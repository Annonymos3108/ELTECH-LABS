#ifndef INTERFACE_H
#define INTERFACE_H

#include <QWidget>

class Interface : public QWidget
{
    Q_OBJECT

public:
    Interface(QWidget *parent = nullptr);
    ~Interface();
};
#endif // INTERFACE_H
