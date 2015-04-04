#include "Debug.h"

Debug::Debug(bool enabled){
	cout << "Debug: Inicio del Programa"  << endl;
	Able = enabled;
}

void Debug::WriteLine(string line)
{
	if(Able)
	{
		numline++;
		cout << "Debug Line " << numline << " : "<< line << endl;
	}

}