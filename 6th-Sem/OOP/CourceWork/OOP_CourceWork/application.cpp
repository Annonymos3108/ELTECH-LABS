#include "application.h"
//#include "eventtypes.h"

Application::Application(int argc, char** argv) :
    QApplication(argc,argv)
{
    interface = new Interface();
    interface->show();

    model = new Model();
    model->start();

    connect(interface,SIGNAL(sendInterfaceEvent(Events)),
            model,SLOT(recieveModelEvent(Events)));
    connect(model,SIGNAL(sendModelEvent(Events)),
            interface,SLOT(recieveInterfaceEvent(Events)));
}

Application::~Application()
{
    //delete model;
    delete interface;
}
