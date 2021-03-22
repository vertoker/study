#include <iostream>
#include <cmath>
#include <cstdlib>
#include <ctime>
using namespace std;

//Вариант №22
int main() {
	const int N = 10;
	int max = INT_MIN;
	int min = INT_MAX;
	int array[N];
	
	srand(time(NULL));
	cout << "Massive: ";
	for(int i = 0; i < N; i++){
		array[i] = rand() % 100;
		cout << array[i] << " ";
	}
	
	for(int i = 0; i < N; i++){
		if(array[i] % 2 == 0 && array[i] > max){
			max = array[i];
		}
		if(array[i] < min){
			min = array[i];
		}
	}
	cout << endl << "Min: " << min << endl;
	cout << "Max: " << max << endl;
	
	return 0;
}
