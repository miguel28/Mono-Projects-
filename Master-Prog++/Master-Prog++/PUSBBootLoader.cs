// Type: SysProgUSB.PUSBBootLoader
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System.Globalization;
using System.IO;
using System.Threading;

namespace SysProgUSB
{
	internal class PUSBBootLoader
	{
		public static bool ReadHexAndDownload(string fileName, ref ushort pk2num)
		{
			try
			{
				TextReader textReader = (TextReader) new FileInfo(fileName).OpenText();
				byte[] payload = new byte[35];
				string str = textReader.ReadLine();
				if (str != null)
				{
					ProgCommand.EnterBootloader();
					ProgCommand.ResetPUSBNumber();
					Thread.Sleep(3000);
					pk2num = (ushort) 0;
					int num;
					for (num = 0; num < 10; ++num)
					{
						if (ProgCommand.DetectPICkit2Device(pk2num, true) == Constants.PICkit2USB.bootloader)
						{
							if (ProgCommand.VerifyBootloaderMode())
								break;
						}
						else
							++pk2num;
						Thread.Sleep(500);
					}
					if (num == 10)
					{
						textReader.Close();
						return false;
					}
				}
				ProgCommand.BL_EraseFlash();
				bool flag = false;
				for (; str != null; str = textReader.ReadLine())
				{
					if ((int) str[0] == 58 && str.Length >= 11)
					{
						int num1 = int.Parse(str.Substring(1, 2), NumberStyles.HexNumber);
						int num2 = int.Parse(str.Substring(3, 4), NumberStyles.HexNumber);
						int num3 = int.Parse(str.Substring(7, 2), NumberStyles.HexNumber);
						if (flag && (num2 & 16) == 0)
						{
							ProgCommand.BL_WriteFlash(payload);
							for (int index = 0; index < payload.Length; ++index)
								payload[index] = byte.MaxValue;
						}
						flag = (num2 & 16) == 16;
						if (num3 == 0 && num2 >= 8192 && num2 < 32736)
						{
							if (!flag)
							{
								int num4 = num2 & 65504;
								payload[0] = (byte) (num4 & (int) byte.MaxValue);
								payload[1] = (byte) (num4 >> 8 & (int) byte.MaxValue);
								payload[2] = (byte) 0;
							}
							if (str.Length >= 11 + 2 * num1)
							{
								int num4 = num2 & 15;
								int num5 = num4 + num1;
								int num6 = 3;
								if (flag)
									num6 = 19;
								for (int index = 0; index < 16; ++index)
								{
									if (index >= num4 && index < num5)
									{
										uint num7 = uint.Parse(str.Substring(9 + 2 * (index - num4), 2), NumberStyles.HexNumber);
										payload[num6 + index] = (byte) (num7 & (uint) byte.MaxValue);
									}
								}
							}
						}
						if (num3 == 1)
							break;
					}
				}
				ProgCommand.BL_WriteFlash(payload);
				textReader.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool ReadHexAndVerify(string fileName)
		{
			try
			{
				TextReader textReader = (TextReader) new FileInfo(fileName).OpenText();
				string str = textReader.ReadLine();
				bool flag = true;
				int num1 = 0;
				for (; str != null; str = textReader.ReadLine())
				{
					if ((int) str[0] == 58 && str.Length >= 11)
					{
						int num2 = int.Parse(str.Substring(1, 2), NumberStyles.HexNumber);
						int num3 = int.Parse(str.Substring(3, 4), NumberStyles.HexNumber);
						int num4 = int.Parse(str.Substring(7, 2), NumberStyles.HexNumber);
						if (num4 == 0 && num3 >= 8192 && num3 < 32736)
						{
							int num5 = num3 & 15;
							int address = num3 & 65520;
							if (num1 != address)
								ProgCommand.BL_ReadFlash16(address);
							if (str.Length >= 11 + 2 * num2)
							{
								for (int index = 0; index < num2; ++index)
								{
									uint num6 = uint.Parse(str.Substring(9 + 2 * index, 2), NumberStyles.HexNumber);
									if ((int) ProgCommand.Usb_read_array[6 + num5 + index] != (int) (byte) (num6 & (uint) byte.MaxValue))
									{
										flag = false;
										num4 = 1;
										break;
									}
								}
							}
							num1 = address;
						}
						if (num4 == 1)
							break;
					}
				}
				textReader.Close();
				return flag;
			}
			catch
			{
				return false;
			}
		}
	}
}
