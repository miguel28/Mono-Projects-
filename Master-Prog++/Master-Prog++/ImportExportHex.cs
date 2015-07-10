// Type: SysProgUSB.ImportExportHex
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.Globalization;
using System.IO;

namespace SysProgUSB
{
  internal class ImportExportHex
  {
    public static DateTime LastWriteTime = new DateTime();

    static ImportExportHex()
    {
    }

    public static Constants.FileRead ImportHexFile(string filePath, bool progMem, bool eeMem)
    {
      try
      {
        FileInfo fileInfo = new FileInfo(filePath);
        ImportExportHex.LastWriteTime = fileInfo.LastWriteTime;
        TextReader textReader = (TextReader) fileInfo.OpenText();
        int num1 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
        int num2 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemHexBytes;
        uint num3 = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEAddr;
        int num4 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem * num1;
        int num5 = 0;
        bool flag1 = false;
        bool flag2 = true;
        bool flag3 = false;
        int num6 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords;
        uint num7 = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDAddr;
        if ((int) num7 == 0)
          num7 = uint.MaxValue;
        int num8 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].UserIDHexBytes;
        int length = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
        bool[] flagArray = new bool[length];
        for (int index = 0; index < length; ++index)
        {
          ProgCommand.DeviceBuffers.ConfigWords[index] = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
          flagArray[index] = false;
        }
        int num9 = num1;
        uint num10 = 0U;
        uint num11 = 0U;
        uint num12 = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BootFlash;
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
        {
          num10 = 486539264U;
          num11 = 532676608U;
          num4 = num4 - (int) num12 * num1 + (int) num10;
          num9 = 2;
        }
        uint num13 = num11 + num12 * (uint) num1;
        int num14 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem - (int) num12;
        for (string str = textReader.ReadLine(); str != null; str = textReader.ReadLine())
        {
          if ((int) str[0] == 58 && str.Length >= 11)
          {
            int num15 = int.Parse(str.Substring(1, 2), NumberStyles.HexNumber);
            int num16 = num5 + int.Parse(str.Substring(3, 4), NumberStyles.HexNumber);
            int num17 = int.Parse(str.Substring(7, 2), NumberStyles.HexNumber);
            if (num17 == 0)
            {
              if (str.Length >= 11 + 2 * num15)
              {
                for (int index1 = 0; index1 < num15; ++index1)
                {
                  int num18 = num16 + index1;
                  int index2 = (num18 - (int) num10) / num1;
                  int num19 = num18 % num1;
                  uint num20 = 4294967040U | uint.Parse(str.Substring(9 + 2 * index1, 2), NumberStyles.HexNumber);
                  for (int index3 = 0; index3 < num19; ++index3)
                    num20 = num20 << 8 | (uint) byte.MaxValue;
                  flag2 = true;
                  if ((long) num18 >= (long) num10 && num18 < num4)
                  {
                    if (progMem)
                      ProgCommand.DeviceBuffers.ProgramMemory[index2] &= num20;
                    flag2 = false;
                  }
                  if (num12 > 0U && (long) num18 >= (long) num11 && (long) num18 < (long) num13)
                  {
                    index2 = (int) ((long) num14 + ((long) num18 - (long) num11) / (long) num1);
                    if (progMem)
                      ProgCommand.DeviceBuffers.ProgramMemory[index2] &= num20;
                    flag2 = false;
                  }
                  if ((long) num18 >= (long) num3 && num3 > 0U && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
                  {
                    int index3 = (int) ((long) num18 - (long) num3) / num2;
                    if (index3 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem)
                    {
                      flag2 = false;
                      if (eeMem)
                      {
                        if (num2 == num1)
                        {
                          ProgCommand.DeviceBuffers.EEPromMemory[index3] &= num20;
                        }
                        else
                        {
                          int num21 = num19 / num2 * num2;
                          for (int index4 = 0; index4 < num21; ++index4)
                            num20 >>= 8;
                          ProgCommand.DeviceBuffers.EEPromMemory[index3] &= num20;
                        }
                      }
                    }
                  }
                  else if ((long) num18 >= (long) num3 && num3 > 0U && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem == 0)
                    flag2 = false;
                  if ((long) num18 >= (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr && length > 0)
                  {
                    int index3 = (num18 - (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr) / num9;
                    if (num9 != num1 && num19 > 1)
                      num20 = num20 >> 16 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
                    if (index3 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords)
                    {
                      flag2 = false;
                      flag1 = true;
                      flagArray[index3] = true;
                      if (progMem)
                      {
                        ProgCommand.DeviceBuffers.ConfigWords[index3] &= num20 & (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index3];
                        if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue == 4095)
                          ProgCommand.DeviceBuffers.ConfigWords[index3] |= (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[5];
                        if (num18 < num4)
                        {
                          uint num21 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue != (int) ushort.MaxValue ? (uint) (16711680 | (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[index3] & (int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index3]) : 61440U;
                          ProgCommand.DeviceBuffers.ProgramMemory[index2] &= num20 & (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index3];
                          ProgCommand.DeviceBuffers.ProgramMemory[index2] |= num21;
                        }
                      }
                    }
                  }
                  if (num6 > 0 && (long) num18 >= (long) num7)
                  {
                    int index3 = (int) ((long) num18 - (long) num7) / num8;
                    if (index3 < num6)
                    {
                      flag2 = false;
                      if (progMem)
                      {
                        if (num8 == num1)
                        {
                          ProgCommand.DeviceBuffers.UserIDs[index3] &= num20;
                        }
                        else
                        {
                          int num21 = num19 / num8 * num8;
                          for (int index4 = 0; index4 < num21; ++index4)
                            num20 >>= 8;
                          ProgCommand.DeviceBuffers.UserIDs[index3] &= num20;
                        }
                      }
                    }
                  }
                  if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].IgnoreBytes > 0 && (long) num18 >= (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].IgnoreAddress && (long) num18 < (long) (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].IgnoreAddress + (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].IgnoreBytes))
                    flag2 = false;
                  if (FormProgUSB.TestMemoryEnabled && FormProgUSB.TestMemoryOpen && (FormProgUSB.formTestMem.HexImportExportTM() && (long) num18 >= (long) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart) && (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart > 0U && FormProgUSB.TestMemoryWords > 0))
                  {
                    int index3 = (int) ((long) num18 - (long) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart) / num1;
                    if (index3 < FormProgUSB.TestMemoryWords)
                    {
                      flag2 = false;
                      FormTestMemory.TestMemory[index3] &= num20;
                    }
                  }
                }
              }
              if (flag2)
                flag3 = true;
            }
            if (num17 == 2 || num17 == 4)
            {
              if (str.Length >= 11 + 2 * num15)
                num5 = int.Parse(str.Substring(9, 4), NumberStyles.HexNumber);
              if (num17 == 2)
                num5 <<= 4;
              else
                num5 <<= 16;
            }
            if (num17 == 1 || fileInfo.Extension.ToUpper() == ".NUM")
              break;
          }
        }
        textReader.Close();
        if (length > 0)
        {
          if (!flag1)
            return Constants.FileRead.noconfig;
          for (int index = 0; index < length; ++index)
          {
            if (!flagArray[index])
            {
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue == 16777215 && length > 7)
                ProgCommand.DeviceBuffers.ConfigWords[7] &= (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[7];
              return Constants.FileRead.partialcfg;
            }
          }
        }
        return flag3 ? Constants.FileRead.largemem : Constants.FileRead.success;
      }
      catch
      {
        return Constants.FileRead.failed;
      }
    }

