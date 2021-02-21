#include <iostream>
#include <math.h>


double force(double* mass) {
    double ans = 1;
    for (size_t i = 0; i < 5; i++) {
        i == 3 ? ans*= pow(mass[i],2) : ans *= mass[i];
    }
    return ans;
}

// функция для получения целой части и степени десятки
//передаем число и требуемый степень десятки, т.е. пов = 1 - значит будет 0,1-0,9 *10 в какой то степени
//будет pow = 10 -- значит будет 1-9 *10 в какой то степени
//будет pow = 100 -- значит будет 10-99 *10 в какой то степени
//будет pow = 1000 -- значит будет 100-999 *10 в какой то степени и.т.д

int GetPow(double y, int pow)
{
    double x = fabs(y);
    int n = 0;
    if (x >= pow)
        while (x >= pow)
        {
            n++;
            x /= 10;
        }
    else if (x < 1)
        while (x < 1)
        {
            n--;
            x *= 10;
        }
    return n;
}

int main() {
    setlocale(LC_ALL, "RU");
    std::cout << "Программа подчета величины подъемной силы крыла самолета." << std::endl;
    double TableDataForce[] = { 0.005, 15, 0.95, 200, 20 }; // coeff; alpha; ro; v; S; 
    double relativeErrTable[] = { 0.001, 0.01, 0.01, 3, 0.001 }; // from table
    //рассчитаем относительную погрешность.
    double relativeErrors = 0;
    for (size_t i = 0; i < 5; i++) {
        i == 3 ? relativeErrors += 2 * relativeErrTable[i]/TableDataForce[i] : relativeErrors += relativeErrTable[i];
    }
  
    double Force = force(TableDataForce);
    int degree = GetPow(Force, 1000);
    Force = Force / pow(10, degree);
    std::cout << "Величина подъемной силы = " << Force << " * 10^" << degree << std::endl;
   
    double absoluteErrors = fabs(Force*pow(10, degree)) * relativeErrors;
    int absoluteErrDeg = GetPow(absoluteErrors, 100);
    // info from math.h libriary :)
    // round() -- математически правильное округление
    // ceil()  -- округляет в сторону большего
    // floor() -- в сторону меньшего
    // trunc() -- простое отбрасывание дробной части
    absoluteErrors = round(absoluteErrors / (pow(10, absoluteErrDeg)));
    std::cout << "Абсолютная погрешность  =  " << absoluteErrors << " * 10^" << absoluteErrDeg << std::endl;

    double relativeErrPercent = relativeErrors * 100;
    std::cout << "Относительная погрешность = " << relativeErrPercent << "%" << std::endl; 

    std::cout << std::endl << "Оканчательный результат:" << std::endl;

    int degree2 = GetPow(Force * (pow(10, degree)), 10);
    Force = Force * pow(10, degree) / pow(10, degree2);
    std::cout << "Величина подъемной силы = " << Force << " * 10^" << degree2 << std::endl;

    int absoluteErrDeg2 = GetPow(absoluteErrors*(pow(10, absoluteErrDeg)), 1);
    absoluteErrors = absoluteErrors * pow(10, absoluteErrDeg) / (pow(10, absoluteErrDeg2));
    std::cout << "Абсолютная погрешность  = " << absoluteErrors << " * 10^" << absoluteErrDeg2 << std::endl;
    
    std::cout << "Относительная погрешность = " << relativeErrPercent << "%" << std::endl;

    std::cin.get();
    return 0;
}