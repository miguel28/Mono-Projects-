// Type: SysProgUSB.ProgCommand
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.IO;
using System.Text;

namespace SysProgUSB
{
  public class ProgCommand
  {
    public static string FirmwareVersion = "NA";
    public static string DeviceFileVersion = "NA";
    public static DeviceFile DevFile = new DeviceFile();
    public static byte[] Usb_write_array = new byte[IntPtr(65)];
    public static byte[] Usb_read_array = new byte[IntPtr(65)];
    public static int ActivePart = 0;
    public static uint LastDeviceID = 0U;
    public static int LastDeviceRev = 0;
    public static bool LearnMode = false;
    private static IntPtr usbReadHandle = IntPtr.Zero;
    private static IntPtr usbWriteHandle = IntPtr.Zero;
    private static ushort lastPUSBnumber = (ushort) byte.MaxValue;
    private static bool vddOn = false;
    private static float vddLastSet = 3.3f;
    private static bool targetSelfPowered = false;
    private static bool fastProgramming = true;
    private static bool assertMCLR = false;
    private static bool vppFirstEnabled = false;
    private static uint scriptBufferChecksum = 0U;
    private static int lastFoundPart = 0;
    private static ProgCommand.scriptRedirect[] scriptRedirectTable = new ProgCommand.scriptRedirect[32];
    public static DeviceData DeviceBuffers;
    private static int[] familySearchTable;

    static ProgCommand()
    {
    }

    public static bool CheckComm()
    {
      if (!ProgCommand.writeUSB(new byte[17]
      {
        (byte) 167,
        (byte) 168,
        (byte) 8,
        (byte) 1,
        (byte) 2,
        (byte) 3,
        (byte) 4,
        (byte) 5,
        (byte) 6,
        (byte) 7,
        (byte) 8,
        (byte) 185,
        (byte) 0,
        (byte) 1,
        (byte) 170,
        (byte) 167,
        (byte) 169
      }) || !ProgCommand.readUSB() || (int) ProgCommand.Usb_read_array[1] != 63)
        return false;
      for (int index = 1; index < 9; ++index)
      {
        if ((int) ProgCommand.Usb_read_array[1 + index] != index)
          return false;
      }
      return true;
    }

    public static bool EnterLearnMode(byte memsize)
    {
      if (!ProgCommand.writeUSB(new byte[5]
      {
        (byte) 181,
        (byte) 80,
        (byte) 75,
        (byte) 50,
        memsize
      }))
        return false;
      ProgCommand.LearnMode = true;
      float voltage = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].Vpp;
      if ((double) voltage < 1.0)
        ProgCommand.SetVppVoltage(ProgCommand.vddLastSet, 0.7f);
      else
        ProgCommand.SetVppVoltage(voltage, 0.7f);
      ProgCommand.downloadPartScripts(ProgCommand.GetActiveFamily());
      return true;
    }

    public static bool ExitLearnMode()
    {
      ProgCommand.LearnMode = false;
      return ProgCommand.writeUSB(new byte[1]
      {
        (byte) 182
      });
    }

    public static bool EnablePK2GoMode(byte memsize)
    {
      ProgCommand.LearnMode = false;
      return ProgCommand.writeUSB(new byte[5]
      {
        (byte) 183,
        (byte) 80,
        (byte) 75,
        (byte) 50,
        memsize
      });
    }

