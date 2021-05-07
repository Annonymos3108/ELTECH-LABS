#include "application.h"
#include <QThread>

Application::Application(int argc, char** argv) :
    QApplication(argc,argv)
{
    interface = new Interface();
    interface->show();

    enginer = new Enginer();

    model = new Model(enginer);

    //создаем поток
    QThread* thread = new QThread;


    connect(thread, SIGNAL(started()), enginer, SLOT(run()));
    connect(enginer, SIGNAL(finished()), thread, SLOT(terminate()));

    connect(interface,SIGNAL(sendInterfaceEvent(Events)),
            model,SLOT(recieveModelEvent(Events))); 
    connect(model,SIGNAL(sendModelEvent(Events)),
            interface,SLOT(recieveInterfaceEvent(Events)));

    connect(enginer, SIGNAL(sendEnginerEvent(Events)),
            model, SLOT(recieveModelEvent(Events)), Qt::DirectConnection);
    connect(model, SIGNAL(sendModelEvent(Events)),
            enginer, SLOT(recieveEnginerEvent(Events)), Qt::DirectConnection);

    enginer->moveToThread(thread);
    thread->start();
}


Application::~Application()
{
    delete model;
    delete interface;
    delete enginer;
}
