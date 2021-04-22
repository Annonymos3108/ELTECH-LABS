#ifndef MODEL_H
#define MODEL_H

#include <QObject>
#include <QThread>

#include "eventtypes.h"

class Model : public QThread
{
    Q_OBJECT
        //параметры
        static ParamData defaultParameters;
        ParamData parameters;

        //состояние
        static StateData defaultState;
        StateData state;

        void init();
        void tact();
        void paramRequest();
        void stateRequest();

        //выполняется в отдельном потоке, в фоне
        void run() override;
        void loadEnginer();
        void enginerCheck();
        void enginerDiagnostic(int PC);
        void enginerRepair(int PC);

    public:
        Model();

    signals:
        void sendModelEvent(Events);

    public slots:
        void recieveModelEvent(Events);

        

};

#endif // MODEL_H
