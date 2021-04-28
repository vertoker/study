#include <iostream>
#include <string>
#include <locale>
using namespace std;

int main() {
	const int ALPHABET_COUNT = 26;
	const string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	int letters[ALPHABET_COUNT] = {0};
	int letters_counter = 0;
	string s;
	getline(cin, s);
	
	for (int i = 0; i < s.length(); i++){
		int pos = ALPHABET.find(s.substr(i, 1));
		if (pos != string::npos){
			if (pos >= ALPHABET_COUNT){
				pos -= ALPHABET_COUNT;
			}
			if (letters[pos] == 0){
				letters_counter += 1;
			}
			letters[pos] += 1;
		}
	}
	
	cout << (letters_counter == ALPHABET_COUNT ? "Pangram" : "Not pangram") << endl;
	for (int i = 0; i < ALPHABET_COUNT; i++){
		cout << ALPHABET.substr(i, 1) << " = " << letters[i] << endl;
	}
	return 0;
}
