#ifndef CONTROLWINDOW_H
#define CONTROLWINDOW_H

#include <QWidget>
#include <QCloseEvent>
#include <QPushButton>
#include "eventtypes.h"

class ControlWindow : public QWidget
{
Q_OBJECT

    QPushButton *b1;
    QPushButton *b2;

public:
    ControlWindow(QWidget *parent = 0);
    ~ControlWindow();

protected:
    void closeEvent(QCloseEvent*);

private slots:
    void controlEvent();

signals:
    void closing();
    void sendControlMessage(Events);
};

#endif // CONTROLWINDOW_H
