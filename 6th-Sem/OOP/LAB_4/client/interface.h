#ifndef INTERFACE_H
#define INTERFACE_H

#include <QWidget>
#include <QLabel>
#include <QLineEdit>
#include <QPushButton>

class TInterface : public QWidget
{
    Q_OBJECT

    QLabel *name_a, *delimeter_a;
    QLineEdit *a_numerator, *a_denominator;
    QLabel *name_b, *delimeter_b;
    QLineEdit *b_numerator, *b_denominator;
    QLabel *name_c, *delimeter_c;
    QLineEdit *c_numerator, *c_denominator;
    QLabel *name_x, *delimeter_x;
    QLineEdit *x_numerator, *x_denominator;

    QPushButton *value_btn;
    QPushButton *root_btn;
    QPushButton *print_classic_btn;
    QPushButton *print_canonic_btn;

    QLabel *output;

public:
    TInterface(QWidget *parent = 0);
    ~TInterface();

public slots:
    void answer(QString);

private slots:
    void formRequest();

signals:
    void request(QString);

};

#endif // INTERFACE_H
