#include "enginer.h"
#include "windows.h"

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
   enginerCheck();
}

void Enginer::recieveEnginerEvent(Events msg)
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
    case RESET:
        enginerCheck();
        paramRequest();
        stateRequest();
        break;
    default: break;
    }
}

void Enginer::paramRequest()
{
    Events msg(PARAMMESSAGE);
    msg.p = parameters;
    emit sendEnginerEvent(msg);
}

void Enginer::stateRequest()
{
    Events msg(STATEMESSAGE);
    msg.s = state;
    emit sendEnginerEvent(msg);
}

void Enginer::enginerCheck()
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
    Sleep(parameters.checkPeriod);
    enginerCheck();
}

void Enginer::enginerDiagnostic(int PC)
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
    Sleep(parameters.diagnosticsTime);
    enginerRepair(PC);
}

void Enginer::enginerRepair(int PC)
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
    Sleep(parameters.repairTime);
    enginerCheck();
}

