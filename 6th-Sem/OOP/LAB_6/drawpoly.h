#ifndef DRAWPOLY_H
#define DRAWPOLY_H

#include <QPainter>

class DrawPoly
{
    int count;
public:
    DrawPoly(int);
    ~DrawPoly() = default;
    void draw(QPainter*,QRect,QColor);
};


#endif // DRAWPOLY_H
