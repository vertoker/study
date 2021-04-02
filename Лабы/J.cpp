#include <iostream>

#include <cmath>

using namespace std;

int main() {

double pi4 = 0.;
long n, k = 1;
int znak = 1;
cin >> n;
if(n > 0){
for(int i = 1; i <= n; i++){
pi4 += 1. / k * znak;
k += 2;
znak = -znak;
}
cout.precision(15);
cout << "Pi = " << (pi4 * 4.) << endl;
}else{
cout << "Wrong number";
}
return 0;
}
