using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace HidApiTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			USBInterface usb = new USBInterface ();
			//usb.EnumerateHIDs();
			usb.HIDOpen (0x3995,0x0001);
			if(usb.HIDisOpen)
				Console.WriteLine ("Hid Opened");
			else 
				Console.WriteLine ("Hid not Opened");
			usb.HIDDescription ();
			usb.SendOutputPort((byte)0xFF);
			Thread.Sleep(1000);
			usb.SendOutputPort((byte)0x0F);
			Thread.Sleep(1000);
			usb.SendOutputPort((byte)0xF0);
			Thread.Sleep(1000);//*/

			int i = 0;

			for (i=0; i<255; i++) 
			{
				usb.SendOutputPort((byte)i);
				Console.WriteLine (i.ToString());
				Thread.Sleep(100);
			}


			usb.GetInputBuffer ();
			usb.Print ();
		}
	}
}
