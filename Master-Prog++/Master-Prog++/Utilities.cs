// Type: SysProgUSB.Utilities
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System.Text;

namespace SysProgUSB
{
  public class Utilities
  {
    public static int Convert_Value_To_Int(string p_value)
    {
      uint[] numArray1 = new uint[34]
      {
        0U,
        0U,
        (uint) int.MinValue,
        1073741824U,
        536870912U,
        268435456U,
        134217728U,
        67108864U,
        33554432U,
        16777216U,
        8388608U,
        4194304U,
        2097152U,
        1048576U,
        524288U,
        262144U,
        131072U,
        65536U,
        32768U,
        16384U,
        8192U,
        4096U,
        2048U,
        1024U,
        512U,
        256U,
        128U,
        64U,
        32U,
        16U,
        8U,
        4U,
        2U,
        1U
      };
      uint[] numArray2 = new uint[10]
      {
        0U,
        0U,
        268435456U,
        16777216U,
        1048576U,
        65536U,
        4096U,
        256U,
        16U,
        1U
      };
      int result1 = 0;
      if ((int) p_value[0] == 0)
        result1 = 0;
      else if ((int) p_value[0] == 89 || (int) p_value[0] == 121)
        result1 = 1;
      else if ((int) p_value[0] == 78 || (int) p_value[0] == 110)
        result1 = 0;
      else if (p_value.Length > 1)
      {
        if ((int) p_value[0] == 48 && ((int) p_value[1] == 98 || (int) p_value[1] == 66) || ((int) p_value[0] == 98 || (int) p_value[0] == 66))
        {
          int num1 = p_value.Length - 1;
          for (int index = (int) p_value[0] != 48 ? 1 : 2; index <= num1; ++index)
          {
            int num2 = (int) p_value[index] != 49 ? 0 : 1;
            result1 += (int) numArray1[index + 34 - p_value.Length] * num2;
          }
        }
        else if ((int) p_value[0] == 48 && ((int) p_value[1] == 120 || (int) p_value[1] == 88))
        {
          int num = p_value.Length - 1;
          for (int index = 2; index <= num; ++index)
          {
            int result2;
            switch (p_value[index])
            {
              case 'A':
              case 'a':
                result2 = 10;
                break;
              case 'B':
              case 'b':
                result2 = 11;
                break;
              case 'C':
              case 'c':
                result2 = 12;
                break;
              case 'D':
              case 'd':
                result2 = 13;
                break;
              case 'E':
              case 'e':
                result2 = 14;
                break;
              case 'F':
              case 'f':
                result2 = 15;
                break;
              default:
                if (!int.TryParse(p_value[index].ToString(), out result2))
                {
                  result2 = 0;
                  break;
                }
                else
                  break;
            }
            result1 += (int) numArray2[index + 10 - p_value.Length] * result2;
          }
        }
        else if (!int.TryParse(p_value, out result1))
          result1 = 0;
      }
      else if (!int.TryParse(p_value, out result1))
        result1 = 0;
      return result1;
    }

    public static string ConvertIntASCII(int toConvert, int numBytes)
    {
      byte[] bytes = new byte[numBytes];
      for (int index = numBytes; index > 0; --index)
      {
        bytes[index - 1] = (byte) toConvert;
        if ((int) bytes[index - 1] < 32 || (int) bytes[index - 1] > 126)
          bytes[index - 1] = (byte) 46;
        toConvert >>= 8;
      }
      return Encoding.ASCII.GetString(bytes);
    }

    public static string ConvertIntASCIIReverse(int toConvert, int numBytes)
    {
      numBytes += numBytes - 1;
      byte[] bytes = new byte[numBytes];
      for (int index = 0; index < numBytes; ++index)
      {
        if (index % 2 == 1)
        {
          bytes[index] = (byte) 32;
        }
        else
        {
          bytes[index] = (byte) toConvert;
          if ((int) bytes[index] < 32 || (int) bytes[index] > 126)
            bytes[index] = (byte) 46;
          toConvert >>= 8;
        }
      }
      return Encoding.ASCII.GetString(bytes);
    }
  }
}
