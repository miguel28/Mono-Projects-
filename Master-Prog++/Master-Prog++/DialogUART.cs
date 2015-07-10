// Type: SysProgUSB.DialogUART
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogUART : Form
  {
    public static string CustomBaud = "";
    private bool newRX = true;
    private const string CUSTOM_BAUD = "Custom...";
    private const int MaxLengthASCII = 60;
    private const int MaxHexLength = 143;
    public DelegateVddCallback VddCallback;
    private DialogUART.baudTable[] baudList;
    private StreamWriter logFile;
    private int hex1Length;
    private int hex2Length;
    private int hex3Length;
    private int hex4Length;
    private IContainer components;
    private TextBox textBoxDisplay;
    private PictureBox pictureBox1;
    private Label label1;
    private RadioButton radioButtonConnect;
    private RadioButton radioButtonDisconnect;
    private ComboBox comboBoxBaud;
    private Panel panel1;
    private Panel panel2;
    private RadioButton radioButtonHex;
    private RadioButton radioButtonASCII;
    private Label label2;
    private Label label3;
    private TextBox textBoxString1;
    private Button buttonString1;
    private Button buttonString2;
    private TextBox textBoxString2;
    private Button buttonString4;
    private Button buttonString3;
    private TextBox textBoxString3;
    private TextBox textBoxString4;
    private Button buttonLog;
    private Button buttonClearScreen;
    private Button buttonExit;
    private CheckBox checkBoxEcho;
    private Label labelMacros;
    private System.Windows.Forms.Timer timerPollForData;
    private Label label5;
    private CheckBox checkBoxCRLF;
    private SaveFileDialog saveFileDialogLogFile;
    private CheckBox checkBoxWrap;
    private PictureBox pictureBoxHelp;
    private CheckBox checkBoxVDD;
    private Panel panelVdd;

    static DialogUART()
    {
    }

    public DialogUART()
    {
      this.InitializeComponent();
      this.KeyPress += new KeyPressEventHandler(this.OnKeyPress);
      this.baudList = new DialogUART.baudTable[7];
      this.baudList[0].baudRate = "300";
      this.baudList[0].baudValue = 45554U;
      this.baudList[1].baudRate = "1200";
      this.baudList[1].baudValue = 60554U;
      this.baudList[2].baudRate = "2400";
      this.baudList[2].baudValue = 63054U;
      this.baudList[3].baudRate = "4800";
      this.baudList[3].baudValue = 64304U;
      this.baudList[4].baudRate = "9600";
      this.baudList[4].baudValue = 64929U;
      this.baudList[5].baudRate = "19200";
      this.baudList[5].baudValue = 65242U;
      this.baudList[6].baudRate = "38400";
      this.baudList[6].baudValue = 65398U;
      this.buildBaudList();
    }

    public string GetBaudRate()
    {
      return this.comboBoxBaud.SelectedItem.ToString();
    }

    public bool IsHexMode()
    {
      return this.radioButtonHex.Checked;
    }

    public string GetStringMacro(int macroNum)
    {
      if (macroNum == 2)
        return this.textBoxString2.Text;
      if (macroNum == 3)
        return this.textBoxString3.Text;
      if (macroNum == 4)
        return this.textBoxString4.Text;
      else
        return this.textBoxString1.Text;
    }

    public bool GetAppendCRLF()
    {
      return this.checkBoxCRLF.Checked;
    }

    public bool GetWrap()
    {
      return this.checkBoxWrap.Checked;
    }

    public bool GetEcho()
    {
      return this.checkBoxEcho.Checked;
    }

    public void SetBaudRate(string baudRate)
    {
      for (int index = 0; index < this.baudList.Length; ++index)
      {
        if (baudRate == this.comboBoxBaud.Items[index].ToString())
        {
          this.comboBoxBaud.SelectedIndex = index;
          break;
        }
        else if (index + 1 == this.baudList.Length)
        {
          this.comboBoxBaud.Items.Add((object) baudRate);
          this.comboBoxBaud.SelectedIndex = index + 3;
        }
      }
    }

    public void SetStringMacro(string macro, int macroNum)
    {
      if (macroNum == 2)
      {
        this.textBoxString2.Text = macro;
        this.hex1Length = macro.Length;
      }
      else if (macroNum == 3)
      {
        this.textBoxString3.Text = macro;
        this.hex2Length = macro.Length;
      }
      else if (macroNum == 4)
      {
        this.textBoxString4.Text = macro;
        this.hex3Length = macro.Length;
      }
      else
      {
        this.textBoxString1.Text = macro;
        this.hex4Length = macro.Length;
      }
    }

    public void SetModeHex()
    {
      this.radioButtonHex.Checked = true;
    }

    public void ClearAppendCRLF()
    {
      this.checkBoxCRLF.Checked = false;
    }

    public void ClearWrap()
    {
      this.checkBoxWrap.Checked = false;
    }

    public void ClearEcho()
    {
      this.checkBoxEcho.Checked = false;
    }

    public void SetVddBox(bool enable, bool check)
    {
      this.checkBoxVDD.Enabled = enable;
      this.checkBoxVDD.Checked = check;
    }

    private void buildBaudList()
    {
      for (int index = 0; index < this.baudList.Length; ++index)
        this.comboBoxBaud.Items.Add((object) this.baudList[index].baudRate);
      this.comboBoxBaud.Items.Add((object) "Custom...");
      this.comboBoxBaud.SelectedIndex = 0;
    }

    private void buttonExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void DialogUART_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.logFile != null)
        this.closeLogFile();
      this.timerPollForData.Enabled = false;
      ProgCommand.ExitUARTMode();
      this.radioButtonConnect.Checked = false;
      this.radioButtonDisconnect.Checked = true;
      this.comboBoxBaud.Enabled = true;
      this.buttonString1.Enabled = false;
      this.buttonString2.Enabled = false;
      this.buttonString3.Enabled = false;
      this.buttonString4.Enabled = false;
      this.panelVdd.Enabled = true;
    }

    public void OnKeyPress(object sender, KeyPressEventArgs e)
    {
      if (this.textBoxString1.ContainsFocus | this.textBoxString2.ContainsFocus | this.textBoxString3.ContainsFocus | this.textBoxString4.ContainsFocus)
        return;
      if ((int) e.KeyChar == 3 || (int) e.KeyChar == 24)
      {
        this.textBoxDisplay.Copy();
      }
      else
      {
        if (this.radioButtonDisconnect.Checked || this.radioButtonHex.Checked)
          return;
        this.textBoxDisplay.Focus();
        if ((int) e.KeyChar == 22)
        {
          this.textBoxDisplay.SelectionStart = this.textBoxDisplay.Text.Length;
          TextBox textBox = new TextBox();
          textBox.Multiline = true;
          ((TextBoxBase) textBox).Paste();
          do
          {
            int num = textBox.Text.Length;
            if (num > 60)
              num = 60;
            this.sendString(textBox.Text.Substring(0, num), false);
            textBox.Text = textBox.Text.Substring(num);
            Thread.Sleep((int) ((float) (1.0 / (double) float.Parse(this.comboBoxBaud.SelectedItem.ToString()) * 12.0) * (float) num * 1000f));
          }
          while (textBox.Text.Length > 0);
          textBox.Dispose();
        }
        else
        {
          string dataString = e.KeyChar.ToString();
          if (dataString == "\r")
            dataString = "\r\n";
          this.sendString(dataString, false);
        }
      }
    }

    private void radioButtonConnect_Click_1(object sender, EventArgs e)
    {
      if (this.radioButtonConnect.Checked)
        return;
      if (this.comboBoxBaud.SelectedIndex == 0)
      {
        int num1 = (int) MessageBox.Show("Please Select a Baud Rate.");
      }
      else
      {
        uint baudValue = 0U;
        for (int index = 0; index < this.baudList.Length; ++index)
        {
          if (this.comboBoxBaud.SelectedItem.ToString() == this.baudList[index].baudRate)
          {
            baudValue = this.baudList[index].baudValue;
            break;
          }
          else if (index + 1 == this.baudList.Length)
          {
            try
            {
              baudValue = 65536U - (uint) (float) ((1.0 / (double) float.Parse(this.comboBoxBaud.SelectedItem.ToString()) - 3.00000010611257E-06) / 1.66670005796732E-07);
            }
            catch
            {
              int num2 = (int) MessageBox.Show("Error with Baud setting.");
              return;
            }
          }
        }
        this.panelVdd.Enabled = false;
        ProgCommand.EnterUARTMode(baudValue);
        this.radioButtonConnect.Checked = true;
        this.radioButtonDisconnect.Checked = false;
        this.buttonString1.Enabled = true;
        this.buttonString2.Enabled = true;
        this.buttonString3.Enabled = true;
        this.buttonString4.Enabled = true;
        this.comboBoxBaud.Enabled = false;
        this.timerPollForData.Interval = baudValue >= 60554U ? 15 : 75;
        this.timerPollForData.Enabled = true;
      }
    }

    private void radioButtonDisconnect_Click(object sender, EventArgs e)
    {
      if (this.radioButtonDisconnect.Checked)
        return;
      this.radioButtonConnect.Checked = false;
      this.radioButtonDisconnect.Checked = true;
      ProgCommand.ExitUARTMode();
      this.comboBoxBaud.Enabled = true;
      this.timerPollForData.Enabled = false;
      this.buttonString1.Enabled = false;
      this.buttonString2.Enabled = false;
      this.buttonString3.Enabled = false;
      this.buttonString4.Enabled = false;
      this.panelVdd.Enabled = true;
    }

    private void buttonClearScreen_Click(object sender, EventArgs e)
    {
      this.textBoxDisplay.Text = "";
    }

    private void timerPollForData_Tick(object sender, EventArgs e)
    {
      ProgCommand.UploadData();
      if ((int) ProgCommand.Usb_read_array[1] > 0)
      {
        string text = "";
        if (this.radioButtonASCII.Checked)
        {
          text = Encoding.ASCII.GetString(ProgCommand.Usb_read_array, 2, (int) ProgCommand.Usb_read_array[1]);
        }
        else
        {
          if (this.newRX)
          {
            text = "RX:  ";
            this.newRX = false;
          }
          for (int index = 0; index < (int) ProgCommand.Usb_read_array[1]; ++index)
            text = text + string.Format("{0:X2} ", (object) ProgCommand.Usb_read_array[index + 2]);
        }
        if (this.logFile != null)
          this.logFile.Write(text);
        this.textBoxDisplay.AppendText(text);
        while (this.textBoxDisplay.Text.Length > 16400)
          this.textBoxDisplay.Text = this.textBoxDisplay.Text.Substring(this.textBoxDisplay.Text.IndexOf("\r\n") + 2);
        this.textBoxDisplay.SelectionStart = this.textBoxDisplay.Text.Length;
        this.textBoxDisplay.ScrollToCaret();
      }
      else
      {
        if (!this.newRX && this.radioButtonHex.Checked)
        {
          this.textBoxDisplay.AppendText("\r\n");
          if (this.logFile != null)
            this.logFile.Write("\r\n");
          this.textBoxDisplay.SelectionStart = this.textBoxDisplay.Text.Length;
          this.textBoxDisplay.ScrollToCaret();
        }
        this.newRX = true;
      }
    }

    private int getLastLineLength(string text)
    {
      int num = text.LastIndexOf("\r\n") + 2;
      if (num < 2)
        num = 0;
      return text.Length - num;
    }

    private void textBoxString1_TextChanged(object sender, EventArgs e)
    {
      if (this.textBoxString1.Text.Length > 60 && this.radioButtonASCII.Checked)
      {
        this.textBoxString1.Text = this.textBoxString1.Text.Substring(0, 60);
        this.textBoxString1.SelectionStart = 60;
      }
      if (!this.radioButtonHex.Checked)
        return;
      this.formatHexString(this.textBoxString1, ref this.hex1Length);
    }

    private void textBoxString2_TextChanged(object sender, EventArgs e)
    {
      if (this.textBoxString2.Text.Length > 60 && this.radioButtonASCII.Checked)
      {
        this.textBoxString2.Text = this.textBoxString2.Text.Substring(0, 60);
        this.textBoxString2.SelectionStart = 60;
      }
      if (!this.radioButtonHex.Checked)
        return;
      this.formatHexString(this.textBoxString2, ref this.hex2Length);
    }

    private void textBoxString3_TextChanged(object sender, EventArgs e)
    {
      if (this.textBoxString3.Text.Length > 60 && this.radioButtonASCII.Checked)
      {
        this.textBoxString3.Text = this.textBoxString3.Text.Substring(0, 60);
        this.textBoxString3.SelectionStart = 60;
      }
      if (!this.radioButtonHex.Checked)
        return;
      this.formatHexString(this.textBoxString3, ref this.hex3Length);
    }

    private void textBoxString4_TextChanged(object sender, EventArgs e)
    {
      if (this.textBoxString4.Text.Length > 60 && this.radioButtonASCII.Checked)
      {
        this.textBoxString4.Text = this.textBoxString4.Text.Substring(0, 60);
        this.textBoxString4.SelectionStart = 60;
      }
      if (!this.radioButtonHex.Checked)
        return;
      this.formatHexString(this.textBoxString4, ref this.hex4Length);
    }

    private void formatHexString(TextBox textBoxToFormat, ref int priorLength)
    {
      string s = textBoxToFormat.Text.ToUpper().Replace(" ", "");
      string str = "";
      for (int index = 0; index < s.Length; ++index)
      {
        str = char.IsNumber(s, index) || (int) s[index] == 65 || ((int) s[index] == 66 || (int) s[index] == 67) || ((int) s[index] == 68 || (int) s[index] == 69 || (int) s[index] == 70) ? str + (object) s[index] : str + (object) '0';
        if ((index + 1) % 2 == 0)
          str = str + " ";
      }
      if (str.Length > 143)
        str = str.Substring(0, 143);
      int index1 = textBoxToFormat.SelectionStart;
      if (index1 > 0 && index1 <= str.Length && (index1 < textBoxToFormat.Text.Length && (int) textBoxToFormat.Text[index1] == 32) && (int) str[index1 - 1] == 32)
        ++index1;
      else if (index1 >= textBoxToFormat.Text.Length && priorLength < textBoxToFormat.Text.Length)
        index1 = str.Length;
      textBoxToFormat.Text = str;
      textBoxToFormat.SelectionStart = index1;
      priorLength = textBoxToFormat.Text.Length;
    }

    private void buttonString1_Click(object sender, EventArgs e)
    {
      this.sendString(this.textBoxString1.Text, this.checkBoxCRLF.Checked);
    }

    private void buttonString2_Click(object sender, EventArgs e)
    {
      this.sendString(this.textBoxString2.Text, this.checkBoxCRLF.Checked);
    }

    private void buttonString3_Click(object sender, EventArgs e)
    {
      this.sendString(this.textBoxString3.Text, this.checkBoxCRLF.Checked);
    }

    private void buttonString4_Click(object sender, EventArgs e)
    {
      this.sendString(this.textBoxString4.Text, this.checkBoxCRLF.Checked);
    }

    private void sendString(string dataString, bool appendCRLF)
    {
      if (dataString.Length == 0)
        return;
      if (this.radioButtonASCII.Checked)
      {
        if (appendCRLF)
          dataString = dataString + "\r\n";
        if (this.checkBoxEcho.Checked)
        {
          this.textBoxDisplay.AppendText(dataString);
          this.textBoxDisplay.SelectionStart = this.textBoxDisplay.Text.Length;
          this.textBoxDisplay.ScrollToCaret();
        }
        if (this.logFile != null)
          this.logFile.Write(dataString);
        byte[] dataArray = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, Encoding.Unicode.GetBytes(dataString));
        ProgCommand.DataDownload(dataArray, 0, dataArray.Length);
      }
      else
      {
        int length;
        if (dataString.Length > 142)
        {
          length = 48;
        }
        else
        {
          length = dataString.Length / 3;
          dataString = dataString.Substring(0, length * 3);
        }
        byte[] dataArray = new byte[length];
        for (int index = 0; index < length; ++index)
          dataArray[index] = (byte) Utilities.Convert_Value_To_Int("0x" + dataString.Substring(3 * index, 2));
        dataString = "TX:  " + dataString + "\r\n";
        this.textBoxDisplay.AppendText(dataString);
        this.textBoxDisplay.SelectionStart = this.textBoxDisplay.Text.Length;
        this.textBoxDisplay.ScrollToCaret();
        if (this.logFile != null)
          this.logFile.Write(dataString);
        ProgCommand.DataDownload(dataArray, 0, dataArray.Length);
      }
    }

    private void buttonLog_Click(object sender, EventArgs e)
    {
      if (this.logFile == null)
      {
        int num = (int) this.saveFileDialogLogFile.ShowDialog();
      }
      else
        this.closeLogFile();
    }

    private void closeLogFile()
    {
      this.logFile.Close();
      this.logFile = (StreamWriter) null;
      this.buttonLog.Text = "Log to File";
      this.buttonLog.BackColor = SystemColors.ControlLight;
    }

    private void saveFileDialogLogFile_FileOk(object sender, CancelEventArgs e)
    {
      this.logFile = new StreamWriter(this.saveFileDialogLogFile.FileName);
      this.buttonLog.Text = "Logging Data...";
      this.buttonLog.BackColor = Color.YellowGreen;
    }

    private void radioButtonASCII_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButtonASCII.Checked)
        return;
      this.checkBoxCRLF.Visible = true;
      this.checkBoxEcho.Enabled = true;
      this.labelMacros.Text = "String Macros:";
      this.textBoxString1.Text = this.convertHexSequenceToStringMacro(this.textBoxString1.Text);
      this.textBoxString2.Text = this.convertHexSequenceToStringMacro(this.textBoxString2.Text);
      this.textBoxString3.Text = this.convertHexSequenceToStringMacro(this.textBoxString3.Text);
      this.textBoxString4.Text = this.convertHexSequenceToStringMacro(this.textBoxString4.Text);
      if (this.textBoxDisplay.Text.Length <= 0 || (int) this.textBoxDisplay.Text[this.textBoxDisplay.Text.Length - 1] == 10)
        return;
      this.textBoxDisplay.AppendText("\r\n");
    }

    private void radioButtonHex_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButtonHex.Checked)
        return;
      this.checkBoxCRLF.Visible = false;
      this.checkBoxEcho.Enabled = false;
      this.labelMacros.Text = "Send Hex Sequences:";
      this.textBoxString1.Text = this.convertStringMacroToHexSequence(this.textBoxString1.Text);
      this.textBoxString2.Text = this.convertStringMacroToHexSequence(this.textBoxString2.Text);
      this.textBoxString3.Text = this.convertStringMacroToHexSequence(this.textBoxString3.Text);
      this.textBoxString4.Text = this.convertStringMacroToHexSequence(this.textBoxString4.Text);
      if (this.textBoxDisplay.Text.Length <= 0 || (int) this.textBoxDisplay.Text[this.textBoxDisplay.Text.Length - 1] == 10)
        return;
      this.textBoxDisplay.AppendText("\r\n");
    }

    private string convertHexSequenceToStringMacro(string hexSeq)
    {
      int length = hexSeq.Length <= 142 ? hexSeq.Length / 3 : 48;
      byte[] bytes = new byte[length];
      for (int index = 0; index < length; ++index)
        bytes[index] = (byte) Utilities.Convert_Value_To_Int("0x" + hexSeq.Substring(3 * index, 2));
      return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
    }

    private string convertStringMacroToHexSequence(string stringMacro)
    {
      if (stringMacro.Length > 48)
        stringMacro = stringMacro.Substring(0, 48);
      byte[] numArray = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, Encoding.Unicode.GetBytes(stringMacro));
      string str = "";
      for (int index = 0; index < numArray.Length; ++index)
        str = str + string.Format("{0:X2} ", (object) numArray[index]);
      return str;
    }

    private void checkBoxWrap_CheckedChanged(object sender, EventArgs e)
    {
      this.textBoxDisplay.WordWrap = this.checkBoxWrap.Checked;
    }

    private void comboBoxBaud_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(this.comboBoxBaud.SelectedItem.ToString() == "Custom..."))
        return;
      int num1 = (int) new DialogCustomBaud().ShowDialog();
      if (DialogUART.CustomBaud == "")
      {
        this.comboBoxBaud.SelectedIndex = 0;
      }
      else
      {
        if (this.comboBoxBaud.Items.Count != this.comboBoxBaud.SelectedIndex + 1)
          this.comboBoxBaud.Items.RemoveAt(this.comboBoxBaud.SelectedIndex + 1);
        this.comboBoxBaud.Items.Add((object) DialogUART.CustomBaud);
        ComboBox comboBox = this.comboBoxBaud;
        int num2 = comboBox.SelectedIndex + 1;
        comboBox.SelectedIndex = num2;
      }
    }

    private void pictureBoxHelp_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(FormProgUSB.HomeDirectory + "\\Instalación.pdf");
      }
      catch
      {
        int num = (int) MessageBox.Show("Unable to open User's Guide.");
      }
    }

    private void checkBoxVDD_Click(object sender, EventArgs e)
    {
      this.VddCallback(true, this.checkBoxVDD.Checked);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogUART));
      this.textBoxDisplay = new TextBox();
      this.pictureBox1 = new PictureBox();
      this.label1 = new Label();
      this.radioButtonConnect = new RadioButton();
      this.radioButtonDisconnect = new RadioButton();
      this.comboBoxBaud = new ComboBox();
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.radioButtonHex = new RadioButton();
      this.radioButtonASCII = new RadioButton();
      this.label2 = new Label();
      this.label3 = new Label();
      this.textBoxString1 = new TextBox();
      this.buttonString1 = new Button();
      this.buttonString2 = new Button();
      this.textBoxString2 = new TextBox();
      this.buttonString4 = new Button();
      this.buttonString3 = new Button();
      this.textBoxString3 = new TextBox();
      this.textBoxString4 = new TextBox();
      this.buttonLog = new Button();
      this.buttonClearScreen = new Button();
      this.buttonExit = new Button();
      this.checkBoxEcho = new CheckBox();
      this.labelMacros = new Label();
      this.timerPollForData = new System.Windows.Forms.Timer(this.components);
      this.label5 = new Label();
      this.checkBoxCRLF = new CheckBox();
      this.saveFileDialogLogFile = new SaveFileDialog();
      this.checkBoxWrap = new CheckBox();
      this.pictureBoxHelp = new PictureBox();
      this.checkBoxVDD = new CheckBox();
      this.panelVdd = new Panel();
      this.pictureBox1.BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.pictureBoxHelp.BeginInit();
      this.panelVdd.SuspendLayout();
      this.SuspendLayout();
      this.textBoxDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBoxDisplay.BackColor = SystemColors.Window;
      this.textBoxDisplay.Cursor = Cursors.Default;
      this.textBoxDisplay.Font = new Font("Courier New", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBoxDisplay.Location = new Point(13, 44);
      this.textBoxDisplay.MaxLength = 17220;
      this.textBoxDisplay.MinimumSize = new Size(708, 332);
      this.textBoxDisplay.Multiline = true;
      this.textBoxDisplay.Name = "textBoxDisplay";
      this.textBoxDisplay.ReadOnly = true;
      this.textBoxDisplay.ScrollBars = ScrollBars.Both;
      this.textBoxDisplay.Size = new Size(708, 332);
      this.textBoxDisplay.TabIndex = 0;
      this.pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(13, 385);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(189, 116);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(10, 504);
      this.label1.Name = "label1";
      this.label1.Size = new Size(181, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Connect MASTER-PROG VDD && target VDD.";
      this.radioButtonConnect.Appearance = Appearance.Button;
      this.radioButtonConnect.AutoCheck = false;
      this.radioButtonConnect.Location = new Point(130, 4);
      this.radioButtonConnect.Name = "radioButtonConnect";
      this.radioButtonConnect.Size = new Size(70, 22);
      this.radioButtonConnect.TabIndex = 14;
      this.radioButtonConnect.Text = "Connect";
      this.radioButtonConnect.TextAlign = ContentAlignment.MiddleCenter;
      this.radioButtonConnect.UseVisualStyleBackColor = true;
      this.radioButtonConnect.Click += new EventHandler(this.radioButtonConnect_Click_1);
      this.radioButtonDisconnect.Appearance = Appearance.Button;
      this.radioButtonDisconnect.AutoCheck = false;
      this.radioButtonDisconnect.Checked = true;
      this.radioButtonDisconnect.Location = new Point(206, 4);
      this.radioButtonDisconnect.Name = "radioButtonDisconnect";
      this.radioButtonDisconnect.Size = new Size(70, 22);
      this.radioButtonDisconnect.TabIndex = 15;
      this.radioButtonDisconnect.TabStop = true;
      this.radioButtonDisconnect.Text = "Disconnect";
      this.radioButtonDisconnect.TextAlign = ContentAlignment.MiddleCenter;
      this.radioButtonDisconnect.UseVisualStyleBackColor = true;
      this.radioButtonDisconnect.Click += new EventHandler(this.radioButtonDisconnect_Click);
      this.comboBoxBaud.BackColor = Color.Aqua;
      this.comboBoxBaud.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxBaud.FormattingEnabled = true;
      this.comboBoxBaud.Items.AddRange(new object[1]
      {
        (object) "- Select Baud -"
      });
      this.comboBoxBaud.Location = new Point(6, 5);
      this.comboBoxBaud.MaxDropDownItems = 12;
      this.comboBoxBaud.Name = "comboBoxBaud";
      this.comboBoxBaud.Size = new Size(118, 21);
      this.comboBoxBaud.TabIndex = 13;
      this.comboBoxBaud.SelectedIndexChanged += new EventHandler(this.comboBoxBaud_SelectedIndexChanged);
      this.panel1.Controls.Add((Control) this.comboBoxBaud);
      this.panel1.Controls.Add((Control) this.radioButtonDisconnect);
      this.panel1.Controls.Add((Control) this.radioButtonConnect);
      this.panel1.Location = new Point(13, 8);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(280, 30);
      this.panel1.TabIndex = 6;
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.panel2.Controls.Add((Control) this.radioButtonHex);
      this.panel2.Controls.Add((Control) this.radioButtonASCII);
      this.panel2.Location = new Point(618, 9);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(106, 29);
      this.panel2.TabIndex = 7;
      this.radioButtonHex.Appearance = Appearance.Button;
      this.radioButtonHex.Location = new Point(57, 3);
      this.radioButtonHex.Name = "radioButtonHex";
      this.radioButtonHex.Size = new Size(47, 22);
      this.radioButtonHex.TabIndex = 17;
      this.radioButtonHex.Text = "Hex";
      this.radioButtonHex.TextAlign = ContentAlignment.MiddleCenter;
      this.radioButtonHex.UseVisualStyleBackColor = true;
      this.radioButtonHex.CheckedChanged += new EventHandler(this.radioButtonHex_CheckedChanged);
      this.radioButtonASCII.Appearance = Appearance.Button;
      this.radioButtonASCII.Checked = true;
      this.radioButtonASCII.Location = new Point(3, 3);
      this.radioButtonASCII.Name = "radioButtonASCII";
      this.radioButtonASCII.Size = new Size(47, 22);
      this.radioButtonASCII.TabIndex = 16;
      this.radioButtonASCII.TabStop = true;
      this.radioButtonASCII.Text = "ASCII";
      this.radioButtonASCII.TextAlign = ContentAlignment.MiddleCenter;
      this.radioButtonASCII.UseVisualStyleBackColor = true;
      this.radioButtonASCII.CheckedChanged += new EventHandler(this.radioButtonASCII_CheckedChanged);
      this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(570, 14);
      this.label2.Name = "label2";
      this.label2.Size = new Size(47, 15);
      this.label2.TabIndex = 8;
      this.label2.Text = "Mode:";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(363, 8);
      this.label3.Name = "label3";
      this.label3.Size = new Size(164, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "8 data bits - No parity - 1 Stop bit.";
      this.textBoxString1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBoxString1.BackColor = Color.Aqua;
      this.textBoxString1.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBoxString1.Location = new Point(306, 406);
      this.textBoxString1.Name = "textBoxString1";
      this.textBoxString1.Size = new Size(286, 20);
      this.textBoxString1.TabIndex = 1;
      this.textBoxString1.TextChanged += new EventHandler(this.textBoxString1_TextChanged);
      this.buttonString1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.buttonString1.Enabled = false;
      this.buttonString1.Location = new Point(246, 404);
      this.buttonString1.Name = "buttonString1";
      this.buttonString1.Size = new Size(54, 22);
      this.buttonString1.TabIndex = 5;
      this.buttonString1.Text = "Send";
      this.buttonString1.UseVisualStyleBackColor = true;
      this.buttonString1.Click += new EventHandler(this.buttonString1_Click);
      this.buttonString2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.buttonString2.Enabled = false;
      this.buttonString2.Location = new Point(246, 434);
      this.buttonString2.Name = "buttonString2";
      this.buttonString2.Size = new Size(54, 22);
      this.buttonString2.TabIndex = 6;
      this.buttonString2.Text = "Send";
      this.buttonString2.UseVisualStyleBackColor = true;
      this.buttonString2.Click += new EventHandler(this.buttonString2_Click);
      this.textBoxString2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBoxString2.BackColor = Color.Aqua;
      this.textBoxString2.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBoxString2.Location = new Point(306, 435);
      this.textBoxString2.Name = "textBoxString2";
      this.textBoxString2.Size = new Size(286, 20);
      this.textBoxString2.TabIndex = 2;
      this.textBoxString2.TextChanged += new EventHandler(this.textBoxString2_TextChanged);
      this.buttonString4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.buttonString4.Enabled = false;
      this.buttonString4.Location = new Point(246, 490);
      this.buttonString4.Name = "buttonString4";
      this.buttonString4.Size = new Size(54, 22);
      this.buttonString4.TabIndex = 8;
      this.buttonString4.Text = "Send";
      this.buttonString4.UseVisualStyleBackColor = true;
      this.buttonString4.Click += new EventHandler(this.buttonString4_Click);
      this.buttonString3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.buttonString3.Enabled = false;
      this.buttonString3.Location = new Point(246, 462);
      this.buttonString3.Name = "buttonString3";
      this.buttonString3.Size = new Size(54, 22);
      this.buttonString3.TabIndex = 7;
      this.buttonString3.Text = "Send";
      this.buttonString3.UseVisualStyleBackColor = true;
      this.buttonString3.Click += new EventHandler(this.buttonString3_Click);
      this.textBoxString3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBoxString3.BackColor = Color.Aqua;
      this.textBoxString3.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBoxString3.Location = new Point(306, 464);
      this.textBoxString3.Name = "textBoxString3";
      this.textBoxString3.Size = new Size(286, 20);
      this.textBoxString3.TabIndex = 3;
      this.textBoxString3.TextChanged += new EventHandler(this.textBoxString3_TextChanged);
      this.textBoxString4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBoxString4.BackColor = Color.Aqua;
      this.textBoxString4.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBoxString4.Location = new Point(306, 492);
      this.textBoxString4.Name = "textBoxString4";
      this.textBoxString4.Size = new Size(286, 20);
      this.textBoxString4.TabIndex = 4;
      this.textBoxString4.TextChanged += new EventHandler(this.textBoxString4_TextChanged);
      this.buttonLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.buttonLog.Location = new Point(618, 404);
      this.buttonLog.Name = "buttonLog";
      this.buttonLog.Size = new Size(102, 22);
      this.buttonLog.TabIndex = 9;
      this.buttonLog.Text = "Log to File";
      this.buttonLog.UseVisualStyleBackColor = true;
      this.buttonLog.Click += new EventHandler(this.buttonLog_Click);
      this.buttonClearScreen.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.buttonClearScreen.Location = new Point(618, 434);
      this.buttonClearScreen.Name = "buttonClearScreen";
      this.buttonClearScreen.Size = new Size(102, 22);
      this.buttonClearScreen.TabIndex = 10;
      this.buttonClearScreen.Text = "Clear Screen";
      this.buttonClearScreen.UseVisualStyleBackColor = true;
      this.buttonClearScreen.Click += new EventHandler(this.buttonClearScreen_Click);
      this.buttonExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.buttonExit.Location = new Point(618, 490);
      this.buttonExit.Name = "buttonExit";
      this.buttonExit.Size = new Size(102, 22);
      this.buttonExit.TabIndex = 12;
      this.buttonExit.Text = "Exit UART Tool";
      this.buttonExit.UseVisualStyleBackColor = true;
      this.buttonExit.Click += new EventHandler(this.buttonExit_Click);
      this.checkBoxEcho.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.checkBoxEcho.AutoSize = true;
      this.checkBoxEcho.Checked = true;
      this.checkBoxEcho.CheckState = CheckState.Checked;
      this.checkBoxEcho.Location = new Point(638, 466);
      this.checkBoxEcho.Name = "checkBoxEcho";
      this.checkBoxEcho.Size = new Size(68, 17);
      this.checkBoxEcho.TabIndex = 11;
      this.checkBoxEcho.Text = "Echo On";
      this.checkBoxEcho.UseVisualStyleBackColor = true;
      this.labelMacros.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.labelMacros.AutoSize = true;
      this.labelMacros.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelMacros.Location = new Point(243, 382);
      this.labelMacros.Name = "labelMacros";
      this.labelMacros.Size = new Size(100, 15);
      this.labelMacros.TabIndex = 22;
      this.labelMacros.Text = "String Macros:";
      this.timerPollForData.Interval = 15;
      this.timerPollForData.Tick += new EventHandler(this.timerPollForData_Tick);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(375, 22);
      this.label5.Name = "label5";
      this.label5.Size = new Size(137, 13);
      this.label5.TabIndex = 23;
      this.label5.Text = "ASCII newline = 0x0D 0x0A";
      this.checkBoxCRLF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.checkBoxCRLF.AutoSize = true;
      this.checkBoxCRLF.Checked = true;
      this.checkBoxCRLF.CheckState = CheckState.Checked;
      this.checkBoxCRLF.Location = new Point(365, 383);
      this.checkBoxCRLF.Name = "checkBoxCRLF";
      this.checkBoxCRLF.Size = new Size(157, 17);
      this.checkBoxCRLF.TabIndex = 18;
      this.checkBoxCRLF.Text = "Append CR+LF (x0D + x0A)";
      this.checkBoxCRLF.UseVisualStyleBackColor = true;
      this.saveFileDialogLogFile.DefaultExt = "txt";
      this.saveFileDialogLogFile.Filter = "All files|*.*|Text files|*.txt";
      this.saveFileDialogLogFile.InitialDirectory = "c:\\";
      this.saveFileDialogLogFile.Title = "Log UART data to file";
      this.saveFileDialogLogFile.FileOk += new CancelEventHandler(this.saveFileDialogLogFile_FileOk);
      this.checkBoxWrap.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.checkBoxWrap.AutoSize = true;
      this.checkBoxWrap.Checked = true;
      this.checkBoxWrap.CheckState = CheckState.Checked;
      this.checkBoxWrap.Location = new Point(638, 383);
      this.checkBoxWrap.Name = "checkBoxWrap";
      this.checkBoxWrap.Size = new Size(76, 17);
      this.checkBoxWrap.TabIndex = 24;
      this.checkBoxWrap.Text = "Wrap Text";
      this.checkBoxWrap.UseVisualStyleBackColor = true;
      this.checkBoxWrap.CheckedChanged += new EventHandler(this.checkBoxWrap_CheckedChanged);
      this.pictureBoxHelp.Cursor = Cursors.Hand;
      this.pictureBoxHelp.Image = (Image) componentResourceManager.GetObject("pictureBoxHelp.Image");
      this.pictureBoxHelp.Location = new Point(540, 10);
      this.pictureBoxHelp.Name = "pictureBoxHelp";
      this.pictureBoxHelp.Size = new Size(24, 24);
      this.pictureBoxHelp.TabIndex = 26;
      this.pictureBoxHelp.TabStop = false;
      this.pictureBoxHelp.Click += new EventHandler(this.pictureBoxHelp_Click);
      this.checkBoxVDD.AutoSize = true;
      this.checkBoxVDD.Location = new Point(6, 5);
      this.checkBoxVDD.Name = "checkBoxVDD";
      this.checkBoxVDD.Size = new Size(49, 17);
      this.checkBoxVDD.TabIndex = 27;
      this.checkBoxVDD.Text = "VDD";
      this.checkBoxVDD.UseVisualStyleBackColor = true;
      this.checkBoxVDD.Click += new EventHandler(this.checkBoxVDD_Click);
      this.panelVdd.Controls.Add((Control) this.checkBoxVDD);
      this.panelVdd.Location = new Point(299, 10);
      this.panelVdd.Name = "panelVdd";
      this.panelVdd.Size = new Size(65, 27);
      this.panelVdd.TabIndex = 28;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(736, 526);
      this.Controls.Add((Control) this.panelVdd);
      this.Controls.Add((Control) this.pictureBoxHelp);
      this.Controls.Add((Control) this.checkBoxWrap);
      this.Controls.Add((Control) this.checkBoxCRLF);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.labelMacros);
      this.Controls.Add((Control) this.checkBoxEcho);
      this.Controls.Add((Control) this.buttonExit);
      this.Controls.Add((Control) this.buttonClearScreen);
      this.Controls.Add((Control) this.buttonLog);
      this.Controls.Add((Control) this.textBoxString4);
      this.Controls.Add((Control) this.textBoxString3);
      this.Controls.Add((Control) this.buttonString3);
      this.Controls.Add((Control) this.buttonString4);
      this.Controls.Add((Control) this.textBoxString2);
      this.Controls.Add((Control) this.buttonString2);
      this.Controls.Add((Control) this.buttonString1);
      this.Controls.Add((Control) this.textBoxString1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.textBoxDisplay);
      this.KeyPreview = true;
      this.MinimumSize = new Size(744, 559);
      this.Name = "DialogUART";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "MASTER-PROG UART Tool";
      this.FormClosing += new FormClosingEventHandler(this.DialogUART_FormClosing);
      this.pictureBox1.EndInit();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.pictureBoxHelp.EndInit();
      this.panelVdd.ResumeLayout(false);
      this.panelVdd.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private struct baudTable
    {
      public string baudRate;
      public uint baudValue;
    }
  }
}
