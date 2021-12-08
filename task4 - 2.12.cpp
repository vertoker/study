#include <iostream>
using namespace std;

int main() {
    int n, top = 0, right = 0, down = 0, left = 0;
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
    
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (i != j && ((i + j) != (n - 1))) {
                if (j > i && (j < (n - 1 - i)))
                    top = top + a[i][j];
                if (j > i && (j > (n - 1 - i)))
                    right = right + a[i][j];
                if (j < i && (j > (n - 1 - i)))
                    down = down + a[i][j];
                if (j < i && (j < (n - 1 - i)))
                    left = left + a[i][j];
            }
        }
    }
    
    cout << "top: " << top << endl;
    cout << "right: " << right << endl;
    cout << "down: " << down << endl;
    cout << "left: " << left << endl;
    
    for (int b = 0; b < n; b++){
        delete [] a[b];
    }
    delete []a;
    return 0;
}