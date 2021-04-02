#include <iostream>
#include <iomanip>
#include <cmath>
#include <cstdlib>
#include <ctime>
using namespace std;

int main() {
	const int N = 10;
	int max = INT_MIN;
	int min = INT_MAX;
	int array[N];
	
	srand(time(NULL));
	cout << "Array elements: " << endl;
	for(int i = 0; i < N; i++){
		array[i] = rand() % 100;
		cout << setw(3) << array[i];
		
		if(array[i] % 2 == 0 && array[i] > max){
			max = array[i];
		}
		if(array[i] < min){
			min = array[i];
		}
	}
	
	cout << endl << "Min: " << min << endl;
	if(max != INT_MIN){
		cout << "Max: " << max << endl;
	}
	else{
		cout << "Max: is not exist" << endl;
	}
	
	return 0;
}
