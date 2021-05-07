#ifndef MODEL_H
#define MODEL_H

#include <QObject>
#include "enginer.h"
#include "eventtypes.h"

class Model : public QObject
{
	Q_OBJECT
	//параметры
	static ParamData defaultParameters;
	ParamData parameters;
	Enginer* enginer;

	//состояние
	static StateData defaultState;
	StateData state;

	void init();
	void tact();
	void paramRequest();
	void stateRequest();
public:
	Model(Enginer*);

signals:
	void sendModelEvent(Events);

public slots:
	void recieveModelEvent(Events);

};

#endif // MODEL_H
