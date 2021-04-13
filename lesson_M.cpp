#include <iostream>

using namespace std;

int main(){
	int n, m;
	cin >> n >> m;
	int *humans = new int[n];
	
	for (int i = 0; i < n; i++){
		humans[i] = i + 1;
	}
	
	for (int i = n; i > 1; i--){
		int counter = 0, loop = m / i;
		int answer = m - loop * i - 1;
		int *temp = new int[i - 1];
		
		for (int j = 0; j < i; j++){
			cout << humans[j] << " ";
		}
		cout << endl;
		
		for (int j = 0; j < i; j++){
			if (j != answer){
				temp[counter] = humans[j];
				counter += 1;
			}
		}
		
		humans = temp;
		delete temp;
	}
	
	cout << humans[0];
	delete[] humans;
	return 0;
}
