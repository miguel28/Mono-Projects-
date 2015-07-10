// Type: SysProgUSB.DialogPK2Go
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogPK2Go : Form
  {
    public string dataSource = "--";
    public bool writeProgMem = true;
    public bool writeEEPROM = true;
    public bool fastProgramming = true;
    public byte icspSpeedSlow = (byte) 4;
    public float VDDVolts;
    public bool codeProtect;
    public bool dataProtect;
    public bool verifyDevice;
    public bool vppFirst;
    public bool holdMCLR;
    private byte ptgMemory;
    private int blinkCount;
    public DelegateWrite PICkit2WriteGo;
    public DelegateOpenProgToGoGuide OpenProgToGoGuide;
    private IContainer components;
    private Panel panelIntro;
    private Button buttonBack;
    private Button buttonNext;
    private Button buttonCancel;
    private Button buttonHelp;
    private Panel panelSettings;
    private Label label16;
    private Label label1;
    private Label label15;
    private GroupBox groupBox1;
    private Label label2;
    private RadioButton radioButtonPK2Power;
    private RadioButton radioButtonSelfPower;
    private GroupBox groupBox2;
    private Label label5;
    private Label labelPartNumber;
    private Label label3;
    private Label labelDataSource;
    private Label label4;
    private Panel panelDownload;
    private GroupBox groupBox3;
    private Label labelTargetPowerSmmry;
    private Label label12;
    private Label label7;
    private Label labelSourceSmmry;
    private Label label8;
    private Label labelOSCCAL_BandGap;
    private Label label10;
    private Label labelMemRegions;
    private Label labelCodeProtect;
    private Label label14;
    private Label labelVerify;
    private Label label11;
    private Label labelDataProtect;
    private Label label9;
    private Label labelRowErase;
    private CheckBox checkBoxRowErase;
    private Label labelVDDMin;
    private Label labelPNsmmry;
    private Label labelMemRegionsSmmry;
    private Label label6;
    private Label labelMCLRHoldSmmry;
    private Label labelFastProgSmmry;
    private Label labelVerifySmmry;
    private Label labelVPP1stSmmry;
    private Panel panelDownloading;
    private Label labelDOWNLOADING;
    private Panel panelDownloadDone;
    private Label label13;
    private Label label17;
    private Timer timerBlink;
    private Label label20;
    private Label label19;
    private Label label18;
    private PictureBox pictureBoxTarget;
    private Panel panelErrors;
    private Label label21;
    private Label label22;
    private Label label23;
    private PictureBox pictureBoxBusy;
    private Label label26;
    private Label label25;
    private RadioButton radioButton4Blinks;
    private RadioButton radioButton3Blinks;
    private RadioButton radioButton2Blinks;
    private RadioButton radioButtonVErr;
    private Label label24;
    private Label label27;
    private Label label28;
    private Label label29;
    private Label label256K;

    public DialogPK2Go()
    {
      this.InitializeComponent();
    }

    public void SetPTGMemory(byte value)
    {
      this.ptgMemory = value;
      if ((int) this.ptgMemory <= 0)
        return;
      this.label256K.Visible = true;
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void buttonNext_Click(object sender, EventArgs e)
    {
      if (this.panelIntro.Visible)
      {
        this.panelIntro.Visible = false;
        this.buttonBack.Enabled = true;
        this.fillSettings(true);
      }
      else if (this.panelSettings.Visible)
      {
        if (!this.checkEraseVoltage())
          return;
        this.panelSettings.Visible = false;
        this.buttonNext.Text = "Download";
        this.fillDownload();
      }
      else if (this.panelDownload.Visible)
      {
        this.downloadGO();
      }
      else
      {
        if (!this.panelDownloadDone.Visible)
          return;
        this.buttonNext.Enabled = false;
        this.panelDownloadDone.Visible = false;
        this.panelErrors.Visible = true;
        this.timerBlink.Interval = 84;
      }
    }

    private void buttonBack_Click(object sender, EventArgs e)
    {
      if (this.panelSettings.Visible)
      {
        this.panelSettings.Visible = false;
        this.panelIntro.Visible = true;
        this.buttonBack.Enabled = false;
      }
      else
      {
        if (!this.panelDownload.Visible)
          return;
        this.panelDownload.Visible = false;
        this.buttonNext.Text = "Next >";
        this.fillSettings(false);
      }
    }

    private bool checkEraseVoltage()
    {
      return this.radioButtonSelfPower.Checked || (double) this.VDDVolts >= (double) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddErase || ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseScript != 0 || MessageBox.Show("El voltaje VDD del MASTER-PROG es menor\nque el m�nimo necesario para borrar.\n\n�Continuar?", this.labelPartNumber.Text + "�� E R R O R !! ", MessageBoxButtons.OKCancel) == DialogResult.OK);
    }

    private void fillSettings(bool changePower)
    {
      this.labelPartNumber.Text = ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].PartName;
      if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].OSSCALSave)
      {
        this.labelOSCCAL_BandGap.Visible = true;
        if (ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BandGapMask > 0U)
          this.labelOSCCAL_BandGap.Text = "OSCCAL && BandGap will be preserved.";
      }
      if (this.dataSource == "Edited.")
        this.labelDataSource.Text = "Edited Buffer.";
      else
        this.labelDataSource.Text = this.dataSource;
      if (!this.writeProgMem)
      {
        this.labelCodeProtect.Text = "N/A";
        this.labelDataProtect.Text = "N/A";
      }
      else
      {
        if (this.codeProtect)
          this.labelCodeProtect.Text = "ON";
        else
          this.labelCodeProtect.Text = "OFF";
        if (this.dataProtect)
          this.labelDataProtect.Text = "ON";
        else if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
          this.labelDataProtect.Text = "OFF";
        else
          this.labelDataProtect.Text = "N/A";
      }
      if (!this.writeProgMem)
        this.labelMemRegions.Text = "Write EEPROM data only.";
      else if (!this.writeEEPROM && (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
        this.labelMemRegions.Text = "Preserve EEPROM on write.";
      else
        this.labelMemRegions.Text = "Write entire device.";
      if (this.verifyDevice)
        this.labelVerify.Text = "Yes";
      else
        this.labelVerify.Text = "No - device will NOT be verified";
      if (changePower)
      {
        this.radioButtonPK2Power.Text = string.Format("Power target from MASTER-PROG at {0:0.0} Volts.", (object) this.VDDVolts);
        if (this.vppFirst)
        {
          this.radioButtonSelfPower.Enabled = false;
          this.radioButtonSelfPower.Text = "Use VPP First - must power from MASTER-PROG";
          this.checkBoxRowErase.Enabled = false;
          this.radioButtonPK2Power.Checked = true;
          this.pickit2PowerRowErase();
        }
        else
        {
          this.radioButtonSelfPower.Checked = true;
          if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseScript > 0)
          {
            this.checkBoxRowErase.Text = string.Format("VDD < {0:0.0}V: Use low voltage row erase", (object) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddErase);
            this.checkBoxRowErase.Enabled = true;
          }
          else
          {
            this.checkBoxRowErase.Visible = false;
            this.checkBoxRowErase.Enabled = false;
            this.labelVDDMin.Text = string.Format("VDD must be >= {0:0.0} Volts.", (object) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddErase);
            this.labelVDDMin.Visible = true;
          }
        }
      }
      this.panelSettings.Visible = true;
    }

    private bool pickit2PowerRowErase()
    {
      if ((double) this.VDDVolts < (double) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddErase)
      {
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseScript <= 0)
          return false;
        this.labelRowErase.Visible = true;
      }
      else
        this.labelRowErase.Visible = false;
      return true;
    }

    private void fillDownload()
    {
      this.labelPNsmmry.Text = this.labelPartNumber.Text;
      this.labelSourceSmmry.Text = this.labelDataSource.Text;
      if (this.radioButtonSelfPower.Checked)
      {
        if (this.checkBoxRowErase.Enabled && this.checkBoxRowErase.Checked)
          this.labelTargetPowerSmmry.Text = "Voltaje VDD Correcto (Usar Borrado LVP)";
        else
          this.labelTargetPowerSmmry.Text = string.Format("Target is Powered (Min VDD = {0:0.0} Volts)", (object) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddErase);
      }
      else
        this.labelTargetPowerSmmry.Text = string.Format("Power target from MASTER-PROG at {0:0.0} Volts", (object) this.VDDVolts);
      this.labelMemRegionsSmmry.Text = this.labelMemRegions.Text;
      if (this.writeProgMem)
      {
        if (this.codeProtect)
        {
          Label label = this.labelMemRegionsSmmry;
          string str = label.Text + " -CP";
          label.Text = str;
        }
        if (this.dataProtect)
        {
          Label label = this.labelMemRegionsSmmry;
          string str = label.Text + " -DP";
          label.Text = str;
        }
      }
      if (this.vppFirst)
        this.labelVPP1stSmmry.Text = "Use VPP 1st Program Entry";
      else
        this.labelVPP1stSmmry.Text = "";
      if (this.verifyDevice)
        this.labelVerifySmmry.Text = "Device will be verified";
      else
        this.labelVerifySmmry.Text = "Device will NOT be verified";
      if (this.fastProgramming)
        this.labelFastProgSmmry.Text = "Fast Programming is ON";
      else
        this.labelFastProgSmmry.Text = "Fast Programming is OFF";
      if (this.holdMCLR)
        this.labelMCLRHoldSmmry.Text = "MCLR kept asserted during && after programming";
      else
        this.labelMCLRHoldSmmry.Text = "MCLR released after programming";
      this.panelDownload.Visible = true;
    }

    private void downloadGO()
    {
      this.panelDownload.Visible = false;
      this.panelDownloading.Visible = true;
      this.buttonHelp.Enabled = false;
      this.buttonBack.Enabled = false;
      this.buttonNext.Enabled = false;
      this.buttonCancel.Enabled = false;
      this.buttonCancel.Text = "Exit";
      this.Update();
      if (this.radioButtonSelfPower.Checked)
        ProgCommand.ForceTargetPowered();
      else
        ProgCommand.ForcePICkitPowered();
      if ((int) this.ptgMemory == 0)
        ProgCommand.EnterLearnMode((byte) 0);
      else
        ProgCommand.EnterLearnMode((byte) 1);
      if (this.fastProgramming)
        ProgCommand.SetProgrammingSpeed((byte) 0);
      else
        ProgCommand.SetProgrammingSpeed(this.icspSpeedSlow);
      int num = this.PICkit2WriteGo(true) ? 1 : 0;
      ProgCommand.ExitLearnMode();
      if ((int) this.ptgMemory == 0)
        ProgCommand.EnablePK2GoMode((byte) 0);
      else
        ProgCommand.EnablePK2GoMode((byte) 1);
      ProgCommand.DisconnectPICkit2Unit();
      this.panelDownloading.Visible = false;
      this.panelDownloadDone.Visible = true;
      this.buttonHelp.Enabled = true;
      this.buttonNext.Enabled = true;
      this.buttonNext.Text = "Next >";
      this.buttonCancel.Enabled = true;
      this.timerBlink.Enabled = true;
    }

    private void radioButtonPK2Power_Click(object sender, EventArgs e)
    {
      this.radiobuttonPower();
    }

    private void radioButtonSelfPower_Click(object sender, EventArgs e)
    {
      this.radiobuttonPower();
    }

    private void radiobuttonPower()
    {
      if (this.radioButtonPK2Power.Checked)
      {
        this.checkBoxRowErase.Enabled = false;
        if (this.pickit2PowerRowErase())
          return;
        this.radioButtonPK2Power.Checked = false;
        this.radioButtonSelfPower.Checked = true;
      }
      else
      {
        if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].DebugRowEraseScript > 0)
          this.checkBoxRowErase.Enabled = true;
        else
          this.checkBoxRowErase.Enabled = false;
        if (this.checkBoxRowErase.Enabled && this.checkBoxRowErase.Checked)
        {
          this.labelRowErase.Text = "Row Erase used: Will NOT program Code Protected parts!";
          this.labelRowErase.Visible = true;
        }
        else
          this.labelRowErase.Visible = false;
      }
    }

    private void checkBoxRowErase_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBoxRowErase.Enabled && this.checkBoxRowErase.Checked)
      {
        this.labelRowErase.Text = "Row Erase used: Will NOT program Code Protected parts!";
        this.labelRowErase.Visible = true;
      }
      else
        this.labelRowErase.Visible = false;
    }

    private void timerBlink_Tick(object sender, EventArgs e)
    {
      if (this.panelDownloadDone.Visible)
      {
        ++this.blinkCount;
        if (this.blinkCount > 5)
          this.blinkCount = 0;
        if (this.blinkCount >= 4)
          return;
        if ((this.blinkCount & 1) == 0)
          this.pictureBoxTarget.BackColor = Color.Orange;
        else
          this.pictureBoxTarget.BackColor = SystemColors.ControlText;
      }
      else if (this.radioButtonVErr.Checked)
      {
        ++this.blinkCount;
        if ((this.blinkCount & 1) == 0)
          this.pictureBoxBusy.BackColor = Color.Red;
        else
          this.pictureBoxBusy.BackColor = SystemColors.ControlText;
      }
      else
      {
        int num = 4;
        if (this.radioButton3Blinks.Checked)
          num = 6;
        else if (this.radioButton4Blinks.Checked)
          num = 8;
        if (this.blinkCount++ <= num)
        {
          if ((this.blinkCount & 1) == 0)
            this.pictureBoxBusy.BackColor = Color.Red;
          else
            this.pictureBoxBusy.BackColor = SystemColors.ControlText;
        }
        else
          this.blinkCount = 0;
      }
    }

    private void DialogPK2Go_FormClosing(object sender, FormClosingEventArgs e)
    {
      ProgCommand.ExitLearnMode();
    }

    private void radioButtonVErr_Click(object sender, EventArgs e)
    {
      if (this.radioButtonVErr.Checked)
        this.timerBlink.Interval = 84;
      else
        this.timerBlink.Interval = 200;
    }

    private void buttonHelp_Click(object sender, EventArgs e)
    {
      this.OpenProgToGoGuide();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogPK2Go));
      this.panelIntro = new Panel();
      this.label8 = new Label();
      this.label15 = new Label();
      this.label16 = new Label();
      this.buttonBack = new Button();
      this.buttonNext = new Button();
      this.buttonCancel = new Button();
      this.buttonHelp = new Button();
      this.panelSettings = new Panel();
      this.groupBox2 = new GroupBox();
      this.label14 = new Label();
      this.label4 = new Label();
      this.labelVerify = new Label();
      this.labelMemRegions = new Label();
      this.label11 = new Label();
      this.labelDataProtect = new Label();
      this.label9 = new Label();
      this.labelCodeProtect = new Label();
      this.label10 = new Label();
      this.labelOSCCAL_BandGap = new Label();
      this.labelDataSource = new Label();
      this.label5 = new Label();
      this.labelPartNumber = new Label();
      this.label3 = new Label();
      this.groupBox1 = new GroupBox();
      this.label2 = new Label();
      this.labelRowErase = new Label();
      this.checkBoxRowErase = new CheckBox();
      this.radioButtonPK2Power = new RadioButton();
      this.radioButtonSelfPower = new RadioButton();
      this.label1 = new Label();
      this.panelDownload = new Panel();
      this.label7 = new Label();
      this.groupBox3 = new GroupBox();
      this.labelSourceSmmry = new Label();
      this.labelTargetPowerSmmry = new Label();
      this.label12 = new Label();
      this.labelVDDMin = new Label();
      this.labelPNsmmry = new Label();
      this.label6 = new Label();
      this.labelMemRegionsSmmry = new Label();
      this.labelVPP1stSmmry = new Label();
      this.labelVerifySmmry = new Label();
      this.labelFastProgSmmry = new Label();
      this.labelMCLRHoldSmmry = new Label();
      this.panelDownloading = new Panel();
      this.labelDOWNLOADING = new Label();
      this.panelDownloadDone = new Panel();
      this.label13 = new Label();
      this.label17 = new Label();
      this.timerBlink = new Timer(this.components);
      this.pictureBoxTarget = new PictureBox();
      this.label18 = new Label();
      this.label19 = new Label();
      this.label20 = new Label();
      this.panelErrors = new Panel();
      this.label21 = new Label();
      this.label22 = new Label();
      this.pictureBoxBusy = new PictureBox();
      this.label23 = new Label();
      this.label24 = new Label();
      this.radioButtonVErr = new RadioButton();
      this.radioButton2Blinks = new RadioButton();
      this.radioButton3Blinks = new RadioButton();
      this.radioButton4Blinks = new RadioButton();
      this.label25 = new Label();
      this.label26 = new Label();
      this.label27 = new Label();
      this.label28 = new Label();
      this.label29 = new Label();
      this.label256K = new Label();
      this.panelIntro.SuspendLayout();
      this.panelSettings.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.panelDownload.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.panelDownloading.SuspendLayout();
      this.panelDownloadDone.SuspendLayout();
      this.pictureBoxTarget.BeginInit();
      this.panelErrors.SuspendLayout();
      this.pictureBoxBusy.BeginInit();
      this.SuspendLayout();
      this.panelIntro.Controls.Add((Control) this.label256K);
      this.panelIntro.Controls.Add((Control) this.label8);
      this.panelIntro.Controls.Add((Control) this.label15);
      this.panelIntro.Controls.Add((Control) this.label16);
      this.panelIntro.Location = new Point(12, 12);
      this.panelIntro.Name = "panelIntro";
      this.panelIntro.Size = new Size(351, 331);
      this.panelIntro.TabIndex = 0;
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(69, 31);
      this.label8.Name = "label8";
      this.label8.Size = new Size(213, 19);
      this.label8.TabIndex = 5;
      this.label8.Text = "Programmer-To-Go Wizard";
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(29, 90);
      this.label15.Name = "label15";
      this.label15.Size = new Size(290, 195);
      this.label15.TabIndex = 4;
      this.label15.Text = componentResourceManager.GetString("label15.Text");
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(81, 12);
      this.label16.Name = "label16";
      this.label16.Size = new Size(188, 19);
      this.label16.TabIndex = 2;
      this.label16.Text = "Welcome to the MASTER-PROG";
      this.buttonBack.Enabled = false;
      this.buttonBack.Location = new Point(102, 350);
      this.buttonBack.Name = "buttonBack";
      this.buttonBack.Size = new Size(82, 22);
      this.buttonBack.TabIndex = 7;
      this.buttonBack.Text = "< Back";
      this.buttonBack.UseVisualStyleBackColor = true;
      this.buttonBack.Click += new EventHandler(this.buttonBack_Click);
      this.buttonNext.Location = new Point(192, 350);
      this.buttonNext.Name = "buttonNext";
      this.buttonNext.Size = new Size(82, 22);
      this.buttonNext.TabIndex = 6;
      this.buttonNext.Text = "Next >";
      this.buttonNext.UseVisualStyleBackColor = true;
      this.buttonNext.Click += new EventHandler(this.buttonNext_Click);
      this.buttonCancel.Location = new Point(282, 350);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(82, 22);
      this.buttonCancel.TabIndex = 5;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.buttonHelp.Location = new Point(12, 350);
      this.buttonHelp.Name = "buttonHelp";
      this.buttonHelp.Size = new Size(82, 22);
      this.buttonHelp.TabIndex = 6;
      this.buttonHelp.Text = "Help";
      this.buttonHelp.UseVisualStyleBackColor = true;
      this.buttonHelp.Click += new EventHandler(this.buttonHelp_Click);
      this.panelSettings.Controls.Add((Control) this.groupBox2);
      this.panelSettings.Controls.Add((Control) this.groupBox1);
      this.panelSettings.Controls.Add((Control) this.label1);
      this.panelSettings.Location = new Point(12, 12);
      this.panelSettings.Name = "panelSettings";
      this.panelSettings.Size = new Size(351, 331);
      this.panelSettings.TabIndex = 8;
      this.panelSettings.Visible = false;
      this.groupBox2.Controls.Add((Control) this.label14);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.labelVerify);
      this.groupBox2.Controls.Add((Control) this.labelMemRegions);
      this.groupBox2.Controls.Add((Control) this.label11);
      this.groupBox2.Controls.Add((Control) this.labelDataProtect);
      this.groupBox2.Controls.Add((Control) this.label9);
      this.groupBox2.Controls.Add((Control) this.labelCodeProtect);
      this.groupBox2.Controls.Add((Control) this.label10);
      this.groupBox2.Controls.Add((Control) this.labelOSCCAL_BandGap);
      this.groupBox2.Controls.Add((Control) this.labelDataSource);
      this.groupBox2.Controls.Add((Control) this.label5);
      this.groupBox2.Controls.Add((Control) this.labelPartNumber);
      this.groupBox2.Controls.Add((Control) this.label3);
      this.groupBox2.Font = new Font("Arial", 9.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.groupBox2.Location = new Point(12, 34);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(325, 154);
      this.groupBox2.TabIndex = 6;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Buffer Settings";
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label14.Location = new Point(6, 109);
      this.label14.Name = "label14";
      this.label14.Size = new Size(79, 15);
      this.label14.TabIndex = 18;
      this.label14.Text = "Verify Device:";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(59, 135);
      this.label4.Name = "label4";
      this.label4.Size = new Size(198, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Click CANCEL to change buffer settings.\r\n";
      this.labelVerify.AutoSize = true;
      this.labelVerify.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelVerify.Location = new Point(90, 109);
      this.labelVerify.Name = "labelVerify";
      this.labelVerify.Size = new Size(30, 15);
      this.labelVerify.TabIndex = 17;
      this.labelVerify.Text = "Yes";
      this.labelMemRegions.AutoSize = true;
      this.labelMemRegions.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelMemRegions.Location = new Point(115, 94);
      this.labelMemRegions.Name = "labelMemRegions";
      this.labelMemRegions.Size = new Size(151, 15);
      this.labelMemRegions.TabIndex = 12;
      this.labelMemRegions.Text = "Program Entire Device";
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.Location = new Point(5, 94);
      this.label11.Name = "label11";
      this.label11.Size = new Size(104, 15);
      this.label11.TabIndex = 15;
      this.label11.Text = "Memory Regions:";
      this.labelDataProtect.AutoSize = true;
      this.labelDataProtect.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelDataProtect.Location = new Point(251, 79);
      this.labelDataProtect.Name = "labelDataProtect";
      this.labelDataProtect.Size = new Size(25, 15);
      this.labelDataProtect.TabIndex = 14;
      this.labelDataProtect.Text = "NA";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(168, 79);
      this.label9.Name = "label9";
      this.label9.Size = new Size(77, 15);
      this.label9.TabIndex = 12;
      this.label9.Text = "Data Protect:";
      this.labelCodeProtect.AutoSize = true;
      this.labelCodeProtect.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelCodeProtect.Location = new Point(91, 79);
      this.labelCodeProtect.Name = "labelCodeProtect";
      this.labelCodeProtect.Size = new Size(27, 15);
      this.labelCodeProtect.TabIndex = 13;
      this.labelCodeProtect.Text = "ON";
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(5, 79);
      this.label10.Name = "label10";
      this.label10.Size = new Size(80, 15);
      this.label10.TabIndex = 11;
      this.label10.Text = "Code Protect:";
      this.labelOSCCAL_BandGap.AutoSize = true;
      this.labelOSCCAL_BandGap.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.labelOSCCAL_BandGap.Location = new Point(59, 33);
      this.labelOSCCAL_BandGap.Name = "labelOSCCAL_BandGap";
      this.labelOSCCAL_BandGap.Size = new Size(177, 15);
      this.labelOSCCAL_BandGap.TabIndex = 10;
      this.labelOSCCAL_BandGap.Text = "OSCCAL will be preserved.";
      this.labelOSCCAL_BandGap.Visible = false;
      this.labelDataSource.AutoSize = true;
      this.labelDataSource.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelDataSource.Location = new Point(32, 63);
      this.labelDataSource.Name = "labelDataSource";
      this.labelDataSource.Size = new Size(88, 13);
      this.labelDataSource.TabIndex = 8;
      this.labelDataSource.Text = "<DataSource>";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(6, 48);
      this.label5.Name = "label5";
      this.label5.Size = new Size(109, 15);
      this.label5.TabIndex = 7;
      this.label5.Text = "Buffer data source:";
      this.labelPartNumber.AutoSize = true;
      this.labelPartNumber.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelPartNumber.Location = new Point(59, 18);
      this.labelPartNumber.Name = "labelPartNumber";
      this.labelPartNumber.Size = new Size(100, 15);
      this.labelPartNumber.TabIndex = 6;
      this.labelPartNumber.Text = "<PartNumber>";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(6, 18);
      this.label3.Name = "label3";
      this.label3.Size = new Size(47, 15);
      this.label3.TabIndex = 5;
      this.label3.Text = "Device:";
      this.groupBox1.Controls.Add((Control) this.labelVDDMin);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.labelRowErase);
      this.groupBox1.Controls.Add((Control) this.checkBoxRowErase);
      this.groupBox1.Controls.Add((Control) this.radioButtonPK2Power);
      this.groupBox1.Controls.Add((Control) this.radioButtonSelfPower);
      this.groupBox1.Font = new Font("Arial", 9.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.groupBox1.Location = new Point(12, 194);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(325, 137);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Power Settings";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(66, 107);
      this.label2.Name = "label2";
      this.label2.Size = new Size(191, 26);
      this.label2.TabIndex = 5;
      this.label2.Text = "To change MASTER-PROG VDD voltage, click\r\n    CANCEL and adjust the VDD box.\r\n";
      this.labelRowErase.AutoSize = true;
      this.labelRowErase.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelRowErase.ForeColor = Color.OrangeRed;
      this.labelRowErase.Location = new Point(13, 89);
      this.labelRowErase.Name = "labelRowErase";
      this.labelRowErase.Size = new Size(281, 13);
      this.labelRowErase.TabIndex = 11;
      this.labelRowErase.Text = "Row Erase used: Will NOT program Code Protected parts!";
      this.labelRowErase.Visible = false;
      this.checkBoxRowErase.AutoSize = true;
      this.checkBoxRowErase.Enabled = false;
      this.checkBoxRowErase.Font = new Font("Arial", 9.75f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.checkBoxRowErase.Location = new Point(48, 44);
      this.checkBoxRowErase.Name = "checkBoxRowErase";
      this.checkBoxRowErase.Size = new Size(176, 20);
      this.checkBoxRowErase.TabIndex = 2;
      this.checkBoxRowErase.Text = "Use low voltage row erase";
      this.checkBoxRowErase.UseVisualStyleBackColor = true;
      this.checkBoxRowErase.CheckedChanged += new EventHandler(this.checkBoxRowErase_CheckedChanged);
      this.radioButtonPK2Power.AutoSize = true;
      this.radioButtonPK2Power.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.radioButtonPK2Power.Location = new Point(16, 66);
      this.radioButtonPK2Power.Name = "radioButtonPK2Power";
      this.radioButtonPK2Power.Size = new Size(249, 20);
      this.radioButtonPK2Power.TabIndex = 1;
      this.radioButtonPK2Power.TabStop = true;
      this.radioButtonPK2Power.Text = "Power target from MASTER-PROG at 0.0 Volts";
      this.radioButtonPK2Power.UseVisualStyleBackColor = true;
      this.radioButtonPK2Power.Click += new EventHandler(this.radioButtonPK2Power_Click);
      this.radioButtonSelfPower.AutoSize = true;
      this.radioButtonSelfPower.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.radioButtonSelfPower.Location = new Point(16, 21);
      this.radioButtonSelfPower.Name = "radioButtonSelfPower";
      this.radioButtonSelfPower.Size = new Size(216, 20);
      this.radioButtonSelfPower.TabIndex = 0;
      this.radioButtonSelfPower.TabStop = true;
      this.radioButtonSelfPower.Text = "Target has its own power supply.";
      this.radioButtonSelfPower.UseVisualStyleBackColor = true;
      this.radioButtonSelfPower.Click += new EventHandler(this.radioButtonSelfPower_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(90, 12);
      this.label1.Name = "label1";
      this.label1.Size = new Size(171, 19);
      this.label1.TabIndex = 3;
      this.label1.Text = "Programmer Settings";
      this.panelDownload.Controls.Add((Control) this.label7);
      this.panelDownload.Controls.Add((Control) this.groupBox3);
      this.panelDownload.Controls.Add((Control) this.label12);
      this.panelDownload.Location = new Point(12, 12);
      this.panelDownload.Name = "panelDownload";
      this.panelDownload.Size = new Size(351, 331);
      this.panelDownload.TabIndex = 9;
      this.panelDownload.Visible = false;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(70, 239);
      this.label7.Name = "label7";
      this.label7.Size = new Size(212, 45);
      this.label7.TabIndex = 7;
      this.label7.Text = "Click the DOWNLOAD button below to\r\nset up MASTER-PROG for Programmer-To-Go\r\noperation.\r\n";
      this.groupBox3.Controls.Add((Control) this.labelMCLRHoldSmmry);
      this.groupBox3.Controls.Add((Control) this.labelFastProgSmmry);
      this.groupBox3.Controls.Add((Control) this.labelVerifySmmry);
      this.groupBox3.Controls.Add((Control) this.labelVPP1stSmmry);
      this.groupBox3.Controls.Add((Control) this.labelMemRegionsSmmry);
      this.groupBox3.Controls.Add((Control) this.label6);
      this.groupBox3.Controls.Add((Control) this.labelPNsmmry);
      this.groupBox3.Controls.Add((Control) this.labelSourceSmmry);
      this.groupBox3.Controls.Add((Control) this.labelTargetPowerSmmry);
      this.groupBox3.Font = new Font("Arial", 9.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.groupBox3.Location = new Point(12, 34);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(327, 171);
      this.groupBox3.TabIndex = 6;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Download Summary";
      this.labelSourceSmmry.AutoSize = true;
      this.labelSourceSmmry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelSourceSmmry.Location = new Point(6, 58);
      this.labelSourceSmmry.Name = "labelSourceSmmry";
      this.labelSourceSmmry.Size = new Size(88, 13);
      this.labelSourceSmmry.TabIndex = 10;
      this.labelSourceSmmry.Text = "<DataSource>";
      this.labelTargetPowerSmmry.AutoSize = true;
      this.labelTargetPowerSmmry.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelTargetPowerSmmry.Location = new Point(6, 75);
      this.labelTargetPowerSmmry.Name = "labelTargetPowerSmmry";
      this.labelTargetPowerSmmry.Size = new Size(108, 15);
      this.labelTargetPowerSmmry.TabIndex = 7;
      this.labelTargetPowerSmmry.Text = "<Target Power>";
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label12.Location = new Point(81, 12);
      this.label12.Name = "label12";
      this.label12.Size = new Size(168, 19);
      this.label12.TabIndex = 3;
      this.label12.Text = "Download to MASTER-PROG";
      this.labelVDDMin.AutoSize = true;
      this.labelVDDMin.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVDDMin.ForeColor = Color.OrangeRed;
      this.labelVDDMin.Location = new Point(45, 47);
      this.labelVDDMin.Name = "labelVDDMin";
      this.labelVDDMin.Size = new Size(132, 13);
      this.labelVDDMin.TabIndex = 12;
      this.labelVDDMin.Text = "VDD must be >= 0.0 Volts.";
      this.labelVDDMin.Visible = false;
      this.labelPNsmmry.AutoSize = true;
      this.labelPNsmmry.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelPNsmmry.Location = new Point(6, 21);
      this.labelPNsmmry.Name = "labelPNsmmry";
      this.labelPNsmmry.Size = new Size(100, 15);
      this.labelPNsmmry.TabIndex = 11;
      this.labelPNsmmry.Text = "<PartNumber>";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(6, 41);
      this.label6.Name = "label6";
      this.label6.Size = new Size(76, 15);
      this.label6.TabIndex = 12;
      this.label6.Text = "Data source:";
      this.labelMemRegionsSmmry.AutoSize = true;
      this.labelMemRegionsSmmry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelMemRegionsSmmry.Location = new Point(6, 94);
      this.labelMemRegionsSmmry.Name = "labelMemRegionsSmmry";
      this.labelMemRegionsSmmry.Size = new Size(134, 13);
      this.labelMemRegionsSmmry.TabIndex = 13;
      this.labelMemRegionsSmmry.Text = "<MemRegions CP-DP>";
      this.labelVPP1stSmmry.AutoSize = true;
      this.labelVPP1stSmmry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelVPP1stSmmry.Location = new Point(6, 107);
      this.labelVPP1stSmmry.Name = "labelVPP1stSmmry";
      this.labelVPP1stSmmry.Size = new Size(62, 13);
      this.labelVPP1stSmmry.TabIndex = 14;
      this.labelVPP1stSmmry.Text = "<VPP1st>";
      this.labelVerifySmmry.AutoSize = true;
      this.labelVerifySmmry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelVerifySmmry.Location = new Point(6, 120);
      this.labelVerifySmmry.Name = "labelVerifySmmry";
      this.labelVerifySmmry.Size = new Size(53, 13);
      this.labelVerifySmmry.TabIndex = 15;
      this.labelVerifySmmry.Text = "<Verify>";
      this.labelFastProgSmmry.AutoSize = true;
      this.labelFastProgSmmry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelFastProgSmmry.Location = new Point(6, 133);
      this.labelFastProgSmmry.Name = "labelFastProgSmmry";
      this.labelFastProgSmmry.Size = new Size(117, 13);
      this.labelFastProgSmmry.TabIndex = 16;
      this.labelFastProgSmmry.Text = "<FastProgramming>";
      this.labelMCLRHoldSmmry.AutoSize = true;
      this.labelMCLRHoldSmmry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelMCLRHoldSmmry.Location = new Point(6, 146);
      this.labelMCLRHoldSmmry.Name = "labelMCLRHoldSmmry";
      this.labelMCLRHoldSmmry.Size = new Size(81, 13);
      this.labelMCLRHoldSmmry.TabIndex = 17;
      this.labelMCLRHoldSmmry.Text = "<MCLRHold>";
      this.panelDownloading.Controls.Add((Control) this.labelDOWNLOADING);
      this.panelDownloading.Location = new Point(12, 12);
      this.panelDownloading.Name = "panelDownloading";
      this.panelDownloading.Size = new Size(351, 331);
      this.panelDownloading.TabIndex = 6;
      this.panelDownloading.Visible = false;
      this.labelDOWNLOADING.AutoSize = true;
      this.labelDOWNLOADING.Font = new Font("Arial", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelDOWNLOADING.Location = new Point(72, 153);
      this.labelDOWNLOADING.Name = "labelDOWNLOADING";
      this.labelDOWNLOADING.Size = new Size(206, 24);
      this.labelDOWNLOADING.TabIndex = 2;
      this.labelDOWNLOADING.Text = "Downloading Now...";
      this.panelDownloadDone.Controls.Add((Control) this.label20);
      this.panelDownloadDone.Controls.Add((Control) this.label19);
      this.panelDownloadDone.Controls.Add((Control) this.label18);
      this.panelDownloadDone.Controls.Add((Control) this.pictureBoxTarget);
      this.panelDownloadDone.Controls.Add((Control) this.label17);
      this.panelDownloadDone.Controls.Add((Control) this.label13);
      this.panelDownloadDone.Location = new Point(12, 12);
      this.panelDownloadDone.Name = "panelDownloadDone";
      this.panelDownloadDone.Size = new Size(351, 331);
      this.panelDownloadDone.TabIndex = 10;
      this.panelDownloadDone.Visible = false;
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label13.Location = new Point(75, 15);
      this.label13.Name = "label13";
      this.label13.Size = new Size(201, 22);
      this.label13.TabIndex = 2;
      this.label13.Text = "Download Complete!";
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(17, 62);
      this.label17.Name = "label17";
      this.label17.Size = new Size(323, 48);
      this.label17.TabIndex = 3;
      this.label17.Text = "The MASTER-PROG unit will indicate it's in Programmer-To-Go\r\nmode and ready to program by blinking the \"Target\" \r\nLED twice in succession:";
      this.timerBlink.Interval = 250;
      this.timerBlink.Tick += new EventHandler(this.timerBlink_Tick);
      this.pictureBoxTarget.BackColor = SystemColors.ControlText;
      this.pictureBoxTarget.Location = new Point(73, 125);
      this.pictureBoxTarget.Name = "pictureBoxTarget";
      this.pictureBoxTarget.Size = new Size(15, 15);
      this.pictureBoxTarget.TabIndex = 4;
      this.pictureBoxTarget.TabStop = false;
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(101, 125);
      this.label18.Name = "label18";
      this.label18.Size = new Size(48, 15);
      this.label18.TabIndex = 6;
      this.label18.Text = "Target";
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Arial", 9.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label19.Location = new Point(16, 159);
      this.label19.Name = "label19";
      this.label19.Size = new Size(230, 16);
      this.label19.TabIndex = 7;
      this.label19.Text = "Remove the MASTER-PROG from USB now.";
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label20.Location = new Point(16, 175);
      this.label20.Name = "label20";
      this.label20.Size = new Size(332, 144);
      this.label20.TabIndex = 8;
      this.label20.Text = componentResourceManager.GetString("label20.Text");
      this.panelErrors.Controls.Add((Control) this.label29);
      this.panelErrors.Controls.Add((Control) this.label28);
      this.panelErrors.Controls.Add((Control) this.label27);
      this.panelErrors.Controls.Add((Control) this.label26);
      this.panelErrors.Controls.Add((Control) this.label25);
      this.panelErrors.Controls.Add((Control) this.radioButton4Blinks);
      this.panelErrors.Controls.Add((Control) this.radioButton3Blinks);
      this.panelErrors.Controls.Add((Control) this.radioButton2Blinks);
      this.panelErrors.Controls.Add((Control) this.radioButtonVErr);
      this.panelErrors.Controls.Add((Control) this.label24);
      this.panelErrors.Controls.Add((Control) this.label23);
      this.panelErrors.Controls.Add((Control) this.pictureBoxBusy);
      this.panelErrors.Controls.Add((Control) this.label22);
      this.panelErrors.Controls.Add((Control) this.label21);
      this.panelErrors.Location = new Point(12, 12);
      this.panelErrors.Name = "panelErrors";
      this.panelErrors.Size = new Size(351, 331);
      this.panelErrors.TabIndex = 11;
      this.panelErrors.Visible = false;
      this.label21.AutoSize = true;
      this.label21.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label21.Location = new Point(69, 12);
      this.label21.Name = "label21";
      this.label21.Size = new Size(226, 19);
      this.label21.TabIndex = 4;
      this.label21.Text = "Programming && Error Codes";
      this.label22.AutoSize = true;
      this.label22.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label22.Location = new Point(25, 33);
      this.label22.Name = "label22";
      this.label22.Size = new Size(287, 150);
      this.label22.TabIndex = 8;
      this.label22.Text = componentResourceManager.GetString("label22.Text");
      this.pictureBoxBusy.BackColor = SystemColors.ControlText;
      this.pictureBoxBusy.Location = new Point(107, 194);
      this.pictureBoxBusy.Name = "pictureBoxBusy";
      this.pictureBoxBusy.Size = new Size(15, 15);
      this.pictureBoxBusy.TabIndex = 9;
      this.pictureBoxBusy.TabStop = false;
      this.label23.AutoSize = true;
      this.label23.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label23.Location = new Point(138, 194);
      this.label23.Name = "label23";
      this.label23.Size = new Size(37, 15);
      this.label23.TabIndex = 10;
      this.label23.Text = "Busy";
      this.label24.AutoSize = true;
      this.label24.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.label24.Location = new Point(25, 212);
      this.label24.Name = "label24";
      this.label24.Size = new Size(188, 15);
      this.label24.TabIndex = 11;
      this.label24.Text = "Error Codes (Select for example):";
      this.radioButtonVErr.AutoSize = true;
      this.radioButtonVErr.Checked = true;
      this.radioButtonVErr.Location = new Point(28, 230);
      this.radioButtonVErr.Name = "radioButtonVErr";
      this.radioButtonVErr.Size = new Size(85, 17);
      this.radioButtonVErr.TabIndex = 12;
      this.radioButtonVErr.TabStop = true;
      this.radioButtonVErr.Text = "Fast Blinking";
      this.radioButtonVErr.UseVisualStyleBackColor = true;
      this.radioButtonVErr.Click += new EventHandler(this.radioButtonVErr_Click);
      this.radioButton2Blinks.AutoSize = true;
      this.radioButton2Blinks.Location = new Point(28, 264);
      this.radioButton2Blinks.Name = "radioButton2Blinks";
      this.radioButton2Blinks.Size = new Size(62, 17);
      this.radioButton2Blinks.TabIndex = 13;
      this.radioButton2Blinks.Text = "2 Blinks";
      this.radioButton2Blinks.UseVisualStyleBackColor = true;
      this.radioButton2Blinks.Click += new EventHandler(this.radioButtonVErr_Click);
      this.radioButton3Blinks.AutoSize = true;
      this.radioButton3Blinks.Location = new Point(186, 230);
      this.radioButton3Blinks.Name = "radioButton3Blinks";
      this.radioButton3Blinks.Size = new Size(62, 17);
      this.radioButton3Blinks.TabIndex = 14;
      this.radioButton3Blinks.Text = "3 Blinks";
      this.radioButton3Blinks.UseVisualStyleBackColor = true;
      this.radioButton3Blinks.Click += new EventHandler(this.radioButtonVErr_Click);
      this.radioButton4Blinks.AutoSize = true;
      this.radioButton4Blinks.Location = new Point(186, 264);
      this.radioButton4Blinks.Name = "radioButton4Blinks";
      this.radioButton4Blinks.Size = new Size(62, 17);
      this.radioButton4Blinks.TabIndex = 15;
      this.radioButton4Blinks.Text = "4 Blinks";
      this.radioButton4Blinks.UseVisualStyleBackColor = true;
      this.radioButton4Blinks.Click += new EventHandler(this.radioButtonVErr_Click);
      this.label25.AutoSize = true;
      this.label25.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label25.Location = new Point(48, 246);
      this.label25.Name = "label25";
      this.label25.Size = new Size(88, 15);
      this.label25.TabIndex = 16;
      this.label25.Text = "VDD/VPP Error";
      this.label26.AutoSize = true;
      this.label26.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label26.Location = new Point(47, 280);
      this.label26.Name = "label26";
      this.label26.Size = new Size(89, 15);
      this.label26.TabIndex = 17;
      this.label26.Text = "Device ID Error";
      this.label27.AutoSize = true;
      this.label27.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label27.Location = new Point(206, 246);
      this.label27.Name = "label27";
      this.label27.Size = new Size(73, 15);
      this.label27.TabIndex = 18;
      this.label27.Text = "Error al Verificar!";
      this.label28.AutoSize = true;
      this.label28.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label28.Location = new Point(206, 280);
      this.label28.Name = "label28";
      this.label28.Size = new Size(78, 15);
      this.label28.TabIndex = 19;
      this.label28.Text = "Error del Hardware!";
      this.label29.AutoSize = true;
      this.label29.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label29.Location = new Point(28, 312);
      this.label29.Name = "label29";
      this.label29.Size = new Size(294, 13);
      this.label29.TabIndex = 19;
      this.label29.Text = "Click EXIT to close Wizard.  Click HELP for more information.\r\n";
      this.label256K.AutoSize = true;
      this.label256K.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label256K.Location = new Point(156, 306);
      this.label256K.Name = "label256K";
      this.label256K.Size = new Size(196, 13);
      this.label256K.TabIndex = 6;
      this.label256K.Text = "256K MASTER-PROG upgrade support enabled.\r\n";
      this.label256K.Visible = false;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(374, 380);
      this.Controls.Add((Control) this.panelErrors);
      this.Controls.Add((Control) this.panelDownloadDone);
      this.Controls.Add((Control) this.panelDownloading);
      this.Controls.Add((Control) this.panelDownload);
      this.Controls.Add((Control) this.panelSettings);
      this.Controls.Add((Control) this.buttonHelp);
      this.Controls.Add((Control) this.buttonBack);
      this.Controls.Add((Control) this.panelIntro);
      this.Controls.Add((Control) this.buttonNext);
      this.Controls.Add((Control) this.buttonCancel);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogPK2Go";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Programmer-To-Go Wizard";
      this.FormClosing += new FormClosingEventHandler(this.DialogPK2Go_FormClosing);
      this.panelIntro.ResumeLayout(false);
      this.panelIntro.PerformLayout();
      this.panelSettings.ResumeLayout(false);
      this.panelSettings.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panelDownload.ResumeLayout(false);
      this.panelDownload.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.panelDownloading.ResumeLayout(false);
      this.panelDownloading.PerformLayout();
      this.panelDownloadDone.ResumeLayout(false);
      this.panelDownloadDone.PerformLayout();
      this.pictureBoxTarget.EndInit();
      this.panelErrors.ResumeLayout(false);
      this.panelErrors.PerformLayout();
      this.pictureBoxBusy.EndInit();
      this.ResumeLayout(false);
    }
  }
}
