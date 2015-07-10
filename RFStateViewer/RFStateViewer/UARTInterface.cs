using System;
using System.IO.Ports;

namespace UART
{
	public class UARTInterface
	{
		public SerialPort mySerial;

		public UARTInterface (string dev, int baud)
		{
			if (mySerial != null)
				if (mySerial.IsOpen)
					mySerial.Close();

			mySerial = new SerialPort(dev, baud);
			mySerial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
			mySerial.Open();
			mySerial.ReadTimeout = 400;
		}

		private static void DataReceivedHandler(object sender,SerialDataReceivedEventArgs e)
		{
			SerialPort sp = (SerialPort)sender;
			string indata = sp.ReadExisting();
			Console.WriteLine("Data Received:");
			Console.Write(indata);
		}

		public string ReadData()
		{
			byte tmpByte;
			string rxString = "";

			tmpByte = (byte) mySerial.ReadByte();

			while (tmpByte != 255) {
				rxString += ((char) tmpByte);
				tmpByte = (byte) mySerial.ReadByte();			
			}

			return rxString;
		}

		public bool SendData(string Data)
		{
			mySerial.Write(Data);
			return true;		
		}

	}
}

