#include "widget.h"
#include "ui_widget.h"

Widget::Widget(QWidget *parent)
    : QWidget(parent)
    , ui(new Ui::Widget)
{
    ui->setupUi(this);
    s = new DrawPoly(ui->AngleCountCB->currentText().toInt());

    setWindowTitle("LAB_6");
}

Widget::~Widget()
{
    delete ui;
}

void Widget::paintEvent(QPaintEvent *event)
{
    Q_UNUSED(event);
    QPainter p;
    p.begin(this);
    s->draw(&p,rect(),ui->ColorCB->currentText());
    p.end();

    /*
    QPainter painter(this); // Создаём объект отрисовщика
    // Устанавливаем кисть абриса
    painter.setPen(QPen(Qt::black, 1, Qt::SolidLine, Qt::FlatCap));
    painter.setBrush(QBrush(ui->ColorCB->currentText(), Qt::SolidPattern));
    painter.drawEllipse(100, 50, 150, 150);*/
}

void Widget::on_DrawButton_clicked()
{
    s = new DrawPoly(ui->AngleCountCB->currentText().toInt());
    repaint();
}
