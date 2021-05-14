#include "enginer.h"
#include "windows.h"
#include <QtDebug>

Enginer::Enginer() : QObject()
{
    setEnginerState(NOTBUSY);
}

/*
void Enginer::run()
{
   int s;
   while(true) {
        paramRequest();
        stateRequest();
        s = enginerCheck();
        qDebug() << state.statePC1;
        qDebug() << state.statePC2;
        qDebug() << state.statePC3;
        qDebug() << state.statePC4;
        qDebug() << state.statePC5;
        qDebug() << parameters.checkPeriod;
        qDebug() << "";
        Sleep(parameters.checkPeriod*1000);
        if (s == 0) {
            continue;
        }
        else {
            enginerDiagnostic(s);
            stateMessage();

            qDebug() << state.statePC1;
            qDebug() << state.statePC2;
            qDebug() << state.statePC3;
            qDebug() << state.statePC4;
            qDebug() << state.statePC5;
            qDebug() << parameters.diagnosticsTime;
            qDebug() << "";

            Sleep(parameters.diagnosticsTime*1000);
            enginerRepair(s);
            stateMessage();

            qDebug() << state.statePC1;
            qDebug() << state.statePC2;
            qDebug() << state.statePC3;
            qDebug() << state.statePC4;
            qDebug() << state.statePC5;
            qDebug() << parameters.checkPeriod;
            qDebug() << "";

            Sleep(parameters.repairTime*1000);
            enginerFix(s);
            stateMessage();
            qDebug() << "Diag and Check";
        }
   }
}
*/

void Enginer::stateRequest()
{
    Events msg(STATEREQUEST);
    emit sendEnginerEvent(msg);
}

void Enginer::paramRequest()
{
    Events msg(PARAMREQUEST);
    emit sendEnginerEvent(msg);
}

/*
void Enginer::setParamsAndState(StateData state, ParamData parameters)
{
    this->state = state;
    this->parameters = parameters;
}
*/

EnginerState Enginer::getEnginerState()
{
    return enginerState;
}

void Enginer::setEnginerState(EnginerState s)
{
    enginerState = s;
}

void Enginer::dbg() {
    qDebug() << state.statePC1;
    qDebug() << state.statePC2;
    qDebug() << state.statePC3;
    qDebug() << state.statePC4;
    qDebug() << state.statePC5;
    qDebug() << "ckeckPeriod     = " << parameters.checkPeriod;
    qDebug() << "diagnosticsTime = " << parameters.diagnosticsTime;
    qDebug() << "repairTime      = " << parameters.repairTime;
    qDebug() << "";
}

void Enginer::receiveEnginerEvent(Events msg)
{
    switch (msg.type)
    {
        case CHECK: {
            state = msg.s;
            parameters = msg.p;
            int s = enginerCheck();

            qDebug() << "CHECK";
            dbg();

            Events msg(ENGINERSTATEMESSAGE);
            msg.s = state;
            msg.PC = s;
            if (s == 0) setEnginerState(NOTBUSY);
            else if (s >=1 && s <= 5) setEnginerState(CHECKWORK);
            emit sendEnginerEvent(msg);
            break;
        }
        case DIAG:
        {
            setEnginerState(DIAGWORK);
            state = msg.s;
            parameters = msg.p;

            enginerDiagnostic(msg.PC);

            qDebug() << "DAIG";
            dbg();

            Events msg2(ENGINERSTATEMESSAGE);
            msg2.s = state;
            msg2.PC = msg.PC;
            emit sendEnginerEvent(msg2);
            break;
        }
        case REPAIR:
        {
            setEnginerState(REPAIRWORK);
            state = msg.s;
            parameters = msg.p;

            enginerRepair(msg.PC);

            qDebug() << "REPAIR";
            dbg();

            Events msg2(ENGINERSTATEMESSAGE);
            msg2.s = state;
            msg2.PC = msg.PC;
            emit sendEnginerEvent(msg2);
            break;
        }
        case FIX: {
            state = msg.s;
            enginerFix(msg.PC);

            qDebug() << "FIX";
            dbg();
            Events msg2(ENGINERSTATEMESSAGE);
            msg2.s = state;
            msg2.PC = msg.PC;
            setEnginerState(NOTBUSY);
            emit sendEnginerEvent(msg2);
            break;
        }
        case PARAMMESSAGE:
            parameters = msg.p;
            break;
        case STATEMESSAGE: {
            state = msg.s;
            break;
        }
        case RESET:
            paramRequest();
            stateRequest();
            break;
        default: break;
    }
}

int Enginer::enginerCheck()
{
    if(state.statePC1 == QString("Не работает"))
        return 1;
    if(state.statePC2 == QString("Не работает"))
        return 2;
    if(state.statePC3 == QString("Не работает"))
        return 3;
    if(state.statePC4 == QString("Не работает"))
        return 4;
    if(state.statePC5 == QString("Не работает"))
        return 5;
    return 0;
}

void Enginer::enginerDiagnostic(quint16 PC)
{
    switch (PC) {
    case 1:
        state.statePC1 = QString("Диагностика...");
        return;
    case 2:
        state.statePC2 = QString("Диагностика...");
        return;
    case 3:
        state.statePC3 = QString("Диагностика...");
        return;
    case 4:
        state.statePC4 = QString("Диагностика...");
        return;
    case 5:
        state.statePC5 = QString("Диагностика...");
        return;
    default:
        return;
    }
}

void Enginer::enginerRepair(quint16 PC)
{
    switch (PC) {
    case 1:
        state.statePC1 = QString("Ремонт...");
        return;
    case 2:
        state.statePC2 = QString("Ремонт...");
        return;
    case 3:
        state.statePC3 = QString("Ремонт...");
        return;
    case 4:
        state.statePC4 = QString("Ремонт...");
        return;
    case 5:
        state.statePC5 = QString("Ремонт...");
        return;
    default:
        return;
    }
}

void Enginer::enginerFix(quint16 PC)
{
    switch (PC) {
    case 1:
        state.statePC1 = QString("Работает");
        return;
    case 2:
        state.statePC2 = QString("Работает");
        return;
    case 3:
        state.statePC3 = QString("Работает");
        return;
    case 4:
        state.statePC4 = QString("Работает");
        return;
    case 5:
        state.statePC5 = QString("Работает");
        return;
    default:
        return;
    }
}

