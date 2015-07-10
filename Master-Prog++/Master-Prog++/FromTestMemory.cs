// Type: SysProgUSB.FormTestMemory
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class FormTestMemory : Form
  {
    public static uint[] TestMemory = new uint[1024];
    public static bool ReWriteCalWords = false;
    private IContainer components;
    private DataGridView dataGridTestMemory;
    private Label label1;
    private TextBox textBoxTestMemSize;
    private Label labelTestMemSize8;
    private Label label11;
    private CheckBox checkBoxTestMemImportExport;
    private Label label2;
    private Label label3;
    private Label labelBLConfig;
    private TextBox textBoxBaselineConfig;
    private Label labelNotSupported;
    private Button buttonClearTestMem;
    private Label label4;
    private Button buttonWriteCalWords;
    private Label labelCalWarning;
    private bool testMemJustEdited;
    private int lastPart;
    private int lastFamily;
    public DelegateUpdateGUI UpdateMainFormGUI;
    public DelegateWriteCal CallMainFormEraseWrCal;

    static FormTestMemory()
    {
    }

    public FormTestMemory()
    {
      this.InitializeComponent();
      this.initTestMemoryGUI();
      this.ClearTestMemory();
      this.UpdateTestMemForm();
      this.UpdateTestMemoryGrid();
      FormProgUSB.TestMemoryOpen = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      this.dataGridTestMemory = new DataGridView();
      this.label1 = new Label();
      this.textBoxTestMemSize = new TextBox();
      this.labelTestMemSize8 = new Label();
      this.label11 = new Label();
      this.checkBoxTestMemImportExport = new CheckBox();
      this.label2 = new Label();
      this.label3 = new Label();
      this.labelBLConfig = new Label();
      this.textBoxBaselineConfig = new TextBox();
      this.labelNotSupported = new Label();
      this.buttonClearTestMem = new Button();
      this.label4 = new Label();
      this.buttonWriteCalWords = new Button();
      this.labelCalWarning = new Label();
      this.dataGridTestMemory.BeginInit();
      this.SuspendLayout();
      this.dataGridTestMemory.AllowUserToAddRows = false;
      this.dataGridTestMemory.AllowUserToDeleteRows = false;
      this.dataGridTestMemory.AllowUserToResizeColumns = false;
      this.dataGridTestMemory.AllowUserToResizeRows = false;
      this.dataGridTestMemory.BackgroundColor = SystemColors.Window;
      this.dataGridTestMemory.CellBorderStyle = DataGridViewCellBorderStyle.None;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dataGridTestMemory.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dataGridTestMemory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGridTestMemory.ColumnHeadersVisible = false;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dataGridTestMemory.DefaultCellStyle = gridViewCellStyle2;
      this.dataGridTestMemory.Location = new Point(16, 52);
      this.dataGridTestMemory.Margin = new Padding(4, 4, 4, 4);
      this.dataGridTestMemory.MultiSelect = false;
      this.dataGridTestMemory.Name = "dataGridTestMemory";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = SystemColors.Control;
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dataGridTestMemory.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dataGridTestMemory.RowHeadersVisible = false;
      this.dataGridTestMemory.RowHeadersWidth = 75;
      this.dataGridTestMemory.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dataGridTestMemory.RowsDefaultCellStyle = gridViewCellStyle4;
      this.dataGridTestMemory.RowTemplate.Height = 17;
      this.dataGridTestMemory.ScrollBars = ScrollBars.Vertical;
      this.dataGridTestMemory.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dataGridTestMemory.Size = new Size(467, 171);
      this.dataGridTestMemory.TabIndex = 5;
      this.dataGridTestMemory.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridTestMemory_CellEndEdit);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 23);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(139, 17);
      this.label1.TabIndex = 6;
      this.label1.Text = "Test Memory Words:";
      this.textBoxTestMemSize.Location = new Point(160, 20);
      this.textBoxTestMemSize.Margin = new Padding(4, 4, 4, 4);
      this.textBoxTestMemSize.Name = "textBoxTestMemSize";
      this.textBoxTestMemSize.Size = new Size(64, 22);
      this.textBoxTestMemSize.TabIndex = 7;
      this.textBoxTestMemSize.Leave += new EventHandler(this.textBoxTestMemSize_Leave);
      this.textBoxTestMemSize.KeyPress += new KeyPressEventHandler(this.textBoxTestMemSize_KeyPress);
      this.labelTestMemSize8.AutoSize = true;
      this.labelTestMemSize8.ForeColor = Color.Red;
      this.labelTestMemSize8.Location = new Point(233, 16);
      this.labelTestMemSize8.Margin = new Padding(4, 0, 4, 0);
      this.labelTestMemSize8.Name = "labelTestMemSize8";
      this.labelTestMemSize8.Size = new Size(92, 34);
      this.labelTestMemSize8.TabIndex = 22;
      this.labelTestMemSize8.Text = "Must be\r\nmultiple of 16";
      this.labelTestMemSize8.Visible = false;
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.label11.Location = new Point(16, 226);
      this.label11.Margin = new Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new Size(120, 17);
      this.label11.TabIndex = 23;
      this.label11.Text = "Hex Import-Export";
      this.checkBoxTestMemImportExport.AutoSize = true;
      this.checkBoxTestMemImportExport.Location = new Point(16, 246);
      this.checkBoxTestMemImportExport.Margin = new Padding(4, 4, 4, 4);
      this.checkBoxTestMemImportExport.Name = "checkBoxTestMemImportExport";
      this.checkBoxTestMemImportExport.Size = new Size(161, 21);
      this.checkBoxTestMemImportExport.TabIndex = 24;
      this.checkBoxTestMemImportExport.Text = "Include Test Memory";
      this.checkBoxTestMemImportExport.UseVisualStyleBackColor = true;
      this.checkBoxTestMemImportExport.CheckedChanged += new EventHandler(this.checkBoxTestMemImportExport_CheckedChanged);
      this.label2.BackColor = Color.LightSteelBlue;
      this.label2.Location = new Point(357, 7);
      this.label2.Margin = new Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(60, 16);
      this.label2.TabIndex = 25;
      this.label2.Text = "UserIDs";
      this.label3.BackColor = Color.LightSalmon;
      this.label3.Location = new Point(423, 7);
      this.label3.Margin = new Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(60, 16);
      this.label3.TabIndex = 26;
      this.label3.Text = "Config";
      this.labelBLConfig.AutoSize = true;
      this.labelBLConfig.Location = new Point(307, 246);
      this.labelBLConfig.Margin = new Padding(4, 0, 4, 0);
      this.labelBLConfig.Name = "labelBLConfig";
      this.labelBLConfig.Size = new Size(110, 17);
      this.labelBLConfig.TabIndex = 27;
      this.labelBLConfig.Text = "Baseline Config:";
      this.textBoxBaselineConfig.BackColor = Color.LightSalmon;
      this.textBoxBaselineConfig.Location = new Point(417, 242);
      this.textBoxBaselineConfig.Margin = new Padding(4, 4, 4, 4);
      this.textBoxBaselineConfig.Name = "textBoxBaselineConfig";
      this.textBoxBaselineConfig.Size = new Size(64, 22);
      this.textBoxBaselineConfig.TabIndex = 28;
      this.textBoxBaselineConfig.Text = "0000";
      this.textBoxBaselineConfig.TextAlign = HorizontalAlignment.Center;
      this.textBoxBaselineConfig.Leave += new EventHandler(this.textBoxBaselineConfig_Leave);
      this.textBoxBaselineConfig.KeyPress += new KeyPressEventHandler(this.textBoxBaselineConfig_KeyPress);
      this.labelNotSupported.AutoSize = true;
      this.labelNotSupported.BackColor = Color.Aqua;
      this.labelNotSupported.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelNotSupported.ForeColor = Color.Red;
      this.labelNotSupported.Location = new Point(37, 100);
      this.labelNotSupported.Margin = new Padding(4, 0, 4, 0);
      this.labelNotSupported.Name = "labelNotSupported";
      this.labelNotSupported.Size = new Size(379, 62);
      this.labelNotSupported.TabIndex = 29;
      this.labelNotSupported.Text = "Test Memory Not Supported\r\n            on this family";
      this.labelNotSupported.Visible = false;
      this.buttonClearTestMem.Location = new Point(208, 239);
      this.buttonClearTestMem.Margin = new Padding(4, 4, 4, 4);
      this.buttonClearTestMem.Name = "buttonClearTestMem";
      this.buttonClearTestMem.Size = new Size(67, 28);
      this.buttonClearTestMem.TabIndex = 30;
      this.buttonClearTestMem.Text = "Clear";
      this.buttonClearTestMem.UseVisualStyleBackColor = true;
      this.buttonClearTestMem.Click += new EventHandler(this.buttonClearTestMem_Click);
      this.label4.BackColor = Color.Gold;
      this.label4.Location = new Point(423, 28);
      this.label4.Margin = new Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(60, 16);
      this.label4.TabIndex = 31;
      this.label4.Text = "CalWrd";
      this.buttonWriteCalWords.Location = new Point(335, 266);
      this.buttonWriteCalWords.Margin = new Padding(4, 4, 4, 4);
      this.buttonWriteCalWords.Name = "buttonWriteCalWords";
      this.buttonWriteCalWords.Size = new Size(111, 28);
      this.buttonWriteCalWords.TabIndex = 32;
      this.buttonWriteCalWords.Text = "Write CalWrd";
      this.buttonWriteCalWords.UseVisualStyleBackColor = true;
      this.buttonWriteCalWords.Click += new EventHandler(this.buttonWriteCalWords_Click);
      this.labelCalWarning.AutoSize = true;
      this.labelCalWarning.ForeColor = Color.Red;
      this.labelCalWarning.Location = new Point(323, 226);
      this.labelCalWarning.Margin = new Padding(4, 0, 4, 0);
      this.labelCalWarning.Name = "labelCalWarning";
      this.labelCalWarning.Size = new Size(136, 34);
      this.labelCalWarning.TabIndex = 33;
      this.labelCalWarning.Text = "Writing Cal Words\r\nwill erase ALL Flash!";
      this.labelCalWarning.TextAlign = ContentAlignment.TopCenter;
      this.labelCalWarning.Visible = false;
      this.AutoScaleDimensions = new SizeF(120f, 120f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(500, 300);
      this.Controls.Add((Control) this.labelCalWarning);
      this.Controls.Add((Control) this.buttonWriteCalWords);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.buttonClearTestMem);
      this.Controls.Add((Control) this.labelNotSupported);
      this.Controls.Add((Control) this.textBoxBaselineConfig);
      this.Controls.Add((Control) this.labelBLConfig);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.checkBoxTestMemImportExport);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.labelTestMemSize8);
      this.Controls.Add((Control) this.textBoxTestMemSize);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.dataGridTestMemory);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormTestMemory";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Test memory";
      this.FormClosing += new FormClosingEventHandler(this.FormTestMemory_FormClosing);
      this.dataGridTestMemory.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void ReadTestMemory()
    {
      byte[] numArray1 = new byte[128];
      ProgCommand.RunScript(0, 1);
      int num1 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
      int repetitions = 128 / ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].TestMemoryRdWords * num1);
      int num2 = repetitions * (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].TestMemoryRdWords;
      int num3 = 0;
      this.prepTestMem();
      do
      {
        ProgCommand.RunScriptUploadNoLen2(27, repetitions);
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
          if (num9 < num1)
            num10 |= (uint) numArray1[num4 + num9++] << 16;
          if (num9 < num1)
            num10 |= (uint) numArray1[num4 + num9++] << 24;
          num4 += num9;
          if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemShift > 0)
            num10 = num10 >> 1 & ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
          FormTestMemory.TestMemory[num3++] = num10;
        }
      }
      while (num3 < FormProgUSB.TestMemoryWords);
      ProgCommand.RunScript(1, 1);
    }

    public bool HexImportExportTM()
    {
      if (this.checkBoxTestMemImportExport.Enabled)
        return this.checkBoxTestMemImportExport.Checked;
      else
        return false;
    }

    private void prepTestMem()
    {
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart == 16384)
        ProgCommand.SendScript(new byte[7]
        {
          (byte) 238,
          (byte) 6,
          (byte) 0,
          (byte) 242,
          (byte) 0,
          (byte) 242,
          (byte) 0
        });
      else if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart == 2048)
      {
        int num = this.getTestMemAddress() / 4 - 1;
        ProgCommand.SendScript(new byte[18]
        {
          (byte) 210,
          (byte) (num & (int) byte.MaxValue),
          (byte) 210,
          (byte) (num >> 8 & (int) byte.MaxValue),
          (byte) 238,
          (byte) 6,
          (byte) 6,
          (byte) 238,
          (byte) 6,
          (byte) 6,
          (byte) 238,
          (byte) 6,
          (byte) 6,
          (byte) 238,
          (byte) 6,
          (byte) 6,
          (byte) 221,
          (byte) 12
        });
      }
      else
      {
        if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart != 2097152)
          return;
        ProgCommand.SendScript(new byte[18]
        {
          (byte) 218,
          (byte) 32,
          (byte) 14,
          (byte) 218,
          (byte) 248,
          (byte) 110,
          (byte) 218,
          (byte) 0,
          (byte) 14,
          (byte) 218,
          (byte) 247,
          (byte) 110,
          (byte) 218,
          (byte) 0,
          (byte) 14,
          (byte) 218,
          (byte) 246,
          (byte) 110
        });
      }
    }

    private void initTestMemoryGUI()
    {
      this.dataGridTestMemory.DefaultCellStyle.Font = new Font("Courier New", 9f);
      this.dataGridTestMemory.ColumnCount = 9;
      this.dataGridTestMemory.RowCount = 512;
      this.dataGridTestMemory[0, 0].Selected = true;
      this.dataGridTestMemory[0, 0].Selected = false;
      this.dataGridTestMemory.Columns[0].Width = (int) (59.0 * (double) FormProgUSB.ScalefactW);
      this.dataGridTestMemory.Columns[0].ReadOnly = true;
      if (!FormProgUSB.TestMemoryImportExport)
        return;
      this.checkBoxTestMemImportExport.Checked = true;
    }

    public void UpdateTestMemForm()
    {
      this.textBoxTestMemSize.Text = FormProgUSB.TestMemoryWords.ToString();
      if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart > 0U)
      {
        this.textBoxBaselineConfig.Enabled = true;
        this.textBoxTestMemSize.Enabled = true;
        this.checkBoxTestMemImportExport.Enabled = true;
        this.labelNotSupported.Visible = false;
      }
      else
      {
        this.textBoxBaselineConfig.Enabled = false;
        this.textBoxTestMemSize.Enabled = false;
        this.checkBoxTestMemImportExport.Enabled = false;
        this.dataGridTestMemory.Enabled = false;
        this.labelNotSupported.Visible = true;
      }
    }

    public void ClearTestMemory()
    {
      for (int index = 0; index < FormTestMemory.TestMemory.Length; ++index)
        FormTestMemory.TestMemory[index] = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
    }

    public void UpdateTestMemoryGrid()
    {
      bool flag1 = false;
      int num1 = 0;
      int num2 = this.getTestMemAddress() * (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
      int num3 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDAddr;
      if (ProgCommand.ActivePart != this.lastPart || ProgCommand.GetActiveFamily() != this.lastFamily)
      {
        this.ClearTestMemory();
        this.lastPart = ProgCommand.ActivePart;
        this.lastFamily = ProgCommand.GetActiveFamily();
      }
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart == 2048)
        num3 = num2;
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords > 0 && num3 >= num2 && num3 < num2 + FormProgUSB.TestMemoryWords)
      {
        flag1 = true;
        num1 = (num3 - num2) / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
      }
      bool flag2 = false;
      int num4 = 0;
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords > 0 && (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr >= (long) num2 && (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr < (long) (num2 + FormProgUSB.TestMemoryWords))
      {
        flag2 = true;
        num4 = (int) ((long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr - (long) num2) / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
      }
      int num5 = 9;
      this.dataGridTestMemory.Columns[0].Width = (int) (51.0 * (double) FormProgUSB.ScalefactW);
      int num6 = 8;
      int num7 = (int) (35.0 * (double) FormProgUSB.ScalefactW);
      int testMemAddress = this.getTestMemAddress();
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart == 2097152)
        testMemAddress *= 2;
      if (this.dataGridTestMemory.ColumnCount != num5)
      {
        this.dataGridTestMemory.Rows.Clear();
        this.dataGridTestMemory.ColumnCount = num5;
      }
      for (int index = 1; index < this.dataGridTestMemory.ColumnCount; ++index)
        this.dataGridTestMemory.Columns[index].Width = num7;
      int num8 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].AddressIncrement;
      int num9 = num6;
      int num10 = FormProgUSB.TestMemoryWords / num9;
      int num11 = num8 * num6;
      if (this.dataGridTestMemory.RowCount != num10)
      {
        this.dataGridTestMemory.Rows.Clear();
        this.dataGridTestMemory.RowCount = num10;
      }
      int num12 = this.dataGridTestMemory.RowCount * num11 - 1;
      string format1 = "{0:X3}";
      if (num12 > (int) ushort.MaxValue)
        format1 = "{0:X5}";
      else if (num12 > 4095)
        format1 = "{0:X4}";
      int index1 = 0;
      int num13 = 0;
      for (; index1 < this.dataGridTestMemory.RowCount; ++index1)
      {
        this.dataGridTestMemory[0, index1].Value = (object) string.Format(format1, (object) (testMemAddress + num13));
        this.dataGridTestMemory[0, index1].Style.BackColor = SystemColors.ControlLight;
        num13 += num11;
      }
      string format2 = "{0:X3}";
      if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > 4095U)
        format2 = "{0:X4}";
      if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > (uint) ushort.MaxValue)
        format2 = "{0:X6}";
      for (int index2 = 0; index2 < num9; ++index2)
        this.dataGridTestMemory.Columns[index2 + 1].ReadOnly = true;
      int index3 = 0;
      int index4 = 0;
      for (; index3 < this.dataGridTestMemory.RowCount; ++index3)
      {
        for (int index2 = 0; index2 < num9; ++index2)
        {
          if (flag1 && index4 >= num1 && index4 < num1 + (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords)
          {
            FormTestMemory.TestMemory[index4] = ProgCommand.DeviceBuffers.UserIDs[index4 - num1];
            this.dataGridTestMemory[index2 + 1, index3].ToolTipText = string.Format(format1, (object) (testMemAddress + index4 * num8));
            this.dataGridTestMemory[index2 + 1, index3].Value = (object) string.Format(format2, (object) ProgCommand.DeviceBuffers.UserIDs[index4++ - num1]);
            this.dataGridTestMemory[index2 + 1, index3].Style.BackColor = Color.LightSteelBlue;
            this.dataGridTestMemory[index2 + 1, index3].ReadOnly = false;
          }
          else if (flag2 && index4 >= num4 && index4 < num4 + (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords)
          {
            FormTestMemory.TestMemory[index4] = ProgCommand.DeviceBuffers.ConfigWords[index4 - num4];
            this.dataGridTestMemory[index2 + 1, index3].ToolTipText = string.Format(format1, (object) (testMemAddress + index4 * num8));
            this.dataGridTestMemory[index2 + 1, index3].Value = (object) string.Format(format2, (object) ProgCommand.DeviceBuffers.ConfigWords[index4++ - num4]);
            this.dataGridTestMemory[index2 + 1, index3].Style.BackColor = Color.LightSalmon;
            this.dataGridTestMemory[index2 + 1, index3].ReadOnly = false;
          }
          else if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CalibrationWords > 0 && index4 >= num4 + (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords && index4 < num4 + (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords + (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CalibrationWords)
          {
            this.dataGridTestMemory[index2 + 1, index3].ToolTipText = string.Format(format1, (object) (testMemAddress + index4 * num8));
            this.dataGridTestMemory[index2 + 1, index3].Value = (object) string.Format(format2, (object) FormTestMemory.TestMemory[index4++]);
            this.dataGridTestMemory[index2 + 1, index3].Style.BackColor = Color.Gold;
            this.dataGridTestMemory[index2 + 1, index3].ReadOnly = false;
          }
          else
          {
            this.dataGridTestMemory[index2 + 1, index3].ToolTipText = string.Format(format1, (object) (testMemAddress + index4 * num8));
            this.dataGridTestMemory[index2 + 1, index3].Value = (object) string.Format(format2, (object) FormTestMemory.TestMemory[index4++]);
            this.dataGridTestMemory[index2 + 1, index3].Style.BackColor = SystemColors.Window;
          }
        }
      }
      if (this.dataGridTestMemory.FirstDisplayedCell != null && !this.testMemJustEdited)
      {
        int rowIndex = this.dataGridTestMemory.FirstDisplayedCell.RowIndex;
        this.dataGridTestMemory[0, rowIndex].Selected = true;
        this.dataGridTestMemory[0, rowIndex].Selected = false;
      }
      else if (this.dataGridTestMemory.FirstDisplayedCell == null)
      {
        this.dataGridTestMemory[0, 0].Selected = true;
        this.dataGridTestMemory[0, 0].Selected = false;
      }
      this.testMemJustEdited = false;
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart == 2048)
      {
        this.labelBLConfig.Visible = true;
        this.textBoxBaselineConfig.Visible = true;
        this.textBoxBaselineConfig.Text = string.Format("{0:X4}", (object) ProgCommand.DeviceBuffers.ConfigWords[0]);
      }
      else
      {
        this.labelBLConfig.Visible = false;
        this.textBoxBaselineConfig.Visible = false;
      }
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart == 16384)
      {
        this.labelCalWarning.Visible = true;
        this.buttonWriteCalWords.Visible = true;
        this.buttonWriteCalWords.Enabled = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CalibrationWords > 0;
      }
      else
      {
        this.labelCalWarning.Visible = false;
        this.buttonWriteCalWords.Visible = false;
      }
    }

    private void FormTestMemory_FormClosing(object sender, FormClosingEventArgs e)
    {
      FormProgUSB.TestMemoryOpen = false;
    }

    private int getTestMemAddress()
    {
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart != 2048)
        return (int) (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart / (uint) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes);
      int num = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem;
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem > 0)
        num += (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem;
      return num;
    }

    private void textBoxTestMemSize_Leave(object sender, EventArgs e)
    {
      this.memSizeEdit();
    }

    private void textBoxTestMemSize_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((int) e.KeyChar != 13)
        return;
      this.memSizeEdit();
    }

    private void memSizeEdit()
    {
      this.labelTestMemSize8.Visible = false;
      try
      {
        string p_value = this.textBoxTestMemSize.Text;
        if (this.textBoxTestMemSize.Text.Length > 1)
        {
          if (this.textBoxTestMemSize.Text.Substring(0, 2) == "0x")
            p_value = this.textBoxTestMemSize.Text;
          else if (this.textBoxTestMemSize.Text.Substring(0, 1) == "x")
            p_value = "0" + this.textBoxTestMemSize.Text;
        }
        FormProgUSB.TestMemoryWords = Utilities.Convert_Value_To_Int(p_value);
        if (FormProgUSB.TestMemoryWords > 1024)
          FormProgUSB.TestMemoryWords = 1024;
        else if (FormProgUSB.TestMemoryWords < 16)
          FormProgUSB.TestMemoryWords = 16;
        else if (FormProgUSB.TestMemoryWords % 16 != 0)
        {
          FormProgUSB.TestMemoryWords = (FormProgUSB.TestMemoryWords / 16 + 1) * 16;
          this.labelTestMemSize8.Visible = true;
        }
      }
      catch
      {
      }
      this.UpdateTestMemForm();
      this.UpdateTestMemoryGrid();
    }

    private void dataGridTestMemory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      int rowIndex = e.RowIndex;
      int columnIndex = e.ColumnIndex;
      int num1 = Utilities.Convert_Value_To_Int("0x" + this.dataGridTestMemory[columnIndex, rowIndex].FormattedValue.ToString());
      int num2 = this.dataGridTestMemory.ColumnCount - 1;
      int index = rowIndex * num2 + columnIndex - 1;
      int num3 = this.getTestMemAddress() * (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
      int num4 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDAddr;
      if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart == 2048)
        num4 = num3;
      FormTestMemory.TestMemory[index] = (uint) ((ulong) num1 & (ulong) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue);
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords > 0 && num4 >= num3 && num4 < num3 + FormProgUSB.TestMemoryWords)
      {
        int num5 = (num4 - num3) / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
        if (index >= num5 && index < num5 + (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].UserIDWords)
        {
          ProgCommand.DeviceBuffers.UserIDs[index - num5] = (uint) ((ulong) num1 & (ulong) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue);
          if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].TestMemoryStart == 2097152)
            ProgCommand.DeviceBuffers.UserIDs[index - num5] &= (uint) byte.MaxValue;
        }
      }
      if ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords > 0 && (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr >= (long) num3 && (long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr < (long) (num3 + FormProgUSB.TestMemoryWords))
      {
        int num5 = (int) ((long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr - (long) num3) / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
        if (index >= num5 && index < num5 + (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords)
          ProgCommand.DeviceBuffers.ConfigWords[index - num5] = (uint) num1 & (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[index - num5];
      }
      this.testMemJustEdited = true;
      this.UpdateMainFormGUI();
    }

    private void textBoxBaselineConfig_Leave(object sender, EventArgs e)
    {
      this.baselineConfigEdit();
    }

    private void textBoxBaselineConfig_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((int) e.KeyChar != 13)
        return;
      this.baselineConfigEdit();
    }

    private void baselineConfigEdit()
    {
      int num = Utilities.Convert_Value_To_Int("0x" + this.textBoxBaselineConfig.Text);
      ProgCommand.DeviceBuffers.ConfigWords[0] = (uint) num;
      this.UpdateTestMemoryGrid();
      this.UpdateMainFormGUI();
    }

    private void checkBoxTestMemImportExport_CheckedChanged(object sender, EventArgs e)
    {
      FormProgUSB.TestMemoryImportExport = this.checkBoxTestMemImportExport.Checked;
    }

    private void buttonClearTestMem_Click(object sender, EventArgs e)
    {
      this.ClearTestMemory();
      this.UpdateTestMemoryGrid();
    }

    private void buttonWriteCalWords_Click(object sender, EventArgs e)
    {
      uint[] calwords = new uint[(int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CalibrationWords];
      int num1 = this.getTestMemAddress() * (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].ProgMemHexBytes;
      int num2 = (int) ((long) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigAddr - (long) num1) / (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation + (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords;
      for (int index = 0; index < calwords.Length; ++index)
        calwords[index] = FormTestMemory.TestMemory[num2 + index];
      this.CallMainFormEraseWrCal(calwords);
    }
  }
}
