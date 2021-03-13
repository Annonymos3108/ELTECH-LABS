#include "interface.h"

Interface::Interface(QWidget *parent)
    : QWidget(parent)
{
    setWindowTitle("Работа №3");
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

    connect(value_btn,SIGNAL(pressed()),this, SLOT(value()));
    connect(root_btn,SIGNAL(pressed()),this, SLOT(root()));
    connect(print_classic_btn,SIGNAL(pressed()),this, SLOT(print_classic()));
    connect(print_canonic_btn,SIGNAL(pressed()),this, SLOT(print_canonic()));

}


Interface::~Interface()
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


void Interface::value()
{
    number a(a_numerator->text().toInt(), a_denominator->text().toUInt());
    number b(b_numerator->text().toInt(), b_denominator->text().toUInt());
    number c(c_numerator->text().toInt(), c_denominator->text().toUInt());
    number x(x_numerator->text().toInt(), x_denominator->text().toUInt());
    Polinom p(a, b, c);
    number v = p.value(x);
    QString qstr("Значение полинома p");
    qstr << x;
    qstr += " = ";
    qstr << v;
    output->setText(qstr);
}


void Interface::root()
{   number a(a_numerator->text().toInt(), a_denominator->text().toUInt());
    number b(b_numerator->text().toInt(), b_denominator->text().toUInt());
    number c(c_numerator->text().toInt(), c_denominator->text().toUInt());
    Polinom p(a, b, c);
    QString qstr = p.Calculate(p);
    output->setText(qstr);
}


void Interface::print_classic()
{
    number a(a_numerator->text().toInt(), a_denominator->text().toUInt());
    number b(b_numerator->text().toInt(), b_denominator->text().toUInt());
    number c(c_numerator->text().toInt(), c_denominator->text().toUInt());
    Polinom p(a, b, c);
    p.setPrintMode(EPrintModeClassic);
    QString qstr("");
    qstr << p;
    output->setText(qstr);
}


void Interface::print_canonic()
{
    number a(a_numerator->text().toInt(), a_denominator->text().toUInt());
    number b(b_numerator->text().toInt(), b_denominator->text().toUInt());
    number c(c_numerator->text().toInt(), c_denominator->text().toUInt());
    Polinom p(a, b, c);
    p.setPrintMode(EprintModeCanonical);
    QString qstr("");
    qstr << p;
    output->setText(qstr);
}


