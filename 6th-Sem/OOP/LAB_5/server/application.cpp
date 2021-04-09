#include "application.h"
#include "rational.h"
#include "polinom.h"
#include "common.h"


QString& operator<<(QString& qstr, int rt)
{
    qstr += QString().setNum(rt);
    return qstr;
}


QByteArray& operator>>(QByteArray& arr, int& c)
{
    int p = arr.indexOf(separator);
    if (p > 0)
    {
        c = atoi(arr.left(p));
        arr = arr.right(arr.length()-p-1);
    }
    return arr;
}

TApplication::TApplication(int argc, char *argv[])
            : QCoreApplication(argc,argv)
{
    TCommParams pars = { QHostAddress("127.0.0.1"), 10000,
                         QHostAddress("127.0.0.1"), 10001};
    comm = new TCommunicator(pars, this);

    connect(comm,SIGNAL(recieved(QByteArray)),this,SLOT(recieve(QByteArray)));
}


void TApplication::recieve(QByteArray msg)
{
    QString answer, s;
    int pos = msg.indexOf(separator);
    int t, mode = msg.left(pos).toInt();
    msg = msg.right(msg.length()-pos-1);
    if(mode == R_MODE)
    {
        Rational a, b, c, x, v;
        msg>>a>>b>>c;
        Polinom<Rational> p(a,b,c);
        pos = msg.indexOf(separator);
        t = msg.left(pos).toInt();
        switch (t)
        {
            case VALUE_REQUEST:
                msg = msg.right(msg.length()-pos-1);
                msg>>x;
                v = p.value(x);
                s<<(QString)x<<(QString)v;
                answer<<QString().setNum(VALUE_ANSWER);
                answer += s;
                break;
            case ROOTS_REQUEST:
                s += p.CalculateRoots();
                answer<<QString().setNum(ROOTS_ANSWER)<<s;
                break;
            case PRINT_CLASSIC_REQUEST:
                p.setPrintMode(EPrintModeClassic);
                s<<p;
                answer<<QString().setNum(PRINT_ANSWER)<<s;
                break;
            case PRINT_CANONIC_REQUEST:
                p.setPrintMode(EprintModeCanonical);
                s<<p;
                answer<<QString().setNum(PRINT_ANSWER)<<s;
                break;
            default: return;
        }
    }
    if(mode == I_MODE)
    {
        int a, b, c, x, v;
        msg>>a>>b>>c;
        Polinom<int> p(a,b,c);
        pos = msg.indexOf(separator);
        t = msg.left(pos).toInt();
        switch (t)
        {
            case VALUE_REQUEST:
                msg = msg.right(msg.length()-pos-1);
                msg>>x;
                v = p.value(x);
                s<<("("+QString().setNum(x)+")")<<QString().setNum(v);
                answer<<QString().setNum(VALUE_ANSWER);
                answer += s;
                break;
            case ROOTS_REQUEST:
                s += p.CalculateRoots();
                answer<<QString().setNum(ROOTS_ANSWER)<<s;
                break;
            case PRINT_CLASSIC_REQUEST:
                p.setPrintMode(EPrintModeClassic);
                s<<p;
                answer<<QString().setNum(PRINT_ANSWER)<<s;
                break;
            case PRINT_CANONIC_REQUEST:
                p.setPrintMode(EprintModeCanonical);
                s<<p;
                answer<<QString().setNum(PRINT_ANSWER)<<s;
                break;
            default: return;
        }
    }
    comm->send(QByteArray().append(answer));
}
