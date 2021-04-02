#include <iostream>

using namespace std;

int main(){
	int h;
	cin >> h;
	if(h>2 && h<9){
		for(int i=1; i<=h; i++){
			for(int c=0; c<(h-i); ++c){
				cout << " ";
			}
			for(int c=0; c<=i*2; ++c){
				cout << "*";
			}
			for(int c=0; c<=(h-i); ++c){
				cout << " ";
			}
			for(int c=0; c<=i*2; ++c){
				cout << "*";
			}
			for(int c=0; c<=(h-i); ++c){
				cout << " ";
			}
			for(int c=0; c<=i*2; ++c){
				cout << "*";
			}
		}
	}
}
