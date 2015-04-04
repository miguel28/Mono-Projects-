#include "main.h"

int main (int argc, char *argv[])
{
	
	
	Out.WriteLine("Abriendo Archivo: RPG_RT.ldb");
	
	Read Reader;
	switch(Reader.OpenFile("/Users/miguelsilva/Proyecto1/RPG_RT.ldb"))
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
	
	Reader.ReadHeader();
	Reader.ReadActor();

	return 0;
}

