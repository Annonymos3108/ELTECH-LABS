#ifndef APPLICATION_H
#define APPLICATION_H

#include <QObject>
#include <QCoreApplication>

#include "communicator.h"

class TApplication : public QCoreApplication
{
    Q_OBJECT

    TCommunicator *comm;

public:

    TApplication(int, char**);
    friend QString& operator<<(QString&, int);
    friend QByteArray& operator>>(QByteArray&, int&);

signals:

public slots:

    void recieve(QByteArray);

};

#endif // APPLICATION_H
