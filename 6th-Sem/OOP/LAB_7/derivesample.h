#ifndef DERIVESAMPLE_H
#define DERIVESAMPLE_H

#include "drawpoly.h"

class DeriveSample : public DrawPoly
{
    int active;
public:
    DeriveSample(int);
    void draw(QPainter*,QRect,QColor);
    void newEvent(bool);
};

#endif // DERIVESAMPLE_H
