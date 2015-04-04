#include <iostream>
#include <fstream>
#include <cstring>
#include "RPG.h"
#include "LDB_Chunks.h"

using namespace std;
using namespace RPG;
using namespace LDB_Reader;

class ReadClass{
	public:
		char *Buffer;
		int Lenght;
		short OpenFile(string Filename);
		short ReadHeader();
		short ReadActor();
		
				
		//void ReadByte(short *Var, int index);		
		//void ReadString(string str,int index, int len);
		
		
};
