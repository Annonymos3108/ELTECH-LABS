#ifndef EVENTTYPES_H
#define EVENTTYPES_H

#include "paramdata.h"
#include "statedata.h"

enum EEvents
{
    CHECK = 1,
    DIAG,
    REPAIR,
    FIX,
    ENGINERSTATEMESSAGE,
    ENGINERDIAGMSG,
    PARAMREQUEST,
    PARAMMESSAGE,
    STATEREQUEST,
    STATEMESSAGE,
    RESET,
    TACT,
};

struct Events
{
    EEvents type;
    ParamData  p;
    StateData  s;
    quint16 PC;
    Events(EEvents t) { type = t; }
};

enum EnginerState {
    CHECKWORK = 1,
    DIAGWORK,
    REPAIRWORK,
    NOTBUSY,
};

#endif // EVENTTYPES_H
