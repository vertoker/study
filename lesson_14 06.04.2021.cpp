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
	
	for(int i = 0; i < X; i++){
		for(int j = 0; j < Y; j++){
			matrix[i][j] = rand() % 10;
			cout.width(5);
			cout << matrix[i][j];
		}
		cout << endl;
	}
	
	for(int i = 0; i < X; i++){
		int min = INT_MIN, minY;
		int max = INT_MAX, maxY;
		cout << "Line ¹" << (i + 1) << endl;
		
		for(int j = 0; j < Y; j++){
			if (matrix[i][j] < min){
				min = matrix[i][j];
				minY = j;
			}
			if (matrix[i][j] > max){
				max = matrix[i][j];
				maxY = j;
			}
		}
		
		cout << "max = " << matrix[i][maxY] << ;
		for(int j = 0; j < Y; j++){
			if (matrix[i][j] == min && minY != j){
				cout << " " << 
			}
		}
		
		cout << endl;
	}
	return 0;
}
