#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include <QPainter>
#include <QMouseEvent>
#include <drawpoly.h>
#include "derivesample.h"

QT_BEGIN_NAMESPACE
namespace Ui { class Widget; }
QT_END_NAMESPACE

class Widget : public QWidget
{
    Q_OBJECT

    DeriveSample* s;

public:
    explicit Widget(QWidget *parent = nullptr);
    ~Widget();

protected:
    void paintEvent(QPaintEvent *event);
    void mousePressEvent(QMouseEvent*);

private slots:
    void on_DrawButton_clicked();

private:
    Ui::Widget *ui;
};
#endif // WIDGET_H
