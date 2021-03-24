#include <iostream>
#include <stdlib.h>
#include <list>

using namespace std;


int main()
{
	list<int,int> matriceAdiacenze;
	list<int,int>::iterator j;
	int Numeronodi, nodoIniziale, nodoFinale,partenza,arrivo,costo;
	cout << "Inserire il numero di nodi: ";
	cin >> Numeronodi;
	for (int i = 0; i < Numeronodi; i++) {
		matriceAdiacenze.push_front(i);
	}
	cout << "Inserire terna di nodi (nodo_partenza nodo_arrivo costo)\n>> ";
	cin >> partenza>> arrivo>> costo;


}