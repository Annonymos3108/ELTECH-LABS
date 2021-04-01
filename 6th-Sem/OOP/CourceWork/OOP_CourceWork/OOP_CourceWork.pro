QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = OOP_CourceWork
CONFIG += c++11
TEMPLATE = app

# The following define makes your compiler emit warnings if you use
# any feature of Qt which has been marked as deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can make your code fail to compile if it uses deprecated APIs.
# In order to do so, uncomment the following line.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0

SOURCES += \
    application.cpp \
    controlwindow.cpp \
    main.cpp \
    interface.cpp \
    model.cpp \
    paramwindow.cpp \
    statewindow.cpp

HEADERS += \
    application.h \
    controlwindow.h \
    eventtypes.h \
    interface.h \
    model.h \
    paramdata.h \
    paramwindow.h \
    statedata.h \
    statewindow.h
