#include "enginer.h"
/*
Enginer::Enginer() : QObject()
{
    data = nullptr;
}

void Enginer::recieveModelEvent(Events msg)
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

void Enginer::run()
{
    while (true)
    {
        enginerCheck();
        sleep(parameters.checkPeriod);
    }
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
    sleep(parameters.diagnosticsTime);
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
    sleep(parameters.repairTime);
}
*/
