#ifndef COMMON_H
#define COMMON_H

#include <QString>

enum messages
{
    VALUE_REQUEST = 1,
    VALUE_ANSWER,
    PRINT_CLASSIC_REQUEST,
    PRINT_CANONIC_REQUEST,
    PRINT_ANSWER,
    ROOTS_REQUEST,
    ROOTS_ANSWER,
};

enum modes
{
    I_MODE = 1,
    R_MODE,
};

extern const QChar separator;
QString& operator<< (QString&,const QString&);

#endif // COMMON_H
