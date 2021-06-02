#include "statewindow.h"
#include "interface.h"

StateWindow::StateWindow(QWidget *parent) :
    QWidget(parent)
{
    setAttribute(Qt::WA_DeleteOnClose,true);
    setFixedSize(280,210);
    setWindowTitle("Состояние");

    stateLabel = new QLabel("Состояние:",this);
    stateLabel->setGeometry(10,10,180,20);

    labelPC1 = new QLabel("1 ПК:",this);
    labelPC1->setGeometry(10,35,50,20);
    statePC1 = new QLabel(this);
    statePC1->setGeometry(80,35,130,20);

    labelPC2 = new QLabel("2 ПК:",this);
    labelPC2->setGeometry(10,60,50,20);
    statePC2 = new QLabel(this);
    statePC2->setGeometry(80,60,130,20);

    labelPC3 = new QLabel("3 ПК:",this);
    labelPC3->setGeometry(10,85,50,20);
    statePC3 = new QLabel(this);
    statePC3->setGeometry(80,85,130,20);

    labelPC4 = new QLabel("4 ПК:",this);
    labelPC4->setGeometry(10,110,50,20);
    statePC4 = new QLabel(this);
    statePC4->setGeometry(80,110,130,20);

    labelPC5 = new QLabel("5 ПК:",this);
    labelPC5->setGeometry(10,135,50,20);
    statePC5 = new QLabel(this);
    statePC5->setGeometry(80,135,130,20);

    labelEnginer = new QLabel("Состояние инженера:", this);
    labelEnginer->setGeometry(10,160,160,20);
    enginerState = new QLabel(this);
    enginerState->setGeometry(40,180,230,20);
}

StateWindow::~StateWindow()
{
    delete stateLabel;
    delete labelPC1;
    delete labelPC2;
    delete labelPC3;
    delete labelPC4;
    delete labelPC5;
    delete statePC1;
    delete statePC2;
    delete statePC3;
    delete statePC4;
    delete statePC5;
    delete labelEnginer;
    delete enginerState;
}

void StateWindow::setCurrentState(const StateData& s)
{
    statePC1->setText(s.statePC1);
    statePC2->setText(s.statePC2);
    statePC3->setText(s.statePC3);
    statePC4->setText(s.statePC4);
    statePC5->setText(s.statePC5);
    enginerState->setText(s.enginerState);
    //repaint();
}

void StateWindow::closeEvent(QCloseEvent* event)
{
    emit closing();
    event->accept();
}

