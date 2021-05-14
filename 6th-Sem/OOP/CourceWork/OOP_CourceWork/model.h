#ifndef MODEL_H
#define MODEL_H

#include <QObject>
#include <QTimer>
#include "enginer.h"
#include "eventtypes.h"

class Model : public QObject
{
	Q_OBJECT
	//параметры
	static ParamData defaultParameters;
	ParamData parameters;
    Enginer* enginer;

    QTimer *timer;
    std::vector<quint32> paramsCount;
    quint16 PC;

	//состояние
	static StateData defaultState;
	StateData state;

	void init();
	void tact();
	void paramRequest();
	void stateRequest();


    //void SetEnginerState();
public:
    Model(Enginer*);

signals:
	void sendModelEvent(Events);

public slots:
	void recieveModelEvent(Events);
    void SayEnginerToCheck();
    void SayEnginerToDiag();
    void SayEnginerToRepair();
    void SayEnginerToFix();

};

#endif // MODEL_H
