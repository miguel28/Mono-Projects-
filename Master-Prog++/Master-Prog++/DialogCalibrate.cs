// Type: SysProgUSB.DialogCalibrate
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogCalibrate : Form
  {
    private IContainer components;
    private Panel panelIntro;
    private Button buttonBack;
    private Button buttonNext;
    private Button buttonCancel;
    private Label label1;
    private Label label2;
    private Button buttonClearUnitID;
    private Button buttonClearCal;
    private Panel panelSetup;
    private PictureBox pictureBox1;
    private Label label3;
    private Label label5;
    private Label label4;
    private Label label6;
    private Panel panelCal;
    private Label label9;
    private PictureBox pictureBox2;
    private Label label10;
    private TextBox textBoxVDD;
    private Label label7;
    private Label labelBadCal;
    private Label labelGoodCal;
    private Button buttonCalibrate;
    private Label label8;
    private Label label11;
    private Panel panelUnitID;
    private Label label12;
    private Label label15;
    private Label label16;
    private Button buttonSetUnitID;
    private TextBox textBoxUnitID;
    private Label labelAssignedID;
    private bool unitIDChanged;

    public DialogCalibrate()
    {
      this.InitializeComponent();
      ProgCommand.VddOff();
      ProgCommand.ForcePICkitPowered();
      this.setupClearButtons();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogCalibrate));
      this.panelIntro = new Panel();
      this.label2 = new Label();
      this.buttonClearUnitID = new Button();
      this.buttonClearCal = new Button();
      this.label1 = new Label();
      this.buttonBack = new Button();
      this.buttonNext = new Button();
      this.buttonCancel = new Button();
      this.panelSetup = new Panel();
      this.label11 = new Label();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.pictureBox1 = new PictureBox();
      this.label3 = new Label();
      this.panelCal = new Panel();
      this.labelBadCal = new Label();
      this.labelGoodCal = new Label();
      this.buttonCalibrate = new Button();
      this.label8 = new Label();
      this.label7 = new Label();
      this.textBoxVDD = new TextBox();
      this.label9 = new Label();
      this.pictureBox2 = new PictureBox();
      this.label10 = new Label();
      this.panelUnitID = new Panel();
      this.labelAssignedID = new Label();
      this.buttonSetUnitID = new Button();
      this.textBoxUnitID = new TextBox();
      this.label12 = new Label();
      this.label15 = new Label();
      this.label16 = new Label();
      this.panelIntro.SuspendLayout();
      this.panelSetup.SuspendLayout();
      this.pictureBox1.BeginInit();
      this.panelCal.SuspendLayout();
      this.pictureBox2.BeginInit();
      this.panelUnitID.SuspendLayout();
      this.SuspendLayout();
      this.panelIntro.Controls.Add((Control) this.label2);
      this.panelIntro.Controls.Add((Control) this.buttonClearUnitID);
      this.panelIntro.Controls.Add((Control) this.buttonClearCal);
      this.panelIntro.Controls.Add((Control) this.label1);
      this.panelIntro.Location = new Point(16, 15);
      this.panelIntro.Margin = new Padding(4, 4, 4, 4);
      this.panelIntro.Name = "panelIntro";
      this.panelIntro.Size = new Size(413, 295);
      this.panelIntro.TabIndex = 0;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(0, 36);
      this.label2.Margin = new Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(411, 221);
      this.label2.TabIndex = 3;
      this.label2.Text = componentResourceManager.GetString("label2.Text");
      this.buttonClearUnitID.Enabled = false;
      this.buttonClearUnitID.Location = new Point(220, 256);
      this.buttonClearUnitID.Margin = new Padding(4, 4, 4, 4);
      this.buttonClearUnitID.Name = "buttonClearUnitID";
      this.buttonClearUnitID.Size = new Size(167, 28);
      this.buttonClearUnitID.TabIndex = 2;
      this.buttonClearUnitID.Text = "Clear Unit ID";
      this.buttonClearUnitID.UseVisualStyleBackColor = true;
      this.buttonClearUnitID.Click += new EventHandler(this.buttonClearUnitID_Click);
      this.buttonClearCal.Enabled = false;
      this.buttonClearCal.Location = new Point(27, 256);
      this.buttonClearCal.Margin = new Padding(4, 4, 4, 4);
      this.buttonClearCal.Name = "buttonClearCal";
      this.buttonClearCal.Size = new Size(167, 28);
      this.buttonClearCal.TabIndex = 1;
      this.buttonClearCal.Text = "Clear Calibration";
      this.buttonClearCal.UseVisualStyleBackColor = true;
      this.buttonClearCal.Click += new EventHandler(this.buttonClearCal_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(79, 0);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(237, 24);
      this.label1.TabIndex = 0;
      this.label1.Text = "MASTER-PROG VDD Calibration";
      this.buttonBack.Enabled = false;
      this.buttonBack.Location = new Point(113, 318);
      this.buttonBack.Margin = new Padding(4, 4, 4, 4);
      this.buttonBack.Name = "buttonBack";
      this.buttonBack.Size = new Size(100, 28);
      this.buttonBack.TabIndex = 1;
      this.buttonBack.Text = "< Back";
      this.buttonBack.UseVisualStyleBackColor = true;
      this.buttonBack.Click += new EventHandler(this.buttonBack_Click);
      this.buttonNext.Location = new Point(221, 318);
      this.buttonNext.Margin = new Padding(4, 4, 4, 4);
      this.buttonNext.Name = "buttonNext";
      this.buttonNext.Size = new Size(100, 28);
      this.buttonNext.TabIndex = 2;
      this.buttonNext.Text = "Next >";
      this.buttonNext.UseVisualStyleBackColor = true;
      this.buttonNext.Click += new EventHandler(this.buttonNext_Click);
      this.buttonCancel.Location = new Point(329, 318);
      this.buttonCancel.Margin = new Padding(4, 4, 4, 4);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(100, 28);
      this.buttonCancel.TabIndex = 3;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.panelSetup.Controls.Add((Control) this.label11);
      this.panelSetup.Controls.Add((Control) this.label6);
      this.panelSetup.Controls.Add((Control) this.label5);
      this.panelSetup.Controls.Add((Control) this.label4);
      this.panelSetup.Controls.Add((Control) this.pictureBox1);
      this.panelSetup.Controls.Add((Control) this.label3);
      this.panelSetup.Location = new Point(16, 15);
      this.panelSetup.Margin = new Padding(4, 4, 4, 4);
      this.panelSetup.Name = "panelSetup";
      this.panelSetup.Size = new Size(413, 295);
      this.panelSetup.TabIndex = 4;
      this.panelSetup.Visible = false;
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.Red;
      this.label11.Location = new Point(5, 277);
      this.label11.Margin = new Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new Size(371, 18);
      this.label11.TabIndex = 6;
      this.label11.Text = "CAUTION: Clicking NEXT will erase existing calibration.";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(5, 210);
      this.label6.Margin = new Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new Size(349, 54);
      this.label6.TabIndex = 5;
      this.label6.Text = "Step 3:\r\nClick NEXT and the MASTER-PROG will apply approximately\r\n4 Volts to the VDD pin.";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point((int) sbyte.MaxValue, 117);
      this.label5.Margin = new Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(236, 72);
      this.label5.TabIndex = 4;
      this.label5.Text = "Step 2:\r\nConnect a voltage meter between\r\npin 2 (VDD) and pin 3 (GND) of the\r\nPICkit 2 ICSP connector.";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point((int) sbyte.MaxValue, 27);
      this.label4.Margin = new Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(228, 72);
      this.label4.TabIndex = 3;
      this.label4.Text = "Step 1:\r\nMake sure the MASTER-PROG is not\r\nconnected to any device or circuit\r\nboard.";
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(0, 27);
      this.pictureBox1.Margin = new Padding(4, 4, 4, 4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(78, 116);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(76, 0);
      this.label3.Margin = new Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(237, 24);
      this.label3.TabIndex = 1;
      this.label3.Text = "MASTER-PROG VDD Calibration";
      this.panelCal.Controls.Add((Control) this.labelBadCal);
      this.panelCal.Controls.Add((Control) this.labelGoodCal);
      this.panelCal.Controls.Add((Control) this.buttonCalibrate);
      this.panelCal.Controls.Add((Control) this.label8);
      this.panelCal.Controls.Add((Control) this.label7);
      this.panelCal.Controls.Add((Control) this.textBoxVDD);
      this.panelCal.Controls.Add((Control) this.label9);
      this.panelCal.Controls.Add((Control) this.pictureBox2);
      this.panelCal.Controls.Add((Control) this.label10);
      this.panelCal.Location = new Point(16, 15);
      this.panelCal.Margin = new Padding(4, 4, 4, 4);
      this.panelCal.Name = "panelCal";
      this.panelCal.Size = new Size(413, 295);
      this.panelCal.TabIndex = 6;
      this.panelCal.Visible = false;
      this.labelBadCal.AutoSize = true;
      this.labelBadCal.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelBadCal.ForeColor = Color.Red;
      this.labelBadCal.Location = new Point(4, 247);
      this.labelBadCal.Margin = new Padding(4, 0, 4, 0);
      this.labelBadCal.Name = "labelBadCal";
      this.labelBadCal.Size = new Size(334, 36);
      this.labelBadCal.TabIndex = 9;
      this.labelBadCal.Text = "Could not fully calibrate the unit.  The USB voltage\r\nmay be too low to completely calibrate.";
      this.labelBadCal.Visible = false;
      this.labelGoodCal.AutoSize = true;
      this.labelGoodCal.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelGoodCal.ForeColor = Color.Blue;
      this.labelGoodCal.Location = new Point(4, 260);
      this.labelGoodCal.Margin = new Padding(4, 0, 4, 0);
      this.labelGoodCal.Name = "labelGoodCal";
      this.labelGoodCal.Size = new Size(212, 18);
      this.labelGoodCal.TabIndex = 8;
      this.labelGoodCal.Text = "Calibación Correcta!";
      this.labelGoodCal.Visible = false;
      this.buttonCalibrate.Location = new Point(8, 215);
      this.buttonCalibrate.Margin = new Padding(4, 4, 4, 4);
      this.buttonCalibrate.Name = "buttonCalibrate";
      this.buttonCalibrate.Size = new Size(140, 28);
      this.buttonCalibrate.TabIndex = 7;
      this.buttonCalibrate.Text = "Calibrate";
      this.buttonCalibrate.UseVisualStyleBackColor = true;
      this.buttonCalibrate.Click += new EventHandler(this.buttonCalibrate_Click);
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(4, 174);
      this.label8.Margin = new Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new Size(353, 36);
      this.label8.TabIndex = 6;
      this.label8.Text = "Step 5:\r\nClick the CALIBRATE button to calibrate the MASTER-PROG.";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(205, 130);
      this.label7.Margin = new Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new Size(106, 17);
      this.label7.TabIndex = 5;
      this.label7.Text = "Volts Measured";
      this.textBoxVDD.Location = new Point(131, (int) sbyte.MaxValue);
      this.textBoxVDD.Margin = new Padding(4, 4, 4, 4);
      this.textBoxVDD.Name = "textBoxVDD";
      this.textBoxVDD.Size = new Size(65, 22);
      this.textBoxVDD.TabIndex = 4;
      this.textBoxVDD.Text = "4.000";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point((int) sbyte.MaxValue, 27);
      this.label9.Margin = new Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new Size(252, 72);
      this.label9.TabIndex = 3;
      this.label9.Text = "Step 4:\r\nEnter the actual voltage measured\r\non the volt meter in the box below, up\r\nto 3 decimal places.";
      this.pictureBox2.Image = (Image) componentResourceManager.GetObject("pictureBox2.Image");
      this.pictureBox2.Location = new Point(0, 27);
      this.pictureBox2.Margin = new Padding(4, 4, 4, 4);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(78, 116);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox2.TabIndex = 2;
      this.pictureBox2.TabStop = false;
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(76, 0);
      this.label10.Margin = new Padding(4, 0, 4, 0);
      this.label10.Name = "label10";
      this.label10.Size = new Size(237, 24);
      this.label10.TabIndex = 1;
      this.label10.Text = "MASTER-PROG VDD Calibration";
      this.panelUnitID.Controls.Add((Control) this.labelAssignedID);
      this.panelUnitID.Controls.Add((Control) this.buttonSetUnitID);
      this.panelUnitID.Controls.Add((Control) this.textBoxUnitID);
      this.panelUnitID.Controls.Add((Control) this.label12);
      this.panelUnitID.Controls.Add((Control) this.label15);
      this.panelUnitID.Controls.Add((Control) this.label16);
      this.panelUnitID.Location = new Point(16, 15);
      this.panelUnitID.Margin = new Padding(4, 4, 4, 4);
      this.panelUnitID.Name = "panelUnitID";
      this.panelUnitID.Size = new Size(413, 295);
      this.panelUnitID.TabIndex = 7;
      this.panelUnitID.Visible = false;
      this.labelAssignedID.AutoSize = true;
      this.labelAssignedID.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelAssignedID.ForeColor = Color.Blue;
      this.labelAssignedID.Location = new Point(73, 271);
      this.labelAssignedID.Margin = new Padding(4, 0, 4, 0);
      this.labelAssignedID.Name = "labelAssignedID";
      this.labelAssignedID.Size = new Size(219, 18);
      this.labelAssignedID.TabIndex = 7;
      this.labelAssignedID.Text = "Unit ID Assigned to this MASTER-PROG.";
      this.labelAssignedID.Visible = false;
      this.buttonSetUnitID.Location = new Point(233, 235);
      this.buttonSetUnitID.Margin = new Padding(4, 4, 4, 4);
      this.buttonSetUnitID.Name = "buttonSetUnitID";
      this.buttonSetUnitID.Size = new Size(132, 28);
      this.buttonSetUnitID.TabIndex = 6;
      this.buttonSetUnitID.Text = "Assign Unit ID";
      this.buttonSetUnitID.UseVisualStyleBackColor = true;
      this.buttonSetUnitID.Click += new EventHandler(this.buttonSetUnitID_Click);
      this.textBoxUnitID.Location = new Point(33, 238);
      this.textBoxUnitID.Margin = new Padding(4, 4, 4, 4);
      this.textBoxUnitID.Name = "textBoxUnitID";
      this.textBoxUnitID.Size = new Size(167, 22);
      this.textBoxUnitID.TabIndex = 5;
      this.textBoxUnitID.Text = "AAAAAAAAAAAAAAA";
      this.textBoxUnitID.TextChanged += new EventHandler(this.textBoxUnitID_TextChanged);
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.Location = new Point(147, 23);
      this.label12.Margin = new Padding(4, 0, 4, 0);
      this.label12.Name = "label12";
      this.label12.Size = new Size(97, 23);
      this.label12.TabIndex = 4;
      this.label12.Text = "(Optional)";
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(0, 60);
      this.label15.Margin = new Padding(4, 0, 4, 0);
      this.label15.Name = "label15";
      this.label15.Size = new Size(370, 144);
      this.label15.TabIndex = 3;
      this.label15.Text = componentResourceManager.GetString("label15.Text");
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(76, 0);
      this.label16.Margin = new Padding(4, 0, 4, 0);
      this.label16.Name = "label16";
      this.label16.Size = new Size(235, 24);
      this.label16.TabIndex = 1;
      this.label16.Text = "Unit Identification Name";
      this.AutoScaleDimensions = new SizeF(120f, 120f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(443, 352);
      this.Controls.Add((Control) this.panelUnitID);
      this.Controls.Add((Control) this.panelCal);
      this.Controls.Add((Control) this.panelSetup);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonNext);
      this.Controls.Add((Control) this.buttonBack);
      this.Controls.Add((Control) this.panelIntro);
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogCalibrate";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "DialogCalibrate";
      this.panelIntro.ResumeLayout(false);
      this.panelIntro.PerformLayout();
      this.panelSetup.ResumeLayout(false);
      this.panelSetup.PerformLayout();
      this.pictureBox1.EndInit();
      this.panelCal.ResumeLayout(false);
      this.panelCal.PerformLayout();
      this.pictureBox2.EndInit();
      this.panelUnitID.ResumeLayout(false);
      this.panelUnitID.PerformLayout();
      this.ResumeLayout(false);
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      ProgCommand.VddOff();
      if (this.unitIDChanged)
      {
        ProgCommand.ResetPICkit2();
        Thread.Sleep(1000);
        int num = (int) MessageBox.Show("Reiniciando MASTER-PROG.\n\nPor favor espera...\nHaz clic para continuar", "Reinicar MASTER-PROG");
        Thread.Sleep(1000);
      }
      this.Close();
    }

    private void setupClearButtons()
    {
      if (ProgCommand.isCalibrated())
      {
        this.buttonClearCal.Enabled = true;
        this.buttonClearCal.Text = "Borrar Ajuste";
      }
      else
      {
        this.buttonClearCal.Enabled = false;
        this.buttonClearCal.Text = "Programador no Ajustado";
      }
      if (ProgCommand.UnitIDRead().Length > 0)
      {
        this.buttonClearUnitID.Enabled = true;
        this.buttonClearUnitID.Text = "Borrar Identificador";
      }
      else
      {
        this.buttonClearUnitID.Enabled = false;
        this.buttonClearUnitID.Text = "Sin Identificador";
      }
    }

    private void buttonNext_Click(object sender, EventArgs e)
    {
      if (this.panelIntro.Visible)
      {
        this.panelIntro.Visible = false;
        this.panelSetup.Visible = true;
        this.buttonBack.Enabled = true;
      }
      else if (this.panelSetup.Visible)
      {
        this.panelSetup.Visible = false;
        this.panelCal.Visible = true;
        this.buttonCalibrate.Enabled = true;
        this.labelGoodCal.Visible = false;
        this.labelBadCal.Visible = false;
        this.textBoxVDD.Text = "4.000";
        this.textBoxVDD.Focus();
        this.textBoxVDD.SelectAll();
        ProgCommand.SetVoltageCals((ushort) 256, (byte) 0, (byte) sbyte.MinValue);
        ProgCommand.SetVDDVoltage(4f, 3.4f);
        ProgCommand.VddOn();
      }
      else
      {
        if (!this.panelCal.Visible)
          return;
        this.panelCal.Visible = false;
        this.panelUnitID.Visible = true;
        this.buttonSetUnitID.Enabled = true;
        this.labelAssignedID.Visible = false;
        this.textBoxUnitID.Text = ProgCommand.UnitIDRead();
        this.textBoxUnitID.Focus();
        this.textBoxVDD.SelectAll();
        this.buttonNext.Enabled = false;
        this.buttonCancel.Text = "Finalizado";
        ProgCommand.VddOff();
      }
    }

    private void buttonBack_Click(object sender, EventArgs e)
    {
      if (this.panelSetup.Visible)
      {
        this.panelIntro.Visible = true;
        this.panelSetup.Visible = false;
        this.buttonBack.Enabled = false;
        this.setupClearButtons();
      }
      else if (this.panelCal.Visible)
      {
        ProgCommand.VddOff();
        this.panelSetup.Visible = true;
        this.panelCal.Visible = false;
      }
      else
      {
        if (!this.panelUnitID.Visible)
          return;
        this.panelUnitID.Visible = false;
        this.panelCal.Visible = true;
        this.buttonCalibrate.Enabled = false;
        this.labelGoodCal.Visible = false;
        this.labelBadCal.Visible = false;
        this.textBoxVDD.Text = "-";
        this.buttonNext.Enabled = true;
        this.buttonCancel.Text = "Cancelar";
      }
    }

    private void buttonCalibrate_Click(object sender, EventArgs e)
    {
      float vdd = 0.0f;
      float vpp = 0.0f;
      bool flag = true;
      float num1;
      try
      {
        num1 = float.Parse(this.textBoxVDD.Text);
      }
      catch
      {
        int num2 = (int) MessageBox.Show("Nivel de Voltaje Medido Incorrecto!!");
        return;
      }
      ProgCommand.ReadPICkitVoltages(ref vdd, ref vpp);
      float num3 = num1 / vdd;
      if ((double) num3 > 1.25)
      {
        num3 = 1.25f;
        flag = false;
      }
      if ((double) num3 < 0.75)
      {
        num3 = 0.75f;
        flag = false;
      }
      float num4 = 256f * num3;
      ProgCommand.SetVoltageCals((ushort) num4, (byte) 0, (byte) sbyte.MinValue);
      ProgCommand.SetVDDVoltage(3f, 2f);
      Thread.Sleep(150);
      ProgCommand.ReadPICkitVoltages(ref vdd, ref vpp);
      float num5 = vdd;
      ProgCommand.SetVDDVoltage(4f, 2.7f);
      Thread.Sleep(150);
      ProgCommand.ReadPICkitVoltages(ref vdd, ref vpp);
      float num6 = (float) (3.0 - 4.0 * (double) num5 / (double) vdd) * (float) ((int) ProgCommand.CalculateVddCPP(4f) >> 6);
      if ((double) num6 > (double) sbyte.MaxValue)
      {
        num6 = (float) sbyte.MaxValue;
        flag = false;
      }
      if ((double) num6 < (double) sbyte.MinValue)
      {
        num6 = (float) sbyte.MinValue;
        flag = false;
      }
      float num7 = (float) (1.0 / ((double) vdd - (double) num5) * 128.0);
      if ((double) num7 > 173.0)
      {
        num7 = 173f;
        flag = false;
      }
      if ((double) num7 < 83.0)
      {
        num7 = 83f;
        flag = false;
      }
      if (flag)
      {
        this.labelGoodCal.Visible = true;
        this.labelBadCal.Visible = false;
        ProgCommand.SetVoltageCals((ushort) num4, (byte) num6, (byte) ((double) num7 + 0.5));
      }
      else
      {
        this.labelGoodCal.Visible = false;
        this.labelBadCal.Visible = true;
        ProgCommand.SetVoltageCals((ushort) 256, (byte) 0, (byte) sbyte.MinValue);
      }
      this.buttonCalibrate.Enabled = false;
      ProgCommand.VddOff();
    }

    private void textBoxUnitID_TextChanged(object sender, EventArgs e)
    {
      if (this.textBoxUnitID.Text.Length <= 15)
        return;
      this.textBoxUnitID.Text = this.textBoxUnitID.Text.Substring(0, 15);
      this.textBoxUnitID.SelectionStart = 15;
    }

    private void buttonSetUnitID_Click(object sender, EventArgs e)
    {
      if (!ProgCommand.UnitIDWrite(this.textBoxUnitID.Text))
        return;
      this.labelAssignedID.Visible = true;
      this.buttonSetUnitID.Enabled = false;
      this.unitIDChanged = true;
    }

    private void buttonClearCal_Click(object sender, EventArgs e)
    {
      ProgCommand.SetVoltageCals((ushort) 256, (byte) 0, (byte) sbyte.MinValue);
      this.buttonClearCal.Enabled = false;
      this.buttonClearCal.Text = "Programador No Ajustado";
    }

    private void buttonClearUnitID_Click(object sender, EventArgs e)
    {
      ProgCommand.UnitIDWrite("");
      this.buttonClearUnitID.Enabled = false;
      this.buttonClearUnitID.Text = "Sin Identificador";
      this.unitIDChanged = true;
    }
  }
}
