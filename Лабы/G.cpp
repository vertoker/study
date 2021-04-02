#include <iostream>

using namespace std;

int main(){
	int i=1,r=1,y=1,g;
	//cout << "input numbers of lops: "
	cin >>g;
	while (i<g){
		r++;
		y+=2;
		i++;
	}
	cout <<r<< " "<< y;
	return 0;
}
