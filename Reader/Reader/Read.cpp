#include "Read.h"

short Read::OpenFile(string Filename){
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

void Read::Output(string s1, string s2)
{
	cout << s1 << " : " << s2 <<endl;

}

short Read::ReadHeader()
{
	HeaderInfo.Info+=ReadString(0,12);
	//cout << HeaderInfo.Info;

	HeaderInfo.NumActors = ReadByte(15);
	//cout << HeaderInfo.NumActors << hex << exp_inflation;
	
	Actors = new Actor[HeaderInfo.NumActors];
}

short Read::ReadActor()
{
	ReadingPos=17;// Inicia en posicion 16 de hecho;
	
	
	while((GetFlag(ReadingPos)!=0x02)||(GetFlag(ReadingPos)==0x02  && GetFlag(ReadingPos+1)!=0x01))
	{
		switch(GetFlag(ReadingPos))
		{
			case name:
				cout << "Pos: " << ReadingPos << " : "<< hex <<(int)GetFlag(ReadingPos) << " : " << (int)GetFlag(ReadingPos+1 )<< endl;
				
				Actors[0].Name+=ReadString(ReadingPos+2,(int)GetFlag(ReadingPos+1));
				Output("-Nombre",Actors[0].Name);
				ReadingPos+=2+(int)GetFlag(ReadingPos+1);
				
				//cout<< hex << (int)GetFlag(ReadingPos) << " "<<(int)GetFlag(ReadingPos+1);
				
				break;
				
			case title:
				cout << "Pos: " << dec <<ReadingPos << " : "<< hex <<(int)GetFlag(ReadingPos) << " : " << (int)GetFlag(ReadingPos+1 )<< endl;
				
				Actors[0].Title+=ReadString(ReadingPos+2,(int)GetFlag(ReadingPos+1));
				Output("-Titulo",Actors[0].Title);
				ReadingPos+=2+(int)GetFlag(ReadingPos+1);
				
				break;
			case character_name:
				cout << "Pos: " << dec <<ReadingPos << " : "<< hex <<(int)GetFlag(ReadingPos) << " : " << (int)GetFlag(ReadingPos+1 )<< endl;
				
				Actors[0].Character_Name+=ReadString(ReadingPos+2,(int)GetFlag(ReadingPos+1));
				Output("-Char Nombre",Actors[0].Character_Name);
				ReadingPos+=2+(int)GetFlag(ReadingPos+1);
				
				break;
			case character_index:
				break;
			case transparent:
				break;
			case initial_level:
				break;
			case final_level:
				break;
			case critical_hit:
				break;
			case critical_hit_chance:
				break;
			case face_name:
				cout << "Pos: " << dec <<ReadingPos << " : "<< hex <<(int)GetFlag(ReadingPos) << " : " << (int)GetFlag(ReadingPos+1 )<< endl;
				
				Actors[0].Face_Name+=ReadString(ReadingPos+2,(int)GetFlag(ReadingPos+1));
				Output("-Face Nombre",Actors[0].Face_Name);
				ReadingPos+=2+(int)GetFlag(ReadingPos+1);
				
				break;
			case face_index:
				break;
			case two_swords_style:
				break;
			case fix_equipment:
				break;
			case auto_battle:
				break;
			case super_guard:
				break;
			case parameters:
				//Output("-Parametros","Encontrados");
				break;
			case exp_base:
				break;
			case exp_inflation:
				break;
			case exp_correction:
				break;
			case initial_equipment:
				break;
			case unarmed_animation:
				break;
			case class_id:
				break;
			case battle_x:
				break;
			case battle_y:
				break;
			case battler_animation:
				break;
			case skills:
				break;
			case rename_skill:
				break;
			case skill_name:
				break;
			case state_ranks_size:
				break;
			case state_ranks:
				break;
			case attribute_ranks_size:
				break;
			case attribute_ranks:
				break;
			case battle_commands:
				break;
		}
			
	}
}


char Read::GetFlag(int index)
{
	return Buffer[index];
}





short Read::ReadByte(int index)
{
	return (short)Buffer[index];
}

string Read::ReadString(int index, int len)
{
	int i;
	char *Temp = new char[len+2];
	for(i=0; i<len; i++)
	{
		Temp[i]=Buffer[i+index];
	}
	Temp[len+1]='\0';
	string Temp2;
	Temp2+=Temp; 
	return Temp2;
}


void Read::Mid( char* str,int index, int len)
{
	strncpy(str, Buffer+index, len);
}
