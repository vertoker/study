#include <iostream>
#include <string>
using namespace std;

bool isPalindrome(string num){
	int length = num.length();
	for (int i = 0; i < length / 2; i++){
		if (num[i] != num[length - i - 1]){
			return false;
		}
	}
	return true;
}

string PlusOne(string num){
	const string NUMS = "0123456789";
	int counter = num.size() - 1;
	bool isNext = true;
	while (isNext && counter >= 0){
		int lastNum = NUMS.find(num[counter]) + 1;
		isNext = lastNum == 10;
		if (isNext){
			num[counter] = '0';
		}
		else{
			num[counter] = NUMS[lastNum];
		}
		counter -= 1;
	}
	if (isNext){
		return "1" + num;
	}
	return num;
}

string reverse(string num){
	int length = num.length();
	for (int i = 0; i < length; i++){
		char temp = 
	}
}

int main(){
	string num;
	cin >> num;
	
	int point = num.length() / 2;
	int middle = num.length() % 2;
	string firstHalf = num.substr(0, point + middle);
	string secondHalf = num.substr(point + middle, point);
	
	
	
	/*do {
		num = PlusOne(num);
		cout << num << endl;
	}
	while(!isPalindrome(num));*/
	cout << num;
	return 0;
}
