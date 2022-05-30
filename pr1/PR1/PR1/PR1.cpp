#include <iostream>
#include <ctime>
using namespace std;

bool CheckPrime(int n) {
    if (n < 2) {
        return false;
    }

    for (int i = 2; i <= n / 2; ++i) {
        if (n % i == 0) {
            return false;
        }
    }

    return true;
}

bool WantContinue() {
    string condition;
    cout << "Want to continue? (y, n) - ";
    cin >> condition;
    if (condition == "y") {
        return true;
    }
    if (condition == "n") {
        return false;
    }
    cout << "Incorrect answer" << endl;
    return WantContinue();
}

int EnterNumber(string comment) {
    cout << comment;
    char str[32], *p = str;
    cin >> str;

    while (*p) {
        if (!isdigit(*p++)) {
            return EnterNumber(comment);
        }
    }
    return atoi(str);
}

int main()
{
    bool inActive = true;
    while (inActive) {
        int a = EnterNumber("Enter start number: ");
        int b = EnterNumber("Enter end number: ");
        cout << endl;

        if (a > b) {
            cout << "Wrong interval numbers" << endl;
            continue;
        }

        int internalCounter = 0;
        int internalLimit = 10;

        int startClock = clock();
        cout << "Prime numbers";
        cout << endl;
        for (int c = a; c <= b; c++) {
            if (CheckPrime(c)) {
                cout << c << ' ';
                /*internalCounter++;

                if (internalCounter == internalLimit) {
                    cout << endl;
                    internalCounter = 0;
                }*/
            }
        }

        cout << endl;
        if (internalCounter != 0) {
            cout << endl;
        }

        int endClock = clock();

        float intervalTime = (endClock - startClock) / (float)1000;
        cout << "Interval time (in seconds): " << intervalTime;
        cout << endl;

        if (WantContinue()) {
            cout << endl;
        }
        else {
            inActive = false;
        }
    }
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
