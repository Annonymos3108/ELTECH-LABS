#include "derivesample.h"
#include <math.h>

DeriveSample::DeriveSample(int n) : DrawPoly(n)
{
    active = 0;
}

void DeriveSample::draw(QPainter* p, QRect r, QColor c)
{
    DrawPoly::draw(p,r,c);
    qreal cw = 0.5*r.width();
    qreal ch = 0.4*r.height();
    qreal cr = 0.9*(cw>ch?ch:cw);
    qreal a = 2.0*acos(-1.0)/count;
    QPointF t(cw+cr*sin(active*a),ch-cr*cos(active*a));
    p->setPen(QPen(Qt::black));
    p->setBrush(QBrush(Qt::yellow));
    p->drawEllipse(t,0.08*cr,0.08*cr);
}

void DeriveSample::newEvent(bool direction)
{
    if (direction) active++;
    else active = --active + count;
    active = active % count;
}
