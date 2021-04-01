#ifndef APPLICATION_H
#define APPLICATION_H

#include <QApplication>
#include <QObject>
#include "interface.h"
#include "model.h"

class Application : public QApplication
{
    Q_OBJECT

    Interface  *interface;
    Model      *model;

public:
    Application(int,char**);
    ~Application();
};

#endif // APPLICATION_H
