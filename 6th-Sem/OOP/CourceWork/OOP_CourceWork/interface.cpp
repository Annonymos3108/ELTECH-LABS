#include "interface.h"
#include "paramwindow.h"
#include "statewindow.h"
#include "controlwindow.h"

Interface::Interface(QWidget *parent)
    : QWidget(parent)
{
    setFixedSize(300,120);
    setWindowTitle("Computing center");

    paramWindow   = nullptr;
    stateWindow   = nullptr;
    controlWindow = nullptr;

    pbtn = new QPushButton("Параметры",this);
    pbtn->setGeometry(40,10,220,30);
    connect(pbtn,SIGNAL(pressed()),this,SLOT(openParamWindow()));

    sbtn = new QPushButton("Состояние",this);
    sbtn->setGeometry(40,45,220,30);
    connect(sbtn,SIGNAL(pressed()),this,SLOT(openStateWindow()));

    cbtn = new QPushButton("Управление",this);
    cbtn->setGeometry(40,80,220,30);
    connect(cbtn,SIGNAL(pressed()),this,SLOT(openControlWindow()));
}

Interface::~Interface()
{
    delete cbtn;
    delete pbtn;
    delete sbtn;
}

void Interface::recieveInterfaceEvent(Events msg)
{
    switch (msg.type)
    {
        case PARAMMESSAGE:
            if (paramWindow != nullptr)
                paramWindow->setCurrentParams(msg.data.p);
            break;
        case STATEMESSAGE:
            if (stateWindow != nullptr)
                stateWindow->setCurrentState(msg.data.s);
            break;
        default: break;
    }
}

void Interface::closeEvent(QCloseEvent* event)
{
    if (paramWindow != nullptr)
    {
        disconnect(paramWindow,SIGNAL(closing()),
                this,SLOT(paramWindowClosed()));
        paramWindow->close();
    }
    if (stateWindow != nullptr)
    {
        disconnect(stateWindow,SIGNAL(closing()),
                this,SLOT(stateWindowClosed()));
        stateWindow->close();
    }
    if (controlWindow != nullptr)
    {
        disconnect(controlWindow,SIGNAL(closing()),
                this,SLOT(controlWindowClosed()));
        controlWindow->close();
    }
    event->accept();
}

void Interface::paramWindowClosed()
{
    disconnect(paramWindow,SIGNAL(sendParamMessage(Events)),
               this,SIGNAL(sendInterfaceEvent(Events)));
    disconnect(paramWindow,SIGNAL(closing()),
               this,SLOT(paramWindowClosed()));
    paramWindow = nullptr;
}

void Interface::stateWindowClosed()
{
    disconnect(stateWindow,SIGNAL(closing()),
               this,SLOT(stateWindowClosed()));
    stateWindow = nullptr;
}

void Interface::controlWindowClosed()
{
    disconnect(controlWindow,SIGNAL(closing()),
               this,SLOT(controlWindowClosed()));
    disconnect(controlWindow,SIGNAL(sendControlMessage(Events)),
               this,SIGNAL(sendInterfaceEvent(Events)));
    controlWindow = nullptr;
}

void Interface::openParamWindow()
{
    if (paramWindow == nullptr)
    {
        paramWindow = new ParamWindow();
        connect(paramWindow,SIGNAL(closing()),
                this,SLOT(paramWindowClosed()));
        connect(paramWindow,SIGNAL(sendParamMessage(Events)),
                this,SIGNAL(sendInterfaceEvent(Events)));
        paramWindow->show();
        Events msg(PARAMREQUEST);
        emit sendInterfaceEvent(msg);
    }
}

void Interface::openStateWindow()
{
    if (stateWindow == nullptr)
    {
        stateWindow = new StateWindow();
        connect(stateWindow,SIGNAL(closing()),
                this,SLOT(stateWindowClosed()));
        stateWindow->show();
        Events msg(STATEREQUEST);
        emit sendInterfaceEvent(msg);
    }
}

void Interface::openControlWindow()
{
    if (controlWindow == nullptr)
    {
        controlWindow = new ControlWindow();
        connect(controlWindow,SIGNAL(closing()),
                this,SLOT(controlWindowClosed()));
        connect(controlWindow,SIGNAL(sendControlMessage(Events)),
                this,SIGNAL(sendInterfaceEvent(Events)));
        controlWindow->show();
    }
}
