#include <iostream>
#include <string>
using namespace std;

int main() {
	string sentence;
	getline(cin, sentence);
	while (true){
		int pos = sentence.find("  ");
		if (pos == string::npos) break;
		sentence.erase(pos, 1);
	}
	cout << sentence;
	return 0;
}
