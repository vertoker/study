#include <iostream>
#include <iomanip>
#include <math.h>
#include <cstdlib>
#include <ctime>
using namespace std;

int main() {
	double fullSum = 0;
	int row;
	cin >> row;
	
	int **pupils = (int **) new int [row][0];
	double *average = (double *) new double[row];
	int *columns = (int *) new int[row];
	
	for (int x = 0; x < row; x++){
		double sum = 0;
		int column;
		cin >> column;
		
		pupils[x] = new int[column];
		for (int y = 0; y < column; y++){
			cin >> pupils[x][y];
			sum += pupils[x][y];
		}
		
		if (column == 0){
			average[x] = 0;
		}
		else{
			average[x] = sum / column;
		}
		fullSum += average[x];
		columns[x] = column;
	}
	
	for (int x = 0; x < row; x++){
		cout << "Course " << x + 1;
		cout.setf(ios::fixed);
		cout.setf(ios::showpoint);
		cout.precision(2);
		cout << ": final " << average[x];
		cout << ", grades: ";
		
		for (int y = 0; y < columns[x]; y++){
			cout << pupils[x][y] << " ";
		}
		
		cout << endl;
	}
	cout << "Overall final " << fullSum / row;
	
	delete[] pupils;
	delete[] average;
	delete[] columns;
	
	return 0;
}
