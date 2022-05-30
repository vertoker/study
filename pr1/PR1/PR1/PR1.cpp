#include <iostream>
#include <ctime>
using namespace std;

bool CheckPrime(int n) {
    if (n < 2) {
        return false;
    }

    for (int i = 2; i < sqrt(n); i++) {
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
    char str[32], * p = str;
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