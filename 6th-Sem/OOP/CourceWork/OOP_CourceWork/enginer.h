#ifndef ENGINER_H
#define ENGINER_H

#include <QObject>
#include "eventtypes.h"
#include <atomic>

class Enginer : public QObject
{
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
	//*& ссылка на указатель, это позволит изменить исходные
	//переменные в классе Model (починить сломавшие компьютеры)
	Enginer();
    void setParamsAndState(StateData, ParamData);
    EnginerState getEnginerState();
    void setEnginerState(EnginerState);
    void dbg();
protected:
    //void run();

signals:
    void sendEnginerEvent(Events);
    void finished();

public slots:
    void receiveEnginerEvent(Events);
    //void run();


};

#endif // ENGINER_H
