#include <iostream>
#include <string>
using namespace std;

bool CheckNum(string num){
	const string NUMS = "0123456789";
	if (num.find_first_not_of(NUMS) == string::npos){
		int number = stoi(num);
		
		if (number > 999){
			cout << "Too many characters in a part";
			return false;
		}
		else if (number > 255){
			cout << "Too big a value of a part";
			return false;
		}
		else if (number < 0){
			cout << "Only digits and dots allowed";
			return false;
		}
	}
	else{
		cout << "Only digits and dots allowed";
		return false;
	}
	return true;
}

void CheckIP(string s){
	const int COUNTOFNUMBERS = 4;
	int counter = 0;
	
	int pos = s.find('.');
	while(pos != string::npos){
		if (CheckNum(s.substr(0, pos))) counter += 1;
		else return;
		s.erase(0, pos + 1);
		pos = s.find('.');
	}
	if (CheckNum(s)) counter += 1;
	else return;
	
	if (counter > COUNTOFNUMBERS){
		cout << "Too many parts";
	}
	else if (counter < COUNTOFNUMBERS){
		cout << "Too few parts";
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
