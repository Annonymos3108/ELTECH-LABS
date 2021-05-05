#include "enginer.h"
#include "windows.h"
#include <QtDebug>

Enginer::Enginer() : QObject()
{
}

void Enginer::setParamsAndState(StateData state, ParamData parameters)
{
    this->state = state;
    this->parameters = parameters;
}


void Enginer::run()
{
   int s;
   while(true) {
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
            qDebug() << "Diag and Check";
        }
   }
}

void Enginer::stateMessage()
{
    Events msg(STATEMESSAGE);
    msg.s = state;
    emit sendEnginerEvent(msg);
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

void Enginer::enginerDiagnostic(int PC)
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

void Enginer::enginerRepair(int PC)
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

void Enginer::enginerFix(int PC)
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