    public static bool ExportHexFile(string filePath, bool progMem, bool eeMem)
    {
      StreamWriter streamWriter = new StreamWriter(filePath);
      if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
        streamWriter.WriteLine(":020000041D00DD");
      else
        streamWriter.WriteLine(":020000040000FA");
      int num1 = 0;
      int num2 = 0;
      int length1 = ProgCommand.DeviceBuffers.ProgramMemory.Length;
      if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
      {
        num1 = 7424;
        num2 = 0;
        length1 -= (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BootFlash;
      }
      int num3 = 0;
      int num4 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
      int num5 = 16 / num4;
      if (progMem)
      {
        do
        {
          string fileLine1 = string.Format(":10{0:X4}00", (object) num2);
          for (int index1 = 0; index1 < num5; ++index1)
          {
            string str = "00000000";
            if (num3 + index1 < ProgCommand.DeviceBuffers.ProgramMemory.Length)
              str = string.Format("{0:X8}", (object) ProgCommand.DeviceBuffers.ProgramMemory[num3 + index1]);
            for (int index2 = 0; index2 < num4; ++index2)
              fileLine1 = fileLine1 + str.Substring(6 - 2 * index2, 2);
          }
          string str1 = fileLine1 + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine1));
          streamWriter.WriteLine(str1);
          num2 += 16;
          num3 += num5;
          if (num2 > (int) ushort.MaxValue && num3 < ProgCommand.DeviceBuffers.ProgramMemory.Length)
          {
            num1 += num2 >> 16;
            num2 &= (int) ushort.MaxValue;
            string fileLine2 = string.Format(":02000004{0:X4}", (object) num1);
            string str2 = fileLine2 + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine2));
            streamWriter.WriteLine(str2);
          }
        }
        while (num3 < length1);
      }
      if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BootFlash > 0U && ProgCommand.FamilyIsPIC32())
      {
        streamWriter.WriteLine(":020000041FC01B");
        int num6 = length1;
        int length2 = ProgCommand.DeviceBuffers.ProgramMemory.Length;
        int num7 = 8128;
        int num8 = 0;
        if (progMem)
        {
          do
          {
            string fileLine1 = string.Format(":10{0:X4}00", (object) num8);
            for (int index1 = 0; index1 < num5; ++index1)
            {
              string str = string.Format("{0:X8}", (object) ProgCommand.DeviceBuffers.ProgramMemory[num6 + index1]);
              for (int index2 = 0; index2 < num4; ++index2)
                fileLine1 = fileLine1 + str.Substring(6 - 2 * index2, 2);
            }
            string str1 = fileLine1 + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine1));
            streamWriter.WriteLine(str1);
            num8 += 16;
            num6 += num5;
            if (num8 > (int) ushort.MaxValue && num6 < ProgCommand.DeviceBuffers.ProgramMemory.Length)
            {
              num7 += num8 >> 16;
              num8 &= (int) ushort.MaxValue;
              string fileLine2 = string.Format(":02000004{0:X4}", (object) num7);
              string str2 = fileLine2 + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine2));
              streamWriter.WriteLine(str2);
            }
          }
          while (num6 < length2);
        }
      }
      if (eeMem)
      {
        int num6 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem;
        int num7 = 0;
        if (num6 > 0)
        {
          uint num8 = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEAddr;
          if ((num8 & 4294901760U) > 0U)
          {
            string fileLine = string.Format(":02000004{0:X4}", (object) (num8 >> 16));
            string str = fileLine + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine));
            streamWriter.WriteLine(str);
          }
          int num9 = (int) num8 & (int) ushort.MaxValue;
          int num10 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemHexBytes;
          int num11 = 16 / num10;
          do
          {
            string fileLine = string.Format(":10{0:X4}00", (object) num9);
            for (int index1 = 0; index1 < num11; ++index1)
            {
              string str = string.Format("{0:X8}", (object) ProgCommand.DeviceBuffers.EEPromMemory[num7 + index1]);
              for (int index2 = 0; index2 < num10; ++index2)
                fileLine = fileLine + str.Substring(6 - 2 * index2, 2);
            }
            string str1 = fileLine + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine));
            streamWriter.WriteLine(str1);
            num9 += 16;
            num7 += num11;
          }
          while (num7 < ProgCommand.DeviceBuffers.EEPromMemory.Length);
        }
      }
      if (progMem)
      {
        int num6 = num4;
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
          num6 = 2;
        int num7 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
        if (num7 > 0 && (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr > (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem * (long) num4)
        {
          uint num8 = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr;
          if ((num8 & 4294901760U) > 0U)
          {
            string fileLine = string.Format(":02000004{0:X4}", (object) (num8 >> 16));
            string str = fileLine + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine));
            streamWriter.WriteLine(str);
          }
          int num9 = (int) num8 & (int) ushort.MaxValue;
          int num10 = 0;
          for (int index1 = 0; index1 < (num7 * num6 - 1) / 16 + 1; ++index1)
          {
            int num11 = num7 - num10;
            if (num11 >= 16 / num6)
              num11 = 16 / num6;
            string fileLine = string.Format(":{0:X2}{1:X4}00", (object) (num11 * num6), (object) num9);
            num9 += num11 * num6;
            for (int index2 = 0; index2 < num11; ++index2)
            {
              uint num12 = ProgCommand.DeviceBuffers.ConfigWords[num10 + index2];
              if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
                num12 = (num12 | (uint) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[num10 + index2]) & (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[num10 + index2];
              string str = string.Format("{0:X8}", (object) num12);
              for (int index3 = 0; index3 < num6; ++index3)
                fileLine = fileLine + str.Substring(8 - (index3 + 1) * 2, 2);
            }
            string str1 = fileLine + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine));
            streamWriter.WriteLine(str1);
            num10 += num11;
          }
        }
      }
      if (progMem)
      {
        int num6 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords;
        int num7 = 0;
        if (num6 > 0)
        {
          uint num8 = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDAddr;
          if ((num8 & 4294901760U) > 0U)
          {
            string fileLine = string.Format(":02000004{0:X4}", (object) (num8 >> 16));
            string str = fileLine + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine));
            streamWriter.WriteLine(str);
          }
          int num9 = (int) num8 & (int) ushort.MaxValue;
          int num10 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].UserIDHexBytes;
          int num11 = 16 / num10;
          do
          {
            int num12 = (num6 - num7) * num10;
            string fileLine;
            if (num12 < 16)
            {
              fileLine = string.Format(":{0:X2}{1:X4}00", (object) num12, (object) num9);
              num11 = num6 - num7;
            }
            else
              fileLine = string.Format(":10{0:X4}00", (object) num9);
            for (int index1 = 0; index1 < num11; ++index1)
            {
              string str = string.Format("{0:X8}", (object) ProgCommand.DeviceBuffers.UserIDs[num7 + index1]);
              for (int index2 = 0; index2 < num10; ++index2)
                fileLine = fileLine + str.Substring(6 - 2 * index2, 2);
            }
            string str1 = fileLine + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine));
            streamWriter.WriteLine(str1);
            num9 += 16;
            num7 += num11;
          }
          while (num7 < ProgCommand.DeviceBuffers.UserIDs.Length);
        }
      }
      if (FormProgUSB.TestMemoryEnabled && FormProgUSB.TestMemoryOpen && FormProgUSB.formTestMem.HexImportExportTM())
      {
        int num6 = FormProgUSB.TestMemoryWords;
        int num7 = 0;
        if (num6 > 0)
        {
          uint num8 = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart;
          if ((num8 & 4294901760U) > 0U)
          {
            string fileLine = string.Format(":02000004{0:X4}", (object) (num8 >> 16));
            string str = fileLine + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine));
            streamWriter.WriteLine(str);
          }
          int num9 = (int) num8 & (int) ushort.MaxValue;
          int num10 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
          int num11 = 16 / num10;
          do
          {
            string fileLine = string.Format(":10{0:X4}00", (object) num9);
            for (int index1 = 0; index1 < num11; ++index1)
            {
              string str = string.Format("{0:X8}", (object) FormTestMemory.TestMemory[num7 + index1]);
              for (int index2 = 0; index2 < num10; ++index2)
                fileLine = fileLine + str.Substring(6 - 2 * index2, 2);
            }
            string str1 = fileLine + string.Format("{0:X2}", (object) ImportExportHex.computeChecksum(fileLine));
            if (num9 != ((int) num8 & (int) ushort.MaxValue) || ProgCommand.GetActiveFamily() != 3)
              streamWriter.WriteLine(str1);
            num9 += 16;
            num7 += num11;
          }
          while (num7 < FormProgUSB.TestMemoryWords);
        }
      }
      streamWriter.WriteLine(":00000001FF");
      streamWriter.Close();
      return true;
    }

    private static byte computeChecksum(string fileLine)
    {
      int num1 = int.Parse(fileLine.Substring(1, 2), NumberStyles.HexNumber);
      if (fileLine.Length < 9 + 2 * num1)
        return (byte) 0;
      int num2 = num1;
      for (int index = 0; index < 3 + num1; ++index)
        num2 += int.Parse(fileLine.Substring(3 + 2 * index, 2), NumberStyles.HexNumber);
      return (byte) (-num2 & (int) byte.MaxValue);
    }
  }
}
