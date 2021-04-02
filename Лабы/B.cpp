#include <iostream>
#include <string>

using namespace std;

int main(){
	int a, i;
	unsigned char d;
	cout << "input four numbers from 1 to 255: ";
	for (i=1; i<5; i++){
		cin >> a;
		if (a<1 || a>255){
			switch (i){
				case 1:
					d="First";
					break;
				case 2:
					d="Second";
					break;
				case 3:
					d="Third"; 
					break;
				case 4:
					d="Fourth";
					break;
			}
		}	cout << d << " in not  valid" << endl;
	}
	
	return 0;
}
