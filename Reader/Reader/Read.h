#include <iostream>
#include <fstream>
#include <cstring>
#include "RPG.h"
#include "LDB_Chunks.h"

using namespace std;
using namespace RPG;
using namespace LDB_Reader;

class Read{
	public:
		char *Buffer;
		int Lenght;
		int ReadingPos;
		short OpenFile(string Filename);
		void Output(string s1, string s2);
		short ReadHeader();
		short ReadActor();
		char GetFlag(int index);
		
		Header HeaderInfo;		
		Actor *Actors;
		
		short ReadByte(int index);		
		string ReadString(int index, int len);
		void Mid( char* str,int index, int len);

		
};
