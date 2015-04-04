#include "main.h"



int main (int argc, char *argv[])
{
	Debug Out(true);
	
	Out.WriteLine("Abriendo Archivo: RPG_RT.ldb");
	
	ReadClass Reader;
	switch(Reader.OpenFile("RPG_RT.ldb"))
	{
		case 1:
			Out.WriteLine("Error al Abrir Archivo");
			break;
		case 2:
			Out.WriteLine("Error al Asignar memoria");
			break;
		default:
			Out.WriteLine("Archivo Abierto");	
			break;		
	}
	Out.WriteLine("Archivo Cerrado");

	return 0;
}

