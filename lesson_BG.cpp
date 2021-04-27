#include <iostream>
#include <cmath>

using namespace std;

int main(){
	struct Data{
		int number;
		int value;
	};
	
	int N;
	cin >> N;
	Data *workers = new Data[N], *taxis = new Data[N], *output = new Data[N];
	for (int i = 0; i < N; i++){
		workers[i].number = i;
		cin >> workers[i].value;
	}
	for (int i = 0; i < N; i++){
		taxis[i].number = i + 1;
		cin >> taxis[i].value;
	}
	
	Data temp;
    for (int i = 0; i < N - 1; i++) {
        for (int j = 0; j < N - i - 1; j++) {
            if (workers[j].value < workers[j + 1].value) {
                temp = workers[j];
                workers[j] = workers[j + 1];
                workers[j + 1] = temp;
            }
            if (taxis[j].value > taxis[j + 1].value) {
                temp = taxis[j];
                taxis[j] = taxis[j + 1];
                taxis[j + 1] = temp;
            }
        }
    }
    
	for (int i = 0; i < N; i++){
		cout << taxis[workers[i].number].number << " ";
	}
    
	/*for (int i = 0; i < N; i++){
		cout << workers[i].number << " ";
		//cout << workers[i].value << " ";
	}
	cout << endl;
	for (int i = 0; i < N; i++){
		cout << taxis[i].number << " ";
		//cout << taxis[i].value << " ";
	}*/
	
	delete[] workers;
	delete[] taxis;
	return 0;
}
