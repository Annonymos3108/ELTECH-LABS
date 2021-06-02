#ifndef PARAMWINDOW_H
#define PARAMWINDOW_H

#include <QWidget>
#include <QCloseEvent>
#include <QLabel>
#include <QSpinBox>
#include <QPushButton>

#include "eventtypes.h"

class ParamWindow : public QWidget
{
private:
    Q_OBJECT

    QLabel *l1;
    QLabel *l2;
    QLabel *l3;
    QLabel *l4;
    QDoubleSpinBox  *crashProbability;
    QSpinBox        *checkPeriod;
    QSpinBox        *diagnosticsTime;
    QSpinBox        *repairTime;
    QPushButton     *apply_btn;
    QPushButton     *cancel_btn;

public:
    ParamWindow(QWidget *parent = 0);
    ~ParamWindow();

    void setCurrentParams(const ParamData&);

protected:
    void closeEvent(QCloseEvent*);

protected slots:
    void setModelParam();
    void restoryModelParam();

signals:
    void closing();
    void sendParamMessage(Events);
};

#endif // PARAMWINDOW_H
