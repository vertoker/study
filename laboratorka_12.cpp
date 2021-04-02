#include <iostream>
#include <iomanip>
#include <cmath>
#include <cstdlib>
#include <ctime>
using namespace std;

//Вариант №22
int main() {
	const int N = 20;
	double array[N];
	srand(time(NULL));
	
	//Формирование данных
	cout << "Unsorted array elements: " << endl;
	for(int i = 0; i < N; i++){
		array[i] = (rand() % 240 - 120) / (10);
		cout << setw(6) << array[i];
	}
	
	/*//Сортировка по методу выбора
	for(int x = 0; x < N; x++){
		if(abs(array[x]) <= 2){
			for(int y = x + 1; y < N; y++){
				array[y - 1] = array[y];
			}
			array[N - 1] = 22;
		}
	}*/
	
	//Сортировка #21
	/*int countInRange = 0;
	for(int x = 0; x < N; x++){
		if(abs(array[x]) <= 7){
			double temp = array[x];
			for(int y = x; y > countInRange; y--){
				array[y] = array[y - 1];
			}
			array[countInRange] = temp;
			countInRange++;
		}
	}*/
	
	//Сортировка #15
	int counterZero = 0, counterPositive = 0;
	for(int x = 0; x < N; x++){
		if(array[x] == 0){
			int temp = array[x];
			for(int y = x; y > counterZero; y--){
				array[y] = array[y - 1];
			}
			array[counterZero] = temp;
			counterZero++;
		}
		else if(array[x] > 0){
			int temp = array[x];
			for(int y = x; y > counterZero + counterPositive; y--){
				array[y] = array[y - 1];
			}
			array[counterZero + counterPositive] = temp;
			counterPositive++;
		}
	}
	
	//Нахождение доп значений и вывод сортированного массива
	cout << endl << "Sorted array elements: " << endl;
	for(int i = 0; i < N; i++){
		cout << setw(6) << array[i];
	}
	return 0;
}
