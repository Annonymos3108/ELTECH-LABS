#include "controlwindow.h"

ControlWindow::ControlWindow(QWidget *parent) :
    QWidget(parent)
{
    setAttribute(Qt::WA_DeleteOnClose,true);
    setFixedSize(300,85);
    setWindowTitle("Управление");

    b1 = new QPushButton("Сброс",this);
    b1->setGeometry(40,10,220,30);
    connect(b1,SIGNAL(pressed()),this,SLOT(controlEvent()));

    //b2 = new QPushButton("Одиночное событие",this);
    b2 = new QPushButton("Сломать произвольный ПК",this);
    b2->setGeometry(40,45,220,30);
    connect(b2,SIGNAL(pressed()),this,SLOT(controlEvent()));
}

ControlWindow::~ControlWindow()
{
    delete b2;
    delete b1;
}

void ControlWindow::controlEvent()
{
    QPushButton *btn = (QPushButton*)sender();
    if (btn == b1)
    {
        Events msg(RESET);
        emit sendControlMessage(msg);
    }
    if (btn == b2)
    {
        Events msg(TACT);
        emit sendControlMessage(msg);
    }
}

void ControlWindow::closeEvent(QCloseEvent* event)
{
    emit closing();
    event->accept();
}
