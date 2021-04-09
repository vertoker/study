#include <iostream>
#include <cmath>

using namespace std;

int main(){
	int N, result = INT_MAX;
	int A[100], B[100];
	cin >> N;
	
	for(int i = 0; i < N; i++){
		cin >> A[i];
	}
	for(int i = 0; i < N; i++){
		cin >> B[i];
	}
	
	for (int C = -1000; C <= 1000; C++){
		int sum = 0;
		for (int i = 0; i < N; i++){
			sum = abs(A[i] + C - B[i]);
		}
		if(result > sum){
			result = sum;
		}
	}
	cout << result << endl;
}
