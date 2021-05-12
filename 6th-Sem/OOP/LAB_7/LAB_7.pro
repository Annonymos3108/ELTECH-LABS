QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = painter
TEMPLATE = app

CONFIG += c++11

SOURCES += \
    derivesample.cpp \
    drawpoly.cpp \
    main.cpp \
    widget.cpp

HEADERS += \
    derivesample.h \
    drawpoly.h \
    widget.h

FORMS += \
    widget.ui
