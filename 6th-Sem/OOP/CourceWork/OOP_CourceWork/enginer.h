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

    int enginerCheck();
    void enginerDiagnostic(int PC);
    void enginerRepair(int PC);
    void enginerFix(int PC);
	void paramRequest();
	void stateRequest();
    void stateMessage();

public:
	//*& ссылка на указатель, это позволит изменить исходные
	//переменные в классе Model (починить сломавшие компьютеры)
	Enginer();
    void setParamsAndState(StateData, ParamData);
protected:
    //void run();

public slots:
    void run();
signals:
	void sendEnginerEvent(Events);
    void finished();
};

#endif // ENGINER_H
