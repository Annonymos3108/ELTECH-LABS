#ifndef ENGINER_H
#define ENGINER_H

#include <QObject>
#include "eventtypes.h"

class Enginer : public QObject
{
private:
	Q_OBJECT
    StateData state;
    ParamData parameters;

    EnginerState enginerState;

    int enginerCheck();
    void enginerDiagnostic(quint16 PC);
    void enginerRepair(quint16 PC);
    void enginerFix(quint16 PC);

    void paramRequest();
	void stateRequest();
    void stateMessage();


public:
	Enginer();
    void setParamsAndState(StateData, ParamData);
    EnginerState getEnginerState();
    void setEnginerState(EnginerState);
    void dbg();

signals:
    void sendEnginerEvent(Events);
    void finished();

public slots:
    void receiveEnginerEvent(Events);
};

#endif // ENGINER_H
