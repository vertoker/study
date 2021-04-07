#include <iostream>
#include <iomanip>
#include <math.h>
#include <cstdlib>
#include <ctime>
using namespace std;

int main() {
	const int X = 10, Y = 15;
	int matrix[X][Y];
	srand(time(NULL));
	
	cout << "Matrix" << endl;
	for(int i = 0; i < X; i++){
		for(int j = 0; j < Y; j++){
			matrix[i][j] = rand() % 10;
			cout.width(5);
			cout << matrix[i][j];
		}
		cout << endl;
	}
	
	for(int i = 0; i < X; i++){
		int min = INT_MAX, minIndex;
		int max = INT_MIN, maxIndex;
		cout << endl << "Line " << (i + 1) << endl;
		
		for(int j = 0; j < Y; j++){
			if (matrix[i][j] < min){
				min = matrix[i][j];
				minIndex = j;
			}
			if (matrix[i][j] > max){
				max = matrix[i][j];
				maxIndex = j;
			}
		}
		
		cout << "    min = " << matrix[i][minIndex] << " -> [" << i << "][" << minIndex << "]";
		for(int j = 0; j < Y; j++){
			if (matrix[i][j] == min && minIndex != j){
				cout << ", [" << i << "][" << j << "]";
			}
		}
		
		cout << endl << "    max = " << matrix[i][maxIndex] << " -> [" << i << "][" << maxIndex << "]";
		for(int j = 0; j < Y; j++){
			if (matrix[i][j] == max && maxIndex != j){
				cout << ", [" << i << "][" << j << "]";
			}
		}
		
		cout << endl;
	}
	return 0;
}
