#include <iostream>

using namespace std;

void space(int length){
	for(int c = 0; c < length; c++){
		cout << " ";
	}
}

void triangle(int length){
	for(int c = 0; c < length; c++){
		cout << "*";
	}
}

int main(){
	int h;
	cin >> h;
	if(h > 2 && h < 9){
		for(int i = 1; i <= h; i++){
			space(h - i);
			
			if (i == 1){
				cout << "*";
			}
			else if (i < h){
				cout << "*";
				space(i * 2 - 3);
				cout << "*";
			}
			else{
				triangle(i * 2 - 1);
			}
			
			space(2 * (h - i) + (21 - h * 2));// 2 * (h - i) + 19
			
			if (i == 1){
				cout << "*";
			}
			else if (i < h){
				cout << "*";
				space(i * 2 - 3);
				cout << "*";
			}
			else{
				triangle(i * 2 - 1);
			}
			
			space(2 * (h - i) + (21 - h * 2));
			
			if (i == 1){
				cout << "*";
			}
			else if (i < h){
				cout << "*";
				space(i * 2 - 3);
				cout << "*";
			}
			else{
				triangle(i * 2 - 1);
			}
			
			cout << endl;
		}
	}
	else{
		cout << "Wrong number" << endl;
	}
}
