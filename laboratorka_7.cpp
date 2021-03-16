#include <iostream>
#include <cmath>
using namespace std;

bool prime(int n){ 
	for(int i = 2; i <= sqrt(n); i++){
		if(n % i == 0){
			return false;
		}
	}
	return true;
}

//Вариант №22
int main() {
	int num, result = 1;
	
	do{
	   cout << "input num: ";
	   cin >> num;
	   if (prime(num) && num > result){
	   		result = num;
	   }
	}
	while(num != 0);
	
	if (result == 1){
 	   cout << "all input nums wasn't prime numbers";
	}
	else{
 		 cout << "result is: " << result;
	}
	return 0;
}
