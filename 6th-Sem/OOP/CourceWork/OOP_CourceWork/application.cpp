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
    connect(interface, SIGNAL(sendInterfaceEvent(Events)),
            enginer, SLOT(receiveEnginerEvent(Events)));
    connect(enginer, SIGNAL(sendEnginerEvent(Events)),
            interface, SLOT(receiveInterfaceEvent(Events)));

    //создаем поток
    QThread* thread = new QThread;
    enginer->moveToThread(thread);
    thread->start();
}


Application::~Application()
{
    delete model;
    delete interface;
    delete enginer;
}
