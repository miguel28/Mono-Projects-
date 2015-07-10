// Type: SysProgUSB.DialogTroubleshoot
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogTroubleshoot : Form
  {
    private IContainer components;
    private Panel panelIntro;
    private Label labelIntroTitle;
    private Panel panelStep1VDDExt;
    private Button buttonStep1Recheck;
    private Label labelStep1ExtTitle;
    private Button buttonCancel;
    private Button buttonNext;
    private Button buttonBack;
    private Label labelIntroText1;
    private Label labelVoltageOnVDD;
    private Label labelVoltageOnVDD2;
    private NumericUpDown numericUpDown1;
    private Label labelTestVDD;
    private Panel panelStep1VDDTest;
    private Label labelStep1Title;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private Button buttonVDDOn;
    private Label labelReadVDD;
    private Label label1;
    private Label labelGood;
    private Label labelVDDShort;
    private Label labelVDDLow;
    private Panel panelCautionVDD;
    private Label label2;
    private Label label3;
    private Panel panelStep2VPP;
    private PictureBox pictureBox3;
    private Label label6;
    private Label label5;
    private Label labelStep2FamilyVPP;
    private Button buttonTestVPP;
    private Button buttonMCLR;
    private Label labelVPPVDDShort;
    private Label labelVPPResults;
    private Label labelReadVPP;
    private Label labelVPPShort;
    private Label labelVPPLow;
    private Label labelVPPPass;
    private Label labelVPPMCLR;
    private Panel panelPGCPGD;
    private PictureBox pictureBox5;
    private PictureBox pictureBox4;
    private Label label8;
    private RadioButton radioButtonPGCLow;
    private RadioButton radioButtonPGCHigh;
    private GroupBox groupBoxPGD;
    private RadioButton radioButtonPGDLow;
    private RadioButton radioButtonPGDHigh;
    private GroupBox groupBoxPGC;
    private Label label4;
    private Label labelPGxOScope;
    private Label labelPGxVDDShort;
    private Label label9;
    private Label label7;
    private Label labelVPPMCLROff;
    private Button buttonMCLROff;
    private RadioButton radioButtonPGDToggle;
    private System.Windows.Forms.Timer timerPGxToggle;
    private RadioButton radioButtonPGCToggle;
    private Label label10;
    private Label label11;
    private Label label12;

    public DialogTroubleshoot()
    {
      this.InitializeComponent();
      ProgCommand.VddOff();
      ProgCommand.SendScript(new byte[2]
      {
        (byte) 243,
        (byte) 3
      });
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
        this.testVDD();
      }
      else if (this.panelStep1VDDTest.Visible)
      {
        ProgCommand.VddOff();
        this.panelStep1VDDTest.Visible = false;
        this.panelCautionVDD.Visible = true;
      }
      else if (this.panelStep1VDDExt.Visible)
      {
        ProgCommand.VddOff();
        this.panelStep1VDDExt.Visible = false;
        this.panelStep2VPP.Visible = true;
        this.testVPP_Enter();
      }
      else if (this.panelCautionVDD.Visible)
      {
        this.panelCautionVDD.Visible = false;
        this.panelStep2VPP.Visible = true;
        this.testVPP_Enter();
      }
      else
      {
        if (!this.panelStep2VPP.Visible)
          return;
        this.panelStep2VPP.Visible = false;
        this.panelPGCPGD.Visible = true;
        this.buttonNext.Enabled = false;
        this.testPGCPGDEnter();
      }
    }

    private void buttonBack_Click(object sender, EventArgs e)
    {
      if (this.panelStep1VDDExt.Visible || this.panelStep1VDDTest.Visible)
      {
        ProgCommand.VddOff();
        this.panelIntro.Visible = true;
        this.buttonBack.Enabled = false;
        this.panelStep1VDDTest.Visible = false;
        this.panelStep1VDDExt.Visible = false;
      }
      else if (this.panelCautionVDD.Visible || this.panelStep2VPP.Visible)
      {
        this.panelCautionVDD.Visible = false;
        this.panelStep2VPP.Visible = false;
        this.testVDD();
      }
      else
      {
        if (!this.panelPGCPGD.Visible)
          return;
        this.panelPGCPGD.Visible = false;
        this.panelStep2VPP.Visible = true;
        this.buttonNext.Enabled = true;
        this.testVPP_Enter();
      }
    }

    private void testVDD()
    {
      float vdd = 0.0f;
      float vpp = 0.0f;
      ProgCommand.SendScript(new byte[4]
      {
        (byte) 250,
        (byte) 248,
        (byte) 254,
        (byte) 253
      });
      Thread.Sleep(250);
      if (ProgCommand.CheckTargetPower(ref vdd, ref vpp) == Constants.PICkit2PWR.selfpowered)
      {
        this.panelStep1VDDExt.Visible = true;
        this.labelVoltageOnVDD.Text = "An external voltage was detected\non the VDD pin at " + string.Format("{0:0.0} Volts.", (object) vdd);
      }
      else
      {
        this.panelStep1VDDExt.Visible = false;
        this.panelStep1VDDTest.Visible = true;
        this.labelGood.Visible = false;
        this.labelVDDShort.Visible = false;
        this.labelVDDLow.Visible = false;
        this.labelReadVDD.Text = "";
        this.numericUpDown1.Maximum = (Decimal) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddMax;
        this.numericUpDown1.Minimum = (Decimal) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddMin;
        if ((double) (float) this.numericUpDown1.Maximum > 4.5)
          this.numericUpDown1.Value = new Decimal(45, 0, 0, false, (byte) 1);
        else
          this.numericUpDown1.Value = this.numericUpDown1.Maximum;
      }
    }

    private void buttonStep1Recheck_Click(object sender, EventArgs e)
    {
      this.testVDD();
    }

    private void buttonVDDOn_Click(object sender, EventArgs e)
    {
      float vdd = 0.0f;
      float vpp = 0.0f;
      this.labelGood.Visible = false;
      this.labelVDDShort.Visible = false;
      this.labelVDDLow.Visible = false;
      this.labelReadVDD.Text = "";
      if (!ProgCommand.SetVDDVoltage((float) this.numericUpDown1.Value, 0.45f))
        return;
      ProgCommand.ForcePICkitPowered();
      if (!ProgCommand.VddOn())
        return;
      if (ProgCommand.PowerStatus() != Constants.PICkit2PWR.vdd_on)
      {
        this.labelVDDShort.Visible = true;
        this.labelReadVDD.Text = "Short!";
      }
      else
      {
        if (!ProgCommand.ReadPICkitVoltages(ref vdd, ref vpp))
          return;
        this.labelReadVDD.Text = string.Format("{0:0.0} V", (object) vdd);
        float num = (float) this.numericUpDown1.Value;
        if ((double) num > 4.59999990463257)
          num = 4.6f;
        if ((double) num - (double) vdd > 0.200000002980232)
          this.labelVDDLow.Visible = true;
        else
          this.labelGood.Visible = true;
      }
    }

    private void testVPP_Enter()
    {
      ProgCommand.VddOff();
      ProgCommand.SendScript(new byte[2]
      {
        (byte) 243,
        (byte) 3
      });
      this.timerPGxToggle.Enabled = false;
      this.buttonCancel.Text = "Cancel";
      if ((double) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].Vpp < 1.0)
        this.labelStep2FamilyVPP.Text = "1) VPP for this family: " + string.Format("{0:0.0}V (=VDD)", (object) this.numericUpDown1.Value);
      else
        this.labelStep2FamilyVPP.Text = "1) VPP for this family: " + string.Format("{0:0.0} Volts.", (object) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].Vpp);
      this.labelReadVPP.Text = "";
      this.labelVPPLow.Visible = false;
      this.labelVPPMCLR.Visible = false;
      this.labelVPPMCLROff.Visible = false;
      this.labelVPPPass.Visible = false;
      this.labelVPPShort.Visible = false;
      this.labelVPPVDDShort.Visible = false;
    }

    private void buttonTestVPP_Click(object sender, EventArgs e)
    {
      float vdd = 0.0f;
      float vpp = 0.0f;
      this.labelVPPLow.Visible = false;
      this.labelVPPMCLR.Visible = false;
      this.labelVPPMCLROff.Visible = false;
      this.labelVPPPass.Visible = false;
      this.labelVPPShort.Visible = false;
      this.labelVPPVDDShort.Visible = false;
      this.labelReadVPP.Text = "";
      Thread.Sleep(250);
      if (ProgCommand.CheckTargetPower(ref vdd, ref vpp) == Constants.PICkit2PWR.selfpowered)
      {
        ProgCommand.VddOff();
      }
      else
      {
        ProgCommand.SetVDDVoltage((float) this.numericUpDown1.Value, 0.85f);
        ProgCommand.VddOn();
      }
      float voltage = (double) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].Vpp <= 1.0 ? (float) this.numericUpDown1.Value : ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].Vpp;
      ProgCommand.SetVppVoltage(voltage, 0.5f);
      ProgCommand.SendScript(new byte[8]
      {
        (byte) 250,
        (byte) 249,
        (byte) 232,
        (byte) 30,
        (byte) 246,
        (byte) 251,
        (byte) 232,
        (byte) 20
      });
      switch (ProgCommand.PowerStatus())
      {
        case Constants.PICkit2PWR.vdderror:
        case Constants.PICkit2PWR.vddvpperrors:
          this.labelVPPVDDShort.Visible = true;
          break;
        case Constants.PICkit2PWR.vpperror:
          this.labelVPPShort.Visible = true;
          this.labelReadVPP.Text = "Short!";
          break;
        case Constants.PICkit2PWR.no_response:
          break;
        default:
          if (!ProgCommand.ReadPICkitVoltages(ref vdd, ref vpp))
            break;
          this.labelReadVPP.Text = string.Format("{0:0.0} V", (object) vpp);
          if ((double) voltage - (double) vpp > 0.300000011920929)
          {
            this.labelVPPLow.Visible = true;
            break;
          }
          else
          {
            this.labelVPPPass.Visible = true;
            break;
          }
      }
    }

    private void buttonMCLR_Click(object sender, EventArgs e)
    {
      this.labelVPPLow.Visible = false;
      this.labelVPPMCLR.Visible = true;
      this.labelVPPMCLROff.Visible = false;
      this.labelVPPPass.Visible = false;
      this.labelVPPShort.Visible = false;
      this.labelVPPVDDShort.Visible = false;
      this.labelReadVPP.Text = "/MCLR On";
      ProgCommand.SendScript(new byte[3]
      {
        (byte) 250,
        (byte) 248,
        (byte) 247
      });
    }

    private void buttonMCLROff_Click(object sender, EventArgs e)
    {
      this.labelVPPLow.Visible = false;
      this.labelVPPMCLR.Visible = false;
      this.labelVPPMCLROff.Visible = true;
      this.labelVPPPass.Visible = false;
      this.labelVPPShort.Visible = false;
      this.labelVPPVDDShort.Visible = false;
      this.labelReadVPP.Text = "/MCLR Off";
      ProgCommand.SendScript(new byte[3]
      {
        (byte) 250,
        (byte) 248,
        (byte) 246
      });
    }

    private void testPGCPGDEnter()
    {
      float vdd = 0.0f;
      float vpp = 0.0f;
      byte[] script = new byte[3]
      {
        (byte) 250,
        (byte) 248,
        (byte) 247
      };
      ProgCommand.SendScript(script);
      ProgCommand.VddOff();
      this.buttonCancel.Text = "Finished";
      Thread.Sleep(200);
      if (ProgCommand.CheckTargetPower(ref vdd, ref vpp) == Constants.PICkit2PWR.selfpowered)
      {
        ProgCommand.VddOff();
      }
      else
      {
        ProgCommand.SetVDDVoltage((float) this.numericUpDown1.Value, 0.85f);
        ProgCommand.VddOn();
        Thread.Sleep(50);
      }
      switch (ProgCommand.PowerStatus())
      {
        case Constants.PICkit2PWR.vdderror:
        case Constants.PICkit2PWR.vddvpperrors:
          this.radioButtonPGCHigh.Enabled = false;
          this.radioButtonPGCLow.Enabled = false;
          this.radioButtonPGDHigh.Enabled = false;
          this.radioButtonPGDLow.Enabled = false;
          this.radioButtonPGCToggle.Enabled = false;
          this.radioButtonPGDToggle.Enabled = false;
          this.labelPGxOScope.Visible = false;
          this.labelPGxVDDShort.Visible = true;
          break;
        case Constants.PICkit2PWR.vpperror:
          this.radioButtonPGCHigh.Enabled = false;
          this.radioButtonPGCLow.Enabled = false;
          this.radioButtonPGDHigh.Enabled = false;
          this.radioButtonPGDLow.Enabled = false;
          this.radioButtonPGCToggle.Enabled = false;
          this.radioButtonPGDToggle.Enabled = false;
          this.labelPGxOScope.Visible = false;
          this.labelPGxVDDShort.Visible = true;
          break;
        case Constants.PICkit2PWR.no_response:
          break;
        default:
          this.radioButtonPGCHigh.Enabled = true;
          this.radioButtonPGCLow.Enabled = true;
          this.radioButtonPGDHigh.Enabled = true;
          this.radioButtonPGDLow.Enabled = true;
          this.radioButtonPGCToggle.Enabled = true;
          this.radioButtonPGDToggle.Enabled = true;
          this.labelPGxOScope.Visible = true;
          this.labelPGxVDDShort.Visible = false;
          script[0] = (byte) 243;
          script[1] = (byte) 0;
          script[2] = (byte) 244;
          ProgCommand.SendScript(script);
          this.radioButtonPGDToggle.Checked = false;
          this.radioButtonPGCToggle.Checked = false;
          this.radioButtonPGCHigh.Checked = false;
          this.radioButtonPGCLow.Checked = true;
          this.radioButtonPGDHigh.Checked = false;
          this.radioButtonPGDLow.Checked = true;
          break;
      }
    }

    private void radioButtonPGCHigh_CheckedChanged(object sender, EventArgs e)
    {
      byte[] script = new byte[2];
      if (this.radioButtonPGDToggle.Checked || this.radioButtonPGCToggle.Checked)
        return;
      this.timerPGxToggle.Enabled = false;
      script[0] = (byte) 243;
      script[1] = !this.radioButtonPGCHigh.Checked || !this.radioButtonPGDHigh.Checked ? (!this.radioButtonPGCHigh.Checked ? (!this.radioButtonPGDHigh.Checked ? (byte) 0 : (byte) 8) : (byte) 4) : (byte) 12;
      ProgCommand.SendScript(script);
    }

    private void radioButtonPGDToggle_Click(object sender, EventArgs e)
    {
      this.PGxToggle();
    }

    private void timerPGxToggle_Tick(object sender, EventArgs e)
    {
      this.PGxToggle();
    }

    private void PGxToggle()
    {
      this.timerPGxToggle.Enabled = false;
      byte num1 = (byte) 0;
      byte num2 = (byte) 0;
      if (this.radioButtonPGDToggle.Checked)
        num1 |= (byte) 8;
      if (this.radioButtonPGCToggle.Checked)
        num1 |= (byte) 4;
      if (this.radioButtonPGCHigh.Checked)
      {
        num1 |= (byte) 4;
        num2 |= (byte) 4;
      }
      if (this.radioButtonPGDHigh.Checked)
      {
        num1 |= (byte) 8;
        num2 |= (byte) 8;
      }
      ProgCommand.SendScript(new byte[15]
      {
        (byte) 210,
        (byte) 59,
        (byte) 210,
        (byte) 0,
        (byte) 243,
        num1,
        (byte) 245,
        (byte) 243,
        num2,
        (byte) 233,
        (byte) 5,
        (byte) 0,
        (byte) 221,
        (byte) 8,
        (byte) 244
      });
      this.timerPGxToggle.Enabled = true;
    }

    private void trblshtingFormClosing(object sender, FormClosingEventArgs e)
    {
      this.timerPGxToggle.Enabled = false;
      ProgCommand.SendScript(new byte[5]
      {
        (byte) 250,
        (byte) 246,
        (byte) 248,
        (byte) 243,
        (byte) 3
      });
      ProgCommand.VddOff();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogTroubleshoot));
      this.panelIntro = new Panel();
      this.labelIntroText1 = new Label();
      this.labelIntroTitle = new Label();
      this.panelStep1VDDExt = new Panel();
      this.pictureBox2 = new PictureBox();
      this.labelVoltageOnVDD2 = new Label();
      this.labelVoltageOnVDD = new Label();
      this.buttonStep1Recheck = new Button();
      this.labelStep1ExtTitle = new Label();
      this.buttonCancel = new Button();
      this.buttonNext = new Button();
      this.buttonBack = new Button();
      this.labelTestVDD = new Label();
      this.numericUpDown1 = new NumericUpDown();
      this.panelStep1VDDTest = new Panel();
      this.label11 = new Label();
      this.label12 = new Label();
      this.label10 = new Label();
      this.labelGood = new Label();
      this.label1 = new Label();
      this.labelVDDLow = new Label();
      this.labelVDDShort = new Label();
      this.labelReadVDD = new Label();
      this.buttonVDDOn = new Button();
      this.pictureBox1 = new PictureBox();
      this.labelStep1Title = new Label();
      this.panelCautionVDD = new Panel();
      this.label2 = new Label();
      this.label3 = new Label();
      this.panelStep2VPP = new Panel();
      this.buttonMCLROff = new Button();
      this.labelVPPMCLROff = new Label();
      this.labelVPPPass = new Label();
      this.label9 = new Label();
      this.label7 = new Label();
      this.labelVPPMCLR = new Label();
      this.labelVPPShort = new Label();
      this.labelVPPLow = new Label();
      this.labelVPPVDDShort = new Label();
      this.labelVPPResults = new Label();
      this.buttonMCLR = new Button();
      this.labelReadVPP = new Label();
      this.buttonTestVPP = new Button();
      this.label5 = new Label();
      this.labelStep2FamilyVPP = new Label();
      this.pictureBox3 = new PictureBox();
      this.label6 = new Label();
      this.panelPGCPGD = new Panel();
      this.labelPGxVDDShort = new Label();
      this.labelPGxOScope = new Label();
      this.label4 = new Label();
      this.groupBoxPGD = new GroupBox();
      this.radioButtonPGDToggle = new RadioButton();
      this.radioButtonPGDLow = new RadioButton();
      this.radioButtonPGDHigh = new RadioButton();
      this.pictureBox5 = new PictureBox();
      this.groupBoxPGC = new GroupBox();
      this.radioButtonPGCToggle = new RadioButton();
      this.radioButtonPGCLow = new RadioButton();
      this.radioButtonPGCHigh = new RadioButton();
      this.label8 = new Label();
      this.pictureBox4 = new PictureBox();
      this.timerPGxToggle = new System.Windows.Forms.Timer(this.components);
      this.panelIntro.SuspendLayout();
      this.panelStep1VDDExt.SuspendLayout();
      this.pictureBox2.BeginInit();
      this.numericUpDown1.BeginInit();
      this.panelStep1VDDTest.SuspendLayout();
      this.pictureBox1.BeginInit();
      this.panelCautionVDD.SuspendLayout();
      this.panelStep2VPP.SuspendLayout();
      this.pictureBox3.BeginInit();
      this.panelPGCPGD.SuspendLayout();
      this.groupBoxPGD.SuspendLayout();
      this.pictureBox5.BeginInit();
      this.groupBoxPGC.SuspendLayout();
      this.pictureBox4.BeginInit();
      this.SuspendLayout();
      this.panelIntro.Controls.Add((Control) this.labelIntroText1);
      this.panelIntro.Controls.Add((Control) this.labelIntroTitle);
      this.panelIntro.Location = new Point(16, 15);
      this.panelIntro.Margin = new Padding(4, 4, 4, 4);
      this.panelIntro.Name = "panelIntro";
      this.panelIntro.Size = new Size(413, 295);
      this.panelIntro.TabIndex = 0;
      this.labelIntroText1.AutoSize = true;
      this.labelIntroText1.Location = new Point(16, 42);
      this.labelIntroText1.Margin = new Padding(4, 0, 4, 0);
      this.labelIntroText1.Name = "labelIntroText1";
      this.labelIntroText1.Size = new Size(384, 238);
      this.labelIntroText1.TabIndex = 1;
      this.labelIntroText1.Text = componentResourceManager.GetString("labelIntroText1.Text");
      this.labelIntroTitle.AutoSize = true;
      this.labelIntroTitle.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelIntroTitle.Location = new Point(68, 0);
      this.labelIntroTitle.Margin = new Padding(4, 0, 4, 0);
      this.labelIntroTitle.Name = "labelIntroTitle";
      this.labelIntroTitle.Size = new Size(244, 24);
      this.labelIntroTitle.TabIndex = 0;
      this.labelIntroTitle.Text = "MASTER-PROG Troubleshooting";
      this.panelStep1VDDExt.Controls.Add((Control) this.pictureBox2);
      this.panelStep1VDDExt.Controls.Add((Control) this.labelVoltageOnVDD2);
      this.panelStep1VDDExt.Controls.Add((Control) this.labelVoltageOnVDD);
      this.panelStep1VDDExt.Controls.Add((Control) this.buttonStep1Recheck);
      this.panelStep1VDDExt.Controls.Add((Control) this.labelStep1ExtTitle);
      this.panelStep1VDDExt.Location = new Point(16, 15);
      this.panelStep1VDDExt.Margin = new Padding(4, 4, 4, 4);
      this.panelStep1VDDExt.Name = "panelStep1VDDExt";
      this.panelStep1VDDExt.Size = new Size(413, 295);
      this.panelStep1VDDExt.TabIndex = 1;
      this.panelStep1VDDExt.Visible = false;
      this.pictureBox2.Image = (Image) componentResourceManager.GetObject("pictureBox2.Image");
      this.pictureBox2.Location = new Point(0, 0);
      this.pictureBox2.Margin = new Padding(4, 4, 4, 4);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(78, 116);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox2.TabIndex = 7;
      this.pictureBox2.TabStop = false;
      this.labelVoltageOnVDD2.AutoSize = true;
      this.labelVoltageOnVDD2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVoltageOnVDD2.ForeColor = Color.Red;
      this.labelVoltageOnVDD2.Location = new Point(4, 146);
      this.labelVoltageOnVDD2.Margin = new Padding(4, 0, 4, 0);
      this.labelVoltageOnVDD2.Name = "labelVoltageOnVDD2";
      this.labelVoltageOnVDD2.Size = new Size(349, 80);
      this.labelVoltageOnVDD2.TabIndex = 3;
      this.labelVoltageOnVDD2.Text = "Click \"Next >\" to skip VDD testing.\r\n\r\nTo test VDD, remove the external voltage and\r\nclick \"Recheck\".";
      this.labelVoltageOnVDD.AutoSize = true;
      this.labelVoltageOnVDD.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVoltageOnVDD.ForeColor = Color.Red;
      this.labelVoltageOnVDD.Location = new Point(124, 60);
      this.labelVoltageOnVDD.Margin = new Padding(4, 0, 4, 0);
      this.labelVoltageOnVDD.Name = "labelVoltageOnVDD";
      this.labelVoltageOnVDD.Size = new Size((int) byte.MaxValue, 40);
      this.labelVoltageOnVDD.TabIndex = 2;
      this.labelVoltageOnVDD.Text = "An external voltage was detected\r\non the VDD pin at ";
      this.buttonStep1Recheck.Location = new Point(155, 254);
      this.buttonStep1Recheck.Margin = new Padding(4, 4, 4, 4);
      this.buttonStep1Recheck.Name = "buttonStep1Recheck";
      this.buttonStep1Recheck.Size = new Size(100, 28);
      this.buttonStep1Recheck.TabIndex = 1;
      this.buttonStep1Recheck.Text = "Recheck";
      this.buttonStep1Recheck.UseVisualStyleBackColor = true;
      this.buttonStep1Recheck.Click += new EventHandler(this.buttonStep1Recheck_Click);
      this.labelStep1ExtTitle.AutoEllipsis = true;
      this.labelStep1ExtTitle.AutoSize = true;
      this.labelStep1ExtTitle.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelStep1ExtTitle.Location = new Point(149, 0);
      this.labelStep1ExtTitle.Margin = new Padding(4, 0, 4, 0);
      this.labelStep1ExtTitle.Name = "labelStep1ExtTitle";
      this.labelStep1ExtTitle.Size = new Size(185, 24);
      this.labelStep1ExtTitle.TabIndex = 0;
      this.labelStep1ExtTitle.Text = "Step 1: Verify VDD";
      this.buttonCancel.Location = new Point(329, 318);
      this.buttonCancel.Margin = new Padding(4, 4, 4, 4);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(100, 28);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.buttonNext.Location = new Point(221, 318);
      this.buttonNext.Margin = new Padding(4, 4, 4, 4);
      this.buttonNext.Name = "buttonNext";
      this.buttonNext.Size = new Size(100, 28);
      this.buttonNext.TabIndex = 3;
      this.buttonNext.Text = "Next >";
      this.buttonNext.UseVisualStyleBackColor = true;
      this.buttonNext.Click += new EventHandler(this.buttonNext_Click);
      this.buttonBack.Enabled = false;
      this.buttonBack.Location = new Point(113, 318);
      this.buttonBack.Margin = new Padding(4, 4, 4, 4);
      this.buttonBack.Name = "buttonBack";
      this.buttonBack.Size = new Size(100, 28);
      this.buttonBack.TabIndex = 4;
      this.buttonBack.Text = "< Back";
      this.buttonBack.UseVisualStyleBackColor = true;
      this.buttonBack.Click += new EventHandler(this.buttonBack_Click);
      this.labelTestVDD.AutoSize = true;
      this.labelTestVDD.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelTestVDD.Location = new Point(119, 23);
      this.labelTestVDD.Margin = new Padding(4, 0, 4, 0);
      this.labelTestVDD.Name = "labelTestVDD";
      this.labelTestVDD.Size = new Size(235, 36);
      this.labelTestVDD.TabIndex = 4;
      this.labelTestVDD.Text = "1) Adjust VDD level for your circuit.\r\n(Limits set by active family)";
      this.numericUpDown1.DecimalPlaces = 1;
      this.numericUpDown1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.numericUpDown1.Increment = new Decimal(new int[4]
      {
        1,
        0,
        0,
        65536
      });
      this.numericUpDown1.Location = new Point(23, 150);
      this.numericUpDown1.Margin = new Padding(4, 4, 4, 4);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(80, 26);
      this.numericUpDown1.TabIndex = 5;
      this.numericUpDown1.Value = new Decimal(new int[4]
      {
        45,
        0,
        0,
        65536
      });
      this.panelStep1VDDTest.Controls.Add((Control) this.label11);
      this.panelStep1VDDTest.Controls.Add((Control) this.label12);
      this.panelStep1VDDTest.Controls.Add((Control) this.label10);
      this.panelStep1VDDTest.Controls.Add((Control) this.labelGood);
      this.panelStep1VDDTest.Controls.Add((Control) this.label1);
      this.panelStep1VDDTest.Controls.Add((Control) this.labelVDDLow);
      this.panelStep1VDDTest.Controls.Add((Control) this.labelVDDShort);
      this.panelStep1VDDTest.Controls.Add((Control) this.labelReadVDD);
      this.panelStep1VDDTest.Controls.Add((Control) this.buttonVDDOn);
      this.panelStep1VDDTest.Controls.Add((Control) this.pictureBox1);
      this.panelStep1VDDTest.Controls.Add((Control) this.numericUpDown1);
      this.panelStep1VDDTest.Controls.Add((Control) this.labelStep1Title);
      this.panelStep1VDDTest.Controls.Add((Control) this.labelTestVDD);
      this.panelStep1VDDTest.Location = new Point(16, 15);
      this.panelStep1VDDTest.Margin = new Padding(4, 4, 4, 4);
      this.panelStep1VDDTest.Name = "panelStep1VDDTest";
      this.panelStep1VDDTest.Size = new Size(413, 295);
      this.panelStep1VDDTest.TabIndex = 5;
      this.panelStep1VDDTest.Visible = false;
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = SystemColors.ControlText;
      this.label11.Location = new Point(119, 133);
      this.label11.Margin = new Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new Size(214, 36);
      this.label11.TabIndex = 12;
      this.label11.Text = "The actual voltage is dependent\r\non the host USB Voltage.";
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.Location = new Point(119, 69);
      this.label12.Margin = new Padding(4, 0, 4, 0);
      this.label12.Name = "label12";
      this.label12.Size = new Size(207, 18);
      this.label12.TabIndex = 12;
      this.label12.Text = "2) Click \"Test\" to turn on VDD.";
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.DarkRed;
      this.label10.Location = new Point(119, 96);
      this.label10.Margin = new Padding(4, 0, 4, 0);
      this.label10.Name = "label10";
      this.label10.Size = new Size(228, 36);
      this.label10.TabIndex = 11;
      this.label10.Text = "3) It is important to verify results\r\nusing a volt meter at all VDD pins.";
      this.labelGood.AutoSize = true;
      this.labelGood.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelGood.ForeColor = Color.Blue;
      this.labelGood.Location = new Point(119, 191);
      this.labelGood.Margin = new Padding(4, 0, 4, 0);
      this.labelGood.Name = "labelGood";
      this.labelGood.Size = new Size(253, 90);
      this.labelGood.TabIndex = 10;
      this.labelGood.Text = "Test Passed:\r\nPICkit 2 detected an expected voltage\r\non the VDD pin.  (NOTE: slow rise\r\ntimes can still cause VDD Errors.)\r\nClick \"Next >\" to test VPP.";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(32, 229);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(59, 17);
      this.label1.TabIndex = 9;
      this.label1.Text = "Results:";
      this.labelVDDLow.AutoSize = true;
      this.labelVDDLow.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVDDLow.ForeColor = Color.Red;
      this.labelVDDLow.Location = new Point(119, 191);
      this.labelVDDLow.Margin = new Padding(4, 0, 4, 0);
      this.labelVDDLow.Name = "labelVDDLow";
      this.labelVDDLow.Size = new Size(256, 90);
      this.labelVDDLow.TabIndex = 6;
      this.labelVDDLow.Text = "Test Failed: The VDD result is low.\r\nThe target circuit may be pulling too\r\nmuch current from VDD, or there may\r\nbe too much capacitance on VDD.\r\nTry using an external supply.";
      this.labelVDDShort.AutoSize = true;
      this.labelVDDShort.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVDDShort.ForeColor = Color.Red;
      this.labelVDDShort.Location = new Point(119, 191);
      this.labelVDDShort.Margin = new Padding(4, 0, 4, 0);
      this.labelVDDShort.Name = "labelVDDShort";
      this.labelVDDShort.Size = new Size(248, 90);
      this.labelVDDShort.TabIndex = 6;
      this.labelVDDShort.Text = "Test Failed:\r\nA short was detected, and VDD was \r\nshut off.\r\nIf no target is connected, the MASTER-PROG\r\nmay be damaged.";
      this.labelVDDShort.Visible = false;
      this.labelReadVDD.BorderStyle = BorderStyle.Fixed3D;
      this.labelReadVDD.Location = new Point(23, 254);
      this.labelReadVDD.Margin = new Padding(4, 0, 4, 0);
      this.labelReadVDD.Name = "labelReadVDD";
      this.labelReadVDD.Size = new Size(80, 28);
      this.labelReadVDD.TabIndex = 8;
      this.buttonVDDOn.Location = new Point(23, 185);
      this.buttonVDDOn.Margin = new Padding(4, 4, 4, 4);
      this.buttonVDDOn.Name = "buttonVDDOn";
      this.buttonVDDOn.Size = new Size(80, 28);
      this.buttonVDDOn.TabIndex = 7;
      this.buttonVDDOn.Text = "Test";
      this.buttonVDDOn.UseVisualStyleBackColor = true;
      this.buttonVDDOn.Click += new EventHandler(this.buttonVDDOn_Click);
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(0, 0);
      this.pictureBox1.Margin = new Padding(4, 4, 4, 4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(78, 116);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      this.labelStep1Title.AutoEllipsis = true;
      this.labelStep1Title.AutoSize = true;
      this.labelStep1Title.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelStep1Title.Location = new Point(151, 0);
      this.labelStep1Title.Margin = new Padding(4, 0, 4, 0);
      this.labelStep1Title.Name = "labelStep1Title";
      this.labelStep1Title.Size = new Size(185, 24);
      this.labelStep1Title.TabIndex = 6;
      this.labelStep1Title.Text = "Step 1: Verify VDD";
      this.panelCautionVDD.Controls.Add((Control) this.label2);
      this.panelCautionVDD.Controls.Add((Control) this.label3);
      this.panelCautionVDD.Location = new Point(16, 15);
      this.panelCautionVDD.Margin = new Padding(4, 4, 4, 4);
      this.panelCautionVDD.Name = "panelCautionVDD";
      this.panelCautionVDD.Size = new Size(413, 295);
      this.panelCautionVDD.TabIndex = 2;
      this.panelCautionVDD.Visible = false;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(36, 91);
      this.label2.Margin = new Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(314, 120);
      this.label2.TabIndex = 1;
      this.label2.Text = "VDD will be turned on in all the following\r\ntests at the voltage set in Step 1, unless\r\nan external supply is detected.\r\n\r\nEnsure that VDD is set to an appropriate\r\nvoltage in Step 1.\r\n";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Red;
      this.label3.Location = new Point(125, 33);
      this.label3.Margin = new Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(139, 24);
      this.label3.TabIndex = 0;
      this.label3.Text = "-- CAUTION --";
      this.panelStep2VPP.Controls.Add((Control) this.buttonMCLROff);
      this.panelStep2VPP.Controls.Add((Control) this.labelVPPMCLROff);
      this.panelStep2VPP.Controls.Add((Control) this.labelVPPPass);
      this.panelStep2VPP.Controls.Add((Control) this.label9);
      this.panelStep2VPP.Controls.Add((Control) this.label7);
      this.panelStep2VPP.Controls.Add((Control) this.labelVPPMCLR);
      this.panelStep2VPP.Controls.Add((Control) this.labelVPPShort);
      this.panelStep2VPP.Controls.Add((Control) this.labelVPPLow);
      this.panelStep2VPP.Controls.Add((Control) this.labelVPPVDDShort);
      this.panelStep2VPP.Controls.Add((Control) this.labelVPPResults);
      this.panelStep2VPP.Controls.Add((Control) this.buttonMCLR);
      this.panelStep2VPP.Controls.Add((Control) this.labelReadVPP);
      this.panelStep2VPP.Controls.Add((Control) this.buttonTestVPP);
      this.panelStep2VPP.Controls.Add((Control) this.label5);
      this.panelStep2VPP.Controls.Add((Control) this.labelStep2FamilyVPP);
      this.panelStep2VPP.Controls.Add((Control) this.pictureBox3);
      this.panelStep2VPP.Controls.Add((Control) this.label6);
      this.panelStep2VPP.Location = new Point(16, 15);
      this.panelStep2VPP.Margin = new Padding(4, 4, 4, 4);
      this.panelStep2VPP.Name = "panelStep2VPP";
      this.panelStep2VPP.Size = new Size(413, 295);
      this.panelStep2VPP.TabIndex = 8;
      this.panelStep2VPP.Visible = false;
      this.buttonMCLROff.Location = new Point(8, 261);
      this.buttonMCLROff.Margin = new Padding(4, 4, 4, 4);
      this.buttonMCLROff.Name = "buttonMCLROff";
      this.buttonMCLROff.Size = new Size(96, 28);
      this.buttonMCLROff.TabIndex = 19;
      this.buttonMCLROff.Text = "/MCLR Off";
      this.buttonMCLROff.UseVisualStyleBackColor = true;
      this.buttonMCLROff.Click += new EventHandler(this.buttonMCLROff_Click);
      this.labelVPPMCLROff.AutoSize = true;
      this.labelVPPMCLROff.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVPPMCLROff.ForeColor = Color.Blue;
      this.labelVPPMCLROff.Location = new Point(112, 188);
      this.labelVPPMCLROff.Margin = new Padding(4, 0, 4, 0);
      this.labelVPPMCLROff.Name = "labelVPPMCLROff";
      this.labelVPPMCLROff.Size = new Size(252, 90);
      this.labelVPPMCLROff.TabIndex = 18;
      this.labelVPPMCLROff.Text = "/MCLR released.\r\n\r\nIf /MCLR has a pull-up, it should be at\r\nthe pull-up voltage.  If not, it will be at\r\nan indeterminate voltage.";
      this.labelVPPPass.AutoSize = true;
      this.labelVPPPass.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVPPPass.ForeColor = Color.Blue;
      this.labelVPPPass.Location = new Point(112, 172);
      this.labelVPPPass.Margin = new Padding(4, 0, 4, 0);
      this.labelVPPPass.Name = "labelVPPPass";
      this.labelVPPPass.Size = new Size(252, 90);
      this.labelVPPPass.TabIndex = 14;
      this.labelVPPPass.Text = "Test Passed:\r\n\r\nPlease check the device /MCLR-VPP\r\npin with a voltmeter to verify it sees\r\nthe appropriate VPP voltage.";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(112, 126);
      this.label9.Margin = new Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new Size(267, 36);
      this.label9.TabIndex = 17;
      this.label9.Text = "4) Click \"/MCLR Off\" to check releasing\r\n/MCLR (VPP = tri-state)";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(112, 82);
      this.label7.Margin = new Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new Size(268, 36);
      this.label7.TabIndex = 16;
      this.label7.Text = "3) Click \"/MCLR On\" to check asserting\r\n/MCLR (VPP = 0 V).";
      this.labelVPPMCLR.AutoSize = true;
      this.labelVPPMCLR.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVPPMCLR.ForeColor = Color.Blue;
      this.labelVPPMCLR.Location = new Point(112, 172);
      this.labelVPPMCLR.Margin = new Padding(4, 0, 4, 0);
      this.labelVPPMCLR.Name = "labelVPPMCLR";
      this.labelVPPMCLR.Size = new Size(241, 90);
      this.labelVPPMCLR.TabIndex = 15;
      this.labelVPPMCLR.Text = "/MCLR asserted.\r\n\r\nPlease check the device /MCLR pin\r\nwith a voltmeter to verify the pin\r\nis pulled low.";
      this.labelVPPShort.AutoSize = true;
      this.labelVPPShort.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVPPShort.ForeColor = Color.Red;
      this.labelVPPShort.Location = new Point(112, 172);
      this.labelVPPShort.Margin = new Padding(4, 0, 4, 0);
      this.labelVPPShort.Name = "labelVPPShort";
      this.labelVPPShort.Size = new Size(263, 90);
      this.labelVPPShort.TabIndex = 12;
      this.labelVPPShort.Text = "Test Failed:\r\nShort Detected.\r\n\r\nA short or very heavy load on VPP was\r\ndetected, and VPP was shut off.";
      this.labelVPPLow.AutoSize = true;
      this.labelVPPLow.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVPPLow.ForeColor = Color.Red;
      this.labelVPPLow.Location = new Point(112, 172);
      this.labelVPPLow.Margin = new Padding(4, 0, 4, 0);
      this.labelVPPLow.Name = "labelVPPLow";
      this.labelVPPLow.Size = new Size(238, 108);
      this.labelVPPLow.TabIndex = 13;
      this.labelVPPLow.Text = "Test Failed:\r\nLow VPP detected.\r\n\r\nVPP is not reaching the expected\r\nvoltage.  VPP cannot support more\r\nthan a few mA of current.";
      this.labelVPPVDDShort.AutoSize = true;
      this.labelVPPVDDShort.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVPPVDDShort.ForeColor = Color.Red;
      this.labelVPPVDDShort.Location = new Point(112, 172);
      this.labelVPPVDDShort.Margin = new Padding(4, 0, 4, 0);
      this.labelVPPVDDShort.Name = "labelVPPVDDShort";
      this.labelVPPVDDShort.Size = new Size(253, 90);
      this.labelVPPVDDShort.TabIndex = 11;
      this.labelVPPVDDShort.Text = "Test Failed:\r\nVDD Short Detected.\r\n\r\nVPP cannot be tested if a short exists\r\non VDD.";
      this.labelVPPResults.AutoSize = true;
      this.labelVPPResults.Location = new Point(28, 172);
      this.labelVPPResults.Margin = new Padding(4, 0, 4, 0);
      this.labelVPPResults.Name = "labelVPPResults";
      this.labelVPPResults.Size = new Size(59, 17);
      this.labelVPPResults.TabIndex = 12;
      this.labelVPPResults.Text = "Results:";
      this.buttonMCLR.Location = new Point(8, 225);
      this.buttonMCLR.Margin = new Padding(4, 4, 4, 4);
      this.buttonMCLR.Name = "buttonMCLR";
      this.buttonMCLR.Size = new Size(96, 28);
      this.buttonMCLR.TabIndex = 15;
      this.buttonMCLR.Text = "/MCLR On";
      this.buttonMCLR.UseVisualStyleBackColor = true;
      this.buttonMCLR.Click += new EventHandler(this.buttonMCLR_Click);
      this.labelReadVPP.BorderStyle = BorderStyle.Fixed3D;
      this.labelReadVPP.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelReadVPP.Location = new Point(8, 188);
      this.labelReadVPP.Margin = new Padding(4, 0, 4, 0);
      this.labelReadVPP.Name = "labelReadVPP";
      this.labelReadVPP.Size = new Size(95, 28);
      this.labelReadVPP.TabIndex = 11;
      this.labelReadVPP.TextAlign = ContentAlignment.MiddleCenter;
      this.buttonTestVPP.Location = new Point(8, 142);
      this.buttonTestVPP.Margin = new Padding(4, 4, 4, 4);
      this.buttonTestVPP.Name = "buttonTestVPP";
      this.buttonTestVPP.Size = new Size(96, 28);
      this.buttonTestVPP.TabIndex = 14;
      this.buttonTestVPP.Text = "Test VPP";
      this.buttonTestVPP.UseVisualStyleBackColor = true;
      this.buttonTestVPP.Click += new EventHandler(this.buttonTestVPP_Click);
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(112, 57);
      this.label5.Margin = new Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(283, 18);
      this.label5.TabIndex = 12;
      this.label5.Text = "2) Click \"Test VPP\" to check VPP voltage.";
      this.labelStep2FamilyVPP.AutoSize = true;
      this.labelStep2FamilyVPP.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelStep2FamilyVPP.Location = new Point(112, 30);
      this.labelStep2FamilyVPP.Margin = new Padding(4, 0, 4, 0);
      this.labelStep2FamilyVPP.Name = "labelStep2FamilyVPP";
      this.labelStep2FamilyVPP.Size = new Size(190, 18);
      this.labelStep2FamilyVPP.TabIndex = 11;
      this.labelStep2FamilyVPP.Text = "1) VPP for this family is \r\n";
      this.pictureBox3.Image = (Image) componentResourceManager.GetObject("pictureBox3.Image");
      this.pictureBox3.Location = new Point(0, 0);
      this.pictureBox3.Margin = new Padding(4, 4, 4, 4);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(78, 116);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox3.TabIndex = 7;
      this.pictureBox3.TabStop = false;
      this.label6.AutoEllipsis = true;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(149, 0);
      this.label6.Margin = new Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new Size(183, 24);
      this.label6.TabIndex = 0;
      this.label6.Text = "Step 2: Verify VPP";
      this.panelPGCPGD.Controls.Add((Control) this.labelPGxVDDShort);
      this.panelPGCPGD.Controls.Add((Control) this.labelPGxOScope);
      this.panelPGCPGD.Controls.Add((Control) this.label4);
      this.panelPGCPGD.Controls.Add((Control) this.groupBoxPGD);
      this.panelPGCPGD.Controls.Add((Control) this.pictureBox5);
      this.panelPGCPGD.Controls.Add((Control) this.groupBoxPGC);
      this.panelPGCPGD.Controls.Add((Control) this.label8);
      this.panelPGCPGD.Controls.Add((Control) this.pictureBox4);
      this.panelPGCPGD.Location = new Point(16, 15);
      this.panelPGCPGD.Margin = new Padding(4, 4, 4, 4);
      this.panelPGCPGD.Name = "panelPGCPGD";
      this.panelPGCPGD.Size = new Size(413, 295);
      this.panelPGCPGD.TabIndex = 9;
      this.panelPGCPGD.Visible = false;
      this.labelPGxVDDShort.AutoSize = true;
      this.labelPGxVDDShort.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelPGxVDDShort.ForeColor = Color.Red;
      this.labelPGxVDDShort.Location = new Point(267, 126);
      this.labelPGxVDDShort.Margin = new Padding(4, 0, 4, 0);
      this.labelPGxVDDShort.Name = "labelPGxVDDShort";
      this.labelPGxVDDShort.Size = new Size(102, 90);
      this.labelPGxVDDShort.TabIndex = 18;
      this.labelPGxVDDShort.Text = "VDD Short\r\ndetected!\r\n\r\nMust be\r\ncleared first.";
      this.labelPGxOScope.AutoSize = true;
      this.labelPGxOScope.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelPGxOScope.Location = new Point(267, 105);
      this.labelPGxOScope.Margin = new Padding(4, 0, 4, 0);
      this.labelPGxOScope.Name = "labelPGxOScope";
      this.labelPGxOScope.Size = new Size(130, 162);
      this.labelPGxOScope.TabIndex = 17;
      this.labelPGxOScope.Text = "It is recommended\r\nto use an oscillo-\r\nscope to verify \r\nwaveform edges\r\nare sharp.\r\n\"Toggle 30kHz\"\r\nwill toggle the pin\r\nat approximately\r\n30kHz.\r\n";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(267, 27);
      this.label4.Margin = new Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(130, 72);
      this.label4.TabIndex = 16;
      this.label4.Text = "Verify signal states\r\nat device pins with\r\na volt meter.\r\n\r\n";
      this.groupBoxPGD.Controls.Add((Control) this.radioButtonPGDToggle);
      this.groupBoxPGD.Controls.Add((Control) this.radioButtonPGDLow);
      this.groupBoxPGD.Controls.Add((Control) this.radioButtonPGDHigh);
      this.groupBoxPGD.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.groupBoxPGD.Location = new Point(112, 27);
      this.groupBoxPGD.Margin = new Padding(4, 4, 4, 4);
      this.groupBoxPGD.Name = "groupBoxPGD";
      this.groupBoxPGD.Padding = new Padding(4, 4, 4, 4);
      this.groupBoxPGD.Size = new Size(140, 116);
      this.groupBoxPGD.TabIndex = 13;
      this.groupBoxPGD.TabStop = false;
      this.groupBoxPGD.Text = "PGD / ICSPDAT";
      this.radioButtonPGDToggle.Appearance = Appearance.Button;
      this.radioButtonPGDToggle.AutoSize = true;
      this.radioButtonPGDToggle.Location = new Point(8, 17);
      this.radioButtonPGDToggle.Margin = new Padding(4, 4, 4, 4);
      this.radioButtonPGDToggle.Name = "radioButtonPGDToggle";
      this.radioButtonPGDToggle.Size = new Size(106, 27);
      this.radioButtonPGDToggle.TabIndex = 11;
      this.radioButtonPGDToggle.TabStop = true;
      this.radioButtonPGDToggle.Text = "Toggle 30kHz";
      this.radioButtonPGDToggle.UseVisualStyleBackColor = true;
      this.radioButtonPGDToggle.Click += new EventHandler(this.radioButtonPGDToggle_Click);
      this.radioButtonPGDLow.Appearance = Appearance.Button;
      this.radioButtonPGDLow.Location = new Point(8, 81);
      this.radioButtonPGDLow.Margin = new Padding(4, 4, 4, 4);
      this.radioButtonPGDLow.Name = "radioButtonPGDLow";
      this.radioButtonPGDLow.Size = new Size(112, 28);
      this.radioButtonPGDLow.TabIndex = 10;
      this.radioButtonPGDLow.TabStop = true;
      this.radioButtonPGDLow.Text = "Low (GND)";
      this.radioButtonPGDLow.UseVisualStyleBackColor = true;
      this.radioButtonPGDLow.CheckedChanged += new EventHandler(this.radioButtonPGCHigh_CheckedChanged);
      this.radioButtonPGDHigh.Appearance = Appearance.Button;
      this.radioButtonPGDHigh.Location = new Point(8, 49);
      this.radioButtonPGDHigh.Margin = new Padding(4, 4, 4, 4);
      this.radioButtonPGDHigh.Name = "radioButtonPGDHigh";
      this.radioButtonPGDHigh.Size = new Size(112, 28);
      this.radioButtonPGDHigh.TabIndex = 9;
      this.radioButtonPGDHigh.TabStop = true;
      this.radioButtonPGDHigh.Text = "High (VDD)";
      this.radioButtonPGDHigh.UseVisualStyleBackColor = true;
      this.radioButtonPGDHigh.CheckedChanged += new EventHandler(this.radioButtonPGCHigh_CheckedChanged);
      this.pictureBox5.Image = (Image) componentResourceManager.GetObject("pictureBox5.Image");
      this.pictureBox5.Location = new Point(0, 0);
      this.pictureBox5.Margin = new Padding(4, 4, 4, 4);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(78, 116);
      this.pictureBox5.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox5.TabIndex = 8;
      this.pictureBox5.TabStop = false;
      this.groupBoxPGC.Controls.Add((Control) this.radioButtonPGCToggle);
      this.groupBoxPGC.Controls.Add((Control) this.radioButtonPGCLow);
      this.groupBoxPGC.Controls.Add((Control) this.radioButtonPGCHigh);
      this.groupBoxPGC.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.groupBoxPGC.Location = new Point(112, 153);
      this.groupBoxPGC.Margin = new Padding(4, 4, 4, 4);
      this.groupBoxPGC.Name = "groupBoxPGC";
      this.groupBoxPGC.Padding = new Padding(4, 4, 4, 4);
      this.groupBoxPGC.Size = new Size(140, 116);
      this.groupBoxPGC.TabIndex = 12;
      this.groupBoxPGC.TabStop = false;
      this.groupBoxPGC.Text = "PGC / ICSPCLK";
      this.radioButtonPGCToggle.Appearance = Appearance.Button;
      this.radioButtonPGCToggle.Location = new Point(8, 17);
      this.radioButtonPGCToggle.Margin = new Padding(4, 4, 4, 4);
      this.radioButtonPGCToggle.Name = "radioButtonPGCToggle";
      this.radioButtonPGCToggle.Size = new Size(112, 28);
      this.radioButtonPGCToggle.TabIndex = 12;
      this.radioButtonPGCToggle.TabStop = true;
      this.radioButtonPGCToggle.Text = "Toggle 30kHz";
      this.radioButtonPGCToggle.UseVisualStyleBackColor = true;
      this.radioButtonPGCToggle.Click += new EventHandler(this.radioButtonPGDToggle_Click);
      this.radioButtonPGCLow.Appearance = Appearance.Button;
      this.radioButtonPGCLow.Location = new Point(8, 81);
      this.radioButtonPGCLow.Margin = new Padding(4, 4, 4, 4);
      this.radioButtonPGCLow.Name = "radioButtonPGCLow";
      this.radioButtonPGCLow.Size = new Size(112, 28);
      this.radioButtonPGCLow.TabIndex = 10;
      this.radioButtonPGCLow.TabStop = true;
      this.radioButtonPGCLow.Text = "Low (GND)";
      this.radioButtonPGCLow.UseVisualStyleBackColor = true;
      this.radioButtonPGCLow.CheckedChanged += new EventHandler(this.radioButtonPGCHigh_CheckedChanged);
      this.radioButtonPGCHigh.Appearance = Appearance.Button;
      this.radioButtonPGCHigh.Location = new Point(8, 49);
      this.radioButtonPGCHigh.Margin = new Padding(4, 4, 4, 4);
      this.radioButtonPGCHigh.Name = "radioButtonPGCHigh";
      this.radioButtonPGCHigh.Size = new Size(112, 28);
      this.radioButtonPGCHigh.TabIndex = 9;
      this.radioButtonPGCHigh.TabStop = true;
      this.radioButtonPGCHigh.Text = "High (VDD)";
      this.radioButtonPGCHigh.UseVisualStyleBackColor = true;
      this.radioButtonPGCHigh.CheckedChanged += new EventHandler(this.radioButtonPGCHigh_CheckedChanged);
      this.label8.AutoEllipsis = true;
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(125, 0);
      this.label8.Margin = new Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new Size(254, 24);
      this.label8.TabIndex = 0;
      this.label8.Text = "Step 3: Verify PGC + PGD";
      this.pictureBox4.Image = (Image) componentResourceManager.GetObject("pictureBox4.Image");
      this.pictureBox4.Location = new Point(0, 153);
      this.pictureBox4.Margin = new Padding(4, 4, 4, 4);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(78, 116);
      this.pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox4.TabIndex = 7;
      this.pictureBox4.TabStop = false;
      this.timerPGxToggle.Interval = 450;
      this.timerPGxToggle.Tick += new EventHandler(this.timerPGxToggle_Tick);
      this.AutoScaleDimensions = new SizeF(120f, 120f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = SystemColors.Control;
      this.ClientSize = new Size(445, 354);
      this.Controls.Add((Control) this.panelPGCPGD);
      this.Controls.Add((Control) this.panelStep2VPP);
      this.Controls.Add((Control) this.panelCautionVDD);
      this.Controls.Add((Control) this.panelStep1VDDTest);
      this.Controls.Add((Control) this.buttonBack);
      this.Controls.Add((Control) this.buttonNext);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.panelStep1VDDExt);
      this.Controls.Add((Control) this.panelIntro);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogTroubleshoot";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "MASTER-PROG Troubleshooting";
      this.FormClosing += new FormClosingEventHandler(this.trblshtingFormClosing);
      this.panelIntro.ResumeLayout(false);
      this.panelIntro.PerformLayout();
      this.panelStep1VDDExt.ResumeLayout(false);
      this.panelStep1VDDExt.PerformLayout();
      this.pictureBox2.EndInit();
      this.numericUpDown1.EndInit();
      this.panelStep1VDDTest.ResumeLayout(false);
      this.panelStep1VDDTest.PerformLayout();
      this.pictureBox1.EndInit();
      this.panelCautionVDD.ResumeLayout(false);
      this.panelCautionVDD.PerformLayout();
      this.panelStep2VPP.ResumeLayout(false);
      this.panelStep2VPP.PerformLayout();
      this.pictureBox3.EndInit();
      this.panelPGCPGD.ResumeLayout(false);
      this.panelPGCPGD.PerformLayout();
      this.groupBoxPGD.ResumeLayout(false);
      this.groupBoxPGD.PerformLayout();
      this.pictureBox5.EndInit();
      this.groupBoxPGC.ResumeLayout(false);
      this.pictureBox4.EndInit();
      this.ResumeLayout(false);
    }
  }
}
