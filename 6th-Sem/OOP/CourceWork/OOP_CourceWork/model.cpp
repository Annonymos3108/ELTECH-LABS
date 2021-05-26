#include "model.h"
#include <algorithm>
#include <random>
#include <chrono>
#include <windows.h>
#include <QThread>



ParamData Model::defaultParameters = {0.5,5,1,7};
StateData Model::defaultState      = {QString("Работает"),
                                      QString("Работает"),
                                      QString("Работает"),
                                      QString("Работает"),
                                      QString("Работает"),
                                      QString("Проверяет ПК с задданым периудом")};

Model::Model(Enginer* enginer_) : QObject(), timer(new QTimer()), paramsCount(4)
{
    parameters = defaultParameters;
    state = defaultState;  
    enginer = enginer_;
    //enginer->setParamsAndState(state, parameters);
    timer->setInterval(1000); //1 sec interval
    connect(timer, SIGNAL(timeout()),this, SLOT(SayEnginerToCheck()));
    connect(timer, SIGNAL(timeout()),this, SLOT(SayEnginerToDiag()));
    connect(timer, SIGNAL(timeout()),this, SLOT(SayEnginerToRepair()));
    connect(timer, SIGNAL(timeout()),this, SLOT(SayEnginerToFix()));
    //connect(timer, SIGNAL(timeout()),this, SLOT(SetEnginerState()));
    timer->start();

}

Model::~Model()
{
    delete timer;
}

void Model::recieveModelEvent(Events msg)
{
    switch (msg.type)
    {
        case PARAMREQUEST:
            paramRequest();
            break;
        case PARAMMESSAGE:
            parameters = msg.p;
            break;
        case STATEREQUEST:
            stateRequest();
            break;
        case STATEMESSAGE:
            state = msg.s;
            stateRequest();
            break;
        case RESET:
            init();
            paramRequest();
            stateRequest();
            break;
        case TACT:
            tact();
            stateRequest();
            break;
        case ENGINERSTATEMESSAGE: {
            state = msg.s;
            if (msg.PC >= 1 && msg.PC <= 5)
                PC = msg.PC;
            else PC = 0;
            Events msg2(STATEMESSAGE);
            msg2.s = state;
            //отправка на интерфейс
            emit sendModelEvent(msg2);
            break;
        }

        default: break;
    }
}



void Model::init()
{
    parameters = defaultParameters;
    state = defaultState;
    enginer->setParamsAndState(state, parameters);
}


void Model::tact()
{
    std::vector<int> a(100);
    int prob = int(parameters.crashProbability * 100);
    fill_n(a.begin(), prob, 1);            // 1 - сломаем
    fill_n(a.begin() + prob, 100-prob, 0); // 0 - не сломаем

    //перемешиваем
    unsigned seed = std::chrono::system_clock::now().time_since_epoch().count();
    shuffle(a.begin(), a.end(), std::default_random_engine(seed));

    srand(time(NULL));
    //тыкаем в рандомную позицию
    bool isCrash = bool(a[int(abs(rand())%100)]);

    //сломаем или не сломаем
    if (isCrash) {
        do {
            //если все таки сломаем, то выбираем какой именно
            int id = int(abs(rand())%5);
            //если все не работают
            if (state.statePC1 == "Не работает" &&
                state.statePC2 == "Не работает" &&
                state.statePC3 == "Не работает" &&
                state.statePC4 == "Не работает" &&
                state.statePC5 == "Не работает")
            {
                //выходим из цикла ибо нечего сломать.
                break;
            }
            switch (id) {
                case 0:
                    //если уже сломанно, пытаемся еще раз выбрать рандомный ПК
                    if(state.statePC1 == "Не работает")
                        continue;
                    state.statePC1 = "Не работает";
                    break;
                case 1:
                    if(state.statePC2 == "Не работает")
                        continue;
                    state.statePC2 = "Не работает";
                    break;
                case 2:
                    if(state.statePC3 == "Не работает")
                        continue;
                    state.statePC3 = "Не работает";
                    break;
                case 3:
                    if(state.statePC4 == "Не работает")
                        continue;
                    state.statePC4 = "Не работает";
                    break;
                case 4:
                    if(state.statePC5 == "Не работает")
                        continue;
                    state.statePC5 = "Не работает";
                    break;
                default:
                    break;
            }
            //если все таки вышли из свич блока
            //значит дело сделано и бесконечный цикл
            //можно прервать
            break;
        }while (true);
    }
    //enginer->setParamsAndState(state, parameters);
}

void Model::paramRequest()
{
    Events msg(PARAMMESSAGE);
    msg.p = parameters;
    emit sendModelEvent(msg);
}

void Model::stateRequest()
{
    Events msg(STATEMESSAGE);
    msg.s = state;
    emit sendModelEvent(msg);
}

//TODO
// исправить время ожидания quint32 time в каждом

void Model::SayEnginerToCheck()
{
    paramsCount[0]++;
    if (paramsCount[0] >= parameters.checkPeriod &&
        enginer->getEnginerState() == NOTBUSY ) {
        //если инжинер НЕ занят обходом, диагностикой или ремонтом
        Events msg(CHECK);
        msg.s = state;
        msg.p = parameters;
        paramsCount[0] = 0;
        emit sendModelEvent(msg);
    }
}

void Model::SayEnginerToDiag()
{
    paramsCount[1]++;
    if (!(PC >= 1 && PC <= 5)) return;
    quint32 time = parameters.checkPeriod;
    if (paramsCount[1] >= time &&
            enginer->getEnginerState() == CHECKWORK){
        Events msg(DIAG);
        msg.s = state;
        msg.PC = PC;
        paramsCount[1] = 0;
        emit sendModelEvent(msg);
    }
}

void Model::SayEnginerToRepair()
{
    paramsCount[2]++;
    if (!(PC >= 1 && PC <= 5)) return;
    quint32 time = parameters.checkPeriod +
                   parameters.diagnosticsTime;
    if (paramsCount[2] >= time &&
            enginer->getEnginerState() == DIAGWORK){
        Events msg(REPAIR);
        msg.s = state;
        msg.PC = PC;
        paramsCount[2] = 0;
        emit sendModelEvent(msg);
    }
}

void Model::SayEnginerToFix()
{
    paramsCount[3]++;
    if (!(PC >= 1 && PC <= 5)) return;
    quint32 time = parameters.checkPeriod +
                   parameters.diagnosticsTime +
                   parameters.repairTime;
    if (paramsCount[3] >= time &&
            enginer->getEnginerState() == REPAIRWORK){
        Events msg(FIX);
        msg.s = state;
        msg.PC = PC;
        emit sendModelEvent(msg);
        paramsCount[3] = 0;
    }
}
