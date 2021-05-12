#include "widget.h"
#include "ui_widget.h"

Widget::Widget(QWidget *parent)
    : QWidget(parent)
    , ui(new Ui::Widget)
{
    ui->setupUi(this);
    s = new DeriveSample(ui->AngleCountCB->currentText().toInt());

    setWindowTitle("LAB_7");
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
}

void Widget::mousePressEvent(QMouseEvent *event)
{
    if (event->button() == Qt::LeftButton)  s->newEvent(false);
    if (event->button() == Qt::RightButton) s->newEvent(true);
    update();
}

void Widget::on_DrawButton_clicked()
{
    s = new DeriveSample(ui->AngleCountCB->currentText().toInt());
    repaint();
}
