#ifndef PARAMDATA_H
#define PARAMDATA_H

#include <QObject>

struct ParamData
{
    float crashProbability;     //0-1
    quint32 checkPeriod;        //seconds
    quint32 diagnosticsTime;    //seconds
    quint32 repairTime;         //seconds
};

#endif // PARAMDATA_H
