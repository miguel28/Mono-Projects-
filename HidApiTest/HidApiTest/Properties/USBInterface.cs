using System;
using HidSharp;
using System.Diagnostics;
using System.Linq;
using System.Threading;
namespace HidApiTest
{
	public class USBInterface
	{
		var DeviceHandle;
		HidDeviceLoader loader = new HidDeviceLoader();
		public USBInterface ()
		{
		}
		public void EnumerateHIDs()
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var deviceList = loader.GetDevices().ToArray();
			stopwatch.Stop();
			long deviceListTotalTime = stopwatch.ElapsedMilliseconds;

			Console.WriteLine("Complete device list (took {0} ms to get {1} devices):",
			                  deviceListTotalTime, deviceList.Length);
			foreach (HidDevice dev in deviceList)
			{
				Console.WriteLine("Device -> VendorID = " + dev.VendorID.ToString() + " ProductID = " +dev.ProductID.ToString());
				Console.WriteLine("Manufacturer: " + dev.Manufacturer);
				Console.WriteLine("Product     : " + dev.ProductName);
				Console.WriteLine("Serial      : " + dev.SerialNumber);
				Console.WriteLine();  
			}
			Console.WriteLine();   

		}

		public void HIDOpen(ushort VendorID, ushort ProductID)
		{
			if(!HIDisOpen)
			{
				DeviceHandle = loader.GetDevices(VendorID, ProductID).FirstOrDefault(d => d.MaxInputReportLength == 63);
				if(DeviceHandle!=null)HIDisOpen = true;
			}
		}

		public void HIDDescription()
		{
			if(HIDisOpen)
			{
				Console.WriteLine("Device -> VendorID = " + DeviceHandle.VendorID.ToString() + " ProductID = " + DeviceHandle.ProductID.ToString());
				Console.WriteLine("Manufacturer: " + DeviceHandle.Manufacturer);
				Console.WriteLine("Product     : " + DeviceHandle.ProductName);
				Console.WriteLine("Serial      : " + DeviceHandle.SerialNumber);
				Console.WriteLine();
			}
		}
		/*
		void USBInterface::HIDClose()
		{
			if(HIDisOpen)
			{
				hid_close(DeviceHandle);
				hid_set_nonblocking(DeviceHandle,1);
				HIDisOpen= false;    
			}
		}

		void USBInterface::CleanBufferOUT()
		{
			for(i=0; i<65; i++)BufferOUT[i]=0x00;     
		}

		void USBInterface::CleanBufferIN()
		{
			for(i=0; i<65; i++)BufferIN[i]=0x00;     
		}

		int USBInterface::SendBuffer()
		{
			if(HIDisOpen)
				return hid_write(DeviceHandle, BufferOUT, 65);
			else return -1;
		}

		int USBInterface::SendOutputPort(const unsigned char Value)
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

		int USBInterface::ReciveBuffer()
		{
			CleanBufferIN();
			if(HIDisOpen)
			{
				//res = hid_read_timeout(DeviceHandle, BufferIN, 65,1);
				res = hid_read(DeviceHandle, BufferIN, 65);
				return res;
			}
			else return -1;
		}

		unsigned char USBInterface::GetInputBuffer()
		{
			CleanBufferIN();
			ReciveBuffer();
			if(HIDisOpen)
			{
				return BufferIN[0];
			}
			else return 1;
		}

		void USBInterface::PrintBufferIN()
		{
			for (i = 0; i < res; i++)
				printf("buf[%d]: %d\n", i, BufferIN[i]);
		}
*/
	}
}

