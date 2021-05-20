#ifndef STATEWINDOW_H
#define STATEWINDOW_H

#include <QWidget>
#include <QCloseEvent>
#include <QLabel>

#include "statedata.h"

class StateWindow : public QWidget
{
Q_OBJECT

    QLabel *stateLabel;
    QLabel *labelPC1;
    QLabel *labelPC2;
    QLabel *labelPC3;
    QLabel *labelPC4;
    QLabel *labelPC5;
    QLabel *statePC1;
    QLabel *statePC2;
    QLabel *statePC3;
    QLabel *statePC4;
    QLabel *statePC5;
    QLabel *labelEnginer;
    QLabel *enginerState;

public:
    StateWindow(QWidget *parent = 0);
    ~StateWindow();

    void setCurrentState(const StateData&);

protected:
    void closeEvent(QCloseEvent*);

signals:
    void closing();
};

#endif // STATEWINDOW_H
