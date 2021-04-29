#include <QObject>
#include "eventtypes.h"

#ifndef ENGINER_H
#define ENGINER_H

class Enginer : public QObject
{
	Q_OBJECT
	StateData state;
	ParamData parameters;

	void enginerCheck();
	void enginerDiagnostic(int PC);
	void enginerRepair(int PC);
	void paramRequest();
	void stateRequest();

public:
	//*& ������ �� ���������, ��� �������� �������� ��������
	//���������� � ������ Model (�������� ��������� ����������)
	Enginer();
	void setParamsAndState(StateData, ParamData);
protected:
	void run();

public slots:
	void recieveEnginerEvent(Events);
signals:
	void sendEnginerEvent(Events);
};

#endif // ENGINER_H
