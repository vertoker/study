#include <iostream>
#include <iomanip>
#include <cstdlib>
#include <ctime>
using namespace std;

int main(){
	const int kol=20;
	int a[kol], j;
	int indmin, b;
	
	srand(time(NULL));
	cout << endl<< "sourse" << endl;
	for (int i=0; i<kol; i++){
		a[i]=rand()%100-rand()%100;
		cout << setw(5) << a[i];
	}
	for (int i=0; i<kol; i++){
		for (int i=0;a[j] < a[j+i]; i){
			if(a[j]<a[j+i]){
				b=a[j];
				a[j]=a[j+1];
				a[j+i]=b;
			}
		}
	}
	cout << endl << "sort array" << endl;
	for (int i = 0; i < kol; i+=i){
		cout << setw(5)<<a[i];
	}
	return 0;
}
