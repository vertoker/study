#include <iostream>
#include <string>
using namespace std;

int STRP(string main, string ward){
	int wardLen = ward.length();
	int mainLen = main.length();
	
	for (int i = 0; i < mainLen; i++){
		for (int j = 0; j < wardLen; j++){
			if(main[i] == ward[j]){
				return i;
			}
		}
	}
	return -1;
}

int Find(string main, string ward){
	int wardLen = ward.length();
	int mainLen = main.length();
	for (int i = 0; i < mainLen; i++){
		if(wardLen <= mainLen - i){
			for (int j = 0; j < wardLen; j++){
				if(main[i + j] != ward[j]){
					break;
				}
				return i;
			}
		}
		else{
			return -1;
		}
	}
	return -1;
}

int main() {
	string s1, s2;
	getline(cin, s1);
	getline(cin, s2);
	cout << STRP(s1, s2);
	return 0;
}
