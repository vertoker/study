#include <iostream>

using namespace std;

int Clamp(int num, int length){
	int power = num / length;
	int result = num - power * length;
	if(result < 0){
		result = length + result;
	}
	return result;
}

int main() {
	int vector1[7]  =  {4,  7,  2,  8,  1,  3,  0};
	
	char dir;
	bool error = false;
	int power, znak;
	cin >> dir >> power;
	
	if(dir == 'l'){
		znak = -1;
	}
	else if(dir == 'r'){
		znak = 1;
	}
	else{
		cout << "Wrong direction";
		error = true;
	}
	
	if(power < 0){
		cout << "Wrong number";
		error = true;
	}
	
	if(!error){
		int temp = vector1[0];
		for(int x = 0; x < 6; x++){
			int past = Clamp(power * x * znak, 7);
			int next = Clamp(power * (x + 1) * znak, 7);
			cout << past << ' ' << next << endl;
			vector1[past] = vector1[next];
		}
		int next = Clamp(power * 6, 7);
		vector1[next] = temp;
		
		for(int i = 0; i < 7; i++) {
			cout << vector1[i] << ' ';
		}
		cout << endl;
	}
	return 0;
}
