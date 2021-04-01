#include "model.h"

ParamData Model::defaultParameters = {0.5,5,1,7};
StateData Model::defaultState      = {"Работает",
                                      "Работает",
                                      "Работает",
                                      "Работает",
                                      "Работает"};

Model::Model() : QObject()
{
    init();
}

void Model::recieveModelEvent(Events msg)
{
    switch (msg.type)
    {
        case PARAMREQUEST:
            paramRequest();
            break;
        case PARAMMESSAGE:
            parameters = msg.data.p;
            break;
        case STATEREQUEST:
            stateRequest();
            break;
        case RESET:
            init();
            paramRequest();
            stateRequest();
            break;
        case TACT:
            tact();
            stateRequest();
            break;
        default: break;
    }
}

void Model::init()
{
    parameters = defaultParameters;
    state = defaultState;
}

#include <QtMath>

void Model::tact()
{
    //TODO
    //напистать алгоритм такта, делать функцию
    //которая учитывая параметр "вероятность поломки ПК"
    //будет ломать произвольный компьютер, в случае если этот
    //компьютер уже сломан, сломарем другую

    for (int i=0; i < 100; i++) {

        if (parameters.crashProbability){

        }
    }
    /*
    state.statePC1 = (state.r1 + parameters.p1) % parameters.m;
    while (state.r1 < 0) state.r1 += parameters.m;
    state.r2 = (state.r2 + parameters.p2) % parameters.m;
    while (state.r2 < 0) state.r2 += parameters.m;
    */
}

void Model::paramRequest()
{
    Events msg(PARAMMESSAGE);
    msg.data.p = parameters;
    emit sendModelEvent(msg);
}

void Model::stateRequest()
{
    Events msg(STATEMESSAGE);
    msg.data.s = state;
    emit sendModelEvent(msg);
}
