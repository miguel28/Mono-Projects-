// Type: SysProgUSB.DialogLogic
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogLogic : Form
  {
    private byte[] sampleArray = new byte[1024];
    private int lastZoomLevel = 1;
    private int lastTrigPos = 50;
    private float[] sampleRates = new float[9]
    {
      1E-06f,
      2E-06f,
      4E-06f,
      1E-05f,
      2E-05f,
      4E-05f,
      0.0001f,
      0.0002f,
      1.0 / 1000.0
    };
    private byte[] sampleFactors = new byte[9]
    {
      (byte) 0,
      (byte) 1,
      (byte) 3,
      (byte) 9,
      (byte) 19,
      (byte) 39,
      (byte) 99,
      (byte) 199,
      byte.MaxValue
    };
    private int postTrigCount = 1;
    private const int SAMPLE_ARRAY_LENGTH = 1024;
    private IContainer components;
    private Label label2;
    private Panel panel2;
    private RadioButton radioButtonAnalyzer;
    private RadioButton radioButtonLogicIO;
    private Panel panelAnalyzer;
    private PictureBox pictureBoxDisplay;
    private Panel panelDisplay;
    private Label label4;
    private Label label3;
    private Label label1;
    private GroupBox groupBoxZoom;
    private Label labelTimeScale;
    private RadioButton radioButton4x;
    private RadioButton radioButtonZoom05;
    private RadioButton radioButton2x;
    private RadioButton radioButtonZoom1x;
    private Label label8;
    private ComboBox comboBoxCh3Trig;
    private ComboBox comboBoxCh2Trig;
    private ComboBox comboBoxCh1Trig;
    private Label label7;
    private Label label6;
    private Label label5;
    private Label label9;
    private Label label14;
    private Label label13;
    private Label label12;
    private Label label11;
    private Label label10;
    private Label label17;
    private TextBox textBox1;
    private Label label16;
    private Label label15;
    private Button buttonExit;
    private GroupBox groupBox2;
    private PictureBox pictureBox1;
    private GroupBox groupBox1;
    private Button buttonRun;
    private Label label18;
    private ComboBox comboBoxSampleRate;
    private Label label19;
    private RadioButton radioButtonTrigStart;
    private Label label21;
    private Label labelAliasFreq;
    private RadioButton radioButtonTrigDly3;
    private RadioButton radioButtonTrigDly2;
    private RadioButton radioButtonTrigDly1;
    private RadioButton radioButtonTrigEnd;
    private RadioButton radioButtonTrigMid;
    private Label label22;
    private Label label23;
    private Label label24;
    private Label label25;
    private Label labelCursor1Val;
    private CheckBox checkBoxCursors;
    private Label labelCursor1;
    private Label labelCursor2Val;
    private Label labelCursor2;
    private Label labelCursorDelta;
    private Label labelCursorDeltaVal;
    private Button buttonHelp;
    private System.Windows.Forms.Timer timerRun;
    private Button buttonSave;
    private SaveFileDialog saveFileDialogDisplay;
    private Panel panelLogicIO;
    private PictureBox pictureBox2;
    private Label label20;
    private Label label29;
    private Label label28;
    private Label label27;
    private Label label26;
    private Panel panel4;
    private RadioButton radioButtonPin6In;
    private RadioButton radioButtonPin6Out;
    private Panel panel3;
    private RadioButton radioButtonPin5In;
    private RadioButton radioButtonPin5Out;
    private Panel panel1;
    private RadioButton radioButtonPin4In;
    private RadioButton radioButtonPin4Out;
    private Label label30;
    private TextBox textBoxPin4In;
    private Label label32;
    private Label label31;
    private TextBox textBoxPin4Out;
    private TextBox textBoxPin1Out;
    private Label label34;
    private Label label33;
    private TextBox textBoxPin5In;
    private TextBox textBoxPin5Out;
    private TextBox textBoxPin6Out;
    private TextBox textBoxPin6In;
    private CheckBox checkBoxIOEnable;
    private Label labelOut6Click;
    private Label labelOut5Click;
    private Label labelOut4Click;
    private Label labelOut1Click;
    private System.Windows.Forms.Timer timerIO;
    private CheckBox checkBoxVDD;
    public DelegateVddCallback VddCallback;
    private int lastSampleRate;
    private int lastTrigDelay;
    private int firstSample;
    private Bitmap lastDrawnDisplay;
    private int cursor1Pos;
    private int cursor2Pos;
    private DialogTrigger trigDialog;
    private bool vddOn;

    public DialogLogic()
    {
      this.InitializeComponent();
      this.KeyPress += new KeyPressEventHandler(this.DialogLogic_KeyPress);
      for (int index = 0; index < 1024; ++index)
        this.sampleArray[index] = (byte) 0;
      this.initLogicIO();
      this.comboBoxCh1Trig.SelectedIndex = 0;
      this.comboBoxCh2Trig.SelectedIndex = 0;
      this.comboBoxCh3Trig.SelectedIndex = 0;
      this.comboBoxSampleRate.SelectedIndex = 0;
      this.labelCursor1Val.Text = "0 us";
      this.labelCursor2Val.Text = "0 us";
      this.labelCursorDeltaVal.Text = "0 us";
      this.updateDisplay();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogLogic));
      this.label2 = new Label();
      this.panel2 = new Panel();
      this.radioButtonAnalyzer = new RadioButton();
      this.radioButtonLogicIO = new RadioButton();
      this.panelAnalyzer = new Panel();
      this.buttonSave = new Button();
      this.labelCursor1Val = new Label();
      this.labelCursor1 = new Label();
      this.labelCursorDelta = new Label();
      this.labelCursorDeltaVal = new Label();
      this.labelCursor2 = new Label();
      this.checkBoxCursors = new CheckBox();
      this.labelCursor2Val = new Label();
      this.label24 = new Label();
      this.label23 = new Label();
      this.label22 = new Label();
      this.groupBox2 = new GroupBox();
      this.label25 = new Label();
      this.radioButtonTrigDly3 = new RadioButton();
      this.radioButtonTrigDly2 = new RadioButton();
      this.radioButtonTrigDly1 = new RadioButton();
      this.radioButtonTrigEnd = new RadioButton();
      this.radioButtonTrigMid = new RadioButton();
      this.radioButtonTrigStart = new RadioButton();
      this.label21 = new Label();
      this.labelAliasFreq = new Label();
      this.comboBoxSampleRate = new ComboBox();
      this.label19 = new Label();
      this.buttonRun = new Button();
      this.pictureBox1 = new PictureBox();
      this.groupBox1 = new GroupBox();
      this.label18 = new Label();
      this.label17 = new Label();
      this.label15 = new Label();
      this.textBox1 = new TextBox();
      this.label5 = new Label();
      this.label16 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label14 = new Label();
      this.comboBoxCh1Trig = new ComboBox();
      this.label13 = new Label();
      this.comboBoxCh2Trig = new ComboBox();
      this.label12 = new Label();
      this.comboBoxCh3Trig = new ComboBox();
      this.label11 = new Label();
      this.label8 = new Label();
      this.label10 = new Label();
      this.label9 = new Label();
      this.groupBoxZoom = new GroupBox();
      this.radioButton4x = new RadioButton();
      this.radioButtonZoom05 = new RadioButton();
      this.radioButton2x = new RadioButton();
      this.radioButtonZoom1x = new RadioButton();
      this.labelTimeScale = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label1 = new Label();
      this.panelDisplay = new Panel();
      this.pictureBoxDisplay = new PictureBox();
      this.buttonExit = new Button();
      this.buttonHelp = new Button();
      this.timerRun = new System.Windows.Forms.Timer(this.components);
      this.saveFileDialogDisplay = new SaveFileDialog();
      this.panelLogicIO = new Panel();
      this.checkBoxIOEnable = new CheckBox();
      this.labelOut6Click = new Label();
      this.labelOut5Click = new Label();
      this.labelOut4Click = new Label();
      this.labelOut1Click = new Label();
      this.textBoxPin6Out = new TextBox();
      this.textBoxPin6In = new TextBox();
      this.textBoxPin5Out = new TextBox();
      this.textBoxPin5In = new TextBox();
      this.textBoxPin4Out = new TextBox();
      this.textBoxPin1Out = new TextBox();
      this.label34 = new Label();
      this.label33 = new Label();
      this.textBoxPin4In = new TextBox();
      this.label32 = new Label();
      this.label31 = new Label();
      this.panel4 = new Panel();
      this.radioButtonPin6In = new RadioButton();
      this.radioButtonPin6Out = new RadioButton();
      this.panel3 = new Panel();
      this.radioButtonPin5In = new RadioButton();
      this.radioButtonPin5Out = new RadioButton();
      this.panel1 = new Panel();
      this.radioButtonPin4In = new RadioButton();
      this.radioButtonPin4Out = new RadioButton();
      this.label30 = new Label();
      this.label29 = new Label();
      this.label28 = new Label();
      this.label27 = new Label();
      this.label26 = new Label();
      this.label20 = new Label();
      this.pictureBox2 = new PictureBox();
      this.timerIO = new System.Windows.Forms.Timer(this.components);
      this.checkBoxVDD = new CheckBox();
      this.panel2.SuspendLayout();
      this.panelAnalyzer.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.pictureBox1.BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBoxZoom.SuspendLayout();
      this.panelDisplay.SuspendLayout();
      this.pictureBoxDisplay.BeginInit();
      this.panelLogicIO.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel1.SuspendLayout();
      this.pictureBox2.BeginInit();
      this.SuspendLayout();
      this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(442, 15);
      this.label2.Name = "label2";
      this.label2.Size = new Size(47, 15);
      this.label2.TabIndex = 10;
      this.label2.Text = "Mode:";
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.panel2.Controls.Add((Control) this.radioButtonAnalyzer);
      this.panel2.Controls.Add((Control) this.radioButtonLogicIO);
      this.panel2.Location = new Point(494, 9);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(130, 30);
      this.panel2.TabIndex = 9;
      this.radioButtonAnalyzer.Appearance = Appearance.Button;
      this.radioButtonAnalyzer.Location = new Point(69, 2);
      this.radioButtonAnalyzer.Name = "radioButtonAnalyzer";
      this.radioButtonAnalyzer.Size = new Size(60, 22);
      this.radioButtonAnalyzer.TabIndex = 17;
      this.radioButtonAnalyzer.Text = "Analyzer";
      this.radioButtonAnalyzer.TextAlign = ContentAlignment.MiddleCenter;
      this.radioButtonAnalyzer.UseVisualStyleBackColor = true;
      this.radioButtonAnalyzer.CheckedChanged += new EventHandler(this.radioButtonAnalyzer_CheckedChanged);
      this.radioButtonLogicIO.Appearance = Appearance.Button;
      this.radioButtonLogicIO.Checked = true;
      this.radioButtonLogicIO.Location = new Point(3, 2);
      this.radioButtonLogicIO.Name = "radioButtonLogicIO";
      this.radioButtonLogicIO.Size = new Size(60, 22);
      this.radioButtonLogicIO.TabIndex = 16;
      this.radioButtonLogicIO.TabStop = true;
      this.radioButtonLogicIO.Text = "Logic I/O";
      this.radioButtonLogicIO.TextAlign = ContentAlignment.MiddleCenter;
      this.radioButtonLogicIO.UseVisualStyleBackColor = true;
      this.panelAnalyzer.Controls.Add((Control) this.buttonSave);
      this.panelAnalyzer.Controls.Add((Control) this.labelCursor1Val);
      this.panelAnalyzer.Controls.Add((Control) this.labelCursor1);
      this.panelAnalyzer.Controls.Add((Control) this.labelCursorDelta);
      this.panelAnalyzer.Controls.Add((Control) this.labelCursorDeltaVal);
      this.panelAnalyzer.Controls.Add((Control) this.labelCursor2);
      this.panelAnalyzer.Controls.Add((Control) this.checkBoxCursors);
      this.panelAnalyzer.Controls.Add((Control) this.labelCursor2Val);
      this.panelAnalyzer.Controls.Add((Control) this.label24);
      this.panelAnalyzer.Controls.Add((Control) this.label23);
      this.panelAnalyzer.Controls.Add((Control) this.label22);
      this.panelAnalyzer.Controls.Add((Control) this.groupBox2);
      this.panelAnalyzer.Controls.Add((Control) this.pictureBox1);
      this.panelAnalyzer.Controls.Add((Control) this.groupBox1);
      this.panelAnalyzer.Controls.Add((Control) this.groupBoxZoom);
      this.panelAnalyzer.Controls.Add((Control) this.labelTimeScale);
      this.panelAnalyzer.Controls.Add((Control) this.label4);
      this.panelAnalyzer.Controls.Add((Control) this.label3);
      this.panelAnalyzer.Controls.Add((Control) this.label1);
      this.panelAnalyzer.Controls.Add((Control) this.panelDisplay);
      this.panelAnalyzer.Location = new Point(12, 39);
      this.panelAnalyzer.Name = "panelAnalyzer";
      this.panelAnalyzer.Size = new Size(610, 326);
      this.panelAnalyzer.TabIndex = 11;
      this.panelAnalyzer.Visible = false;
      this.buttonSave.Location = new Point(542, 119);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new Size(68, 23);
      this.buttonSave.TabIndex = 34;
      this.buttonSave.Text = "Save";
      this.buttonSave.UseVisualStyleBackColor = true;
      this.buttonSave.Click += new EventHandler(this.buttonSave_Click);
      this.labelCursor1Val.AutoSize = true;
      this.labelCursor1Val.Enabled = false;
      this.labelCursor1Val.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelCursor1Val.ForeColor = Color.RoyalBlue;
      this.labelCursor1Val.Location = new Point(260, 2);
      this.labelCursor1Val.Name = "labelCursor1Val";
      this.labelCursor1Val.Size = new Size(63, 13);
      this.labelCursor1Val.TabIndex = 29;
      this.labelCursor1Val.Text = "100.52 us";
      this.labelCursor1.AutoSize = true;
      this.labelCursor1.Enabled = false;
      this.labelCursor1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelCursor1.ForeColor = Color.RoyalBlue;
      this.labelCursor1.Location = new Point(237, 2);
      this.labelCursor1.Name = "labelCursor1";
      this.labelCursor1.Size = new Size(26, 13);
      this.labelCursor1.TabIndex = 28;
      this.labelCursor1.Text = "X =";
      this.labelCursorDelta.AutoSize = true;
      this.labelCursorDelta.Enabled = false;
      this.labelCursorDelta.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelCursorDelta.ForeColor = SystemColors.ControlText;
      this.labelCursorDelta.Location = new Point(439, 2);
      this.labelCursorDelta.Name = "labelCursorDelta";
      this.labelCursorDelta.Size = new Size(38, 13);
      this.labelCursorDelta.TabIndex = 32;
      this.labelCursorDelta.Text = "Y-X =";
      this.labelCursorDeltaVal.AutoSize = true;
      this.labelCursorDeltaVal.Enabled = false;
      this.labelCursorDeltaVal.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelCursorDeltaVal.ForeColor = SystemColors.ControlText;
      this.labelCursorDeltaVal.Location = new Point(477, 2);
      this.labelCursorDeltaVal.Name = "labelCursorDeltaVal";
      this.labelCursorDeltaVal.Size = new Size(122, 13);
      this.labelCursorDeltaVal.TabIndex = 33;
      this.labelCursorDeltaVal.Text = "100.26 us (9974 Hz)";
      this.labelCursor2.AutoSize = true;
      this.labelCursor2.Enabled = false;
      this.labelCursor2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelCursor2.ForeColor = Color.DarkViolet;
      this.labelCursor2.Location = new Point(338, 2);
      this.labelCursor2.Name = "labelCursor2";
      this.labelCursor2.Size = new Size(26, 13);
      this.labelCursor2.TabIndex = 29;
      this.labelCursor2.Text = "Y =";
      this.checkBoxCursors.AutoSize = true;
      this.checkBoxCursors.Location = new Point(161, 1);
      this.checkBoxCursors.Name = "checkBoxCursors";
      this.checkBoxCursors.Size = new Size(61, 17);
      this.checkBoxCursors.TabIndex = 30;
      this.checkBoxCursors.Text = "Cursors";
      this.checkBoxCursors.UseVisualStyleBackColor = true;
      this.checkBoxCursors.CheckedChanged += new EventHandler(this.checkBoxCursors_CheckedChanged);
      this.labelCursor2Val.AutoSize = true;
      this.labelCursor2Val.Enabled = false;
      this.labelCursor2Val.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelCursor2Val.ForeColor = Color.DarkViolet;
      this.labelCursor2Val.Location = new Point(365, 2);
      this.labelCursor2Val.Name = "labelCursor2Val";
      this.labelCursor2Val.Size = new Size(63, 13);
      this.labelCursor2Val.TabIndex = 31;
      this.labelCursor2Val.Text = "200.78 us";
      this.label24.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label24.AutoSize = true;
      this.label24.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label24.ForeColor = SystemColors.ActiveCaption;
      this.label24.Location = new Point(3, 297);
      this.label24.Name = "label24";
      this.label24.Size = new Size(117, 26);
      this.label24.TabIndex = 29;
      this.label24.Text = "Set VDD Voltage value\r\nin main form.";
      this.label23.AutoSize = true;
      this.label23.Location = new Point(84, 157);
      this.label23.Name = "label23";
      this.label23.Size = new Size(65, 78);
      this.label23.TabIndex = 28;
      this.label23.Text = "NOTE:\r\nCh 1 && Ch 2\r\ninputs have \r\n4.7k Ohm\r\npull-down\r\nresistors.";
      this.label22.AutoSize = true;
      this.label22.Location = new Point(3, 265);
      this.label22.Name = "label22";
      this.label22.Size = new Size(158, 26);
      this.label22.TabIndex = 27;
      this.label22.Text = "MASTER-PROG VDD MUST connect to\r\ncircuit VDD.";
      this.groupBox2.Controls.Add((Control) this.label25);
      this.groupBox2.Controls.Add((Control) this.radioButtonTrigDly3);
      this.groupBox2.Controls.Add((Control) this.radioButtonTrigDly2);
      this.groupBox2.Controls.Add((Control) this.radioButtonTrigDly1);
      this.groupBox2.Controls.Add((Control) this.radioButtonTrigEnd);
      this.groupBox2.Controls.Add((Control) this.radioButtonTrigMid);
      this.groupBox2.Controls.Add((Control) this.radioButtonTrigStart);
      this.groupBox2.Controls.Add((Control) this.label21);
      this.groupBox2.Controls.Add((Control) this.labelAliasFreq);
      this.groupBox2.Controls.Add((Control) this.comboBoxSampleRate);
      this.groupBox2.Controls.Add((Control) this.label19);
      this.groupBox2.Controls.Add((Control) this.buttonRun);
      this.groupBox2.Location = new Point(359, 146);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(251, 180);
      this.groupBox2.TabIndex = 26;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Aquisition";
      this.label25.AutoSize = true;
      this.label25.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label25.Location = new Point(110, 164);
      this.label25.Name = "label25";
      this.label25.Size = new Size(135, 13);
      this.label25.TabIndex = 31;
      this.label25.Text = "1 Window = 1000 samples.";
      this.radioButtonTrigDly3.AutoSize = true;
      this.radioButtonTrigDly3.Location = new Point(126, 148);
      this.radioButtonTrigDly3.Name = "radioButtonTrigDly3";
      this.radioButtonTrigDly3.Size = new Size(108, 17);
      this.radioButtonTrigDly3.TabIndex = 30;
      this.radioButtonTrigDly3.Text = "Delay 3 Windows";
      this.radioButtonTrigDly3.UseVisualStyleBackColor = true;
      this.radioButtonTrigDly2.AutoSize = true;
      this.radioButtonTrigDly2.Location = new Point(126, 130);
      this.radioButtonTrigDly2.Name = "radioButtonTrigDly2";
      this.radioButtonTrigDly2.Size = new Size(108, 17);
      this.radioButtonTrigDly2.TabIndex = 29;
      this.radioButtonTrigDly2.Text = "Delay 2 Windows";
      this.radioButtonTrigDly2.UseVisualStyleBackColor = true;
      this.radioButtonTrigDly1.AutoSize = true;
      this.radioButtonTrigDly1.Location = new Point(126, 112);
      this.radioButtonTrigDly1.Name = "radioButtonTrigDly1";
      this.radioButtonTrigDly1.Size = new Size(103, 17);
      this.radioButtonTrigDly1.TabIndex = 28;
      this.radioButtonTrigDly1.Text = "Delay 1 Window";
      this.radioButtonTrigDly1.UseVisualStyleBackColor = true;
      this.radioButtonTrigEnd.AutoSize = true;
      this.radioButtonTrigEnd.Location = new Point(9, 148);
      this.radioButtonTrigEnd.Name = "radioButtonTrigEnd";
      this.radioButtonTrigEnd.Size = new Size(82, 17);
      this.radioButtonTrigEnd.TabIndex = 27;
      this.radioButtonTrigEnd.Text = "End of Data";
      this.radioButtonTrigEnd.UseVisualStyleBackColor = true;
      this.radioButtonTrigMid.AutoSize = true;
      this.radioButtonTrigMid.Location = new Point(9, 130);
      this.radioButtonTrigMid.Name = "radioButtonTrigMid";
      this.radioButtonTrigMid.Size = new Size(94, 17);
      this.radioButtonTrigMid.TabIndex = 26;
      this.radioButtonTrigMid.Text = "Center of Data";
      this.radioButtonTrigMid.UseVisualStyleBackColor = true;
      this.radioButtonTrigStart.AutoSize = true;
      this.radioButtonTrigStart.Checked = true;
      this.radioButtonTrigStart.Location = new Point(9, 112);
      this.radioButtonTrigStart.Name = "radioButtonTrigStart";
      this.radioButtonTrigStart.Size = new Size(85, 17);
      this.radioButtonTrigStart.TabIndex = 25;
      this.radioButtonTrigStart.TabStop = true;
      this.radioButtonTrigStart.Text = "Start of Data";
      this.radioButtonTrigStart.UseVisualStyleBackColor = true;
      this.label21.AutoSize = true;
      this.label21.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label21.Location = new Point(6, 89);
      this.label21.Name = "label21";
      this.label21.Size = new Size(113, 15);
      this.label21.TabIndex = 24;
      this.label21.Text = "Trigger Position:";
      this.labelAliasFreq.AutoSize = true;
      this.labelAliasFreq.Location = new Point(6, 63);
      this.labelAliasFreq.Name = "labelAliasFreq";
      this.labelAliasFreq.Size = new Size(224, 13);
      this.labelAliasFreq.TabIndex = 23;
      this.labelAliasFreq.Text = "NOTE: Signals greater than 500 kHz will alias.";
      this.comboBoxSampleRate.FormattingEnabled = true;
      this.comboBoxSampleRate.Items.AddRange(new object[8]
      {
        (object) "1 MHz - 1 ms Window",
        (object) "500 kHz - 2 ms Window",
        (object) "250 kHz - 4 ms Window",
        (object) "100 kHz - 10 ms Window",
        (object) "50 kHz - 20 ms Window",
        (object) "25 kHz - 40 ms Window",
        (object) "10 kHz - 100 ms Window",
        (object) "5 kHz - 200 ms Window"
      });
      this.comboBoxSampleRate.Location = new Point(9, 37);
      this.comboBoxSampleRate.Name = "comboBoxSampleRate";
      this.comboBoxSampleRate.Size = new Size(168, 21);
      this.comboBoxSampleRate.TabIndex = 22;
      this.comboBoxSampleRate.SelectedIndexChanged += new EventHandler(this.comboBoxSampleRate_SelectedIndexChanged);
      this.label19.AutoSize = true;
      this.label19.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label19.Location = new Point(6, 16);
      this.label19.Name = "label19";
      this.label19.Size = new Size(94, 15);
      this.label19.TabIndex = 21;
      this.label19.Text = "Sample Rate:";
      this.buttonRun.Location = new Point(189, 13);
      this.buttonRun.Name = "buttonRun";
      this.buttonRun.Size = new Size(56, 45);
      this.buttonRun.TabIndex = 0;
      this.buttonRun.Text = "RUN";
      this.buttonRun.UseVisualStyleBackColor = true;
      this.buttonRun.Click += new EventHandler(this.buttonRun_Click);
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(0, 146);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(78, 116);
      this.pictureBox1.TabIndex = 25;
      this.pictureBox1.TabStop = false;
      this.groupBox1.Controls.Add((Control) this.label18);
      this.groupBox1.Controls.Add((Control) this.label17);
      this.groupBox1.Controls.Add((Control) this.label15);
      this.groupBox1.Controls.Add((Control) this.textBox1);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label16);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.label7);
      this.groupBox1.Controls.Add((Control) this.label14);
      this.groupBox1.Controls.Add((Control) this.comboBoxCh1Trig);
      this.groupBox1.Controls.Add((Control) this.label13);
      this.groupBox1.Controls.Add((Control) this.comboBoxCh2Trig);
      this.groupBox1.Controls.Add((Control) this.label12);
      this.groupBox1.Controls.Add((Control) this.comboBoxCh3Trig);
      this.groupBox1.Controls.Add((Control) this.label11);
      this.groupBox1.Controls.Add((Control) this.label8);
      this.groupBox1.Controls.Add((Control) this.label10);
      this.groupBox1.Controls.Add((Control) this.label9);
      this.groupBox1.Location = new Point(167, 146);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(186, 180);
      this.groupBox1.TabIndex = 24;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Trigger";
      this.label18.AutoSize = true;
      this.label18.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label18.Location = new Point(51, 164);
      this.label18.Name = "label18";
      this.label18.Size = new Size(46, 13);
      this.label18.TabIndex = 24;
      this.label18.Text = "(1 - 256)";
      this.label17.AutoSize = true;
      this.label17.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label17.Location = new Point(102, 144);
      this.label17.Name = "label17";
      this.label17.Size = new Size(46, 15);
      this.label17.TabIndex = 23;
      this.label17.Text = "times.";
      this.label15.AutoSize = true;
      this.label15.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label15.Location = new Point(6, 16);
      this.label15.Name = "label15";
      this.label15.Size = new Size(91, 15);
      this.label15.TabIndex = 20;
      this.label15.Text = "Trigger when";
      this.textBox1.Location = new Point(53, 143);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(43, 20);
      this.textBox1.TabIndex = 22;
      this.textBox1.Text = "1";
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.textBox1.Leave += new EventHandler(this.textBox1_Leave);
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(6, 48);
      this.label5.Name = "label5";
      this.label5.Size = new Size(45, 15);
      this.label5.TabIndex = 7;
      this.label5.Text = "Ch 1 = ";
      this.label16.AutoSize = true;
      this.label16.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label16.Location = new Point(6, 144);
      this.label16.Name = "label16";
      this.label16.Size = new Size(49, 15);
      this.label16.TabIndex = 21;
      this.label16.Text = "occurs";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.Location = new Point(6, 79);
      this.label6.Name = "label6";
      this.label6.Size = new Size(45, 15);
      this.label6.TabIndex = 8;
      this.label6.Text = "Ch 2 = ";
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.Location = new Point(6, 111);
      this.label7.Name = "label7";
      this.label7.Size = new Size(45, 15);
      this.label7.TabIndex = 9;
      this.label7.Text = "Ch 3 = ";
      this.label14.AutoSize = true;
      this.label14.Location = new Point(102, 63);
      this.label14.Name = "label14";
      this.label14.Size = new Size(73, 13);
      this.label14.TabIndex = 19;
      this.label14.Text = "1 - Logic High";
      this.comboBoxCh1Trig.FormattingEnabled = true;
      this.comboBoxCh1Trig.Items.AddRange(new object[5]
      {
        (object) "*",
        (object) "1",
        (object) "0",
        (object) "/",
        (object) "\\"
      });
      this.comboBoxCh1Trig.Location = new Point(53, 45);
      this.comboBoxCh1Trig.Name = "comboBoxCh1Trig";
      this.comboBoxCh1Trig.Size = new Size(43, 21);
      this.comboBoxCh1Trig.TabIndex = 10;
      this.comboBoxCh1Trig.SelectedIndexChanged += new EventHandler(this.comboBoxCh1Trig_SelectedIndexChanged);
      this.label13.AutoSize = true;
      this.label13.Location = new Point(102, 81);
      this.label13.Name = "label13";
      this.label13.Size = new Size(71, 13);
      this.label13.TabIndex = 18;
      this.label13.Text = "0 - Logic Low";
      this.comboBoxCh2Trig.FormattingEnabled = true;
      this.comboBoxCh2Trig.Items.AddRange(new object[5]
      {
        (object) "*",
        (object) "1",
        (object) "0",
        (object) "/",
        (object) "\\"
      });
      this.comboBoxCh2Trig.Location = new Point(53, 76);
      this.comboBoxCh2Trig.Name = "comboBoxCh2Trig";
      this.comboBoxCh2Trig.Size = new Size(43, 21);
      this.comboBoxCh2Trig.TabIndex = 11;
      this.comboBoxCh2Trig.SelectedIndexChanged += new EventHandler(this.comboBoxCh2Trig_SelectedIndexChanged);
      this.label12.AutoSize = true;
      this.label12.Location = new Point(102, 99);
      this.label12.Name = "label12";
      this.label12.Size = new Size(78, 13);
      this.label12.TabIndex = 17;
      this.label12.Text = "/ - Rising Edge";
      this.comboBoxCh3Trig.FormattingEnabled = true;
      this.comboBoxCh3Trig.Items.AddRange(new object[5]
      {
        (object) "*",
        (object) "1",
        (object) "0",
        (object) "/",
        (object) "\\"
      });
      this.comboBoxCh3Trig.Location = new Point(53, 108);
      this.comboBoxCh3Trig.Name = "comboBoxCh3Trig";
      this.comboBoxCh3Trig.Size = new Size(43, 21);
      this.comboBoxCh3Trig.TabIndex = 12;
      this.comboBoxCh3Trig.SelectedIndexChanged += new EventHandler(this.comboBoxCh3Trig_SelectedIndexChanged);
      this.label11.AutoSize = true;
      this.label11.Location = new Point(102, 117);
      this.label11.Name = "label11";
      this.label11.Size = new Size(79, 13);
      this.label11.TabIndex = 16;
      this.label11.Text = "\\ - Falling Edge";
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(22, 63);
      this.label8.Name = "label8";
      this.label8.Size = new Size(25, 13);
      this.label8.TabIndex = 13;
      this.label8.Text = "and";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(102, 45);
      this.label10.Name = "label10";
      this.label10.Size = new Size(70, 13);
      this.label10.TabIndex = 15;
      this.label10.Text = "* - Don't Care";
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label9.Location = new Point(22, 94);
      this.label9.Name = "label9";
      this.label9.Size = new Size(25, 13);
      this.label9.TabIndex = 14;
      this.label9.Text = "and";
      this.groupBoxZoom.Controls.Add((Control) this.radioButton4x);
      this.groupBoxZoom.Controls.Add((Control) this.radioButtonZoom05);
      this.groupBoxZoom.Controls.Add((Control) this.radioButton2x);
      this.groupBoxZoom.Controls.Add((Control) this.radioButtonZoom1x);
      this.groupBoxZoom.Location = new Point(542, 13);
      this.groupBoxZoom.Name = "groupBoxZoom";
      this.groupBoxZoom.Size = new Size(68, 100);
      this.groupBoxZoom.TabIndex = 6;
      this.groupBoxZoom.TabStop = false;
      this.groupBoxZoom.Text = "Zoom";
      this.radioButton4x.AutoSize = true;
      this.radioButton4x.Location = new Point(9, 73);
      this.radioButton4x.Name = "radioButton4x";
      this.radioButton4x.Size = new Size(36, 17);
      this.radioButton4x.TabIndex = 10;
      this.radioButton4x.Text = "4x";
      this.radioButton4x.UseVisualStyleBackColor = true;
      this.radioButton4x.Click += new EventHandler(this.radioButtonZoom05_Click);
      this.radioButtonZoom05.AutoSize = true;
      this.radioButtonZoom05.Location = new Point(9, 19);
      this.radioButtonZoom05.Name = "radioButtonZoom05";
      this.radioButtonZoom05.Size = new Size(45, 17);
      this.radioButtonZoom05.TabIndex = 7;
      this.radioButtonZoom05.Text = "0.5x";
      this.radioButtonZoom05.UseVisualStyleBackColor = true;
      this.radioButtonZoom05.Click += new EventHandler(this.radioButtonZoom05_Click);
      this.radioButton2x.AutoSize = true;
      this.radioButton2x.Location = new Point(9, 55);
      this.radioButton2x.Name = "radioButton2x";
      this.radioButton2x.Size = new Size(36, 17);
      this.radioButton2x.TabIndex = 9;
      this.radioButton2x.Text = "2x";
      this.radioButton2x.UseVisualStyleBackColor = true;
      this.radioButton2x.Click += new EventHandler(this.radioButtonZoom05_Click);
      this.radioButtonZoom1x.AutoSize = true;
      this.radioButtonZoom1x.Checked = true;
      this.radioButtonZoom1x.Location = new Point(9, 37);
      this.radioButtonZoom1x.Name = "radioButtonZoom1x";
      this.radioButtonZoom1x.Size = new Size(36, 17);
      this.radioButtonZoom1x.TabIndex = 8;
      this.radioButtonZoom1x.TabStop = true;
      this.radioButtonZoom1x.Text = "1x";
      this.radioButtonZoom1x.UseVisualStyleBackColor = true;
      this.radioButtonZoom1x.Click += new EventHandler(this.radioButtonZoom05_Click);
      this.labelTimeScale.AutoSize = true;
      this.labelTimeScale.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelTimeScale.Location = new Point(33, 0);
      this.labelTimeScale.Name = "labelTimeScale";
      this.labelTimeScale.Size = new Size(70, 15);
      this.labelTimeScale.TabIndex = 5;
      this.labelTimeScale.Text = "50us / Div";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(1, 95);
      this.label4.Name = "label4";
      this.label4.Size = new Size(29, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Ch.3";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(1, 65);
      this.label3.Name = "label3";
      this.label3.Size = new Size(29, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Ch.2";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(1, 35);
      this.label1.Name = "label1";
      this.label1.Size = new Size(29, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Ch.1";
      this.panelDisplay.AutoScroll = true;
      this.panelDisplay.BorderStyle = BorderStyle.Fixed3D;
      this.panelDisplay.Controls.Add((Control) this.pictureBoxDisplay);
      this.panelDisplay.Location = new Point(36, 20);
      this.panelDisplay.Name = "panelDisplay";
      this.panelDisplay.Size = new Size(500, 122);
      this.panelDisplay.TabIndex = 1;
      this.pictureBoxDisplay.Location = new Point(0, 0);
      this.pictureBoxDisplay.Name = "pictureBoxDisplay";
      this.pictureBoxDisplay.Size = new Size(1024, 100);
      this.pictureBoxDisplay.TabIndex = 0;
      this.pictureBoxDisplay.TabStop = false;
      this.pictureBoxDisplay.MouseDown += new MouseEventHandler(this.pictureBoxDisplay_MouseDown);
      this.buttonExit.Location = new Point(508, 371);
      this.buttonExit.Name = "buttonExit";
      this.buttonExit.Size = new Size(116, 23);
      this.buttonExit.TabIndex = 27;
      this.buttonExit.Text = "Exit Logic Tool";
      this.buttonExit.UseVisualStyleBackColor = true;
      this.buttonExit.Click += new EventHandler(this.buttonExit_Click);
      this.buttonHelp.Location = new Point(12, 371);
      this.buttonHelp.Name = "buttonHelp";
      this.buttonHelp.Size = new Size(56, 23);
      this.buttonHelp.TabIndex = 32;
      this.buttonHelp.Text = "Help";
      this.buttonHelp.UseVisualStyleBackColor = true;
      this.buttonHelp.Click += new EventHandler(this.buttonHelp_Click);
      this.timerRun.Interval = 250;
      this.timerRun.Tick += new EventHandler(this.timerRun_Tick);
      this.saveFileDialogDisplay.DefaultExt = "bmp";
      this.saveFileDialogDisplay.Filter = "Bitmap(.bmp)|*.bmp";
      this.saveFileDialogDisplay.InitialDirectory = "c:\\";
      this.saveFileDialogDisplay.Title = "Save Logic Analyzer Display";
      this.panelLogicIO.Controls.Add((Control) this.checkBoxIOEnable);
      this.panelLogicIO.Controls.Add((Control) this.labelOut6Click);
      this.panelLogicIO.Controls.Add((Control) this.labelOut5Click);
      this.panelLogicIO.Controls.Add((Control) this.labelOut4Click);
      this.panelLogicIO.Controls.Add((Control) this.labelOut1Click);
      this.panelLogicIO.Controls.Add((Control) this.textBoxPin6Out);
      this.panelLogicIO.Controls.Add((Control) this.textBoxPin6In);
      this.panelLogicIO.Controls.Add((Control) this.textBoxPin5Out);
      this.panelLogicIO.Controls.Add((Control) this.textBoxPin5In);
      this.panelLogicIO.Controls.Add((Control) this.textBoxPin4Out);
      this.panelLogicIO.Controls.Add((Control) this.textBoxPin1Out);
      this.panelLogicIO.Controls.Add((Control) this.label34);
      this.panelLogicIO.Controls.Add((Control) this.label33);
      this.panelLogicIO.Controls.Add((Control) this.textBoxPin4In);
      this.panelLogicIO.Controls.Add((Control) this.label32);
      this.panelLogicIO.Controls.Add((Control) this.label31);
      this.panelLogicIO.Controls.Add((Control) this.panel4);
      this.panelLogicIO.Controls.Add((Control) this.panel3);
      this.panelLogicIO.Controls.Add((Control) this.panel1);
      this.panelLogicIO.Controls.Add((Control) this.label30);
      this.panelLogicIO.Controls.Add((Control) this.label29);
      this.panelLogicIO.Controls.Add((Control) this.label28);
      this.panelLogicIO.Controls.Add((Control) this.label27);
      this.panelLogicIO.Controls.Add((Control) this.label26);
      this.panelLogicIO.Controls.Add((Control) this.label20);
      this.panelLogicIO.Controls.Add((Control) this.pictureBox2);
      this.panelLogicIO.Location = new Point(12, 39);
      this.panelLogicIO.Name = "panelLogicIO";
      this.panelLogicIO.Size = new Size(610, 326);
      this.panelLogicIO.TabIndex = 33;
      this.checkBoxIOEnable.Appearance = Appearance.Button;
      this.checkBoxIOEnable.Location = new Point(515, 277);
      this.checkBoxIOEnable.Name = "checkBoxIOEnable";
      this.checkBoxIOEnable.Size = new Size(78, 34);
      this.checkBoxIOEnable.TabIndex = 52;
      this.checkBoxIOEnable.Text = "Enable IO";
      this.checkBoxIOEnable.TextAlign = ContentAlignment.MiddleCenter;
      this.checkBoxIOEnable.UseVisualStyleBackColor = true;
      this.checkBoxIOEnable.CheckedChanged += new EventHandler(this.checkBoxIOEnable_CheckedChanged);
      this.labelOut6Click.AutoSize = true;
      this.labelOut6Click.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelOut6Click.ForeColor = SystemColors.ControlDarkDark;
      this.labelOut6Click.Location = new Point(419, 243);
      this.labelOut6Click.Name = "labelOut6Click";
      this.labelOut6Click.Size = new Size(178, 13);
      this.labelOut6Click.TabIndex = 51;
      this.labelOut6Click.Text = "<- Click Output box or press <F> key";
      this.labelOut5Click.AutoSize = true;
      this.labelOut5Click.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelOut5Click.ForeColor = SystemColors.ControlDarkDark;
      this.labelOut5Click.Location = new Point(419, 177);
      this.labelOut5Click.Name = "labelOut5Click";
      this.labelOut5Click.Size = new Size(180, 13);
      this.labelOut5Click.TabIndex = 50;
      this.labelOut5Click.Text = "<- Click Output box or press <D> key";
      this.labelOut4Click.AutoSize = true;
      this.labelOut4Click.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelOut4Click.ForeColor = SystemColors.ControlDarkDark;
      this.labelOut4Click.Location = new Point(419, 111);
      this.labelOut4Click.Name = "labelOut4Click";
      this.labelOut4Click.Size = new Size(179, 13);
      this.labelOut4Click.TabIndex = 49;
      this.labelOut4Click.Text = "<- Click Output box or press <S> key";
      this.labelOut1Click.AutoSize = true;
      this.labelOut1Click.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelOut1Click.ForeColor = SystemColors.ControlDarkDark;
      this.labelOut1Click.Location = new Point(419, 45);
      this.labelOut1Click.Name = "labelOut1Click";
      this.labelOut1Click.Size = new Size(179, 13);
      this.labelOut1Click.TabIndex = 48;
      this.labelOut1Click.Text = "<- Click Output box or press <A> key";
      this.textBoxPin6Out.BackColor = SystemColors.Control;
      this.textBoxPin6Out.Cursor = Cursors.Hand;
      this.textBoxPin6Out.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBoxPin6Out.ForeColor = SystemColors.Window;
      this.textBoxPin6Out.Location = new Point(350, 237);
      this.textBoxPin6Out.Name = "textBoxPin6Out";
      this.textBoxPin6Out.ReadOnly = true;
      this.textBoxPin6Out.Size = new Size(30, 29);
      this.textBoxPin6Out.TabIndex = 47;
      this.textBoxPin6Out.TextAlign = HorizontalAlignment.Center;
      this.textBoxPin6Out.Click += new EventHandler(this.textBoxPin6Out_Click);
      this.textBoxPin6In.BackColor = SystemColors.Control;
      this.textBoxPin6In.Cursor = Cursors.Default;
      this.textBoxPin6In.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBoxPin6In.ForeColor = SystemColors.Window;
      this.textBoxPin6In.Location = new Point(266, 239);
      this.textBoxPin6In.Name = "textBoxPin6In";
      this.textBoxPin6In.ReadOnly = true;
      this.textBoxPin6In.Size = new Size(30, 29);
      this.textBoxPin6In.TabIndex = 46;
      this.textBoxPin6In.TextAlign = HorizontalAlignment.Center;
      this.textBoxPin5Out.BackColor = Color.Red;
      this.textBoxPin5Out.Cursor = Cursors.Hand;
      this.textBoxPin5Out.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBoxPin5Out.ForeColor = SystemColors.Window;
      this.textBoxPin5Out.Location = new Point(350, 173);
      this.textBoxPin5Out.Name = "textBoxPin5Out";
      this.textBoxPin5Out.ReadOnly = true;
      this.textBoxPin5Out.Size = new Size(30, 29);
      this.textBoxPin5Out.TabIndex = 45;
      this.textBoxPin5Out.Text = "1";
      this.textBoxPin5Out.TextAlign = HorizontalAlignment.Center;
      this.textBoxPin5Out.Click += new EventHandler(this.textBoxPin5Out_Click);
      this.textBoxPin5In.BackColor = Color.DodgerBlue;
      this.textBoxPin5In.Cursor = Cursors.Default;
      this.textBoxPin5In.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBoxPin5In.ForeColor = SystemColors.Window;
      this.textBoxPin5In.Location = new Point(266, 173);
      this.textBoxPin5In.Name = "textBoxPin5In";
      this.textBoxPin5In.ReadOnly = true;
      this.textBoxPin5In.Size = new Size(30, 29);
      this.textBoxPin5In.TabIndex = 44;
      this.textBoxPin5In.Text = "1";
      this.textBoxPin5In.TextAlign = HorizontalAlignment.Center;
      this.textBoxPin4Out.BackColor = Color.DarkRed;
      this.textBoxPin4Out.Cursor = Cursors.Hand;
      this.textBoxPin4Out.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBoxPin4Out.ForeColor = SystemColors.Window;
      this.textBoxPin4Out.Location = new Point(350, 107);
      this.textBoxPin4Out.Name = "textBoxPin4Out";
      this.textBoxPin4Out.ReadOnly = true;
      this.textBoxPin4Out.Size = new Size(30, 29);
      this.textBoxPin4Out.TabIndex = 43;
      this.textBoxPin4Out.Text = "0";
      this.textBoxPin4Out.TextAlign = HorizontalAlignment.Center;
      this.textBoxPin4Out.Click += new EventHandler(this.textBoxPin4Out_Click);
      this.textBoxPin1Out.BackColor = Color.DarkRed;
      this.textBoxPin1Out.Cursor = Cursors.Hand;
      this.textBoxPin1Out.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBoxPin1Out.ForeColor = SystemColors.Window;
      this.textBoxPin1Out.Location = new Point(350, 39);
      this.textBoxPin1Out.Name = "textBoxPin1Out";
      this.textBoxPin1Out.ReadOnly = true;
      this.textBoxPin1Out.Size = new Size(30, 29);
      this.textBoxPin1Out.TabIndex = 42;
      this.textBoxPin1Out.Text = "0";
      this.textBoxPin1Out.TextAlign = HorizontalAlignment.Center;
      this.textBoxPin1Out.Click += new EventHandler(this.textBoxPin1Out_Click);
      this.label34.AutoSize = true;
      this.label34.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.label34.Location = new Point(260, 13);
      this.label34.Name = "label34";
      this.label34.Size = new Size(49, 16);
      this.label34.TabIndex = 41;
      this.label34.Text = "Inputs";
      this.label33.AutoSize = true;
      this.label33.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.label33.Location = new Point(338, 13);
      this.label33.Name = "label33";
      this.label33.Size = new Size(60, 16);
      this.label33.TabIndex = 40;
      this.label33.Text = "Outputs";
      this.textBoxPin4In.BackColor = Color.DarkBlue;
      this.textBoxPin4In.Cursor = Cursors.Default;
      this.textBoxPin4In.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.textBoxPin4In.ForeColor = SystemColors.Window;
      this.textBoxPin4In.Location = new Point(266, 107);
      this.textBoxPin4In.Name = "textBoxPin4In";
      this.textBoxPin4In.ReadOnly = true;
      this.textBoxPin4In.Size = new Size(30, 29);
      this.textBoxPin4In.TabIndex = 38;
      this.textBoxPin4In.Text = "0";
      this.textBoxPin4In.TextAlign = HorizontalAlignment.Center;
      this.label32.AutoSize = true;
      this.label32.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label32.ForeColor = SystemColors.ControlDarkDark;
      this.label32.Location = new Point(108, 197);
      this.label32.Name = "label32";
      this.label32.Size = new Size(53, 26);
      this.label32.TabIndex = 37;
      this.label32.Text = "4.7k Ohm\r\npulldown";
      this.label31.AutoSize = true;
      this.label31.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label31.ForeColor = SystemColors.ControlDarkDark;
      this.label31.Location = new Point(108, 131);
      this.label31.Name = "label31";
      this.label31.Size = new Size(53, 26);
      this.label31.TabIndex = 36;
      this.label31.Text = "4.7k Ohm\r\npulldown";
      this.panel4.Controls.Add((Control) this.radioButtonPin6In);
      this.panel4.Controls.Add((Control) this.radioButtonPin6Out);
      this.panel4.Location = new Point(170, 233);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(60, 45);
      this.panel4.TabIndex = 35;
      this.radioButtonPin6In.AutoSize = true;
      this.radioButtonPin6In.Checked = true;
      this.radioButtonPin6In.Enabled = false;
      this.radioButtonPin6In.Location = new Point(3, 21);
      this.radioButtonPin6In.Name = "radioButtonPin6In";
      this.radioButtonPin6In.Size = new Size(49, 17);
      this.radioButtonPin6In.TabIndex = 1;
      this.radioButtonPin6In.TabStop = true;
      this.radioButtonPin6In.Text = "Input";
      this.radioButtonPin6In.UseVisualStyleBackColor = true;
      this.radioButtonPin6Out.AutoSize = true;
      this.radioButtonPin6Out.Enabled = false;
      this.radioButtonPin6Out.Location = new Point(3, 3);
      this.radioButtonPin6Out.Name = "radioButtonPin6Out";
      this.radioButtonPin6Out.Size = new Size(57, 17);
      this.radioButtonPin6Out.TabIndex = 0;
      this.radioButtonPin6Out.Text = "Output";
      this.radioButtonPin6Out.UseVisualStyleBackColor = true;
      this.radioButtonPin6Out.CheckedChanged += new EventHandler(this.radioButtonPin6Out_CheckedChanged);
      this.panel3.Controls.Add((Control) this.radioButtonPin5In);
      this.panel3.Controls.Add((Control) this.radioButtonPin5Out);
      this.panel3.Location = new Point(170, 167);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(60, 45);
      this.panel3.TabIndex = 34;
      this.radioButtonPin5In.AutoSize = true;
      this.radioButtonPin5In.Checked = true;
      this.radioButtonPin5In.Enabled = false;
      this.radioButtonPin5In.Location = new Point(3, 21);
      this.radioButtonPin5In.Name = "radioButtonPin5In";
      this.radioButtonPin5In.Size = new Size(49, 17);
      this.radioButtonPin5In.TabIndex = 1;
      this.radioButtonPin5In.TabStop = true;
      this.radioButtonPin5In.Text = "Input";
      this.radioButtonPin5In.UseVisualStyleBackColor = true;
      this.radioButtonPin5Out.AutoSize = true;
      this.radioButtonPin5Out.Enabled = false;
      this.radioButtonPin5Out.Location = new Point(3, 3);
      this.radioButtonPin5Out.Name = "radioButtonPin5Out";
      this.radioButtonPin5Out.Size = new Size(57, 17);
      this.radioButtonPin5Out.TabIndex = 0;
      this.radioButtonPin5Out.Text = "Output";
      this.radioButtonPin5Out.UseVisualStyleBackColor = true;
      this.radioButtonPin5Out.CheckedChanged += new EventHandler(this.radioButtonPin5Out_CheckedChanged);
      this.panel1.Controls.Add((Control) this.radioButtonPin4In);
      this.panel1.Controls.Add((Control) this.radioButtonPin4Out);
      this.panel1.Location = new Point(170, 101);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(60, 45);
      this.panel1.TabIndex = 33;
      this.radioButtonPin4In.AutoSize = true;
      this.radioButtonPin4In.Checked = true;
      this.radioButtonPin4In.Enabled = false;
      this.radioButtonPin4In.Location = new Point(3, 21);
      this.radioButtonPin4In.Name = "radioButtonPin4In";
      this.radioButtonPin4In.Size = new Size(49, 17);
      this.radioButtonPin4In.TabIndex = 1;
      this.radioButtonPin4In.TabStop = true;
      this.radioButtonPin4In.Text = "Input";
      this.radioButtonPin4In.UseVisualStyleBackColor = true;
      this.radioButtonPin4Out.AutoSize = true;
      this.radioButtonPin4Out.Enabled = false;
      this.radioButtonPin4Out.Location = new Point(3, 3);
      this.radioButtonPin4Out.Name = "radioButtonPin4Out";
      this.radioButtonPin4Out.Size = new Size(57, 17);
      this.radioButtonPin4Out.TabIndex = 0;
      this.radioButtonPin4Out.Text = "Output";
      this.radioButtonPin4Out.UseVisualStyleBackColor = true;
      this.radioButtonPin4Out.CheckedChanged += new EventHandler(this.radioButtonPin4Out_CheckedChanged);
      this.label30.AutoSize = true;
      this.label30.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label30.Location = new Point(167, 50);
      this.label30.Name = "label30";
      this.label30.Size = new Size(63, 13);
      this.label30.TabIndex = 32;
      this.label30.Text = "Output Only";
      this.label29.AutoSize = true;
      this.label29.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label29.Location = new Point(106, 243);
      this.label29.Name = "label29";
      this.label29.Size = new Size(49, 20);
      this.label29.TabIndex = 31;
      this.label29.Text = "Pin 6";
      this.label28.AutoSize = true;
      this.label28.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label28.Location = new Point(106, 177);
      this.label28.Name = "label28";
      this.label28.Size = new Size(49, 20);
      this.label28.TabIndex = 30;
      this.label28.Text = "Pin 5";
      this.label27.AutoSize = true;
      this.label27.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label27.Location = new Point(106, 111);
      this.label27.Name = "label27";
      this.label27.Size = new Size(49, 20);
      this.label27.TabIndex = 29;
      this.label27.Text = "Pin 4";
      this.label26.AutoSize = true;
      this.label26.Location = new Point(-3, 300);
      this.label26.Name = "label26";
      this.label26.Size = new Size(356, 26);
      this.label26.TabIndex = 28;
      this.label26.Text = "MASTER-PROG VDD pin MUST have a valid voltage (either sourced from MASTER-PROG\r\nor the target) or pins 4, 5, && 6 will not function.";
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label20.Location = new Point(106, 45);
      this.label20.Name = "label20";
      this.label20.Size = new Size(49, 20);
      this.label20.TabIndex = 27;
      this.label20.Text = "Pin 1";
      this.pictureBox2.Image = (Image) componentResourceManager.GetObject("pictureBox2.Image");
      this.pictureBox2.Location = new Point(0, 106);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(78, 116);
      this.pictureBox2.TabIndex = 26;
      this.pictureBox2.TabStop = false;
      this.timerIO.Tick += new EventHandler(this.timerIO_Tick);
      this.checkBoxVDD.AutoSize = true;
      this.checkBoxVDD.Location = new Point(12, 16);
      this.checkBoxVDD.Name = "checkBoxVDD";
      this.checkBoxVDD.Size = new Size(66, 17);
      this.checkBoxVDD.TabIndex = 34;
      this.checkBoxVDD.Text = "VDD On";
      this.checkBoxVDD.UseVisualStyleBackColor = true;
      this.checkBoxVDD.Click += new EventHandler(this.checkBoxVDD_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(634, 401);
      this.Controls.Add((Control) this.checkBoxVDD);
      this.Controls.Add((Control) this.panelLogicIO);
      this.Controls.Add((Control) this.buttonHelp);
      this.Controls.Add((Control) this.buttonExit);
      this.Controls.Add((Control) this.panelAnalyzer);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.panel2);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogLogic";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "MASTER-PROG Logic Tool";
      this.panel2.ResumeLayout(false);
      this.panelAnalyzer.ResumeLayout(false);
      this.panelAnalyzer.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.pictureBox1.EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBoxZoom.ResumeLayout(false);
      this.groupBoxZoom.PerformLayout();
      this.panelDisplay.ResumeLayout(false);
      this.pictureBoxDisplay.EndInit();
      this.panelLogicIO.ResumeLayout(false);
      this.panelLogicIO.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.pictureBox2.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public bool getModeAnalyzer()
    {
      return this.radioButtonAnalyzer.Checked;
    }

    public void setModeAnalyzer()
    {
      this.radioButtonLogicIO.Checked = false;
      this.radioButtonAnalyzer.Checked = true;
    }

    public int getZoom()
    {
      return this.lastZoomLevel;
    }

    public void setZoom(int zoom)
    {
      this.lastZoomLevel = zoom;
      if (zoom == 1)
        return;
      this.radioButtonZoom1x.Checked = false;
      if (zoom == 0)
        this.radioButtonZoom05.Checked = true;
      else if (zoom == 2)
        this.radioButton2x.Checked = true;
      else if (zoom == 3)
        this.radioButton4x.Checked = true;
      this.updateDisplay();
    }

    public int getCh1Trigger()
    {
      return this.comboBoxCh1Trig.SelectedIndex;
    }

    public void setCh1Trigger(int trig)
    {
      this.comboBoxCh1Trig.SelectedIndex = trig;
    }

    public int getCh2Trigger()
    {
      return this.comboBoxCh2Trig.SelectedIndex;
    }

    public void setCh2Trigger(int trig)
    {
      this.comboBoxCh2Trig.SelectedIndex = trig;
    }

    public int getCh3Trigger()
    {
      return this.comboBoxCh3Trig.SelectedIndex;
    }

    public void setCh3Trigger(int trig)
    {
      this.comboBoxCh3Trig.SelectedIndex = trig;
    }

    public int getTrigCount()
    {
      return int.Parse(this.textBox1.Text);
    }

    public void setTrigCount(int count)
    {
      this.textBox1.Text = count.ToString();
    }

    public int getSampleRate()
    {
      return this.comboBoxSampleRate.SelectedIndex;
    }

    public void setSampleRate(int rate)
    {
      this.comboBoxSampleRate.SelectedIndex = rate;
    }

    public int getTriggerPosition()
    {
      int num = 0;
      if (this.radioButtonTrigMid.Checked)
        num = 1;
      else if (this.radioButtonTrigEnd.Checked)
        num = 2;
      else if (this.radioButtonTrigDly1.Checked)
        num = 3;
      else if (this.radioButtonTrigDly2.Checked)
        num = 4;
      else if (this.radioButtonTrigDly3.Checked)
        num = 5;
      return num;
    }

    public void setTriggerPosition(int trigpos)
    {
      if (trigpos <= 0)
        return;
      this.radioButtonTrigStart.Checked = false;
      if (trigpos == 1)
        this.radioButtonTrigMid.Checked = true;
      else if (trigpos == 2)
        this.radioButtonTrigEnd.Checked = true;
      else if (trigpos == 3)
        this.radioButtonTrigDly1.Checked = true;
      else if (trigpos == 4)
        this.radioButtonTrigDly2.Checked = true;
      else if (trigpos == 5)
        this.radioButtonTrigDly3.Checked = true;
      this.updateDisplay();
    }

    public bool getCursorsEnabled()
    {
      return this.checkBoxCursors.Checked;
    }

    public void setCursorsEnabled(bool enable)
    {
      this.checkBoxCursors.Checked = enable;
    }

    public int getXCursorPos()
    {
      return this.cursor1Pos;
    }

    public void setXCursorPos(int pos)
    {
      this.cursor1Pos = pos;
      this.updateDisplay();
    }

    public int getYCursorPos()
    {
      return this.cursor2Pos;
    }

    public void setYCursorPos(int pos)
    {
      this.cursor2Pos = pos;
      this.updateDisplay();
    }

    public void SetVddBox(bool enable, bool check)
    {
      this.checkBoxVDD.Enabled = enable;
      this.checkBoxVDD.Checked = check;
    }

    private void updateDisplay()
    {
      Bitmap bitmap = this.drawSampleData(this.lastZoomLevel, this.lastTrigPos, this.firstSample);
      this.pictureBoxDisplay.Width = bitmap.Width;
      if (!this.checkBoxCursors.Checked)
        this.pictureBoxDisplay.Image = (Image) bitmap;
      this.lastDrawnDisplay = bitmap;
      this.updateDisplayCursors();
      float num = this.sampleRates[this.lastSampleRate] * 50f;
      if (this.lastZoomLevel == 0)
        num *= 2f;
      else if (this.lastZoomLevel == 2)
        num /= 2f;
      else if (this.lastZoomLevel == 3)
        num /= 4f;
      string str = "s";
      if ((double) num < 1.0 / 1000.0)
      {
        num *= 1000000f;
        str = "us";
      }
      else if ((double) num < 1.0)
      {
        num *= 1000f;
        str = "ms";
      }
      this.labelTimeScale.Text = string.Format("{0:G} ", (object) num) + str + " / Div";
    }

    private Bitmap drawSampleData(int zoom, int triggerPos, int startPos)
    {
      int height = 100;
      int width = 1;
      if (zoom == 0)
      {
        triggerPos /= 2;
        width = 0;
      }
      else if (zoom == 2)
      {
        triggerPos *= 2;
        width = 2;
      }
      else if (zoom == 3)
      {
        triggerPos *= 4;
        width = 4;
      }
      Bitmap displayGraph = this.getDisplayGraph(zoom);
      Graphics graphics = Graphics.FromImage((Image) displayGraph);
      SolidBrush solidBrush1 = new SolidBrush(Color.Red);
      graphics.FillRectangle((Brush) solidBrush1, triggerPos, 0, 1, height);
      graphics.FillRectangle((Brush) solidBrush1, triggerPos - 2, 4, 5, 2);
      graphics.FillRectangle((Brush) solidBrush1, triggerPos - 2, height - 5, 5, 2);
      if (this.lastTrigDelay > 0)
      {
        solidBrush1 = new SolidBrush(Color.White);
        Point[] points = new Point[3]
        {
          new Point(triggerPos - 4, 0),
          new Point(triggerPos - 4, 8),
          new Point(triggerPos - 9, 4)
        };
        graphics.FillPolygon((Brush) solidBrush1, points);
        float num = this.sampleRates[this.lastSampleRate] * 1000f * (float) this.lastTrigDelay;
        Font font = new Font(FontFamily.GenericSansSerif, 7f, FontStyle.Bold);
        string str = "s";
        if ((double) num < 1.0 / 1000.0)
        {
          num *= 1000000f;
          str = "us";
        }
        else if ((double) num < 1.0)
        {
          num *= 1000f;
          str = "ms";
        }
        graphics.DrawString(string.Format("DLY {0:G} ", (object) num) + str, font, (Brush) solidBrush1, (float) (triggerPos + 3), -2f);
        font.Dispose();
      }
      solidBrush1.Dispose();
      SolidBrush solidBrush2 = new SolidBrush(Color.YellowGreen);
      int x = 0;
      byte num1 = this.sampleArray[0];
      if (width > 0)
      {
        for (int index = 0; index < 1024; ++index)
        {
          if (((int) this.sampleArray[index] & 1 ^ (int) num1 & 1) > 0)
          {
            graphics.FillRectangle((Brush) solidBrush2, x, 10, 1, 20);
            if (width > 1)
            {
              if (((int) this.sampleArray[index] & 1) == 0)
                graphics.FillRectangle((Brush) solidBrush2, x + 1, 27, width - 1, 3);
              else
                graphics.FillRectangle((Brush) solidBrush2, x + 1, 10, width - 1, 1);
            }
          }
          else if (((int) this.sampleArray[index] & 1) == 0)
            graphics.FillRectangle((Brush) solidBrush2, x, 27, width, 3);
          else
            graphics.FillRectangle((Brush) solidBrush2, x, 10, width, 1);
          if (((int) this.sampleArray[index] & 2 ^ (int) num1 & 2) > 0)
          {
            graphics.FillRectangle((Brush) solidBrush2, x, 40, 1, 20);
            if (width > 1)
            {
              if (((int) this.sampleArray[index] & 2) == 0)
                graphics.FillRectangle((Brush) solidBrush2, x + 1, 57, width - 1, 3);
              else
                graphics.FillRectangle((Brush) solidBrush2, x + 1, 40, width - 1, 1);
            }
          }
          else if (((int) this.sampleArray[index] & 2) == 0)
            graphics.FillRectangle((Brush) solidBrush2, x, 57, width, 3);
          else
            graphics.FillRectangle((Brush) solidBrush2, x, 40, width, 1);
          if (((int) this.sampleArray[index] & 4 ^ (int) num1 & 4) > 0)
          {
            graphics.FillRectangle((Brush) solidBrush2, x, 70, 1, 20);
            if (width > 1)
            {
              if (((int) this.sampleArray[index] & 4) == 0)
                graphics.FillRectangle((Brush) solidBrush2, x + 1, 87, width - 1, 3);
              else
                graphics.FillRectangle((Brush) solidBrush2, x + 1, 70, width - 1, 1);
            }
          }
          else if (((int) this.sampleArray[index] & 4) == 0)
            graphics.FillRectangle((Brush) solidBrush2, x, 87, width, 3);
          else
            graphics.FillRectangle((Brush) solidBrush2, x, 70, width, 1);
          x += width;
          num1 = this.sampleArray[index];
        }
      }
      else
      {
        int index = 0;
        while (index < 1024)
        {
          if (((int) this.sampleArray[index] & 1 ^ (int) num1 & 1) > 0 || ((int) this.sampleArray[index + 1] & 1 ^ (int) num1 & 1) > 0)
            graphics.FillRectangle((Brush) solidBrush2, x, 10, 1, 20);
          else if (((int) this.sampleArray[index] & 1) == 0)
            graphics.FillRectangle((Brush) solidBrush2, x, 27, 1, 3);
          else
            graphics.FillRectangle((Brush) solidBrush2, x, 10, 1, 1);
          if (((int) this.sampleArray[index] & 2 ^ (int) num1 & 2) > 0 || ((int) this.sampleArray[index + 1] & 2 ^ (int) num1 & 2) > 0)
            graphics.FillRectangle((Brush) solidBrush2, x, 40, 1, 20);
          else if (((int) this.sampleArray[index] & 2) == 0)
            graphics.FillRectangle((Brush) solidBrush2, x, 57, 1, 3);
          else
            graphics.FillRectangle((Brush) solidBrush2, x, 40, 1, 1);
          if (((int) this.sampleArray[index] & 4 ^ (int) num1 & 4) > 0 || ((int) this.sampleArray[index + 1] & 4 ^ (int) num1 & 4) > 0)
            graphics.FillRectangle((Brush) solidBrush2, x, 70, 1, 20);
          else if (((int) this.sampleArray[index] & 4) == 0)
            graphics.FillRectangle((Brush) solidBrush2, x, 87, 1, 3);
          else
            graphics.FillRectangle((Brush) solidBrush2, x, 70, 1, 1);
          ++x;
          num1 = this.sampleArray[index + 1];
          index += 2;
        }
      }
      graphics.Dispose();
      solidBrush2.Dispose();
      return displayGraph;
    }

    private Bitmap getDisplayGraph(int zoom)
    {
      int width = 1024;
      int height = 100;
      if (zoom == 0)
        width = 512;
      else if (zoom == 2)
        width = 2048;
      else if (zoom == 3)
        width = 4096;
      Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format16bppRgb555);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      SolidBrush solidBrush1 = new SolidBrush(Color.Black);
      graphics.FillRectangle((Brush) solidBrush1, 0, 0, width, height);
      solidBrush1.Dispose();
      SolidBrush solidBrush2 = new SolidBrush(Color.DarkGray);
      int x1 = 0;
      while (x1 < width - 50)
      {
        graphics.FillRectangle((Brush) solidBrush2, x1, 0, 1, height);
        graphics.FillRectangle((Brush) solidBrush2, x1 + 10, height - 7, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x1 + 20, height - 7, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x1 + 30, height - 7, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x1 + 40, height - 7, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x1 + 10, 0, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x1 + 20, 0, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x1 + 30, 0, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x1 + 40, 0, 1, 7);
        x1 += 50;
      }
      int x2 = ((width - 50) / 50 + 1) * 50;
      if (x2 < width)
        graphics.FillRectangle((Brush) solidBrush2, x2, 0, 1, height);
      int x3 = x2 + 10;
      if (x3 < width)
      {
        graphics.FillRectangle((Brush) solidBrush2, x3, height - 7, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x3, 0, 1, 7);
      }
      int x4 = x3 + 10;
      if (x4 < width)
      {
        graphics.FillRectangle((Brush) solidBrush2, x4, height - 7, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x4, 0, 1, 7);
      }
      int x5 = x4 + 10;
      if (x5 < width)
      {
        graphics.FillRectangle((Brush) solidBrush2, x5, height - 7, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x5, 0, 1, 7);
      }
      int x6 = x5 + 10;
      if (x6 < width)
      {
        graphics.FillRectangle((Brush) solidBrush2, x6, height - 7, 1, 7);
        graphics.FillRectangle((Brush) solidBrush2, x6, 0, 1, 7);
      }
      solidBrush2.Dispose();
      graphics.Dispose();
      return bitmap;
    }

    private void radioButtonZoom05_Click(object sender, EventArgs e)
    {
      if (this.radioButtonZoom05.Checked)
      {
        if (this.lastZoomLevel == 1)
        {
          this.cursor1Pos /= 2;
          this.cursor2Pos /= 2;
        }
        else if (this.lastZoomLevel == 2)
        {
          this.cursor1Pos /= 4;
          this.cursor2Pos /= 4;
        }
        else if (this.lastZoomLevel == 3)
        {
          this.cursor1Pos /= 8;
          this.cursor2Pos /= 8;
        }
        this.lastZoomLevel = 0;
      }
      else if (this.radioButtonZoom1x.Checked)
      {
        if (this.lastZoomLevel == 0)
        {
          this.cursor1Pos *= 2;
          this.cursor2Pos *= 2;
        }
        else if (this.lastZoomLevel == 2)
        {
          this.cursor1Pos /= 2;
          this.cursor2Pos /= 2;
        }
        else if (this.lastZoomLevel == 3)
        {
          this.cursor1Pos /= 4;
          this.cursor2Pos /= 4;
        }
        this.lastZoomLevel = 1;
      }
      else if (this.radioButton2x.Checked)
      {
        if (this.lastZoomLevel == 0)
        {
          this.cursor1Pos *= 4;
          this.cursor2Pos *= 4;
        }
        else if (this.lastZoomLevel == 1)
        {
          this.cursor1Pos *= 2;
          this.cursor2Pos *= 2;
        }
        else if (this.lastZoomLevel == 3)
        {
          this.cursor1Pos /= 2;
          this.cursor2Pos /= 2;
        }
        this.lastZoomLevel = 2;
      }
      else if (this.radioButton4x.Checked)
      {
        if (this.lastZoomLevel == 0)
        {
          this.cursor1Pos *= 8;
          this.cursor2Pos *= 8;
        }
        else if (this.lastZoomLevel == 1)
        {
          this.cursor1Pos *= 4;
          this.cursor2Pos *= 4;
        }
        else if (this.lastZoomLevel == 2)
        {
          this.cursor1Pos *= 2;
          this.cursor2Pos *= 2;
        }
        this.lastZoomLevel = 3;
      }
      this.updateDisplay();
    }

    private void checkBoxCursors_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBoxCursors.Checked)
      {
        this.labelCursor1.Enabled = true;
        this.labelCursor1Val.Enabled = true;
        this.labelCursor2.Enabled = true;
        this.labelCursor2Val.Enabled = true;
        this.labelCursorDelta.Enabled = true;
        this.labelCursorDeltaVal.Enabled = true;
        this.updateDisplay();
      }
      else
      {
        this.labelCursor1.Enabled = false;
        this.labelCursor1Val.Enabled = false;
        this.labelCursor2.Enabled = false;
        this.labelCursor2Val.Enabled = false;
        this.labelCursorDelta.Enabled = false;
        this.labelCursorDeltaVal.Enabled = false;
        this.updateDisplay();
      }
    }

    private void pictureBoxDisplay_MouseDown(object sender, MouseEventArgs e)
    {
      if (this.checkBoxCursors.Checked)
      {
        if (e.Button == MouseButtons.Left)
          this.cursor1Pos = e.X;
        else if (e.Button == MouseButtons.Right)
          this.cursor2Pos = e.X;
      }
      this.updateDisplayCursors();
    }

    private void updateDisplayCursors()
    {
      if (!this.checkBoxCursors.Checked)
        return;
      int height = this.lastDrawnDisplay.Height;
      int width = 1;
      int num1 = this.cursor1Pos;
      int num2 = this.cursor2Pos;
      if (this.lastZoomLevel == 0)
      {
        num1 *= 2;
        num2 *= 2;
      }
      else if (this.lastZoomLevel == 2)
      {
        width = 2;
        num1 /= 2;
        num2 /= 2;
        this.cursor1Pos -= this.cursor1Pos % 2;
        this.cursor2Pos -= this.cursor2Pos % 2;
      }
      else if (this.lastZoomLevel == 3)
      {
        width = 4;
        num1 /= 4;
        num2 /= 4;
        this.cursor1Pos -= this.cursor1Pos % 4;
        this.cursor2Pos -= this.cursor2Pos % 4;
      }
      Bitmap bitmap = (Bitmap) ((Image) this.lastDrawnDisplay).Clone();
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      Font font = new Font(FontFamily.GenericSansSerif, 7f);
      SolidBrush solidBrush1 = new SolidBrush(Color.DodgerBlue);
      graphics.FillRectangle((Brush) solidBrush1, this.cursor1Pos, 0, width, height);
      graphics.DrawString("X", font, (Brush) solidBrush1, (float) (this.cursor1Pos - 10), 29f);
      float num3 = (float) (num1 - this.lastTrigPos) * this.sampleRates[this.lastSampleRate] + this.sampleRates[this.lastSampleRate] * 1000f * (float) this.lastTrigDelay;
      string str1 = "s";
      int decimals = 3;
      if ((double) Math.Abs(num3) < 1.0 / 1000.0)
      {
        num3 *= 1000000f;
        str1 = "us";
        decimals = 0;
      }
      else if ((double) Math.Abs(num3) < 1.0)
      {
        num3 *= 1000f;
        str1 = "ms";
      }
      this.labelCursor1Val.Text = string.Format("{0:G} ", (object) Math.Round((Decimal) num3, decimals)) + str1;
      SolidBrush solidBrush2 = new SolidBrush(Color.MediumOrchid);
      graphics.FillRectangle((Brush) solidBrush2, this.cursor2Pos, 0, width, height);
      graphics.DrawString("Y", font, (Brush) solidBrush2, (float) (this.cursor2Pos + width + 2), 29f);
      float num4 = (float) (num2 - this.lastTrigPos) * this.sampleRates[this.lastSampleRate] + this.sampleRates[this.lastSampleRate] * 1000f * (float) this.lastTrigDelay;
      string str2 = "s";
      int num5 = 3;
      if ((double) Math.Abs(num4) < 1.0 / 1000.0)
      {
        num4 *= 1000000f;
        str2 = "us";
        num5 = 0;
      }
      else if ((double) Math.Abs(num4) < 1.0)
      {
        num4 *= 1000f;
        str2 = "ms";
      }
      this.labelCursor2Val.Text = string.Format("{0:G} ", (object) Math.Round((Decimal) num4, 3)) + str2;
      this.pictureBoxDisplay.Image = (Image) bitmap;
      float num6 = (float) (num2 - num1) * this.sampleRates[this.lastSampleRate];
      float num7 = 0.0f;
      if ((double) Math.Abs(num6) > 0.0)
        num7 = Math.Abs(1f / num6);
      string str3 = "s";
      if ((double) Math.Abs(num6) < 1.0 / 1000.0)
      {
        num6 *= 1000000f;
        str3 = "us";
      }
      else if ((double) Math.Abs(num6) < 1.0)
      {
        num6 *= 1000f;
        str3 = "ms";
      }
      string str4 = "Hz)";
      if ((double) num7 >= 10000.0)
      {
        num7 /= 1000f;
        str4 = "kHz)";
      }
      this.labelCursorDeltaVal.Text = string.Format("{0:G} ", (object) Math.Round((Decimal) num6, 2)) + str3 + string.Format(" ({0:G} ", (object) Math.Round((Decimal) num7, 2)) + str4;
      solidBrush2.Dispose();
      graphics.Dispose();
    }

    private void comboBoxCh1Trig_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboBoxCh1Trig.SelectedIndex > 2 && this.comboBoxCh2Trig.SelectedIndex > 2 && this.comboBoxCh1Trig.SelectedIndex != this.comboBoxCh2Trig.SelectedIndex)
      {
        int num = (int) MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
        this.comboBoxCh1Trig.SelectedIndex = 0;
      }
      if (this.comboBoxCh1Trig.SelectedIndex <= 2 || this.comboBoxCh3Trig.SelectedIndex <= 2 || this.comboBoxCh1Trig.SelectedIndex == this.comboBoxCh3Trig.SelectedIndex)
        return;
      int num1 = (int) MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
      this.comboBoxCh1Trig.SelectedIndex = 0;
    }

    private void comboBoxCh2Trig_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboBoxCh1Trig.SelectedIndex > 2 && this.comboBoxCh2Trig.SelectedIndex > 2 && this.comboBoxCh1Trig.SelectedIndex != this.comboBoxCh2Trig.SelectedIndex)
      {
        int num = (int) MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
        this.comboBoxCh2Trig.SelectedIndex = 0;
      }
      if (this.comboBoxCh2Trig.SelectedIndex <= 2 || this.comboBoxCh3Trig.SelectedIndex <= 2 || this.comboBoxCh2Trig.SelectedIndex == this.comboBoxCh3Trig.SelectedIndex)
        return;
      int num1 = (int) MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
      this.comboBoxCh2Trig.SelectedIndex = 0;
    }

    private void comboBoxCh3Trig_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboBoxCh1Trig.SelectedIndex > 2 && this.comboBoxCh3Trig.SelectedIndex > 2 && this.comboBoxCh1Trig.SelectedIndex != this.comboBoxCh3Trig.SelectedIndex)
      {
        int num = (int) MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
        this.comboBoxCh3Trig.SelectedIndex = 0;
      }
      if (this.comboBoxCh2Trig.SelectedIndex <= 2 || this.comboBoxCh3Trig.SelectedIndex <= 2 || this.comboBoxCh2Trig.SelectedIndex == this.comboBoxCh3Trig.SelectedIndex)
        return;
      int num1 = (int) MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
      this.comboBoxCh3Trig.SelectedIndex = 0;
    }

    private void textBox1_Leave(object sender, EventArgs e)
    {
      uint num = uint.Parse(this.textBox1.Text);
      if ((int) num == 0)
        num = 1U;
      if (num > 256U)
        num = 256U;
      this.textBox1.Text = num.ToString();
    }

    private void comboBoxSampleRate_SelectedIndexChanged(object sender, EventArgs e)
    {
      float num = 0.5f / this.sampleRates[this.comboBoxSampleRate.SelectedIndex];
      string str = "Hz";
      if ((double) num >= 10000.0)
      {
        num /= 1000f;
        str = "kHz";
      }
      this.labelAliasFreq.Text = string.Format("NOTE: Signals greater than {0:G} ", (object) Math.Round((Decimal) num, 1)) + str + " will alias.";
    }

    private void buttonRun_Click(object sender, EventArgs e)
    {
      if (this.comboBoxCh1Trig.SelectedIndex == 0 && this.comboBoxCh2Trig.SelectedIndex == 0 && this.comboBoxCh3Trig.SelectedIndex == 0)
      {
        int num1 = (int) MessageBox.Show("At least one trigger condition\n must be defined.\n\nAll are set to Don't Care.", "MASTER-PROG Logic Tool");
      }
      else
      {
        byte num2 = (byte) 1;
        if (this.comboBoxCh1Trig.SelectedIndex == 4 || this.comboBoxCh2Trig.SelectedIndex == 4 || this.comboBoxCh3Trig.SelectedIndex == 4)
          num2 = (byte) 0;
        byte num3 = (byte) 0;
        if (this.comboBoxCh1Trig.SelectedIndex > 0)
          num3 |= (byte) 4;
        if (this.comboBoxCh2Trig.SelectedIndex > 0)
          num3 |= (byte) 8;
        if (this.comboBoxCh3Trig.SelectedIndex > 0)
          num3 |= (byte) 16;
        byte num4 = (byte) 0;
        if (this.comboBoxCh1Trig.SelectedIndex == 1 || this.comboBoxCh1Trig.SelectedIndex == 3)
          num4 |= (byte) 4;
        if (this.comboBoxCh2Trig.SelectedIndex == 1 || this.comboBoxCh2Trig.SelectedIndex == 3)
          num4 |= (byte) 8;
        if (this.comboBoxCh3Trig.SelectedIndex == 1 || this.comboBoxCh3Trig.SelectedIndex == 3)
          num4 |= (byte) 16;
        byte num5 = (byte) 0;
        if (this.comboBoxCh1Trig.SelectedIndex == 4 || this.comboBoxCh1Trig.SelectedIndex == 3)
          num5 |= (byte) 4;
        if (this.comboBoxCh2Trig.SelectedIndex == 4 || this.comboBoxCh2Trig.SelectedIndex == 3)
          num5 |= (byte) 8;
        if (this.comboBoxCh3Trig.SelectedIndex == 4 || this.comboBoxCh3Trig.SelectedIndex == 3)
          num5 |= (byte) 16;
        byte num6 = byte.Parse(this.textBox1.Text);
        this.postTrigCount = 2;
        if (this.radioButtonTrigStart.Checked)
          this.postTrigCount = 973;
        else if (this.radioButtonTrigMid.Checked)
          this.postTrigCount = 523;
        else if (this.radioButtonTrigEnd.Checked)
          this.postTrigCount = 73;
        else if (this.radioButtonTrigDly1.Checked)
          this.postTrigCount = 1973;
        else if (this.radioButtonTrigDly2.Checked)
          this.postTrigCount = 2973;
        else if (this.radioButtonTrigDly3.Checked)
          this.postTrigCount = 3973;
        this.trigDialog = new DialogTrigger();
        this.AddOwnedForm((Form) this.trigDialog);
        ((Control) this.trigDialog).Show();
        byte[] commandList = new byte[9];
        int num7 = 0;
        byte[] numArray1 = commandList;
        int index1 = num7;
        int num8 = 1;
        int num9 = index1 + num8;
        int num10 = 184;
        numArray1[index1] = (byte) num10;
        byte[] numArray2 = commandList;
        int index2 = num9;
        int num11 = 1;
        int num12 = index2 + num11;
        int num13 = (int) num2;
        numArray2[index2] = (byte) num13;
        byte[] numArray3 = commandList;
        int index3 = num12;
        int num14 = 1;
        int num15 = index3 + num14;
        int num16 = (int) num3;
        numArray3[index3] = (byte) num16;
        byte[] numArray4 = commandList;
        int index4 = num15;
        int num17 = 1;
        int num18 = index4 + num17;
        int num19 = (int) num4;
        numArray4[index4] = (byte) num19;
        byte[] numArray5 = commandList;
        int index5 = num18;
        int num20 = 1;
        int num21 = index5 + num20;
        int num22 = (int) num5;
        numArray5[index5] = (byte) num22;
        byte[] numArray6 = commandList;
        int index6 = num21;
        int num23 = 1;
        int num24 = index6 + num23;
        int num25 = (int) num6;
        numArray6[index6] = (byte) num25;
        byte[] numArray7 = commandList;
        int index7 = num24;
        int num26 = 1;
        int num27 = index7 + num26;
        int num28 = (int) (byte) (this.postTrigCount - 1 & (int) byte.MaxValue);
        numArray7[index7] = (byte) num28;
        byte[] numArray8 = commandList;
        int index8 = num27;
        int num29 = 1;
        int num30 = index8 + num29;
        int num31 = (int) (byte) (this.postTrigCount - 1 >> 8 & (int) byte.MaxValue);
        numArray8[index8] = (byte) num31;
        byte[] numArray9 = commandList;
        int index9 = num30;
        int num32 = 1;
        int num33 = index9 + num32;
        int num34 = (int) this.sampleFactors[this.comboBoxSampleRate.SelectedIndex];
        numArray9[index9] = (byte) num34;
        ProgCommand.writeUSB(commandList);
        this.timerRun.Enabled = true;
      }
    }

    private void timerRun_Tick(object sender, EventArgs e)
    {
      this.timerRun.Enabled = false;
      bool flag1 = ProgCommand.readUSB();
      Thread.Sleep(250);
      this.RemoveOwnedForm((Form) this.trigDialog);
      this.trigDialog.Close();
      if (!flag1)
        return;
      int num1 = (int) ProgCommand.Usb_read_array[1] + (int) ProgCommand.Usb_read_array[2] * 256;
      if ((num1 & 16384) > 0)
        return;
      this.lastSampleRate = this.comboBoxSampleRate.SelectedIndex;
      bool flag2 = (num1 & 32768) > 0;
      int num2 = (num1 & 4095) + 1;
      if (num2 == 2048)
        num2 = 1536;
      int num3 = num2 - 1536;
      byte[] numArray1 = new byte[512];
      byte[] commandList = new byte[3];
      int num4 = 0;
      byte[] numArray2 = commandList;
      int index1 = num4;
      int num5 = 1;
      int num6 = index1 + num5;
      int num7 = 185;
      numArray2[index1] = (byte) num7;
      byte[] numArray3 = commandList;
      int index2 = num6;
      int num8 = 1;
      int num9 = index2 + num8;
      int num10 = 0;
      numArray3[index2] = (byte) num10;
      byte[] numArray4 = commandList;
      int index3 = num9;
      int num11 = 1;
      int num12 = index3 + num11;
      int num13 = 6;
      numArray4[index3] = (byte) num13;
      ProgCommand.writeUSB(commandList);
      ProgCommand.UploadDataNoLen();
      Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
      ProgCommand.UploadDataNoLen();
      Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
      int num14 = 0;
      byte[] numArray5 = commandList;
      int index4 = num14;
      int num15 = 1;
      int num16 = index4 + num15;
      int num17 = 185;
      numArray5[index4] = (byte) num17;
      byte[] numArray6 = commandList;
      int index5 = num16;
      int num18 = 1;
      int num19 = index5 + num18;
      int num20 = 128;
      numArray6[index5] = (byte) num20;
      byte[] numArray7 = commandList;
      int index6 = num19;
      int num21 = 1;
      num12 = index6 + num21;
      int num22 = 6;
      numArray7[index6] = (byte) num22;
      ProgCommand.writeUSB(commandList);
      ProgCommand.UploadDataNoLen();
      Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 128L, 64L);
      ProgCommand.UploadDataNoLen();
      Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 192L, 64L);
      int num23 = 0;
      byte[] numArray8 = commandList;
      int index7 = num23;
      int num24 = 1;
      int num25 = index7 + num24;
      int num26 = 185;
      numArray8[index7] = (byte) num26;
      byte[] numArray9 = commandList;
      int index8 = num25;
      int num27 = 1;
      int num28 = index8 + num27;
      int num29 = 0;
      numArray9[index8] = (byte) num29;
      byte[] numArray10 = commandList;
      int index9 = num28;
      int num30 = 1;
      num12 = index9 + num30;
      int num31 = 7;
      numArray10[index9] = (byte) num31;
      ProgCommand.writeUSB(commandList);
      ProgCommand.UploadDataNoLen();
      Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 256L, 64L);
      ProgCommand.UploadDataNoLen();
      Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 320L, 64L);
      int num32 = 0;
      byte[] numArray11 = commandList;
      int index10 = num32;
      int num33 = 1;
      int num34 = index10 + num33;
      int num35 = 185;
      numArray11[index10] = (byte) num35;
      byte[] numArray12 = commandList;
      int index11 = num34;
      int num36 = 1;
      int num37 = index11 + num36;
      int num38 = 128;
      numArray12[index11] = (byte) num38;
      byte[] numArray13 = commandList;
      int index12 = num37;
      int num39 = 1;
      num12 = index12 + num39;
      int num40 = 7;
      numArray13[index12] = (byte) num40;
      ProgCommand.writeUSB(commandList);
      ProgCommand.UploadDataNoLen();
      Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 384L, 64L);
      ProgCommand.UploadDataNoLen();
      Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 448L, 64L);
      this.lastTrigPos = 1023 - this.postTrigCount % 1000;
      this.lastTrigDelay = this.postTrigCount / 1000;
      int num41 = num3 + (this.lastTrigPos / 2 + this.postTrigCount / 1000 * 12);
      if (this.lastTrigPos % 2 > 0)
      {
        flag2 = !flag2;
        if (flag2)
          ++num41;
      }
      int index13 = num41 % 512;
      for (int index14 = 0; index14 < this.sampleArray.Length; ++index14)
      {
        byte num42 = numArray1[index13];
        if (flag2)
        {
          --index13;
          if (index13 < 0)
            index13 += 512;
          num42 = (byte) (((int) num42 >> 4) + ((int) num42 << 4));
        }
        byte num43 = (byte) ((uint) num42 & 28U);
        this.sampleArray[index14] = (byte) ((uint) num43 >> 2);
        flag2 = !flag2;
      }
      this.sampleArray[0] = this.sampleArray[1];
      this.updateDisplay();
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      Bitmap bitmap = (Bitmap) this.pictureBoxDisplay.Image.Clone();
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      Font font = new Font(FontFamily.GenericSansSerif, 7f, FontStyle.Bold);
      SolidBrush solidBrush = new SolidBrush(Color.White);
      graphics.DrawString(this.labelTimeScale.Text, font, (Brush) solidBrush, 5f, 88f);
      if (this.checkBoxCursors.Checked)
      {
        graphics.DrawString("X=" + this.labelCursor1Val.Text, font, (Brush) solidBrush, 100f, 88f);
        graphics.DrawString("Y=" + this.labelCursor2Val.Text, font, (Brush) solidBrush, 200f, 88f);
      }
      int num = (int) this.saveFileDialogDisplay.ShowDialog();
      try
      {
        bitmap.Save(this.saveFileDialogDisplay.FileName);
      }
      catch
      {
      }
      graphics.Dispose();
      solidBrush.Dispose();
      font.Dispose();
      bitmap.Dispose();
    }

    private void buttonExit_Click(object sender, EventArgs e)
    {
      this.checkBoxIOEnable.Checked = false;
      this.Close();
    }

    private void radioButtonAnalyzer_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButtonLogicIO.Checked)
      {
        this.panelLogicIO.Visible = true;
        this.panelAnalyzer.Visible = false;
      }
      else
      {
        this.panelLogicIO.Visible = false;
        this.checkBoxIOEnable.Checked = false;
        this.panelAnalyzer.Visible = true;
      }
    }

    private void initLogicIO()
    {
      this.radioButtonPin4In.Checked = true;
      this.radioButtonPin5In.Checked = true;
      this.radioButtonPin6In.Checked = true;
      this.textBoxPin1Out.Enabled = true;
      this.textBoxPin1Out.Text = "0";
      this.textBoxPin1Out.BackColor = Color.DarkRed;
      this.labelOut1Click.Visible = true;
      this.textBoxPin4In.Enabled = true;
      this.textBoxPin4In.Text = "0";
      this.textBoxPin4In.BackColor = Color.DarkBlue;
      this.textBoxPin4Out.Enabled = false;
      this.textBoxPin4Out.Text = "0";
      this.textBoxPin4Out.BackColor = SystemColors.Control;
      this.labelOut4Click.Visible = false;
      this.textBoxPin5In.Enabled = true;
      this.textBoxPin5In.Text = "0";
      this.textBoxPin5In.BackColor = Color.DarkBlue;
      this.textBoxPin5Out.Enabled = false;
      this.textBoxPin5Out.Text = "0";
      this.textBoxPin5Out.BackColor = SystemColors.Control;
      this.labelOut5Click.Visible = false;
      this.textBoxPin6In.Enabled = true;
      this.textBoxPin6In.Text = "0";
      this.textBoxPin6In.BackColor = Color.DarkBlue;
      this.textBoxPin6Out.Enabled = false;
      this.textBoxPin6Out.Text = "0";
      this.textBoxPin6Out.BackColor = SystemColors.Control;
      this.labelOut6Click.Visible = false;
    }

    private void textBoxPin1Out_Click(object sender, EventArgs e)
    {
      this.pinOut(this.textBoxPin1Out);
    }

    private void textBoxPin4Out_Click(object sender, EventArgs e)
    {
      this.pinOut(this.textBoxPin4Out);
    }

    private void textBoxPin5Out_Click(object sender, EventArgs e)
    {
      this.pinOut(this.textBoxPin5Out);
    }

    private void textBoxPin6Out_Click(object sender, EventArgs e)
    {
      this.pinOut(this.textBoxPin6Out);
    }

    private void pinOut(TextBox textBoxObject)
    {
      if (this.checkBoxIOEnable.Checked)
      {
        if (!textBoxObject.Enabled)
          return;
        if (textBoxObject.Text == "0")
        {
          textBoxObject.Text = "1";
          textBoxObject.BackColor = Color.Red;
        }
        else
        {
          textBoxObject.Text = "0";
          textBoxObject.BackColor = Color.DarkRed;
        }
        this.updateOutputs();
      }
      else
      {
        int num = (int) MessageBox.Show("Click the 'Enable IO' button\n to use the Logic IO.", "MASTER-PROG Logic Tool");
      }
    }

    private void checkBoxIOEnable_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBoxIOEnable.Checked)
      {
        if (!this.initLogicPins())
        {
          int num = (int) MessageBox.Show("No valid voltage detected on\nPICkit 2 VDD pin.\n\nA valid voltage (2.5V to 5.0V)\nis required for the Logic IO.", "MASTER-PROG Logic Tool");
          this.checkBoxIOEnable.Checked = false;
        }
        else
        {
          this.vddOn = ProgCommand.PowerStatus() == Constants.PICkit2PWR.vdd_on;
          this.radioButtonPin4In.Enabled = true;
          this.radioButtonPin4Out.Enabled = true;
          this.radioButtonPin5In.Enabled = true;
          this.radioButtonPin5Out.Enabled = true;
          this.radioButtonPin6In.Enabled = true;
          this.radioButtonPin6Out.Enabled = true;
          this.updateOutputs();
          this.timerIO.Enabled = true;
        }
      }
      else
      {
        this.timerIO.Enabled = false;
        this.radioButtonPin4In.Enabled = false;
        this.radioButtonPin4Out.Enabled = false;
        this.radioButtonPin5In.Enabled = false;
        this.radioButtonPin5Out.Enabled = false;
        this.radioButtonPin6In.Enabled = false;
        this.radioButtonPin6Out.Enabled = false;
        this.exitLogicIO();
      }
    }

    private void radioButtonPin4Out_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButtonPin4Out.Checked)
      {
        this.textBoxPin4In.Text = "";
        this.textBoxPin4In.BackColor = SystemColors.Control;
        this.textBoxPin4In.Enabled = false;
        this.textBoxPin4Out.Enabled = true;
        if (this.textBoxPin4Out.Text == "0")
          this.textBoxPin4Out.BackColor = Color.DarkRed;
        else
          this.textBoxPin4Out.BackColor = Color.Red;
        this.labelOut4Click.Visible = true;
      }
      else
      {
        this.textBoxPin4In.Enabled = true;
        this.textBoxPin4In.Text = "0";
        this.textBoxPin4In.BackColor = Color.DarkBlue;
        this.textBoxPin4Out.Enabled = false;
        this.textBoxPin4Out.BackColor = SystemColors.Control;
        this.labelOut4Click.Visible = false;
      }
      this.updateOutputs();
    }

    private void radioButtonPin5Out_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButtonPin5Out.Checked)
      {
        this.textBoxPin5In.Text = "";
        this.textBoxPin5In.BackColor = SystemColors.Control;
        this.textBoxPin5In.Enabled = false;
        this.textBoxPin5Out.Enabled = true;
        if (this.textBoxPin5Out.Text == "0")
          this.textBoxPin5Out.BackColor = Color.DarkRed;
        else
          this.textBoxPin5Out.BackColor = Color.Red;
        this.labelOut5Click.Visible = true;
      }
      else
      {
        this.textBoxPin5In.Enabled = true;
        this.textBoxPin5In.Text = "0";
        this.textBoxPin5In.BackColor = Color.DarkBlue;
        this.textBoxPin5Out.Enabled = false;
        this.textBoxPin5Out.BackColor = SystemColors.Control;
        this.labelOut5Click.Visible = false;
      }
      this.updateOutputs();
    }

    private void radioButtonPin6Out_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButtonPin6Out.Checked)
      {
        this.textBoxPin6In.Text = "";
        this.textBoxPin6In.BackColor = SystemColors.Control;
        this.textBoxPin6In.Enabled = false;
        this.textBoxPin6Out.Enabled = true;
        if (this.textBoxPin6Out.Text == "0")
          this.textBoxPin6Out.BackColor = Color.DarkRed;
        else
          this.textBoxPin6Out.BackColor = Color.Red;
        this.labelOut6Click.Visible = true;
      }
      else
      {
        this.textBoxPin6In.Enabled = true;
        this.textBoxPin6In.Text = "0";
        this.textBoxPin6In.BackColor = Color.DarkBlue;
        this.textBoxPin6Out.Enabled = false;
        this.textBoxPin6Out.BackColor = SystemColors.Control;
        this.labelOut6Click.Visible = false;
      }
      this.updateOutputs();
    }

    private bool initLogicPins()
    {
      float vdd = 0.0f;
      float vpp = 0.0f;
      if (!ProgCommand.ReadPICkitVoltages(ref vdd, ref vpp) || (double) vdd < 2.5)
        return false;
      ProgCommand.SetVppVoltage(vdd, 0.7f);
      ProgCommand.SetVDDVoltage(vdd, 0.85f);
      byte[] commandList = new byte[11];
      int num1 = 0;
      byte[] numArray1 = commandList;
      int index1 = num1;
      int num2 = 1;
      int num3 = index1 + num2;
      int num4 = 166;
      numArray1[index1] = (byte) num4;
      byte[] numArray2 = commandList;
      int index2 = num3;
      int num5 = 1;
      int num6 = index2 + num5;
      int num7 = 9;
      numArray2[index2] = (byte) num7;
      byte[] numArray3 = commandList;
      int index3 = num6;
      int num8 = 1;
      int num9 = index3 + num8;
      int num10 = 250;
      numArray3[index3] = (byte) num10;
      byte[] numArray4 = commandList;
      int index4 = num9;
      int num11 = 1;
      int num12 = index4 + num11;
      int num13 = 247;
      numArray4[index4] = (byte) num13;
      byte[] numArray5 = commandList;
      int index5 = num12;
      int num14 = 1;
      int num15 = index5 + num14;
      int num16 = 249;
      numArray5[index5] = (byte) num16;
      byte[] numArray6 = commandList;
      int index6 = num15;
      int num17 = 1;
      int num18 = index6 + num17;
      int num19 = 243;
      numArray6[index6] = (byte) num19;
      byte[] numArray7 = commandList;
      int index7 = num18;
      int num20 = 1;
      int num21 = index7 + num20;
      int num22 = 3;
      numArray7[index7] = (byte) num22;
      byte[] numArray8 = commandList;
      int index8 = num21;
      int num23 = 1;
      int num24 = index8 + num23;
      int num25 = 207;
      numArray8[index8] = (byte) num25;
      byte[] numArray9 = commandList;
      int index9 = num24;
      int num26 = 1;
      int num27 = index9 + num26;
      int num28 = 1;
      numArray9[index9] = (byte) num28;
      byte[] numArray10 = commandList;
      int index10 = num27;
      int num29 = 1;
      int num30 = index10 + num29;
      int num31 = 232;
      numArray10[index10] = (byte) num31;
      byte[] numArray11 = commandList;
      int index11 = num30;
      int num32 = 1;
      int num33 = index11 + num32;
      int num34 = 20;
      numArray11[index11] = (byte) num34;
      return ProgCommand.writeUSB(commandList);
    }

    private bool exitLogicIO()
    {
      byte[] commandList = new byte[9];
      int num1 = 0;
      byte[] numArray1 = commandList;
      int index1 = num1;
      int num2 = 1;
      int num3 = index1 + num2;
      int num4 = 166;
      numArray1[index1] = (byte) num4;
      byte[] numArray2 = commandList;
      int index2 = num3;
      int num5 = 1;
      int num6 = index2 + num5;
      int num7 = 7;
      numArray2[index2] = (byte) num7;
      byte[] numArray3 = commandList;
      int index3 = num6;
      int num8 = 1;
      int num9 = index3 + num8;
      int num10 = 250;
      numArray3[index3] = (byte) num10;
      byte[] numArray4 = commandList;
      int index4 = num9;
      int num11 = 1;
      int num12 = index4 + num11;
      int num13 = 247;
      numArray4[index4] = (byte) num13;
      byte[] numArray5 = commandList;
      int index5 = num12;
      int num14 = 1;
      int num15 = index5 + num14;
      int num16 = 248;
      numArray5[index5] = (byte) num16;
      byte[] numArray6 = commandList;
      int index6 = num15;
      int num17 = 1;
      int num18 = index6 + num17;
      int num19 = 243;
      numArray6[index6] = (byte) num19;
      byte[] numArray7 = commandList;
      int index7 = num18;
      int num20 = 1;
      int num21 = index7 + num20;
      int num22 = 3;
      numArray7[index7] = (byte) num22;
      byte[] numArray8 = commandList;
      int index8 = num21;
      int num23 = 1;
      int num24 = index8 + num23;
      int num25 = 207;
      numArray8[index8] = (byte) num25;
      byte[] numArray9 = commandList;
      int index9 = num24;
      int num26 = 1;
      int num27 = index9 + num26;
      int num28 = 1;
      numArray9[index9] = (byte) num28;
      return ProgCommand.writeUSB(commandList);
    }

    private bool updateOutputs()
    {
      byte num1 = (byte) 3;
      byte num2 = (byte) 1;
      if (this.radioButtonPin4Out.Checked)
      {
        num1 &= (byte) 253;
        if (this.textBoxPin4Out.Text == "1")
          num1 |= (byte) 8;
      }
      if (this.radioButtonPin5Out.Checked)
      {
        num1 &= (byte) 254;
        if (this.textBoxPin5Out.Text == "1")
          num1 |= (byte) 4;
      }
      if (this.radioButtonPin6Out.Checked)
      {
        num2 = (byte) 0;
        if (this.textBoxPin6Out.Text == "1")
          num2 = (byte) 2;
      }
      byte[] commandList = new byte[8];
      int num3 = 0;
      byte[] numArray1 = commandList;
      int index1 = num3;
      int num4 = 1;
      int num5 = index1 + num4;
      int num6 = 166;
      numArray1[index1] = (byte) num6;
      byte[] numArray2 = commandList;
      int index2 = num5;
      int num7 = 1;
      int num8 = index2 + num7;
      int num9 = 6;
      numArray2[index2] = (byte) num9;
      int num10;
      if (this.textBoxPin1Out.Text == "0")
      {
        byte[] numArray3 = commandList;
        int index3 = num8;
        int num11 = 1;
        int num12 = index3 + num11;
        int num13 = 250;
        numArray3[index3] = (byte) num13;
        byte[] numArray4 = commandList;
        int index4 = num12;
        int num14 = 1;
        num10 = index4 + num14;
        int num15 = 247;
        numArray4[index4] = (byte) num15;
      }
      else
      {
        byte[] numArray3 = commandList;
        int index3 = num8;
        int num11 = 1;
        int num12 = index3 + num11;
        int num13 = 246;
        numArray3[index3] = (byte) num13;
        byte[] numArray4 = commandList;
        int index4 = num12;
        int num14 = 1;
        num10 = index4 + num14;
        int num15 = 251;
        numArray4[index4] = (byte) num15;
      }
      byte[] numArray5 = commandList;
      int index5 = num10;
      int num16 = 1;
      int num17 = index5 + num16;
      int num18 = 243;
      numArray5[index5] = (byte) num18;
      byte[] numArray6 = commandList;
      int index6 = num17;
      int num19 = 1;
      int num20 = index6 + num19;
      int num21 = (int) num1;
      numArray6[index6] = (byte) num21;
      byte[] numArray7 = commandList;
      int index7 = num20;
      int num22 = 1;
      int num23 = index7 + num22;
      int num24 = 207;
      numArray7[index7] = (byte) num24;
      byte[] numArray8 = commandList;
      int index8 = num23;
      int num25 = 1;
      int num26 = index8 + num25;
      int num27 = (int) num2;
      numArray8[index8] = (byte) num27;
      return ProgCommand.writeUSB(commandList);
    }

    public void DialogLogic_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!this.panelLogicIO.Visible || !this.checkBoxIOEnable.Checked)
        return;
      if ((int) e.KeyChar == 97 || (int) e.KeyChar == 65)
        this.pinOut(this.textBoxPin1Out);
      else if ((int) e.KeyChar == 115 || (int) e.KeyChar == 83)
        this.pinOut(this.textBoxPin4Out);
      else if ((int) e.KeyChar == 100 || (int) e.KeyChar == 68)
      {
        this.pinOut(this.textBoxPin5Out);
      }
      else
      {
        if ((int) e.KeyChar != 102 && (int) e.KeyChar != 70)
          return;
        this.pinOut(this.textBoxPin6Out);
      }
    }

    private void timerIO_Tick(object sender, EventArgs e)
    {
      switch (ProgCommand.PowerStatus())
      {
        case Constants.PICkit2PWR.vdderror:
        case Constants.PICkit2PWR.vddvpperrors:
          int num1 = (int) MessageBox.Show("MASTER-PROG VDD voltage level error.\nVDD shut off: Disabling IO", "  ¡ERROR DETECTADO!");
          this.checkBoxIOEnable.Checked = false;
          return;
        case Constants.PICkit2PWR.vpperror:
          if (this.vddOn)
          {
            int num2 = (int) MessageBox.Show("Voltage error on Pin 1:\nVDD was shut off.\n\nDisabling IO", "  ¡ERROR DETECTADO!");
            this.checkBoxIOEnable.Checked = false;
            return;
          }
          else
          {
            int num2 = (int) MessageBox.Show("Voltage error on Pin 1:\nState reset to '0'", "  ¡ERROR DETECTADO!");
            this.textBoxPin1Out.Text = "0";
            this.textBoxPin1Out.BackColor = Color.DarkRed;
            break;
          }
      }
      byte[] commandList = new byte[5];
      int num3 = 0;
      byte[] numArray1 = commandList;
      int index1 = num3;
      int num4 = 1;
      int num5 = index1 + num4;
      int num6 = 166;
      numArray1[index1] = (byte) num6;
      byte[] numArray2 = commandList;
      int index2 = num5;
      int num7 = 1;
      int num8 = index2 + num7;
      int num9 = 2;
      numArray2[index2] = (byte) num9;
      byte[] numArray3 = commandList;
      int index3 = num8;
      int num10 = 1;
      int num11 = index3 + num10;
      int num12 = 220;
      numArray3[index3] = (byte) num12;
      byte[] numArray4 = commandList;
      int index4 = num11;
      int num13 = 1;
      int num14 = index4 + num13;
      int num15 = 206;
      numArray4[index4] = (byte) num15;
      byte[] numArray5 = commandList;
      int index5 = num14;
      int num16 = 1;
      int num17 = index5 + num16;
      int num18 = 170;
      numArray5[index5] = (byte) num18;
      ProgCommand.writeUSB(commandList);
      ProgCommand.readUSB();
      if (((int) ProgCommand.Usb_read_array[2] & 2) > 0)
        this.updateInputBox(this.textBoxPin4In, "1");
      else
        this.updateInputBox(this.textBoxPin4In, "0");
      if (((int) ProgCommand.Usb_read_array[2] & 1) > 0)
        this.updateInputBox(this.textBoxPin5In, "1");
      else
        this.updateInputBox(this.textBoxPin5In, "0");
      if (((int) ProgCommand.Usb_read_array[3] & 1) > 0)
        this.updateInputBox(this.textBoxPin6In, "1");
      else
        this.updateInputBox(this.textBoxPin6In, "0");
    }

    private void updateInputBox(TextBox inputBox, string value)
    {
      if (!inputBox.Enabled)
        return;
      inputBox.Text = value;
      if (value == "1")
        inputBox.BackColor = Color.DodgerBlue;
      else
        inputBox.BackColor = Color.DarkBlue;
    }

    private void buttonHelp_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\Logic Tool User Guide.pdf");
      }
      catch
      {
        int num = (int) MessageBox.Show("Unable to open Logic Tool User Guide.");
      }
    }

    private void checkBoxVDD_Click(object sender, EventArgs e)
    {
      this.VddCallback(true, this.checkBoxVDD.Checked);
    }
  }
}
