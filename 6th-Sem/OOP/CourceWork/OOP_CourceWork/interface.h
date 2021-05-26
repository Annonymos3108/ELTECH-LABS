#ifndef INTERFACE_H
#define INTERFACE_H

#include <QWidget>
#include <QCloseEvent>
#include <QPushButton>

#include "eventtypes.h"

class ParamWindow;
class StateWindow;
class ControlWindow;

class Interface : public QWidget
{
private:
    Q_OBJECT

    ParamWindow   *paramWindow;
    StateWindow   *stateWindow;
    ControlWindow *controlWindow;

    QPushButton *pbtn;
    QPushButton *sbtn;
    QPushButton *cbtn;

public:
    Interface(QWidget *parent = 0);
    ~Interface();

protected:
    void closeEvent(QCloseEvent*);

signals:
    void sendInterfaceEvent(Events);

public slots:
    void paramWindowClosed();
    void stateWindowClosed();
    void controlWindowClosed();
    void recieveInterfaceEvent(Events);

private slots:
    void openParamWindow();
    void openStateWindow();
    void openControlWindow();
};

#endif // INTERFACE_H
