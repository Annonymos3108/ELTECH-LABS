#include <iostream>
#define _USE_MATH_DEFINES // for C++
#include <math.h>
#include <cmath>


int main()
{
    setlocale(LC_ALL, "RU");
    std::cout << "Программа подчета значения функции." << std::endl;
    double data[3][2][2] = {
        { {52.34, 2.0435},
          {0.01,  0.0001} },
        { {0.0545, 0.82},
          {0.00005, 0.01} },
        { {0.65, 6.3},
          {0.02,  0.02} },
    };

    std::cout << "Абсолютные погрешности аргументов:" << std::endl;
    for (size_t i = 0; i < 3; i++) {
        for (size_t j = 0; j < 2; j++) {
            std::cout << data[i][1][j] << "\t";
        }
        std::cout << std::endl;
    };
 
    std::cout << std::endl << "Относительные погрешности равны:" << std::endl;
    double relative[6];
    for (size_t i = 0, k = 0; i < 3; i++) {
        for (size_t j = 0; j < 2; j++) {
            relative[k] = data[i][1][j] / data[i][0][j];
            k++;
        }
    }

    double relativePercent[6];
    for (size_t i = 0; i < 6; i++) {
       //relativePercent[i] = relative[i]* 100;
       relativePercent[i] = round(relative[i] *100*1000)/1000;
    }

    for (size_t i = 0; i < 6; i++) {
        std::cout << relativePercent[i] << "%" << (i % 2 == 1 ? "\n" : "\t");
    }

    std::cout << std::endl << "Значение функции:" << std::endl;
    double SFuncResult[3];
    for (size_t i = 0; i < 3; i++) {
        SFuncResult[i] = (M_PI*pow(data[i][0][0], 2))/2+ (M_PI * pow(data[i][0][1], 2));
    }
    
    for (size_t i = 0; i < 3; i++) {
        std::cout << SFuncResult[i] << std::endl;
    }

    std::cout << std::endl << "Коеффиценты:" << std::endl;
    double diff[2][3];
    for (size_t i = 0; i < 3; i++) {
        diff[0][i] = fabs(data[i][0][0]) / fabs(SFuncResult[i]) * M_PI * data[i][0][0];
    }
    for (size_t i = 0; i < 3; i++) {
        diff[1][i] = fabs(data[i][0][1]) / fabs(SFuncResult[i]) * 2 * M_PI * data[i][0][1];
    }

    for (size_t i = 0; i < 2; i++) {
        for (size_t j = 0; j < 3; j++) {
            std::cout << diff[i][j] << "\t\t\t";
        }
        std::cout << std::endl;
    };

    //std::cout << std::endl << "delta(S):" << std::endl;
    double deltaS[3], deltaSPercent[3];
    for (size_t i = 0, k = 0; i < 3; i++) {
        deltaS[i] = diff[0][i] * relative[k] + diff[1][i] * relative[k + 1];
    }
    for (size_t i = 0; i < 3; i++) {
        deltaSPercent[i]= round(deltaS[i] * 100 * 1000) / 1000;
    }
    

    std::cout << std::endl << "DELTA S:" << std::endl;
    double DELTA_S[3];
    for (size_t i = 0; i < 3; i++) {
        DELTA_S[i] = fabs(SFuncResult[i]) * deltaS[i];
    }
    for (size_t i = 0; i < 3; i++) {
        std::cout << DELTA_S[i] << "\t";
    }

    std::cout << std::endl << std::endl << "Значение функции округленное до трех значащих цифр:" << std::endl;
    for (size_t i = 0; i < 3; i++) {
        SFuncResult[i] = round(SFuncResult[i] * 1000) / 1000;
    }
    for (size_t i = 0; i < 3; i++) {
        std::cout << SFuncResult[i] << std::endl;
    }

    std::cout << std::endl << "DELTA S округленное до трех значащих цифр::" << std::endl;
    for (size_t i = 0; i < 3; i++) {
        DELTA_S[i] = round(DELTA_S[i] * 10000) / 10000;
    }
    for (size_t i = 0; i < 3; i++) {
        std::cout << DELTA_S[i] << "\t";
    }

    std::cout << std::endl << std::endl << "delta(S):" << std::endl;
    for (size_t i = 0; i < 3; i++) {
        std::cout << deltaSPercent[i] << "%" << "\t";
    }

    std::cin.get();
    //std::cout << "" << std::endl;
    return 0;
};