    public static bool MetaCmd_CHECK_DEVICE_ID()
    {
      int num1 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].DeviceIDMask;
      int num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DeviceID;
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift != 0)
      {
        num1 <<= 1;
        num2 <<= 1;
      }
      return ProgCommand.writeUSB(new byte[5]
      {
        (byte) 132,
        (byte) (num1 & (int) byte.MaxValue),
        (byte) (num1 >> 8 & (int) byte.MaxValue),
        (byte) (num2 & (int) byte.MaxValue),
        (byte) (num2 >> 8 & (int) byte.MaxValue)
      });
    }

    public static bool MetaCmd_READ_BANDGAP()
    {
      return ProgCommand.writeUSB(new byte[1]
      {
        (byte) 133
      });
    }

    public static bool MetaCmd_WRITE_CFG_BANDGAP()
    {
      return ProgCommand.writeUSB(new byte[1]
      {
        (byte) 134
      });
    }

    public static bool MetaCmd_READ_OSCCAL()
    {
      int num = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem - 1;
      return ProgCommand.writeUSB(new byte[3]
      {
        (byte) sbyte.MinValue,
        (byte) (num & (int) byte.MaxValue),
        (byte) (num >> 8 & (int) byte.MaxValue)
      });
    }

    public static bool MetaCmd_WRITE_OSCCAL()
    {
      int num = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem - 1;
      return ProgCommand.writeUSB(new byte[3]
      {
        (byte) 129,
        (byte) (num & (int) byte.MaxValue),
        (byte) (num >> 8 & (int) byte.MaxValue)
      });
    }

    public static bool MetaCmd_START_CHECKSUM()
    {
      return ProgCommand.writeUSB(new byte[3]
      {
        (byte) 130,
        ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift,
        (byte) 0
      });
    }

    public static bool MetaCmd_CHANGE_CHKSM_FRMT(byte format)
    {
      return ProgCommand.writeUSB(new byte[3]
      {
        (byte) 135,
        format,
        (byte) 0
      });
    }

    public static bool MetaCmd_VERIFY_CHECKSUM(uint checksum)
    {
      checksum = ~checksum;
      return ProgCommand.writeUSB(new byte[3]
      {
        (byte) 131,
        (byte) (checksum & (uint) byte.MaxValue),
        (byte) (checksum >> 8 & (uint) byte.MaxValue)
      });
    }

    public static void ResetPUSBNumber()
    {
      ProgCommand.lastPUSBnumber = (ushort) byte.MaxValue;
    }

    public static float MeasurePGDPulse()
    {
      if (ProgCommand.writeUSB(new byte[13]
      {
        (byte) 169,
        (byte) 166,
        (byte) 9,
        (byte) 243,
        (byte) 2,
        (byte) 232,
        (byte) 20,
        (byte) 243,
        (byte) 6,
        (byte) 191,
        (byte) 243,
        (byte) 3,
        (byte) 170
      }) && ProgCommand.readUSB() && (int) ProgCommand.Usb_read_array[1] == 2)
        return (float) ((int) ProgCommand.Usb_read_array[2] + (int) ProgCommand.Usb_read_array[3] * 256) * 0.021333f;
      else
        return 0.0f;
    }

    public static bool EnterUARTMode(uint baudValue)
    {
      return ProgCommand.writeUSB(new byte[5]
      {
        (byte) 167,
        (byte) 169,
        (byte) 179,
        (byte) (baudValue & (uint) byte.MaxValue),
        (byte) (baudValue >> 8 & (uint) byte.MaxValue)
      });
    }

    public static bool ExitUARTMode()
    {
      return ProgCommand.writeUSB(new byte[3]
      {
        (byte) 180,
        (byte) 167,
        (byte) 169
      });
    }

    public static bool ValidateOSSCAL()
    {
      uint num = ProgCommand.DeviceBuffers.OSCCAL & 65280U;
      return (int) num != 0 && (int) num == (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[7];
    }

    public static bool isCalibrated()
    {
      if (ProgCommand.writeUSB(new byte[3]
      {
        (byte) 178,
        (byte) 0,
        (byte) 4
      }) && ProgCommand.readUSB())
      {
        int num = (int) ProgCommand.Usb_read_array[1] + (int) ProgCommand.Usb_read_array[2] * 256;
        if (num <= 320 && num >= 192 && ((int) ProgCommand.Usb_read_array[1] != 0 || (int) ProgCommand.Usb_read_array[2] != 1 || ((int) ProgCommand.Usb_read_array[3] != 0 || (int) ProgCommand.Usb_read_array[4] != 128)))
          return true;
      }
      return false;
    }

    public static string UnitIDRead()
    {
      string str = "";
      if (ProgCommand.writeUSB(new byte[3]
      {
        (byte) 178,
        (byte) 240,
        (byte) 16
      }) && ProgCommand.readUSB() && (int) ProgCommand.Usb_read_array[1] == 35)
      {
        int length = 0;
        while (length < 15 && (int) ProgCommand.Usb_read_array[2 + length] != 0)
          ++length;
        byte[] bytes = new byte[length];
        Array.Copy((Array) ProgCommand.Usb_read_array, 2, (Array) bytes, 0, length);
        char[] chars = new char[Encoding.ASCII.GetCharCount(bytes, 0, bytes.Length)];
        Encoding.ASCII.GetChars(bytes, 0, bytes.Length, chars, 0);
        str = new string(chars);
      }
      return str;
    }

    public static bool UnitIDWrite(string unitID)
    {
      int num = unitID.Length;
      if (num > 15)
        num = 15;
      byte[] commandList = new byte[19];
      commandList[0] = (byte) 177;
      commandList[1] = (byte) 240;
      commandList[2] = (byte) 16;
      byte[] numArray = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, Encoding.Unicode.GetBytes(unitID));
      commandList[3] = num <= 0 ? byte.MaxValue : (byte) 35;
      for (int index = 0; index < 15; ++index)
        commandList[4 + index] = index >= num ? (byte) 0 : numArray[index];
      return ProgCommand.writeUSB(commandList);
    }

    public static bool SetVoltageCals(ushort adcCal, byte vddOffset, byte VddCal)
    {
      return ProgCommand.writeUSB(new byte[5]
      {
        (byte) 176,
        (byte) adcCal,
        (byte) ((uint) adcCal >> 8),
        vddOffset,
        VddCal
      });
    }

    public static bool HCS360_361_VppSpecial()
    {
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DeviceID != -202)
        return true;
      byte[] commandList = new byte[12];
      commandList[0] = (byte) 166;
      commandList[1] = (byte) 10;
      if (((int) ProgCommand.DeviceBuffers.ProgramMemory[0] & 1) == 0)
      {
        commandList[2] = (byte) 243;
        commandList[3] = (byte) 4;
        commandList[4] = (byte) 247;
        commandList[5] = (byte) 250;
        commandList[6] = (byte) 232;
        commandList[7] = (byte) 5;
        commandList[8] = (byte) 243;
        commandList[9] = (byte) 4;
        commandList[10] = (byte) 243;
        commandList[11] = (byte) 0;
      }
      else
      {
        commandList[2] = (byte) 243;
        commandList[3] = (byte) 4;
        commandList[4] = (byte) 246;
        commandList[5] = (byte) 251;
        commandList[6] = (byte) 232;
        commandList[7] = (byte) 5;
        commandList[8] = (byte) 243;
        commandList[9] = (byte) 12;
        commandList[10] = (byte) 243;
        commandList[11] = (byte) 8;
      }
      return ProgCommand.writeUSB(commandList);
    }

    public static bool FamilyIsEEPROM()
    {
      int length = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName.Length;
      if (length > 6)
        length = 6;
      return ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName.Substring(0, length) == "EEPROM";
    }

    public static bool FamilyIsKeeloq()
    {
      return ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName == "KEELOQ® HCS";
    }

    public static bool FamilyIsMCP()
    {
      int length = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName.Length;
      if (length > 3)
        length = 3;
      return ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName.Substring(0, length) == "MCP";
    }

    public static bool FamilyIsPIC32()
    {
      int length = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName.Length;
      if (length > 5)
        length = 5;
      return ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName.Substring(0, length) == "PIC32";
    }

    public static bool FamilyIsdsPIC30()
    {
      int length = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName.Length;
      if (length > 7)
        length = 7;
      return ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName.Substring(0, length) == "dsPIC30";
    }

    public static bool FamilyIsPIC18J()
    {
      int length = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName.Length;
      if (length > 9)
        length = 9;
      return ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName.Substring(0, length) == "PIC18F_J_";
    }

    public static void SetVPPFirstProgramEntry()
    {
      ProgCommand.vppFirstEnabled = true;
      ProgCommand.scriptBufferChecksum = ~ProgCommand.scriptBufferChecksum;
    }

    public static void ClearVppFirstProgramEntry()
    {
      ProgCommand.vppFirstEnabled = false;
      ProgCommand.scriptBufferChecksum = ~ProgCommand.scriptBufferChecksum;
    }

    public static void RowEraseDevice()
    {
      int repetitions1 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem / (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseSize;
      ProgCommand.RunScript(0, 1);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrPrepScript != 0)
      {
        ProgCommand.DownloadAddress3(0);
        ProgCommand.RunScript(6, 1);
      }
      do
      {
        if (repetitions1 >= 256)
        {
          ProgCommand.RunScript(26, 0);
          repetitions1 -= 256;
        }
        else
        {
          ProgCommand.RunScript(26, repetitions1);
          repetitions1 = 0;
        }
      }
      while (repetitions1 > 0);
      ProgCommand.RunScript(1, 1);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERowEraseScript > 0)
      {
        int repetitions2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem / (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERowEraseWords;
        ProgCommand.RunScript(0, 1);
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdPrepScript != 0)
        {
          ProgCommand.DownloadAddress3((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEAddr / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemBytesPerWord);
          ProgCommand.RunScript(8, 1);
        }
        do
        {
          if (repetitions2 >= 256)
          {
            ProgCommand.RunScript(28, 0);
            repetitions2 -= 256;
          }
          else
          {
            ProgCommand.RunScript(28, repetitions2);
            repetitions2 = 0;
          }
        }
        while (repetitions2 > 0);
        ProgCommand.RunScript(1, 1);
      }
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMemEraseScript <= 0)
        return;
      ProgCommand.RunScript(0, 1);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrPrepScript != 0)
      {
        ProgCommand.DownloadAddress3((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDAddr);
        ProgCommand.RunScript(6, 1);
      }
      ProgCommand.ExecuteScript((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMemEraseScript);
      ProgCommand.RunScript(1, 1);
    }

    public static bool ExecuteScript(int scriptArrayIndex)
    {
      if (scriptArrayIndex == 0)
        return false;
      int num = (int) ProgCommand.DevFile.Scripts[--scriptArrayIndex].ScriptLength;
      byte[] commandList = new byte[3 + num];
      commandList[0] = (byte) 169;
      commandList[1] = (byte) 166;
      commandList[2] = (byte) num;
      for (int index = 0; index < num; ++index)
        commandList[3 + index] = (byte) ProgCommand.DevFile.Scripts[scriptArrayIndex].Script[index];
      return ProgCommand.writeUSB(commandList);
    }

    public static bool GetVDDState()
    {
      return ProgCommand.vddOn;
    }

    public static bool SetMCLRTemp(bool nMCLR)
    {
      return ProgCommand.SendScript(new byte[1]
      {
        !nMCLR ? (byte) 246 : (byte) 247
      });
    }

    public static bool HoldMCLR(bool nMCLR)
    {
      ProgCommand.assertMCLR = nMCLR;
      return ProgCommand.SendScript(new byte[1]
      {
        !nMCLR ? (byte) 246 : (byte) 247
      });
    }

    public static void SetFastProgramming(bool fast)
    {
      ProgCommand.fastProgramming = fast;
      ProgCommand.scriptBufferChecksum = ~ProgCommand.scriptBufferChecksum;
    }

    public static void ForcePICkitPowered()
    {
      ProgCommand.targetSelfPowered = false;
    }

    public static void ForceTargetPowered()
    {
      ProgCommand.targetSelfPowered = true;
    }

    public static void ReadConfigOutsideProgMem()
    {
      ProgCommand.RunScript(0, 1);
      ProgCommand.RunScript(13, 1);
      ProgCommand.UploadData();
      ProgCommand.RunScript(1, 1);
      int num1 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
      int num2 = 2;
      for (int index1 = 0; index1 < num1; ++index1)
      {
        byte[] numArray1 = ProgCommand.Usb_read_array;
        int index2 = num2;
        int num3 = 1;
        int num4 = index2 + num3;
        int num5 = (int) numArray1[index2];
        byte[] numArray2 = ProgCommand.Usb_read_array;
        int index3 = num4;
        int num6 = 1;
        num2 = index3 + num6;
        int num7 = (int) numArray2[index3] << 8;
        uint num8 = (uint) (num5 | num7);
        if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
          num8 = num8 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
        ProgCommand.DeviceBuffers.ConfigWords[index1] = num8;
      }
    }

    public static void ReadBandGap()
    {
      ProgCommand.RunScript(0, 1);
      ProgCommand.RunScript(13, 1);
      ProgCommand.UploadData();
      ProgCommand.RunScript(1, 1);
      int num1 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
      uint num2 = (uint) ProgCommand.Usb_read_array[2] | (uint) ProgCommand.Usb_read_array[3] << 8;
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
        num2 = num2 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
      ProgCommand.DeviceBuffers.BandGap = num2 & ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask;
    }

    public static uint WriteConfigOutsideProgMem(bool codeProtect, bool dataProtect)
    {
      int num1 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
      uint num2 = 0U;
      byte[] dataArray = new byte[num1 * 2];
      if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask > 0U)
      {
        ProgCommand.DeviceBuffers.ConfigWords[0] &= ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask;
        if (!ProgCommand.LearnMode)
          ProgCommand.DeviceBuffers.ConfigWords[0] |= ProgCommand.DeviceBuffers.BandGap;
      }
      if (ProgCommand.FamilyIsMCP())
        ProgCommand.DeviceBuffers.ConfigWords[0] |= 16376U;
      ProgCommand.RunScript(0, 1);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWrPrepScript > 0)
      {
        ProgCommand.DownloadAddress3(0);
        ProgCommand.RunScript(14, 1);
      }
      int index1 = 0;
      int num3 = 0;
      for (; index1 < num1; ++index1)
      {
        uint num4 = ProgCommand.DeviceBuffers.ConfigWords[index1];
        if (index1 == (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPConfig - 1)
        {
          if (codeProtect)
            num4 &= (uint) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask;
          if (dataProtect)
            num4 &= (uint) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask;
        }
        if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
        {
          uint num5 = num4 | (uint) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index1] & ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask;
          if (!ProgCommand.FamilyIsMCP())
            num5 &= ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
          num4 = num5 << 1;
        }
        byte[] numArray1 = dataArray;
        int index2 = num3;
        int num6 = 1;
        int num7 = index2 + num6;
        int num8 = (int) (byte) (num4 & (uint) byte.MaxValue);
        numArray1[index2] = (byte) num8;
        byte[] numArray2 = dataArray;
        int index3 = num7;
        int num9 = 1;
        num3 = index3 + num9;
        int num10 = (int) (byte) (num4 >> 8 & (uint) byte.MaxValue);
        numArray2[index3] = (byte) num10;
        num2 = num2 + (uint) (byte) (num4 & (uint) byte.MaxValue) + (uint) (byte) (num4 >> 8 & (uint) byte.MaxValue);
      }
      ProgCommand.DataClrAndDownload(dataArray, 0);
      if (ProgCommand.LearnMode && ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask > 0U)
        ProgCommand.MetaCmd_WRITE_CFG_BANDGAP();
      else
        ProgCommand.RunScript(15, 1);
      ProgCommand.RunScript(1, 1);
      return num2;
    }

    public static bool ReadOSSCAL()
    {
      if (!ProgCommand.RunScript(0, 1) || !ProgCommand.DownloadAddress3((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem - 1) || (!ProgCommand.RunScript(20, 1) || !ProgCommand.UploadData()) || !ProgCommand.RunScript(1, 1))
        return false;
      ProgCommand.DeviceBuffers.OSCCAL = (uint) ProgCommand.Usb_read_array[2] + (uint) ProgCommand.Usb_read_array[3] * 256U;
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
        ProgCommand.DeviceBuffers.OSCCAL >>= 1;
      ProgCommand.DeviceBuffers.OSCCAL &= ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
      return true;
    }

    public static bool WriteOSSCAL()
    {
      if (ProgCommand.RunScript(0, 1))
      {
        uint num1 = ProgCommand.DeviceBuffers.OSCCAL;
        uint num2 = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem - 1U;
        if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
          num1 <<= 1;
        ProgCommand.DataClrAndDownload(new byte[5]
        {
          (byte) (num2 & (uint) byte.MaxValue),
          (byte) (num2 >> 8 & (uint) byte.MaxValue),
          (byte) (num2 >> 16 & (uint) byte.MaxValue),
          (byte) (num1 & (uint) byte.MaxValue),
          (byte) (num1 >> 8 & (uint) byte.MaxValue)
        }, 0);
        if (ProgCommand.RunScript(21, 1) && ProgCommand.RunScript(1, 1))
          return true;
      }
      return false;
    }

    public static Constants.PICkit2PWR CheckTargetPower(ref float vdd, ref float vpp)
    {
      if (ProgCommand.vddOn)
        return Constants.PICkit2PWR.vdd_on;
      if (ProgCommand.ReadPICkitVoltages(ref vdd, ref vpp))
      {
        if ((double) vdd > 2.29999995231628)
        {
          ProgCommand.targetSelfPowered = true;
          ProgCommand.SetVDDVoltage(vdd, 0.85f);
          return Constants.PICkit2PWR.selfpowered;
        }
        else
        {
          ProgCommand.targetSelfPowered = false;
          return Constants.PICkit2PWR.unpowered;
        }
      }
      else
      {
        ProgCommand.targetSelfPowered = false;
        return Constants.PICkit2PWR.no_response;
      }
    }

    public static int GetActiveFamily()
    {
      return (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].Family;
    }

    public static void SetActiveFamily(int family)
    {
      ProgCommand.ActivePart = 0;
      ProgCommand.lastFoundPart = 0;
      ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].Family = (ushort) family;
      ProgCommand.ResetBuffers();
    }

    public static bool SetVDDVoltage(float voltage, float threshold)
    {
      if ((double) voltage < 2.5)
        voltage = 2.5f;
      ProgCommand.vddLastSet = voltage;
      ushort num1 = ProgCommand.CalculateVddCPP(voltage);
      byte num2 = (byte) ((double) threshold * (double) voltage / 5.0 * (double) byte.MaxValue);
      if ((int) num2 > 210)
        num2 = (byte) 210;
      return ProgCommand.writeUSB(new byte[4]
      {
        (byte) 160,
        (byte) ((uint) num1 & (uint) byte.MaxValue),
        (byte) ((uint) num1 / 256U),
        num2
      });
    }

    public static ushort CalculateVddCPP(float voltage)
    {
      return (ushort) ((uint) (ushort) ((double) voltage * 32.0 + 10.5) << 6);
    }

    public static bool VddOn()
    {
      bool flag = ProgCommand.writeUSB(new byte[4]
      {
        (byte) 166,
        (byte) 2,
        (byte) 252,
        !ProgCommand.targetSelfPowered ? byte.MaxValue : (byte) 254
      });
      if (!flag)
        return flag;
      ProgCommand.vddOn = true;
      return true;
    }

    public static bool VddOff()
    {
      bool flag = ProgCommand.writeUSB(new byte[4]
      {
        (byte) 166,
        (byte) 2,
        (byte) 254,
        !ProgCommand.targetSelfPowered ? (byte) 253 : (byte) 252
      });
      if (!flag)
        return flag;
      ProgCommand.vddOn = false;
      return true;
    }

    public static bool SetProgrammingSpeed(byte speed)
    {
      return ProgCommand.writeUSB(new byte[4]
      {
        (byte) 166,
        (byte) 2,
        (byte) 234,
        speed
      });
    }

    public static bool ResetPICkit2()
    {
      return ProgCommand.writeUSB(new byte[1]
      {
        (byte) 174
      });
    }

    public static bool EnterBootloader()
    {
      return ProgCommand.writeUSB(new byte[1]
      {
        (byte) 66
      });
    }

    public static bool VerifyBootloaderMode()
    {
      return ProgCommand.writeUSB(new byte[1]
      {
        (byte) 118
      }) && ProgCommand.readUSB() && (int) ProgCommand.Usb_read_array[1] == 118;
    }

    public static bool BL_EraseFlash()
    {
      byte[] commandList = new byte[5]
      {
        (byte) 3,
        (byte) 192,
        (byte) 0,
        (byte) 32,
        (byte) 0
      };
      if (!ProgCommand.writeUSB(commandList))
        return false;
      commandList[3] = (byte) 80;
      return ProgCommand.writeUSB(commandList);
    }

    public static bool BL_WriteFlash(byte[] payload)
    {
      byte[] commandList = new byte[37];
      commandList[0] = (byte) 2;
      commandList[1] = (byte) 32;
      for (int index = 0; index < 35; ++index)
        commandList[2 + index] = payload[index];
      return ProgCommand.writeUSB(commandList);
    }

    public static bool BL_WriteFWLoadedKey()
    {
      byte[] payload = new byte[35];
      payload[0] = (byte) 224;
      payload[1] = (byte) 127;
      payload[2] = (byte) 0;
      for (int index = 3; index < payload.Length; ++index)
        payload[index] = byte.MaxValue;
      payload[payload.Length - 2] = (byte) 85;
      payload[payload.Length - 1] = (byte) 85;
      return ProgCommand.BL_WriteFlash(payload);
    }

    public static bool BL_ReadFlash16(int address)
    {
      if (ProgCommand.writeUSB(new byte[5]
      {
        (byte) 1,
        (byte) 16,
        (byte) (address & (int) byte.MaxValue),
        (byte) (address >> 8 & (int) byte.MaxValue),
        (byte) 0
      }))
        return ProgCommand.readUSB();
      else
        return false;
    }

    public static bool BL_Reset()
    {
      return ProgCommand.writeUSB(new byte[1]
      {
        byte.MaxValue
      });
    }

    public static bool ButtonPressed()
    {
      return ((int) ProgCommand.readPkStatus() & 64) == 64;
    }

    public static bool BusErrorCheck()
    {
      if (((int) ProgCommand.readPkStatus() & 1024) == 1024)
        return true;
      ProgCommand.writeUSB(new byte[3]
      {
        (byte) 166,
        (byte) 1,
        (byte) 245
      });
      return false;
    }

    public static Constants.PICkit2PWR PowerStatus()
    {
      ushort num = ProgCommand.readPkStatus();
      if ((int) num == (int) ushort.MaxValue)
        return Constants.PICkit2PWR.no_response;
      if (((int) num & 48) == 48)
      {
        ProgCommand.vddOn = false;
        return Constants.PICkit2PWR.vddvpperrors;
      }
      else if (((int) num & 32) == 32)
      {
        ProgCommand.vddOn = false;
        return Constants.PICkit2PWR.vpperror;
      }
      else if (((int) num & 16) == 16)
      {
        ProgCommand.vddOn = false;
        return Constants.PICkit2PWR.vdderror;
      }
      else if (((int) num & 2) == 2)
      {
        ProgCommand.vddOn = true;
        return Constants.PICkit2PWR.vdd_on;
      }
      else
      {
        ProgCommand.vddOn = false;
        return Constants.PICkit2PWR.vdd_off;
      }
    }

    public static void DisconnectPICkit2Unit()
    {
      if (ProgCommand.usbWriteHandle != IntPtr.Zero)
        USB.CloseHandle(ProgCommand.usbWriteHandle);
      if (ProgCommand.usbReadHandle != IntPtr.Zero)
        USB.CloseHandle(ProgCommand.usbReadHandle);
      ProgCommand.usbReadHandle = IntPtr.Zero;
      ProgCommand.usbWriteHandle = IntPtr.Zero;
    }

    public static string GetSerialUnitID()
    {
      return USB.UnitID;
    }

    public static Constants.PICkit2USB DetectPICkit2Device(ushort pk2ID, bool readFW)
    {
      IntPtr p_ReadHandle = IntPtr.Zero;
      IntPtr p_WriteHandle = IntPtr.Zero;
      ProgCommand.DisconnectPICkit2Unit();
      bool thisDevice = USB.Find_This_Device((ushort) 4660, (ushort) 51, pk2ID, ref p_ReadHandle, ref p_WriteHandle);
      ProgCommand.lastPUSBnumber = pk2ID;
      ProgCommand.usbReadHandle = p_ReadHandle;
      ProgCommand.usbWriteHandle = p_WriteHandle;
      if (thisDevice && !readFW)
        return Constants.PICkit2USB.found;
      if (!thisDevice)
        return Constants.PICkit2USB.notFound;
      if (!ProgCommand.writeUSB(new byte[1]
      {
        (byte) 118
      }))
        return Constants.PICkit2USB.writeError;
      if (!ProgCommand.readUSB())
        return Constants.PICkit2USB.readError;
      ProgCommand.FirmwareVersion = string.Format("{0:D1}.{1:D2}.{2:D2}", (object) ProgCommand.Usb_read_array[1], (object) ProgCommand.Usb_read_array[2], (object) ProgCommand.Usb_read_array[3]);
      if ((int) ProgCommand.Usb_read_array[1] == 2 && ((int) ProgCommand.Usb_read_array[2] == 32 && (int) ProgCommand.Usb_read_array[3] >= 0 || (int) ProgCommand.Usb_read_array[2] > 32))
        return Constants.PICkit2USB.found;
      if ((int) ProgCommand.Usb_read_array[1] != 118)
        return Constants.PICkit2USB.firmwareInvalid;
      ProgCommand.FirmwareVersion = string.Format("BL {0:D1}.{1:D1}", (object) ProgCommand.Usb_read_array[7], (object) ProgCommand.Usb_read_array[8]);
      return Constants.PICkit2USB.bootloader;
    }

    public static bool ReadDeviceFile(string DeviceFileName)
    {
      if (!File.Exists(DeviceFileName))
        return false;
      try
      {
        FileStream fileStream = File.OpenRead(DeviceFileName);
        using (BinaryReader binaryReader = new BinaryReader((Stream) fileStream))
        {
          ProgCommand.DevFile.Info.VersionMajor = binaryReader.ReadInt32();
          ProgCommand.DevFile.Info.VersionMinor = binaryReader.ReadInt32();
          ProgCommand.DevFile.Info.VersionDot = binaryReader.ReadInt32();
          ProgCommand.DevFile.Info.VersionNotes = binaryReader.ReadString();
          ProgCommand.DevFile.Info.NumberFamilies = binaryReader.ReadInt32();
          ProgCommand.DevFile.Info.NumberParts = binaryReader.ReadInt32();
          ProgCommand.DevFile.Info.NumberScripts = binaryReader.ReadInt32();
          ProgCommand.DevFile.Info.Compatibility = binaryReader.ReadByte();
          ProgCommand.DevFile.Info.UNUSED1A = binaryReader.ReadByte();
          ProgCommand.DevFile.Info.UNUSED1B = binaryReader.ReadUInt16();
          ProgCommand.DevFile.Info.UNUSED2 = binaryReader.ReadUInt32();
          ProgCommand.DeviceFileVersion = string.Format("{0:D1}.{1:D2}.{2:D2}", (object) ProgCommand.DevFile.Info.VersionMajor, (object) ProgCommand.DevFile.Info.VersionMinor, (object) ProgCommand.DevFile.Info.VersionDot);
          ProgCommand.DevFile.Families = new DeviceFile.DeviceFamilyParams[ProgCommand.DevFile.Info.NumberFamilies];
          ProgCommand.DevFile.PartsList = new DeviceFile.DevicePartParams[ProgCommand.DevFile.Info.NumberParts];
          ProgCommand.DevFile.Scripts = new DeviceFile.DeviceScripts[ProgCommand.DevFile.Info.NumberScripts];
          for (int index = 0; index < ProgCommand.DevFile.Info.NumberFamilies; ++index)
          {
            ProgCommand.DevFile.Families[index].FamilyID = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Families[index].FamilyType = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Families[index].SearchPriority = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Families[index].FamilyName = binaryReader.ReadString();
            ProgCommand.DevFile.Families[index].ProgEntryScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Families[index].ProgExitScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Families[index].ReadDevIDScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Families[index].DeviceIDMask = binaryReader.ReadUInt32();
            ProgCommand.DevFile.Families[index].BlankValue = binaryReader.ReadUInt32();
            ProgCommand.DevFile.Families[index].BytesPerLocation = binaryReader.ReadByte();
            ProgCommand.DevFile.Families[index].AddressIncrement = binaryReader.ReadByte();
            ProgCommand.DevFile.Families[index].PartDetect = binaryReader.ReadBoolean();
            ProgCommand.DevFile.Families[index].ProgEntryVPPScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Families[index].UNUSED1 = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Families[index].EEMemBytesPerWord = binaryReader.ReadByte();
            ProgCommand.DevFile.Families[index].EEMemAddressIncrement = binaryReader.ReadByte();
            ProgCommand.DevFile.Families[index].UserIDHexBytes = binaryReader.ReadByte();
            ProgCommand.DevFile.Families[index].UserIDBytes = binaryReader.ReadByte();
            ProgCommand.DevFile.Families[index].ProgMemHexBytes = binaryReader.ReadByte();
            ProgCommand.DevFile.Families[index].EEMemHexBytes = binaryReader.ReadByte();
            ProgCommand.DevFile.Families[index].ProgMemShift = binaryReader.ReadByte();
            ProgCommand.DevFile.Families[index].TestMemoryStart = binaryReader.ReadUInt32();
            ProgCommand.DevFile.Families[index].TestMemoryLength = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Families[index].Vpp = binaryReader.ReadSingle();
          }
          ProgCommand.familySearchTable = new int[ProgCommand.DevFile.Info.NumberFamilies];
          for (int index = 0; index < ProgCommand.DevFile.Info.NumberFamilies; ++index)
            ProgCommand.familySearchTable[(int) ProgCommand.DevFile.Families[index].SearchPriority] = index;
          for (int index1 = 0; index1 < ProgCommand.DevFile.Info.NumberParts; ++index1)
          {
            ProgCommand.DevFile.PartsList[index1].PartName = binaryReader.ReadString();
            ProgCommand.DevFile.PartsList[index1].Family = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DeviceID = binaryReader.ReadUInt32();
            ProgCommand.DevFile.PartsList[index1].ProgramMem = binaryReader.ReadUInt32();
            ProgCommand.DevFile.PartsList[index1].EEMem = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].EEAddr = binaryReader.ReadUInt32();
            ProgCommand.DevFile.PartsList[index1].ConfigWords = binaryReader.ReadByte();
            ProgCommand.DevFile.PartsList[index1].ConfigAddr = binaryReader.ReadUInt32();
            ProgCommand.DevFile.PartsList[index1].UserIDWords = binaryReader.ReadByte();
            ProgCommand.DevFile.PartsList[index1].UserIDAddr = binaryReader.ReadUInt32();
            ProgCommand.DevFile.PartsList[index1].BandGapMask = binaryReader.ReadUInt32();
            ProgCommand.DevFile.PartsList[index1].ConfigMasks = new ushort[8];
            ProgCommand.DevFile.PartsList[index1].ConfigBlank = new ushort[8];
            for (int index2 = 0; index2 < 8; ++index2)
              ProgCommand.DevFile.PartsList[index1].ConfigMasks[index2] = binaryReader.ReadUInt16();
            for (int index2 = 0; index2 < 8; ++index2)
              ProgCommand.DevFile.PartsList[index1].ConfigBlank[index2] = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].CPMask = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].CPConfig = binaryReader.ReadByte();
            ProgCommand.DevFile.PartsList[index1].OSSCALSave = binaryReader.ReadBoolean();
            ProgCommand.DevFile.PartsList[index1].IgnoreAddress = binaryReader.ReadUInt32();
            ProgCommand.DevFile.PartsList[index1].VddMin = binaryReader.ReadSingle();
            ProgCommand.DevFile.PartsList[index1].VddMax = binaryReader.ReadSingle();
            ProgCommand.DevFile.PartsList[index1].VddErase = binaryReader.ReadSingle();
            ProgCommand.DevFile.PartsList[index1].CalibrationWords = binaryReader.ReadByte();
            ProgCommand.DevFile.PartsList[index1].ChipEraseScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ProgMemAddrSetScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ProgMemAddrBytes = binaryReader.ReadByte();
            ProgCommand.DevFile.PartsList[index1].ProgMemRdScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ProgMemRdWords = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].EERdPrepScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].EERdScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].EERdLocations = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].UserIDRdPrepScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].UserIDRdScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ConfigRdPrepScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ConfigRdScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ProgMemWrPrepScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ProgMemWrScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ProgMemWrWords = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ProgMemPanelBufs = binaryReader.ReadByte();
            ProgCommand.DevFile.PartsList[index1].ProgMemPanelOffset = binaryReader.ReadUInt32();
            ProgCommand.DevFile.PartsList[index1].EEWrPrepScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].EEWrScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].EEWrLocations = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].UserIDWrPrepScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].UserIDWrScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ConfigWrPrepScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ConfigWrScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].OSCCALRdScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].OSCCALWrScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DPMask = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].WriteCfgOnErase = binaryReader.ReadBoolean();
            ProgCommand.DevFile.PartsList[index1].BlankCheckSkipUsrIDs = binaryReader.ReadBoolean();
            ProgCommand.DevFile.PartsList[index1].IgnoreBytes = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ChipErasePrepScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].BootFlash = binaryReader.ReadUInt32();
            ProgCommand.DevFile.PartsList[index1].UNUSED4 = binaryReader.ReadUInt32();
            ProgCommand.DevFile.PartsList[index1].ProgMemEraseScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].EEMemEraseScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ConfigMemEraseScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].reserved1EraseScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].reserved2EraseScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].TestMemoryRdScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].TestMemoryRdWords = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].EERowEraseScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].EERowEraseWords = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].ExportToMPLAB = binaryReader.ReadBoolean();
            ProgCommand.DevFile.PartsList[index1].DebugHaltScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugRunScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugStatusScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugReadExecVerScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugSingleStepScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugBulkWrDataScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugBulkRdDataScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugWriteVectorScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugReadVectorScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugRowEraseScript = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugRowEraseSize = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugReserved5Script = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugReserved6Script = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugReserved7Script = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugReserved8Script = binaryReader.ReadUInt16();
            ProgCommand.DevFile.PartsList[index1].DebugReserved9Script = binaryReader.ReadUInt16();
          }
          for (int index1 = 0; index1 < ProgCommand.DevFile.Info.NumberScripts; ++index1)
          {
            ProgCommand.DevFile.Scripts[index1].ScriptNumber = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Scripts[index1].ScriptName = binaryReader.ReadString();
            ProgCommand.DevFile.Scripts[index1].ScriptVersion = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Scripts[index1].UNUSED1 = binaryReader.ReadUInt32();
            ProgCommand.DevFile.Scripts[index1].ScriptLength = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Scripts[index1].Script = new ushort[(int) ProgCommand.DevFile.Scripts[index1].ScriptLength];
            for (int index2 = 0; index2 < (int) ProgCommand.DevFile.Scripts[index1].ScriptLength; ++index2)
              ProgCommand.DevFile.Scripts[index1].Script[index2] = binaryReader.ReadUInt16();
            ProgCommand.DevFile.Scripts[index1].Comment = binaryReader.ReadString();
          }
          binaryReader.Close();
        }
        fileStream.Close();
      }
      catch
      {
        return false;
      }
      return true;
    }

    public static bool DetectDevice(int familyIndex, bool resetOnNotFound, bool keepVddOn)
    {
      if (familyIndex == 16777215)
      {
        if (!ProgCommand.targetSelfPowered)
          ProgCommand.SetVDDVoltage(3.3f, 0.85f);
        for (int index = 0; index < ProgCommand.DevFile.Families.Length; ++index)
        {
          if (ProgCommand.DevFile.Families[ProgCommand.familySearchTable[index]].PartDetect && ProgCommand.searchDevice(ProgCommand.familySearchTable[index], true, keepVddOn))
            return true;
        }
        return false;
      }
      else
      {
        ProgCommand.SetVDDVoltage(ProgCommand.vddLastSet, 0.85f);
        return !ProgCommand.DevFile.Families[familyIndex].PartDetect || ProgCommand.searchDevice(familyIndex, resetOnNotFound, keepVddOn);
      }
    }

    public static int FindLastUsedInBuffer(uint[] bufferToSearch, uint blankValue, int startIndex)
    {
      if (!(ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName != "KEELOQ® HCS"))
        return bufferToSearch.Length - 1;
      for (int index = startIndex; index > 0; --index)
      {
        if ((int) bufferToSearch[index] != (int) blankValue)
          return index;
      }
      return 0;
    }

    public static bool RunScriptUploadNoLen(int script, int repetitions)
    {
      bool flag = ProgCommand.writeUSB(new byte[5]
      {
        (byte) 169,
        (byte) 165,
        ProgCommand.scriptRedirectTable[script].redirectToScriptLocation,
        (byte) repetitions,
        (byte) 172
      });
      if (flag)
        flag = ProgCommand.readUSB();
      return flag;
    }

    public static bool RunScriptUploadNoLen2(int script, int repetitions)
    {
      bool flag = ProgCommand.writeUSB(new byte[6]
      {
        (byte) 169,
        (byte) 165,
        ProgCommand.scriptRedirectTable[script].redirectToScriptLocation,
        (byte) repetitions,
        (byte) 172,
        (byte) 172
      });
      if (flag)
        flag = ProgCommand.readUSB();
      return flag;
    }

    public static bool GetUpload()
    {
      return ProgCommand.readUSB();
    }

    public static bool UploadData()
    {
      bool flag = ProgCommand.writeUSB(new byte[1]
      {
        (byte) 170
      });
      if (flag)
        flag = ProgCommand.readUSB();
      return flag;
    }

    public static bool UploadDataNoLen()
    {
      bool flag = ProgCommand.writeUSB(new byte[1]
      {
        (byte) 172
      });
      if (flag)
        flag = ProgCommand.readUSB();
      return flag;
    }

    public static bool RunScript(int script, int repetitions)
    {
      if (!ProgCommand.writeUSB(new byte[4]
      {
        (byte) 169,
        (byte) 165,
        ProgCommand.scriptRedirectTable[script].redirectToScriptLocation,
        (byte) repetitions
      }))
        return false;
      if (script == 1 && !ProgCommand.assertMCLR)
        return ProgCommand.HoldMCLR(false);
      else
        return true;
    }

    public static int DataClrAndDownload(byte[] dataArray, int startIndex)
    {
      if (startIndex >= dataArray.Length)
        return 0;
      int num = dataArray.Length - startIndex;
      if (num > 61)
        num = 61;
      byte[] commandList = new byte[3 + num];
      commandList[0] = (byte) 167;
      commandList[1] = (byte) 168;
      commandList[2] = (byte) (num & (int) byte.MaxValue);
      for (int index = 0; index < num; ++index)
        commandList[3 + index] = dataArray[startIndex + index];
      if (ProgCommand.writeUSB(commandList))
        return startIndex + num;
      else
        return 0;
    }

    public static int DataDownload(byte[] dataArray, int startIndex, int lastIndex)
    {
      if (startIndex >= lastIndex)
        return 0;
      int num = lastIndex - startIndex;
      if (num > 62)
        num = 62;
      byte[] commandList = new byte[2 + num];
      commandList[0] = (byte) 168;
      commandList[1] = (byte) (num & (int) byte.MaxValue);
      for (int index = 0; index < num; ++index)
        commandList[2 + index] = dataArray[startIndex + index];
      if (ProgCommand.writeUSB(commandList))
        return startIndex + num;
      else
        return 0;
    }

    public static bool DownloadAddress3(int address)
    {
      return ProgCommand.writeUSB(new byte[6]
      {
        (byte) 167,
        (byte) 168,
        (byte) 3,
        (byte) (address & (int) byte.MaxValue),
        (byte) ((int) byte.MaxValue & address >> 8),
        (byte) ((int) byte.MaxValue & address >> 16)
      });
    }

    public static bool DownloadAddress3MSBFirst(int address)
    {
      return ProgCommand.writeUSB(new byte[6]
      {
        (byte) 167,
        (byte) 168,
        (byte) 3,
        (byte) ((int) byte.MaxValue & address >> 16),
        (byte) ((int) byte.MaxValue & address >> 8),
        (byte) (address & (int) byte.MaxValue)
      });
    }

    public static bool Download3Multiples(int downloadBytes, int multiples, int increment)
    {
      byte num1 = (byte) 167;
      do
      {
        int num2 = multiples;
        if (multiples > 20)
        {
          num2 = 20;
          multiples -= 20;
        }
        else
          multiples = 0;
        byte[] commandList = new byte[3 * num2 + 3];
        commandList[0] = num1;
        commandList[1] = (byte) 168;
        commandList[2] = (byte) (3 * num2);
        for (int index = 0; index < num2; ++index)
        {
          commandList[3 + 3 * index] = (byte) (downloadBytes >> 16);
          commandList[4 + 3 * index] = (byte) (downloadBytes >> 8);
          commandList[5 + 3 * index] = (byte) downloadBytes;
          downloadBytes += increment;
        }
        if (!ProgCommand.writeUSB(commandList))
          return false;
        num1 = (byte) 90;
      }
      while (multiples > 0);
      return true;
    }

    public static uint ComputeChecksum(bool codeProtectOn)
    {
      uint num1 = 0U;
      if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue < (uint) ushort.MaxValue)
      {
        int num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem;
        if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave)
          --num2;
        for (int index = 0; index < num2; ++index)
          num1 += ProgCommand.DeviceBuffers.ProgramMemory[index];
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords > 0)
        {
          if (((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask & (int) ProgCommand.DeviceBuffers.ConfigWords[(int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPConfig - 1]) != (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask)
          {
            num1 = 0U;
            for (int index1 = 0; index1 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords; ++index1)
            {
              int num3 = 1;
              for (int index2 = 0; index2 < index1; ++index2)
                num3 <<= 4;
              num1 += (uint) ((ulong) (15U & ProgCommand.DeviceBuffers.UserIDs[(int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords - index1 - 1]) * (ulong) num3);
            }
          }
          for (int index = 0; index < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords; ++index)
            num1 += ProgCommand.DeviceBuffers.ConfigWords[index] & (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index];
        }
        return num1 & (uint) ushort.MaxValue;
      }
      else
      {
        int num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
        if ((long) num2 > (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem)
          num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem;
        for (int index1 = 0; index1 < num2; ++index1)
        {
          uint num3 = ProgCommand.DeviceBuffers.ProgramMemory[index1];
          num1 += num3 & (uint) byte.MaxValue;
          for (int index2 = 1; index2 < (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation; ++index2)
          {
            num3 >>= 8;
            num1 += num3 & (uint) byte.MaxValue;
          }
        }
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords > 0)
        {
          if (((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask & (int) ProgCommand.DeviceBuffers.ConfigWords[(int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPConfig - 1]) != (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask)
          {
            num1 = 0U;
            for (int index = 0; index < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords; ++index)
            {
              uint num3 = ProgCommand.DeviceBuffers.UserIDs[index];
              num1 = num1 + (num3 & (uint) byte.MaxValue) + (num3 >> 8 & (uint) byte.MaxValue);
            }
          }
          for (int index = 0; index < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords; ++index)
          {
            uint num3 = ProgCommand.DeviceBuffers.ConfigWords[index] & (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index];
            num1 = num1 + (num3 & (uint) byte.MaxValue) + (num3 >> 8 & (uint) byte.MaxValue);
          }
        }
        return num1 & (uint) ushort.MaxValue;
      }
    }

    public static void ResetBuffers()
    {
      ProgCommand.DeviceBuffers = new DeviceData(ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords, ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue, (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemAddressIncrement, (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].UserIDBytes, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank, (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[7]);
    }

    public static DeviceData CloneBuffers(DeviceData copyFrom)
    {
      DeviceData deviceData = new DeviceData(ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords, ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue, (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemAddressIncrement, (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].UserIDBytes, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank, (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[7]);
      for (int index = 0; index < copyFrom.ProgramMemory.Length; ++index)
        deviceData.ProgramMemory[index] = copyFrom.ProgramMemory[index];
      for (int index = 0; index < copyFrom.EEPromMemory.Length; ++index)
        deviceData.EEPromMemory[index] = copyFrom.EEPromMemory[index];
      for (int index = 0; index < copyFrom.ConfigWords.Length; ++index)
        deviceData.ConfigWords[index] = copyFrom.ConfigWords[index];
      for (int index = 0; index < copyFrom.UserIDs.Length; ++index)
        deviceData.UserIDs[index] = copyFrom.UserIDs[index];
      deviceData.OSCCAL = copyFrom.OSCCAL;
      deviceData.OSCCAL = copyFrom.BandGap;
      return deviceData;
    }

    public static void PrepNewPart()
    {
      ProgCommand.ResetBuffers();
      float voltage = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].Vpp;
      if ((double) voltage < 1.0)
        ProgCommand.SetVppVoltage(ProgCommand.vddLastSet, 0.7f);
      else
        ProgCommand.SetVppVoltage(voltage, 0.7f);
      ProgCommand.downloadPartScripts(ProgCommand.GetActiveFamily());
    }

    public static uint ReadDebugVector()
    {
      ProgCommand.RunScript(0, 1);
      ProgCommand.ExecuteScript((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugReadVectorScript);
      ProgCommand.UploadData();
      ProgCommand.RunScript(1, 1);
      int num1 = 2;
      int num2 = 2;
      uint num3 = 0U;
      for (int index1 = 0; index1 < num1; ++index1)
      {
        byte[] numArray1 = ProgCommand.Usb_read_array;
        int index2 = num2;
        int num4 = 1;
        int num5 = index2 + num4;
        int num6 = (int) numArray1[index2];
        byte[] numArray2 = ProgCommand.Usb_read_array;
        int index3 = num5;
        int num7 = 1;
        num2 = index3 + num7;
        int num8 = (int) numArray2[index3] << 8;
        uint num9 = (uint) (num6 | num8);
        if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
          num9 = num9 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
        if (index1 == 0)
          num3 = num9;
        else
          num3 += num9 << 16;
      }
      return num3;
    }

    public static void WriteDebugVector(uint debugWords)
    {
      int num1 = 2;
      byte[] dataArray = new byte[4];
      ProgCommand.RunScript(0, 1);
      int num2 = 0;
      int num3 = 0;
      for (; num2 < num1; ++num2)
      {
        uint num4 = num2 != 0 ? debugWords >> 16 : debugWords & (uint) ushort.MaxValue;
        if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
          num4 <<= 1;
        byte[] numArray1 = dataArray;
        int index1 = num3;
        int num5 = 1;
        int num6 = index1 + num5;
        int num7 = (int) (byte) (num4 & (uint) byte.MaxValue);
        numArray1[index1] = (byte) num7;
        byte[] numArray2 = dataArray;
        int index2 = num6;
        int num8 = 1;
        num3 = index2 + num8;
        int num9 = (int) (byte) (num4 >> 8 & (uint) byte.MaxValue);
        numArray2[index2] = (byte) num9;
      }
      ProgCommand.DataClrAndDownload(dataArray, 0);
      ProgCommand.ExecuteScript((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugWriteVectorScript);
      ProgCommand.RunScript(1, 1);
    }

    public static bool ReadPICkitVoltages(ref float vdd, ref float vpp)
    {
      if (!ProgCommand.writeUSB(new byte[1]
      {
        (byte) 163
      }) || !ProgCommand.readUSB())
        return false;
      float num1 = (float) ((int) ProgCommand.Usb_read_array[2] * 256 + (int) ProgCommand.Usb_read_array[1]);
      vdd = (float) ((double) num1 / 65536.0 * 5.0);
      float num2 = (float) ((int) ProgCommand.Usb_read_array[4] * 256 + (int) ProgCommand.Usb_read_array[3]);
      vpp = (float) ((double) num2 / 65536.0 * 13.6999998092651);
      return true;
    }

    public static bool SetVppVoltage(float voltage, float threshold)
    {
      return ProgCommand.writeUSB(new byte[4]
      {
        (byte) 161,
        (byte) 64,
        (byte) ((double) voltage * 18.6100006103516),
        (byte) ((double) threshold * (double) voltage * 18.6100006103516)
      });
    }

    public static bool SendScript(byte[] script)
    {
      int length = script.Length;
      byte[] commandList = new byte[2 + length];
      commandList[0] = (byte) 166;
      commandList[1] = (byte) length;
      for (int index = 0; index < length; ++index)
        commandList[2 + index] = script[index];
      return ProgCommand.writeUSB(commandList);
    }

    private static ushort readPkStatus()
    {
      if (ProgCommand.writeUSB(new byte[1]
      {
        (byte) 162
      }) && ProgCommand.readUSB())
        return (ushort) ((uint) ProgCommand.Usb_read_array[2] * 256U + (uint) ProgCommand.Usb_read_array[1]);
      else
        return ushort.MaxValue;
    }

    public static bool writeUSB(byte[] commandList)
    {
      int numBytesWritten = 0;
      ProgCommand.Usb_write_array[0] = (byte) 0;
      for (int index = 1; index < ProgCommand.Usb_write_array.Length; ++index)
        ProgCommand.Usb_write_array[index] = (byte) 173;
      Array.Copy((Array) commandList, 0, (Array) ProgCommand.Usb_write_array, 1, commandList.Length);
      bool flag = USB.WriteFile(ProgCommand.usbWriteHandle, ProgCommand.Usb_write_array, ProgCommand.Usb_write_array.Length, ref numBytesWritten, 0);
      if (numBytesWritten != ProgCommand.Usb_write_array.Length)
        return false;
      else
        return flag;
    }

    public static bool readUSB()
    {
      int pNumberOfBytesRead = 0;
      if (ProgCommand.LearnMode)
        return true;
      bool flag = USB.ReadFile(ProgCommand.usbReadHandle, ProgCommand.Usb_read_array, ProgCommand.Usb_read_array.Length, ref pNumberOfBytesRead, 0);
      if (pNumberOfBytesRead != ProgCommand.Usb_read_array.Length)
        return false;
      else
        return flag;
    }

    private static bool searchDevice(int familyIndex, bool resetOnNoDevice, bool keepVddOn)
    {
      int index1 = ProgCommand.ActivePart;
      if (ProgCommand.ActivePart != 0)
        ProgCommand.lastFoundPart = ProgCommand.ActivePart;
      float voltage = ProgCommand.DevFile.Families[familyIndex].Vpp;
      if ((double) voltage < 1.0)
        ProgCommand.SetVppVoltage(ProgCommand.vddLastSet, 0.7f);
      else
        ProgCommand.SetVppVoltage(voltage, 0.7f);
      ProgCommand.SetMCLRTemp(true);
      ProgCommand.VddOn();
      if (ProgCommand.vppFirstEnabled && (int) ProgCommand.DevFile.Families[familyIndex].ProgEntryVPPScript > 0)
        ProgCommand.ExecuteScript((int) ProgCommand.DevFile.Families[familyIndex].ProgEntryVPPScript);
      else
        ProgCommand.ExecuteScript((int) ProgCommand.DevFile.Families[familyIndex].ProgEntryScript);
      ProgCommand.ExecuteScript((int) ProgCommand.DevFile.Families[familyIndex].ReadDevIDScript);
      ProgCommand.UploadData();
      ProgCommand.ExecuteScript((int) ProgCommand.DevFile.Families[familyIndex].ProgExitScript);
      if (!keepVddOn)
        ProgCommand.VddOff();
      if (!ProgCommand.assertMCLR)
        ProgCommand.HoldMCLR(false);
      uint num1 = (uint) ((int) ProgCommand.Usb_read_array[5] * 16777216 + (int) ProgCommand.Usb_read_array[4] * 65536 + (int) ProgCommand.Usb_read_array[3] * 256) + (uint) ProgCommand.Usb_read_array[2];
      for (int index2 = 0; index2 < (int) ProgCommand.DevFile.Families[familyIndex].ProgMemShift; ++index2)
        num1 >>= 1;
      if ((int) ProgCommand.Usb_read_array[1] == 4)
      {
        ProgCommand.LastDeviceRev = (int) ProgCommand.Usb_read_array[5] * 256 + (int) ProgCommand.Usb_read_array[4];
        if ((int) ProgCommand.DevFile.Families[familyIndex].BlankValue == -1)
          ProgCommand.LastDeviceRev >>= 4;
      }
      else
        ProgCommand.LastDeviceRev = (int) num1 & ~(int) ProgCommand.DevFile.Families[familyIndex].DeviceIDMask;
      uint num2 = num1 & ProgCommand.DevFile.Families[familyIndex].DeviceIDMask;
      ProgCommand.LastDeviceID = num2;
      ProgCommand.ActivePart = 0;
      for (int index2 = 0; index2 < ProgCommand.DevFile.PartsList.Length; ++index2)
      {
        if ((int) ProgCommand.DevFile.PartsList[index2].Family == familyIndex && (int) ProgCommand.DevFile.PartsList[index2].DeviceID == (int) num2)
        {
          ProgCommand.ActivePart = index2;
          break;
        }
      }
      if (ProgCommand.ActivePart == 0)
      {
        if (index1 != 0)
        {
          ProgCommand.DevFile.PartsList[ProgCommand.ActivePart] = ProgCommand.DevFile.PartsList[index1];
          ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DeviceID = 0U;
          ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].PartName = "No Soportado!";
        }
        if (resetOnNoDevice)
          ProgCommand.ResetBuffers();
        return false;
      }
      else
      {
        if (ProgCommand.ActivePart == ProgCommand.lastFoundPart && (int) ProgCommand.scriptBufferChecksum != 0 && (int) ProgCommand.scriptBufferChecksum == (int) ProgCommand.getScriptBufferChecksum())
          return true;
        ProgCommand.downloadPartScripts(familyIndex);
        if (ProgCommand.ActivePart != ProgCommand.lastFoundPart)
          ProgCommand.ResetBuffers();
        if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave)
        {
          ProgCommand.VddOn();
          ProgCommand.ReadOSSCAL();
        }
        if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask > 0U)
        {
          ProgCommand.VddOn();
          ProgCommand.ReadBandGap();
        }
        if (!keepVddOn)
          ProgCommand.VddOff();
        return true;
      }
    }

    private static void downloadPartScripts(int familyIndex)
    {
      ProgCommand.writeUSB(new byte[1]
      {
        (byte) 171
      });
      for (int index = 0; index < ProgCommand.scriptRedirectTable.Length; ++index)
      {
        ProgCommand.scriptRedirectTable[index].redirectToScriptLocation = (byte) 0;
        ProgCommand.scriptRedirectTable[index].deviceFileScriptNumber = 0;
      }
      if ((int) ProgCommand.DevFile.Families[familyIndex].ProgEntryScript != 0)
      {
        if (ProgCommand.vppFirstEnabled && (int) ProgCommand.DevFile.Families[familyIndex].ProgEntryVPPScript != 0)
          ProgCommand.downloadScript((byte) 0, (int) ProgCommand.DevFile.Families[familyIndex].ProgEntryVPPScript);
        else
          ProgCommand.downloadScript((byte) 0, (int) ProgCommand.DevFile.Families[familyIndex].ProgEntryScript);
      }
      if ((int) ProgCommand.DevFile.Families[familyIndex].ProgExitScript != 0)
        ProgCommand.downloadScript((byte) 1, (int) ProgCommand.DevFile.Families[familyIndex].ProgExitScript);
      if ((int) ProgCommand.DevFile.Families[familyIndex].ReadDevIDScript != 0)
        ProgCommand.downloadScript((byte) 2, (int) ProgCommand.DevFile.Families[familyIndex].ReadDevIDScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdScript != 0)
        ProgCommand.downloadScript((byte) 3, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ChipErasePrepScript != 0)
        ProgCommand.downloadScript((byte) 4, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ChipErasePrepScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrSetScript != 0)
        ProgCommand.downloadScript((byte) 5, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrSetScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrPrepScript != 0)
        ProgCommand.downloadScript((byte) 6, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrPrepScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrScript != 0)
        ProgCommand.downloadScript((byte) 7, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdPrepScript != 0)
        ProgCommand.downloadScript((byte) 8, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdPrepScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdScript != 0)
        ProgCommand.downloadScript((byte) 9, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEWrPrepScript != 0)
        ProgCommand.downloadScript((byte) 10, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEWrPrepScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEWrScript != 0)
        ProgCommand.downloadScript((byte) 11, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEWrScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigRdPrepScript != 0)
        ProgCommand.downloadScript((byte) 12, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigRdPrepScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigRdScript != 0)
        ProgCommand.downloadScript((byte) 13, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigRdScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWrPrepScript != 0)
        ProgCommand.downloadScript((byte) 14, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWrPrepScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWrScript != 0)
        ProgCommand.downloadScript((byte) 15, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWrScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDRdPrepScript != 0)
        ProgCommand.downloadScript((byte) 16, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDRdPrepScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDRdScript != 0)
        ProgCommand.downloadScript((byte) 17, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDRdScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWrPrepScript != 0)
        ProgCommand.downloadScript((byte) 18, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWrPrepScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWrScript != 0)
        ProgCommand.downloadScript((byte) 19, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWrScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSCCALRdScript != 0)
        ProgCommand.downloadScript((byte) 20, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSCCALRdScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSCCALWrScript != 0)
        ProgCommand.downloadScript((byte) 21, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSCCALWrScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ChipEraseScript != 0)
        ProgCommand.downloadScript((byte) 22, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ChipEraseScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemEraseScript != 0)
        ProgCommand.downloadScript((byte) 23, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemEraseScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMemEraseScript != 0)
        ProgCommand.downloadScript((byte) 24, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMemEraseScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseScript != 0)
        ProgCommand.downloadScript((byte) 26, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].TestMemoryRdScript != 0)
        ProgCommand.downloadScript((byte) 27, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].TestMemoryRdScript);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERowEraseScript != 0)
        ProgCommand.downloadScript((byte) 28, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERowEraseScript);
      ProgCommand.scriptBufferChecksum = ProgCommand.getScriptBufferChecksum();
    }

    private static uint getScriptBufferChecksum()
    {
      if (ProgCommand.LearnMode)
        return 0U;
      if (ProgCommand.writeUSB(new byte[1]
      {
        (byte) 175
      }) && ProgCommand.readUSB())
        return (uint) ProgCommand.Usb_read_array[4] + ((uint) ProgCommand.Usb_read_array[3] << 8) + ((uint) ProgCommand.Usb_read_array[2] << 16) + ((uint) ProgCommand.Usb_read_array[1] << 24);
      else
        return 0U;
    }

    private static bool downloadScript(byte scriptBufferLocation, int scriptArrayIndex)
    {
      byte num1 = scriptBufferLocation;
      for (byte index = (byte) 0; (int) index < ProgCommand.scriptRedirectTable.Length; ++index)
      {
        if (scriptArrayIndex == ProgCommand.scriptRedirectTable[(int) index].deviceFileScriptNumber)
        {
          num1 = index;
          break;
        }
      }
      ProgCommand.scriptRedirectTable[(int) scriptBufferLocation].redirectToScriptLocation = num1;
      ProgCommand.scriptRedirectTable[(int) scriptBufferLocation].deviceFileScriptNumber = scriptArrayIndex;
      if ((int) scriptBufferLocation != (int) num1)
        return true;
      int num2 = (int) ProgCommand.DevFile.Scripts[--scriptArrayIndex].ScriptLength;
      byte[] commandList = new byte[3 + num2];
      commandList[0] = (byte) 164;
      commandList[1] = scriptBufferLocation;
      commandList[2] = (byte) num2;
      for (int index = 0; index < num2; ++index)
      {
        ushort num3 = ProgCommand.DevFile.Scripts[scriptArrayIndex].Script[index];
        if (ProgCommand.fastProgramming)
          commandList[3 + index] = (byte) num3;
        else if ((int) num3 == 43751)
        {
          ushort num4 = (ushort) ((uint) ProgCommand.DevFile.Scripts[scriptArrayIndex].Script[index + 1] & (uint) byte.MaxValue);
          if ((int) num4 < 170 && (int) num4 != 0)
          {
            commandList[3 + index++] = (byte) num3;
            byte num5 = (byte) ProgCommand.DevFile.Scripts[scriptArrayIndex].Script[index];
            commandList[3 + index] = (byte) ((uint) num5 + (uint) num5 / 2U);
          }
          else
          {
            commandList[3 + index++] = (byte) 232;
            commandList[3 + index] = (byte) 2;
          }
        }
        else if ((int) num3 == 43752)
        {
          ushort num4 = (ushort) ((uint) ProgCommand.DevFile.Scripts[scriptArrayIndex].Script[index + 1] & (uint) byte.MaxValue);
          if ((int) num4 < 171 && (int) num4 != 0)
          {
            commandList[3 + index++] = (byte) num3;
            byte num5 = (byte) ProgCommand.DevFile.Scripts[scriptArrayIndex].Script[index];
            commandList[3 + index] = (byte) ((uint) num5 + (uint) num5 / 2U);
          }
          else
          {
            commandList[3 + index++] = (byte) 232;
            commandList[3 + index] = (byte) 0;
          }
        }
        else
          commandList[3 + index] = (byte) num3;
      }
      return ProgCommand.writeUSB(commandList);
    }

    private struct scriptRedirect
    {
      public byte redirectToScriptLocation;
      public int deviceFileScriptNumber;
    }
  }
}
