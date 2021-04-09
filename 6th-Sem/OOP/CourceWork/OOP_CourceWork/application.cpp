#include "application.h"
//#include "eventtypes.h"

Application::Application(int argc, char** argv) :
    QApplication(argc,argv)
{
    interface = new Interface();
    interface->show();

    model = new Model();
    model->start();

    connect(interface,SIGNAL(sendInterfaceEvent(TEvents)),
            model,SLOT(recieveModelEvent(TEvents)));
    connect(model,SIGNAL(sendModelEvent(TEvents)),
            interface,SLOT(recieveInterfaceEvent(TEvents)));
}

Application::~Application()
{
    //delete model;
    delete interface;
}
