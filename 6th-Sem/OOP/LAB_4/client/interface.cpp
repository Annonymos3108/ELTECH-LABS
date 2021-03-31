#include "interface.h"
#include "common.h"

TInterface::TInterface(QWidget *parent) : QWidget(parent)
{
    setWindowTitle("Работа №4");
    setFixedSize(360,280);

    name_a = new QLabel("a =", this);
    name_a->setGeometry(30,20,30,25);
    a_numerator = new QLineEdit("2", this);
    a_numerator->setGeometry(70,20,50,25);
    delimeter_a = new QLabel("/", this);
    delimeter_a->setGeometry(130,20,30,25);
    a_denominator = new QLineEdit("5", this);
    a_denominator->setGeometry(145,20,50,25);

    name_b = new QLabel("b =", this);
    name_b->setGeometry(30,50,30,25);
    b_numerator = new QLineEdit("4", this);
    b_numerator->setGeometry(70,50,50,25);
    delimeter_b = new QLabel("/", this);
    delimeter_b->setGeometry(130,50,30,25);
    b_denominator = new QLineEdit("5", this);
    b_denominator->setGeometry(145,50,50,25);

    name_c = new QLabel("c =", this);
    name_c->setGeometry(30,80,30,25);
    c_numerator = new QLineEdit("112", this);
    c_numerator->setGeometry(70,80,50,25);
    delimeter_c = new QLabel("/", this);
    delimeter_c->setGeometry(130,80,30,25);
    c_denominator = new QLineEdit("405", this);
    c_denominator->setGeometry(145,80,50,25);

    name_x = new QLabel("x =", this);
    name_x->setGeometry(30,110,30,25);
    x_numerator = new QLineEdit("7", this);
    x_numerator->setGeometry(70,110,50,25);
    delimeter_x = new QLabel("/", this);
    delimeter_x->setGeometry(130,110,30,25);
    x_denominator = new QLineEdit("8", this);
    x_denominator->setGeometry(145,110,50,25);

    value_btn = new QPushButton("Значение", this);
    value_btn->setGeometry(10,150,100,30);
    root_btn = new QPushButton("Корни", this);
    root_btn->setGeometry(130,150,60,30);
    print_classic_btn = new QPushButton("Класс.", this);
    print_classic_btn->setGeometry(210,150,60,30);
    print_canonic_btn = new QPushButton("Канон.", this);
    print_canonic_btn->setGeometry(290,150,60,30);

    output = new QLabel(this);
    output->setGeometry(20,200,340,50);

    connect(value_btn,SIGNAL(pressed()),this,SLOT(formRequest()));
    connect(root_btn,SIGNAL(pressed()),this,SLOT(formRequest()));
    connect(print_classic_btn,SIGNAL(pressed()),this,SLOT(formRequest()));
    connect(print_canonic_btn,SIGNAL(pressed()),this,SLOT(formRequest()));
}

TInterface::~TInterface()
{
    delete name_a;
    delete delimeter_a;
    delete a_numerator;
    delete a_denominator;

    delete name_b;
    delete delimeter_b;
    delete b_numerator;
    delete b_denominator;

    delete name_c;
    delete delimeter_c;
    delete c_numerator;
    delete c_denominator;

    delete name_x;
    delete delimeter_x;
    delete x_numerator;
    delete x_denominator;

    delete value_btn;
    delete root_btn;
    delete print_classic_btn;
    delete print_canonic_btn;

    delete output;
}

void TInterface::formRequest()
{
    QString msg;
    msg << a_numerator->text() << a_denominator->text();
    msg << b_numerator->text() << b_denominator->text();
    msg << c_numerator->text() << c_denominator->text();
    QPushButton *btn = (QPushButton*)sender();
    if (btn == value_btn)
    {
        msg << QString().setNum(VALUE_REQUEST);
        msg << x_numerator->text() << x_denominator->text();
    }
    if (btn == root_btn)
    {
        msg << QString().setNum(ROOTS_REQUEST);
    }
    if (btn == print_classic_btn)
    {
       msg << QString().setNum(PRINT_CLASSIC_REQUEST);
    }
    if (btn == print_canonic_btn)
    {
        msg << QString().setNum(PRINT_CANONIC_REQUEST);
    }
    emit request(msg);
}

void TInterface::answer(QString msg)
{
    QString text;
    int p = msg.indexOf(separator);
    int t = msg.left(p).toInt();
    msg = msg.mid(p+1,msg.length()-p-2);
    switch (t)
    {
        case VALUE_ANSWER:
            text = "Значение полинома p";
            p = msg.indexOf(separator);
            text += msg.left(p);
            text += " = ";
            text += msg.right(msg.length()-p-1);
            output->setText(text);
            break;
        case ROOTS_ANSWER:
            text = "";
            text<<msg;
            output->setText(text);
            break;
        case PRINT_ANSWER:
            text = "";
            text<<msg;
            output->setText(text);
            break;
        default: break;
    }
}
