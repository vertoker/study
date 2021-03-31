#include <iostream>
#include <iomanip>
#include <cmath>
#include <cstdlib>
#include <ctime>
using namespace std;

//Вариант №22
int main() {
	const int N = 20;
	int maxAverage = 0;
	int minCount = 0;
	int array[N];
	srand(time(NULL));
	
	//Формирование данных
	cout << "Unsorted array elements: " << endl;
	for(int i = 0; i < N; i++){
		array[i] = rand() % 200 - 100;
		cout << setw(5) << array[i];
	}
	cout << endl;
	
	//Сортировка по методу выбора
	for(int x = 0; x < N; x++){
		int id = x;
		for(int y = x + 1; y < N; y++){
			if(array[y] < array[id]){
				id = y;
			}
		}
		int temp = array[id];
		array[id] = array[x];
		array[x] = temp;
	}
	
	//Нахождение доп значений и вывод сортированного массива
	cout << "Sorted array elements: " << endl;
	for(int i = 0; i < N; i++){
		cout << setw(5) << array[i];
		if(array[i] < 0){
			minCount++;
		}
		else {
			maxAverage += array[i];
		}
	}
	cout << endl;
	
	//Вывод
	if(maxAverage == 0){
		cout << "Negative nums count equals " << minCount << endl;
		cout << "Positive nums is not exist" << endl;
	}
	else if(minCount == 0){
		cout << "Negative nums is not exist" << endl;
		cout << "Average of positive nums equals " << maxAverage / (N - minCount) << endl;
	}
	else{
		cout << "Negative nums count equals " << minCount << endl;
		cout << "Average of positive nums equals " << maxAverage / (N - minCount) << endl;
	}
	return 0;
}
