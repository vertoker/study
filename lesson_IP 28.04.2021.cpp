#include <iostream>
#include <string>
#include <locale>
using namespace std;

void CheckIP(string s){
	const string NUMSSTR = "0123456789";
	const int NUMS[10] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
	int length = s.length();
	bool isNum = false;
	int lastNum = 0;
	int numsCounter = 0;
	
	for (int i = 0; i < length; i++){
		int pos = NUMSSTR.find(s.substr(i, 1));
		if (s[i] == '.'){
			if (lastNum > 255){
				cout << "Too big a value of a part";
				return;
			}
			if (isNum == false){
				cout << "Incorrect parts count";
				return;
			}
			isNum = false;
			lastNum = 0;
			numsCounter += 1;
		}
		else if(pos != string::npos){
			isNum = true;
			lastNum = lastNum * 10 + NUMS[pos];
			if (lastNum > 999){
				cout << "Too many characters in a part";
				return;
			}
		}
		else{
			cout << "Only digits and dots allowed";
			return;
		}
	}
	
	if (numsCounter > 3){
		cout << "Too many parts";
	}
	else if (numsCounter < 3){
		cout << "Too few parts";
	}
	else if (isNum == false){
		cout << "Incorrect parts count";
	}
	else{
		cout << "Correct IP";
	}
}

int main() {
	string s;
	getline(cin, s);
	CheckIP(s);
	return 0;
}
