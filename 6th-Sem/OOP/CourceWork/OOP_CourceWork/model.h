#ifndef MODEL_H
#define MODEL_H

#include <QObject>
#include <QTimer>
#include "enginer.h"
#include "eventtypes.h"

class Model : public QObject
{
private:
	Q_OBJECT

	static ParamData defaultParameters;
    static StateData defaultState;

    ParamData parameters;
    StateData state;

    Enginer* enginer;

    QTimer *timer;

    std::vector<quint32> paramsCount;
    quint16 PC;

    void init();
	void tact();
	void paramRequest();
	void stateRequest();

public:
    Model(Enginer*);
    ~Model();

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
