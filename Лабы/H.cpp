#include <iostream>

using namespace std;

int main (){

int a, b, c, d, e, year;
cin >> year;
if( year >= 1900 && year <= 2100){
a = year % 19;
b = year % 4;
c = year % 7;
d = (a * 19 + 24) % 30;
e = (2 * b + 4 * c + 6 * d + 5) % 7;
if((d + e) < 10){
cout << "March " << d + e + 22 << endl;
}else{
cout << "April " << d + e - 9 << endl;
}
}else{
cout << "Year must be XX-XXI century";
}
return 0;
}
