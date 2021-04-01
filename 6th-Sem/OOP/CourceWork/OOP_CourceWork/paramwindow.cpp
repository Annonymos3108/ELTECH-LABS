#include "paramwindow.h"

ParamWindow::ParamWindow(QWidget *parent) :
    QWidget(parent)
{
    setAttribute(Qt::WA_DeleteOnClose,true);
    setWindowTitle("Параметры");
    setFixedSize(280,200);

    l1 = new QLabel("Вероятность поломки ПК:",this);
    l1->setGeometry(10,10,200,20);
    crashProbability = new QDoubleSpinBox(this);
    crashProbability->setRange(0.0,1.0);
    crashProbability->setGeometry(210,10,50,20);

    l2 = new QLabel("Период обхода инженера:",this);
    l2->setGeometry(10,35,200,20);
    checkPeriod = new QSpinBox(this);
    checkPeriod->setRange(1,100);
    checkPeriod->setGeometry(210,35,50,20);

    l3 = new QLabel("Время выполнения диагностики:",this);
    l3->setGeometry(10,60,200,20);
    diagnosticsTime = new QSpinBox(this);
    diagnosticsTime->setRange(1,100);
    diagnosticsTime->setGeometry(210,60,50,20);

    l4 = new QLabel("Время выполнения ремонта ПК:",this);
    l4->setGeometry(10,85,200,20);
    repairTime = new QSpinBox(this);
    repairTime->setRange(1,500);
    repairTime->setGeometry(210,85,50,20);

    apply_btn = new QPushButton("Применить",this);
    apply_btn->setGeometry(10,120,85,30);
    connect(apply_btn,SIGNAL(pressed()),this,SLOT(setModelParam()));

    cancel_btn = new QPushButton("Отменить",this);
    cancel_btn->setGeometry(105,120,85,30);
    connect(cancel_btn,SIGNAL(pressed()),this,SLOT(restoryModelParam()));
}

ParamWindow::~ParamWindow()
{
    delete l1;
    delete l2;
    delete l3;
    delete l4;
    delete crashProbability;
    delete checkPeriod;
    delete diagnosticsTime;
    delete repairTime;
    delete apply_btn;
    delete cancel_btn;
}

void ParamWindow::closeEvent(QCloseEvent* event)
{
    emit closing();
    event->accept();
}

void ParamWindow::setCurrentParams(const ParamData& pd)
{
    crashProbability->setValue(pd.crashProbability);
    checkPeriod->setValue(pd.checkPeriod);
    diagnosticsTime->setValue(pd.diagnosticsTime);
    repairTime->setValue(pd.repairTime);
}

void ParamWindow::setModelParam()
{
    ParamData pd;
    Events msg(PARAMMESSAGE);
    pd.crashProbability = crashProbability->value();
    pd.checkPeriod = checkPeriod->value();
    pd.diagnosticsTime = diagnosticsTime->value();
    pd.repairTime = repairTime->value();
    msg.data.p = pd;
    emit sendParamMessage(msg);
}

void ParamWindow::restoryModelParam()
{
    Events msg(PARAMREQUEST);
    emit sendParamMessage(msg);
}
