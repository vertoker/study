#include<iostream>
#include<string>
using namespace std;

int main(){
	int a=0, num, currency[5] = {50, 20, 10, 5, 1};
	//cout >> "Write money: ";
	cin >> num;
	if(num>0){
		for (int i=0; i!=num;){
			if(i+ currency[a] <=num){
				i=i+ currency[a];
				cout << currency[a] << " ";
			}else{
				a++;
			}
		}
	}else{
		cout << "Wrong number";
	}
}
