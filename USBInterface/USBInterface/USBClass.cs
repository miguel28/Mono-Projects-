using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices; 
using System.Text;

namespace USBInterface
{
	public class USBClass
	{
		[DllImport ("hidapi.dll")]
		public extern static IntPtr hid_open(ushort vendor_id, ushort product_id, IntPtr serial_number);

		[DllImport ("hidapi.dll")]
		public extern static void hid_close(IntPtr device);

		[DllImport ("hidapi.dll")]
		public extern static int hid_set_nonblocking(IntPtr device, int nonblock);

		[DllImport ("hidapi.dll")]
		public extern static int hid_write(IntPtr device, IntPtr data, int length);

		[DllImport ("hidapi.dll")]
		public extern static int hid_read(IntPtr device, IntPtr data, int length);

		[DllImport ("hidapi.dll")]
		public extern static int hid_get_manufacturer_string(IntPtr device, IntPtr str, UInt32 size);

		[DllImport ("hidapi.dll")]
		public extern static int hid_get_product_string(IntPtr device, IntPtr str, UInt32 size);

		public bool HIDisOpen = false;
		public byte[] BufferOUT = new byte[65];
		public byte[] BufferIN = new byte[65];

		private IntPtr DeviceHandle;
		private IntPtr WStringPointer = Marshal.AllocHGlobal(255);
		private byte[] ByteArray = new byte[255];

		public USBClass ()
		{
		}


		private string ParseWString()
		{
			try
			{
				Marshal.Copy(WStringPointer, ByteArray, 0, 100);
				ByteArray = Encoding.Convert (Encoding.UTF8, Encoding.ASCII, ByteArray); 
				string str = Encoding.ASCII.GetString(ByteArray);
				Marshal.FreeHGlobal (WStringPointer);
				WStringPointer = IntPtr.Zero;
				WStringPointer = Marshal.AllocHGlobal(255);
				int a = str.IndexOf ("?");
				if (a > 100)
					a = 100;
				return str.Substring (0, a);
			}
			catch(Exception e)
			{
				return "Error Parsing String: " + e.Message;
			}
		}


		public void HIDDescription()
		{
			if(HIDisOpen)
			{

				hid_get_manufacturer_string(DeviceHandle, WStringPointer, 255);
				Console.WriteLine ("Manufacturer: " + ParseWString());
				hid_get_product_string(DeviceHandle, WStringPointer, 255);
				Console.WriteLine ("Product Name: " + ParseWString());
				//hid_get_serial_number_string(DeviceHandle, wstr, MAX_STR);
				//printf("Serial String: %ls\n", wstr);
			}
		}

		public void HIDOpen(ushort VendorID, ushort ProductID)
		{
			if(!HIDisOpen)
			{
				DeviceHandle = hid_open(VendorID, ProductID, IntPtr.Zero);
				if(DeviceHandle != IntPtr.Zero)HIDisOpen=true;
			}
		}

		public void HIDClose()
		{
			if(HIDisOpen)
			{
				hid_close(DeviceHandle);
				hid_set_nonblocking(DeviceHandle,1);
				HIDisOpen=false;    
			}
		}

		public void CleanBufferOUT()
		{
			int i;
			for(i=0; i<65; i++)BufferOUT[i]=0x00;     

		}

		public void CleanBufferIN()
		{
			int i;
			for(i=0; i<65; i++)BufferIN[i]=0x00;     
		}

		public int SendBuffer()
		{
			//BufferOUT[64]=Mode;
			if(HIDisOpen)
			{
				int size = Marshal.SizeOf(BufferOUT[0]) * BufferOUT.Length;
				IntPtr pnt = Marshal.AllocHGlobal(size);
				Marshal.Copy(BufferOUT, 0, pnt, BufferOUT.Length);
				return hid_write(DeviceHandle, pnt, 65);
			}
			else return -1;
		}

		int ReciveBuffer()
		{
			CleanBufferIN();
			if(HIDisOpen)
			{
				//res = hid_read_timeout(DeviceHandle, BufferIN, 65,1);
				int size = Marshal.SizeOf(BufferIN[0]) * BufferIN.Length;
				IntPtr pnt = Marshal.AllocHGlobal(size);
				int res = hid_read(DeviceHandle, pnt, 65);
				Marshal.Copy (pnt, BufferIN, 0, BufferIN.Length);
				return res;
			}
			else return -1;
		}

		public byte GetInputBuffer()
		{
			CleanBufferIN();
			ReciveBuffer();
			if(HIDisOpen)
			{
				return BufferIN[0];
			}
			else return 1;
		}

		public int SendOutputPort(byte Value)
		{
			if(HIDisOpen)
			{
				CleanBufferOUT();
				BufferOUT[0]=0x00;
				BufferOUT[1]=Value;
				return SendBuffer();
			}
			else return -1;
		}

		public void Print()
		{
			int i;
			for (i=0; i<64; i++)
				Console.Write (Convert.ToInt16(BufferIN[i])+ ",");
			Console.WriteLine ("");
		}
	}
}
