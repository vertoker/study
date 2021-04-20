#include <iostream>
#include <iomanip>
#include <math.h>
#include <cstdlib>
#include <ctime>
using namespace std;

int main() {
	int cources;
	cin >> cources;
	
	int **grades = new int *[cources];
	double *averages = (double *) new double[cources];
	int *subjects = (int *) new int[cources];
	
	double fullSum = 0;
	for (int x = 0; x < cources; x++){
		double sum = 0;
		int subject;
		cin >> subject;
		
		if (subject == 0){
			averages[x] = 0;
			subjects[x] = 0;
			continue;
		}
		
		grades[x] = new int [subject];
		for (int y = 0; y < subject; y++){
			cin >> grades[x][y];
			sum += grades[x][y];
		}
		
		averages[x] = sum / subject;
		fullSum += averages[x];
		subjects[x] = subject;
	}
	
	for (int x = 0; x < cources; x++){
		cout << "Course " << x + 1;
		cout.setf(ios::fixed);
		cout.setf(ios::showpoint);
		cout.precision(2);
		
		cout << ": final " << averages[x] << ", grades: ";
		for (int y = 0; y < subjects[x]; y++){
			cout << grades[x][y] << " ";
		}
		cout << endl;
	}
	cout << "Overall final " << fullSum / cources;
	
	delete[] grades;
	delete[] averages;
	delete[] subjects;
	
	return 0;
}
