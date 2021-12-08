#include <iostream>
using namespace std;

int main() {
    int n, q, w;
    cin >> n;
    int **a = new int*[n];
    
    for (int b = 0; b < n; b++) {
        a[b] = new int [n];
    }
    
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            cin >> a[i][j];
        }
    }
    
    w = n - 1;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (i == j) {
                q = a[i + w][j];
                a[i + w][j] = a[i][j];
                a[i][j] = q;
                w = w - 2;
            }
        }
    }
    
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            cout << a[i][j] << " ";
        }
        cout << endl;
    }
    
    for (int b = 0; b < n; b++) {
        delete[] a[b];
    }
    delete []a;
    return 0;
}