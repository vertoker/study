#include <iostream>
#include <string>
using namespace std;

bool isPalindrome(int num){
	string temp = to_string(num);
	int length = temp.length();
	for (int i = 0; i < length / 2; i++){
		if (temp[i] != temp[length - i - 1]){
			return false;
		}
	}
	return true;
}

int main(){
	int num;
	cin >> num;
	do {
		num += 1;
	}
	while(!isPalindrome(num));
	cout << "Palindrome: " << num;
	return 0;
}
