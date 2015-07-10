// Type: SysProgUSB.DeviceData
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;

namespace SysProgUSB
{
  public class DeviceData
  {
    public uint[] ProgramMemory;
    public uint[] EEPromMemory;
    public uint[] ConfigWords;
    public uint[] UserIDs;
    public uint OSCCAL;
    public uint BandGap;

    public DeviceData(uint progMemSize, ushort eeMemSize, byte numConfigs, byte numIDs, uint memBlankVal, int eeBytes, int idBytes, ushort[] configBlank, uint OSCCALInit)
    {
      this.ProgramMemory = new uint[(IntPtr) progMemSize];
      this.EEPromMemory = new uint[(int) eeMemSize];
      this.ConfigWords = new uint[(int) numConfigs];
      this.UserIDs = new uint[(int) numIDs];
      this.ClearProgramMemory(memBlankVal);
      this.ClearEEPromMemory(eeBytes, memBlankVal);
      this.ClearConfigWords(configBlank);
      this.ClearUserIDs(idBytes, memBlankVal);
      this.OSCCAL = OSCCALInit | (uint) byte.MaxValue;
      this.BandGap = memBlankVal;
    }

    public void ClearProgramMemory(uint memBlankVal)
    {
      if (this.ProgramMemory.Length <= 0)
        return;
      for (int index = 0; index < this.ProgramMemory.Length; ++index)
        this.ProgramMemory[index] = memBlankVal;
    }

    public void ClearConfigWords(ushort[] configBlank)
    {
      if (this.ConfigWords.Length <= 0)
        return;
      for (int index = 0; index < this.ConfigWords.Length; ++index)
        this.ConfigWords[index] = (uint) configBlank[index];
    }

    public void ClearUserIDs(int idBytes, uint memBlankVal)
    {
      if (this.UserIDs.Length <= 0)
        return;
      uint num = memBlankVal;
      if (idBytes == 1)
        num = (uint) byte.MaxValue;
      for (int index = 0; index < this.UserIDs.Length; ++index)
        this.UserIDs[index] = num;
    }

    public void ClearEEPromMemory(int eeBytes, uint memBlankVal)
    {
      if (this.EEPromMemory.Length <= 0)
        return;
      uint num = (uint) byte.MaxValue;
      if (eeBytes == 2)
        num = (uint) ushort.MaxValue;
      if ((int) memBlankVal == 4095)
        num = 4095U;
      for (int index = 0; index < this.EEPromMemory.Length; ++index)
        this.EEPromMemory[index] = num;
    }
  }
}
