// Type: SysProgUSB.USB
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SysProgUSB
{
  public class USB
  {
    public static string UnitID = "";
    private const uint GENERIC_READ = 2147483648U;
    private const uint GENERIC_WRITE = 1073741824U;
    private const uint FILE_SHARE_READ = 1U;
    private const uint FILE_SHARE_WRITE = 2U;
    private const uint FILE_FLAG_OVERLAPPED = 1073741824U;
    private const int INVALID_HANDLE_VALUE = -1;
    private const short OPEN_EXISTING = (short) 3;
    private const short DIGCF_PRESENT = (short) 2;
    private const short DIGCF_DEVICEINTERFACE = (short) 16;

    static USB()
    {
    }

    [DllImport("hid.dll")]
    public static void HidD_GetHidGuid(ref Guid HidGuid);

    [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
    public static IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, int hwndParent, int Flags);

    [DllImport("setupapi.dll")]
    public static int SetupDiEnumDeviceInterfaces(IntPtr DeviceInfoSet, int DeviceInfoData, ref Guid InterfaceClassGuid, int MemberIndex, ref USB.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

    [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
    public static bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref USB.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, ref USB.SECURITY_ATTRIBUTES lpSecurityAttributes, int dwCreationDisposition, uint dwFlagsAndAttributes, int hTemplateFile);

    [DllImport("hid.dll")]
    public static int HidD_GetAttributes(IntPtr HidDeviceObject, ref USB.HIDD_ATTRIBUTES Attributes);

    [DllImport("hid.dll")]
    public static bool HidD_GetPreparsedData(IntPtr HidDeviceObject, ref IntPtr PreparsedData);

    [DllImport("hid.dll")]
    public static bool HidD_GetSerialNumberString(IntPtr HidDeviceObject, byte[] Buffer, ulong BufferLength);

    [DllImport("hid.dll")]
    public static int HidP_GetCaps(IntPtr PreparsedData, ref USB.HIDP_CAPS Capabilities);

    [DllImport("setupapi.dll")]
    public static int SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

    [DllImport("hid.dll")]
    public static bool HidD_FreePreparsedData(ref IntPtr PreparsedData);

    [DllImport("kernel32.dll")]
    public static int CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static bool WriteFile(IntPtr hFile, byte[] Buffer, int numBytesToWrite, ref int numBytesWritten, int Overlapped);

    [DllImport("kernel32", SetLastError = true)]
    public static bool ReadFile(IntPtr hFile, byte[] Buffer, int NumberOfBytesToRead, ref int pNumberOfBytesRead, int Overlapped);

    public static bool Find_This_Device(ushort p_VendorID, ushort p_PoductID, ushort p_index, ref IntPtr p_ReadHandle, ref IntPtr p_WriteHandle)
    {
      IntPtr num1 = IntPtr.Zero;
      IntPtr PreparsedData = IntPtr.Zero;
      USB.HIDP_CAPS Capabilities = new USB.HIDP_CAPS();
      ushort num2 = (ushort) 0;
      IntPtr num3 = IntPtr.Zero;
      int RequiredSize = 0;
      USB.SECURITY_ATTRIBUTES lpSecurityAttributes = new USB.SECURITY_ATTRIBUTES();
      IntPtr num4 = new IntPtr(-1);
      byte[] numArray = new byte[64];
      lpSecurityAttributes.lpSecurityDescriptor = 0;
      lpSecurityAttributes.bInheritHandle = Convert.ToInt32(true);
      lpSecurityAttributes.nLength = Marshal.SizeOf((object) lpSecurityAttributes);
      Guid guid = Guid.Empty;
      USB.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData;
      DeviceInterfaceData.cbSize = 0;
      DeviceInterfaceData.Flags = 0;
      DeviceInterfaceData.InterfaceClassGuid = Guid.Empty;
      DeviceInterfaceData.Reserved = 0;
      USB.SP_DEVICE_INTERFACE_DETAIL_DATA interfaceDetailData;
      interfaceDetailData.cbSize = 0;
      interfaceDetailData.DevicePath = "";
      USB.HIDD_ATTRIBUTES Attributes;
      Attributes.ProductID = (ushort) 0;
      Attributes.Size = 0;
      Attributes.VendorID = (ushort) 0;
      Attributes.VersionNumber = (ushort) 0;
      bool flag = false;
      lpSecurityAttributes.lpSecurityDescriptor = 0;
      lpSecurityAttributes.bInheritHandle = Convert.ToInt32(true);
      lpSecurityAttributes.nLength = Marshal.SizeOf((object) lpSecurityAttributes);
      USB.HidD_GetHidGuid(ref guid);
      IntPtr classDevs = USB.SetupDiGetClassDevs(ref guid, (string) null, 0, 18);
      DeviceInterfaceData.cbSize = Marshal.SizeOf((object) DeviceInterfaceData);
      for (int MemberIndex = 0; MemberIndex < 20; ++MemberIndex)
      {
        if (USB.SetupDiEnumDeviceInterfaces(classDevs, 0, ref guid, MemberIndex, ref DeviceInterfaceData) != 0)
        {
          USB.SetupDiGetDeviceInterfaceDetail(classDevs, ref DeviceInterfaceData, IntPtr.Zero, 0, ref RequiredSize, IntPtr.Zero);
          interfaceDetailData.cbSize = Marshal.SizeOf((object) interfaceDetailData);
          IntPtr num5 = Marshal.AllocHGlobal(RequiredSize);
          Marshal.WriteInt32(num5, 4 + Marshal.SystemDefaultCharSize);
          USB.SetupDiGetDeviceInterfaceDetail(classDevs, ref DeviceInterfaceData, num5, RequiredSize, ref RequiredSize, IntPtr.Zero);
          string lpFileName = Marshal.PtrToStringAuto(new IntPtr(num5.ToInt32() + 4));
          IntPtr file = USB.CreateFile(lpFileName, 3221225472U, 3U, ref lpSecurityAttributes, 3, 0U, 0);
          if (file != num4)
          {
            Attributes.Size = Marshal.SizeOf((object) Attributes);
            if (USB.HidD_GetAttributes(file, ref Attributes) != 0)
            {
              if ((int) Attributes.VendorID == (int) p_VendorID && (int) Attributes.ProductID == (int) p_PoductID)
              {
                if ((int) num2 == (int) p_index)
                {
                  flag = true;
                  USB.HidD_GetSerialNumberString(file, numArray, 64UL);
                  if ((int) numArray[0] == 9 || (int) numArray[0] == 0)
                  {
                    USB.UnitID = "-";
                  }
                  else
                  {
                    int index = 2;
                    while (index < 64)
                    {
                      numArray[index / 2] = numArray[index];
                      if ((int) numArray[index] != 0)
                      {
                        numArray[index] = (byte) 0;
                        numArray[index + 1] = (byte) 0;
                        index += 2;
                      }
                      else
                        break;
                    }
                    int num6 = index / 2;
                    char[] chars = new char[Encoding.ASCII.GetCharCount(numArray, 0, num6)];
                    Encoding.ASCII.GetChars(numArray, 0, num6, chars, 0);
                    USB.UnitID = new string(chars);
                  }
                  p_WriteHandle = file;
                  USB.HidD_GetPreparsedData(file, ref PreparsedData);
                  USB.HidP_GetCaps(PreparsedData, ref Capabilities);
                  p_ReadHandle = USB.CreateFile(lpFileName, 3221225472U, 3U, ref lpSecurityAttributes, 3, 0U, 0);
                  USB.HidD_FreePreparsedData(ref PreparsedData);
                  break;
                }
                else
                {
                  USB.CloseHandle(file);
                  ++num2;
                }
              }
              else
              {
                flag = false;
                USB.CloseHandle(file);
              }
            }
            else
            {
              flag = false;
              USB.CloseHandle(file);
            }
          }
        }
      }
      USB.SetupDiDestroyDeviceInfoList(classDevs);
      return flag;
    }

    public struct SP_DEVICE_INTERFACE_DATA
    {
      public int cbSize;
      public Guid InterfaceClassGuid;
      public int Flags;
      public int Reserved;
    }

    public struct SP_DEVICE_INTERFACE_DETAIL_DATA
    {
      public int cbSize;
      public string DevicePath;
    }

    public struct SP_DEVINFO_DATA
    {
      public int cbSize;
      public Guid ClassGuid;
      public int DevInst;
      public int Reserved;
    }

    public struct HIDD_ATTRIBUTES
    {
      public int Size;
      public ushort VendorID;
      public ushort ProductID;
      public ushort VersionNumber;
    }

    public struct SECURITY_ATTRIBUTES
    {
      public int nLength;
      public int lpSecurityDescriptor;
      public int bInheritHandle;
    }

    public struct HIDP_CAPS
    {
      public short Usage;
      public short UsagePage;
      public short InputReportByteLength;
      public short OutputReportByteLength;
      public short FeatureReportByteLength;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
      public short[] Reserved;
      public short NumberLinkCollectionNodes;
      public short NumberInputButtonCaps;
      public short NumberInputValueCaps;
      public short NumberInputDataIndices;
      public short NumberOutputButtonCaps;
      public short NumberOutputValueCaps;
      public short NumberOutputDataIndices;
      public short NumberFeatureButtonCaps;
      public short NumberFeatureValueCaps;
      public short NumberFeatureDataIndices;
    }
  }
}
