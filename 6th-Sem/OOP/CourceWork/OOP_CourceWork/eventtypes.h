#ifndef EVENTTYPES_H
#define EVENTTYPES_H

#include "paramdata.h"
#include "statedata.h"

enum EEvents
{
    CLIENTNO = 1,
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
    struct
    {
        ParamData  p;
        StateData  s;
    } data;

    Events(EEvents t) { type = t; }
};

#endif // EVENTTYPES_H
