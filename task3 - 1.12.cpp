#include <iostream>
using namespace std;

int main() {
    int n, max;
    cin >> n;
    int **a = new int*[n];

    for (int b = 0; b < n; b++){
        a[b] = new int [n];
    }

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            cin >> a[i][j];
        }
    }
    
    max = a[0][0];
    for (int i = 0; i < n; i++) {
        for (int j = i; j < n; j++) {
            if ( (max < a[i][j] && j >= i && j >= n - i - 1) || (j <= i && j <= n - i - 1 && max < a[i][j]))
                max = a[i][j];
        }
    }

    for (int i = 1; i < n; i++) {
        for (int j = 1; j < n; j++) {
            if (i == j) {
                if (a[i][j] > max) {
                    max = a[i][j];
                }
            }
            if ((i + j) == (n - 1)) {
                if (a[i][j] > max) {
                    max = a[i][j];
                }
            }
        }
    }

    cout << max << endl;
    for (int b = 0; b < n; b++){
        delete [] a[b];
    }
    delete []a;
    return 0;
}