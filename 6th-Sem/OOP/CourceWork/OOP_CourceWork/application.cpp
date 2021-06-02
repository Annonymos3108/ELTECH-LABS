#include "application.h"
#include <QThread>

Application::Application(int argc, char** argv) :
    QApplication(argc,argv)
{
    interface = new Interface();
    interface->show();

    enginer = new Enginer();
    model = new Model(enginer);

    connect(interface,SIGNAL(sendInterfaceEvent(Events)),
            model,SLOT(recieveModelEvent(Events)));
    connect(model,SIGNAL(sendModelEvent(Events)),
            interface,SLOT(recieveInterfaceEvent(Events)));

    connect(interface,SIGNAL(sendInterfaceEvent(Events)),
            enginer,SLOT(receiveEnginerEvent(Events)));

    connect(enginer, SIGNAL(sendEnginerEvent(Events)),
            model, SLOT(recieveModelEvent(Events)));
    connect(model, SIGNAL(sendModelEvent(Events)),
            enginer, SLOT(receiveEnginerEvent(Events)));
}


Application::~Application()
{
    delete model;
    delete interface;
    delete enginer;
}
