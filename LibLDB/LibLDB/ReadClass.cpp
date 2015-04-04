#include "ReadClass.h"

short ReadClass::OpenFile(string Filename){
	FILE* Read = fopen (Filename.c_str(), "rb");
	
	if(!Read) return 1;
	
	fseek(Read, 0, SEEK_END); // seek to end of file
	Lenght = ftell(Read); // get current file pointer
	fseek(Read, 0, SEEK_SET);
	
	Buffer= new char[Lenght];
	
	if(!Buffer) return 2;
	
	fread(Buffer, 1, Lenght, Read);
	fclose(Read);
	
	return 0;
}
short ReadClass::ReadHeader()
{
	//ReadString(Header,0,11);

}
short ReadClass::ReadActor()
{


}/*
void ReadClass::ReadByte(short* Var,int index)
{
	char *str;
	strncpy(str, Buffer+index, 1);
	
	Var = (short*)str;	
}
/*
void ReadClass::ReadString(string str,int index, int len)
{
	char *temp;
	strncpy(temp, Buffer+index, len);
	string temp2;
	temp2+=temp;
	//return temp2;
}

/*
void ReadClass::ReadString( char* str,int index, int len)
{
	strncpy(str, Buffer+index, len);
}*/