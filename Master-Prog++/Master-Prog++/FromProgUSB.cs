// Type: SysProgUSB.FormProgUSB
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class FormProgUSB : Form
  {
    public static bool ShowWriteEraseVDDDialog = true;
    public static bool ContinueWriteErase = false;
    public static bool setOSCCALValue = false;
    public static bool TestMemoryOpen = false;
    public static bool TestMemoryEnabled = false;
    public static int TestMemoryWords = 64;
    public static ushort pk2number = (ushort) 0;
    public static bool TestMemoryImportExport = false;
    public static string DeviceFileName = "Dispositivos.bin";
    public static float ScalefactW = 1f;
    public static float ScalefactH = 1f;
    private static Constants.StatusColor statusWindowColor = Constants.StatusColor.normal;
    private DialogVDDErase dialogVddErase = new DialogVDDErase();
    private DialogUART uartWindow = new DialogUART();
    private DialogLogic logicWindow = new DialogLogic();
    private FormMultiWinProgMem programMemMultiWin = new FormMultiWinProgMem();
    private FormMultiWinEEData eepromDataMultiWin = new FormMultiWinEEData();
    private Point lastLoc = new Point(0, 0);
    private bool buttonLast = true;
    private bool allowDataEdits = true;
    private bool searchOnStartup = true;
    private bool autoDetectInINI = true;
    private bool multiWinPMemOpen = true;
    private bool multiWinEEMemOpen = true;
    private bool saveMultWinPMemOpen = true;
    private bool saveMultiWinEEMemOpen = true;
    private bool verifyOSCCALValue = true;
    private bool mainWinOwnsMem = true;
    private string lastFamily = "Midrange";
    private string hex1 = "";
    private string hex2 = "";
    private string hex3 = "";
    private string hex4 = "";
    private byte slowSpeedICSP = (byte) 4;
    public static FormTestMemory formTestMem;
    public static string HomeDirectory;
    private static bool selfPoweredTarget;
    private DialogUserIDs dialogIDMemory;
    private Constants.VddTargetSelect VddTargetSave;
    private bool checkImportFile;
    private bool oldFirmware;
    private bool bootLoad;
    private bool importGo;
    private bool progMemJustEdited;
    private bool eeMemJustEdited;
    private bool testConnected;
    private bool selectDeviceFile;
    private bool viewChanged;
    private bool multiWindow;
    private byte ptgMemory;
    private IContainer components;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem importFileToolStripMenuItem;
    private ToolStripMenuItem exportFileToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem deviceToolStripMenuItem;
    private ToolStripMenuItem toolsToolStripMenuItem;
    private ToolStripMenuItem enableCodeProtectToolStripMenuItem;
    private ToolStripMenuItem targetPowerToolStripMenuItem;
    private ToolStripMenuItem fastProgrammingToolStripMenuItem;
    private ToolStripMenuItem checkCommunicationToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem2;
    private ToolStripMenuItem downloadPICkit2FirmwareToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem usersGuideToolStripMenuItem;
    private ToolStripMenuItem readMeToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem3;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private GroupBox statusGroupBox;
    private Label labelChecksum;
    private Label labelUserIDs;
    private DataGridView dataGridConfigWords;
    private Label displayUserIDs;
    private Label displayDevice;
    private Label labelConfig;
    private Label displayChecksum;
    private Label labelOSCCAL;
    private Label displayBandGap;
    private Label labelBandGap;
    private Label displayOSCCAL;
    private Label displayStatusWindow;
    private Button buttonRead;
    private ProgressBar progressBar1;
    private Button buttonWrite;
    private Button buttonVerify;
    private Button buttonErase;
    private Button buttonBlankCheck;
    private CheckBox chkBoxVddOn;
    private NumericUpDown numUpDnVDD;
    private GroupBox groupBoxVDD;
    private GroupBox groupBoxProgMem;
    private CheckBox checkBoxProgMemEnabled;
    private ComboBox comboBoxProgMemView;
    private Label displayDataSource;
    private DataGridView dataGridProgramMemory;
    private OpenFileDialog openHexFileDialog;
    private SaveFileDialog saveHexFileDialog;
    private OpenFileDialog openFWFile;
    private System.Windows.Forms.Timer timerButton;
    private GroupBox groupBoxEEMem;
    private Button buttonExportHex;
    private ComboBox comboBoxEE;
    private CheckBox checkBoxEEMem;
    private DataGridView dataGridViewEEPROM;
    private ToolStripMenuItem autoDetectToolStripMenuItem;
    private ToolStripMenuItem forcePICkit2ToolStripMenuItem;
    private ToolStripMenuItem forceTargetToolStripMenuItem;
    private ComboBox comboBoxSelectPart;
    private Label labelCodeProtect;
    private System.Windows.Forms.Timer timerDLFW;
    private ToolStripMenuItem hex1ToolStripMenuItem;
    private ToolStripMenuItem hex2ToolStripMenuItem;
    private ToolStripMenuItem hex3ToolStripMenuItem;
    private ToolStripMenuItem hex4ToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem enableDataProtectStripMenuItem;
    private ToolStripMenuItem lpcUsersGuideToolStripMenuItem;
    private Label displayEEProgInfo;
    private ToolStripMenuItem setOSCCALToolStripMenuItem;
    private ToolStripMenuItem webPUSBToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem6;
    private ToolStripMenuItem troubleshhotToolStripMenuItem;
    private CheckBox checkBoxMCLR;
    private ToolStripMenuItem toolStripMenuItemTestMemory;
    private CheckBox checkBoxAutoImportWrite;
    private System.Windows.Forms.Timer timerAutoImportWrite;
    private ToolStripMenuItem testToolStripMenuItem;
    private Label displayRev;
    private ToolStripMenuItem uG44pinToolStripMenuItem;
    private Button buttonShowIDMem;
    private ToolStripMenuItem VppFirstToolStripMenuItem;
    private CheckBox checkBoxA1CS;
    private CheckBox checkBoxA0CS;
    private CheckBox checkBoxA2CS;
    private ToolStripMenuItem calibrateToolStripMenuItem;
    private Label labelOSSCALInvalid;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem UARTtoolStripMenuItem;
    private CheckBox checkBoxProgMemEnabledAlt;
    private CheckBox checkBoxEEDATAMemoryEnabledAlt;
    private ToolStripMenuItem toolStripMenuItemView;
    private ToolStripMenuItem toolStripMenuItemSingleWindow;
    private ToolStripMenuItem toolStripMenuItemMultiWindow;
    private ToolStripSeparator toolStripMenuItem7;
    private ToolStripMenuItem toolStripMenuItemShowProgramMemory;
    private ToolStripMenuItem toolStripMenuItemShowEEPROMData;
    private ToolStripMenuItem toolStripMenuItemProgToGo;
    private ToolStripMenuItem toolStripMenuItemLogicTool;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem toolStripMenuItemContextSelectAll;
    private ToolStripMenuItem toolStripMenuItemContextCopy;
    private ToolStripMenuItem toolStripMenuItemLogicToolUG;
    private ToolStripMenuItem calSetManuallyToolStripMenuItem;
    private ToolStripMenuItem calAutoRegenerateToolStripMenuItem;
    private System.Windows.Forms.Timer timerInitalUpdate;
    private ToolStripSeparator toolStripMenuItem9;
    private ToolStripMenuItem mainWindowAlwaysInFrontToolStripMenuItem;
    private PictureBox pictureBox1;
    private Label label1;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private Label label3;
    private Label label2;
    private Label labelDevice;
    private Button button1;
    private TabPage tabPage3;
    private Label label5;
    private Label label4;
    private ToolStripSeparator toolStripMenuItem5;
    private Label label6;
    private TabPage tabPage4;
    private ToolStripMenuItem verifyOnWriteToolStripMenuItem;
    private ToolStripMenuItem programmerToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem4;
    private ToolStripMenuItem readDeviceToolStripMenuItem;
    private ToolStripMenuItem writeDeviceToolStripMenuItem;
    private ToolStripMenuItem eraseToolStripMenuItem;
    private ToolStripMenuItem blankCheckToolStripMenuItem;
    private ToolStripMenuItem verifyToolStripMenuItem;
    private ToolStripMenuItem MCLRtoolStripMenuItem;
    private ToolStripMenuItem writeOnPICkitButtonToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem8;
    private ToolStripMenuItem toolStripMenuItemManualSelect;
    private ToolStripMenuItem pICkit2GoToolStripMenuItem;
    private ToolStripMenuItem toolStripMenuItemClearBuffersErase;
    private Button button2;
    private ToolStripMenuItem practicasToolStripMenuItem;
    private ToolStripMenuItem basicasToolStripMenuItem;
    private ToolStripMenuItem prenderUnLEDToolStripMenuItem;
    private ToolStripMenuItem funcionesLogicasToolStripMenuItem;
    private ToolStripMenuItem autoIncreibleToolStripMenuItem;
    private ToolStripMenuItem contadorBinarioToolStripMenuItem;
    private ToolStripMenuItem display7SegmentosToolStripMenuItem;
    private ToolStripMenuItem intermediasToolStripMenuItem;
    private ToolStripMenuItem contadorDeTurnosToolStripMenuItem;
    private ToolStripMenuItem tacometroDigtalToolStripMenuItem;
    private ToolStripMenuItem robotSeguidorDeLineaToolStripMenuItem;
    private ToolStripMenuItem relojConDisplayDe7segToolStripMenuItem;
    private ToolStripMenuItem controlDeUnDisplayLCDToolStripMenuItem;
    private ToolStripMenuItem avanzadasToolStripMenuItem;
    private ToolStripMenuItem termometroConLCDToolStripMenuItem;
    private ToolStripMenuItem comunicacionSerialToolStripMenuItem;
    private ToolStripMenuItem trnasmisonRFToolStripMenuItem;
    private PictureBox pictureBox4;
    private PictureBox pictureBox3;
    private TabControl tabControl2;
    private TabPage tabPage5;
    private PictureBox pictureBox2;
    private TabPage tabPage6;
    private PictureBox pictureBox5;
    private TabPage tabPage7;
    private PictureBox pictureBox6;
    private TabPage tabPage8;
    private PictureBox pictureBox7;
    private TabPage tabPage9;
    private PictureBox pictureBox8;
    private TabPage tabPage10;
    private PictureBox pictureBox9;
    private PictureBox pictureBox10;
    private TabPage tabPage11;
    private PictureBox pictureBox11;
    private PictureBox pictureBox12;
    private PictureBox pictureBox13;
    private PictureBox pictureBox14;

    static FormProgUSB()
    {
    }

    public FormProgUSB()
    {
      this.InitializeComponent();
      float num = this.loadINI();
      if (this.mainWinOwnsMem)
      {
        this.AddOwnedForm((Form) this.programMemMultiWin);
        this.AddOwnedForm((Form) this.eepromDataMultiWin);
      }
      this.initializeGUI();
      if (!this.loadDeviceFile())
        return;
      if (this.toolStripMenuItemManualSelect.Checked)
        this.ManualAutoSelectToggle(false);
      this.buildDeviceMenu();
      if (!this.allowDataEdits)
      {
        this.dataGridProgramMemory.ReadOnly = true;
        this.dataGridViewEEPROM.ReadOnly = true;
      }
      ProgCommand.ResetBuffers();
      this.testConnected = this.checkForTest();
      if (this.testConnected)
        this.testConnected = this.testMenuBuild();
      PIC32MXFunctions.UpdateStatusWinText = new DelegateStatusWin(this.StatusWinWr);
      PIC32MXFunctions.ResetStatusBar = new DelegateResetStatusBar(this.ResetStatusBar);
      PIC32MXFunctions.StepStatusBar = new DelegateStepStatusBar(this.StepStatusBar);
      this.uartWindow.VddCallback = new DelegateVddCallback(this.SetVddState);
      this.logicWindow.VddCallback = new DelegateVddCallback(this.SetVddState);
      if (!this.detectPICkit2(true, true))
      {
        if (this.bootLoad)
          return;
        if (!this.oldFirmware)
        {
          Thread.Sleep(3000);
          if (!this.detectPICkit2(true, true))
            return;
        }
        else
        {
          FormProgUSB.TestMemoryOpen = false;
          this.timerDLFW.Enabled = true;
          return;
        }
      }
      this.partialEnableGUIControls();
      ProgCommand.ExitUARTMode();
      ProgCommand.VddOff();
      ProgCommand.SetVDDVoltage(3.3f, 0.85f);
      if (this.autoDetectToolStripMenuItem.Checked)
        this.lookForPoweredTarget(false);
      if (this.searchOnStartup && ProgCommand.DetectDevice(16777215, true, this.chkBoxVddOn.Checked))
      {
        this.setGUIVoltageLimits(true);
        ProgCommand.SetVDDVoltage((float) this.numUpDnVDD.Value, 0.85f);
        this.displayStatusWindow.Text = this.displayStatusWindow.Text + "\nPIC Encontrado.";
        this.fullEnableGUIControls();
      }
      else
      {
        for (int family = 0; family < ProgCommand.DevFile.Info.NumberFamilies; ++family)
        {
          if (ProgCommand.DevFile.Families[family].FamilyName == this.lastFamily)
          {
            ProgCommand.SetActiveFamily(family);
            if (!ProgCommand.DevFile.Families[family].PartDetect)
            {
              this.buildDeviceSelectDropDown(family);
              this.comboBoxSelectPart.Visible = true;
              this.comboBoxSelectPart.SelectedIndex = 0;
              this.displayDevice.Visible = true;
            }
          }
        }
        for (int index = 1; index < ProgCommand.DevFile.Info.NumberParts; ++index)
        {
          if ((int) ProgCommand.DevFile.PartsList[index].Family == ProgCommand.GetActiveFamily())
          {
            ProgCommand.DevFile.PartsList[0].VddMax = ProgCommand.DevFile.PartsList[index].VddMax;
            ProgCommand.DevFile.PartsList[0].VddMin = ProgCommand.DevFile.PartsList[index].VddMin;
            break;
          }
        }
        this.setGUIVoltageLimits(true);
      }
      if ((double) num != 0.0 && ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName == this.lastFamily && !FormProgUSB.selfPoweredTarget)
      {
        if ((double) num > (double) (float) this.numUpDnVDD.Maximum)
          num = (float) this.numUpDnVDD.Maximum;
        if ((double) num < (double) (float) this.numUpDnVDD.Minimum)
          num = (float) this.numUpDnVDD.Minimum;
        this.numUpDnVDD.Value = (Decimal) num;
        ProgCommand.SetVDDVoltage((float) this.numUpDnVDD.Value, 0.85f);
      }
      this.checkForPowerErrors();
      if (FormProgUSB.TestMemoryEnabled)
      {
        this.toolStripMenuItemTestMemory.Visible = true;
        if (FormProgUSB.TestMemoryOpen)
          this.openTestMemory();
      }
      if (!ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].PartDetect)
        this.disableGUIControls();
      if (this.multiWindow)
      {
        this.saveMultWinPMemOpen = this.multiWinPMemOpen;
        this.toolStripMenuItemShowProgramMemory.Checked = false;
        this.multiWinPMemOpen = false;
        this.saveMultiWinEEMemOpen = this.multiWinEEMemOpen;
        this.toolStripMenuItemShowEEPROMData.Checked = false;
        this.multiWinEEMemOpen = false;
      }
      this.updateGUI(true);
      if (!this.multiWindow)
        return;
      this.timerInitalUpdate.Enabled = true;
    }

    /*[DllImport("user32.dll")]
    private static short FlashWindowEx(ref FormProgUSB.FLASHWINFO pwfi);
*/
    public void ExtCallUpdateGUI()
    {
      this.updateGUI(true);
    }

    public bool ExtCallVerify()
    {
      return this.deviceVerify(false, 0, false);
    }

    public bool ExtCallWrite(bool verify)
    {
      bool @checked = this.verifyOnWriteToolStripMenuItem.Checked;
      this.verifyOnWriteToolStripMenuItem.Checked = verify;
      bool flag = this.deviceWrite();
      this.verifyOnWriteToolStripMenuItem.Checked = @checked;
      return flag;
    }

    public void ExtCallRead()
    {
      this.deviceRead();
    }

    public void ExtCallErase(bool writeOSCCAL)
    {
      this.eraseDeviceAll(writeOSCCAL, new uint[0]);
    }

    public void ExtCallCalEraseWrite(uint[] calwords)
    {
      this.eraseDeviceAll(false, calwords);
    }

    public bool ExtCallBlank()
    {
      return this.blankCheckDevice();
    }

    public void MultiWinProgMemClosed()
    {
      this.multiWinPMemOpen = false;
      this.toolStripMenuItemShowProgramMemory.Checked = false;
    }

    public void MultiWinEEMemClosed()
    {
      this.multiWinEEMemOpen = false;
      this.toolStripMenuItemShowEEPROMData.Checked = false;
    }

    public void ShowMemEdited()
    {
      this.displayDataSource.Text = "Modificado";
      this.checkImportFile = false;
    }

    public void StatusWinWr(string dispText)
    {
      this.displayStatusWindow.Text = dispText;
      this.Update();
    }

    public void ResetStatusBar(int maxValue)
    {
      this.progressBar1.Value = 0;
      this.progressBar1.Maximum = maxValue;
      this.Update();
    }

    public void StepStatusBar()
    {
      this.progressBar1.PerformStep();
    }

    public void SetVddState(bool force, bool forceState)
    {
      this.vddControl(force, forceState);
      this.uartWindow.SetVddBox(this.numUpDnVDD.Enabled, this.chkBoxVddOn.Checked);
      this.logicWindow.SetVddBox(this.numUpDnVDD.Enabled, this.chkBoxVddOn.Checked);
    }

    private bool checkForPowerErrors()
    {
      Thread.Sleep(100);
      switch (ProgCommand.PowerStatus())
      {
        case Constants.PICkit2PWR.vdderror:
          if (!this.timerAutoImportWrite.Enabled)
          {
            int num = (int) MessageBox.Show("Error en el nivel de Voltaje VDD!\nRevisar Conexiones y Reintentar", "  ¡ERROR DETECTADO!");
            break;
          }
          else
            break;
        case Constants.PICkit2PWR.vpperror:
          if (!this.timerAutoImportWrite.Enabled)
          {
            int num = (int) MessageBox.Show("Error en el nivel de Voltaje VPP!\nRevisar Conexiones y Reintentar", "  ¡ERROR DETECTADO!");
            break;
          }
          else
            break;
        case Constants.PICkit2PWR.vddvpperrors:
          if (!this.timerAutoImportWrite.Enabled)
          {
            int num = (int) MessageBox.Show("Error en los Voltajes VPP y VDD!\nRevisar Conexiones y Reintentar", "  ¡ERROR DETECTADO!");
            break;
          }
          else
            break;
        case Constants.PICkit2PWR.vdd_on:
          this.chkBoxVddOn.Checked = true;
          return false;
        case Constants.PICkit2PWR.vdd_off:
          this.chkBoxVddOn.Checked = false;
          return false;
      }
      this.chkBoxVddOn.Checked = false;
      return true;
    }

    private bool lookForPoweredTarget(bool showMessageBox)
    {
      float vdd = 0.0f;
      float vpp = 0.0f;
      if (this.fastProgrammingToolStripMenuItem.Checked)
        ProgCommand.SetProgrammingSpeed((byte) 0);
      else
        ProgCommand.SetProgrammingSpeed(this.slowSpeedICSP);
      if (this.autoDetectToolStripMenuItem.Checked)
      {
        if (ProgCommand.CheckTargetPower(ref vdd, ref vpp) == Constants.PICkit2PWR.selfpowered)
        {
          this.chkBoxVddOn.Checked = false;
          if (!FormProgUSB.selfPoweredTarget)
          {
            FormProgUSB.selfPoweredTarget = true;
            this.chkBoxVddOn.Enabled = true;
            this.chkBoxVddOn.Text = "Revisar";
            this.numUpDnVDD.Enabled = false;
            this.groupBoxVDD.Text = "Voltaje VDD";
            if (showMessageBox)
            {
              int num = (int) MessageBox.Show(" Voltaje VDD Correcto!\n", " ");
            }
          }
          this.numUpDnVDD.Maximum = (Decimal) vdd;
          this.numUpDnVDD.Value = (Decimal) vdd;
          this.numUpDnVDD.Update();
          return true;
        }
        else
        {
          if (FormProgUSB.selfPoweredTarget)
          {
            FormProgUSB.selfPoweredTarget = false;
            this.chkBoxVddOn.Enabled = true;
            this.chkBoxVddOn.Text = "Enc";
            this.numUpDnVDD.Enabled = true;
            this.setGUIVoltageLimits(true);
            this.groupBoxVDD.Text = "VDD MASTER-PROG";
            if (showMessageBox)
            {
              int num = (int) MessageBox.Show("Voltaje VDD no presente!\nPosible CORTO CIRCUITO ", "       ¡ A L E R T A !");
            }
          }
          return false;
        }
      }
      else if (this.forcePICkit2ToolStripMenuItem.Checked)
      {
        if (FormProgUSB.selfPoweredTarget)
        {
          ProgCommand.ForcePICkitPowered();
          FormProgUSB.selfPoweredTarget = false;
          this.chkBoxVddOn.Enabled = true;
          this.chkBoxVddOn.Text = "Enc";
          this.numUpDnVDD.Enabled = true;
          this.setGUIVoltageLimits(true);
          this.groupBoxVDD.Text = "VDD MASTER-PROG";
        }
        return false;
      }
      else
      {
        int num = (int) ProgCommand.CheckTargetPower(ref vdd, ref vpp);
        ProgCommand.ForceTargetPowered();
        this.chkBoxVddOn.Checked = false;
        if (!FormProgUSB.selfPoweredTarget)
        {
          FormProgUSB.selfPoweredTarget = true;
          this.chkBoxVddOn.Enabled = true;
          this.chkBoxVddOn.Text = "Revisar";
          this.numUpDnVDD.Enabled = false;
          this.groupBoxVDD.Text = "Voltaje VDD";
        }
        this.numUpDnVDD.Maximum = (Decimal) vdd;
        this.numUpDnVDD.Value = (Decimal) vdd;
        this.numUpDnVDD.Update();
        return true;
      }
    }

    private void setGUIVoltageLimits(bool setValue)
    {
      if (!this.numUpDnVDD.Enabled)
        return;
      this.numUpDnVDD.Maximum = (Decimal) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddMax;
      this.numUpDnVDD.Minimum = (Decimal) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddMin;
      if (ProgCommand.ActivePart != 0)
      {
        ProgCommand.DevFile.PartsList[0].VddMax = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddMax;
        ProgCommand.DevFile.PartsList[0].VddMin = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddMin;
      }
      if (!setValue)
        return;
      if ((double) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddMax <= 4.0 && (double) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddMax >= 3.3)
        this.numUpDnVDD.Value = new Decimal(33, 0, 0, false, (byte) 1);
      else if ((double) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddMax == 5.0)
        this.numUpDnVDD.Value = new Decimal(50, 0, 0, false, (byte) 1);
      else
        this.numUpDnVDD.Value = (Decimal) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddMax;
    }

    private void initializeGUI()
    {
      FormProgUSB.ScalefactW = (float) this.dataGridProgramMemory.Size.Width / 502f;
      FormProgUSB.ScalefactH = (float) this.dataGridProgramMemory.Size.Height / 208f;
      this.dataGridConfigWords.BackgroundColor = SystemColors.Control;
      this.dataGridConfigWords.ColumnCount = 4;
      this.dataGridConfigWords.RowCount = 2;
      this.dataGridConfigWords.DefaultCellStyle.BackColor = SystemColors.Control;
      this.dataGridConfigWords[0, 0].Selected = true;
      this.dataGridConfigWords[0, 0].Selected = false;
      int num1 = (int) (40.0 * (double) FormProgUSB.ScalefactW);
      for (int index = 0; index < 4; ++index)
        this.dataGridConfigWords.Columns[index].Width = num1;
      this.dataGridConfigWords.Rows[0].Height = (int) (17.0 * (double) FormProgUSB.ScalefactH);
      this.dataGridConfigWords.Rows[1].Height = (int) (17.0 * (double) FormProgUSB.ScalefactH);
      this.progressBar1.Step = 1;
      if (this.comboBoxProgMemView.SelectedIndex < 0)
        this.comboBoxProgMemView.SelectedIndex = 0;
      this.dataGridProgramMemory.DefaultCellStyle.Font = new Font("Courier New", 9f);
      this.dataGridProgramMemory.ColumnCount = 9;
      this.dataGridProgramMemory.RowCount = 512;
      this.dataGridProgramMemory[0, 0].Selected = true;
      this.dataGridProgramMemory[0, 0].Selected = false;
      this.dataGridProgramMemory.Columns[0].Width = (int) (59.0 * (double) FormProgUSB.ScalefactW);
      this.dataGridProgramMemory.Columns[0].ReadOnly = true;
      int num2 = (int) (53.0 * (double) FormProgUSB.ScalefactW);
      for (int index = 1; index < 9; ++index)
        this.dataGridProgramMemory.Columns[index].Width = num2;
      for (int index = 0; index < 32; ++index)
      {
        this.dataGridProgramMemory[0, index].Style.BackColor = SystemColors.ControlLight;
        this.dataGridProgramMemory[0, index].Value = (object) string.Format("{0:X5}", (object) (index * 8));
      }
      if (this.comboBoxEE.SelectedIndex < 0)
        this.comboBoxEE.SelectedIndex = 0;
      this.dataGridViewEEPROM.DefaultCellStyle.Font = new Font("Courier New", 9f);
      this.dataGridViewEEPROM.ColumnCount = 9;
      this.dataGridViewEEPROM.RowCount = 16;
      this.dataGridViewEEPROM.Columns[0].Width = (int) (40.0 * (double) FormProgUSB.ScalefactW);
      this.dataGridViewEEPROM.Columns[0].ReadOnly = true;
      int num3 = (int) (41.0 * (double) FormProgUSB.ScalefactW);
      for (int index = 1; index < 9; ++index)
        this.dataGridViewEEPROM.Columns[index].Width = num3;
      this.dataGridViewEEPROM[0, 0].Selected = true;
      this.dataGridViewEEPROM[0, 0].Selected = false;
      this.dataGridViewEEPROM.Visible = false;
      this.programMemMultiWin.TellMainFormProgMemClosed = new DelegateMultiProgMemClosed(this.MultiWinProgMemClosed);
      this.programMemMultiWin.TellMainFormProgMemEdited = new DelegateMemEdited(this.ShowMemEdited);
      this.programMemMultiWin.TellMainFormUpdateGUI = new DelegateUpdateGUI(this.ExtCallUpdateGUI);
      this.eepromDataMultiWin.TellMainFormEEMemClosed = new DelegateMultiEEMemClosed(this.MultiWinEEMemClosed);
      this.eepromDataMultiWin.TellMainFormProgMemEdited = new DelegateMemEdited(this.ShowMemEdited);
      this.eepromDataMultiWin.TellMainFormUpdateGUI = new DelegateUpdateGUI(this.ExtCallUpdateGUI);
    }

    private bool loadDeviceFile()
    {
      if (this.selectDeviceFile)
      {
        int num = (int) new DialogDevFile().ShowDialog();
      }
      if (ProgCommand.ReadDeviceFile(FormProgUSB.DeviceFileName))
      {
        if ((int) ProgCommand.DevFile.Info.Compatibility < 0)
        {
          this.displayStatusWindow.Text = "Error en la Aplicación!\nContactar al Soporte Técnico";
          this.checkCommunicationToolStripMenuItem.Enabled = false;
          return false;
        }
        else
        {
          if ((int) ProgCommand.DevFile.Info.Compatibility <= 5)
            return true;
          this.displayStatusWindow.Text = "Error en la Aplicación!\nContactar al Soporte Técnico";
          this.checkCommunicationToolStripMenuItem.Enabled = false;
          return false;
        }
      }
      else
      {
        this.displayStatusWindow.Text = "No se cargó la librería " + FormProgUSB.DeviceFileName + "\n(Debe estar en la misma carpeta que esta aplicación)";
        this.checkCommunicationToolStripMenuItem.Enabled = false;
        return false;
      }
    }

    private bool detectPICkit2(bool showFound, bool detectMult)
    {
      if (detectMult)
      {
        FormProgUSB.pk2number = (ushort) 0;
        if (ProgCommand.DetectPICkit2Device((ushort) 0, false) != Constants.PICkit2USB.notFound && ProgCommand.DetectPICkit2Device((ushort) 1, false) != Constants.PICkit2USB.notFound)
        {
          int num = (int) new DialogUnitSelect().ShowDialog();
        }
      }
      Constants.PICkit2USB piCkit2Usb = ProgCommand.DetectPICkit2Device(FormProgUSB.pk2number, true);
      if (piCkit2Usb == Constants.PICkit2USB.found)
      {
        this.downloadPICkit2FirmwareToolStripMenuItem.Enabled = true;
        this.chkBoxVddOn.Enabled = true;
        if (!FormProgUSB.selfPoweredTarget)
          this.numUpDnVDD.Enabled = true;
        this.deviceToolStripMenuItem.Enabled = true;
        if (showFound)
        {
          string serialUnitId = ProgCommand.GetSerialUnitID();
          if ((int) serialUnitId[0] == 45)
          {
            this.pictureBox14.Visible = false;
            this.pictureBox12.Visible = true;
            this.pictureBox10.Visible = true;
            this.pictureBox4.Visible = true;
            this.pictureBox3.Visible = true;
            this.displayStatusWindow.Text = "MASTER-PROG Listo en el puerto USB";
            this.Text = "MASTER-PROG+";
          }
          else
          {
            this.displayStatusWindow.Text = "MASTER-PROG Detectado.  Ident = " + serialUnitId;
            this.Text = "MASTER-PROG+ - " + serialUnitId;
          }
        }
        return true;
      }
      else
      {
        this.downloadPICkit2FirmwareToolStripMenuItem.Enabled = false;
        this.chkBoxVddOn.Enabled = false;
        this.numUpDnVDD.Enabled = false;
        this.deviceToolStripMenuItem.Enabled = false;
        this.disableGUIControls();
        if (piCkit2Usb == Constants.PICkit2USB.firmwareInvalid)
        {
          this.displayStatusWindow.BackColor = Color.Orange;
          this.downloadPICkit2FirmwareToolStripMenuItem.Enabled = true;
          this.displayStatusWindow.Text = "El ROM interno tiene un error!!\nContactar al sopore técnico.";
          this.oldFirmware = true;
          return false;
        }
        else if (piCkit2Usb == Constants.PICkit2USB.bootloader)
        {
          this.displayStatusWindow.BackColor = Color.Orange;
          this.downloadPICkit2FirmwareToolStripMenuItem.Enabled = true;
          this.displayStatusWindow.Text = "El ROM interno tiene un error!!\nContactar al sopore técnico.";
          this.bootLoad = true;
          return false;
        }
        else
        {
          this.displayStatusWindow.BackColor = Color.OrangeRed;
          this.pictureBox14.Visible = true;
          this.pictureBox12.Visible = false;
          this.pictureBox10.Visible = false;
          this.pictureBox4.Visible = false;
          this.pictureBox3.Visible = false;
          this.displayStatusWindow.Text = "MASTER-PROG no detectado! Revisar Conexiones y Reintentar. Usar el Botón AUTO/CONEX";
          return false;
        }
      }
    }

    private void disableGUIControls()
    {
      this.importFileToolStripMenuItem.Enabled = false;
      this.exportFileToolStripMenuItem.Enabled = false;
      this.programmerToolStripMenuItem.Enabled = false;
      this.setOSCCALToolStripMenuItem.Enabled = false;
      this.buttonRead.Enabled = false;
      this.button1.Enabled = true;
      this.buttonWrite.Enabled = false;
      this.buttonVerify.Enabled = false;
      this.buttonErase.Enabled = false;
      this.buttonBlankCheck.Enabled = false;
      this.checkBoxProgMemEnabled.Enabled = false;
      this.checkBoxProgMemEnabledAlt.Enabled = false;
      this.comboBoxProgMemView.Enabled = false;
      this.dataGridProgramMemory.ForeColor = SystemColors.GrayText;
      this.dataGridProgramMemory.Enabled = false;
      this.dataGridViewEEPROM.Visible = false;
      this.comboBoxEE.Enabled = false;
      this.checkBoxEEMem.Enabled = false;
      this.checkBoxEEDATAMemoryEnabledAlt.Enabled = false;
      this.buttonExportHex.Enabled = false;
      this.checkBoxAutoImportWrite.Enabled = false;
      this.troubleshhotToolStripMenuItem.Enabled = false;
      this.calibrateToolStripMenuItem.Enabled = false;
      this.programMemMultiWin.DisplayDisable();
      this.eepromDataMultiWin.DisplayDisable();
      this.UARTtoolStripMenuItem.Enabled = false;
      this.toolStripMenuItemLogicTool.Enabled = false;
    }

    private void partialEnableGUIControls()
    {
      this.importFileToolStripMenuItem.Enabled = true;
      this.exportFileToolStripMenuItem.Enabled = false;
      this.programmerToolStripMenuItem.Enabled = true;
      this.setOSCCALToolStripMenuItem.Enabled = false;
      this.writeDeviceToolStripMenuItem.Enabled = false;
      this.verifyToolStripMenuItem.Enabled = false;
      this.buttonRead.Enabled = true;
      this.buttonWrite.Enabled = false;
      this.buttonVerify.Enabled = false;
      this.buttonErase.Enabled = true;
      this.buttonBlankCheck.Enabled = true;
      this.checkBoxProgMemEnabled.Enabled = false;
      this.checkBoxProgMemEnabledAlt.Enabled = false;
      this.comboBoxProgMemView.Enabled = false;
      this.dataGridProgramMemory.ForeColor = SystemColors.GrayText;
      this.dataGridProgramMemory.Enabled = false;
      this.dataGridViewEEPROM.Visible = false;
      this.comboBoxEE.Enabled = false;
      this.checkBoxEEMem.Enabled = false;
      this.checkBoxEEDATAMemoryEnabledAlt.Enabled = false;
      this.buttonExportHex.Enabled = false;
      this.checkBoxAutoImportWrite.Enabled = false;
      this.troubleshhotToolStripMenuItem.Enabled = true;
      this.calibrateToolStripMenuItem.Enabled = true;
      this.programMemMultiWin.DisplayDisable();
      this.eepromDataMultiWin.DisplayDisable();
      this.UARTtoolStripMenuItem.Enabled = true;
      this.toolStripMenuItemLogicTool.Enabled = true;
    }

    private void semiEnableGUIControls()
    {
      this.importFileToolStripMenuItem.Enabled = true;
      this.exportFileToolStripMenuItem.Enabled = false;
      this.programmerToolStripMenuItem.Enabled = true;
      this.writeDeviceToolStripMenuItem.Enabled = true;
      this.verifyToolStripMenuItem.Enabled = true;
      this.setOSCCALToolStripMenuItem.Enabled = false;
      this.buttonRead.Enabled = true;
      this.buttonWrite.Enabled = true;
      this.buttonVerify.Enabled = true;
      this.buttonErase.Enabled = true;
      this.buttonBlankCheck.Enabled = true;
      this.checkBoxProgMemEnabled.Enabled = false;
      this.checkBoxProgMemEnabledAlt.Enabled = false;
      this.comboBoxProgMemView.Enabled = false;
      this.dataGridProgramMemory.ForeColor = SystemColors.GrayText;
      this.dataGridProgramMemory.Enabled = false;
      this.dataGridViewEEPROM.Visible = true;
      this.dataGridViewEEPROM.ForeColor = SystemColors.GrayText;
      this.comboBoxEE.Enabled = false;
      this.checkBoxEEMem.Enabled = false;
      this.checkBoxEEDATAMemoryEnabledAlt.Enabled = false;
      this.buttonExportHex.Enabled = false;
      this.checkBoxAutoImportWrite.Enabled = true;
      this.troubleshhotToolStripMenuItem.Enabled = true;
      this.calibrateToolStripMenuItem.Enabled = true;
      this.UARTtoolStripMenuItem.Enabled = true;
      this.toolStripMenuItemLogicTool.Enabled = true;
    }

    private void fullEnableGUIControls()
    {
      this.importFileToolStripMenuItem.Enabled = true;
      this.exportFileToolStripMenuItem.Enabled = true;
      this.programmerToolStripMenuItem.Enabled = true;
      this.writeDeviceToolStripMenuItem.Enabled = true;
      this.verifyToolStripMenuItem.Enabled = true;
      this.buttonRead.Enabled = true;
      this.buttonWrite.Enabled = true;
      this.buttonVerify.Enabled = true;
      this.buttonErase.Enabled = true;
      this.buttonBlankCheck.Enabled = true;
      this.checkBoxProgMemEnabled.Enabled = true;
      this.checkBoxProgMemEnabledAlt.Enabled = true;
      this.comboBoxProgMemView.Enabled = true;
      this.dataGridProgramMemory.Enabled = true;
      this.dataGridProgramMemory.ForeColor = SystemColors.WindowText;
      this.dataGridViewEEPROM.ForeColor = SystemColors.WindowText;
      this.buttonExportHex.Enabled = true;
      this.checkBoxAutoImportWrite.Enabled = true;
      this.troubleshhotToolStripMenuItem.Enabled = true;
      this.calibrateToolStripMenuItem.Enabled = true;
      this.programMemMultiWin.DisplayEnable();
      this.eepromDataMultiWin.DisplayEnable();
      this.UARTtoolStripMenuItem.Enabled = true;
      this.toolStripMenuItemLogicTool.Enabled = true;
    }

    private void updateGUIView()
    {
      if (this.multiWindow)
      {
        this.toolStripMenuItemSingleWindow.Checked = false;
        this.toolStripMenuItemMultiWindow.Checked = true;
        this.groupBoxProgMem.Location = new Point((int) (12.0 * (double) FormProgUSB.ScalefactW), (int) (300.0 * (double) FormProgUSB.ScalefactH));
        this.Size = new Size((int) (544.0 * (double) FormProgUSB.ScalefactW), (int) (320.0 * (double) FormProgUSB.ScalefactH));
        this.pictureBox1.Location = new Point((int) (423.0 * (double) FormProgUSB.ScalefactW), (int) (238.0 * (double) FormProgUSB.ScalefactH));
        this.buttonExportHex.Location = new Point((int) (311.0 * (double) FormProgUSB.ScalefactW), (int) (240.0 * (double) FormProgUSB.ScalefactH));
        this.checkBoxAutoImportWrite.Location = new Point((int) (201.0 * (double) FormProgUSB.ScalefactW), (int) (240.0 * (double) FormProgUSB.ScalefactH));
        this.checkBoxProgMemEnabledAlt.Visible = true;
        this.checkBoxEEDATAMemoryEnabledAlt.Visible = true;
        this.toolStripMenuItemShowProgramMemory.Enabled = true;
        this.toolStripMenuItemShowEEPROMData.Enabled = true;
        this.mainWindowAlwaysInFrontToolStripMenuItem.Enabled = true;
        if (this.mainWinOwnsMem)
          this.mainWindowAlwaysInFrontToolStripMenuItem.Checked = true;
        Point point = new Point(0, 0);
        if (this.programMemMultiWin.Location == point && this.eepromDataMultiWin.Location == point)
        {
          this.programMemMultiWin.Location = new Point(this.Location.X, this.Location.Y + (int) (321.0 * (double) FormProgUSB.ScalefactH));
          this.eepromDataMultiWin.Location = new Point(this.Location.X, this.Location.Y + (int) (530.0 * (double) FormProgUSB.ScalefactH));
        }
        if (this.multiWinPMemOpen)
        {
          ((Control) this.programMemMultiWin).Show();
          this.toolStripMenuItemShowProgramMemory.Checked = true;
        }
        if (this.multiWinEEMemOpen)
        {
          this.toolStripMenuItemShowEEPROMData.Checked = true;
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
          {
            this.toolStripMenuItemShowEEPROMData.Enabled = true;
            ((Control) this.eepromDataMultiWin).Show();
          }
          else
            this.toolStripMenuItemShowEEPROMData.Enabled = false;
        }
      }
      else
      {
        this.programMemMultiWin.Hide();
        this.eepromDataMultiWin.Hide();
        this.toolStripMenuItemSingleWindow.Checked = true;
        this.toolStripMenuItemMultiWindow.Checked = false;
        this.groupBoxProgMem.Location = new Point((int) (12.0 * (double) FormProgUSB.ScalefactW), (int) (236.0 * (double) FormProgUSB.ScalefactH));
        this.Size = new Size((int) (544.0 * (double) FormProgUSB.ScalefactW), (int) (670.0 * (double) FormProgUSB.ScalefactH));
        this.pictureBox1.Location = new Point((int) (423.0 * (double) FormProgUSB.ScalefactW), (int) (586.0 * (double) FormProgUSB.ScalefactH));
        this.buttonExportHex.Location = new Point((int) (423.0 * (double) FormProgUSB.ScalefactW), (int) (545.0 * (double) FormProgUSB.ScalefactH));
        this.checkBoxAutoImportWrite.Location = new Point((int) (423.0 * (double) FormProgUSB.ScalefactW), (int) (505.0 * (double) FormProgUSB.ScalefactH));
        this.checkBoxProgMemEnabledAlt.Visible = false;
        this.checkBoxEEDATAMemoryEnabledAlt.Visible = false;
        this.toolStripMenuItemShowProgramMemory.Enabled = false;
        this.toolStripMenuItemShowEEPROMData.Enabled = false;
        this.mainWindowAlwaysInFrontToolStripMenuItem.Enabled = false;
        this.toolStripMenuItemShowProgramMemory.Checked = false;
        this.toolStripMenuItemShowEEPROMData.Checked = false;
        this.mainWindowAlwaysInFrontToolStripMenuItem.Checked = false;
      }
      this.Focus();
    }

    private void updateGUI(bool updateMemories)
    {
      if (this.viewChanged)
      {
        this.updateGUIView();
        this.viewChanged = false;
      }
      this.statusGroupBox.Text = "Familia " + ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName + " Seleccionada";
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgEntryVPPScript > 0)
      {
        this.VppFirstToolStripMenuItem.Enabled = true;
      }
      else
      {
        this.VppFirstToolStripMenuItem.Checked = false;
        this.VppFirstToolStripMenuItem.Enabled = false;
      }
      this.displayDevice.Text = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].PartName;
      if (ProgCommand.ActivePart == 0)
      {
        if ((int) ProgCommand.LastDeviceID == 0)
          this.displayDevice.Text = "No Detectado";
        else
          this.displayDevice.Text = "No Soportado";
      }
      this.displayDevice.Update();
      this.displayRev.Text = " <" + string.Format("{0:X2}", (object) ProgCommand.LastDeviceRev) + ">";
      if (updateMemories)
      {
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords > 0)
        {
          this.labelUserIDs.Enabled = true;
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords < 9)
          {
            this.displayUserIDs.Visible = true;
            this.buttonShowIDMem.Visible = false;
            string str = "";
            for (int index = 0; index < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords; ++index)
              str = str + string.Format("{0:X2} ", (object) (uint) ((int) byte.MaxValue & (int) ProgCommand.DeviceBuffers.UserIDs[index]));
            this.displayUserIDs.Text = str;
          }
          else
          {
            this.displayUserIDs.Visible = false;
            this.buttonShowIDMem.Visible = true;
            if (DialogUserIDs.IDMemOpen)
              this.dialogIDMemory.UpdateIDMemoryGrid();
          }
        }
        else
        {
          this.labelUserIDs.Enabled = false;
          this.displayUserIDs.Text = "";
          this.displayUserIDs.Visible = false;
          this.buttonShowIDMem.Visible = false;
        }
      }
      if (this.checkBoxProgMemEnabled.Checked)
        this.displayUserIDs.ForeColor = SystemColors.WindowText;
      else
        this.displayUserIDs.ForeColor = SystemColors.GrayText;
      if (updateMemories)
        this.displayChecksum.Text = string.Format("{0:X4}", (object) ProgCommand.ComputeChecksum(this.enableCodeProtectToolStripMenuItem.Checked));
      if (updateMemories)
      {
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords == 0)
          this.labelConfig.Enabled = false;
        else
          this.labelConfig.Enabled = true;
        int index1 = 0;
        for (int index2 = 0; index2 < 2; ++index2)
        {
          for (int index3 = 0; index3 < 4; ++index3)
          {
            if (index1 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords)
            {
              uint num = ProgCommand.DeviceBuffers.ConfigWords[index1] & (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index1];
              if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPConfig - 1 == index1)
              {
                if (this.enableCodeProtectToolStripMenuItem.Checked && ((int) ProgCommand.DeviceBuffers.ConfigWords[(int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPConfig - 1] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask) == (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask)
                  num &= (uint) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask;
                if (this.enableDataProtectStripMenuItem.Checked && ((int) ProgCommand.DeviceBuffers.ConfigWords[(int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPConfig - 1] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask) == (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask)
                  num &= (uint) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask;
              }
              this.dataGridConfigWords[index3, index2].Value = (object) string.Format("{0:X4}", (object) num);
              ++index1;
            }
            else
              this.dataGridConfigWords[index3, index2].Value = (object) " ";
          }
        }
      }
      if (this.checkBoxProgMemEnabled.Checked)
        this.dataGridConfigWords.ForeColor = SystemColors.WindowText;
      else
        this.dataGridConfigWords.ForeColor = SystemColors.GrayText;
      if (ProgCommand.FamilyIsEEPROM() && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 1)
      {
        this.checkBoxA0CS.Visible = true;
        this.checkBoxA1CS.Visible = true;
        this.checkBoxA2CS.Visible = true;
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[3] == 1)
        {
          this.checkBoxA0CS.Enabled = true;
          this.checkBoxA1CS.Enabled = false;
          this.checkBoxA1CS.Checked = false;
          this.checkBoxA2CS.Enabled = false;
          this.checkBoxA2CS.Checked = false;
        }
        else if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[3] == 2)
        {
          this.checkBoxA0CS.Enabled = true;
          this.checkBoxA1CS.Enabled = true;
          this.checkBoxA2CS.Enabled = false;
          this.checkBoxA2CS.Checked = false;
        }
        else if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[3] == 3)
        {
          this.checkBoxA0CS.Enabled = true;
          this.checkBoxA1CS.Enabled = true;
          this.checkBoxA2CS.Enabled = true;
        }
        else
        {
          this.checkBoxA0CS.Enabled = false;
          this.checkBoxA0CS.Checked = false;
          this.checkBoxA1CS.Enabled = false;
          this.checkBoxA1CS.Checked = false;
          this.checkBoxA2CS.Enabled = false;
          this.checkBoxA2CS.Checked = false;
        }
      }
      else
      {
        this.checkBoxA0CS.Visible = false;
        this.checkBoxA1CS.Visible = false;
        this.checkBoxA2CS.Visible = false;
      }
      if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave)
      {
        this.setOSCCALToolStripMenuItem.Enabled = true;
        this.labelOSCCAL.Enabled = true;
        this.displayOSCCAL.Text = string.Format("{0:X4}", (object) ProgCommand.DeviceBuffers.OSCCAL);
        if (ProgCommand.ValidateOSSCAL())
        {
          this.labelOSSCALInvalid.Visible = false;
          this.displayOSCCAL.ForeColor = SystemColors.ControlText;
        }
        else
        {
          this.labelOSSCALInvalid.Visible = true;
          this.displayOSCCAL.ForeColor = Color.Red;
        }
      }
      else
      {
        this.labelOSSCALInvalid.Visible = false;
        this.setOSCCALToolStripMenuItem.Enabled = false;
        this.labelOSCCAL.Enabled = false;
        this.displayOSCCAL.Text = "";
      }
      if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask > 0U)
      {
        this.labelBandGap.Enabled = true;
        if ((int) ProgCommand.DeviceBuffers.BandGap == (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue)
          this.displayBandGap.Text = "";
        else
          this.displayBandGap.Text = string.Format("{0:X4}", (object) ProgCommand.DeviceBuffers.BandGap);
      }
      else
      {
        this.labelBandGap.Enabled = false;
        this.displayBandGap.Text = "";
      }
      switch (FormProgUSB.statusWindowColor)
      {
        case Constants.StatusColor.green:
          this.displayStatusWindow.BackColor = Color.Blue;
          break;
        case Constants.StatusColor.yellow:
          this.displayStatusWindow.BackColor = Color.Orange;
          break;
        case Constants.StatusColor.red:
          this.displayStatusWindow.BackColor = Color.OrangeRed;
          break;
        default:
          this.displayStatusWindow.BackColor = Color.Aqua;
          break;
      }
      FormProgUSB.statusWindowColor = Constants.StatusColor.normal;
      if (ProgCommand.FamilyIsEEPROM())
      {
        this.checkBoxMCLR.Checked = false;
        this.checkBoxMCLR.Enabled = false;
        this.MCLRtoolStripMenuItem.Checked = false;
        this.MCLRtoolStripMenuItem.Enabled = false;
        ProgCommand.HoldMCLR(false);
      }
      else
      {
        this.checkBoxMCLR.Enabled = true;
        this.MCLRtoolStripMenuItem.Enabled = true;
      }
      if (ProgCommand.FamilyIsPIC32())
      {
        this.fastProgrammingToolStripMenuItem.Checked = true;
        this.fastProgrammingToolStripMenuItem.Enabled = false;
      }
      else
        this.fastProgrammingToolStripMenuItem.Enabled = true;
      if (updateMemories)
      {
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask == 0)
        {
          this.enableCodeProtectToolStripMenuItem.Checked = false;
          this.enableCodeProtectToolStripMenuItem.Enabled = false;
        }
        else
          this.enableCodeProtectToolStripMenuItem.Enabled = true;
      }
      if (updateMemories && this.multiWindow)
      {
        if (!this.programMemMultiWin.InitDone)
          this.programMemMultiWin.InitProgMemDisplay(this.comboBoxProgMemView.SelectedIndex);
        this.programMemMultiWin.UpdateMultiWinProgMem(this.displayDataSource.Text);
      }
      if (updateMemories && !this.multiWindow)
      {
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
        {
          this.comboBoxProgMemView.SelectedIndex = 0;
          this.comboBoxProgMemView.Enabled = false;
        }
        else
          this.comboBoxProgMemView.Enabled = true;
        int num1;
        int num2;
        int num3;
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue <= 4095U)
        {
          if (ProgCommand.FamilyIsEEPROM())
          {
            num1 = 17;
            this.dataGridProgramMemory.Columns[0].Width = (int) (51.0 * (double) FormProgUSB.ScalefactW);
            num2 = 16;
            num3 = (int) (27.0 * (double) FormProgUSB.ScalefactW);
          }
          else
          {
            num1 = 17;
            this.dataGridProgramMemory.Columns[0].Width = (int) (35.0 * (double) FormProgUSB.ScalefactW);
            num2 = 16;
            num3 = (int) (28.0 * (double) FormProgUSB.ScalefactW);
          }
        }
        else if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
        {
          num1 = 5;
          this.dataGridProgramMemory.Columns[0].Width = (int) (99.0 * (double) FormProgUSB.ScalefactW);
          num2 = 4;
          num3 = (int) (96.0 * (double) FormProgUSB.ScalefactW);
        }
        else
        {
          num1 = 9;
          this.dataGridProgramMemory.Columns[0].Width = (int) (59.0 * (double) FormProgUSB.ScalefactW);
          num2 = 8;
          num3 = (int) (53.0 * (double) FormProgUSB.ScalefactW);
        }
        if (this.dataGridProgramMemory.ColumnCount != num1)
        {
          this.dataGridProgramMemory.Rows.Clear();
          this.dataGridProgramMemory.ColumnCount = num1;
        }
        for (int index = 1; index < this.dataGridProgramMemory.ColumnCount; ++index)
          this.dataGridProgramMemory.Columns[index].Width = num3;
        int num4 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].AddressIncrement;
        int num5;
        int num6;
        int num7;
        if (this.comboBoxProgMemView.SelectedIndex == 0)
        {
          num5 = num2;
          num6 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem / num5;
          if ((long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem % (long) num5 > 0L)
            ++num6;
          num7 = num4 * num2;
        }
        else
        {
          num5 = num2 / 2;
          num6 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem / num5;
          if ((long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem % (long) num5 > 0L)
            ++num6;
          num7 = num4 * (num2 / 2);
        }
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
          num6 += 2;
        if (this.dataGridProgramMemory.RowCount != num6)
        {
          this.dataGridProgramMemory.Rows.Clear();
          this.dataGridProgramMemory.RowCount = num6;
        }
        for (int index = 0; index < num5; ++index)
          this.dataGridProgramMemory.Columns[index + 1].ReadOnly = false;
        int num8 = this.dataGridProgramMemory.RowCount * num7 - 1;
        string format1 = "{0:X3}";
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
          format1 = "{0:X8}";
        else if (num8 > (int) ushort.MaxValue)
          format1 = "{0:X5}";
        else if (num8 > 4095)
          format1 = "{0:X4}";
        int num9 = ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem - (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BootFlash) / num5;
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
        {
          this.dataGridProgramMemory.ShowCellToolTips = false;
          this.dataGridProgramMemory[0, 0].Value = (object) "Mem. Programa";
          for (int index = 0; index < this.dataGridProgramMemory.ColumnCount; ++index)
          {
            this.dataGridProgramMemory[index, 0].Style.BackColor = SystemColors.ControlDark;
            this.dataGridProgramMemory[index, 0].ReadOnly = true;
          }
          int index1 = 1;
          int num10 = 486539264;
          for (; index1 <= num9; ++index1)
          {
            this.dataGridProgramMemory[0, index1].Value = (object) string.Format(format1, (object) num10);
            this.dataGridProgramMemory[0, index1].Style.BackColor = SystemColors.ControlLight;
            num10 += num7;
          }
          this.dataGridProgramMemory[0, num9 + 1].Value = (object) "Mem. Boot";
          for (int index2 = 0; index2 < this.dataGridProgramMemory.ColumnCount; ++index2)
          {
            this.dataGridProgramMemory[index2, num9 + 1].Style.BackColor = SystemColors.ControlDark;
            this.dataGridProgramMemory[index2, num9 + 1].ReadOnly = true;
          }
          int index3 = num9 + 2;
          int num11 = 532676608;
          for (; index3 < this.dataGridProgramMemory.RowCount; ++index3)
          {
            this.dataGridProgramMemory[0, index3].Value = (object) string.Format(format1, (object) num11);
            this.dataGridProgramMemory[0, index3].Style.BackColor = SystemColors.ControlLight;
            num11 += num7;
          }
        }
        else
        {
          this.dataGridProgramMemory.ShowCellToolTips = true;
          int index = 0;
          int num10 = 0;
          for (; index < this.dataGridProgramMemory.RowCount; ++index)
          {
            this.dataGridProgramMemory[0, index].Value = (object) string.Format(format1, (object) num10);
            this.dataGridProgramMemory[0, index].Style.BackColor = SystemColors.ControlLight;
            num10 += num7;
          }
        }
        string format2 = "{0:X2}";
        int numBytes = 1;
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > (uint) byte.MaxValue)
        {
          format2 = "{0:X3}";
          numBytes = 2;
        }
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 4095U)
        {
          format2 = "{0:X4}";
          numBytes = 2;
        }
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > (uint) ushort.MaxValue)
        {
          format2 = "{0:X6}";
          numBytes = 3;
        }
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
        {
          format2 = "{0:X8}";
          numBytes = 4;
        }
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16777215U)
        {
          int num10 = 0;
          for (int index1 = 1; index1 <= num9; ++index1)
          {
            for (int index2 = 0; index2 < num5; ++index2)
              this.dataGridProgramMemory[index2 + 1, index1].Value = (object) string.Format(format2, (object) ProgCommand.DeviceBuffers.ProgramMemory[num10++]);
          }
          for (int index1 = num9 + 2; index1 < this.dataGridProgramMemory.RowCount; ++index1)
          {
            for (int index2 = 0; index2 < num5; ++index2)
              this.dataGridProgramMemory[index2 + 1, index1].Value = (object) string.Format(format2, (object) ProgCommand.DeviceBuffers.ProgramMemory[num10++]);
          }
        }
        else
        {
          int index1 = 0;
          int num10 = 0;
          for (; index1 < this.dataGridProgramMemory.RowCount - 1; ++index1)
          {
            for (int index2 = 0; index2 < num5; ++index2)
            {
              this.dataGridProgramMemory[index2 + 1, index1].ToolTipText = string.Format(format1, (object) (num10 * num4));
              this.dataGridProgramMemory[index2 + 1, index1].Value = (object) string.Format(format2, (object) ProgCommand.DeviceBuffers.ProgramMemory[num10++]);
            }
          }
        }
        int index4 = this.dataGridProgramMemory.RowCount - 1;
        int num12 = index4 * num5;
        int num13 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem % num5;
        if (num13 == 0)
          num13 = num5;
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue <= 16777215U)
        {
          for (int index1 = 0; index1 < num5; ++index1)
          {
            if (index1 < num13)
            {
              this.dataGridProgramMemory[index1 + 1, index4].ToolTipText = string.Format(format1, (object) (num12 * num4));
              this.dataGridProgramMemory[index1 + 1, index4].Value = (object) string.Format(format2, (object) ProgCommand.DeviceBuffers.ProgramMemory[num12++]);
            }
            else
              this.dataGridProgramMemory[index1 + 1, index4].ReadOnly = true;
          }
        }
        if (this.comboBoxProgMemView.SelectedIndex >= 1)
        {
          for (int index1 = 0; index1 < num5; ++index1)
            this.dataGridProgramMemory.Columns[index1 + num5 + 1].ReadOnly = true;
          if (this.comboBoxProgMemView.SelectedIndex == 1)
          {
            int index1 = 0;
            int num10 = 0;
            for (; index1 < this.dataGridProgramMemory.RowCount; ++index1)
            {
              for (int index2 = 0; index2 < num5; ++index2)
              {
                this.dataGridProgramMemory[index2 + num5 + 1, index1].ToolTipText = string.Format(format1, (object) (num10 * num4));
                this.dataGridProgramMemory[index2 + num5 + 1, index1].Value = (object) Utilities.ConvertIntASCII((int) ProgCommand.DeviceBuffers.ProgramMemory[num10++], numBytes);
              }
            }
          }
          else
          {
            int index1 = 0;
            int num10 = 0;
            for (; index1 < this.dataGridProgramMemory.RowCount; ++index1)
            {
              for (int index2 = 0; index2 < num5; ++index2)
              {
                this.dataGridProgramMemory[index2 + num5 + 1, index1].ToolTipText = string.Format(format1, (object) (num10 * num4));
                this.dataGridProgramMemory[index2 + num5 + 1, index1].Value = (object) Utilities.ConvertIntASCIIReverse((int) ProgCommand.DeviceBuffers.ProgramMemory[num10++], numBytes);
              }
            }
          }
        }
        if (this.dataGridProgramMemory.FirstDisplayedCell != null && !this.progMemJustEdited)
        {
          int rowIndex = this.dataGridProgramMemory.FirstDisplayedCell.RowIndex;
          this.dataGridProgramMemory.MultiSelect = false;
          this.dataGridProgramMemory[0, rowIndex].Selected = true;
          this.dataGridProgramMemory[0, rowIndex].Selected = false;
          this.dataGridProgramMemory.MultiSelect = true;
        }
        else if (this.dataGridProgramMemory.FirstDisplayedCell == null)
        {
          this.dataGridProgramMemory.MultiSelect = false;
          this.dataGridProgramMemory[0, 0].Selected = true;
          this.dataGridProgramMemory[0, 0].Selected = false;
          this.dataGridProgramMemory.MultiSelect = true;
        }
        this.progMemJustEdited = false;
      }
      if (updateMemories && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
      {
        this.checkBoxProgMemEnabled.Enabled = true;
        this.comboBoxEE.Enabled = true;
        if (!this.checkBoxEEMem.Enabled)
        {
          this.checkBoxEEMem.Checked = true;
          this.checkBoxEEDATAMemoryEnabledAlt.Checked = true;
        }
        this.checkBoxEEMem.Enabled = true;
        this.enableDataProtectStripMenuItem.Enabled = true;
        this.checkBoxEEDATAMemoryEnabledAlt.Enabled = true;
        this.checkBoxProgMemEnabledAlt.Enabled = true;
        if (this.multiWindow)
        {
          if (!this.eepromDataMultiWin.InitDone)
            this.eepromDataMultiWin.InitMemDisplay(this.comboBoxEE.SelectedIndex);
          if (!this.toolStripMenuItemShowEEPROMData.Enabled)
          {
            this.toolStripMenuItemShowEEPROMData.Enabled = true;
            if (this.multiWinEEMemOpen)
            {
              ((Control) this.eepromDataMultiWin).Show();
              this.Focus();
            }
          }
          this.eepromDataMultiWin.UpdateMultiWinMem();
        }
        else
        {
          this.dataGridViewEEPROM.Visible = true;
          int num1 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemAddressIncrement;
          int num2 = num1;
          int num3;
          int num4;
          int num5;
          if (num1 == 1 && (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue != 4095)
          {
            num3 = 17;
            this.dataGridViewEEPROM.Columns[0].Width = (int) (32.0 * (double) FormProgUSB.ScalefactW);
            num4 = 16;
            num5 = (int) (21.0 * (double) FormProgUSB.ScalefactW);
          }
          else
          {
            num3 = 9;
            this.dataGridViewEEPROM.Columns[0].Width = (int) (40.0 * (double) FormProgUSB.ScalefactW);
            num4 = 8;
            num5 = (int) (41.0 * (double) FormProgUSB.ScalefactW);
          }
          if (this.dataGridViewEEPROM.ColumnCount != num3)
          {
            this.dataGridViewEEPROM.Rows.Clear();
            this.dataGridViewEEPROM.ColumnCount = num3;
          }
          this.dataGridViewEEPROM.Columns[0].ReadOnly = true;
          for (int index = 1; index < this.dataGridViewEEPROM.ColumnCount; ++index)
            this.dataGridViewEEPROM.Columns[index].Width = num5;
          int num6;
          int num7;
          int num8;
          if (this.comboBoxEE.SelectedIndex == 0)
          {
            int num9 = num4;
            num6 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem / num9;
            num7 = num1 * num4;
            num8 = num4;
          }
          else
          {
            num8 = num4 / 2;
            num6 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem / num8;
            num7 = num1 * (num4 / 2);
          }
          if (this.dataGridViewEEPROM.RowCount != num6)
          {
            this.dataGridViewEEPROM.Rows.Clear();
            this.dataGridViewEEPROM.RowCount = num6;
          }
          int num10 = this.dataGridViewEEPROM.RowCount * num7 - 1;
          string format1 = "{0:X2}";
          if (num10 > (int) byte.MaxValue)
            format1 = "{0:X3}";
          else if (num10 > 4095)
            format1 = "{0:X4}";
          int index1 = 0;
          int num11 = 0;
          for (; index1 < this.dataGridViewEEPROM.RowCount; ++index1)
          {
            this.dataGridViewEEPROM[0, index1].Value = (object) string.Format(format1, (object) num11);
            this.dataGridViewEEPROM[0, index1].Style.BackColor = SystemColors.ControlLight;
            num11 += num7;
          }
          string format2 = "{0:X2}";
          int numBytes = 1;
          if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemAddressIncrement > 1)
          {
            format2 = "{0:X4}";
            numBytes = 2;
          }
          if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue == 4095)
          {
            format2 = "{0:X3}";
            numBytes = 2;
          }
          for (int index2 = 0; index2 < num8; ++index2)
            this.dataGridViewEEPROM.Columns[index2 + 1].ReadOnly = false;
          int index3 = 0;
          int num12 = 0;
          for (; index3 < this.dataGridViewEEPROM.RowCount; ++index3)
          {
            for (int index2 = 0; index2 < num8; ++index2)
            {
              this.dataGridViewEEPROM[index2 + 1, index3].ToolTipText = string.Format(format1, (object) (num12 * num2));
              this.dataGridViewEEPROM[index2 + 1, index3].Value = (object) string.Format(format2, (object) ProgCommand.DeviceBuffers.EEPromMemory[num12++]);
            }
          }
          if (this.comboBoxEE.SelectedIndex >= 1)
          {
            for (int index2 = 0; index2 < num8; ++index2)
              this.dataGridViewEEPROM.Columns[index2 + num8 + 1].ReadOnly = true;
            if (this.comboBoxEE.SelectedIndex == 1)
            {
              int index2 = 0;
              int num9 = 0;
              for (; index2 < this.dataGridViewEEPROM.RowCount; ++index2)
              {
                for (int index4 = 0; index4 < num8; ++index4)
                {
                  this.dataGridViewEEPROM[index4 + num8 + 1, index2].ToolTipText = string.Format(format1, (object) (num9 * num2));
                  this.dataGridViewEEPROM[index4 + num8 + 1, index2].Value = (object) Utilities.ConvertIntASCII((int) ProgCommand.DeviceBuffers.EEPromMemory[num9++], numBytes);
                }
              }
            }
            else
            {
              int index2 = 0;
              int num9 = 0;
              for (; index2 < this.dataGridViewEEPROM.RowCount; ++index2)
              {
                for (int index4 = 0; index4 < num8; ++index4)
                {
                  this.dataGridViewEEPROM[index4 + num8 + 1, index2].ToolTipText = string.Format(format1, (object) (num9 * num2));
                  this.dataGridViewEEPROM[index4 + num8 + 1, index2].Value = (object) Utilities.ConvertIntASCIIReverse((int) ProgCommand.DeviceBuffers.EEPromMemory[num9++], numBytes);
                }
              }
            }
          }
          if (this.dataGridViewEEPROM.FirstDisplayedCell != null && !this.eeMemJustEdited)
          {
            int rowIndex = this.dataGridViewEEPROM.FirstDisplayedCell.RowIndex;
            this.dataGridViewEEPROM.MultiSelect = false;
            this.dataGridViewEEPROM[0, rowIndex].Selected = true;
            this.dataGridViewEEPROM[0, rowIndex].Selected = false;
            this.dataGridViewEEPROM.MultiSelect = true;
          }
          else if (this.dataGridViewEEPROM.FirstDisplayedCell == null)
          {
            this.dataGridViewEEPROM.MultiSelect = false;
            this.dataGridViewEEPROM[0, 0].Selected = true;
            this.dataGridViewEEPROM[0, 0].Selected = false;
            this.dataGridViewEEPROM.MultiSelect = true;
          }
          this.eeMemJustEdited = false;
        }
      }
      else if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem == 0)
      {
        this.dataGridViewEEPROM.Visible = false;
        this.comboBoxEE.Enabled = false;
        this.checkBoxEEMem.Checked = false;
        this.checkBoxEEDATAMemoryEnabledAlt.Checked = false;
        this.checkBoxEEMem.Enabled = false;
        this.checkBoxEEDATAMemoryEnabledAlt.Enabled = false;
        this.enableDataProtectStripMenuItem.Enabled = false;
        this.enableDataProtectStripMenuItem.Checked = false;
        this.checkBoxProgMemEnabled.Checked = true;
        this.checkBoxProgMemEnabledAlt.Checked = true;
        this.checkBoxProgMemEnabled.Enabled = false;
        this.checkBoxProgMemEnabledAlt.Enabled = false;
        this.eepromDataMultiWin.Hide();
        this.toolStripMenuItemShowEEPROMData.Enabled = false;
      }
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask != 0 && ((int) ProgCommand.DeviceBuffers.ConfigWords[(int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPConfig - 1] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask) != (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask)
      {
        this.enableCodeProtectToolStripMenuItem.Checked = false;
        this.enableCodeProtectToolStripMenuItem.Enabled = false;
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask == 0)
        {
          this.enableDataProtectStripMenuItem.Checked = false;
          this.enableDataProtectStripMenuItem.Enabled = false;
        }
      }
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0 && ((int) ProgCommand.DeviceBuffers.ConfigWords[(int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPConfig - 1] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask) != (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask)
      {
        this.enableDataProtectStripMenuItem.Checked = true;
        this.enableDataProtectStripMenuItem.Enabled = false;
      }
      if (this.enableCodeProtectToolStripMenuItem.Checked || this.enableDataProtectStripMenuItem.Checked)
      {
        this.labelCodeProtect.Visible = true;
        if (this.enableCodeProtectToolStripMenuItem.Checked && this.enableDataProtectStripMenuItem.Checked)
          this.labelCodeProtect.Text = "Proteger FLASH + EEPROM";
        else if (this.enableCodeProtectToolStripMenuItem.Checked)
          this.labelCodeProtect.Text = "Proteger FLASH (PROGRAMA)";
        else
          this.labelCodeProtect.Text = "Proteger EEPROM (DATOS)";
      }
      else
        this.labelCodeProtect.Visible = false;
      if (!this.checkBoxProgMemEnabled.Checked)
      {
        this.displayEEProgInfo.Text = "Sólo La Memoria EEPROM Es Accesible";
        this.displayEEProgInfo.Visible = true;
        this.eepromDataMultiWin.DisplayEETextOn("Sólo La Memoria EEPROM Es Accesible");
      }
      else if (!this.checkBoxEEMem.Checked && this.checkBoxEEMem.Enabled)
      {
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemEraseScript != 0)
        {
          this.displayEEProgInfo.Text = "Datos EEPROM No Modififcables";
          this.eepromDataMultiWin.DisplayEETextOn("Proteger Datos EEPROM Al Escribir");
        }
        else
        {
          this.displayEEProgInfo.Text = "Proteger Datos EEPROM Al Escribir";
          this.eepromDataMultiWin.DisplayEETextOn("Proteger Datos EEPROM Al Escribir");
        }
        this.displayEEProgInfo.Visible = true;
      }
      else
      {
        this.displayEEProgInfo.Visible = false;
        this.eepromDataMultiWin.DisplayEETextOff();
      }
      if (FormProgUSB.TestMemoryEnabled && FormProgUSB.TestMemoryOpen)
      {
        FormProgUSB.formTestMem.UpdateTestMemForm();
        if (updateMemories)
          FormProgUSB.formTestMem.UpdateTestMemoryGrid();
      }
      if (!this.testConnected)
        return;
      this.updateTestGUI();
    }

    private void updateTestGUI()
    {
    }

    private void progMemViewChanged(object sender, EventArgs e)
    {
      this.updateGUI(true);
    }

    private void buildDeviceMenu()
    {
      for (int index1 = 0; index1 < ProgCommand.DevFile.Families.Length; ++index1)
      {
        for (int index2 = 0; index2 < ProgCommand.DevFile.Families.Length; ++index2)
        {
          if ((int) ProgCommand.DevFile.Families[index2].FamilyType == index1)
          {
            string text = ProgCommand.DevFile.Families[index2].FamilyName;
            int length = text.IndexOf("/");
            if ((int) text[0] != 35)
            {
              if (length < 0)
              {
                this.deviceToolStripMenuItem.DropDown.Items.Add(text);
              }
              else
              {
                int count = this.deviceToolStripMenuItem.DropDownItems.Count;
                for (int index3 = 0; index3 < count; ++index3)
                {
                  if (text.Substring(0, length) == this.deviceToolStripMenuItem.DropDown.Items[index3].ToString())
                    ((ToolStripDropDownItem) this.deviceToolStripMenuItem.DropDownItems[index3]).DropDown.Items.Add(text.Substring(length + 1));
                  else if (index3 == count - 1)
                  {
                    this.deviceToolStripMenuItem.DropDown.Items.Add(text.Substring(0, length));
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem) this.deviceToolStripMenuItem.DropDownItems[index3 + 1];
                    toolStripMenuItem.DropDown.Items.Add(text.Substring(length + 1));
                    toolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.deviceFamilyClick);
                  }
                }
              }
            }
          }
        }
      }
      this.deviceToolStripMenuItem.Enabled = true;
    }

    private void guiVddControl(object sender, EventArgs e)
    {
      this.vddControl(false, false);
    }

    private void vddControl(bool force, bool forceState)
    {
      if (force)
        this.chkBoxVddOn.Checked = forceState;
      bool @checked = this.chkBoxVddOn.Checked;
      if (!this.detectPICkit2(false, false))
        return;
      if (@checked)
      {
        if (!this.lookForPoweredTarget(true))
        {
          this.chkBoxVddOn.Checked = true;
          ProgCommand.SetVDDVoltage((float) this.numUpDnVDD.Value, 0.85f);
          ProgCommand.VddOn();
          if (!this.checkForPowerErrors())
            return;
          ProgCommand.VddOff();
        }
        else
        {
          this.checkForPowerErrors();
          ProgCommand.VddOff();
        }
      }
      else
      {
        this.chkBoxVddOn.Checked = false;
        ProgCommand.VddOff();
      }
    }

    private void guiChangeVDD(object sender, EventArgs e)
    {
      if (!this.detectPICkit2(false, false))
        return;
      ProgCommand.SetVDDVoltage((float) this.numUpDnVDD.Value, 0.85f);
    }

    private void pickitFormClosing(object sender, FormClosingEventArgs e)
    {
      this.SaveINI();
    }

    private void fileMenuExit(object sender, EventArgs e)
    {
      this.Close();
    }

    private void menuFileImportHex(object sender, EventArgs e)
    {
      if (ProgCommand.FamilyIsKeeloq())
        this.openHexFileDialog.Filter = "Archivos HEX|*.hex;*.num|Todos Los Archivos|*.*";
      else
        this.openHexFileDialog.Filter = "Archivos HEX|*.hex";
      int num = (int) this.openHexFileDialog.ShowDialog();
      this.updateGUI(true);
    }

    private void importHexFile(object sender, CancelEventArgs e)
    {
      this.importHexFileGo();
    }

    private bool importHexFileGo()
    {
      int num = ProgCommand.ActivePart;
      if (!this.preProgrammingCheck(ProgCommand.GetActiveFamily()))
      {
        this.displayStatusWindow.Text = "Error en Dispositivo, archivo HEX no abierto!.";
        FormProgUSB.statusWindowColor = Constants.StatusColor.red;
        this.displayDataSource.Text = "Archivo Nulo";
        this.importGo = false;
        return false;
      }
      else
      {
        if (num != ProgCommand.ActivePart || (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem == 0 || this.checkBoxProgMemEnabled.Checked && this.checkBoxEEMem.Checked)
        {
          ProgCommand.ResetBuffers();
        }
        else
        {
          if (this.checkBoxProgMemEnabled.Checked)
          {
            ProgCommand.DeviceBuffers.ClearProgramMemory(ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue);
            ProgCommand.DeviceBuffers.ClearConfigWords(ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank);
            ProgCommand.DeviceBuffers.ClearUserIDs((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].UserIDBytes, ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue);
          }
          if (this.checkBoxEEMem.Checked)
            ProgCommand.DeviceBuffers.ClearEEPromMemory((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemAddressIncrement, ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue);
        }
        if (FormProgUSB.TestMemoryEnabled && FormProgUSB.TestMemoryOpen && FormProgUSB.formTestMem.HexImportExportTM())
          FormProgUSB.formTestMem.ClearTestMemory();
        switch (ImportExportHex.ImportHexFile(this.openHexFileDialog.FileName, this.checkBoxProgMemEnabled.Checked, this.checkBoxEEMem.Checked))
        {
          case Constants.FileRead.success:
            this.displayStatusWindow.Text = "Archivo HEX Cargado Correctamente.";
            if (this.multiWindow)
              this.displayDataSource.Text = this.openHexFileDialog.FileName;
            else
              this.displayDataSource.Text = this.shortenHex(this.openHexFileDialog.FileName);
            this.checkImportFile = true;
            this.importGo = true;
            break;
          case Constants.FileRead.noconfig:
            FormProgUSB.statusWindowColor = Constants.StatusColor.yellow;
            this.displayStatusWindow.Text = "AVISO:Faltan los Bits de Configuración en el Archivo HEX! Consultar el Instuctivo para Solucionar este Problema.";
            if (this.multiWindow)
              this.displayDataSource.Text = this.openHexFileDialog.FileName;
            else
              this.displayDataSource.Text = this.shortenHex(this.openHexFileDialog.FileName);
            this.checkImportFile = true;
            this.importGo = true;
            break;
          case Constants.FileRead.partialcfg:
            FormProgUSB.statusWindowColor = Constants.StatusColor.yellow;
            this.displayStatusWindow.Text = "AVISO:Faltan los Bits de Configuración en el Archivo HEX! Consultar el Instuctivo para Solucionar este Problema.";
            if (this.multiWindow)
              this.displayDataSource.Text = this.openHexFileDialog.FileName;
            else
              this.displayDataSource.Text = this.shortenHex(this.openHexFileDialog.FileName);
            this.checkImportFile = true;
            this.importGo = true;
            break;
          case Constants.FileRead.largemem:
            FormProgUSB.statusWindowColor = Constants.StatusColor.yellow;
            this.displayStatusWindow.Text = "El Archivo HEX Supera la Capacidad Máxima! Revisar Tipo/Archivo y Reintentar.";
            if (this.multiWindow)
              this.displayDataSource.Text = this.openHexFileDialog.FileName;
            else
              this.displayDataSource.Text = this.shortenHex(this.openHexFileDialog.FileName);
            this.checkImportFile = true;
            this.importGo = true;
            break;
          default:
            FormProgUSB.statusWindowColor = Constants.StatusColor.red;
            this.displayStatusWindow.Text = "Error al abrir el HEX!";
            this.displayDataSource.Text = "Archivo Nulo";
            this.checkImportFile = false;
            this.importGo = false;
            ProgCommand.ResetBuffers();
            break;
        }
        if (this.checkImportFile)
        {
          if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave)
          {
            ProgCommand.SetMCLRTemp(true);
            ProgCommand.VddOn();
            ProgCommand.ReadOSSCAL();
            ProgCommand.DeviceBuffers.ProgramMemory[ProgCommand.DeviceBuffers.ProgramMemory.Length - 1] = ProgCommand.DeviceBuffers.OSCCAL;
          }
          if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask > 0U)
          {
            ProgCommand.SetMCLRTemp(true);
            ProgCommand.VddOn();
            ProgCommand.ReadBandGap();
          }
          this.conditionalVDDOff();
          bool flag1 = false;
          bool flag2 = false;
          do
          {
            if (this.openHexFileDialog.FileName == this.hex4 || flag1)
            {
              if (!this.hex4ToolStripMenuItem.Visible && this.hex3.Length > 3)
                this.hex4ToolStripMenuItem.Visible = true;
              this.hex4 = this.hex3;
              this.hex4ToolStripMenuItem.Text = "&4" + this.hex3ToolStripMenuItem.Text.Substring(2);
              flag1 = true;
              flag2 = true;
            }
            if (this.openHexFileDialog.FileName == this.hex3 || flag1)
            {
              if (!this.hex3ToolStripMenuItem.Visible && this.hex2.Length > 3)
                this.hex3ToolStripMenuItem.Visible = true;
              this.hex3 = this.hex2;
              this.hex3ToolStripMenuItem.Text = "&3" + this.hex2ToolStripMenuItem.Text.Substring(2);
              flag1 = true;
              flag2 = true;
            }
            if (this.openHexFileDialog.FileName == this.hex2 || flag1)
            {
              if (!this.hex2ToolStripMenuItem.Visible && this.hex1.Length > 3)
                this.hex2ToolStripMenuItem.Visible = true;
              this.hex2 = this.hex1;
              this.hex2ToolStripMenuItem.Text = "&2" + this.hex1ToolStripMenuItem.Text.Substring(2);
              flag2 = true;
            }
            flag1 = true;
            if (this.openHexFileDialog.FileName == this.hex1)
              flag2 = true;
          }
          while (!flag2);
          if (!this.hex1ToolStripMenuItem.Visible)
          {
            this.hex1ToolStripMenuItem.Visible = true;
            this.toolStripMenuItem5.Visible = true;
          }
          this.hex1 = this.openHexFileDialog.FileName;
          this.hex1ToolStripMenuItem.Text = "&1 " + this.shortenHex(this.openHexFileDialog.FileName);
        }
        return this.checkImportFile;
      }
    }

    private void menuFileExportHex(object sender, EventArgs e)
    {
      if (ProgCommand.FamilyIsKeeloq())
      {
        int num1 = (int) MessageBox.Show("Función Inválida Para\nEste Tipo de Dispositivo!");
      }
      else
      {
        int num2 = (int) this.saveHexFileDialog.ShowDialog();
      }
    }

    private void exportHexFile(object sender, CancelEventArgs e)
    {
      ImportExportHex.ExportHexFile(this.saveHexFileDialog.FileName, this.checkBoxProgMemEnabled.Checked, this.checkBoxEEMem.Checked);
    }

    private bool preProgrammingCheck(int family)
    {
      this.statusGroupBox.Update();
      if (ProgCommand.LearnMode)
      {
        ProgCommand.SetVDDVoltage((float) this.numUpDnVDD.Value, 0.85f);
        return true;
      }
      else
      {
        if (!this.detectPICkit2(false, false))
          return false;
        if (this.checkForPowerErrors())
        {
          this.updateGUI(false);
          return false;
        }
        else
        {
          this.lookForPoweredTarget(!this.timerAutoImportWrite.Enabled);
          if (ProgCommand.DevFile.Families[family].PartDetect)
          {
            if (ProgCommand.DetectDevice(family, false, this.chkBoxVddOn.Checked))
            {
              this.setGUIVoltageLimits(false);
              this.fullEnableGUIControls();
              this.updateGUI(false);
            }
            else
            {
              this.semiEnableGUIControls();
              FormProgUSB.statusWindowColor = Constants.StatusColor.yellow;
              this.displayStatusWindow.Text = "Dispositivo No Encontrado!";
              if ((double) ProgCommand.DevFile.Families[family].Vpp < 1.0)
              {
                Label label = this.displayStatusWindow;
                string str = label.Text + "\nChecar Capacitor en VDDCORE/VCAP !";
                label.Text = str;
              }
              this.checkForPowerErrors();
              this.updateGUI(false);
              return false;
            }
          }
          else
          {
            ProgCommand.SetMCLRTemp(true);
            ProgCommand.SetVDDVoltage((float) this.numUpDnVDD.Value, 0.85f);
            ProgCommand.VddOn();
            ProgCommand.RunScript(0, 1);
            Thread.Sleep(300);
            ProgCommand.RunScript(1, 1);
            this.conditionalVDDOff();
            if (this.checkForPowerErrors())
            {
              this.updateGUI(false);
              return false;
            }
          }
          ProgCommand.SetVDDVoltage((float) this.numUpDnVDD.Value, 0.85f);
          if (!this.checkBoxEEMem.Enabled && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
            this.checkBoxEEMem.Checked = true;
          return true;
        }
      }
    }

    private void readDevice(object sender, EventArgs e)
    {
      this.deviceRead();
    }

    private void deviceRead()
    {
      if (ProgCommand.FamilyIsKeeloq())
      {
        this.displayStatusWindow.Text = "Función Inválida Para el Tipo Seleccionado!";
        FormProgUSB.statusWindowColor = Constants.StatusColor.yellow;
        this.updateGUI(false);
      }
      else
      {
        if (!this.preProgrammingCheck(ProgCommand.GetActiveFamily()))
          return;
        if (ProgCommand.FamilyIsPIC32())
        {
          FormProgUSB.statusWindowColor = !PIC32MXFunctions.PIC32Read() ? Constants.StatusColor.red : Constants.StatusColor.normal;
          this.conditionalVDDOff();
          this.updateGUI(true);
        }
        else
        {
          this.displayStatusWindow.Text = "Leyendo Dispositivo...\n";
          this.Update();
          byte[] numArray1 = new byte[128];
          ProgCommand.SetMCLRTemp(true);
          ProgCommand.VddOn();
          if (this.checkBoxProgMemEnabled.Checked)
          {
            Label label = this.displayStatusWindow;
            string str = label.Text + "Flash + ";
            label.Text = str;
            this.Update();
            ProgCommand.RunScript(0, 1);
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrSetScript != 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrBytes != 0)
            {
              if (ProgCommand.FamilyIsEEPROM())
              {
                ProgCommand.DownloadAddress3MSBFirst(this.eeprom24BitAddress(0, false));
                ProgCommand.RunScript(5, 1);
                if (this.eeprom_CheckBusErrors())
                  return;
              }
              else
              {
                ProgCommand.DownloadAddress3(0);
                ProgCommand.RunScript(5, 1);
              }
            }
            int num1 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
            int num2 = 128 / ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords * num1);
            int num3 = num2 * (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords;
            int wordsWritten = 0;
            this.progressBar1.Value = 0;
            this.progressBar1.Maximum = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem / num3;
            do
            {
              if (ProgCommand.FamilyIsEEPROM())
              {
                if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 1 && wordsWritten > (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] && wordsWritten % ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] + 1) == 0)
                {
                  ProgCommand.DownloadAddress3MSBFirst(this.eeprom24BitAddress(wordsWritten, false));
                  ProgCommand.RunScript(5, 1);
                }
                ProgCommand.Download3Multiples(this.eeprom24BitAddress(wordsWritten, true), num2, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords);
              }
              ProgCommand.RunScriptUploadNoLen2(3, num2);
              Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
              ProgCommand.GetUpload();
              Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
              int num4 = 0;
              for (int index1 = 0; index1 < num3; ++index1)
              {
                int num5 = 0;
                byte[] numArray2 = numArray1;
                int num6 = num4;
                int num7 = num5;
                int num8 = 1;
                int num9 = num7 + num8;
                int index2 = num6 + num7;
                uint num10 = (uint) numArray2[index2];
                if (num9 < num1)
                  num10 |= (uint) numArray1[num4 + num9++] << 8;
                if (num9 < num1)
                  num10 |= (uint) numArray1[num4 + num9++] << 16;
                if (num9 < num1)
                  num10 |= (uint) numArray1[num4 + num9++] << 24;
                num4 += num9;
                if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
                  num10 = num10 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
                ProgCommand.DeviceBuffers.ProgramMemory[wordsWritten++] = num10;
                if ((long) wordsWritten != (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem)
                {
                  if (wordsWritten % 32768 == 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrSetScript != 0 && ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrBytes != 0 && ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > (uint) ushort.MaxValue))
                  {
                    ProgCommand.DownloadAddress3(65536 * (wordsWritten / 32768));
                    ProgCommand.RunScript(5, 1);
                    break;
                  }
                }
                else
                  break;
              }
              this.progressBar1.PerformStep();
            }
            while ((long) wordsWritten < (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem);
            ProgCommand.RunScript(1, 1);
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 3 && num1 == 2 && ProgCommand.FamilyIsEEPROM())
            {
              for (int index = 0; index < ProgCommand.DeviceBuffers.ProgramMemory.Length; ++index)
              {
                uint num4 = (uint) ((int) ProgCommand.DeviceBuffers.ProgramMemory[index] << 8 & 65280);
                ProgCommand.DeviceBuffers.ProgramMemory[index] >>= 8;
                ProgCommand.DeviceBuffers.ProgramMemory[index] |= num4;
              }
            }
          }
          if (this.checkBoxEEMem.Checked && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
            this.readEEPROM();
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords > 0 && this.checkBoxProgMemEnabled.Checked)
          {
            Label label = this.displayStatusWindow;
            string str = label.Text + "Bits ID + ";
            label.Text = str;
            this.Update();
            ProgCommand.RunScript(0, 1);
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDRdPrepScript > 0)
              ProgCommand.RunScript(16, 1);
            int num1 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].UserIDBytes;
            int num2 = 0;
            int num3 = 0;
            ProgCommand.RunScriptUploadNoLen(17, 1);
            Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
            if ((long) ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords * num1) > 64L)
            {
              ProgCommand.UploadDataNoLen();
              Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
            }
            ProgCommand.RunScript(1, 1);
            do
            {
              int num4 = 0;
              byte[] numArray2 = numArray1;
              int num5 = num3;
              int num6 = num4;
              int num7 = 1;
              int num8 = num6 + num7;
              int index = num5 + num6;
              uint num9 = (uint) numArray2[index];
              if (num8 < num1)
                num9 |= (uint) numArray1[num3 + num8++] << 8;
              if (num8 < num1)
                num9 |= (uint) numArray1[num3 + num8++] << 16;
              if (num8 < num1)
                num9 |= (uint) numArray1[num3 + num8++] << 24;
              num3 += num8;
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
                num9 = num9 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
              ProgCommand.DeviceBuffers.UserIDs[num2++] = num9;
            }
            while (num2 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords);
          }
          int num11 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
          int num12 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
          if (num12 > 0 && (long) num11 >= (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem && this.checkBoxProgMemEnabled.Checked)
          {
            Label label = this.displayStatusWindow;
            string str = label.Text + "Bits Config  ";
            label.Text = str;
            this.Update();
            ProgCommand.ReadConfigOutsideProgMem();
            if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask > 0U)
              ProgCommand.DeviceBuffers.BandGap = ProgCommand.DeviceBuffers.ConfigWords[0] & ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask;
          }
          else if (num12 > 0 && this.checkBoxProgMemEnabled.Checked)
          {
            Label label = this.displayStatusWindow;
            string str = label.Text + "Bits Config  ";
            label.Text = str;
            this.Update();
            for (int index = 0; index < num12; ++index)
              ProgCommand.DeviceBuffers.ConfigWords[index] = ProgCommand.DeviceBuffers.ProgramMemory[num11 + index];
          }
          if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave)
            ProgCommand.ReadOSSCAL();
          if (FormProgUSB.TestMemoryEnabled && FormProgUSB.TestMemoryOpen)
            FormProgUSB.formTestMem.ReadTestMemory();
          this.conditionalVDDOff();
          Label label1 = this.displayStatusWindow;
          string str1 = label1.Text + "Listo!";
          label1.Text = str1;
          this.displayDataSource.Text = "Leer desde " + ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].PartName;
          this.checkImportFile = false;
          this.updateGUI(true);
        }
      }
    }

    private void readEEPROM()
    {
      byte[] numArray1 = new byte[128];
      Label label = this.displayStatusWindow;
      string str = label.Text + "EEPROM + ";
      label.Text = str;
      this.Update();
      ProgCommand.RunScript(0, 1);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdPrepScript > 0)
      {
        if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemHexBytes == 4)
          ProgCommand.DownloadAddress3((int) (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEAddr / 2U));
        else
          ProgCommand.DownloadAddress3(0);
        ProgCommand.RunScript(8, 1);
      }
      int num1 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemBytesPerWord;
      int repetitions = 128 / ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdLocations * num1);
      int num2 = repetitions * (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdLocations;
      int num3 = 0;
      uint eeBlank = this.getEEBlank();
      this.progressBar1.Value = 0;
      this.progressBar1.Maximum = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem / num2;
      do
      {
        ProgCommand.RunScriptUploadNoLen2(9, repetitions);
        Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
        ProgCommand.GetUpload();
        Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
        int num4 = 0;
        for (int index1 = 0; index1 < num2; ++index1)
        {
          int num5 = 0;
          byte[] numArray2 = numArray1;
          int num6 = num4;
          int num7 = num5;
          int num8 = 1;
          int num9 = num7 + num8;
          int index2 = num6 + num7;
          uint num10 = (uint) numArray2[index2];
          if (num9 < num1)
            num10 |= (uint) numArray1[num4 + num9++] << 8;
          num4 += num9;
          if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
            num10 = num10 >> 1 & eeBlank;
          ProgCommand.DeviceBuffers.EEPromMemory[num3++] = num10;
          if (num3 >= (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem)
            break;
        }
        this.progressBar1.PerformStep();
      }
      while (num3 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem);
      ProgCommand.RunScript(1, 1);
    }

    private void eraseDevice(object sender, EventArgs e)
    {
      this.eraseDeviceAll(false, new uint[0]);
    }

    private void eraseDeviceAll(bool forceOSSCAL, uint[] calWords)
    {
      if (ProgCommand.FamilyIsKeeloq() || ProgCommand.FamilyIsMCP())
      {
        this.displayStatusWindow.Text = "Función Inválida Para el Tipo Seleccionado!";
        FormProgUSB.statusWindowColor = Constants.StatusColor.yellow;
        this.updateGUI(false);
      }
      else
      {
        if (!this.preProgrammingCheck(ProgCommand.GetActiveFamily()))
          return;
        DeviceData deviceData = ProgCommand.CloneBuffers(ProgCommand.DeviceBuffers);
        if (ProgCommand.FamilyIsEEPROM() && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] != 3 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] != 4)
        {
          ProgCommand.ResetBuffers();
          this.checkImportFile = false;
          if (!this.eepromWrite(true))
          {
            if (this.toolStripMenuItemClearBuffersErase.Checked)
              return;
            ProgCommand.DeviceBuffers = deviceData;
          }
          else
          {
            Label label = this.displayStatusWindow;
            string str = label.Text + "Listo!";
            label.Text = str;
            if (!this.toolStripMenuItemClearBuffersErase.Checked)
              ProgCommand.DeviceBuffers = deviceData;
            else
              this.displayDataSource.Text = "Archivo Nulo";
            this.updateGUI(true);
          }
        }
        else
        {
          if (!this.checkEraseVoltage(false))
            return;
          this.progressBar1.Value = 0;
          ProgCommand.SetMCLRTemp(true);
          ProgCommand.VddOn();
          if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave && !forceOSSCAL)
          {
            ProgCommand.ReadOSSCAL();
            if (!this.verifyOSCCAL())
              return;
          }
          uint num1 = ProgCommand.DeviceBuffers.OSCCAL;
          if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask > 0U)
            ProgCommand.ReadBandGap();
          uint num2 = ProgCommand.DeviceBuffers.BandGap;
          this.displayStatusWindow.Text = "Borrando Dispositivo...";
          this.Update();
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMemEraseScript > 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseSize == 0)
          {
            ProgCommand.RunScript(0, 1);
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWrPrepScript > 0)
            {
              ProgCommand.DownloadAddress3(0);
              ProgCommand.RunScript(14, 1);
            }
            ProgCommand.ExecuteScript((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMemEraseScript);
            ProgCommand.RunScript(1, 1);
          }
          ProgCommand.RunScript(0, 1);
          if (FormProgUSB.TestMemoryEnabled && FormProgUSB.TestMemoryOpen && calWords.Length > 0)
          {
            byte[] dataArray = new byte[2 * calWords.Length];
            for (int index = 0; index < calWords.Length; ++index)
            {
              calWords[index] <<= 1;
              dataArray[2 * index] = (byte) (calWords[index] & (uint) byte.MaxValue);
              dataArray[2 * index + 1] = (byte) (calWords[index] >> 8);
            }
            ProgCommand.DataClrAndDownload(dataArray, 0);
            ProgCommand.RunScript(21, 1);
          }
          else
          {
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ChipErasePrepScript > 0)
              ProgCommand.RunScript(4, 1);
            ProgCommand.RunScript(22, 1);
          }
          ProgCommand.RunScript(1, 1);
          ProgCommand.ResetBuffers();
          if (FormProgUSB.TestMemoryEnabled && FormProgUSB.TestMemoryOpen && !this.toolStripMenuItemClearBuffersErase.Checked)
            FormProgUSB.formTestMem.ClearTestMemory();
          if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave)
          {
            ProgCommand.DeviceBuffers.OSCCAL = num1;
            deviceData.OSCCAL = num1;
            ProgCommand.WriteOSSCAL();
            ProgCommand.DeviceBuffers.ProgramMemory[ProgCommand.DeviceBuffers.ProgramMemory.Length - 1] = ProgCommand.DeviceBuffers.OSCCAL;
            deviceData.ProgramMemory[deviceData.ProgramMemory.Length - 1] = ProgCommand.DeviceBuffers.OSCCAL;
          }
          if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask > 0U)
          {
            ProgCommand.DeviceBuffers.BandGap = num2;
            deviceData.BandGap = num2;
            int num3 = (int) ProgCommand.WriteConfigOutsideProgMem(false, false);
          }
          if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].WriteCfgOnErase)
          {
            int num3 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
            int num4 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
            int length = ProgCommand.DeviceBuffers.ProgramMemory.Length;
            if ((long) num3 < (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem && num4 > 0)
            {
              uint num5 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue != (int) ushort.MaxValue ? 16711680U : 61440U;
              for (int index = num4; index > 0; --index)
                ProgCommand.DeviceBuffers.ProgramMemory[length - index] = (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[num4 - index] | num5;
              this.writeConfigInsideProgramMem();
            }
            else
            {
              int num6 = (int) ProgCommand.WriteConfigOutsideProgMem(false, false);
            }
          }
          if (!this.toolStripMenuItemClearBuffersErase.Checked)
            ProgCommand.DeviceBuffers = deviceData;
          Label label = this.displayStatusWindow;
          string str = label.Text + "Listo!";
          label.Text = str;
          this.Update();
          if (this.toolStripMenuItemClearBuffersErase.Checked)
            this.displayDataSource.Text = "Archivo Nulo";
          this.checkImportFile = false;
          this.conditionalVDDOff();
          this.updateGUI(true);
        }
      }
    }

    private bool checkEraseVoltage(bool checkRowErase)
    {
      if ((double) (float) (this.numUpDnVDD.Value + new Decimal(5, 0, 0, false, (byte) 2)) >= (double) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddErase || !FormProgUSB.ShowWriteEraseVDDDialog)
        return true;
      if (checkRowErase && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseScript > 0)
        return false;
      bool enabled = this.timerAutoImportWrite.Enabled;
      this.timerAutoImportWrite.Enabled = false;
      this.timerAutoImportWrite.Enabled = enabled;
      return FormProgUSB.ContinueWriteErase;
    }

    private bool verifyOSCCAL()
    {
      if (ProgCommand.ValidateOSSCAL() || !this.verifyOSCCALValue || MessageBox.Show("Valor Incorrecto en OSCCAL!\n\n      ¿Aceptar o Cancelar?\n", "      ¡¡ A L E R T A !! ", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
        return true;
      this.conditionalVDDOff();
      this.displayStatusWindow.Text = "Operación Cancelada!\n";
      FormProgUSB.statusWindowColor = Constants.StatusColor.red;
      this.updateGUI(true);
      return false;
    }

    private void writeDevice(object sender, EventArgs e)
    {
      this.deviceWrite();
    }

    private bool deviceWrite()
    {
      uint checksum1 = 0U;
      if (ProgCommand.FamilyIsEEPROM())
        return this.eepromWrite(false);
      bool flag1 = false;
      if (!this.preProgrammingCheck(ProgCommand.GetActiveFamily()))
        return false;
      if (!this.checkEraseVoltage(true) && !ProgCommand.FamilyIsPIC32())
      {
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseScript <= 0)
          return false;
        flag1 = true;
      }
      this.updateGUI(false);
      this.Update();
      if (this.checkImportFile && !ProgCommand.LearnMode)
      {
        FileInfo fileInfo = new FileInfo(this.openHexFileDialog.FileName);
        if (ImportExportHex.LastWriteTime != fileInfo.LastWriteTime)
        {
          this.displayStatusWindow.Text = "Abriendo archivo HEX...\n";
          this.Update();
          Thread.Sleep(300);
          if (!this.importHexFileGo())
          {
            this.displayStatusWindow.Text = "Error al Abrir el Archvio HEX!\n";
            FormProgUSB.statusWindowColor = Constants.StatusColor.red;
            this.updateGUI(true);
            return false;
          }
        }
      }
      if (ProgCommand.FamilyIsPIC32())
      {
        if (PIC32MXFunctions.P32Write(this.verifyOnWriteToolStripMenuItem.Checked, this.enableCodeProtectToolStripMenuItem.Checked))
        {
          FormProgUSB.statusWindowColor = Constants.StatusColor.green;
          this.conditionalVDDOff();
          this.updateGUI(true);
          return true;
        }
        else
        {
          FormProgUSB.statusWindowColor = Constants.StatusColor.red;
          this.conditionalVDDOff();
          this.updateGUI(true);
          return true;
        }
      }
      else
      {
        ProgCommand.SetMCLRTemp(true);
        ProgCommand.VddOn();
        if (ProgCommand.LearnMode && ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].DeviceIDMask > 0U)
          ProgCommand.MetaCmd_CHECK_DEVICE_ID();
        if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave)
        {
          if (ProgCommand.LearnMode)
          {
            ProgCommand.DeviceBuffers.ProgramMemory[ProgCommand.DeviceBuffers.ProgramMemory.Length - 1] = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
            ProgCommand.MetaCmd_READ_OSCCAL();
          }
          else
          {
            ProgCommand.ReadOSSCAL();
            ProgCommand.DeviceBuffers.ProgramMemory[ProgCommand.DeviceBuffers.ProgramMemory.Length - 1] = ProgCommand.DeviceBuffers.OSCCAL;
            if (!this.verifyOSCCAL())
              return false;
          }
        }
        int num1 = (int) ProgCommand.DeviceBuffers.OSCCAL;
        if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask > 0U)
        {
          if (ProgCommand.LearnMode)
            ProgCommand.MetaCmd_READ_BANDGAP();
          else
            ProgCommand.ReadBandGap();
        }
        int num2 = (int) ProgCommand.DeviceBuffers.BandGap;
        bool forceEEVerify = false;
        if (this.checkBoxProgMemEnabled.Checked && (this.checkBoxEEMem.Checked || !this.checkBoxEEMem.Enabled))
        {
          if (flag1)
          {
            this.displayStatusWindow.Text = "Borrando Dispostivo en LVP...\n";
            this.Update();
            ProgCommand.RowEraseDevice();
          }
          else
          {
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMemEraseScript > 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseSize == 0)
            {
              ProgCommand.RunScript(0, 1);
              if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWrPrepScript > 0)
              {
                ProgCommand.DownloadAddress3(0);
                ProgCommand.RunScript(14, 1);
              }
              ProgCommand.ExecuteScript((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMemEraseScript);
              ProgCommand.RunScript(1, 1);
            }
            ProgCommand.RunScript(0, 1);
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ChipErasePrepScript > 0)
              ProgCommand.RunScript(4, 1);
            ProgCommand.RunScript(22, 1);
            ProgCommand.RunScript(1, 1);
          }
        }
        else if (this.checkBoxProgMemEnabled.Checked && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemEraseScript != 0)
        {
          if (flag1)
          {
            this.displayStatusWindow.Text = "Borrando Dispostivo en LVP...\n";
            this.Update();
            ProgCommand.RowEraseDevice();
          }
          else
          {
            ProgCommand.RunScript(0, 1);
            ProgCommand.RunScript(23, 1);
            ProgCommand.RunScript(1, 1);
          }
        }
        else if (this.checkBoxEEMem.Checked && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMemEraseScript != 0)
        {
          ProgCommand.RunScript(0, 1);
          ProgCommand.RunScript(24, 1);
          ProgCommand.RunScript(1, 1);
        }
        else if (!this.checkBoxEEMem.Checked && this.checkBoxEEMem.Enabled && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemEraseScript == 0)
        {
          this.displayStatusWindow.Text = "Leyendo Dipositivo...\n";
          this.Update();
          this.readEEPROM();
          this.updateGUI(true);
          if (flag1)
          {
            this.displayStatusWindow.Text = "Borrando Dispostivo en LVP...\n";
            this.Update();
            ProgCommand.RowEraseDevice();
          }
          else
          {
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMemEraseScript > 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseSize == 0)
            {
              ProgCommand.RunScript(0, 1);
              if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWrPrepScript > 0)
              {
                ProgCommand.DownloadAddress3(0);
                ProgCommand.RunScript(14, 1);
              }
              ProgCommand.ExecuteScript((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMemEraseScript);
              ProgCommand.RunScript(1, 1);
            }
            ProgCommand.RunScript(0, 1);
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ChipErasePrepScript > 0)
              ProgCommand.RunScript(4, 1);
            ProgCommand.RunScript(22, 1);
            ProgCommand.RunScript(1, 1);
            forceEEVerify = true;
          }
        }
        this.displayStatusWindow.Text = "Programando Dispositivo...\n";
        this.Update();
        bool flag2 = false;
        int configLocation = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
        int configWords = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
        int length = ProgCommand.DeviceBuffers.ProgramMemory.Length;
        uint[] numArray = new uint[configWords];
        if ((long) configLocation < (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem && configWords > 0)
        {
          flag2 = true;
          for (int index = configWords; index > 0; --index)
          {
            numArray[index - 1] = ProgCommand.DeviceBuffers.ProgramMemory[length - index];
            ProgCommand.DeviceBuffers.ProgramMemory[length - index] = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
          }
        }
        int startIndex1 = length - 1;
        if (this.checkBoxProgMemEnabled.Checked)
        {
          Label label = this.displayStatusWindow;
          string str = label.Text + "Flash + ";
          label.Text = str;
          this.Update();
          this.progressBar1.Value = 0;
          ProgCommand.RunScript(0, 1);
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrPrepScript != 0)
          {
            ProgCommand.DownloadAddress3(0);
            ProgCommand.RunScript(6, 1);
          }
          if (ProgCommand.FamilyIsKeeloq())
            ProgCommand.HCS360_361_VppSpecial();
          int num3 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrWords;
          int num4 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
          int repetitions = 256 / (num3 * num4);
          int num5 = repetitions * num3;
          int wordsWritten = 0;
          int lastUsedInBuffer = ProgCommand.FindLastUsedInBuffer(ProgCommand.DeviceBuffers.ProgramMemory, ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue, startIndex1);
          if ((num3 == lastUsedInBuffer + 1 || num5 > lastUsedInBuffer + 1) && !ProgCommand.LearnMode)
          {
            repetitions = 1;
            num5 = num3;
          }
          int num6 = (lastUsedInBuffer + 1) / num5;
          if ((lastUsedInBuffer + 1) % num5 > 0)
            ++num6;
          startIndex1 = num6 * num5;
          this.progressBar1.Maximum = startIndex1 / num5;
          byte[] downloadBuffer = new byte[256];
          do
          {
            int lastIndex = 0;
            for (int index1 = 0; index1 < num5 && wordsWritten != startIndex1; ++index1)
            {
              uint num7 = ProgCommand.DeviceBuffers.ProgramMemory[wordsWritten++];
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
                num7 <<= 1;
              downloadBuffer[lastIndex++] = (byte) (num7 & (uint) byte.MaxValue);
              checksum1 += (uint) (byte) (num7 & (uint) byte.MaxValue);
              for (int index2 = 1; index2 < num4; ++index2)
              {
                num7 >>= 8;
                downloadBuffer[lastIndex++] = (byte) (num7 & (uint) byte.MaxValue);
                checksum1 += (uint) (byte) (num7 & (uint) byte.MaxValue);
              }
            }
            if (ProgCommand.FamilyIsKeeloq())
              this.processKeeloqData(ref downloadBuffer, wordsWritten);
            int startIndex2 = ProgCommand.DataClrAndDownload(downloadBuffer, 0);
            while (startIndex2 < lastIndex)
              startIndex2 = ProgCommand.DataDownload(downloadBuffer, startIndex2, lastIndex);
            ProgCommand.RunScript(7, repetitions);
            if (wordsWritten % 32768 == 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrPrepScript != 0)
            {
              ProgCommand.DownloadAddress3(65536 * (wordsWritten / 32768));
              ProgCommand.RunScript(6, 1);
            }
            this.progressBar1.PerformStep();
          }
          while (wordsWritten < startIndex1);
          ProgCommand.RunScript(1, 1);
        }
        int num8 = startIndex1;
        if (flag2)
        {
          for (int index = configWords; index > 0; --index)
            ProgCommand.DeviceBuffers.ProgramMemory[ProgCommand.DeviceBuffers.ProgramMemory.Length - index] = numArray[index - 1];
        }
        if ((this.checkBoxEEMem.Checked || forceEEVerify) && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
        {
          Label label = this.displayStatusWindow;
          string str = label.Text + "EEPROM + ";
          label.Text = str;
          this.Update();
          ProgCommand.RunScript(0, 1);
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEWrPrepScript > 1)
          {
            if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemHexBytes == 4)
              ProgCommand.DownloadAddress3((int) (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEAddr / 2U));
            else
              ProgCommand.DownloadAddress3(0);
            ProgCommand.RunScript(10, 1);
          }
          int num3 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemBytesPerWord;
          uint eeBlank = this.getEEBlank();
          int num4 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEWrLocations;
          if (num4 < 16)
            num4 = 16;
          int num5 = !this.checkBoxProgMemEnabled.Checked || flag1 || ProgCommand.LearnMode ? ProgCommand.DeviceBuffers.EEPromMemory.Length - 1 : ProgCommand.FindLastUsedInBuffer(ProgCommand.DeviceBuffers.EEPromMemory, eeBlank, ProgCommand.DeviceBuffers.EEPromMemory.Length - 1);
          int num6 = (num5 + 1) / num4;
          if ((num5 + 1) % num4 > 0)
            ++num6;
          int num7 = num6 * num4;
          byte[] dataArray = new byte[num4 * num3];
          int repetitions = num4 / (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEWrLocations;
          int num9 = 0;
          this.progressBar1.Value = 0;
          this.progressBar1.Maximum = num7 / num4;
          do
          {
            int num10 = 0;
            for (int index1 = 0; index1 < num4; ++index1)
            {
              uint num11 = ProgCommand.DeviceBuffers.EEPromMemory[num9++];
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
                num11 <<= 1;
              dataArray[num10++] = (byte) (num11 & (uint) byte.MaxValue);
              checksum1 += (uint) (byte) (num11 & (uint) byte.MaxValue);
              for (int index2 = 1; index2 < num3; ++index2)
              {
                num11 >>= 8;
                dataArray[num10++] = (byte) (num11 & (uint) byte.MaxValue);
                checksum1 += (uint) (byte) (num11 & (uint) byte.MaxValue);
              }
            }
            ProgCommand.DataClrAndDownload(dataArray, 0);
            ProgCommand.RunScript(11, repetitions);
            this.progressBar1.PerformStep();
          }
          while (num9 < num7);
          ProgCommand.RunScript(1, 1);
        }
        if (this.checkBoxProgMemEnabled.Checked && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords > 0)
        {
          Label label = this.displayStatusWindow;
          string str = label.Text + "Bits ID + ";
          label.Text = str;
          this.Update();
          ProgCommand.RunScript(0, 1);
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWrPrepScript > 0)
            ProgCommand.RunScript(18, 1);
          int num3 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].UserIDBytes;
          byte[] dataArray = new byte[(int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords * num3];
          int lastIndex = 0;
          int num4 = 0;
          for (int index1 = 0; index1 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords; ++index1)
          {
            uint num5 = ProgCommand.DeviceBuffers.UserIDs[num4++];
            if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
              num5 <<= 1;
            dataArray[lastIndex++] = (byte) (num5 & (uint) byte.MaxValue);
            checksum1 += (uint) (byte) (num5 & (uint) byte.MaxValue);
            for (int index2 = 1; index2 < num3; ++index2)
            {
              num5 >>= 8;
              dataArray[lastIndex++] = (byte) (num5 & (uint) byte.MaxValue);
              checksum1 += (uint) (byte) (num5 & (uint) byte.MaxValue);
            }
          }
          int startIndex2 = ProgCommand.DataClrAndDownload(dataArray, 0);
          while (startIndex2 < lastIndex)
            startIndex2 = ProgCommand.DataDownload(dataArray, startIndex2, lastIndex);
          ProgCommand.RunScript(19, 1);
          ProgCommand.RunScript(1, 1);
        }
        bool flag3 = true;
        if (flag2)
        {
          if (ProgCommand.LearnMode)
          {
            if ((long) num8 == (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem)
            {
              if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > (uint) ushort.MaxValue)
                checksum1 -= 128U;
              else
                checksum1 -= 8U;
            }
          }
          else
            num8 -= configWords;
        }
        if (this.verifyOnWriteToolStripMenuItem.Checked)
        {
          if (ProgCommand.LearnMode)
            ProgCommand.MetaCmd_START_CHECKSUM();
          flag3 = this.deviceVerify(true, num8 - 1, forceEEVerify);
          if (ProgCommand.LearnMode)
          {
            ProgCommand.MetaCmd_VERIFY_CHECKSUM(checksum1);
            checksum1 = 0U;
          }
        }
        if (ProgCommand.LearnMode && ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave)
        {
          ProgCommand.MetaCmd_WRITE_OSCCAL();
          ProgCommand.DeviceBuffers.ProgramMemory[ProgCommand.DeviceBuffers.ProgramMemory.Length - 1] = ProgCommand.DeviceBuffers.OSCCAL;
        }
        if (!flag3)
          return false;
        if (configWords > 0 && !flag2 && this.checkBoxProgMemEnabled.Checked)
        {
          if (!this.verifyOnWriteToolStripMenuItem.Checked)
          {
            Label label = this.displayStatusWindow;
            string str = label.Text + "Bits Config  ";
            label.Text = str;
            this.Update();
          }
          if ((ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName == "PIC18F" || ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName == "PIC18F_K_") && ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords > 5 && ((long) ProgCommand.DeviceBuffers.ConfigWords[5] & -8193L) == (long) ProgCommand.DeviceBuffers.ConfigWords[5]))
          {
            uint num3 = ProgCommand.DeviceBuffers.ConfigWords[5];
            ProgCommand.DeviceBuffers.ConfigWords[5] = (uint) ushort.MaxValue;
            int num4 = (int) ProgCommand.WriteConfigOutsideProgMem(false, false);
            ProgCommand.DeviceBuffers.ConfigWords[5] = num3;
          }
          uint checksum2 = checksum1 + ProgCommand.WriteConfigOutsideProgMem(this.enableCodeProtectToolStripMenuItem.Enabled && this.enableCodeProtectToolStripMenuItem.Checked, this.enableDataProtectStripMenuItem.Enabled && this.enableDataProtectStripMenuItem.Checked);
          if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue == (int) ushort.MaxValue)
            checksum2 += (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[7];
          if (this.verifyOnWriteToolStripMenuItem.Checked && (!ProgCommand.LearnMode || (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask == 0))
          {
            if (this.verifyConfig(configWords, configLocation))
            {
              FormProgUSB.statusWindowColor = Constants.StatusColor.green;
              this.displayStatusWindow.Text = "Programación Correcta!\n";
            }
            else if (!ProgCommand.LearnMode)
            {
              FormProgUSB.statusWindowColor = Constants.StatusColor.red;
              flag3 = false;
            }
            if (ProgCommand.LearnMode && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask == 0)
              ProgCommand.MetaCmd_VERIFY_CHECKSUM(checksum2);
          }
        }
        else if (configWords > 0 && this.checkBoxProgMemEnabled.Checked)
        {
          if (!this.verifyOnWriteToolStripMenuItem.Checked)
          {
            Label label = this.displayStatusWindow;
            string str = label.Text + "Bits Config  ";
            label.Text = str;
            this.Update();
          }
          for (int index = 0; index < configWords; ++index)
          {
            if (index == (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPConfig - 1)
            {
              if (this.enableCodeProtectToolStripMenuItem.Enabled && this.enableCodeProtectToolStripMenuItem.Checked)
                ProgCommand.DeviceBuffers.ProgramMemory[configLocation + index] &= (uint) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask;
              if (this.enableDataProtectStripMenuItem.Enabled && this.enableDataProtectStripMenuItem.Checked)
                ProgCommand.DeviceBuffers.ProgramMemory[configLocation + index] &= (uint) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask;
            }
          }
          this.writeConfigInsideProgramMem();
          if (this.verifyOnWriteToolStripMenuItem.Checked)
          {
            FormProgUSB.statusWindowColor = Constants.StatusColor.green;
            this.displayStatusWindow.Text = "Programación Correcta!\n";
          }
          else
            flag3 = false;
        }
        else if (!this.checkBoxProgMemEnabled.Checked)
        {
          FormProgUSB.statusWindowColor = Constants.StatusColor.green;
          this.displayStatusWindow.Text = "Programación Correcta!\n";
        }
        else
        {
          FormProgUSB.statusWindowColor = Constants.StatusColor.green;
          this.displayStatusWindow.Text = "Programación Correcta!\n";
        }
        this.conditionalVDDOff();
        if (!this.verifyOnWriteToolStripMenuItem.Checked)
        {
          Label label = this.displayStatusWindow;
          string str = label.Text + "Listo!";
          label.Text = str;
        }
        if (ProgCommand.LearnMode)
          this.displayStatusWindow.Text = "Funcíón Lista";
        this.updateGUI(true);
        return flag3;
      }
    }

    private void writeConfigInsideProgramMem()
    {
      ProgCommand.RunScript(0, 1);
      int num1 = ProgCommand.DeviceBuffers.ProgramMemory.Length - (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrWords;
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrPrepScript != 0)
      {
        ProgCommand.DownloadAddress3(num1 * (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].AddressIncrement);
        ProgCommand.RunScript(6, 1);
      }
      byte[] dataArray = new byte[256];
      int lastIndex = 0;
      for (int index1 = 0; index1 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrWords; ++index1)
      {
        uint num2 = ProgCommand.DeviceBuffers.ProgramMemory[num1++];
        if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
          num2 <<= 1;
        dataArray[lastIndex++] = (byte) (num2 & (uint) byte.MaxValue);
        for (int index2 = 1; index2 < (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation; ++index2)
        {
          num2 >>= 8;
          dataArray[lastIndex++] = (byte) (num2 & (uint) byte.MaxValue);
        }
      }
      int startIndex = ProgCommand.DataClrAndDownload(dataArray, 0);
      while (startIndex < lastIndex)
        startIndex = ProgCommand.DataDownload(dataArray, startIndex, lastIndex);
      ProgCommand.RunScript(7, 1);
      ProgCommand.RunScript(1, 1);
    }

    private void processKeeloqData(ref byte[] downloadBuffer, int wordsWritten)
    {
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DeviceID != -202)
        return;
      for (int index = wordsWritten / 2; index > 0; --index)
      {
        downloadBuffer[index * 4 - 1] = ~downloadBuffer[index * 2 - 1];
        downloadBuffer[index * 4 - 2] = ~downloadBuffer[index * 2 - 2];
        downloadBuffer[index * 4 - 3] = downloadBuffer[index * 2 - 1];
        downloadBuffer[index * 4 - 4] = downloadBuffer[index * 2 - 2];
      }
      downloadBuffer[0] >>= 1;
    }

    private void blankCheck(object sender, EventArgs e)
    {
      this.blankCheckDevice();
    }

    private bool blankCheckDevice()
    {
      if (ProgCommand.FamilyIsKeeloq() || ProgCommand.FamilyIsMCP())
      {
        this.displayStatusWindow.Text = "Función Inválida Para el Tipo Seleccionado!";
        FormProgUSB.statusWindowColor = Constants.StatusColor.yellow;
        this.updateGUI(false);
        return false;
      }
      else
      {
        if (!this.preProgrammingCheck(ProgCommand.GetActiveFamily()))
          return false;
        if (ProgCommand.FamilyIsPIC32())
        {
          if (PIC32MXFunctions.PIC32BlankCheck())
          {
            FormProgUSB.statusWindowColor = Constants.StatusColor.green;
            this.conditionalVDDOff();
            this.updateGUI(true);
            return true;
          }
          else
          {
            FormProgUSB.statusWindowColor = Constants.StatusColor.red;
            this.conditionalVDDOff();
            this.updateGUI(true);
            return true;
          }
        }
        else
        {
          DeviceData deviceData = new DeviceData(ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords, ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue, (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemAddressIncrement, (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].UserIDBytes, ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank, (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[7]);
          int num1 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
          int num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
          if ((long) num1 < (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem)
          {
            for (int index = 0; index < num2; ++index)
            {
              uint num3 = deviceData.ProgramMemory[num1 + index] & 4294901760U;
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue == (int) ushort.MaxValue)
                num3 |= 61440U;
              deviceData.ProgramMemory[num1 + index] = num3 | (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[index];
            }
          }
          this.displayStatusWindow.Text = "Verificando si hay datos...\n";
          this.Update();
          ProgCommand.SetMCLRTemp(true);
          ProgCommand.VddOn();
          byte[] numArray1 = new byte[128];
          Label label1 = this.displayStatusWindow;
          string str1 = label1.Text + "Flash + ";
          label1.Text = str1;
          this.Update();
          ProgCommand.RunScript(0, 1);
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrSetScript != 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrBytes != 0)
          {
            if (ProgCommand.FamilyIsEEPROM())
            {
              ProgCommand.DownloadAddress3MSBFirst(this.eeprom24BitAddress(0, false));
              ProgCommand.RunScript(5, 1);
              if (this.eeprom_CheckBusErrors())
                return false;
            }
            else
            {
              ProgCommand.DownloadAddress3(0);
              ProgCommand.RunScript(5, 1);
            }
          }
          int num4 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
          int num5 = 128 / ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords * num4);
          int num6 = num5 * (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords;
          int wordsWritten = 0;
          this.progressBar1.Value = 0;
          this.progressBar1.Maximum = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem / num6;
          do
          {
            if (ProgCommand.FamilyIsEEPROM())
            {
              if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 1 && wordsWritten > (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] && wordsWritten % ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] + 1) == 0)
              {
                ProgCommand.DownloadAddress3MSBFirst(this.eeprom24BitAddress(wordsWritten, false));
                ProgCommand.RunScript(5, 1);
              }
              ProgCommand.Download3Multiples(this.eeprom24BitAddress(wordsWritten, true), num5, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords);
            }
            ProgCommand.RunScriptUploadNoLen2(3, num5);
            Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
            ProgCommand.GetUpload();
            Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
            int num3 = 0;
            for (int index1 = 0; index1 < num6; ++index1)
            {
              int num7 = 0;
              byte[] numArray2 = numArray1;
              int num8 = num3;
              int num9 = num7;
              int num10 = 1;
              int num11 = num9 + num10;
              int index2 = num8 + num9;
              uint num12 = (uint) numArray2[index2];
              if (num11 < num4)
                num12 |= (uint) numArray1[num3 + num11++] << 8;
              if (num11 < num4)
                num12 |= (uint) numArray1[num3 + num11++] << 16;
              if (num11 < num4)
                num12 |= (uint) numArray1[num3 + num11++] << 24;
              num3 += num11;
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
                num12 = num12 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
              if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave && (long) wordsWritten == (long) (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem - 1U))
                num12 = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
              if ((int) num12 != (int) deviceData.ProgramMemory[wordsWritten++])
              {
                ProgCommand.RunScript(1, 1);
                this.conditionalVDDOff();
                if (ProgCommand.FamilyIsEEPROM())
                  this.displayStatusWindow.Text = "Datos EEPROM Econtrados En:\n";
                else
                  this.displayStatusWindow.Text = "Datos FLASH Econtrados En:\n";
                Label label2 = this.displayStatusWindow;
                int num13;
                string str2 = label2.Text + string.Format("0x{0:X6}", (object) ((num13 = wordsWritten - 1) * (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].AddressIncrement));
                label2.Text = str2;
                FormProgUSB.statusWindowColor = Constants.StatusColor.red;
                this.updateGUI(true);
                return false;
              }
              else if ((long) wordsWritten != (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem)
              {
                if (wordsWritten % 32768 == 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrSetScript != 0 && ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrBytes != 0 && ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > (uint) ushort.MaxValue))
                {
                  ProgCommand.DownloadAddress3(65536 * (wordsWritten / 32768));
                  ProgCommand.RunScript(5, 1);
                  break;
                }
              }
              else
                break;
            }
            this.progressBar1.PerformStep();
          }
          while ((long) wordsWritten < (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem);
          ProgCommand.RunScript(1, 1);
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
          {
            Label label2 = this.displayStatusWindow;
            string str2 = label2.Text + "EEPROM + ";
            label2.Text = str2;
            this.Update();
            ProgCommand.RunScript(0, 1);
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdPrepScript > 0)
            {
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemHexBytes == 4)
                ProgCommand.DownloadAddress3((int) (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEAddr / 2U));
              else
                ProgCommand.DownloadAddress3(0);
              ProgCommand.RunScript(8, 1);
            }
            int num3 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemBytesPerWord;
            uint eeBlank = this.getEEBlank();
            int repetitions = 128 / ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdLocations * num3);
            int num7 = repetitions * (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdLocations;
            int num8 = 0;
            this.progressBar1.Value = 0;
            this.progressBar1.Maximum = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem / num7;
            do
            {
              ProgCommand.RunScriptUploadNoLen2(9, repetitions);
              Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
              ProgCommand.GetUpload();
              Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
              int num9 = 0;
              for (int index1 = 0; index1 < num7; ++index1)
              {
                int num10 = 0;
                byte[] numArray2 = numArray1;
                int num11 = num9;
                int num12 = num10;
                int num13 = 1;
                int num14 = num12 + num13;
                int index2 = num11 + num12;
                uint num15 = (uint) numArray2[index2];
                if (num14 < num3)
                  num15 |= (uint) numArray1[num9 + num14++] << 8;
                num9 += num14;
                if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
                  num15 = num15 >> 1 & eeBlank;
                ++num8;
                if ((int) num15 != (int) eeBlank)
                {
                  ProgCommand.RunScript(1, 1);
                  this.conditionalVDDOff();
                  this.displayStatusWindow.Text = "Datos EEPROM Encontrados En:\n";
                  int num16;
                  if ((int) eeBlank == (int) ushort.MaxValue)
                  {
                    Label label3 = this.displayStatusWindow;
                    string str3 = label3.Text + string.Format("0x{0:X4}", (object) ((num16 = num8 - 1) * 2));
                    label3.Text = str3;
                  }
                  else
                  {
                    Label label3 = this.displayStatusWindow;
                    string str3 = label3.Text + string.Format("0x{0:X4}", (object) (num16 = num8 - 1));
                    label3.Text = str3;
                  }
                  FormProgUSB.statusWindowColor = Constants.StatusColor.red;
                  this.updateGUI(true);
                  return false;
                }
                else if (num8 >= (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem)
                  break;
              }
              this.progressBar1.PerformStep();
            }
            while (num8 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem);
            ProgCommand.RunScript(1, 1);
          }
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords > 0 && !ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BlankCheckSkipUsrIDs)
          {
            Label label2 = this.displayStatusWindow;
            string str2 = label2.Text + "Bits ID + ";
            label2.Text = str2;
            this.Update();
            ProgCommand.RunScript(0, 1);
            if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDRdPrepScript > 0)
              ProgCommand.RunScript(16, 1);
            int num3 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].UserIDBytes;
            int num7 = 0;
            int num8 = 0;
            ProgCommand.RunScriptUploadNoLen(17, 1);
            Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
            if ((long) ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords * num3) > 64L)
            {
              ProgCommand.UploadDataNoLen();
              Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
            }
            ProgCommand.RunScript(1, 1);
            do
            {
              int num9 = 0;
              byte[] numArray2 = numArray1;
              int num10 = num8;
              int num11 = num9;
              int num12 = 1;
              int num13 = num11 + num12;
              int index = num10 + num11;
              uint num14 = (uint) numArray2[index];
              if (num13 < num3)
                num14 |= (uint) numArray1[num8 + num13++] << 8;
              if (num13 < num3)
                num14 |= (uint) numArray1[num8 + num13++] << 16;
              if (num13 < num3)
                num14 |= (uint) numArray1[num8 + num13++] << 24;
              num8 += num13;
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
                num14 = num14 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
              ++num7;
              uint num15 = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
              if (num3 == 1)
                num15 &= (uint) byte.MaxValue;
              if ((int) num14 != (int) num15)
              {
                this.conditionalVDDOff();
                this.displayStatusWindow.Text = "Bits del Usuario ID No Borrados!";
                FormProgUSB.statusWindowColor = Constants.StatusColor.red;
                this.updateGUI(true);
                return false;
              }
            }
            while (num7 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords);
          }
          if (num2 > 0 && (long) num1 > (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem)
          {
            Label label2 = this.displayStatusWindow;
            string str2 = label2.Text + "Bits Config  ";
            label2.Text = str2;
            this.Update();
            ProgCommand.RunScript(0, 1);
            ProgCommand.RunScript(13, 1);
            ProgCommand.UploadData();
            ProgCommand.RunScript(1, 1);
            int num3 = 2;
            for (int index1 = 0; index1 < num2; ++index1)
            {
              byte[] numArray2 = ProgCommand.Usb_read_array;
              int index2 = num3;
              int num7 = 1;
              int num8 = index2 + num7;
              int num9 = (int) numArray2[index2];
              byte[] numArray3 = ProgCommand.Usb_read_array;
              int index3 = num8;
              int num10 = 1;
              num3 = index3 + num10;
              int num11 = (int) numArray3[index3] << 8;
              uint num12 = (uint) (num9 | num11);
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
                num12 = num12 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
              uint num13 = num12 & (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index1];
              if ((long) ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index1] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[index1]) != (long) num13)
              {
                this.conditionalVDDOff();
                this.displayStatusWindow.Text = "Bits CONFIG No Borrados!";
                FormProgUSB.statusWindowColor = Constants.StatusColor.red;
                this.updateGUI(true);
                return false;
              }
            }
          }
          ProgCommand.RunScript(1, 1);
          this.conditionalVDDOff();
          FormProgUSB.statusWindowColor = Constants.StatusColor.green;
          this.displayStatusWindow.Text = "El Dispoditivo está Borrado!";
          this.updateGUI(true);
          return true;
        }
      }
    }

    private void progMemEdit(object sender, DataGridViewCellEventArgs e)
    {
      int rowIndex = e.RowIndex;
      int columnIndex = e.ColumnIndex;
      string p_value = "0x" + this.dataGridProgramMemory[columnIndex, rowIndex].FormattedValue.ToString();
      int num1;
      try
      {
        num1 = Utilities.Convert_Value_To_Int(p_value);
      }
      catch
      {
        num1 = 0;
      }
      int num2 = this.dataGridProgramMemory.ColumnCount - 1;
      if (this.comboBoxProgMemView.SelectedIndex >= 1)
        num2 /= 2;
      int index = rowIndex * num2 + columnIndex - 1;
      if (ProgCommand.FamilyIsPIC32())
      {
        int num3 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem - (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BootFlash;
        index -= num2;
        if (index > num3)
          index -= num2;
      }
      ProgCommand.DeviceBuffers.ProgramMemory[index] = (uint) ((ulong) num1 & (ulong) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue);
      this.displayDataSource.Text = "Modificado";
      this.checkImportFile = false;
      this.progMemJustEdited = true;
      this.updateGUI(true);
    }

    private void eEpromEdit(object sender, DataGridViewCellEventArgs e)
    {
      int rowIndex = e.RowIndex;
      int columnIndex = e.ColumnIndex;
      string p_value = "0x" + this.dataGridViewEEPROM[columnIndex, rowIndex].FormattedValue.ToString();
      int num1;
      try
      {
        num1 = Utilities.Convert_Value_To_Int(p_value);
      }
      catch
      {
        num1 = 0;
      }
      int num2 = this.dataGridViewEEPROM.ColumnCount - 1;
      if (this.comboBoxEE.SelectedIndex >= 1)
        num2 /= 2;
      ProgCommand.DeviceBuffers.EEPromMemory[rowIndex * num2 + columnIndex - 1] = (uint) ((ulong) num1 & (ulong) this.getEEBlank());
      this.displayDataSource.Text = "Modificado";
      this.checkImportFile = false;
      this.eeMemJustEdited = true;
      this.updateGUI(true);
    }

    private void checkCommunication(object sender, EventArgs e)
    {
      if (!this.detectPICkit2(true, true))
        return;
      this.partialEnableGUIControls();
      this.lookForPoweredTarget(false);
      if (!ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].PartDetect)
      {
        this.setGUIVoltageLimits(true);
        ProgCommand.SetVDDVoltage((float) this.numUpDnVDD.Value, 0.85f);
        this.displayStatusWindow.Text = this.displayStatusWindow.Text + "\n[Está Familia NO es Autodetectable]";
        this.fullEnableGUIControls();
      }
      else if (ProgCommand.DetectDevice(16777215, true, this.chkBoxVddOn.Checked))
      {
        this.setGUIVoltageLimits(true);
        ProgCommand.SetVDDVoltage((float) this.numUpDnVDD.Value, 0.85f);
        this.displayStatusWindow.Text = this.displayStatusWindow.Text + "\nPIC Encontrado.";
        this.fullEnableGUIControls();
      }
      this.displayDataSource.Text = "Archivo Nulo";
      this.checkForPowerErrors();
      this.updateGUI(true);
    }

    private void verifyDevice(object sender, EventArgs e)
    {
      if (ProgCommand.FamilyIsKeeloq())
      {
        this.displayStatusWindow.Text = "Función Inválida Para el Tipo Seleccionado!";
        FormProgUSB.statusWindowColor = Constants.StatusColor.yellow;
        this.updateGUI(false);
      }
      else
        this.deviceVerify(false, 0, false);
    }

    private bool deviceVerify(bool writeVerify, int lastLocation, bool forceEEVerify)
    {
      if (!writeVerify && !this.preProgrammingCheck(ProgCommand.GetActiveFamily()))
        return false;
      if (ProgCommand.FamilyIsPIC32())
      {
        if (PIC32MXFunctions.P32Verify(writeVerify, this.enableCodeProtectToolStripMenuItem.Checked))
        {
          FormProgUSB.statusWindowColor = Constants.StatusColor.green;
          this.conditionalVDDOff();
          this.updateGUI(true);
          return true;
        }
        else
        {
          FormProgUSB.statusWindowColor = Constants.StatusColor.red;
          this.conditionalVDDOff();
          this.updateGUI(true);
          return true;
        }
      }
      else
      {
        this.displayStatusWindow.Text = "Verificando Escritura...\n";
        this.Update();
        if (!ProgCommand.FamilyIsKeeloq())
          ProgCommand.SetMCLRTemp(true);
        ProgCommand.VddOn();
        byte[] numArray1 = new byte[128];
        int configLocation = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
        int configWords = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
        int num1 = ProgCommand.DeviceBuffers.ProgramMemory.Length - 1;
        if (writeVerify)
          num1 = lastLocation;
        if (this.checkBoxProgMemEnabled.Checked)
        {
          Label label1 = this.displayStatusWindow;
          string str1 = label1.Text + "Flash + ";
          label1.Text = str1;
          this.Update();
          ProgCommand.RunScript(0, 1);
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrSetScript != 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrBytes != 0)
          {
            if (ProgCommand.FamilyIsEEPROM())
            {
              ProgCommand.DownloadAddress3MSBFirst(this.eeprom24BitAddress(0, false));
              ProgCommand.RunScript(5, 1);
              if (!writeVerify && this.eeprom_CheckBusErrors())
                return false;
            }
            else
            {
              ProgCommand.DownloadAddress3(0);
              ProgCommand.RunScript(5, 1);
            }
          }
          int num2 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
          int num3 = 128 / ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords * num2);
          int num4 = num3 * (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords;
          int wordsWritten = 0;
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords == num1 + 1)
          {
            num3 = 1;
            num4 = num1 + 1;
          }
          this.progressBar1.Value = 0;
          this.progressBar1.Maximum = num1 / num4;
          do
          {
            if (ProgCommand.FamilyIsEEPROM())
            {
              if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 1 && wordsWritten > (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] && wordsWritten % ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] + 1) == 0)
              {
                ProgCommand.DownloadAddress3MSBFirst(this.eeprom24BitAddress(wordsWritten, false));
                ProgCommand.RunScript(5, 1);
              }
              ProgCommand.Download3Multiples(this.eeprom24BitAddress(wordsWritten, true), num3, (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords);
            }
            ProgCommand.RunScriptUploadNoLen2(3, num3);
            Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
            ProgCommand.GetUpload();
            Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
            int num5 = 0;
            for (int index1 = 0; index1 < num4; ++index1)
            {
              int num6 = 0;
              byte[] numArray2 = numArray1;
              int num7 = num5;
              int num8 = num6;
              int num9 = 1;
              int num10 = num8 + num9;
              int index2 = num7 + num8;
              uint num11 = (uint) numArray2[index2];
              if (num10 < num2)
                num11 |= (uint) numArray1[num5 + num10++] << 8;
              if (num10 < num2)
                num11 |= (uint) numArray1[num5 + num10++] << 16;
              if (num10 < num2)
                num11 |= (uint) numArray1[num5 + num10++] << 24;
              num5 += num10;
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
                num11 = num11 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
              if (num2 == 2 && ProgCommand.FamilyIsEEPROM() && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 3)
              {
                uint num12 = (uint) ((int) num11 << 8 & 65280);
                num11 = num11 >> 8 | num12;
              }
              if ((int) num11 != (int) ProgCommand.DeviceBuffers.ProgramMemory[wordsWritten++] && !ProgCommand.LearnMode)
              {
                ProgCommand.RunScript(1, 1);
                this.conditionalVDDOff();
                if (!writeVerify)
                {
                  if (ProgCommand.FamilyIsEEPROM())
                    this.displayStatusWindow.Text = "Error de Verificación en memoria EEPROM en: ";
                  else
                    this.displayStatusWindow.Text = "Error de Verificación en memoria FLASH en: ";
                }
                else if (ProgCommand.FamilyIsEEPROM())
                  this.displayStatusWindow.Text = "Error en memoria EEPROM en: ";
                else
                  this.displayStatusWindow.Text = "Error en memoria FLASH en: ";
                Label label2 = this.displayStatusWindow;
                int num12;
                string str2 = label2.Text + string.Format("0x{0:X6}", (object) ((num12 = wordsWritten - 1) * (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].AddressIncrement));
                label2.Text = str2;
                FormProgUSB.statusWindowColor = Constants.StatusColor.red;
                this.updateGUI(true);
                return false;
              }
              else if (wordsWritten % 32768 == 0 && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrSetScript != 0 && ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemAddrBytes != 0 && ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > (uint) ushort.MaxValue))
              {
                ProgCommand.DownloadAddress3(65536 * (wordsWritten / 32768));
                ProgCommand.RunScript(5, 1);
                break;
              }
              else if (wordsWritten > num1)
                break;
            }
            this.progressBar1.PerformStep();
          }
          while (wordsWritten < num1);
          ProgCommand.RunScript(1, 1);
        }
        if ((this.checkBoxEEMem.Checked || forceEEVerify) && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
        {
          if (ProgCommand.LearnMode && (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
            ProgCommand.MetaCmd_CHANGE_CHKSM_FRMT((byte) 2);
          Label label1 = this.displayStatusWindow;
          string str1 = label1.Text + "EEPROM + ";
          label1.Text = str1;
          this.Update();
          ProgCommand.RunScript(0, 1);
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdPrepScript > 0)
          {
            if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemHexBytes == 4)
              ProgCommand.DownloadAddress3((int) (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEAddr / 2U));
            else
              ProgCommand.DownloadAddress3(0);
            ProgCommand.RunScript(8, 1);
          }
          int num2 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemBytesPerWord;
          int repetitions = 128 / ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdLocations * num2);
          int num3 = repetitions * (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EERdLocations;
          int num4 = 0;
          uint eeBlank = this.getEEBlank();
          this.progressBar1.Value = 0;
          this.progressBar1.Maximum = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem / num3;
          do
          {
            ProgCommand.RunScriptUploadNoLen2(9, repetitions);
            Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
            ProgCommand.GetUpload();
            Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
            int num5 = 0;
            for (int index1 = 0; index1 < num3; ++index1)
            {
              int num6 = 0;
              byte[] numArray2 = numArray1;
              int num7 = num5;
              int num8 = num6;
              int num9 = 1;
              int num10 = num8 + num9;
              int index2 = num7 + num8;
              uint num11 = (uint) numArray2[index2];
              if (num10 < num2)
                num11 |= (uint) numArray1[num5 + num10++] << 8;
              num5 += num10;
              if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
                num11 = num11 >> 1 & eeBlank;
              if ((int) num11 != (int) ProgCommand.DeviceBuffers.EEPromMemory[num4++] && !ProgCommand.LearnMode)
              {
                ProgCommand.RunScript(1, 1);
                this.conditionalVDDOff();
                if (!writeVerify)
                  this.displayStatusWindow.Text = "Error de Verificación en memoria EEPROM en: ";
                else
                  this.displayStatusWindow.Text = "Error en memoria EEPROM en: ";
                int num12;
                if ((int) eeBlank == (int) ushort.MaxValue)
                {
                  Label label2 = this.displayStatusWindow;
                  string str2 = label2.Text + string.Format("0x{0:X4}", (object) ((num12 = num4 - 1) * 2));
                  label2.Text = str2;
                }
                else
                {
                  Label label2 = this.displayStatusWindow;
                  string str2 = label2.Text + string.Format("0x{0:X4}", (object) (num12 = num4 - 1));
                  label2.Text = str2;
                }
                FormProgUSB.statusWindowColor = Constants.StatusColor.red;
                this.updateGUI(true);
                return false;
              }
              else if (num4 >= (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem)
                break;
            }
            this.progressBar1.PerformStep();
          }
          while (num4 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem);
          ProgCommand.RunScript(1, 1);
          if (ProgCommand.LearnMode && (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
            ProgCommand.MetaCmd_CHANGE_CHKSM_FRMT((byte) 1);
        }
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords > 0 && this.checkBoxProgMemEnabled.Checked)
        {
          Label label = this.displayStatusWindow;
          string str = label.Text + "Bits ID + ";
          label.Text = str;
          this.Update();
          ProgCommand.RunScript(0, 1);
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDRdPrepScript > 0)
            ProgCommand.RunScript(16, 1);
          int num2 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].UserIDBytes;
          int num3 = 0;
          int num4 = 0;
          ProgCommand.RunScriptUploadNoLen(17, 1);
          Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
          if ((long) ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords * num2) > 64L)
          {
            ProgCommand.UploadDataNoLen();
            Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
          }
          ProgCommand.RunScript(1, 1);
          do
          {
            int num5 = 0;
            byte[] numArray2 = numArray1;
            int num6 = num4;
            int num7 = num5;
            int num8 = 1;
            int num9 = num7 + num8;
            int index = num6 + num7;
            uint num10 = (uint) numArray2[index];
            if (num9 < num2)
              num10 |= (uint) numArray1[num4 + num9++] << 8;
            if (num9 < num2)
              num10 |= (uint) numArray1[num4 + num9++] << 16;
            if (num9 < num2)
              num10 |= (uint) numArray1[num4 + num9++] << 24;
            num4 += num9;
            if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
              num10 = num10 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
            if ((int) num10 != (int) ProgCommand.DeviceBuffers.UserIDs[num3++] && !ProgCommand.LearnMode)
            {
              this.conditionalVDDOff();
              if (!writeVerify)
                this.displayStatusWindow.Text = "Error al Verificar bits del Usuario ID";
              else
                this.displayStatusWindow.Text = "Error en bits del Usuario ID!";
              FormProgUSB.statusWindowColor = Constants.StatusColor.red;
              this.updateGUI(true);
              return false;
            }
          }
          while (num3 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords);
        }
        if (!writeVerify && !this.verifyConfig(configWords, configLocation))
          return false;
        ProgCommand.RunScript(1, 1);
        if (!writeVerify)
        {
          FormProgUSB.statusWindowColor = Constants.StatusColor.green;
          this.displayStatusWindow.Text = "Escritura Correcta.\n";
          this.conditionalVDDOff();
        }
        this.updateGUI(true);
        return true;
      }
    }

    private bool verifyConfig(int configWords, int configLocation)
    {
      if (configWords > 0 && (long) configLocation > (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem && this.checkBoxProgMemEnabled.Checked)
      {
        Label label = this.displayStatusWindow;
        string str = label.Text + "Bits Config  ";
        label.Text = str;
        this.Update();
        ProgCommand.RunScript(0, 1);
        ProgCommand.RunScript(13, 1);
        ProgCommand.UploadData();
        ProgCommand.RunScript(1, 1);
        int num1 = 2;
        for (int index1 = 0; index1 < configWords; ++index1)
        {
          byte[] numArray1 = ProgCommand.Usb_read_array;
          int index2 = num1;
          int num2 = 1;
          int num3 = index2 + num2;
          int num4 = (int) numArray1[index2];
          byte[] numArray2 = ProgCommand.Usb_read_array;
          int index3 = num3;
          int num5 = 1;
          num1 = index3 + num5;
          int num6 = (int) numArray2[index3] << 8;
          uint num7 = (uint) (num4 | num6);
          if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
            num7 = num7 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
          uint num8 = num7 & (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index1];
          uint num9 = ProgCommand.DeviceBuffers.ConfigWords[index1] & (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index1];
          if (index1 == (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPConfig - 1)
          {
            if (this.enableCodeProtectToolStripMenuItem.Enabled && this.enableCodeProtectToolStripMenuItem.Checked)
              num9 &= (uint) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask;
            if (this.enableDataProtectStripMenuItem.Enabled && this.enableDataProtectStripMenuItem.Checked)
              num9 &= (uint) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask;
          }
          if ((int) num9 != (int) num8)
          {
            this.conditionalVDDOff();
            this.displayStatusWindow.Text = "Error de Verificación en Bits CONFIG!";
            FormProgUSB.statusWindowColor = Constants.StatusColor.red;
            this.updateGUI(true);
            return false;
          }
        }
      }
      return true;
    }

    private void downloadPUSBFirmware(object sender, EventArgs e)
    {
      if (this.openFWFile.ShowDialog() != DialogResult.OK)
        return;
      this.downloadNewFirmware();
    }

    private void downloadNewFirmware()
    {
      this.progressBar1.Value = 0;
      this.progressBar1.Maximum = 2;
      this.displayStatusWindow.Text = "Reparando ROM interno, espere...";
      this.displayStatusWindow.BackColor = Color.SteelBlue;
      this.Update();
      if (!PUSBBootLoader.ReadHexAndDownload(this.openFWFile.FileName, ref FormProgUSB.pk2number))
      {
        this.displayStatusWindow.Text = "Error al reparar ROM!\nContactar al soporte técnico.";
        this.displayStatusWindow.BackColor = Color.OrangeRed;
        this.downloadPICkit2FirmwareToolStripMenuItem.Enabled = false;
        this.chkBoxVddOn.Enabled = false;
        this.numUpDnVDD.Enabled = false;
        this.deviceToolStripMenuItem.Enabled = false;
        this.disableGUIControls();
      }
      else
      {
        this.progressBar1.PerformStep();
        this.displayStatusWindow.Text = "Verificando ROM interno, espere...";
        this.Update();
        if (!PUSBBootLoader.ReadHexAndVerify(this.openFWFile.FileName))
        {
          this.displayStatusWindow.Text = "Error al escribir el ROM interno!\nContactar al soporte técnico";
          this.displayStatusWindow.BackColor = Color.OrangeRed;
        }
        else if (!ProgCommand.BL_WriteFWLoadedKey())
        {
          this.displayStatusWindow.Text = "Error al escribir el ROM!\nContactar al soporte técnico.";
          this.displayStatusWindow.BackColor = Color.OrangeRed;
        }
        else
        {
          this.progressBar1.PerformStep();
          this.displayStatusWindow.Text = "Escritura Correcta!\nReiniciando MASTER-PROG...";
          this.displayStatusWindow.BackColor = Color.YellowGreen;
          this.Update();
          ProgCommand.BL_Reset();
          Thread.Sleep(5000);
          ProgCommand.ResetPUSBNumber();
          if (!this.detectPICkit2(true, true))
            return;
          ProgCommand.VddOff();
          this.lookForPoweredTarget(false);
          if (ProgCommand.DetectDevice(16777215, true, this.chkBoxVddOn.Checked))
          {
            this.setGUIVoltageLimits(true);
            this.displayStatusWindow.Text = this.displayStatusWindow.Text + "\nPIC Encontrado.";
            this.fullEnableGUIControls();
          }
          else
            this.partialEnableGUIControls();
          this.checkForPowerErrors();
          this.updateGUI(true);
        }
      }
    }

    private void programmingSpeed(object sender, EventArgs e)
    {
      if (this.fastProgrammingToolStripMenuItem.Checked)
      {
        ProgCommand.SetFastProgramming(true);
        this.displayStatusWindow.BackColor = Color.Aqua;
        if (ProgCommand.FamilyIsEEPROM())
        {
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 1)
            this.displayStatusWindow.Text = "Frecuencia del Bus I2C = 400kHz\n";
          else if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 4)
            this.displayStatusWindow.Text = "Frecuencia del Reloj = 100kHz\n";
          else
            this.displayStatusWindow.Text = "Frecuencia de SCK = 925kHz\n";
        }
        else
        {
          this.displayStatusWindow.Text = "Programación Rápida Activada!\n";
          Label label = this.displayStatusWindow;
          string str = label.Text + "(Desactivar en Caso de Errores)";
          label.Text = str;
        }
      }
      else
      {
        ProgCommand.SetFastProgramming(false);
        this.displayStatusWindow.BackColor = Color.Aqua;
        if (ProgCommand.FamilyIsEEPROM())
        {
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 1)
            this.displayStatusWindow.Text = "Frecuencia del Bus I2C = 100kHz\n";
          else if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 4)
            this.displayStatusWindow.Text = "Frecuencia del Reloj = 25kHz\n";
          else
            this.displayStatusWindow.Text = "Frecuencia de SCK = 245kHz\n";
        }
        else
        {
          this.displayStatusWindow.Text = "Programación Rápida Desactivada!\n";
          Label label = this.displayStatusWindow;
          string str = label.Text + "(Reduce los Errores de Escritura/Lectura)";
          label.Text = str;
        }
      }
    }

    private void clickAbout(object sender, EventArgs e)
    {
      int num = (int) new DialogAbout().ShowDialog();
    }

    private void launchUsersGuide(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\Instalación.pdf");
      }
      catch
      {
        int num = (int) MessageBox.Show("Error al abrir el archivo!");
      }
    }

    private void launchReadMe(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\MASTER-PROG.txt");
      }
      catch
      {
        int num = (int) MessageBox.Show("Hubo Un Error Al Abrir El Archivo!");
      }
    }

    private void codeProtect(object sender, EventArgs e)
    {
      if (this.enableDataProtectStripMenuItem.Enabled && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask == 0)
        this.enableDataProtectStripMenuItem.Checked = this.enableCodeProtectToolStripMenuItem.Checked;
      this.updateGUI(true);
    }

    private void dataProtect(object sender, EventArgs e)
    {
      if (this.enableDataProtectStripMenuItem.Enabled && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DPMask == 0)
        this.enableCodeProtectToolStripMenuItem.Checked = this.enableDataProtectStripMenuItem.Checked;
      this.updateGUI(true);
    }

    private void writeOnButton(object sender, EventArgs e)
    {
      if (this.writeOnPICkitButtonToolStripMenuItem.Checked)
      {
        this.timerButton.Enabled = true;
        this.buttonLast = true;
        this.displayStatusWindow.Text = "Función Futura (No Implementada)";
      }
      else
        this.timerButton.Enabled = false;
    }

    private void timerGoesOff(object sender, EventArgs e)
    {
      if (!ProgCommand.ButtonPressed())
      {
        this.buttonLast = false;
      }
      else
      {
        if (this.buttonLast)
          return;
        this.buttonLast = true;
        this.deviceWrite();
        this.checkForPowerErrors();
      }
    }

    private void conditionalVDDOff()
    {
      if (this.chkBoxVddOn.Checked)
        return;
      ProgCommand.VddOff();
    }

    private void buttonReadExport(object sender, EventArgs e)
    {
      if (ProgCommand.FamilyIsKeeloq())
      {
        this.displayStatusWindow.Text = "Función Inválida Para el Tipo Seleccionado!";
        FormProgUSB.statusWindowColor = Constants.StatusColor.yellow;
        this.updateGUI(false);
      }
      else
      {
        this.deviceRead();
        this.updateGUI(true);
        this.Refresh();
        int num = (int) this.saveHexFileDialog.ShowDialog();
      }
    }

    private void menuVDDAuto(object sender, EventArgs e)
    {
      this.vddAuto();
    }

    private void vddAuto()
    {
      this.autoDetectToolStripMenuItem.Checked = true;
      this.forcePICkit2ToolStripMenuItem.Checked = false;
      this.forceTargetToolStripMenuItem.Checked = false;
      this.lookForPoweredTarget(false);
    }

    private void menuVDDPUSB(object sender, EventArgs e)
    {
      this.vddPUSB();
    }

    private void vddPUSB()
    {
      this.autoDetectToolStripMenuItem.Checked = false;
      this.forcePICkit2ToolStripMenuItem.Checked = true;
      this.forceTargetToolStripMenuItem.Checked = false;
      this.lookForPoweredTarget(false);
    }

    private void menuVDDTarget(object sender, EventArgs e)
    {
      this.vddTarget();
    }

    private void vddTarget()
    {
      this.autoDetectToolStripMenuItem.Checked = false;
      this.forcePICkit2ToolStripMenuItem.Checked = false;
      this.forceTargetToolStripMenuItem.Checked = true;
      this.lookForPoweredTarget(false);
    }

    private void deviceFamilyClick(object sender, ToolStripItemClickedEventArgs e)
    {
      ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem) e.ClickedItem;
      if (toolStripMenuItem.HasDropDownItems)
        return;
      string str = !toolStripMenuItem.OwnerItem.Equals((object) this.deviceToolStripMenuItem) ? toolStripMenuItem.OwnerItem.Text + "/" + toolStripMenuItem.Text : toolStripMenuItem.Text;
      int family = 0;
      while (family < ProgCommand.DevFile.Families.Length && !(str == ProgCommand.DevFile.Families[family].FamilyName))
        ++family;
      for (int index = 1; index < ProgCommand.DevFile.Info.NumberParts; ++index)
      {
        if ((int) ProgCommand.DevFile.PartsList[index].Family == family)
        {
          ProgCommand.DevFile.PartsList[0].VddMax = ProgCommand.DevFile.PartsList[index].VddMax;
          ProgCommand.DevFile.PartsList[0].VddMin = ProgCommand.DevFile.PartsList[index].VddMin;
          break;
        }
      }
      this.FamilySelectLogic(family, true);
    }

    private void FamilySelectLogic(int family, bool updateGUI_OK)
    {
      if (family != ProgCommand.GetActiveFamily())
      {
        ProgCommand.ActivePart = 0;
        this.setGUIVoltageLimits(true);
      }
      else
        this.setGUIVoltageLimits(false);
      this.displayStatusWindow.Text = "";
      if (ProgCommand.DevFile.Families[family].PartDetect)
      {
        ProgCommand.SetActiveFamily(family);
        if (this.preProgrammingCheck(family))
        {
          this.displayStatusWindow.Text = "Dispositivo " + ProgCommand.DevFile.Families[family].FamilyName + " Detectado!";
          this.setGUIVoltageLimits(false);
        }
        this.comboBoxSelectPart.Visible = false;
        this.displayDevice.Visible = true;
        if (updateGUI_OK)
          this.updateGUI(true);
      }
      else
      {
        this.buildDeviceSelectDropDown(family);
        this.comboBoxSelectPart.Visible = true;
        this.comboBoxSelectPart.SelectedIndex = 0;
        this.displayDevice.Visible = true;
        ProgCommand.SetActiveFamily(family);
        if (updateGUI_OK)
          this.updateGUI(true);
        this.disableGUIControls();
      }
      this.displayDataSource.Text = "Archivo Nulo";
    }

    private void buildDeviceSelectDropDown(int family)
    {
      this.comboBoxSelectPart.Items.Clear();
      this.comboBoxSelectPart.Items.Add((object) "-Seleccionar Aquí-");
      for (int index = 1; index < ProgCommand.DevFile.Info.NumberParts; ++index)
      {
        if ((int) ProgCommand.DevFile.PartsList[index].Family == family)
          this.comboBoxSelectPart.Items.Add((object) ProgCommand.DevFile.PartsList[index].PartName);
      }
    }

    private void selectPart(object sender, EventArgs e)
    {
      if (this.comboBoxSelectPart.SelectedIndex == 0)
      {
        this.disableGUIControls();
      }
      else
      {
        string str = this.comboBoxSelectPart.SelectedItem.ToString();
        this.fullEnableGUIControls();
        for (int index = 0; index < ProgCommand.DevFile.Info.NumberParts; ++index)
        {
          if (ProgCommand.DevFile.PartsList[index].PartName == str)
          {
            ProgCommand.ActivePart = index;
            break;
          }
        }
      }
      ProgCommand.PrepNewPart();
      this.setGUIVoltageLimits(true);
      this.displayDataSource.Text = "Archivo Nulo";
      this.updateGUI(true);
    }

    private void autoDownloadFW(object sender, EventArgs e)
    {
      this.timerDLFW.Enabled = false;
      this.displayStatusWindow.Text = "El ROM interno tiene un error!!\nContactar al sopore técnico.";
      if (MessageBox.Show("Hubo un error al acceder al MASTER-PROG Por favor contactar al soporte técnico.\n\nVer menú Ayuda > Soporte Técnico", "¡¡ E R R O R  I N T E R N O !!", MessageBoxButtons.OK) == DialogResult.OK)
        this.displayStatusWindow.Text = "El ROM interno tiene un error!!\nContactar al sopore técnico.";
      else
        this.displayStatusWindow.Text = "El ROM interno tiene un error!!\nContactar al sopore técnico.";
    }

    private void SaveINI()
    {
      StreamWriter text = File.CreateText(FormProgUSB.HomeDirectory + "\\MASTER.cfg");
      string str1 = ";ARCHIVO DE CONFIGURACION MASTER-PROG ";
      text.WriteLine(str1);
      DateTime now = DateTime.Now;
      string str2 = ";";
      text.WriteLine(str2);
      text.WriteLine("");
      string str3 = "Y";
      if (this.toolStripMenuItemManualSelect.Checked)
      {
        str3 = "N";
        this.searchOnStartup = false;
      }
      else if (!this.autoDetectInINI)
        this.searchOnStartup = true;
      text.WriteLine("ADET: " + str3);
      string str4 = "N";
      if (this.searchOnStartup)
        str4 = "Y";
      text.WriteLine("PDET: " + str4);
      string str5 = ProgCommand.DevFile.Families != null ? ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].FamilyName : this.lastFamily;
      text.WriteLine("LFAM: " + str5);
      string str6 = "N";
      if (this.verifyOnWriteToolStripMenuItem.Checked)
        str6 = "Y";
      text.WriteLine("VRFW: " + str6);
      string str7 = "N";
      if (this.writeOnPICkitButtonToolStripMenuItem.Checked)
        str7 = "Y";
      text.WriteLine("WRBT: " + str7);
      string str8 = "N";
      if (this.MCLRtoolStripMenuItem.Checked)
        str8 = "Y";
      text.WriteLine("MCLR: " + str8);
      if (this.VppFirstToolStripMenuItem.Checked)
        this.restoreVddTarget();
      string str9 = "Auto";
      if (this.forcePICkit2ToolStripMenuItem.Checked)
        str9 = "Interno";
      else if (this.forceTargetToolStripMenuItem.Checked)
        str9 = "Externo";
      text.WriteLine("TVDD: " + str9);
      string str10 = "N";
      if (this.fastProgrammingToolStripMenuItem.Checked)
        str10 = "Y";
      text.WriteLine("FPRG: " + str10);
      string str11 = string.Format("PCLK: {0:G}", (object) this.slowSpeedICSP);
      text.WriteLine(str11);
      string str12 = "N";
      if (this.multiWindow)
        this.comboBoxProgMemView.SelectedIndex = this.programMemMultiWin.GetViewMode();
      if (this.comboBoxProgMemView.SelectedIndex == 1)
        str12 = "Y";
      else if (this.comboBoxProgMemView.SelectedIndex == 2)
        str12 = "B";
      text.WriteLine("PASC: " + str12);
      string str13 = "N";
      if (this.multiWindow)
        this.comboBoxProgMemView.SelectedIndex = this.eepromDataMultiWin.GetViewMode();
      if (this.comboBoxEE.SelectedIndex == 1)
        str13 = "Y";
      else if (this.comboBoxEE.SelectedIndex == 2)
        str13 = "B";
      text.WriteLine("EASC: " + str13);
      string str14 = "N";
      if (this.allowDataEdits)
        str14 = "Y";
      text.WriteLine("EDIT: " + str14);
      if (this.displayRev.Visible)
        text.WriteLine("REVS: Y");
      string str15 = string.Format("SETV: {0:0.0}", (object) this.numUpDnVDD.Value);
      text.WriteLine(str15);
      string str16 = "N";
      if (this.toolStripMenuItemClearBuffersErase.Checked)
        str16 = "Y";
      text.WriteLine("CLBF: " + str16);
      text.WriteLine("HEX1: " + this.hex1);
      text.WriteLine("HEX2: " + this.hex2);
      text.WriteLine("HEX3: " + this.hex3);
      text.WriteLine("HEX4: " + this.hex4);
      if (this.selectDeviceFile)
        text.WriteLine("SDAT: Y");
      if (FormProgUSB.TestMemoryEnabled)
      {
        string str17 = "N";
        if (FormProgUSB.TestMemoryOpen)
          str17 = "Y";
        text.WriteLine("TMEN: " + str17);
        string str18 = string.Format("TMWD: {0:G}", (object) FormProgUSB.TestMemoryWords);
        text.WriteLine(str18);
        string str19 = "N";
        if (FormProgUSB.TestMemoryImportExport)
          str19 = "Y";
        text.WriteLine("TMIE: " + str19);
      }
      string str20 = "N";
      if (this.multiWindow)
        str20 = "Y";
      text.WriteLine("MWEN: " + str20);
      string str21 = string.Format("MWLX: {0:G}", (object) this.Location.X);
      text.WriteLine(str21);
      string str22 = string.Format("MWLY: {0:G}", (object) this.Location.Y);
      text.WriteLine(str22);
      string str23 = "N";
      if (this.mainWinOwnsMem)
        str23 = "Y";
      text.WriteLine("MWFR: " + str23);
      string str24 = "N";
      if (this.multiWinPMemOpen)
        str24 = "Y";
      text.WriteLine("PMEN: " + str24);
      string str25 = string.Format("PMLX: {0:G}", (object) this.programMemMultiWin.Location.X);
      text.WriteLine(str25);
      string str26 = string.Format("PMLY: {0:G}", (object) this.programMemMultiWin.Location.Y);
      text.WriteLine(str26);
      string str27 = string.Format("PMSX: {0:G}", (object) this.programMemMultiWin.Size.Width);
      text.WriteLine(str27);
      string str28 = string.Format("PMSY: {0:G}", (object) this.programMemMultiWin.Size.Height);
      text.WriteLine(str28);
      string str29 = "N";
      if (this.multiWinEEMemOpen)
        str29 = "Y";
      text.WriteLine("EEEN: " + str29);
      string str30 = string.Format("EELX: {0:G}", (object) this.eepromDataMultiWin.Location.X);
      text.WriteLine(str30);
      string str31 = string.Format("EELY: {0:G}", (object) this.eepromDataMultiWin.Location.Y);
      text.WriteLine(str31);
      string str32 = string.Format("EESX: {0:G}", (object) this.eepromDataMultiWin.Size.Width);
      text.WriteLine(str32);
      string str33 = string.Format("EESY: {0:G}", (object) this.eepromDataMultiWin.Size.Height);
      text.WriteLine(str33);
      text.WriteLine("UABD: " + this.uartWindow.GetBaudRate());
      string str34 = "N";
      if (this.uartWindow.IsHexMode())
        str34 = "Y";
      text.WriteLine("UAHX: " + str34);
      text.WriteLine("UAS1: " + this.uartWindow.GetStringMacro(1));
      text.WriteLine("UAS2: " + this.uartWindow.GetStringMacro(2));
      text.WriteLine("UAS3: " + this.uartWindow.GetStringMacro(3));
      text.WriteLine("UAS4: " + this.uartWindow.GetStringMacro(4));
      string str35 = "N";
      if (this.uartWindow.GetAppendCRLF())
        str35 = "Y";
      text.WriteLine("UACL: " + str35);
      string str36 = "N";
      if (this.uartWindow.GetWrap())
        str36 = "Y";
      text.WriteLine("UAWR: " + str36);
      string str37 = "N";
      if (this.uartWindow.GetEcho())
        str37 = "Y";
      text.WriteLine("UAEC: " + str37);
      string str38 = "N";
      if (this.logicWindow.getModeAnalyzer())
        str38 = "Y";
      text.WriteLine("LTAM: " + str38);
      string str39 = string.Format("LTZM: {0:G}", (object) this.logicWindow.getZoom());
      text.WriteLine(str39);
      string str40 = string.Format("LTT1: {0:G}", (object) this.logicWindow.getCh1Trigger());
      text.WriteLine(str40);
      string str41 = string.Format("LTT2: {0:G}", (object) this.logicWindow.getCh2Trigger());
      text.WriteLine(str41);
      string str42 = string.Format("LTT3: {0:G}", (object) this.logicWindow.getCh3Trigger());
      text.WriteLine(str42);
      string str43 = string.Format("LTTC: {0:G}", (object) this.logicWindow.getTrigCount());
      text.WriteLine(str43);
      string str44 = string.Format("LTSR: {0:G}", (object) this.logicWindow.getSampleRate());
      text.WriteLine(str44);
      string str45 = string.Format("LTTP: {0:G}", (object) this.logicWindow.getTriggerPosition());
      text.WriteLine(str45);
      string str46 = "N";
      if (this.logicWindow.getCursorsEnabled())
        str46 = "Y";
      text.WriteLine("LTCE: " + str46);
      string str47 = string.Format("LTCX: {0:G}", (object) this.logicWindow.getXCursorPos());
      text.WriteLine(str47);
      string str48 = string.Format("LTCY: {0:G}", (object) this.logicWindow.getYCursorPos());
      text.WriteLine(str48);
      string str49 = "0";
      if ((int) this.ptgMemory > 0)
        str49 = "1";
      text.WriteLine("PTGM: " + str49);
      ((TextWriter) text).Flush();
      text.Close();
    }

    private float loadINI()
    {
      float num = 0.0f;
      try
      {
        int height1 = SystemInformation.VirtualScreen.Height;
        int width1 = SystemInformation.VirtualScreen.Width;
        FileInfo fileInfo = new FileInfo("MASTER.cfg");
        FormProgUSB.HomeDirectory = fileInfo.DirectoryName;
        TextReader textReader = (TextReader) fileInfo.OpenText();
        for (string str = textReader.ReadLine(); str != null; str = textReader.ReadLine())
        {
          if (str != "" && string.Compare(str.Substring(0, 1), ";") != 0 && string.Compare(str.Substring(0, 1), " ") != 0)
          {
            switch (str.Substring(0, 5))
            {
              case "ADET:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.toolStripMenuItemManualSelect.Checked = true;
                  this.autoDetectInINI = false;
                  this.searchOnStartup = false;
                  continue;
                }
                else
                  continue;
              case "PDET:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.searchOnStartup = false;
                  continue;
                }
                else
                  continue;
              case "LFAM:":
                this.lastFamily = str.Substring(6);
                continue;
              case "VRFW:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.verifyOnWriteToolStripMenuItem.Checked = false;
                  continue;
                }
                else
                  continue;
              case "WRBT:":
                if (string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  this.writeOnPICkitButtonToolStripMenuItem.Checked = true;
                  this.timerButton.Enabled = true;
                  this.buttonLast = true;
                  continue;
                }
                else
                  continue;
              case "MCLR:":
                if (string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  this.MCLRtoolStripMenuItem.Checked = true;
                  this.checkBoxMCLR.Checked = true;
                  ProgCommand.HoldMCLR(true);
                  continue;
                }
                else
                  continue;
              case "TVDD:":
                if (string.Compare(str.Substring(6, 1), "P") == 0)
                {
                  this.vddPUSB();
                  continue;
                }
                else if (string.Compare(str.Substring(6, 1), "T") == 0)
                {
                  this.vddTarget();
                  continue;
                }
                else
                  continue;
              case "FPRG:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.fastProgrammingToolStripMenuItem.Checked = false;
                  ProgCommand.SetFastProgramming(false);
                  continue;
                }
                else
                  continue;
              case "PCLK:":
                this.slowSpeedICSP = str.Length != 7 ? byte.Parse(str.Substring(6, 2)) : byte.Parse(str.Substring(6, 1));
                if ((int) this.slowSpeedICSP < 2)
                  this.slowSpeedICSP = (byte) 2;
                if ((int) this.slowSpeedICSP > 16)
                {
                  this.slowSpeedICSP = (byte) 16;
                  continue;
                }
                else
                  continue;
              case "PASC:":
                if (string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  this.comboBoxProgMemView.SelectedIndex = 1;
                  continue;
                }
                else if (string.Compare(str.Substring(6, 1), "B") == 0)
                {
                  this.comboBoxProgMemView.SelectedIndex = 2;
                  continue;
                }
                else
                  continue;
              case "EASC:":
                if (string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  this.comboBoxEE.SelectedIndex = 1;
                  continue;
                }
                else if (string.Compare(str.Substring(6, 1), "B") == 0)
                {
                  this.comboBoxEE.SelectedIndex = 2;
                  continue;
                }
                else
                  continue;
              case "EDIT:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.allowDataEdits = false;
                  this.calibrateToolStripMenuItem.Visible = false;
                  continue;
                }
                else
                  continue;
              case "REVS:":
                this.displayRev.Visible = true;
                continue;
              case "SETV:":
                if (str.Length == 9)
                {
                  num = float.Parse(str.Substring(6, 3));
                  if ((double) num > 5.0)
                    num = 5f;
                  if ((double) num < 2.5)
                  {
                    num = 2.5f;
                    continue;
                  }
                  else
                    continue;
                }
                else
                {
                  num = 0.0f;
                  continue;
                }
              case "CLBF:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.toolStripMenuItemClearBuffersErase.Checked = false;
                  continue;
                }
                else
                  continue;
              case "HEX1:":
                this.hex1 = str.Substring(6);
                if (this.hex1.Length > 3)
                {
                  this.hex1ToolStripMenuItem.Visible = true;
                  this.toolStripMenuItem5.Visible = true;
                  continue;
                }
                else
                  continue;
              case "HEX2:":
                this.hex2 = str.Substring(6);
                if (this.hex2.Length > 3)
                {
                  this.hex2ToolStripMenuItem.Visible = true;
                  continue;
                }
                else
                  continue;
              case "HEX3:":
                this.hex3 = str.Substring(6);
                if (this.hex3.Length > 3)
                {
                  this.hex3ToolStripMenuItem.Visible = true;
                  continue;
                }
                else
                  continue;
              case "HEX4:":
                this.hex4 = str.Substring(6);
                if (this.hex4.Length > 3)
                {
                  this.hex4ToolStripMenuItem.Visible = true;
                  continue;
                }
                else
                  continue;
              case "SDAT:":
                if (string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  this.selectDeviceFile = true;
                  continue;
                }
                else
                  continue;
              case "TMEN:":
                FormProgUSB.TestMemoryEnabled = true;
                if (str.Length > 5 && string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  FormProgUSB.TestMemoryOpen = true;
                  continue;
                }
                else
                  continue;
              case "TMWD:":
                FormProgUSB.TestMemoryWords = int.Parse(str.Substring(6, str.Length - 6));
                if (FormProgUSB.TestMemoryWords < 16)
                  FormProgUSB.TestMemoryWords = 16;
                if (FormProgUSB.TestMemoryWords > 1024)
                {
                  FormProgUSB.TestMemoryWords = 1024;
                  continue;
                }
                else
                  continue;
              case "TMIE:":
                if (string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  FormProgUSB.TestMemoryImportExport = true;
                  continue;
                }
                else
                  continue;
              case "MWEN:":
                if (string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  this.multiWindow = true;
                  this.viewChanged = true;
                  continue;
                }
                else
                  continue;
              case "MWLX:":
                int x1 = int.Parse(str.Substring(6, str.Length - 6));
                if (x1 < 0)
                  x1 = 0;
                if (x1 > width1)
                  x1 = width1 - 75;
                this.Location = new Point(x1, this.Location.Y);
                continue;
              case "MWLY:":
                int y1 = int.Parse(str.Substring(6, str.Length - 6));
                if (y1 < 0)
                  y1 = 0;
                if (y1 > height1)
                  y1 = height1 - 75;
                this.Location = new Point(this.Location.X, y1);
                continue;
              case "MWFR:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.mainWinOwnsMem = false;
                  continue;
                }
                else
                  continue;
              case "PMEN:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.multiWinPMemOpen = false;
                  continue;
                }
                else
                  continue;
              case "PMLX:":
                int x2 = int.Parse(str.Substring(6, str.Length - 6));
                if (x2 < 0)
                  x2 = 0;
                if (x2 > width1)
                  x2 = width1 - 75;
                this.programMemMultiWin.Location = new Point(x2, this.programMemMultiWin.Location.Y);
                continue;
              case "PMLY:":
                int y2 = int.Parse(str.Substring(6, str.Length - 6));
                if (y2 < 0)
                  y2 = 0;
                if (y2 > height1)
                  y2 = height1 - 75;
                this.programMemMultiWin.Location = new Point(this.programMemMultiWin.Location.X, y2);
                continue;
              case "PMSX:":
                int width2 = int.Parse(str.Substring(6, str.Length - 6));
                if (width2 < 50)
                  width2 = 50;
                if (width2 > width1)
                  width2 = width1;
                this.programMemMultiWin.Size = new Size(width2, this.programMemMultiWin.Size.Height);
                continue;
              case "PMSY:":
                int height2 = int.Parse(str.Substring(6, str.Length - 6));
                if (height2 < 50)
                  height2 = 50;
                if (height2 > height1)
                  height2 = height1;
                this.programMemMultiWin.Size = new Size(this.programMemMultiWin.Size.Width, height2);
                continue;
              case "EEEN:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.multiWinEEMemOpen = false;
                  continue;
                }
                else
                  continue;
              case "EELX:":
                int x3 = int.Parse(str.Substring(6, str.Length - 6));
                if (x3 < 0)
                  x3 = 0;
                if (x3 > width1)
                  x3 = width1 - 75;
                this.eepromDataMultiWin.Location = new Point(x3, this.eepromDataMultiWin.Location.Y);
                continue;
              case "EELY:":
                int y3 = int.Parse(str.Substring(6, str.Length - 6));
                if (y3 < 0)
                  y3 = 0;
                if (y3 > height1)
                  y3 = height1 - 75;
                this.eepromDataMultiWin.Location = new Point(this.eepromDataMultiWin.Location.X, y3);
                continue;
              case "EESX:":
                int width3 = int.Parse(str.Substring(6, str.Length - 6));
                if (width3 < 50)
                  width3 = 50;
                if (width3 > width1)
                  width3 = width1;
                this.eepromDataMultiWin.Size = new Size(width3, this.eepromDataMultiWin.Size.Height);
                continue;
              case "EESY:":
                int height3 = int.Parse(str.Substring(6, str.Length - 6));
                if (height3 < 50)
                  height3 = 50;
                if (height3 > height1)
                  height3 = height1;
                this.eepromDataMultiWin.Size = new Size(this.eepromDataMultiWin.Size.Width, height3);
                continue;
              case "UABD:":
                this.uartWindow.SetBaudRate(str.Substring(6));
                continue;
              case "UAHX:":
                if (string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  this.uartWindow.SetModeHex();
                  continue;
                }
                else
                  continue;
              case "UAS1:":
                this.uartWindow.SetStringMacro(str.Substring(6), 1);
                continue;
              case "UAS2:":
                this.uartWindow.SetStringMacro(str.Substring(6), 2);
                continue;
              case "UAS3:":
                this.uartWindow.SetStringMacro(str.Substring(6), 3);
                continue;
              case "UAS4:":
                this.uartWindow.SetStringMacro(str.Substring(6), 4);
                continue;
              case "UACL:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.uartWindow.ClearAppendCRLF();
                  continue;
                }
                else
                  continue;
              case "UAWR:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.uartWindow.ClearWrap();
                  continue;
                }
                else
                  continue;
              case "UAEC:":
                if (string.Compare(str.Substring(6, 1), "N") == 0)
                {
                  this.uartWindow.ClearEcho();
                  continue;
                }
                else
                  continue;
              case "LTAM:":
                if (string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  this.logicWindow.setModeAnalyzer();
                  continue;
                }
                else
                  continue;
              case "LTZM:":
                int zoom = int.Parse(str.Substring(6, str.Length - 6));
                if (zoom > 3)
                  zoom = 3;
                this.logicWindow.setZoom(zoom);
                continue;
              case "LTT1:":
                int trig1 = int.Parse(str.Substring(6, str.Length - 6));
                if (trig1 > 5)
                  trig1 = 5;
                this.logicWindow.setCh1Trigger(trig1);
                continue;
              case "LTT2:":
                int trig2 = int.Parse(str.Substring(6, str.Length - 6));
                if (trig2 > 5)
                  trig2 = 5;
                this.logicWindow.setCh2Trigger(trig2);
                continue;
              case "LTT3:":
                int trig3 = int.Parse(str.Substring(6, str.Length - 6));
                if (trig3 > 5)
                  trig3 = 5;
                this.logicWindow.setCh3Trigger(trig3);
                continue;
              case "LTTC:":
                int count = int.Parse(str.Substring(6, str.Length - 6));
                if (count > 256)
                  count = 256;
                if (count < 1)
                  count = 1;
                this.logicWindow.setTrigCount(count);
                continue;
              case "LTSR:":
                int rate = int.Parse(str.Substring(6, str.Length - 6));
                if (rate > 7)
                  rate = 7;
                this.logicWindow.setSampleRate(rate);
                continue;
              case "LTTP:":
                int trigpos = int.Parse(str.Substring(6, str.Length - 6));
                if (trigpos > 5)
                  trigpos = 5;
                this.logicWindow.setTriggerPosition(trigpos);
                continue;
              case "LTCE:":
                if (string.Compare(str.Substring(6, 1), "Y") == 0)
                {
                  this.logicWindow.setCursorsEnabled(true);
                  continue;
                }
                else
                  continue;
              case "LTCX:":
                int pos1 = int.Parse(str.Substring(6, str.Length - 6));
                if (pos1 > 4095)
                  pos1 = 4095;
                this.logicWindow.setXCursorPos(pos1);
                continue;
              case "LTCY:":
                int pos2 = int.Parse(str.Substring(6, str.Length - 6));
                if (pos2 > 4095)
                  pos2 = 4095;
                this.logicWindow.setYCursorPos(pos2);
                continue;
              case "PTGM:":
                if (string.Compare(str.Substring(6, 1), "1") == 0)
                {
                  this.ptgMemory = (byte) 1;
                  continue;
                }
                else
                  continue;
              default:
                continue;
            }
          }
        }
        textReader.Close();
      }
      catch
      {
        return 0.0f;
      }
      this.hex1ToolStripMenuItem.Text = "&1 " + this.shortenHex(this.hex1);
      this.hex2ToolStripMenuItem.Text = "&2 " + this.shortenHex(this.hex2);
      this.hex3ToolStripMenuItem.Text = "&3 " + this.shortenHex(this.hex3);
      this.hex4ToolStripMenuItem.Text = "&4 " + this.shortenHex(this.hex4);
      return num;
    }

    private string shortenHex(string fullPath)
    {
      if (fullPath.Length > 42)
        return fullPath.Substring(0, 3) + "..." + fullPath.Substring(fullPath.Length - 36);
      else
        return fullPath;
    }

    private void hex1Click(object sender, EventArgs e)
    {
      this.hexImportFromHistory(this.hex1);
    }

    private void hex2Click(object sender, EventArgs e)
    {
      this.hexImportFromHistory(this.hex2);
    }

    private void hex3Click(object sender, EventArgs e)
    {
      this.hexImportFromHistory(this.hex3);
    }

    private void hex4Click(object sender, EventArgs e)
    {
      this.hexImportFromHistory(this.hex4);
    }

    private void hexImportFromHistory(string filename)
    {
      if (!this.importFileToolStripMenuItem.Enabled || filename.Length <= 3)
        return;
      this.openHexFileDialog.FileName = filename;
      this.importHexFileGo();
      this.updateGUI(true);
    }

    private void launchLPCDemoGuide(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\Archvio_1.pdf");
      }
      catch
      {
        int num = (int) MessageBox.Show("No se pudo Abrir el Archivo!");
      }
    }

    private void uG44pinToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\Archvio_2.pdf");
      }
      catch
      {
        int num = (int) MessageBox.Show("No se pudo Abrir el Archivo!");
      }
    }

    private void memorySelectVerify(object sender, EventArgs e)
    {
      if (sender.Equals((object) this.checkBoxProgMemEnabled))
        this.checkBoxProgMemEnabledAlt.Checked = this.checkBoxProgMemEnabled.Checked;
      if (sender.Equals((object) this.checkBoxProgMemEnabledAlt))
        this.checkBoxProgMemEnabled.Checked = this.checkBoxProgMemEnabledAlt.Checked;
      if (sender.Equals((object) this.checkBoxEEMem))
        this.checkBoxEEDATAMemoryEnabledAlt.Checked = this.checkBoxEEMem.Checked;
      if (sender.Equals((object) this.checkBoxEEDATAMemoryEnabledAlt))
        this.checkBoxEEMem.Checked = this.checkBoxEEDATAMemoryEnabledAlt.Checked;
      if (!this.checkBoxProgMemEnabled.Checked && !this.checkBoxEEMem.Checked)
      {
        int num = (int) MessageBox.Show("Se Debe Seleccionar Una Región de Memoria Mínimo");
        if (sender.Equals((object) this.checkBoxProgMemEnabled) || sender.Equals((object) this.checkBoxProgMemEnabledAlt))
        {
          this.checkBoxProgMemEnabled.Checked = true;
          this.checkBoxProgMemEnabledAlt.Checked = true;
        }
        else
        {
          this.checkBoxEEMem.Checked = true;
          this.checkBoxEEDATAMemoryEnabledAlt.Checked = true;
        }
      }
      this.updateGUI(false);
    }

    private void setOSCCAL(object sender, EventArgs e)
    {
      if (!this.setOSCCALToolStripMenuItem.Enabled)
        return;
      int num = (int) new SetOSCCAL().ShowDialog();
      if (FormProgUSB.setOSCCALValue)
      {
        this.eraseDeviceAll(true, new uint[0]);
        Label label = this.displayStatusWindow;
        string str = label.Text + "\nOSCCAL modificado.";
        label.Text = str;
      }
      FormProgUSB.setOSCCALValue = false;
      this.updateGUI(true);
    }

    private void pickit2OnTheWeb(object sender, EventArgs e)
    {
      try
      {
        Process.Start("http://www.microchip.com/stellent/idcplg?IdcService=SS_GET_PAGE&nodeId=2046");
      }
      catch
      {
        int num = (int) MessageBox.Show("Error al abrir el link");
      }
    }

    private void SoporteTecnico(object sender, EventArgs e)
    {
      try
      {
        Process.Start("mailto:edutronika@hotmail.com");
      }
      catch
      {
        int num = (int) MessageBox.Show("Error al abrir el link");
      }
    }

    private void VisitarMicrochip(object sender, EventArgs e)
    {
      try
      {
        Process.Start("http://www.microchip.com");
      }
      catch
      {
        int num = (int) MessageBox.Show("Error al abrir el link");
      }
    }

    private void troubleshhotToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new DialogTroubleshoot().ShowDialog();
      this.chkBoxVddOn.Checked = false;
      if (!FormProgUSB.selfPoweredTarget)
        return;
      ProgCommand.ForceTargetPowered();
    }

    private void MCLRtoolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.MCLRtoolStripMenuItem.Checked)
      {
        this.checkBoxMCLR.Checked = false;
        this.MCLRtoolStripMenuItem.Checked = false;
        ProgCommand.HoldMCLR(false);
      }
      else
      {
        this.checkBoxMCLR.Checked = true;
        this.MCLRtoolStripMenuItem.Checked = true;
        ProgCommand.HoldMCLR(true);
      }
    }

    private void toolStripMenuItemTestMemory_Click(object sender, EventArgs e)
    {
      if (!FormProgUSB.TestMemoryEnabled || FormProgUSB.TestMemoryOpen)
        return;
      this.openTestMemory();
    }

    private void openTestMemory()
    {
      FormProgUSB.formTestMem = new FormTestMemory();
      FormProgUSB.formTestMem.UpdateMainFormGUI = new DelegateUpdateGUI(this.ExtCallUpdateGUI);
      FormProgUSB.formTestMem.CallMainFormEraseWrCal = new DelegateWriteCal(this.ExtCallCalEraseWrite);
      ((Control) FormProgUSB.formTestMem).Show();
    }

    private void buttonImportWrite(object sender, EventArgs e)
    {
    }

    private void checkBoxAutoImportWrite_Click(object sender, EventArgs e)
    {
      if (!this.checkBoxAutoImportWrite.Checked)
      {
        this.displayStatusWindow.Text = "AUTOPROG Desactivado";
        this.checkBoxAutoImportWrite.Checked = false;
        this.displayStatusWindow.BackColor = Color.Aqua;
      }
      if (!this.checkBoxAutoImportWrite.Checked)
        return;
      this.importGo = false;
      if (this.hex1.Length > 3)
        this.openHexFileDialog.FileName = this.hex1;
      int num = (int) this.openHexFileDialog.ShowDialog();
      if (this.importGo)
      {
        this.updateGUI(true);
        this.Refresh();
        if (this.deviceWrite())
        {
          this.importFileToolStripMenuItem.Enabled = false;
          this.exportFileToolStripMenuItem.Enabled = false;
          this.programmerToolStripMenuItem.Enabled = false;
          this.setOSCCALToolStripMenuItem.Enabled = false;
          this.buttonRead.Enabled = false;
          this.buttonWrite.Enabled = false;
          this.button1.Enabled = false;
          this.buttonVerify.Enabled = false;
          this.buttonErase.Enabled = false;
          this.buttonBlankCheck.Enabled = false;
          this.dataGridProgramMemory.Enabled = false;
          this.dataGridViewEEPROM.Enabled = false;
          this.buttonExportHex.Enabled = false;
          this.deviceToolStripMenuItem.Enabled = false;
          this.checkCommunicationToolStripMenuItem.Enabled = false;
          this.troubleshhotToolStripMenuItem.Enabled = false;
          this.downloadPICkit2FirmwareToolStripMenuItem.Enabled = false;
          Label label = this.displayStatusWindow;
          string str = label.Text + "AUTOPROG Activo, Esperando Compilación...";
          label.Text = str;
          this.timerAutoImportWrite.Enabled = true;
        }
        else
          this.importGo = false;
      }
      else
        this.updateGUI(true);
      if (this.importGo)
        return;
      this.checkBoxAutoImportWrite.Checked = false;
    }

    private void checkBoxAutoImportWrite_Changed(object sender, EventArgs e)
    {
      if (this.checkBoxAutoImportWrite.Checked && this.importGo)
        return;
      this.importFileToolStripMenuItem.Enabled = true;
      this.exportFileToolStripMenuItem.Enabled = true;
      this.programmerToolStripMenuItem.Enabled = true;
      this.setOSCCALToolStripMenuItem.Enabled = true;
      this.buttonRead.Enabled = true;
      this.button1.Enabled = true;
      this.buttonWrite.Enabled = true;
      this.buttonVerify.Enabled = true;
      this.buttonErase.Enabled = true;
      this.buttonBlankCheck.Enabled = true;
      this.dataGridProgramMemory.Enabled = true;
      this.dataGridViewEEPROM.Enabled = true;
      this.buttonExportHex.Enabled = true;
      this.deviceToolStripMenuItem.Enabled = true;
      this.checkCommunicationToolStripMenuItem.Enabled = true;
      this.troubleshhotToolStripMenuItem.Enabled = true;
      this.downloadPICkit2FirmwareToolStripMenuItem.Enabled = true;
      this.timerAutoImportWrite.Enabled = false;
      /*FormProgUSB.FLASHWINFO pwfi = new FormProgUSB.FLASHWINFO();
      pwfi.cbSize = (ushort) Marshal.SizeOf((object) pwfi);
      pwfi.hwnd = this.Handle;
      pwfi.dwFlags = 14U;
      pwfi.uCount = ushort.MaxValue;
      pwfi.dwTimeout = 0U;
      int num = (int) FormProgUSB.FlashWindowEx(ref pwfi);*/
      if (this.WindowState != FormWindowState.Minimized)
        return;
      this.WindowState = FormWindowState.Normal;
    }

    private void timerAutoImportWrite_Tick(object sender, EventArgs e)
    {
      FileInfo fileInfo = new FileInfo(this.openHexFileDialog.FileName);
      if (!(ImportExportHex.LastWriteTime != fileInfo.LastWriteTime))
        return;
      if (this.deviceWrite())
      {
        this.importFileToolStripMenuItem.Enabled = false;
        this.exportFileToolStripMenuItem.Enabled = false;
        this.programmerToolStripMenuItem.Enabled = false;
        this.setOSCCALToolStripMenuItem.Enabled = false;
        this.buttonRead.Enabled = false;
        this.button1.Enabled = false;
        this.buttonWrite.Enabled = false;
        this.buttonVerify.Enabled = false;
        this.buttonErase.Enabled = false;
        this.buttonBlankCheck.Enabled = false;
        this.dataGridProgramMemory.Enabled = false;
        this.dataGridViewEEPROM.Enabled = false;
        this.buttonExportHex.Enabled = false;
        this.deviceToolStripMenuItem.Enabled = false;
        this.checkCommunicationToolStripMenuItem.Enabled = false;
        this.troubleshhotToolStripMenuItem.Enabled = false;
        this.downloadPICkit2FirmwareToolStripMenuItem.Enabled = false;
        Label label = this.displayStatusWindow;
        string str = label.Text + "AUTOPROG Activo, Esperando Compilación...";
        label.Text = str;
      }
      else
      {
        this.timerAutoImportWrite.Enabled = false;
        this.checkBoxAutoImportWrite.Checked = false;
      }
    }

    private bool checkForTest()
    {
      return false;
    }

    private bool testMenuBuild()
    {
      return false;
    }

    private void testMenuDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
    }

    private void buttonShowIDMem_Click(object sender, EventArgs e)
    {
      if (DialogUserIDs.IDMemOpen)
        return;
      this.dialogIDMemory = new DialogUserIDs();
      ((Control) this.dialogIDMemory).Show();
    }

    private uint getEEBlank()
    {
      uint num = (uint) byte.MaxValue;
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemAddressIncrement > 1)
        num = (uint) ushort.MaxValue;
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue == 4095)
        num = 4095U;
      return num;
    }

    private void restoreVddTarget()
    {
      if (this.VddTargetSave == Constants.VddTargetSelect.auto)
        this.vddAuto();
      else if (this.VddTargetSave == Constants.VddTargetSelect.pickit2)
        this.vddPUSB();
      else
        this.vddTarget();
    }

    private void VppFirstToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.VppFirstToolStripMenuItem.Checked)
      {
        ProgCommand.SetVPPFirstProgramEntry();
        this.displayStatusWindow.Text = "Forzar Programación en Alto Voltaje (Vpp=12V).\nUsat Sólo en ";
        this.VddTargetSave = !this.autoDetectToolStripMenuItem.Checked ? (!this.forcePICkit2ToolStripMenuItem.Checked ? Constants.VddTargetSelect.target : Constants.VddTargetSelect.pickit2) : Constants.VddTargetSelect.auto;
        this.vddPUSB();
        this.targetPowerToolStripMenuItem.Enabled = false;
      }
      else
      {
        ProgCommand.ClearVppFirstProgramEntry();
        this.displayStatusWindow.Text = "Modo de Programación Estándar";
        this.targetPowerToolStripMenuItem.Enabled = true;
        this.restoreVddTarget();
      }
    }

    private bool eepromWrite(bool eraseWrite)
    {
      if (!this.preProgrammingCheck(ProgCommand.GetActiveFamily()))
        return false;
      this.updateGUI(false);
      this.Update();
      if (this.checkImportFile && !eraseWrite)
      {
        FileInfo fileInfo = new FileInfo(this.openHexFileDialog.FileName);
        if (ImportExportHex.LastWriteTime != fileInfo.LastWriteTime)
        {
          this.displayStatusWindow.Text = "Abriendo archivo HEX\n";
          this.Update();
          Thread.Sleep(300);
          if (!this.importHexFileGo())
          {
            this.displayStatusWindow.Text = "Error al abrir el archivo HEX!\n";
            FormProgUSB.statusWindowColor = Constants.StatusColor.red;
            this.updateGUI(true);
            return false;
          }
        }
      }
      ProgCommand.VddOn();
      if (eraseWrite)
        this.displayStatusWindow.Text = "Borrando Dispositivo...\n";
      else
        this.displayStatusWindow.Text = "Programando Dispositivo...\n";
      this.Update();
      int num1 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem;
      if (this.checkBoxProgMemEnabled.Checked)
      {
        ProgCommand.RunScript(0, 1);
        Label label = this.displayStatusWindow;
        string str = label.Text + "EEPROM... ";
        label.Text = str;
        this.Update();
        this.progressBar1.Value = 0;
        int num2 = 3;
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 4)
          num2 = 4;
        int num3 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrWords;
        int num4 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
        int num5 = 256;
        if (num1 < num5)
          num5 = num1 + num1 / (num3 * num4) * num2;
        if (num5 > 256)
          num5 = 256;
        int repetitions = num5 / (num3 * num4 + num2);
        int num6 = repetitions * num3;
        int wordsWritten = 0;
        this.progressBar1.Maximum = num1 / num6;
        byte[] dataArray = new byte[256];
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrPrepScript != 0)
          ProgCommand.RunScript(6, 1);
        do
        {
          int lastIndex = 0;
          for (int index1 = 0; index1 < num6; ++index1)
          {
            if (wordsWritten == num1)
            {
              repetitions = lastIndex / (num3 * num4 + num2);
              break;
            }
            else
            {
              if (wordsWritten % num3 == 0)
              {
                int num7 = this.eeprom24BitAddress(wordsWritten, false);
                if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 4)
                  dataArray[lastIndex++] = (byte) 150;
                byte[] numArray1 = dataArray;
                int index2 = lastIndex;
                int num8 = 1;
                int num9 = index2 + num8;
                int num10 = (int) (byte) (num7 >> 16 & (int) byte.MaxValue);
                numArray1[index2] = (byte) num10;
                byte[] numArray2 = dataArray;
                int index3 = num9;
                int num11 = 1;
                int num12 = index3 + num11;
                int num13 = (int) (byte) (num7 >> 8 & (int) byte.MaxValue);
                numArray2[index3] = (byte) num13;
                byte[] numArray3 = dataArray;
                int index4 = num12;
                int num14 = 1;
                lastIndex = index4 + num14;
                int num15 = (int) (byte) (num7 & (int) byte.MaxValue);
                numArray3[index4] = (byte) num15;
              }
              uint num16 = ProgCommand.DeviceBuffers.ProgramMemory[wordsWritten++];
              dataArray[lastIndex++] = (byte) (num16 & (uint) byte.MaxValue);
              for (int index2 = 1; index2 < num4; ++index2)
              {
                num16 >>= 8;
                dataArray[lastIndex++] = (byte) (num16 & (uint) byte.MaxValue);
              }
              if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 3 && num4 == 2)
              {
                byte num7 = dataArray[lastIndex - 2];
                dataArray[lastIndex - 2] = dataArray[lastIndex - 1];
                dataArray[lastIndex - 1] = num7;
              }
            }
          }
          int startIndex = ProgCommand.DataClrAndDownload(dataArray, 0);
          while (startIndex < lastIndex)
            startIndex = ProgCommand.DataDownload(dataArray, startIndex, lastIndex);
          ProgCommand.RunScript(7, repetitions);
          if (((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 1 || (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 4) && this.eeprom_CheckBusErrors())
            return false;
          this.progressBar1.PerformStep();
        }
        while (wordsWritten < num1);
      }
      ProgCommand.RunScript(1, 1);
      bool flag = true;
      if (this.verifyOnWriteToolStripMenuItem.Checked && !eraseWrite)
      {
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 4)
          this.conditionalVDDOff();
        flag = this.deviceVerify(true, num1 - 1, false);
      }
      this.conditionalVDDOff();
      if (!flag || eraseWrite)
        return flag;
      FormProgUSB.statusWindowColor = Constants.StatusColor.green;
      this.displayStatusWindow.Text = "Programación Correcta!\n";
      this.updateGUI(true);
      return true;
    }

    private int eeprom24BitAddress(int wordsWritten, bool setReadBit)
    {
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 1)
      {
        int num1 = wordsWritten;
        int num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[3];
        int num3 = wordsWritten & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] & (int) ushort.MaxValue;
        int num4 = num1 >> (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[2] << 17 + num2;
        if (num2 > 0)
        {
          if (this.checkBoxA0CS.Checked)
            num4 |= 131072;
          if (this.checkBoxA1CS.Checked)
            num4 |= 262144;
          if (this.checkBoxA2CS.Checked)
            num4 |= 524288;
        }
        int num5 = num3 + ((num4 & 917504) + 10485760);
        if (setReadBit)
          num5 |= 65536;
        return num5;
      }
      else if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 2)
      {
        int num1 = wordsWritten;
        int num2;
        if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem <= 65536U)
        {
          num2 = (wordsWritten & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] & (int) ushort.MaxValue) + ((num1 >> (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[2] << 19 & 524288) + 131072);
          if (setReadBit)
            num2 |= 65536;
        }
        else
          num2 = wordsWritten;
        return num2;
      }
      else if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 3)
      {
        int num1 = 5;
        int num2 = wordsWritten & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] & (int) ushort.MaxValue;
        if (setReadBit)
          num1 = 6;
        int num3 = num1 << (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[2];
        return num2 | num3;
      }
      else
      {
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] != 4)
          return 0;
        int num = wordsWritten & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] & (int) ushort.MaxValue;
        return !setReadBit ? num | 7077888 : num | 196608;
      }
    }

    private bool eeprom_CheckBusErrors()
    {
      if (!ProgCommand.BusErrorCheck())
        return false;
      ProgCommand.RunScript(1, 1);
      this.conditionalVDDOff();
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] == 4)
        this.displayStatusWindow.Text = "Error en bus UNI/O (Sin señal SAK)!\nRevisar Conexiones y Reintentar";
      else
        this.displayStatusWindow.Text = "Error en bus I2C (Sin señal ACK)!\nRevisar Conexiones y Reintentar";
      FormProgUSB.statusWindowColor = Constants.StatusColor.yellow;
      this.updateGUI(true);
      return true;
    }

    private void calibrateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new DialogCalibrate().ShowDialog();
      this.chkBoxVddOn.Checked = false;
      if (FormProgUSB.selfPoweredTarget)
        ProgCommand.ForceTargetPowered();
      this.detectPICkit2(true, true);
    }

    private void UARTtoolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.timerButton.Enabled = false;
      this.MCLRtoolStripMenuItem.Checked = false;
      this.checkBoxMCLR.Checked = false;
      this.uartWindow.SetVddBox(this.numUpDnVDD.Enabled, this.chkBoxVddOn.Checked);
      if (this.multiWindow)
      {
        this.programMemMultiWin.Hide();
        this.eepromDataMultiWin.Hide();
      }
      this.Hide();
      int num = (int) this.uartWindow.ShowDialog();
      ((Control) this).Show();
      if (this.multiWindow)
      {
        if (this.multiWinPMemOpen)
          ((Control) this.programMemMultiWin).Show();
        if (this.multiWinEEMemOpen && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
          ((Control) this.eepromDataMultiWin).Show();
        this.Focus();
      }
      if (!FormProgUSB.selfPoweredTarget)
        ProgCommand.ForcePICkitPowered();
      if (!this.writeOnPICkitButtonToolStripMenuItem.Checked)
        return;
      this.buttonLast = true;
      this.timerButton.Enabled = true;
    }

    private void toolStripMenuItemSingleWindow_Click(object sender, EventArgs e)
    {
      if (this.multiWindow)
        this.viewChanged = true;
      this.multiWindow = false;
      this.updateGUI(true);
    }

    private void toolStripMenuItemMultiWindow_Click(object sender, EventArgs e)
    {
      if (!this.multiWindow)
        this.viewChanged = true;
      this.multiWindow = true;
      this.updateGUI(true);
    }

    private void toolStripMenuItemShowProgramMemory_Click(object sender, EventArgs e)
    {
      if (this.multiWinPMemOpen)
      {
        this.multiWinPMemOpen = false;
        this.toolStripMenuItemShowProgramMemory.Checked = false;
        this.programMemMultiWin.Hide();
      }
      else
      {
        this.multiWinPMemOpen = true;
        this.toolStripMenuItemShowProgramMemory.Checked = true;
        ((Control) this.programMemMultiWin).Show();
      }
      this.Focus();
    }

    private void toolStripMenuItemShowEEPROMData_Click(object sender, EventArgs e)
    {
      if (this.multiWinEEMemOpen)
      {
        this.multiWinEEMemOpen = false;
        this.toolStripMenuItemShowEEPROMData.Checked = false;
        this.eepromDataMultiWin.Hide();
      }
      else
      {
        this.multiWinEEMemOpen = true;
        this.toolStripMenuItemShowEEPROMData.Checked = true;
        ((Control) this.eepromDataMultiWin).Show();
      }
      this.Focus();
    }

    private void FormPICkit2_Move(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
        return;
      if (this.multiWindow && this.mainWinOwnsMem)
      {
        int num1 = this.Location.X - this.lastLoc.X;
        int num2 = this.Location.Y - this.lastLoc.Y;
        int height = SystemInformation.VirtualScreen.Height;
        int width = SystemInformation.VirtualScreen.Width;
        int x1 = this.programMemMultiWin.Location.X + num1;
        int y1 = this.programMemMultiWin.Location.Y + num2;
        if (x1 + 75 > width)
          x1 = width - 75;
        if (x1 < 0)
          x1 = 0;
        if (y1 + 75 > height)
          y1 = height - 75;
        if (y1 < 0)
          y1 = 0;
        if (this.programMemMultiWin.WindowState != FormWindowState.Maximized && this.programMemMultiWin.WindowState != FormWindowState.Minimized)
          this.programMemMultiWin.Location = new Point(x1, y1);
        int x2 = this.eepromDataMultiWin.Location.X + num1;
        int y2 = this.eepromDataMultiWin.Location.Y + num2;
        if (x2 + 75 > width)
          x2 = width - 75;
        if (x2 < 0)
          x2 = 0;
        if (y2 + 75 > height)
          y2 = height - 75;
        if (y2 < 0)
          y2 = 0;
        if (this.eepromDataMultiWin.WindowState != FormWindowState.Maximized && this.eepromDataMultiWin.WindowState != FormWindowState.Minimized)
          this.eepromDataMultiWin.Location = new Point(x2, y2);
      }
      this.lastLoc = this.Location;
    }

    private void pICkit2GoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (ProgCommand.FamilyIsEEPROM() || ProgCommand.FamilyIsKeeloq() || (ProgCommand.FamilyIsPIC32() || ProgCommand.FamilyIsMCP()) || ProgCommand.ActivePart == 0 || !this.checkBoxEEMem.Checked && this.checkBoxEEMem.Enabled && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemEraseScript == 0)
        return;
      if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 16383U)
      {
        int num1 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
        int num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
        int num3 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
        int length = ProgCommand.DeviceBuffers.ProgramMemory.Length;
        if ((long) num2 < (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem && num3 > 0)
          length -= num3 + 1;
        int num4 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemWrWords;
        int num5 = 256 / (num4 * num1) * num4;
        int lastUsedInBuffer = ProgCommand.FindLastUsedInBuffer(ProgCommand.DeviceBuffers.ProgramMemory, ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue, length - 1);
        int num6 = (lastUsedInBuffer + 1) / num5;
        if ((lastUsedInBuffer + 1) % num5 > 0)
          ++num6;
        int num7 = num6 * num5;
        int num8;
        if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > (uint) ushort.MaxValue)
        {
          float num9 = 1.23f;
          if (ProgCommand.FamilyIsdsPIC30())
            num9 = 1.26f;
          num8 = (int) ((double) num7 * (double) num9);
        }
        else
        {
          float num9 = 1.22f;
          if (ProgCommand.FamilyIsPIC18J())
            num9 = 1.17f;
          num8 = (int) ((double) num7 * (double) num9);
        }
        int num10 = num8 * num1;
        int num11 = 131072;
        if ((int) this.ptgMemory > 0)
          num11 = 262144;
        if (num10 > num11)
        {
          if ((int) this.ptgMemory > 0)
          {
            int num9 = (int) MessageBox.Show("Función Inválida (Futura)", "N O  I M P L E M E N T A D A");
            return;
          }
          else
          {
            int num9 = (int) MessageBox.Show("Función Inválida (Futura)", "N O  I M P L E M E N T A D A");
            return;
          }
        }
      }
      if (this.VppFirstToolStripMenuItem.Checked && this.VppFirstToolStripMenuItem.Enabled && ((double) (float) this.numUpDnVDD.Value < (double) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddErase && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseScript == 0))
      {
        int num12 = (int) MessageBox.Show("Función Inválida (Futura)", "N O  I M P L E M E N T A D A");
      }
      else
      {
        this.timerButton.Enabled = false;
        DialogPK2Go dialogPk2Go = new DialogPK2Go();
        dialogPk2Go.VDDVolts = (float) this.numUpDnVDD.Value;
        dialogPk2Go.dataSource = !this.multiWindow ? this.displayDataSource.Text : this.shortenHex(this.displayDataSource.Text);
        if (this.enableCodeProtectToolStripMenuItem.Checked || this.enableDataProtectStripMenuItem.Checked)
        {
          if (this.enableDataProtectStripMenuItem.Checked)
            dialogPk2Go.dataProtect = true;
          if (this.enableCodeProtectToolStripMenuItem.Checked)
            dialogPk2Go.codeProtect = true;
        }
        dialogPk2Go.writeProgMem = this.checkBoxProgMemEnabled.Checked;
        dialogPk2Go.writeEEPROM = this.checkBoxEEMem.Checked;
        if (this.verifyOnWriteToolStripMenuItem.Checked)
          dialogPk2Go.verifyDevice = true;
        if (this.VppFirstToolStripMenuItem.Enabled && this.VppFirstToolStripMenuItem.Checked)
          dialogPk2Go.vppFirst = true;
        if (this.fastProgrammingToolStripMenuItem.Enabled && !this.fastProgrammingToolStripMenuItem.Checked)
          dialogPk2Go.fastProgramming = false;
        dialogPk2Go.icspSpeedSlow = this.slowSpeedICSP;
        if (this.MCLRtoolStripMenuItem.Enabled && this.MCLRtoolStripMenuItem.Checked)
          dialogPk2Go.holdMCLR = true;
        dialogPk2Go.SetPTGMemory(this.ptgMemory);
        dialogPk2Go.PICkit2WriteGo = new DelegateWrite(this.ExtCallWrite);
        dialogPk2Go.OpenProgToGoGuide = new DelegateOpenProgToGoGuide(this.OpenProgToGoUserGuide);
        int num1 = (int) dialogPk2Go.ShowDialog();
        if (!FormProgUSB.selfPoweredTarget)
          ProgCommand.ForcePICkitPowered();
        else
          ProgCommand.ForcePICkitPowered();
        if (!this.writeOnPICkitButtonToolStripMenuItem.Checked)
          return;
        this.buttonLast = true;
        this.timerButton.Enabled = true;
      }
    }

    private void toolStripMenuItemManualSelect_Click(object sender, EventArgs e)
    {
      this.ManualAutoSelectToggle(true);
    }

    private void ManualAutoSelectToggle(bool updateGUI_OK)
    {
      if (this.toolStripMenuItemManualSelect.Checked)
      {
        for (int index = 0; index < ProgCommand.DevFile.Families.Length; ++index)
          ProgCommand.DevFile.Families[index].PartDetect = false;
      }
      else
      {
        for (int index = 0; index < ProgCommand.DevFile.Families.Length; ++index)
        {
          if (ProgCommand.DevFile.Families[index].DeviceIDMask > 0U)
            ProgCommand.DevFile.Families[index].PartDetect = true;
        }
      }
      this.FamilySelectLogic(ProgCommand.GetActiveFamily(), updateGUI_OK);
    }

    private void toolStripMenuItemProgToGo_Click(object sender, EventArgs e)
    {
      this.OpenProgToGoUserGuide();
    }

    public void OpenProgToGoUserGuide()
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\chufis.mpg");
      }
      catch
      {
        int num = (int) MessageBox.Show("No se pudo Abrir el Archivo!");
      }
    }

    private void toolStripMenuItemLogicTool_Click(object sender, EventArgs e)
    {
      this.timerButton.Enabled = false;
      this.MCLRtoolStripMenuItem.Checked = false;
      this.checkBoxMCLR.Checked = false;
      this.logicWindow.SetVddBox(this.numUpDnVDD.Enabled, this.chkBoxVddOn.Checked);
      if (this.multiWindow)
      {
        this.programMemMultiWin.Hide();
        this.eepromDataMultiWin.Hide();
      }
      this.Hide();
      int num = (int) this.logicWindow.ShowDialog();
      ((Control) this).Show();
      if (this.multiWindow)
      {
        if (this.multiWinPMemOpen)
          ((Control) this.programMemMultiWin).Show();
        if (this.multiWinEEMemOpen && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
          ((Control) this.eepromDataMultiWin).Show();
        this.Focus();
      }
      if (!this.writeOnPICkitButtonToolStripMenuItem.Checked)
        return;
      this.buttonLast = true;
      this.timerButton.Enabled = true;
    }

    private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      if (e.ClickedItem.Text == "Todo Selecionado")
      {
        if (this.dataGridProgramMemory.ContainsFocus)
        {
          this.dataGridProgramMemory.SelectAll();
        }
        else
        {
          if (!this.dataGridViewEEPROM.ContainsFocus)
            return;
          this.dataGridViewEEPROM.SelectAll();
        }
      }
      else
      {
        if (!(e.ClickedItem.Text == "Copiar"))
          return;
        if (this.dataGridProgramMemory.ContainsFocus)
        {
          Clipboard.SetDataObject((object) this.dataGridProgramMemory.GetClipboardContent());
        }
        else
        {
          if (!this.dataGridViewEEPROM.ContainsFocus)
            return;
          Clipboard.SetDataObject((object) this.dataGridViewEEPROM.GetClipboardContent());
        }
      }
    }

    private void dataGridProgramMemory_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.dataGridProgramMemory.Focus();
    }

    private void dataGridViewEEPROM_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.dataGridViewEEPROM.Focus();
    }

    private void toolStripMenuItemLogicToolUG_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\Archvio_3.pdf");
      }
      catch
      {
        int num = (int) MessageBox.Show("No se pudo Abrir el Archivo!");
      }
    }

    private void calAutoRegenerateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.setOSCCALToolStripMenuItem.Enabled || MessageBox.Show("La calibración OSCCAL Borrará\nToda la Memoria Flash!!\n\n        ¿Deseas Continuar?", "CALIBRACION OSCCAL", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        return;
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue == 4095)
      {
        short num1 = (short) 0;
        float num2 = 0.0f;
        this.verifyOSCCALValue = false;
        for (int index1 = 0; index1 < 5; ++index1)
        {
          float num3 = (float) ((1.0 - 400.0 / (double) num2) / 0.00570000009611249 + 0.5);
          num1 += (short) num3;
          if ((int) num1 < -64 || (int) num1 > 63)
          {
            this.conditionalVDDOff();
            this.eraseDeviceAll(false, new uint[0]);
            this.verifyOSCCALValue = true;
            this.updateGUI(true);
            int num4 = (int) MessageBox.Show("Error en OSCCAL!\n\nImposible calibrar.", "CALIBRACION OSCCAL");
            return;
          }
          else
          {
            ProgCommand.ResetBuffers();
            ProgCommand.DeviceBuffers.ProgramMemory[0] = Constants.BASELINE_CAL[0] | (uint) ((int) num1 << 1 & (int) byte.MaxValue);
            ProgCommand.DeviceBuffers.ConfigWords[0] = (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[6];
            for (int index2 = 1; index2 < Constants.BASELINE_CAL.Length; ++index2)
              ProgCommand.DeviceBuffers.ProgramMemory[index2] = Constants.BASELINE_CAL[index2];
            if (!this.deviceWrite())
            {
              ProgCommand.ResetBuffers();
              this.verifyOSCCALValue = true;
              this.updateGUI(true);
              int num4 = (int) MessageBox.Show("Error en OSCCAL!\n\nImposible calibrar.", "CALIBRACION OSCCAL");
              return;
            }
            else
            {
              ProgCommand.VddOn();
              for (int index2 = 0; index2 < 3; ++index2)
              {
                num2 = ProgCommand.MeasurePGDPulse();
                if ((double) num2 >= 695.0 || (double) num2 <= 10.0)
                {
                  if (index2 == 2)
                  {
                    this.conditionalVDDOff();
                    this.eraseDeviceAll(false, new uint[0]);
                    this.verifyOSCCALValue = true;
                    int num4 = (int) MessageBox.Show("Error en OSCCAL!\n\nImposible calibrar.", "CALIBRACION OSCCAL");
                    this.updateGUI(true);
                    return;
                  }
                }
                else
                  break;
              }
              this.conditionalVDDOff();
              float num5 = 404f;
              if (index1 == 4)
                num5 = 406f;
              float num6 = 396f;
              if (index1 == 4)
                num5 = 394f;
              if ((double) num2 > (double) num6 && (double) num2 < (double) num5)
              {
                ProgCommand.DeviceBuffers.OSCCAL = ProgCommand.DeviceBuffers.ProgramMemory[0];
                this.eraseDeviceAll(true, new uint[0]);
                this.verifyOSCCALValue = true;
                int num4 = (int) MessageBox.Show("Calibración OSCCAL Correcta!\n\nValor OSSCAL escrito en memoria.", "CALIBRACION OSCCAL");
                this.updateGUI(true);
                return;
              }
            }
          }
        }
      }
      else
      {
        short num1 = (short) 32;
        float num2 = 0.0f;
        this.verifyOSCCALValue = false;
        for (int index1 = 0; index1 < 5; ++index1)
        {
          float num3 = (float) ((1.0 - 400.0 / (double) num2) / 0.00700000021606684 + 0.5);
          num1 += (short) num3;
          if ((int) num1 < 0 || (int) num1 > 63)
          {
            this.conditionalVDDOff();
            this.eraseDeviceAll(false, new uint[0]);
            this.verifyOSCCALValue = true;
            this.updateGUI(true);
            int num4 = (int) MessageBox.Show("Valor OSCCAL fuera de rango!\n\nImposible calibrar.", "CALIBRACION OSCCAL");
            return;
          }
          else
          {
            ProgCommand.ResetBuffers();
            ProgCommand.DeviceBuffers.ProgramMemory[0] = Constants.MR16F676FAM_CAL[0] | (uint) ((int) num1 << 2 & (int) byte.MaxValue);
            ProgCommand.DeviceBuffers.ConfigWords[0] = (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[6];
            for (int index2 = 1; index2 < Constants.MR16F676FAM_CAL.Length; ++index2)
              ProgCommand.DeviceBuffers.ProgramMemory[index2] = Constants.MR16F676FAM_CAL[index2];
            if (!this.deviceWrite())
            {
              ProgCommand.ResetBuffers();
              this.verifyOSCCALValue = true;
              this.updateGUI(true);
              int num4 = (int) MessageBox.Show("Error en OSCCAL!\n\nImposible calibrar.", "CALIBRACION OSCCAL");
              return;
            }
            else
            {
              ProgCommand.VddOn();
              for (int index2 = 0; index2 < 3; ++index2)
              {
                num2 = ProgCommand.MeasurePGDPulse();
                if ((double) num2 >= 695.0 || (double) num2 <= 10.0)
                {
                  if (index2 == 2)
                  {
                    this.conditionalVDDOff();
                    this.eraseDeviceAll(false, new uint[0]);
                    this.verifyOSCCALValue = true;
                    int num4 = (int) MessageBox.Show("Error en OSCCAL!\n\nImposible calibrar.", "CALIBRACION OSCCAL");
                    this.updateGUI(true);
                    return;
                  }
                }
                else
                  break;
              }
              this.conditionalVDDOff();
              float num5 = 404f;
              if (index1 == 4)
                num5 = 406f;
              float num6 = 396f;
              if (index1 == 4)
                num5 = 394f;
              if ((double) num2 > (double) num6 && (double) num2 < (double) num5)
              {
                ProgCommand.DeviceBuffers.OSCCAL = (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[7] | ProgCommand.DeviceBuffers.ProgramMemory[0] & (uint) byte.MaxValue;
                this.eraseDeviceAll(true, new uint[0]);
                this.verifyOSCCALValue = true;
                int num4 = (int) MessageBox.Show("Calibración OSCCAL Correcta!\n\nValor OSSCAL escrito en memoria.", "CALIBRACION OSCCAL");
                this.updateGUI(true);
                return;
              }
            }
          }
        }
      }
      this.eraseDeviceAll(false, new uint[0]);
      this.verifyOSCCALValue = true;
      this.updateGUI(true);
      int num = (int) MessageBox.Show("Error en OSCCAL!\n\nImposible calibrar.", "CALIBRACION OSCCAL");
    }

    private void timerInitalUpdate_Tick(object sender, EventArgs e)
    {
      this.timerInitalUpdate.Enabled = false;
      this.toolStripMenuItemShowProgramMemory.Checked = this.saveMultWinPMemOpen;
      this.multiWinPMemOpen = this.saveMultWinPMemOpen;
      if (this.multiWinPMemOpen)
        ((Control) this.programMemMultiWin).Show();
      this.toolStripMenuItemShowEEPROMData.Checked = this.saveMultiWinEEMemOpen;
      this.multiWinEEMemOpen = this.saveMultiWinEEMemOpen;
      if (this.multiWinEEMemOpen && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
        ((Control) this.eepromDataMultiWin).Show();
      this.Focus();
    }

    private void mainWindowAlwaysInFrontToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.mainWindowAlwaysInFrontToolStripMenuItem.Checked)
      {
        this.mainWinOwnsMem = true;
        this.AddOwnedForm((Form) this.programMemMultiWin);
        this.AddOwnedForm((Form) this.eepromDataMultiWin);
      }
      else
      {
        this.mainWinOwnsMem = false;
        this.RemoveOwnedForm((Form) this.programMemMultiWin);
        this.RemoveOwnedForm((Form) this.eepromDataMultiWin);
      }
    }

    private void ver_manual(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\Manual de Uso.pdf");
      }
      catch
      {
        int num = (int) MessageBox.Show("No se pudo Abrir el Archivo!");
      }
    }

    private void ajustar_config(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\Ajustar_Config_Bits.pdf");
      }
      catch
      {
        int num = (int) MessageBox.Show("No se pudo Abrir el Archivo!");
      }
    }

    private void practica_1(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\Practicas\\Archivo_1.pdf");
      }
      catch
      {
        int num = (int) MessageBox.Show("No se pudo Abrir el Archivo!");
      }
    }

    private void practica_2(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\Practicas\\Archivo_2.pdf");
      }
      catch
      {
        int num = (int) MessageBox.Show("No se pudo Abrir el Archivo!", "¡ ¡ E R R O R ! !");
      }
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox1_Click_1(object sender, EventArgs e)
    {
    }

    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void statusGroupBox_Enter(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void labelCodeProtect_Click(object sender, EventArgs e)
    {
    }

    private void displayDevice_Click(object sender, EventArgs e)
    {
    }

    private void dataGridProgramMemory_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void toolStripMenuItemClearBuffersErase_Click(object sender, EventArgs e)
    {
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void comboBoxEE_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void checkBoxAutoImportWrite_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void tabPage10_Click(object sender, EventArgs e)
    {
    }

    private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
    {
    }

    private void labelDevice_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox14_Click(object sender, EventArgs e)
    {
    }

    private void button3_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox14_Click_1(object sender, EventArgs e)
    {
    }

    private void pictureBox10_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormProgUSB));
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.importFileToolStripMenuItem = new ToolStripMenuItem();
      this.exportFileToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem1 = new ToolStripSeparator();
      this.hex1ToolStripMenuItem = new ToolStripMenuItem();
      this.hex2ToolStripMenuItem = new ToolStripMenuItem();
      this.hex3ToolStripMenuItem = new ToolStripMenuItem();
      this.hex4ToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem5 = new ToolStripSeparator();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.programmerToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem4 = new ToolStripSeparator();
      this.MCLRtoolStripMenuItem = new ToolStripMenuItem();
      this.writeOnPICkitButtonToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem8 = new ToolStripSeparator();
      this.toolStripMenuItemManualSelect = new ToolStripMenuItem();
      this.pICkit2GoToolStripMenuItem = new ToolStripMenuItem();
      this.deviceToolStripMenuItem = new ToolStripMenuItem();
      this.toolsToolStripMenuItem = new ToolStripMenuItem();
      this.fastProgrammingToolStripMenuItem = new ToolStripMenuItem();
      this.targetPowerToolStripMenuItem = new ToolStripMenuItem();
      this.autoDetectToolStripMenuItem = new ToolStripMenuItem();
      this.forcePICkit2ToolStripMenuItem = new ToolStripMenuItem();
      this.forceTargetToolStripMenuItem = new ToolStripMenuItem();
      this.calibrateToolStripMenuItem = new ToolStripMenuItem();
      this.VppFirstToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.UARTtoolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItemLogicTool = new ToolStripMenuItem();
      this.toolStripMenuItem6 = new ToolStripSeparator();
      this.toolStripMenuItemClearBuffersErase = new ToolStripMenuItem();
      this.checkCommunicationToolStripMenuItem = new ToolStripMenuItem();
      this.troubleshhotToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItemTestMemory = new ToolStripMenuItem();
      this.toolStripMenuItem2 = new ToolStripSeparator();
      this.downloadPICkit2FirmwareToolStripMenuItem = new ToolStripMenuItem();
      this.helpToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItemProgToGo = new ToolStripMenuItem();
      this.uG44pinToolStripMenuItem = new ToolStripMenuItem();
      this.lpcUsersGuideToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem3 = new ToolStripSeparator();
      this.practicasToolStripMenuItem = new ToolStripMenuItem();
      this.basicasToolStripMenuItem = new ToolStripMenuItem();
      this.prenderUnLEDToolStripMenuItem = new ToolStripMenuItem();
      this.funcionesLogicasToolStripMenuItem = new ToolStripMenuItem();
      this.autoIncreibleToolStripMenuItem = new ToolStripMenuItem();
      this.contadorBinarioToolStripMenuItem = new ToolStripMenuItem();
      this.display7SegmentosToolStripMenuItem = new ToolStripMenuItem();
      this.intermediasToolStripMenuItem = new ToolStripMenuItem();
      this.contadorDeTurnosToolStripMenuItem = new ToolStripMenuItem();
      this.tacometroDigtalToolStripMenuItem = new ToolStripMenuItem();
      this.robotSeguidorDeLineaToolStripMenuItem = new ToolStripMenuItem();
      this.relojConDisplayDe7segToolStripMenuItem = new ToolStripMenuItem();
      this.controlDeUnDisplayLCDToolStripMenuItem = new ToolStripMenuItem();
      this.avanzadasToolStripMenuItem = new ToolStripMenuItem();
      this.termometroConLCDToolStripMenuItem = new ToolStripMenuItem();
      this.comunicacionSerialToolStripMenuItem = new ToolStripMenuItem();
      this.trnasmisonRFToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItemView = new ToolStripMenuItem();
      this.toolStripMenuItemSingleWindow = new ToolStripMenuItem();
      this.toolStripMenuItemMultiWindow = new ToolStripMenuItem();
      this.toolStripMenuItem7 = new ToolStripSeparator();
      this.toolStripMenuItemShowProgramMemory = new ToolStripMenuItem();
      this.toolStripMenuItemShowEEPROMData = new ToolStripMenuItem();
      this.toolStripMenuItem9 = new ToolStripSeparator();
      this.mainWindowAlwaysInFrontToolStripMenuItem = new ToolStripMenuItem();
      this.testToolStripMenuItem = new ToolStripMenuItem();
      this.statusGroupBox = new GroupBox();
      this.dataGridConfigWords = new DataGridView();
      this.comboBoxSelectPart = new ComboBox();
      this.buttonShowIDMem = new Button();
      this.labelCodeProtect = new Label();
      this.label1 = new Label();
      this.labelOSSCALInvalid = new Label();
      this.checkBoxA2CS = new CheckBox();
      this.checkBoxA1CS = new CheckBox();
      this.checkBoxA0CS = new CheckBox();
      this.displayBandGap = new Label();
      this.labelBandGap = new Label();
      this.displayOSCCAL = new Label();
      this.labelOSCCAL = new Label();
      this.displayChecksum = new Label();
      this.displayUserIDs = new Label();
      this.displayDevice = new Label();
      this.labelConfig = new Label();
      this.labelChecksum = new Label();
      this.labelUserIDs = new Label();
      this.labelDevice = new Label();
      this.displayRev = new Label();
      this.displayStatusWindow = new Label();
      this.progressBar1 = new ProgressBar();
      this.chkBoxVddOn = new CheckBox();
      this.numUpDnVDD = new NumericUpDown();
      this.groupBoxVDD = new GroupBox();
      this.checkBoxMCLR = new CheckBox();
      this.groupBoxProgMem = new GroupBox();
      this.dataGridProgramMemory = new DataGridView();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.toolStripMenuItemContextSelectAll = new ToolStripMenuItem();
      this.toolStripMenuItemContextCopy = new ToolStripMenuItem();
      this.label3 = new Label();
      this.comboBoxProgMemView = new ComboBox();
      this.checkBoxProgMemEnabled = new CheckBox();
      this.displayDataSource = new Label();
      this.openHexFileDialog = new OpenFileDialog();
      this.saveHexFileDialog = new SaveFileDialog();
      this.openFWFile = new OpenFileDialog();
      this.timerButton = new System.Windows.Forms.Timer(this.components);
      this.groupBoxEEMem = new GroupBox();
      this.dataGridViewEEPROM = new DataGridView();
      this.label2 = new Label();
      this.comboBoxEE = new ComboBox();
      this.checkBoxEEMem = new CheckBox();
      this.displayEEProgInfo = new Label();
      this.timerDLFW = new System.Windows.Forms.Timer(this.components);
      this.timerAutoImportWrite = new System.Windows.Forms.Timer(this.components);
      this.checkBoxProgMemEnabledAlt = new CheckBox();
      this.checkBoxEEDATAMemoryEnabledAlt = new CheckBox();
      this.timerInitalUpdate = new System.Windows.Forms.Timer(this.components);
      this.tabControl1 = new TabControl();
      this.tabPage3 = new TabPage();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.tabPage1 = new TabPage();
      this.tabPage2 = new TabPage();
      this.tabPage4 = new TabPage();
      this.tabControl2 = new TabControl();
      this.tabPage5 = new TabPage();
      this.tabPage6 = new TabPage();
      this.tabPage7 = new TabPage();
      this.tabPage8 = new TabPage();
      this.tabPage9 = new TabPage();
      this.tabPage10 = new TabPage();
      this.tabPage11 = new TabPage();
      this.pictureBox1 = new PictureBox();
      this.readDeviceToolStripMenuItem = new ToolStripMenuItem();
      this.writeDeviceToolStripMenuItem = new ToolStripMenuItem();
      this.eraseToolStripMenuItem = new ToolStripMenuItem();
      this.blankCheckToolStripMenuItem = new ToolStripMenuItem();
      this.verifyToolStripMenuItem = new ToolStripMenuItem();
      this.verifyOnWriteToolStripMenuItem = new ToolStripMenuItem();
      this.enableCodeProtectToolStripMenuItem = new ToolStripMenuItem();
      this.enableDataProtectStripMenuItem = new ToolStripMenuItem();
      this.setOSCCALToolStripMenuItem = new ToolStripMenuItem();
      this.calSetManuallyToolStripMenuItem = new ToolStripMenuItem();
      this.calAutoRegenerateToolStripMenuItem = new ToolStripMenuItem();
      this.usersGuideToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItemLogicToolUG = new ToolStripMenuItem();
      this.webPUSBToolStripMenuItem = new ToolStripMenuItem();
      this.readMeToolStripMenuItem = new ToolStripMenuItem();
      this.aboutToolStripMenuItem = new ToolStripMenuItem();
      this.buttonWrite = new Button();
      this.button1 = new Button();
      this.buttonExportHex = new Button();
      this.buttonErase = new Button();
      this.pictureBox14 = new PictureBox();
      this.pictureBox13 = new PictureBox();
      this.pictureBox12 = new PictureBox();
      this.pictureBox10 = new PictureBox();
      this.pictureBox4 = new PictureBox();
      this.pictureBox3 = new PictureBox();
      this.button2 = new Button();
      this.buttonRead = new Button();
      this.buttonVerify = new Button();
      this.checkBoxAutoImportWrite = new CheckBox();
      this.buttonBlankCheck = new Button();
      this.pictureBox2 = new PictureBox();
      this.pictureBox5 = new PictureBox();
      this.pictureBox6 = new PictureBox();
      this.pictureBox7 = new PictureBox();
      this.pictureBox8 = new PictureBox();
      this.pictureBox9 = new PictureBox();
      this.pictureBox11 = new PictureBox();
      this.menuStrip1.SuspendLayout();
      this.statusGroupBox.SuspendLayout();
      this.dataGridConfigWords.BeginInit();
      this.numUpDnVDD.BeginInit();
      this.groupBoxVDD.SuspendLayout();
      this.groupBoxProgMem.SuspendLayout();
      this.dataGridProgramMemory.BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.groupBoxEEMem.SuspendLayout();
      this.dataGridViewEEPROM.BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage4.SuspendLayout();
      this.tabControl2.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.tabPage6.SuspendLayout();
      this.tabPage7.SuspendLayout();
      this.tabPage8.SuspendLayout();
      this.tabPage9.SuspendLayout();
      this.tabPage10.SuspendLayout();
      this.tabPage11.SuspendLayout();
      this.pictureBox1.BeginInit();
      this.pictureBox14.BeginInit();
      this.pictureBox13.BeginInit();
      this.pictureBox12.BeginInit();
      this.pictureBox10.BeginInit();
      this.pictureBox4.BeginInit();
      this.pictureBox3.BeginInit();
      this.pictureBox2.BeginInit();
      this.pictureBox5.BeginInit();
      this.pictureBox6.BeginInit();
      this.pictureBox7.BeginInit();
      this.pictureBox8.BeginInit();
      this.pictureBox9.BeginInit();
      this.pictureBox11.BeginInit();
      this.SuspendLayout();
      this.menuStrip1.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.programmerToolStripMenuItem,
        (ToolStripItem) this.deviceToolStripMenuItem,
        (ToolStripItem) this.toolsToolStripMenuItem,
        (ToolStripItem) this.helpToolStripMenuItem,
        (ToolStripItem) this.practicasToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItemView,
        (ToolStripItem) this.testToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new Padding(7, 2, 0, 2);
      this.menuStrip1.Size = new Size(534, 25);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.importFileToolStripMenuItem,
        (ToolStripItem) this.exportFileToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.hex1ToolStripMenuItem,
        (ToolStripItem) this.hex2ToolStripMenuItem,
        (ToolStripItem) this.hex3ToolStripMenuItem,
        (ToolStripItem) this.hex4ToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem5,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.fileToolStripMenuItem.Font = new Font("Comic Sans MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(62, 21);
      this.fileToolStripMenuItem.Text = "Archivo";
      this.importFileToolStripMenuItem.Enabled = false;
      this.importFileToolStripMenuItem.Name = "importFileToolStripMenuItem";
      this.importFileToolStripMenuItem.Size = new Size(156, 22);
      this.importFileToolStripMenuItem.Text = "Abrir HEX";
      this.importFileToolStripMenuItem.Click += new EventHandler(this.menuFileImportHex);
      this.exportFileToolStripMenuItem.Enabled = false;
      this.exportFileToolStripMenuItem.Name = "exportFileToolStripMenuItem";
      this.exportFileToolStripMenuItem.Size = new Size(156, 22);
      this.exportFileToolStripMenuItem.Text = "Guardar HEX";
      this.exportFileToolStripMenuItem.Click += new EventHandler(this.menuFileExportHex);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(153, 6);
      this.toolStripMenuItem1.Visible = false;
      this.hex1ToolStripMenuItem.Name = "hex1ToolStripMenuItem";
      this.hex1ToolStripMenuItem.Size = new Size(156, 22);
      this.hex1ToolStripMenuItem.Text = "&1 ";
      this.hex1ToolStripMenuItem.Visible = false;
      this.hex1ToolStripMenuItem.Click += new EventHandler(this.hex1Click);
      this.hex2ToolStripMenuItem.Name = "hex2ToolStripMenuItem";
      this.hex2ToolStripMenuItem.Size = new Size(156, 22);
      this.hex2ToolStripMenuItem.Text = "&2 ";
      this.hex2ToolStripMenuItem.Visible = false;
      this.hex2ToolStripMenuItem.Click += new EventHandler(this.hex2Click);
      this.hex3ToolStripMenuItem.Name = "hex3ToolStripMenuItem";
      this.hex3ToolStripMenuItem.Size = new Size(156, 22);
      this.hex3ToolStripMenuItem.Text = "&3";
      this.hex3ToolStripMenuItem.Visible = false;
      this.hex3ToolStripMenuItem.Click += new EventHandler(this.hex3Click);
      this.hex4ToolStripMenuItem.Name = "hex4ToolStripMenuItem";
      this.hex4ToolStripMenuItem.Size = new Size(156, 22);
      this.hex4ToolStripMenuItem.Text = "&4";
      this.hex4ToolStripMenuItem.Visible = false;
      this.hex4ToolStripMenuItem.Click += new EventHandler(this.hex4Click);
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new Size(153, 6);
      this.toolStripMenuItem5.Visible = false;
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(156, 22);
      this.exitToolStripMenuItem.Text = "Salir";
      this.exitToolStripMenuItem.Click += new EventHandler(this.fileMenuExit);
      this.programmerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[11]
      {
        (ToolStripItem) this.toolStripMenuItem4,
        (ToolStripItem) this.readDeviceToolStripMenuItem,
        (ToolStripItem) this.writeDeviceToolStripMenuItem,
        (ToolStripItem) this.eraseToolStripMenuItem,
        (ToolStripItem) this.blankCheckToolStripMenuItem,
        (ToolStripItem) this.verifyToolStripMenuItem,
        (ToolStripItem) this.MCLRtoolStripMenuItem,
        (ToolStripItem) this.writeOnPICkitButtonToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem8,
        (ToolStripItem) this.toolStripMenuItemManualSelect,
        (ToolStripItem) this.pICkit2GoToolStripMenuItem
      });
      this.programmerToolStripMenuItem.Enabled = false;
      this.programmerToolStripMenuItem.Font = new Font("Comic Sans MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.programmerToolStripMenuItem.Name = "programmerToolStripMenuItem";
      this.programmerToolStripMenuItem.Size = new Size(71, 21);
      this.programmerToolStripMenuItem.Text = "Comandos";
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new Size(261, 6);
      this.toolStripMenuItem4.Visible = false;
      this.MCLRtoolStripMenuItem.Name = "MCLRtoolStripMenuItem";
      this.MCLRtoolStripMenuItem.Size = new Size(264, 22);
      this.MCLRtoolStripMenuItem.Text = "Activar Reset (MCLR en el ICSP)";
      this.MCLRtoolStripMenuItem.Visible = false;
      this.writeOnPICkitButtonToolStripMenuItem.CheckOnClick = true;
      this.writeOnPICkitButtonToolStripMenuItem.Name = "writeOnPICkitButtonToolStripMenuItem";
      this.writeOnPICkitButtonToolStripMenuItem.Size = new Size(264, 22);
      this.writeOnPICkitButtonToolStripMenuItem.Text = "Write on PICkit Button";
      this.writeOnPICkitButtonToolStripMenuItem.Visible = false;
      this.writeOnPICkitButtonToolStripMenuItem.Click += new EventHandler(this.writeOnButton);
      this.toolStripMenuItem8.Name = "toolStripMenuItem8";
      this.toolStripMenuItem8.Size = new Size(261, 6);
      this.toolStripMenuItem8.Visible = false;
      this.toolStripMenuItemManualSelect.CheckOnClick = true;
      this.toolStripMenuItemManualSelect.Enabled = false;
      this.toolStripMenuItemManualSelect.Name = "toolStripMenuItemManualSelect";
      this.toolStripMenuItemManualSelect.Size = new Size(264, 22);
      this.toolStripMenuItemManualSelect.Text = "Selección Manual";
      this.toolStripMenuItemManualSelect.Visible = false;
      this.toolStripMenuItemManualSelect.Click += new EventHandler(this.toolStripMenuItemManualSelect_Click);
      this.pICkit2GoToolStripMenuItem.Name = "pICkit2GoToolStripMenuItem";
      this.pICkit2GoToolStripMenuItem.Size = new Size(264, 22);
      this.pICkit2GoToolStripMenuItem.Text = "MASTER-PROG+-To-Go...";
      this.pICkit2GoToolStripMenuItem.Visible = false;
      this.pICkit2GoToolStripMenuItem.Click += new EventHandler(this.pICkit2GoToolStripMenuItem_Click);
      this.deviceToolStripMenuItem.Enabled = false;
      this.deviceToolStripMenuItem.Font = new Font("Comic Sans MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
      this.deviceToolStripMenuItem.Size = new Size(83, 21);
      this.deviceToolStripMenuItem.Text = "Dispositivo";
      this.deviceToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.deviceFamilyClick);
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[18]
      {
        (ToolStripItem) this.verifyOnWriteToolStripMenuItem,
        (ToolStripItem) this.enableCodeProtectToolStripMenuItem,
        (ToolStripItem) this.enableDataProtectStripMenuItem,
        (ToolStripItem) this.fastProgrammingToolStripMenuItem,
        (ToolStripItem) this.setOSCCALToolStripMenuItem,
        (ToolStripItem) this.targetPowerToolStripMenuItem,
        (ToolStripItem) this.calibrateToolStripMenuItem,
        (ToolStripItem) this.VppFirstToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.UARTtoolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItemLogicTool,
        (ToolStripItem) this.toolStripMenuItem6,
        (ToolStripItem) this.toolStripMenuItemClearBuffersErase,
        (ToolStripItem) this.checkCommunicationToolStripMenuItem,
        (ToolStripItem) this.troubleshhotToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItemTestMemory,
        (ToolStripItem) this.toolStripMenuItem2,
        (ToolStripItem) this.downloadPICkit2FirmwareToolStripMenuItem
      });
      this.toolsToolStripMenuItem.Font = new Font("Comic Sans MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new Size(95, 21);
      this.toolsToolStripMenuItem.Text = "Herramientas";
      this.fastProgrammingToolStripMenuItem.Checked = true;
      this.fastProgrammingToolStripMenuItem.CheckOnClick = true;
      this.fastProgrammingToolStripMenuItem.CheckState = CheckState.Checked;
      this.fastProgrammingToolStripMenuItem.Name = "fastProgrammingToolStripMenuItem";
      this.fastProgrammingToolStripMenuItem.Size = new Size(376, 22);
      this.fastProgrammingToolStripMenuItem.Text = "Programación Rápida";
      this.fastProgrammingToolStripMenuItem.Click += new EventHandler(this.programmingSpeed);
      this.targetPowerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.autoDetectToolStripMenuItem,
        (ToolStripItem) this.forcePICkit2ToolStripMenuItem,
        (ToolStripItem) this.forceTargetToolStripMenuItem
      });
      this.targetPowerToolStripMenuItem.Enabled = false;
      this.targetPowerToolStripMenuItem.Name = "targetPowerToolStripMenuItem";
      this.targetPowerToolStripMenuItem.Size = new Size(376, 22);
      this.targetPowerToolStripMenuItem.Text = "Target &VDD Source";
      this.targetPowerToolStripMenuItem.Visible = false;
      this.autoDetectToolStripMenuItem.Checked = true;
      this.autoDetectToolStripMenuItem.CheckOnClick = true;
      this.autoDetectToolStripMenuItem.CheckState = CheckState.Checked;
      this.autoDetectToolStripMenuItem.Name = "autoDetectToolStripMenuItem";
      this.autoDetectToolStripMenuItem.Size = new Size(202, 22);
      this.autoDetectToolStripMenuItem.Text = "&Auto-Detect";
      this.autoDetectToolStripMenuItem.Click += new EventHandler(this.menuVDDAuto);
      this.forcePICkit2ToolStripMenuItem.CheckOnClick = true;
      this.forcePICkit2ToolStripMenuItem.Name = "forcePICkit2ToolStripMenuItem";
      this.forcePICkit2ToolStripMenuItem.Size = new Size(202, 22);
      this.forcePICkit2ToolStripMenuItem.Text = "Force &MASTER-PROG";
      this.forcePICkit2ToolStripMenuItem.Click += new EventHandler(this.menuVDDPUSB);
      this.forceTargetToolStripMenuItem.CheckOnClick = true;
      this.forceTargetToolStripMenuItem.Name = "forceTargetToolStripMenuItem";
      this.forceTargetToolStripMenuItem.Size = new Size(202, 22);
      this.forceTargetToolStripMenuItem.Text = "Force &Target";
      this.forceTargetToolStripMenuItem.Click += new EventHandler(this.menuVDDTarget);
      this.calibrateToolStripMenuItem.Enabled = false;
      this.calibrateToolStripMenuItem.Name = "calibrateToolStripMenuItem";
      this.calibrateToolStripMenuItem.Size = new Size(376, 22);
      this.calibrateToolStripMenuItem.Text = "Calibrate VDD && Set Unit ID...";
      this.calibrateToolStripMenuItem.Visible = false;
      this.calibrateToolStripMenuItem.Click += new EventHandler(this.calibrateToolStripMenuItem_Click);
      this.VppFirstToolStripMenuItem.CheckOnClick = true;
      this.VppFirstToolStripMenuItem.Enabled = false;
      this.VppFirstToolStripMenuItem.Name = "VppFirstToolStripMenuItem";
      this.VppFirstToolStripMenuItem.Size = new Size(376, 22);
      this.VppFirstToolStripMenuItem.Text = "Forzar Programación En Alto Voltaje (Vpp=12V)";
      this.VppFirstToolStripMenuItem.Visible = false;
      this.VppFirstToolStripMenuItem.CheckedChanged += new EventHandler(this.VppFirstToolStripMenuItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(373, 6);
      this.toolStripSeparator1.Visible = false;
      this.UARTtoolStripMenuItem.Enabled = false;
      this.UARTtoolStripMenuItem.Name = "UARTtoolStripMenuItem";
      this.UARTtoolStripMenuItem.Size = new Size(376, 22);
      this.UARTtoolStripMenuItem.Text = "Interfaz Serial (UART)";
      this.UARTtoolStripMenuItem.Visible = false;
      this.UARTtoolStripMenuItem.Click += new EventHandler(this.UARTtoolStripMenuItem_Click);
      this.toolStripMenuItemLogicTool.Enabled = false;
      this.toolStripMenuItemLogicTool.Name = "toolStripMenuItemLogicTool";
      this.toolStripMenuItemLogicTool.Size = new Size(376, 22);
      this.toolStripMenuItemLogicTool.Text = "Interfaz Lógica y Analizador";
      this.toolStripMenuItemLogicTool.Visible = false;
      this.toolStripMenuItemLogicTool.Click += new EventHandler(this.toolStripMenuItemLogicTool_Click);
      this.toolStripMenuItem6.Name = "toolStripMenuItem6";
      this.toolStripMenuItem6.Size = new Size(373, 6);
      this.toolStripMenuItem6.Visible = false;
      this.toolStripMenuItemClearBuffersErase.Checked = true;
      this.toolStripMenuItemClearBuffersErase.CheckOnClick = true;
      this.toolStripMenuItemClearBuffersErase.CheckState = CheckState.Checked;
      this.toolStripMenuItemClearBuffersErase.Name = "toolStripMenuItemClearBuffersErase";
      this.toolStripMenuItemClearBuffersErase.Size = new Size(376, 22);
      this.toolStripMenuItemClearBuffersErase.Text = "Limpiar Buffer Después de Borrar";
      this.toolStripMenuItemClearBuffersErase.Visible = false;
      this.checkCommunicationToolStripMenuItem.Name = "checkCommunicationToolStripMenuItem";
      this.checkCommunicationToolStripMenuItem.Size = new Size(376, 22);
      this.checkCommunicationToolStripMenuItem.Text = "Checar Comunicación USB (Autodetectar Dispositivo)";
      this.checkCommunicationToolStripMenuItem.Visible = false;
      this.troubleshhotToolStripMenuItem.Enabled = false;
      this.troubleshhotToolStripMenuItem.Name = "troubleshhotToolStripMenuItem";
      this.troubleshhotToolStripMenuItem.Size = new Size(376, 22);
      this.troubleshhotToolStripMenuItem.Text = "Troubleshoot...";
      this.troubleshhotToolStripMenuItem.Visible = false;
      this.troubleshhotToolStripMenuItem.Click += new EventHandler(this.troubleshhotToolStripMenuItem_Click);
      this.toolStripMenuItemTestMemory.Enabled = false;
      this.toolStripMenuItemTestMemory.Name = "toolStripMenuItemTestMemory";
      this.toolStripMenuItemTestMemory.ShortcutKeys = Keys.T | Keys.Control;
      this.toolStripMenuItemTestMemory.Size = new Size(376, 22);
      this.toolStripMenuItemTestMemory.Text = "Test Memory";
      this.toolStripMenuItemTestMemory.Visible = false;
      this.toolStripMenuItemTestMemory.Click += new EventHandler(this.toolStripMenuItemTestMemory_Click);
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new Size(373, 6);
      this.toolStripMenuItem2.Visible = false;
      this.downloadPICkit2FirmwareToolStripMenuItem.Enabled = false;
      this.downloadPICkit2FirmwareToolStripMenuItem.Name = "downloadPICkit2FirmwareToolStripMenuItem";
      this.downloadPICkit2FirmwareToolStripMenuItem.Size = new Size(376, 22);
      this.downloadPICkit2FirmwareToolStripMenuItem.Text = "Actualizar ROM";
      this.downloadPICkit2FirmwareToolStripMenuItem.Visible = false;
      this.downloadPICkit2FirmwareToolStripMenuItem.Click += new EventHandler(this.downloadPUSBFirmware);
      this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.usersGuideToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItemProgToGo,
        (ToolStripItem) this.toolStripMenuItemLogicToolUG,
        (ToolStripItem) this.uG44pinToolStripMenuItem,
        (ToolStripItem) this.lpcUsersGuideToolStripMenuItem,
        (ToolStripItem) this.webPUSBToolStripMenuItem,
        (ToolStripItem) this.readMeToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem3,
        (ToolStripItem) this.aboutToolStripMenuItem
      });
      this.helpToolStripMenuItem.Font = new Font("Comic Sans MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new Size(52, 21);
      this.helpToolStripMenuItem.Text = "Ayuda";
      this.toolStripMenuItemProgToGo.Name = "toolStripMenuItemProgToGo";
      this.toolStripMenuItemProgToGo.Size = new Size(319, 22);
      this.toolStripMenuItemProgToGo.Text = "Ver a chufis";
      this.toolStripMenuItemProgToGo.Visible = false;
      this.toolStripMenuItemProgToGo.Click += new EventHandler(this.toolStripMenuItemProgToGo_Click);
      this.uG44pinToolStripMenuItem.Name = "uG44pinToolStripMenuItem";
      this.uG44pinToolStripMenuItem.Size = new Size(319, 22);
      this.uG44pinToolStripMenuItem.Text = "44-Pin Demo Board Guide";
      this.uG44pinToolStripMenuItem.Visible = false;
      this.uG44pinToolStripMenuItem.Click += new EventHandler(this.uG44pinToolStripMenuItem_Click);
      this.lpcUsersGuideToolStripMenuItem.Name = "lpcUsersGuideToolStripMenuItem";
      this.lpcUsersGuideToolStripMenuItem.Size = new Size(319, 22);
      this.lpcUsersGuideToolStripMenuItem.Text = "LPC Demo Board Guide";
      this.lpcUsersGuideToolStripMenuItem.Visible = false;
      this.lpcUsersGuideToolStripMenuItem.Click += new EventHandler(this.launchLPCDemoGuide);
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new Size(316, 6);
      this.toolStripMenuItem3.Visible = false;
      this.practicasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.basicasToolStripMenuItem,
        (ToolStripItem) this.intermediasToolStripMenuItem,
        (ToolStripItem) this.avanzadasToolStripMenuItem
      });
      this.practicasToolStripMenuItem.Font = new Font("Comic Sans MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.practicasToolStripMenuItem.Name = "prácticasToolStripMenuItem";
      this.practicasToolStripMenuItem.Size = new Size(72, 21);
      this.practicasToolStripMenuItem.Text = "Prácticas";
      this.practicasToolStripMenuItem.Visible = false;
      this.basicasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.prenderUnLEDToolStripMenuItem,
        (ToolStripItem) this.funcionesLogicasToolStripMenuItem,
        (ToolStripItem) this.autoIncreibleToolStripMenuItem,
        (ToolStripItem) this.contadorBinarioToolStripMenuItem,
        (ToolStripItem) this.display7SegmentosToolStripMenuItem
      });
      this.basicasToolStripMenuItem.Name = "básicasToolStripMenuItem";
      this.basicasToolStripMenuItem.Size = new Size(149, 22);
      this.basicasToolStripMenuItem.Text = "Básicas";
      this.prenderUnLEDToolStripMenuItem.Name = "prenderUnLEDToolStripMenuItem";
      this.prenderUnLEDToolStripMenuItem.Size = new Size(196, 22);
      this.prenderUnLEDToolStripMenuItem.Text = "Prender un LED";
      this.prenderUnLEDToolStripMenuItem.Click += new EventHandler(this.practica_1);
      this.funcionesLogicasToolStripMenuItem.Name = "funcionesLógicasToolStripMenuItem";
      this.funcionesLogicasToolStripMenuItem.Size = new Size(196, 22);
      this.funcionesLogicasToolStripMenuItem.Text = "Funciones Lógicas";
      this.funcionesLogicasToolStripMenuItem.Click += new EventHandler(this.practica_2);
      this.autoIncreibleToolStripMenuItem.Name = "autoIncreibleToolStripMenuItem";
      this.autoIncreibleToolStripMenuItem.Size = new Size(196, 22);
      this.autoIncreibleToolStripMenuItem.Text = "Auto Increible";
      this.contadorBinarioToolStripMenuItem.Name = "contadorBinarioToolStripMenuItem";
      this.contadorBinarioToolStripMenuItem.Size = new Size(196, 22);
      this.contadorBinarioToolStripMenuItem.Text = "Contador Binario";
      this.display7SegmentosToolStripMenuItem.Name = "display7SegmentosToolStripMenuItem";
      this.display7SegmentosToolStripMenuItem.Size = new Size(196, 22);
      this.display7SegmentosToolStripMenuItem.Text = "Display 7 Segmentos";
      this.intermediasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.contadorDeTurnosToolStripMenuItem,
        (ToolStripItem) this.tacometroDigtalToolStripMenuItem,
        (ToolStripItem) this.robotSeguidorDeLineaToolStripMenuItem,
        (ToolStripItem) this.relojConDisplayDe7segToolStripMenuItem,
        (ToolStripItem) this.controlDeUnDisplayLCDToolStripMenuItem
      });
      this.intermediasToolStripMenuItem.Name = "intermediasToolStripMenuItem";
      this.intermediasToolStripMenuItem.Size = new Size(149, 22);
      this.intermediasToolStripMenuItem.Text = "Intermedias";
      this.contadorDeTurnosToolStripMenuItem.Name = "contadorDeTurnosToolStripMenuItem";
      this.contadorDeTurnosToolStripMenuItem.Size = new Size(227, 22);
      this.contadorDeTurnosToolStripMenuItem.Text = "Contador de Turnos";
      this.tacometroDigtalToolStripMenuItem.Name = "tacómetroDigtalToolStripMenuItem";
      this.tacometroDigtalToolStripMenuItem.Size = new Size(227, 22);
      this.tacometroDigtalToolStripMenuItem.Text = "Tacómetro Digtal";
      this.robotSeguidorDeLineaToolStripMenuItem.Name = "robotSeguidorDeLíneaToolStripMenuItem";
      this.robotSeguidorDeLineaToolStripMenuItem.Size = new Size(227, 22);
      this.robotSeguidorDeLineaToolStripMenuItem.Text = "Robot Seguidor de Línea";
      this.relojConDisplayDe7segToolStripMenuItem.Name = "relojConDisplayDe7segToolStripMenuItem";
      this.relojConDisplayDe7segToolStripMenuItem.Size = new Size(227, 22);
      this.relojConDisplayDe7segToolStripMenuItem.Text = "Reloj con Display de 7seg";
      this.controlDeUnDisplayLCDToolStripMenuItem.Name = "controlDeUnDisplayLCDToolStripMenuItem";
      this.controlDeUnDisplayLCDToolStripMenuItem.Size = new Size(227, 22);
      this.controlDeUnDisplayLCDToolStripMenuItem.Text = "Control de un Display LCD";
      this.avanzadasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.termometroConLCDToolStripMenuItem,
        (ToolStripItem) this.comunicacionSerialToolStripMenuItem,
        (ToolStripItem) this.trnasmisonRFToolStripMenuItem
      });
      this.avanzadasToolStripMenuItem.Name = "avanzadasToolStripMenuItem";
      this.avanzadasToolStripMenuItem.Size = new Size(149, 22);
      this.avanzadasToolStripMenuItem.Text = "Avanzadas";
      this.termometroConLCDToolStripMenuItem.Name = "termómetroConLCDToolStripMenuItem";
      this.termometroConLCDToolStripMenuItem.Size = new Size(197, 22);
      this.termometroConLCDToolStripMenuItem.Text = "Termómetro con LCD";
      this.comunicacionSerialToolStripMenuItem.Name = "comunicaciónSerialToolStripMenuItem";
      this.comunicaconSerialToolStripMenuItem.Size = new Size(197, 22);
      this.comunicacionSerialToolStripMenuItem.Text = "Comunicación Serial";
      this.trnasmisonRFToolStripMenuItem.Name = "trnasmisónRFToolStripMenuItem";
      this.trnasmisonRFToolStripMenuItem.Size = new Size(197, 22);
      this.trnasmisonRFToolStripMenuItem.Text = "Trnasmisón RF";
      this.toolStripMenuItemView.DropDownItems.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.toolStripMenuItemSingleWindow,
        (ToolStripItem) this.toolStripMenuItemMultiWindow,
        (ToolStripItem) this.toolStripMenuItem7,
        (ToolStripItem) this.toolStripMenuItemShowProgramMemory,
        (ToolStripItem) this.toolStripMenuItemShowEEPROMData,
        (ToolStripItem) this.toolStripMenuItem9,
        (ToolStripItem) this.mainWindowAlwaysInFrontToolStripMenuItem
      });
      this.toolStripMenuItemView.Enabled = false;
      this.toolStripMenuItemView.Name = "toolStripMenuItemView";
      this.toolStripMenuItemView.Size = new Size(41, 21);
      this.toolStripMenuItemView.Text = "View";
      this.toolStripMenuItemView.Visible = false;
      this.toolStripMenuItemSingleWindow.Checked = true;
      this.toolStripMenuItemSingleWindow.CheckState = CheckState.Checked;
      this.toolStripMenuItemSingleWindow.Name = "toolStripMenuItemSingleWindow";
      this.toolStripMenuItemSingleWindow.Size = new Size(261, 22);
      this.toolStripMenuItemSingleWindow.Text = "Single Window";
      this.toolStripMenuItemSingleWindow.Visible = false;
      this.toolStripMenuItemSingleWindow.Click += new EventHandler(this.toolStripMenuItemSingleWindow_Click);
      this.toolStripMenuItemMultiWindow.Enabled = false;
      this.toolStripMenuItemMultiWindow.Name = "toolStripMenuItemMultiWindow";
      this.toolStripMenuItemMultiWindow.Size = new Size(261, 22);
      this.toolStripMenuItemMultiWindow.Text = "Multi-Window";
      this.toolStripMenuItemMultiWindow.Visible = false;
      this.toolStripMenuItemMultiWindow.Click += new EventHandler(this.toolStripMenuItemMultiWindow_Click);
      this.toolStripMenuItem7.Name = "toolStripMenuItem7";
      this.toolStripMenuItem7.Size = new Size(258, 6);
      this.toolStripMenuItemShowProgramMemory.Enabled = false;
      this.toolStripMenuItemShowProgramMemory.Name = "toolStripMenuItemShowProgramMemory";
      this.toolStripMenuItemShowProgramMemory.Size = new Size(261, 22);
      this.toolStripMenuItemShowProgramMemory.Text = "Show Program Memory";
      this.toolStripMenuItemShowProgramMemory.Click += new EventHandler(this.toolStripMenuItemShowProgramMemory_Click);
      this.toolStripMenuItemShowEEPROMData.Enabled = false;
      this.toolStripMenuItemShowEEPROMData.Name = "toolStripMenuItemShowEEPROMData";
      this.toolStripMenuItemShowEEPROMData.Size = new Size(261, 22);
      this.toolStripMenuItemShowEEPROMData.Text = "Show EEPROM Data";
      this.toolStripMenuItemShowEEPROMData.Click += new EventHandler(this.toolStripMenuItemShowEEPROMData_Click);
      this.toolStripMenuItem9.Name = "toolStripMenuItem9";
      this.toolStripMenuItem9.Size = new Size(258, 6);
      this.mainWindowAlwaysInFrontToolStripMenuItem.CheckOnClick = true;
      this.mainWindowAlwaysInFrontToolStripMenuItem.Enabled = false;
      this.mainWindowAlwaysInFrontToolStripMenuItem.Name = "mainWindowAlwaysInFrontToolStripMenuItem";
      this.mainWindowAlwaysInFrontToolStripMenuItem.Size = new Size(261, 22);
      this.mainWindowAlwaysInFrontToolStripMenuItem.Text = "Associate / Memory Displays in Front";
      this.mainWindowAlwaysInFrontToolStripMenuItem.Click += new EventHandler(this.mainWindowAlwaysInFrontToolStripMenuItem_Click);
      this.testToolStripMenuItem.Name = "testToolStripMenuItem";
      this.testToolStripMenuItem.Size = new Size(40, 21);
      this.testToolStripMenuItem.Text = "Test";
      this.testToolStripMenuItem.Visible = false;
      this.testToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.testMenuDropDownItemClicked);
      this.testToolStripMenuItem.Click += new EventHandler(this.testToolStripMenuItem_Click);
      this.statusGroupBox.Controls.Add((Control) this.pictureBox14);
      this.statusGroupBox.Controls.Add((Control) this.dataGridConfigWords);
      this.statusGroupBox.Controls.Add((Control) this.pictureBox13);
      this.statusGroupBox.Controls.Add((Control) this.pictureBox12);
      this.statusGroupBox.Controls.Add((Control) this.comboBoxSelectPart);
      this.statusGroupBox.Controls.Add((Control) this.pictureBox10);
      this.statusGroupBox.Controls.Add((Control) this.pictureBox4);
      this.statusGroupBox.Controls.Add((Control) this.pictureBox3);
      this.statusGroupBox.Controls.Add((Control) this.button2);
      this.statusGroupBox.Controls.Add((Control) this.buttonShowIDMem);
      this.statusGroupBox.Controls.Add((Control) this.labelCodeProtect);
      this.statusGroupBox.Controls.Add((Control) this.label1);
      this.statusGroupBox.Controls.Add((Control) this.labelOSSCALInvalid);
      this.statusGroupBox.Controls.Add((Control) this.checkBoxA2CS);
      this.statusGroupBox.Controls.Add((Control) this.checkBoxA1CS);
      this.statusGroupBox.Controls.Add((Control) this.checkBoxA0CS);
      this.statusGroupBox.Controls.Add((Control) this.displayBandGap);
      this.statusGroupBox.Controls.Add((Control) this.labelBandGap);
      this.statusGroupBox.Controls.Add((Control) this.displayOSCCAL);
      this.statusGroupBox.Controls.Add((Control) this.labelOSCCAL);
      this.statusGroupBox.Controls.Add((Control) this.displayChecksum);
      this.statusGroupBox.Controls.Add((Control) this.displayUserIDs);
      this.statusGroupBox.Controls.Add((Control) this.displayDevice);
      this.statusGroupBox.Controls.Add((Control) this.labelConfig);
      this.statusGroupBox.Controls.Add((Control) this.labelChecksum);
      this.statusGroupBox.Controls.Add((Control) this.labelUserIDs);
      this.statusGroupBox.Controls.Add((Control) this.labelDevice);
      this.statusGroupBox.Controls.Add((Control) this.displayRev);
      this.statusGroupBox.Cursor = Cursors.Default;
      this.statusGroupBox.Font = new Font("Comic Sans MS", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.statusGroupBox.ForeColor = Color.Navy;
      this.statusGroupBox.Location = new Point(6, 144);
      this.statusGroupBox.Margin = new Padding(2);
      this.statusGroupBox.Name = "statusGroupBox";
      this.statusGroupBox.Padding = new Padding(2);
      this.statusGroupBox.RightToLeft = RightToLeft.No;
      this.statusGroupBox.Size = new Size(514, 196);
      this.statusGroupBox.TabIndex = 1;
      this.statusGroupBox.TabStop = false;
      this.statusGroupBox.Text = "Familia de Dispositivo";
      this.statusGroupBox.Enter += new EventHandler(this.statusGroupBox_Enter);
      this.dataGridConfigWords.AllowUserToAddRows = false;
      this.dataGridConfigWords.AllowUserToDeleteRows = false;
      this.dataGridConfigWords.AllowUserToResizeColumns = false;
      this.dataGridConfigWords.AllowUserToResizeRows = false;
      this.dataGridConfigWords.BackgroundColor = SystemColors.Control;
      this.dataGridConfigWords.BorderStyle = BorderStyle.Fixed3D;
      this.dataGridConfigWords.CellBorderStyle = DataGridViewCellBorderStyle.None;
      this.dataGridConfigWords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridConfigWords.ColumnHeadersVisible = false;
      this.dataGridConfigWords.Enabled = false;
      this.dataGridConfigWords.GridColor = SystemColors.ControlLight;
      this.dataGridConfigWords.Location = new Point(107, 121);
      this.dataGridConfigWords.Margin = new Padding(2);
      this.dataGridConfigWords.MultiSelect = false;
      this.dataGridConfigWords.Name = "dataGridConfigWords";
      this.dataGridConfigWords.ReadOnly = true;
      this.dataGridConfigWords.RowHeadersVisible = false;
      this.dataGridConfigWords.ScrollBars = ScrollBars.None;
      this.dataGridConfigWords.Size = new Size(172, 49);
      this.dataGridConfigWords.TabIndex = 3;
      this.comboBoxSelectPart.BackColor = Color.Aqua;
      this.comboBoxSelectPart.DropDownHeight = 212;
      this.comboBoxSelectPart.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxSelectPart.FormattingEnabled = true;
      this.comboBoxSelectPart.IntegralHeight = false;
      this.comboBoxSelectPart.Items.AddRange(new object[1]
      {
        (object) "-Seleccionar Aquí-"
      });
      this.comboBoxSelectPart.Location = new Point(79, 27);
      this.comboBoxSelectPart.Margin = new Padding(2);
      this.comboBoxSelectPart.Name = "comboBoxSelectPart";
      this.comboBoxSelectPart.Size = new Size(148, 24);
      this.comboBoxSelectPart.Sorted = true;
      this.comboBoxSelectPart.TabIndex = 12;
      this.comboBoxSelectPart.Visible = false;
      this.comboBoxSelectPart.SelectionChangeCommitted += new EventHandler(this.selectPart);
      this.buttonShowIDMem.Font = new Font("Comic Sans MS", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.buttonShowIDMem.ForeColor = Color.Green;
      this.buttonShowIDMem.Location = new Point(337, 29);
      this.buttonShowIDMem.Margin = new Padding(2);
      this.buttonShowIDMem.Name = "buttonShowIDMem";
      this.buttonShowIDMem.Size = new Size(98, 22);
      this.buttonShowIDMem.TabIndex = 15;
      this.buttonShowIDMem.Text = "VER BITS";
      this.buttonShowIDMem.UseVisualStyleBackColor = true;
      this.buttonShowIDMem.Visible = false;
      this.buttonShowIDMem.Click += new EventHandler(this.buttonShowIDMem_Click);
      this.labelCodeProtect.AutoSize = true;
      this.labelCodeProtect.ForeColor = Color.Red;
      this.labelCodeProtect.Location = new Point(93, 62);
      this.labelCodeProtect.Margin = new Padding(2, 0, 2, 0);
      this.labelCodeProtect.Name = "labelCodeProtect";
      this.labelCodeProtect.Size = new Size(145, 16);
      this.labelCodeProtect.TabIndex = 13;
      this.labelCodeProtect.Text = "PROTECCION CODIGO";
      this.labelCodeProtect.Visible = false;
      this.labelCodeProtect.Click += new EventHandler(this.labelCodeProtect_Click);
      this.label1.AutoSize = true;
      this.label1.ForeColor = Color.Blue;
      this.label1.Location = new Point(43, 62);
      this.label1.Name = "label1";
      this.label1.Size = new Size(54, 16);
      this.label1.TabIndex = 23;
      this.label1.Text = "CP/CPD:";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.labelOSSCALInvalid.AutoSize = true;
      this.labelOSSCALInvalid.ForeColor = Color.Red;
      this.labelOSSCALInvalid.Location = new Point(490, 164);
      this.labelOSSCALInvalid.Margin = new Padding(2, 0, 2, 0);
      this.labelOSSCALInvalid.Name = "labelOSSCALInvalid";
      this.labelOSSCALInvalid.Size = new Size(23, 16);
      this.labelOSSCALInvalid.TabIndex = 22;
      this.labelOSSCALInvalid.Text = "IV";
      this.labelOSSCALInvalid.Visible = false;
      this.checkBoxA2CS.AutoSize = true;
      this.checkBoxA2CS.Enabled = false;
      this.checkBoxA2CS.Location = new Point(290, 145);
      this.checkBoxA2CS.Margin = new Padding(2);
      this.checkBoxA2CS.Name = "checkBoxA2CS";
      this.checkBoxA2CS.RightToLeft = RightToLeft.No;
      this.checkBoxA2CS.Size = new Size(43, 20);
      this.checkBoxA2CS.TabIndex = 21;
      this.checkBoxA2CS.Text = "A2";
      this.checkBoxA2CS.UseVisualStyleBackColor = true;
      this.checkBoxA2CS.Visible = false;
      this.checkBoxA1CS.AutoSize = true;
      this.checkBoxA1CS.Enabled = false;
      this.checkBoxA1CS.Location = new Point(290, 129);
      this.checkBoxA1CS.Margin = new Padding(2);
      this.checkBoxA1CS.Name = "checkBoxA1CS";
      this.checkBoxA1CS.RightToLeft = RightToLeft.No;
      this.checkBoxA1CS.Size = new Size(153, 20);
      this.checkBoxA1CS.TabIndex = 20;
      this.checkBoxA1CS.Text = "A1     DIR. EEPROM";
      this.checkBoxA1CS.UseVisualStyleBackColor = true;
      this.checkBoxA1CS.Visible = false;
      this.checkBoxA0CS.AutoSize = true;
      this.checkBoxA0CS.Enabled = false;
      this.checkBoxA0CS.Location = new Point(290, 113);
      this.checkBoxA0CS.Margin = new Padding(2);
      this.checkBoxA0CS.Name = "checkBoxA0CS";
      this.checkBoxA0CS.RightToLeft = RightToLeft.No;
      this.checkBoxA0CS.Size = new Size(43, 20);
      this.checkBoxA0CS.TabIndex = 19;
      this.checkBoxA0CS.Text = "A0";
      this.checkBoxA0CS.UseVisualStyleBackColor = true;
      this.checkBoxA0CS.Visible = false;
      this.displayBandGap.AutoSize = true;
      this.displayBandGap.ForeColor = Color.Red;
      this.displayBandGap.Location = new Point(101, 172);
      this.displayBandGap.Margin = new Padding(2, 0, 2, 0);
      this.displayBandGap.Name = "displayBandGap";
      this.displayBandGap.Size = new Size(36, 16);
      this.displayBandGap.TabIndex = 11;
      this.displayBandGap.Text = "0000";
      this.displayBandGap.Visible = false;
      this.labelBandGap.AutoSize = true;
      this.labelBandGap.ForeColor = Color.Blue;
      this.labelBandGap.Location = new Point(8, 171);
      this.labelBandGap.Margin = new Padding(2, 0, 2, 0);
      this.labelBandGap.Name = "labelBandGap";
      this.labelBandGap.Size = new Size(97, 16);
      this.labelBandGap.TabIndex = 10;
      this.labelBandGap.Text = "Valor BandGap:";
      this.labelBandGap.Visible = false;
      this.displayOSCCAL.AutoSize = true;
      this.displayOSCCAL.ForeColor = Color.Red;
      this.displayOSCCAL.Location = new Point(129, 99);
      this.displayOSCCAL.Margin = new Padding(2, 0, 2, 0);
      this.displayOSCCAL.Name = "displayOSCCAL";
      this.displayOSCCAL.Size = new Size(36, 16);
      this.displayOSCCAL.TabIndex = 9;
      this.displayOSCCAL.Text = "0000";
      this.labelOSCCAL.AutoSize = true;
      this.labelOSCCAL.ForeColor = Color.Blue;
      this.labelOSCCAL.Location = new Point(43, 98);
      this.labelOSCCAL.Margin = new Padding(2, 0, 2, 0);
      this.labelOSCCAL.Name = "labelOSCCAL";
      this.labelOSCCAL.Size = new Size(91, 16);
      this.labelOSCCAL.TabIndex = 8;
      this.labelOSCCAL.Text = "Reloj Interno:";
      this.displayChecksum.AutoSize = true;
      this.displayChecksum.Location = new Point(76, 61);
      this.displayChecksum.Margin = new Padding(2, 0, 2, 0);
      this.displayChecksum.Name = "displayChecksum";
      this.displayChecksum.Size = new Size(36, 16);
      this.displayChecksum.TabIndex = 7;
      this.displayChecksum.Text = "0000";
      this.displayChecksum.Visible = false;
      this.displayUserIDs.AutoSize = true;
      this.displayUserIDs.ForeColor = Color.Red;
      this.displayUserIDs.Location = new Point(346, 33);
      this.displayUserIDs.Margin = new Padding(2, 0, 2, 0);
      this.displayUserIDs.Name = "displayUserIDs";
      this.displayUserIDs.Size = new Size(79, 16);
      this.displayUserIDs.TabIndex = 6;
      this.displayUserIDs.Text = "00 00 00 00";
      this.displayDevice.AutoSize = true;
      this.displayDevice.ForeColor = Color.DarkOrange;
      this.displayDevice.Location = new Point(79, 31);
      this.displayDevice.Margin = new Padding(2, 0, 2, 0);
      this.displayDevice.Name = "displayDevice";
      this.displayDevice.Size = new Size(91, 16);
      this.displayDevice.TabIndex = 5;
      this.displayDevice.Text = "No detectado!";
      this.displayDevice.Click += new EventHandler(this.displayDevice_Click);
      this.labelConfig.AutoSize = true;
      this.labelConfig.ForeColor = Color.Blue;
      this.labelConfig.Location = new Point(43, 140);
      this.labelConfig.Margin = new Padding(2, 0, 2, 0);
      this.labelConfig.Name = "labelConfig";
      this.labelConfig.Size = new Size(62, 16);
      this.labelConfig.TabIndex = 4;
      this.labelConfig.Text = "CONFIG:";
      this.labelChecksum.AutoSize = true;
      this.labelChecksum.Location = new Point(6, 61);
      this.labelChecksum.Margin = new Padding(2, 0, 2, 0);
      this.labelChecksum.Name = "labelChecksum";
      this.labelChecksum.Size = new Size(67, 16);
      this.labelChecksum.TabIndex = 2;
      this.labelChecksum.Text = "Checksum:";
      this.labelChecksum.Visible = false;
      this.labelUserIDs.AutoSize = true;
      this.labelUserIDs.ForeColor = Color.Blue;
      this.labelUserIDs.Location = new Point(310, 32);
      this.labelUserIDs.Margin = new Padding(2, 0, 2, 0);
      this.labelUserIDs.Name = "labelUserIDs";
      this.labelUserIDs.Size = new Size(29, 16);
      this.labelUserIDs.TabIndex = 1;
      this.labelUserIDs.Text = "ID:";
      this.labelDevice.AutoSize = true;
      this.labelDevice.ForeColor = Color.Blue;
      this.labelDevice.Location = new Point(43, 31);
      this.labelDevice.Margin = new Padding(2, 0, 2, 0);
      this.labelDevice.Name = "labelDevice";
      this.labelDevice.Size = new Size(36, 16);
      this.labelDevice.TabIndex = 0;
      this.labelDevice.Text = "Tipo:";
      this.labelDevice.Click += new EventHandler(this.labelDevice_Click);
      this.displayRev.AutoSize = true;
      this.displayRev.Location = new Point(135, 61);
      this.displayRev.Margin = new Padding(2, 0, 2, 0);
      this.displayRev.Name = "displayRev";
      this.displayRev.Size = new Size(29, 16);
      this.displayRev.TabIndex = 14;
      this.displayRev.Text = "Rev";
      this.displayRev.Visible = false;
      this.displayStatusWindow.BackColor = Color.Aqua;
      this.displayStatusWindow.BorderStyle = BorderStyle.Fixed3D;
      this.displayStatusWindow.Font = new Font("Comic Sans MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.displayStatusWindow.Location = new Point(247, 7);
      this.displayStatusWindow.Margin = new Padding(2, 0, 2, 0);
      this.displayStatusWindow.Name = "displayStatusWindow";
      this.displayStatusWindow.Size = new Size(273, 78);
      this.displayStatusWindow.TabIndex = 4;
      this.displayStatusWindow.Text = "Ventana\r\nEstado\r\n";
      this.progressBar1.BackColor = Color.Aqua;
      this.progressBar1.Location = new Point(38, 344);
      this.progressBar1.Margin = new Padding(2);
      this.progressBar1.MarqueeAnimationSpeed = 50;
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(437, 20);
      this.progressBar1.Style = ProgressBarStyle.Continuous;
      this.progressBar1.TabIndex = 6;
      this.progressBar1.Tag = (object) "";
      this.chkBoxVddOn.AutoSize = true;
      this.chkBoxVddOn.Enabled = false;
      this.chkBoxVddOn.Location = new Point(15, 15);
      this.chkBoxVddOn.Margin = new Padding(2);
      this.chkBoxVddOn.Name = "chkBoxVddOn";
      this.chkBoxVddOn.Size = new Size(42, 20);
      this.chkBoxVddOn.TabIndex = 11;
      this.chkBoxVddOn.Text = "On";
      this.chkBoxVddOn.UseVisualStyleBackColor = true;
      this.chkBoxVddOn.Click += new EventHandler(this.guiVddControl);
      this.numUpDnVDD.DecimalPlaces = 1;
      this.numUpDnVDD.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.numUpDnVDD.Increment = new Decimal(new int[4]
      {
        1,
        0,
        0,
        65536
      });
      this.numUpDnVDD.Location = new Point(97, 15);
      this.numUpDnVDD.Margin = new Padding(2);
      this.numUpDnVDD.Maximum = new Decimal(new int[4]
      {
        50,
        0,
        0,
        65536
      });
      this.numUpDnVDD.Minimum = new Decimal(new int[4]
      {
        25,
        0,
        0,
        65536
      });
      this.numUpDnVDD.Name = "numUpDnVDD";
      this.numUpDnVDD.Size = new Size(53, 26);
      this.numUpDnVDD.TabIndex = 14;
      this.numUpDnVDD.TextAlign = HorizontalAlignment.Center;
      this.numUpDnVDD.Value = new Decimal(new int[4]
      {
        25,
        0,
        0,
        65536
      });
      this.numUpDnVDD.ValueChanged += new EventHandler(this.guiChangeVDD);
      this.groupBoxVDD.Controls.Add((Control) this.checkBoxMCLR);
      this.groupBoxVDD.Controls.Add((Control) this.numUpDnVDD);
      this.groupBoxVDD.Controls.Add((Control) this.chkBoxVddOn);
      this.groupBoxVDD.ForeColor = SystemColors.ControlText;
      this.groupBoxVDD.Location = new Point(408, 10);
      this.groupBoxVDD.Margin = new Padding(2);
      this.groupBoxVDD.Name = "groupBoxVDD";
      this.groupBoxVDD.Padding = new Padding(2);
      this.groupBoxVDD.Size = new Size(24, 14);
      this.groupBoxVDD.TabIndex = 17;
      this.groupBoxVDD.TabStop = false;
      this.groupBoxVDD.Text = "VDD MASTER-PROG";
      this.groupBoxVDD.Visible = false;
      this.checkBoxMCLR.AutoSize = true;
      this.checkBoxMCLR.Enabled = false;
      this.checkBoxMCLR.Location = new Point(15, 32);
      this.checkBoxMCLR.Margin = new Padding(2);
      this.checkBoxMCLR.Name = "checkBoxMCLR";
      this.checkBoxMCLR.Size = new Size(64, 20);
      this.checkBoxMCLR.TabIndex = 15;
      this.checkBoxMCLR.Text = "/MCLR";
      this.checkBoxMCLR.UseVisualStyleBackColor = true;
      this.checkBoxMCLR.Click += new EventHandler(this.MCLRtoolStripMenuItem_Click);
      this.groupBoxProgMem.Controls.Add((Control) this.dataGridProgramMemory);
      this.groupBoxProgMem.Controls.Add((Control) this.label3);
      this.groupBoxProgMem.Controls.Add((Control) this.comboBoxProgMemView);
      this.groupBoxProgMem.Controls.Add((Control) this.checkBoxProgMemEnabled);
      this.groupBoxProgMem.Controls.Add((Control) this.displayDataSource);
      this.groupBoxProgMem.Font = new Font("Comic Sans MS", 8.25f, FontStyle.Bold);
      this.groupBoxProgMem.ForeColor = SystemColors.InfoText;
      this.groupBoxProgMem.Location = new Point(5, 5);
      this.groupBoxProgMem.Margin = new Padding(2);
      this.groupBoxProgMem.Name = "groupBoxProgMem";
      this.groupBoxProgMem.Padding = new Padding(2);
      this.groupBoxProgMem.Size = new Size(514, 378);
      this.groupBoxProgMem.TabIndex = 18;
      this.groupBoxProgMem.TabStop = false;
      this.groupBoxProgMem.Text = "Memoria Flash (Programa)";
      this.dataGridProgramMemory.AllowUserToAddRows = false;
      this.dataGridProgramMemory.AllowUserToDeleteRows = false;
      this.dataGridProgramMemory.AllowUserToResizeColumns = false;
      this.dataGridProgramMemory.AllowUserToResizeRows = false;
      this.dataGridProgramMemory.BackgroundColor = SystemColors.Window;
      this.dataGridProgramMemory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      this.dataGridProgramMemory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGridProgramMemory.ColumnHeadersVisible = false;
      this.dataGridProgramMemory.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridProgramMemory.Enabled = false;
      this.dataGridProgramMemory.Location = new Point(6, 18);
      this.dataGridProgramMemory.Margin = new Padding(2);
      this.dataGridProgramMemory.Name = "dataGridProgramMemory";
      this.dataGridProgramMemory.RowHeadersVisible = false;
      this.dataGridProgramMemory.RowHeadersWidth = 75;
      this.dataGridProgramMemory.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dataGridProgramMemory.RowsDefaultCellStyle = gridViewCellStyle1;
      this.dataGridProgramMemory.RowTemplate.Height = 17;
      this.dataGridProgramMemory.ScrollBars = ScrollBars.Vertical;
      this.dataGridProgramMemory.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dataGridProgramMemory.Size = new Size(502, 326);
      this.dataGridProgramMemory.TabIndex = 4;
      this.dataGridProgramMemory.CellMouseDown += new DataGridViewCellMouseEventHandler(this.dataGridProgramMemory_CellMouseDown);
      this.dataGridProgramMemory.CellEndEdit += new DataGridViewCellEventHandler(this.progMemEdit);
      this.dataGridProgramMemory.CellContentClick += new DataGridViewCellEventHandler(this.dataGridProgramMemory_CellContentClick);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.toolStripMenuItemContextSelectAll,
        (ToolStripItem) this.toolStripMenuItemContextCopy
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(164, 48);
      this.contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
      this.toolStripMenuItemContextSelectAll.Name = "toolStripMenuItemContextSelectAll";
      this.toolStripMenuItemContextSelectAll.ShortcutKeyDisplayString = "Ctrl-A";
      this.toolStripMenuItemContextSelectAll.Size = new Size(163, 22);
      this.toolStripMenuItemContextSelectAll.Text = "Select All";
      this.toolStripMenuItemContextCopy.Name = "toolStripMenuItemContextCopy";
      this.toolStripMenuItemContextCopy.ShortcutKeyDisplayString = "Ctrl-C";
      this.toolStripMenuItemContextCopy.Size = new Size(163, 22);
      this.toolStripMenuItemContextCopy.Text = "Copy";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(341, 355);
      this.label3.Name = "label3";
      this.label3.Size = new Size(72, 16);
      this.label3.TabIndex = 5;
      this.label3.Text = "FORMATO:";
      this.comboBoxProgMemView.BackColor = Color.Aqua;
      this.comboBoxProgMemView.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxProgMemView.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBoxProgMemView.FormattingEnabled = true;
      this.comboBoxProgMemView.Items.AddRange(new object[3]
      {
        (object) "Hexadecimal",
        (object) "ASCII (Word)",
        (object) "ASCII (Byte)"
      });
      this.comboBoxProgMemView.Location = new Point(417, 351);
      this.comboBoxProgMemView.Margin = new Padding(2);
      this.comboBoxProgMemView.Name = "comboBoxProgMemView";
      this.comboBoxProgMemView.Size = new Size(91, 21);
      this.comboBoxProgMemView.TabIndex = 1;
      this.comboBoxProgMemView.SelectionChangeCommitted += new EventHandler(this.progMemViewChanged);
      this.checkBoxProgMemEnabled.AutoSize = true;
      this.checkBoxProgMemEnabled.Checked = true;
      this.checkBoxProgMemEnabled.CheckState = CheckState.Checked;
      this.checkBoxProgMemEnabled.Enabled = false;
      this.checkBoxProgMemEnabled.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkBoxProgMemEnabled.Location = new Point(6, 19);
      this.checkBoxProgMemEnabled.Margin = new Padding(2);
      this.checkBoxProgMemEnabled.Name = "checkBoxProgMemEnabled";
      this.checkBoxProgMemEnabled.Size = new Size(65, 17);
      this.checkBoxProgMemEnabled.TabIndex = 0;
      this.checkBoxProgMemEnabled.Text = "Enabled";
      this.checkBoxProgMemEnabled.UseVisualStyleBackColor = true;
      this.checkBoxProgMemEnabled.Visible = false;
      this.checkBoxProgMemEnabled.Click += new EventHandler(this.memorySelectVerify);
      this.displayDataSource.BorderStyle = BorderStyle.Fixed3D;
      this.displayDataSource.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.displayDataSource.Location = new Point(229, 19);
      this.displayDataSource.Margin = new Padding(2, 0, 2, 0);
      this.displayDataSource.Name = "displayDataSource";
      this.displayDataSource.Size = new Size(279, 16);
      this.displayDataSource.TabIndex = 3;
      this.displayDataSource.Text = "None (Empty/Erased)";
      this.displayDataSource.UseCompatibleTextRendering = true;
      this.displayDataSource.Visible = false;
      this.openHexFileDialog.DefaultExt = "hex";
      this.openHexFileDialog.Filter = "Archivos HEX|*.hex";
      this.openHexFileDialog.Title = "Abrir Archivo HEX";
      this.openHexFileDialog.FileOk += new CancelEventHandler(this.importHexFile);
      this.saveHexFileDialog.DefaultExt = "hex";
      this.saveHexFileDialog.Filter = "Archivos HEX|*.hex";
      this.saveHexFileDialog.Title = "Guardar Archivo HEX";
      this.saveHexFileDialog.FileOk += new CancelEventHandler(this.exportHexFile);
      this.openFWFile.DefaultExt = "hex";
      this.openFWFile.Filter = "Archivo ROM|R*.bin";
      this.openFWFile.InitialDirectory = "c:\\MASTER-PROG";
      this.openFWFile.Title = "Abrir Archivo ROM";
      this.timerButton.Interval = 250;
      this.timerButton.Tick += new EventHandler(this.timerGoesOff);
      this.groupBoxEEMem.Controls.Add((Control) this.dataGridViewEEPROM);
      this.groupBoxEEMem.Controls.Add((Control) this.label2);
      this.groupBoxEEMem.Controls.Add((Control) this.comboBoxEE);
      this.groupBoxEEMem.Controls.Add((Control) this.checkBoxEEMem);
      this.groupBoxEEMem.Controls.Add((Control) this.displayEEProgInfo);
      this.groupBoxEEMem.Font = new Font("Comic Sans MS", 8.25f, FontStyle.Bold);
      this.groupBoxEEMem.ForeColor = SystemColors.InfoText;
      this.groupBoxEEMem.Location = new Point(5, 5);
      this.groupBoxEEMem.Margin = new Padding(2);
      this.groupBoxEEMem.Name = "groupBoxEEMem";
      this.groupBoxEEMem.Padding = new Padding(2);
      this.groupBoxEEMem.Size = new Size(514, 378);
      this.groupBoxEEMem.TabIndex = 19;
      this.groupBoxEEMem.TabStop = false;
      this.groupBoxEEMem.Text = "Memoria EEPROM (Datos)";
      this.dataGridViewEEPROM.AllowUserToAddRows = false;
      this.dataGridViewEEPROM.AllowUserToDeleteRows = false;
      this.dataGridViewEEPROM.AllowUserToResizeColumns = false;
      this.dataGridViewEEPROM.AllowUserToResizeRows = false;
      this.dataGridViewEEPROM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dataGridViewEEPROM.BackgroundColor = SystemColors.Window;
      this.dataGridViewEEPROM.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
      this.dataGridViewEEPROM.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGridViewEEPROM.ColumnHeadersVisible = false;
      this.dataGridViewEEPROM.ContextMenuStrip = this.contextMenuStrip1;
      this.dataGridViewEEPROM.Location = new Point(6, 18);
      this.dataGridViewEEPROM.Margin = new Padding(2);
      this.dataGridViewEEPROM.Name = "dataGridViewEEPROM";
      this.dataGridViewEEPROM.RowHeadersVisible = false;
      this.dataGridViewEEPROM.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewEEPROM.RowsDefaultCellStyle = gridViewCellStyle2;
      this.dataGridViewEEPROM.RowTemplate.Height = 17;
      this.dataGridViewEEPROM.ScrollBars = ScrollBars.Vertical;
      this.dataGridViewEEPROM.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dataGridViewEEPROM.Size = new Size(502, 326);
      this.dataGridViewEEPROM.TabIndex = 6;
      this.dataGridViewEEPROM.CellMouseDown += new DataGridViewCellMouseEventHandler(this.dataGridViewEEPROM_CellMouseDown);
      this.dataGridViewEEPROM.CellEndEdit += new DataGridViewCellEventHandler(this.eEpromEdit);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(341, 355);
      this.label2.Name = "label2";
      this.label2.Size = new Size(72, 16);
      this.label2.TabIndex = 26;
      this.label2.Text = "FORMATO:";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.comboBoxEE.BackColor = Color.Aqua;
      this.comboBoxEE.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxEE.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBoxEE.FormattingEnabled = true;
      this.comboBoxEE.Items.AddRange(new object[3]
      {
        (object) "Hexadecimal",
        (object) "ASCII (Word)",
        (object) "ASCII (Byte)"
      });
      this.comboBoxEE.Location = new Point(417, 351);
      this.comboBoxEE.Margin = new Padding(2);
      this.comboBoxEE.Name = "comboBoxEE";
      this.comboBoxEE.Size = new Size(91, 21);
      this.comboBoxEE.TabIndex = 5;
      this.comboBoxEE.SelectionChangeCommitted += new EventHandler(this.progMemViewChanged);
      this.comboBoxEE.SelectedIndexChanged += new EventHandler(this.comboBoxEE_SelectedIndexChanged);
      this.checkBoxEEMem.AutoSize = true;
      this.checkBoxEEMem.Checked = true;
      this.checkBoxEEMem.CheckState = CheckState.Checked;
      this.checkBoxEEMem.Enabled = false;
      this.checkBoxEEMem.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkBoxEEMem.Location = new Point(6, 19);
      this.checkBoxEEMem.Margin = new Padding(2);
      this.checkBoxEEMem.Name = "checkBoxEEMem";
      this.checkBoxEEMem.Size = new Size(65, 17);
      this.checkBoxEEMem.TabIndex = 0;
      this.checkBoxEEMem.Text = "Enabled";
      this.checkBoxEEMem.UseVisualStyleBackColor = true;
      this.checkBoxEEMem.Visible = false;
      this.checkBoxEEMem.Click += new EventHandler(this.memorySelectVerify);
      this.displayEEProgInfo.AutoSize = true;
      this.displayEEProgInfo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.displayEEProgInfo.ForeColor = Color.Red;
      this.displayEEProgInfo.Location = new Point(186, 20);
      this.displayEEProgInfo.Margin = new Padding(2, 0, 2, 0);
      this.displayEEProgInfo.Name = "displayEEProgInfo";
      this.displayEEProgInfo.Size = new Size(206, 13);
      this.displayEEProgInfo.TabIndex = 7;
      this.displayEEProgInfo.Text = "Preserve EEPROM and User IDs on write.";
      this.displayEEProgInfo.Visible = false;
      this.timerDLFW.Tick += new EventHandler(this.autoDownloadFW);
      this.timerAutoImportWrite.Interval = 250;
      this.timerAutoImportWrite.Tick += new EventHandler(this.timerAutoImportWrite_Tick);
      this.checkBoxProgMemEnabledAlt.AutoSize = true;
      this.checkBoxProgMemEnabledAlt.Checked = true;
      this.checkBoxProgMemEnabledAlt.CheckState = CheckState.Checked;
      this.checkBoxProgMemEnabledAlt.Location = new Point(85, 268);
      this.checkBoxProgMemEnabledAlt.Margin = new Padding(2);
      this.checkBoxProgMemEnabledAlt.Name = "checkBoxProgMemEnabledAlt";
      this.checkBoxProgMemEnabledAlt.Size = new Size(69, 23);
      this.checkBoxProgMemEnabledAlt.TabIndex = 24;
      this.checkBoxProgMemEnabledAlt.Text = "Pro En";
      this.checkBoxProgMemEnabledAlt.UseVisualStyleBackColor = true;
      this.checkBoxProgMemEnabledAlt.Visible = false;
      this.checkBoxProgMemEnabledAlt.Click += new EventHandler(this.memorySelectVerify);
      this.checkBoxEEDATAMemoryEnabledAlt.AutoSize = true;
      this.checkBoxEEDATAMemoryEnabledAlt.Checked = true;
      this.checkBoxEEDATAMemoryEnabledAlt.CheckState = CheckState.Checked;
      this.checkBoxEEDATAMemoryEnabledAlt.Location = new Point(16, 268);
      this.checkBoxEEDATAMemoryEnabledAlt.Margin = new Padding(2);
      this.checkBoxEEDATAMemoryEnabledAlt.Name = "checkBoxEEDATAMemoryEnabledAlt";
      this.checkBoxEEDATAMemoryEnabledAlt.Size = new Size(65, 23);
      this.checkBoxEEDATAMemoryEnabledAlt.TabIndex = 25;
      this.checkBoxEEDATAMemoryEnabledAlt.Text = "EE En";
      this.checkBoxEEDATAMemoryEnabledAlt.UseVisualStyleBackColor = true;
      this.checkBoxEEDATAMemoryEnabledAlt.Visible = false;
      this.checkBoxEEDATAMemoryEnabledAlt.Click += new EventHandler(this.memorySelectVerify);
      this.timerInitalUpdate.Interval = 1;
      this.timerInitalUpdate.Tick += new EventHandler(this.timerInitalUpdate_Tick);
      this.tabControl1.Controls.Add((Control) this.tabPage3);
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Controls.Add((Control) this.tabPage4);
      this.tabControl1.Font = new Font("Comic Sans MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tabControl1.Location = new Point(1, 25);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(533, 414);
      this.tabControl1.TabIndex = 27;
      this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);
      this.tabPage3.Controls.Add((Control) this.label6);
      this.tabPage3.Controls.Add((Control) this.label5);
      this.tabPage3.Controls.Add((Control) this.label4);
      this.tabPage3.Controls.Add((Control) this.progressBar1);
      this.tabPage3.Controls.Add((Control) this.buttonWrite);
      this.tabPage3.Controls.Add((Control) this.button1);
      this.tabPage3.Controls.Add((Control) this.buttonExportHex);
      this.tabPage3.Controls.Add((Control) this.buttonErase);
      this.tabPage3.Controls.Add((Control) this.statusGroupBox);
      this.tabPage3.Controls.Add((Control) this.buttonRead);
      this.tabPage3.Controls.Add((Control) this.buttonVerify);
      this.tabPage3.Controls.Add((Control) this.checkBoxAutoImportWrite);
      this.tabPage3.Controls.Add((Control) this.displayStatusWindow);
      this.tabPage3.Controls.Add((Control) this.buttonBlankCheck);
      this.tabPage3.Location = new Point(4, 28);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new Padding(3);
      this.tabPage3.Size = new Size(525, 382);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "CONTROL";
      this.tabPage3.UseVisualStyleBackColor = true;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(202, 364);
      this.label6.Name = "label6";
      this.label6.Size = new Size(120, 19);
      this.label6.TabIndex = 31;
      this.label6.Text = "P R O G R E S O";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(478, 344);
      this.label5.Name = "label5";
      this.label5.Size = new Size(44, 19);
      this.label5.TabIndex = 30;
      this.label5.Text = "100%";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(10, 344);
      this.label4.Name = "label4";
      this.label4.Size = new Size(28, 19);
      this.label4.TabIndex = 29;
      this.label4.Text = "0%";
      this.tabPage1.Controls.Add((Control) this.groupBoxProgMem);
      this.tabPage1.Font = new Font("Comic Sans MS", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.tabPage1.Location = new Point(4, 28);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(525, 382);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "FLASH";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.tabPage2.Controls.Add((Control) this.groupBoxEEMem);
      this.tabPage2.Controls.Add((Control) this.checkBoxEEDATAMemoryEnabledAlt);
      this.tabPage2.Controls.Add((Control) this.checkBoxProgMemEnabledAlt);
      this.tabPage2.Location = new Point(4, 28);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(525, 382);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "EEPROM";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.tabPage4.Controls.Add((Control) this.tabControl2);
      this.tabPage4.Location = new Point(4, 28);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Padding = new Padding(3);
      this.tabPage4.Size = new Size(525, 382);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "ZIF";
      this.tabPage4.UseVisualStyleBackColor = true;
      this.tabControl2.Alignment = TabAlignment.Bottom;
      this.tabControl2.Controls.Add((Control) this.tabPage5);
      this.tabControl2.Controls.Add((Control) this.tabPage6);
      this.tabControl2.Controls.Add((Control) this.tabPage7);
      this.tabControl2.Controls.Add((Control) this.tabPage8);
      this.tabControl2.Controls.Add((Control) this.tabPage9);
      this.tabControl2.Controls.Add((Control) this.tabPage10);
      this.tabControl2.Controls.Add((Control) this.tabPage11);
      this.tabControl2.Location = new Point(3, 3);
      this.tabControl2.Multiline = true;
      this.tabControl2.Name = "tabControl2";
      this.tabControl2.SelectedIndex = 0;
      this.tabControl2.Size = new Size(519, 376);
      this.tabControl2.TabIndex = 0;
      this.tabPage5.Controls.Add((Control) this.pictureBox2);
      this.tabPage5.Location = new Point(4, 4);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new Padding(3);
      this.tabPage5.Size = new Size(511, 344);
      this.tabPage5.TabIndex = 0;
      this.tabPage5.Text = "8 PINS";
      this.tabPage5.UseVisualStyleBackColor = true;
      this.tabPage6.Controls.Add((Control) this.pictureBox5);
      this.tabPage6.Location = new Point(4, 4);
      this.tabPage6.Name = "tabPage6";
      this.tabPage6.Padding = new Padding(3);
      this.tabPage6.Size = new Size(511, 344);
      this.tabPage6.TabIndex = 1;
      this.tabPage6.Text = "14 PINS";
      this.tabPage6.UseVisualStyleBackColor = true;
      this.tabPage7.Controls.Add((Control) this.pictureBox6);
      this.tabPage7.Location = new Point(4, 4);
      this.tabPage7.Name = "tabPage7";
      this.tabPage7.Padding = new Padding(3);
      this.tabPage7.Size = new Size(511, 344);
      this.tabPage7.TabIndex = 2;
      this.tabPage7.Text = "18 PINS";
      this.tabPage7.UseVisualStyleBackColor = true;
      this.tabPage8.Controls.Add((Control) this.pictureBox7);
      this.tabPage8.Location = new Point(4, 4);
      this.tabPage8.Name = "tabPage8";
      this.tabPage8.Padding = new Padding(3);
      this.tabPage8.Size = new Size(511, 344);
      this.tabPage8.TabIndex = 3;
      this.tabPage8.Text = "28 PINS";
      this.tabPage8.UseVisualStyleBackColor = true;
      this.tabPage9.Controls.Add((Control) this.pictureBox8);
      this.tabPage9.Location = new Point(4, 4);
      this.tabPage9.Name = "tabPage9";
      this.tabPage9.Padding = new Padding(3);
      this.tabPage9.Size = new Size(511, 344);
      this.tabPage9.TabIndex = 4;
      this.tabPage9.Text = "40 PINS";
      this.tabPage9.UseVisualStyleBackColor = true;
      this.tabPage10.Controls.Add((Control) this.pictureBox9);
      this.tabPage10.Location = new Point(4, 4);
      this.tabPage10.Name = "tabPage10";
      this.tabPage10.Padding = new Padding(3);
      this.tabPage10.Size = new Size(511, 344);
      this.tabPage10.TabIndex = 5;
      this.tabPage10.Text = "93Cxx";
      this.tabPage10.UseVisualStyleBackColor = true;
      this.tabPage10.Click += new EventHandler(this.tabPage10_Click);
      this.tabPage11.Controls.Add((Control) this.pictureBox11);
      this.tabPage11.Location = new Point(4, 4);
      this.tabPage11.Name = "tabPage11";
      this.tabPage11.Padding = new Padding(3);
      this.tabPage11.Size = new Size(511, 344);
      this.tabPage11.TabIndex = 6;
      this.tabPage11.Text = "24Cxx";
      this.tabPage11.UseVisualStyleBackColor = true;
      this.pictureBox1.Location = new Point(393, 10);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(10, 10);
      this.pictureBox1.TabIndex = 26;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Visible = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click_1);
      this.readDeviceToolStripMenuItem.Image = (Image) Resources.LEER_CHIP;
      this.readDeviceToolStripMenuItem.Name = "readDeviceToolStripMenuItem";
      this.readDeviceToolStripMenuItem.Size = new Size(264, 22);
      this.readDeviceToolStripMenuItem.Text = "Leer Dispositivo";
      this.readDeviceToolStripMenuItem.Click += new EventHandler(this.readDevice);
      this.writeDeviceToolStripMenuItem.Image = (Image) Resources.GRABAR_CHIP;
      this.writeDeviceToolStripMenuItem.Name = "writeDeviceToolStripMenuItem";
      this.writeDeviceToolStripMenuItem.Size = new Size(264, 22);
      this.writeDeviceToolStripMenuItem.Text = "Escribir Dispositivo";
      this.writeDeviceToolStripMenuItem.Click += new EventHandler(this.writeDevice);
      this.eraseToolStripMenuItem.Image = (Image) Resources.BORRAR_CHIP;
      this.eraseToolStripMenuItem.Name = "eraseToolStripMenuItem";
      this.eraseToolStripMenuItem.Size = new Size(264, 22);
      this.eraseToolStripMenuItem.Text = "Borrar";
      this.eraseToolStripMenuItem.Click += new EventHandler(this.eraseDevice);
      this.blankCheckToolStripMenuItem.Image = (Image) Resources.CHECAR_BORRADO_CHIP;
      this.blankCheckToolStripMenuItem.Name = "blankCheckToolStripMenuItem";
      this.blankCheckToolStripMenuItem.Size = new Size(264, 22);
      this.blankCheckToolStripMenuItem.Text = "¿Dispositivo Borrado?";
      this.blankCheckToolStripMenuItem.Click += new EventHandler(this.blankCheck);
      this.verifyToolStripMenuItem.Image = (Image) Resources.VERIFICAR_CHIP;
      this.verifyToolStripMenuItem.Name = "verifyToolStripMenuItem";
      this.verifyToolStripMenuItem.Size = new Size(264, 22);
      this.verifyToolStripMenuItem.Text = "Verificar Escritura";
      this.verifyToolStripMenuItem.Click += new EventHandler(this.verifyDevice);
      this.verifyOnWriteToolStripMenuItem.Checked = true;
      this.verifyOnWriteToolStripMenuItem.CheckOnClick = true;
      this.verifyOnWriteToolStripMenuItem.CheckState = CheckState.Checked;
      this.verifyOnWriteToolStripMenuItem.Image = (Image) Resources.VERIFICAR_CHIP;
      this.verifyOnWriteToolStripMenuItem.Name = "verifyOnWriteToolStripMenuItem";
      this.verifyOnWriteToolStripMenuItem.Size = new Size(376, 22);
      this.verifyOnWriteToolStripMenuItem.Text = "Verificar al Escribir";
      this.enableCodeProtectToolStripMenuItem.CheckOnClick = true;
      this.enableCodeProtectToolStripMenuItem.Image = (Image) Resources.BLOQUEAR_CHIP_2;
      this.enableCodeProtectToolStripMenuItem.Name = "enableCodeProtectToolStripMenuItem";
      this.enableCodeProtectToolStripMenuItem.Size = new Size(376, 22);
      this.enableCodeProtectToolStripMenuItem.Text = "Proteger Código (Anti Copia)";
      this.enableCodeProtectToolStripMenuItem.Click += new EventHandler(this.codeProtect);
      this.enableDataProtectStripMenuItem.CheckOnClick = true;
      this.enableDataProtectStripMenuItem.Enabled = false;
      this.enableDataProtectStripMenuItem.Image = (Image) Resources.BLOQUEAR_CHIP_2;
      this.enableDataProtectStripMenuItem.Name = "enableDataProtectStripMenuItem";
      this.enableDataProtectStripMenuItem.Size = new Size(376, 22);
      this.enableDataProtectStripMenuItem.Text = "Proteger Datos (EEPROM)";
      this.enableDataProtectStripMenuItem.Click += new EventHandler(this.dataProtect);
      this.setOSCCALToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.calSetManuallyToolStripMenuItem,
        (ToolStripItem) this.calAutoRegenerateToolStripMenuItem
      });
      this.setOSCCALToolStripMenuItem.Image = (Image) Resources.TIMER_CHIP;
      this.setOSCCALToolStripMenuItem.Name = "setOSCCALToolStripMenuItem";
      this.setOSCCALToolStripMenuItem.Size = new Size(376, 22);
      this.setOSCCALToolStripMenuItem.Text = "Ajustar OSCCAL (Calibración del Oscilador Interno)";
      this.calSetManuallyToolStripMenuItem.Name = "calSetManuallyToolStripMenuItem";
      this.calSetManuallyToolStripMenuItem.Size = new Size(173, 22);
      this.calSetManuallyToolStripMenuItem.Text = "Ajuste Manual";
      this.calSetManuallyToolStripMenuItem.Click += new EventHandler(this.setOSCCAL);
      this.calAutoRegenerateToolStripMenuItem.Name = "calAutoRegenerateToolStripMenuItem";
      this.calAutoRegenerateToolStripMenuItem.Size = new Size(173, 22);
      this.calAutoRegenerateToolStripMenuItem.Text = "Auto Calibración";
      this.calAutoRegenerateToolStripMenuItem.Click += new EventHandler(this.calAutoRegenerateToolStripMenuItem_Click);
      this.usersGuideToolStripMenuItem.Image = (Image) Resources.Chip_2;
      this.usersGuideToolStripMenuItem.Name = "usersGuideToolStripMenuItem";
      this.usersGuideToolStripMenuItem.Size = new Size(319, 22);
      this.usersGuideToolStripMenuItem.Text = "Ver manual del usuario";
      this.usersGuideToolStripMenuItem.Visible = false;
      this.usersGuideToolStripMenuItem.Click += new EventHandler(this.ver_manual);
      this.toolStripMenuItemLogicToolUG.Image = (Image) Resources.Chip_2;
      this.toolStripMenuItemLogicToolUG.Name = "toolStripMenuItemLogicToolUG";
      this.toolStripMenuItemLogicToolUG.Size = new Size(319, 22);
      this.toolStripMenuItemLogicToolUG.Text = "Ajustar Bits de Configuración";
      this.toolStripMenuItemLogicToolUG.Visible = false;
      this.toolStripMenuItemLogicToolUG.Click += new EventHandler(this.ajustar_config);
      this.webPUSBToolStripMenuItem.Image = (Image) Resources.ICON_1_b;
      this.webPUSBToolStripMenuItem.Name = "webPUSBToolStripMenuItem";
      this.webPUSBToolStripMenuItem.Size = new Size(319, 22);
      this.webPUSBToolStripMenuItem.Text = "Ver Fichas Técnicas PIC, dsPIC y EEPROM";
      this.webPUSBToolStripMenuItem.Click += new EventHandler(this.pickit2OnTheWeb);
      this.readMeToolStripMenuItem.Image = (Image) Resources.Logo_Microchip;
      this.readMeToolStripMenuItem.Name = "readMeToolStripMenuItem";
      this.readMeToolStripMenuItem.Size = new Size(319, 22);
      this.readMeToolStripMenuItem.Text = "Visitar Sitio www.microchip.com";
      this.readMeToolStripMenuItem.Click += new EventHandler(this.VisitarMicrochip);
      this.aboutToolStripMenuItem.Image = (Image) Resources.ICON_5;
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new Size(319, 22);
      this.aboutToolStripMenuItem.Text = "Ventas y Soporte Técnico";
      this.aboutToolStripMenuItem.Click += new EventHandler(this.clickAbout);
      this.buttonWrite.Enabled = false;
      this.buttonWrite.Font = new Font("Comic Sans MS", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.buttonWrite.ForeColor = Color.Red;
      this.buttonWrite.Image = (Image) Resources.GRABAR_CHIP;
      this.buttonWrite.ImageAlign = ContentAlignment.MiddleLeft;
      this.buttonWrite.Location = new Point(6, 102);
      this.buttonWrite.Margin = new Padding(2);
      this.buttonWrite.Name = "buttonWrite";
      this.buttonWrite.Size = new Size(111, 40);
      this.buttonWrite.TabIndex = 7;
      this.buttonWrite.Text = "ESCRIBIR";
      this.buttonWrite.TextAlign = ContentAlignment.MiddleRight;
      this.buttonWrite.TextImageRelation = TextImageRelation.TextBeforeImage;
      this.buttonWrite.UseVisualStyleBackColor = true;
      this.buttonWrite.Click += new EventHandler(this.writeDevice);
      this.button1.Font = new Font("Comic Sans MS", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = Color.Red;
      this.button1.Image = (Image) Resources.USB;
      this.button1.Location = new Point(388, 88);
      this.button1.Name = "button1";
      this.button1.Size = new Size(132, 54);
      this.button1.TabIndex = 28;
      this.button1.Text = "AUTO/CONEX";
      this.button1.TextImageRelation = TextImageRelation.ImageAboveText;
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.checkCommunication);
      this.buttonExportHex.Font = new Font("Comic Sans MS", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.buttonExportHex.ForeColor = Color.Blue;
      this.buttonExportHex.Image = (Image) Resources.AUTOSAVE_CHIP_2;
      this.buttonExportHex.Location = new Point(247, 89);
      this.buttonExportHex.Margin = new Padding(2);
      this.buttonExportHex.Name = "buttonExportHex";
      this.buttonExportHex.Size = new Size(135, 53);
      this.buttonExportHex.TabIndex = 21;
      this.buttonExportHex.Text = "LEER/GUARDAR";
      this.buttonExportHex.TextImageRelation = TextImageRelation.ImageAboveText;
      this.buttonExportHex.UseVisualStyleBackColor = true;
      this.buttonExportHex.Click += new EventHandler(this.buttonReadExport);
      this.buttonErase.Enabled = false;
      this.buttonErase.Font = new Font("Comic Sans MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.buttonErase.ForeColor = Color.Red;
      this.buttonErase.Image = (Image) Resources.BORRAR_CHIP;
      this.buttonErase.Location = new Point(6, 54);
      this.buttonErase.Margin = new Padding(2);
      this.buttonErase.Name = "buttonErase";
      this.buttonErase.Size = new Size(111, 40);
      this.buttonErase.TabIndex = 9;
      this.buttonErase.Text = "BORRAR";
      this.buttonErase.TextImageRelation = TextImageRelation.TextBeforeImage;
      this.buttonErase.UseVisualStyleBackColor = true;
      this.buttonErase.Click += new EventHandler(this.eraseDevice);
      this.pictureBox14.Image = (Image) Resources.skull_crossbones;
      this.pictureBox14.Location = new Point(159, 7);
      this.pictureBox14.Name = "pictureBox14";
      this.pictureBox14.Size = new Size(197, 182);
      this.pictureBox14.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox14.TabIndex = 30;
      this.pictureBox14.TabStop = false;
      this.pictureBox14.Visible = false;
      this.pictureBox14.Click += new EventHandler(this.pictureBox14_Click_1);
      this.pictureBox13.Image = (Image) Resources.ID_CHIP;
      this.pictureBox13.Location = new Point(277, 22);
      this.pictureBox13.Name = "pictureBox13";
      this.pictureBox13.Size = new Size(32, 32);
      this.pictureBox13.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox13.TabIndex = 29;
      this.pictureBox13.TabStop = false;
      this.pictureBox12.Image = (Image) Resources.CONFIG_CHIP_2;
      this.pictureBox12.Location = new Point(6, 129);
      this.pictureBox12.Name = "pictureBox12";
      this.pictureBox12.Size = new Size(32, 32);
      this.pictureBox12.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox12.TabIndex = 28;
      this.pictureBox12.TabStop = false;
      this.pictureBox10.Image = (Image) Resources.TIPO_CHIP;
      this.pictureBox10.Location = new Point(7, 21);
      this.pictureBox10.Name = "pictureBox10";
      this.pictureBox10.Size = new Size(32, 32);
      this.pictureBox10.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox10.TabIndex = 27;
      this.pictureBox10.TabStop = false;
      this.pictureBox10.Click += new EventHandler(this.pictureBox10_Click);
      this.pictureBox4.Image = (Image) Resources.BLOQUEAR_CHIP_3;
      this.pictureBox4.Location = new Point(7, 57);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(32, 32);
      this.pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox4.TabIndex = 26;
      this.pictureBox4.TabStop = false;
      this.pictureBox3.Image = (Image) Resources.TIMER_CHIP;
      this.pictureBox3.Location = new Point(6, 93);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(32, 32);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox3.TabIndex = 25;
      this.pictureBox3.TabStop = false;
      this.button2.Font = new Font("Comic Sans MS", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button2.Image = (Image) Resources.RESET_CHIP;
      this.button2.Location = new Point(337, 149);
      this.button2.Name = "button2";
      this.button2.RightToLeft = RightToLeft.No;
      this.button2.Size = new Size(111, 42);
      this.button2.TabIndex = 24;
      this.button2.Text = "RESET\r\nICSP";
      this.button2.TextImageRelation = TextImageRelation.TextBeforeImage;
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Visible = false;
      this.button2.Click += new EventHandler(this.MCLRtoolStripMenuItem_Click);
      this.buttonRead.Enabled = false;
      this.buttonRead.Font = new Font("Comic Sans MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.buttonRead.ForeColor = Color.Blue;
      this.buttonRead.Image = (Image) Resources.LEER_CHIP;
      this.buttonRead.ImageAlign = ContentAlignment.MiddleLeft;
      this.buttonRead.Location = new Point(6, 6);
      this.buttonRead.Margin = new Padding(2);
      this.buttonRead.Name = "buttonRead";
      this.buttonRead.Size = new Size(111, 40);
      this.buttonRead.TabIndex = 5;
      this.buttonRead.Text = "LEER";
      this.buttonRead.TextAlign = ContentAlignment.MiddleRight;
      this.buttonRead.TextImageRelation = TextImageRelation.TextBeforeImage;
      this.buttonRead.UseVisualStyleBackColor = true;
      this.buttonRead.Click += new EventHandler(this.readDevice);
      this.buttonVerify.Enabled = false;
      this.buttonVerify.Font = new Font("Comic Sans MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.buttonVerify.ForeColor = Color.Orange;
      this.buttonVerify.Image = (Image) Resources.VERIFICAR_CHIP;
      this.buttonVerify.Location = new Point(121, 7);
      this.buttonVerify.Margin = new Padding(2);
      this.buttonVerify.Name = "buttonVerify";
      this.buttonVerify.Size = new Size(123, 40);
      this.buttonVerify.TabIndex = 8;
      this.buttonVerify.Text = "VERIFICAR";
      this.buttonVerify.TextImageRelation = TextImageRelation.TextBeforeImage;
      this.buttonVerify.UseVisualStyleBackColor = true;
      this.buttonVerify.Click += new EventHandler(this.verifyDevice);
      this.checkBoxAutoImportWrite.Appearance = Appearance.Button;
      this.checkBoxAutoImportWrite.Font = new Font("Comic Sans MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.checkBoxAutoImportWrite.ForeColor = Color.MediumBlue;
      this.checkBoxAutoImportWrite.Image = (Image) Resources.AUTOPROG_CHIP;
      this.checkBoxAutoImportWrite.Location = new Point(121, 101);
      this.checkBoxAutoImportWrite.Margin = new Padding(2);
      this.checkBoxAutoImportWrite.Name = "checkBoxAutoImportWrite";
      this.checkBoxAutoImportWrite.Size = new Size(122, 40);
      this.checkBoxAutoImportWrite.TabIndex = 23;
      this.checkBoxAutoImportWrite.Text = "AUTOPROG";
      this.checkBoxAutoImportWrite.TextAlign = ContentAlignment.MiddleCenter;
      this.checkBoxAutoImportWrite.TextImageRelation = TextImageRelation.TextBeforeImage;
      this.checkBoxAutoImportWrite.UseVisualStyleBackColor = true;
      this.checkBoxAutoImportWrite.Click += new EventHandler(this.checkBoxAutoImportWrite_Click);
      this.checkBoxAutoImportWrite.CheckedChanged += new EventHandler(this.checkBoxAutoImportWrite_Changed);
      this.buttonBlankCheck.Enabled = false;
      this.buttonBlankCheck.Font = new Font("Comic Sans MS", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.buttonBlankCheck.ForeColor = Color.LimeGreen;
      this.buttonBlankCheck.Image = (Image) Resources.CHECAR_BORRADO_CHIP;
      this.buttonBlankCheck.Location = new Point(121, 54);
      this.buttonBlankCheck.Margin = new Padding(2);
      this.buttonBlankCheck.Name = "buttonBlankCheck";
      this.buttonBlankCheck.Size = new Size(123, 40);
      this.buttonBlankCheck.TabIndex = 10;
      this.buttonBlankCheck.Text = "¿BORRADO?";
      this.buttonBlankCheck.TextImageRelation = TextImageRelation.TextBeforeImage;
      this.buttonBlankCheck.UseVisualStyleBackColor = true;
      this.buttonBlankCheck.Click += new EventHandler(this.blankCheck);
      this.pictureBox2.Dock = DockStyle.Fill;
      this.pictureBox2.Image = (Image) Resources._8_PIN;
      this.pictureBox2.Location = new Point(3, 3);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(505, 338);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox2.TabIndex = 0;
      this.pictureBox2.TabStop = false;
      this.pictureBox5.Dock = DockStyle.Fill;
      this.pictureBox5.Image = (Image) Resources._14_PIN;
      this.pictureBox5.Location = new Point(3, 3);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(505, 344);
      this.pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox5.TabIndex = 1;
      this.pictureBox5.TabStop = false;
      this.pictureBox6.Dock = DockStyle.Fill;
      this.pictureBox6.Image = (Image) Resources._18_PIN;
      this.pictureBox6.Location = new Point(3, 3);
      this.pictureBox6.Name = "pictureBox6";
      this.pictureBox6.Size = new Size(505, 344);
      this.pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox6.TabIndex = 1;
      this.pictureBox6.TabStop = false;
      this.pictureBox7.Dock = DockStyle.Fill;
      this.pictureBox7.Image = (Image) Resources._28_PIN;
      this.pictureBox7.Location = new Point(3, 3);
      this.pictureBox7.Name = "pictureBox7";
      this.pictureBox7.Size = new Size(505, 344);
      this.pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox7.TabIndex = 1;
      this.pictureBox7.TabStop = false;
      this.pictureBox8.Dock = DockStyle.Fill;
      this.pictureBox8.Image = (Image) Resources._40_PIN1;
      this.pictureBox8.Location = new Point(3, 3);
      this.pictureBox8.Name = "pictureBox8";
      this.pictureBox8.Size = new Size(505, 344);
      this.pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox8.TabIndex = 1;
      this.pictureBox8.TabStop = false;
      this.pictureBox9.Dock = DockStyle.Fill;
      this.pictureBox9.Image = (Image) Resources._93C_ZIF;
      this.pictureBox9.Location = new Point(3, 3);
      this.pictureBox9.Name = "pictureBox9";
      this.pictureBox9.Size = new Size(505, 344);
      this.pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox9.TabIndex = 2;
      this.pictureBox9.TabStop = false;
      this.pictureBox11.Dock = DockStyle.Fill;
      this.pictureBox11.Image = (Image) Resources._24C_ZIF1;
      this.pictureBox11.Location = new Point(3, 3);
      this.pictureBox11.Name = "pictureBox11";
      this.pictureBox11.Size = new Size(505, 344);
      this.pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox11.TabIndex = 3;
      this.pictureBox11.TabStop = false;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = SystemColors.ControlLight;
      this.ClientSize = new Size(534, 438);
      this.Controls.Add((Control) this.groupBoxVDD);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.menuStrip1);
      this.Controls.Add((Control) this.tabControl1);
      this.Font = new Font("Comic Sans MS", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new Padding(2);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(540, 470);
      this.MinimumSize = new Size(540, 470);
      this.Name = "FormProgUSB";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "MASTER-PROG+";
      this.Move += new EventHandler(this.FormPICkit2_Move);
      this.FormClosing += new FormClosingEventHandler(this.pickitFormClosing);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.statusGroupBox.ResumeLayout(false);
      this.statusGroupBox.PerformLayout();
      this.dataGridConfigWords.EndInit();
      this.numUpDnVDD.EndInit();
      this.groupBoxVDD.ResumeLayout(false);
      this.groupBoxVDD.PerformLayout();
      this.groupBoxProgMem.ResumeLayout(false);
      this.groupBoxProgMem.PerformLayout();
      this.dataGridProgramMemory.EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.groupBoxEEMem.ResumeLayout(false);
      this.groupBoxEEMem.PerformLayout();
      this.dataGridViewEEPROM.EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tabPage4.ResumeLayout(false);
      this.tabControl2.ResumeLayout(false);
      this.tabPage5.ResumeLayout(false);
      this.tabPage6.ResumeLayout(false);
      this.tabPage7.ResumeLayout(false);
      this.tabPage8.ResumeLayout(false);
      this.tabPage9.ResumeLayout(false);
      this.tabPage10.ResumeLayout(false);
      this.tabPage11.ResumeLayout(false);
      this.pictureBox1.EndInit();
      this.pictureBox14.EndInit();
      this.pictureBox13.EndInit();
      this.pictureBox12.EndInit();
      this.pictureBox10.EndInit();
      this.pictureBox4.EndInit();
      this.pictureBox3.EndInit();
      this.pictureBox2.EndInit();
      this.pictureBox5.EndInit();
      this.pictureBox6.EndInit();
      this.pictureBox7.EndInit();
      this.pictureBox8.EndInit();
      this.pictureBox9.EndInit();
      this.pictureBox11.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public struct FLASHWINFO
    {
      public ushort cbSize;
      public IntPtr hwnd;
      public uint dwFlags;
      public ushort uCount;
      public uint dwTimeout;
    }
  }
}
