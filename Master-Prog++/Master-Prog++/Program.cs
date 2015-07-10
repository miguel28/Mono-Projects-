// Type: SysProgUSB.Program
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.Windows.Forms;

namespace SysProgUSB
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new FormProgUSB());
    }
  }
}
