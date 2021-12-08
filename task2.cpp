#include <iostream>
#include <cmath>
using namespace std;

int main() {
    int arraySize;
    cin >> arraySize;
    int array[arraySize];
    for (int n = 0; n < arraySize; n++) {
        array[n] = 1;
        if (n > 1) {
            for (int m = n - 1; m > 0; m--) {
                array[m] = array[m - 1] + array[m];
            }
        }
        for (int m = 0; m <= n; m++) {
            cout << array[m];
            if (m < arraySize) {
                cout << " ";
            }
        }
        if (n < arraySize) {
            cout << endl;
        }
    }
    return 0;
}