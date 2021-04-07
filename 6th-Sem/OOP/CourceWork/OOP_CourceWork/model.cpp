#include "model.h"
#include <algorithm>
#include <random>
#include <chrono>

#include <thread>
#include <mutex>

ParamData Model::defaultParameters = {0.5,5,1,7};
StateData Model::defaultState      = {"Работает",
                                      "Работает",
                                      "Работает",
                                      "Работает",
                                      "Работает"};

Model::Model() : QThread()
{
    init();
}

void Model::recieveModelEvent(Events msg)
{
    switch (msg.type)
    {
        case PARAMREQUEST:
            paramRequest();
            break;
        case PARAMMESSAGE:
            parameters = msg.data.p;
            break;
        case STATEREQUEST:
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
        default: break;
    }
}

void Model::init()
{
    parameters = defaultParameters;
    state = defaultState;
}

void Model::run()
{
    while (true)
    {
        enginerCheck();
        sleep(parameters.checkPeriod);
    }
}

void Model::tact()
{
    //TODO
    //напистать алгоритм такта, делать функцию
    //которая учитывая параметр "вероятность поломки ПК"
    //будет ломать произвольный компьютер, в случае если этот
    //компьютер уже сломан, сломарем другую

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
}

void Model::paramRequest()
{
    Events msg(PARAMMESSAGE);
    msg.data.p = parameters;
    emit sendModelEvent(msg);
}

void Model::stateRequest()
{
    Events msg(STATEMESSAGE);
    msg.data.s = state;
    emit sendModelEvent(msg);
}

void Model::enginerCheck()
{
    if(state.statePC1 == "Не работает")
        enginerDiagnostic(1);
    if(state.statePC2 == "Не работает")
        enginerDiagnostic(2);
    if(state.statePC3 == "Не работает")
        enginerDiagnostic(3);
    if(state.statePC4 == "Не работает")
        enginerDiagnostic(4);
    if(state.statePC5 == "Не работает")
        enginerDiagnostic(5);
}

void Model::enginerDiagnostic(int PC)
{
    switch (PC) {
    case 1:
        state.statePC1 = "Диагностика...";
        break;
    case 2:
        state.statePC2 = "Диагностика...";
        break;
    case 3:
        state.statePC3 = "Диагностика...";
        break;
    case 4:
        state.statePC4 = "Диагностика...";
        break;
    case 5:
        state.statePC5 = "Диагностика...";
        break;
    default:
        break;
    }
    sleep(parameters.diagnosticsTime);
    enginerRepair(PC);
}

void Model::enginerRepair(int PC)
{
    switch (PC) {
    case 1:
        state.statePC1 = "Ремонт...";
        break;
    case 2:
        state.statePC2 = "Ремонт...";
        break;
    case 3:
        state.statePC3 = "Ремонт...";
        break;
    case 4:
        state.statePC4 = "Ремонт...";
        break;
    case 5:
        state.statePC5 = "Ремонт...";
        break;
    default:
        break;
    }
    sleep(parameters.repairTime);
}
