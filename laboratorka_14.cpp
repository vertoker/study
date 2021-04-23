#include <iostream>
#include <iomanip>
#include <math.h>
#include <cstdlib>
#include <ctime>
using namespace std;

void calculateAverage(double *averages, int **array, int row, int column){
	for (int x = 0; x < row; x++){
		double sum = 0;
		for (int y = 0; y < column; y++){
			sum += array[x][y];
		}
		averages[x] = sum / column;
	}
}

int calculateCounter(int *numbers, double *averages, double num, int row){
	int counter = 0;
	for (int x = 0; x < row; x++){
		if (averages[x] < num){
			numbers[counter] = x;
			counter += 1;
		}
	}
	return counter;
}

int main() {
	//Инициация и ввод
	setlocale(LC_ALL, "Russian");
	int row, column, **array;
	double num;
	cout << "Введите определённое значение: ";
	cin >> num;
	cout << "Введите количество строк: ";
	cin >> row;
	cout << "Введите количество столбцов: ";
	cin >> column;
	
	array = new int *[row];
	double *averages = (double *) new double[row];
	int *numbers = (int *) new int[row];
	
	for (int x = 0; x < row; x++){
		array[x] = new int[column];
		cout << "Введите значения для " << x + 1 << "-й строки (" << column << " значения): ";
		for (int y = 0; y < column; y++){
			cin >> array[x][y];
		}
	}
	//Вывод массива
	cout << endl << "Введёная матрица" << endl;
	for (int x = 0; x < row; x++){
		for (int y = 0; y < column; y++){
			cout << array[x][y] << " ";
		}
		cout << endl;
	}
	cout << endl;
	
	//Высчитывание
	calculateAverage(averages, array, row, column);
	int counter = calculateCounter(numbers, averages, num, row);
	
	//Вывод
	if (counter == 0){
		cout << "В массиве нету строк, среднее ариметических которых меньше " << num;
	}
	else{
		cout << "Количество строк, среднее ариметических которых меньше " << num << " равно " << counter << endl;
		cout << "Строки под номером: ";
		for (int x = 0; x < row; x++){
			if (averages[x] < num){
				cout << x << " ";
			}
		}
	}
	
	//Очистка
	for (int x = 0; x < row; x++){
		delete[] array[x];
	}
	delete[] array;
	delete[] numbers;
	delete[] averages;
	
	return 0;
}
