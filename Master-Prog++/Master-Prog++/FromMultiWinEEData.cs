// Type: SysProgUSB.FormMultiWinEEData
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class FormMultiWinEEData : Form
  {
    private string dataFormat = "";
    private string addrFormat = "";
    private IContainer components;
    private ComboBox comboBoxProgMemView;
    private DataGridView dataGridProgramMemory;
    private Label displayEEProgInfo;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem toolStripMenuItemContextSelectAll;
    private ToolStripMenuItem toolStripMenuItemContextCopy;
    public bool InitDone;
    private bool maxed;
    private bool progMemJustEdited;
    private int asciiBytes;
    private int lastPart;
    private int lastFam;
    public DelegateMemEdited TellMainFormProgMemEdited;
    public DelegateUpdateGUI TellMainFormUpdateGUI;
    public DelegateMultiEEMemClosed TellMainFormEEMemClosed;

    public FormMultiWinEEData()
    {
      this.InitializeComponent();
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
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormMultiWinEEData));
      this.comboBoxProgMemView = new ComboBox();
      this.dataGridProgramMemory = new DataGridView();
      this.displayEEProgInfo = new Label();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.toolStripMenuItemContextSelectAll = new ToolStripMenuItem();
      this.toolStripMenuItemContextCopy = new ToolStripMenuItem();
      this.dataGridProgramMemory.BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.comboBoxProgMemView.BackColor = Color.Aqua;
      this.comboBoxProgMemView.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxProgMemView.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBoxProgMemView.FormattingEnabled = true;
      this.comboBoxProgMemView.Items.AddRange(new object[3]
      {
        (object) "Hexadecimal",
        (object) "ASCII Tipo Word",
        (object) "ASCII Tipo Byte"
      });
      this.comboBoxProgMemView.Location = new Point(12, 11);
      this.comboBoxProgMemView.Margin = new Padding(2);
      this.comboBoxProgMemView.Name = "comboBoxProgMemView";
      this.comboBoxProgMemView.Size = new Size(91, 21);
      this.comboBoxProgMemView.TabIndex = 8;
      this.comboBoxProgMemView.SelectionChangeCommitted += new EventHandler(this.comboBoxProgMemView_SelectionChangeCommitted);
      this.dataGridProgramMemory.AllowUserToAddRows = false;
      this.dataGridProgramMemory.AllowUserToDeleteRows = false;
      this.dataGridProgramMemory.AllowUserToResizeColumns = false;
      this.dataGridProgramMemory.AllowUserToResizeRows = false;
      this.dataGridProgramMemory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridProgramMemory.BackgroundColor = SystemColors.Window;
      this.dataGridProgramMemory.CellBorderStyle = DataGridViewCellBorderStyle.None;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dataGridProgramMemory.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dataGridProgramMemory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGridProgramMemory.ColumnHeadersVisible = false;
      this.dataGridProgramMemory.ContextMenuStrip = this.contextMenuStrip1;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dataGridProgramMemory.DefaultCellStyle = gridViewCellStyle2;
      this.dataGridProgramMemory.Enabled = false;
      this.dataGridProgramMemory.Location = new Point(12, 39);
      this.dataGridProgramMemory.Name = "dataGridProgramMemory";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = SystemColors.Control;
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dataGridProgramMemory.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dataGridProgramMemory.RowHeadersVisible = false;
      this.dataGridProgramMemory.RowHeadersWidth = 75;
      this.dataGridProgramMemory.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dataGridProgramMemory.RowsDefaultCellStyle = gridViewCellStyle4;
      this.dataGridProgramMemory.RowTemplate.Height = 17;
      this.dataGridProgramMemory.ScrollBars = ScrollBars.Vertical;
      this.dataGridProgramMemory.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dataGridProgramMemory.Size = new Size(510, 49);
      this.dataGridProgramMemory.TabIndex = 7;
      this.dataGridProgramMemory.CellMouseDown += new DataGridViewCellMouseEventHandler(this.dataGridProgramMemory_CellMouseDown);
      this.dataGridProgramMemory.CellEndEdit += new DataGridViewCellEventHandler(this.progMemEdit);
      this.displayEEProgInfo.AutoSize = true;
      this.displayEEProgInfo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.displayEEProgInfo.ForeColor = Color.Red;
      this.displayEEProgInfo.Location = new Point(107, 14);
      this.displayEEProgInfo.Margin = new Padding(2, 0, 2, 0);
      this.displayEEProgInfo.Name = "displayEEProgInfo";
      this.displayEEProgInfo.Size = new Size(206, 13);
      this.displayEEProgInfo.TabIndex = 9;
      this.displayEEProgInfo.Text = "Preserve EEPROM and User IDs on write.";
      this.displayEEProgInfo.Visible = false;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.toolStripMenuItemContextSelectAll,
        (ToolStripItem) this.toolStripMenuItemContextCopy
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(164, 48);
      this.toolStripMenuItemContextSelectAll.Name = "toolStripMenuItemContextSelectAll";
      this.toolStripMenuItemContextSelectAll.ShortcutKeyDisplayString = "Ctrl-A";
      this.toolStripMenuItemContextSelectAll.Size = new Size(163, 22);
      this.toolStripMenuItemContextSelectAll.Text = "Select All";
      this.toolStripMenuItemContextSelectAll.Click += new EventHandler(this.toolStripMenuItemContextSelectAll_Click);
      this.toolStripMenuItemContextCopy.Name = "toolStripMenuItemContextCopy";
      this.toolStripMenuItemContextCopy.ShortcutKeyDisplayString = "Ctrl-C";
      this.toolStripMenuItemContextCopy.Size = new Size(163, 22);
      this.toolStripMenuItemContextCopy.Text = "Copy";
      this.toolStripMenuItemContextCopy.Click += new EventHandler(this.toolStripMenuItemContextCopy_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(536, 100);
      this.Controls.Add((Control) this.displayEEProgInfo);
      this.Controls.Add((Control) this.comboBoxProgMemView);
      this.Controls.Add((Control) this.dataGridProgramMemory);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MinimumSize = new Size(200, 110);
      this.Name = "FormMultiWinEEData";
      this.SizeGripStyle = SizeGripStyle.Show;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "MASTER-PROG EEPROM Data";
      this.Resize += new EventHandler(this.FormMultiWinEEData_Resize);
      this.FormClosing += new FormClosingEventHandler(this.FormMultiWinEEData_FormClosing);
      this.ResizeEnd += new EventHandler(this.FormMultiWinEEData_ResizeEnd);
      this.dataGridProgramMemory.EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void InitMemDisplay(int viewMode)
    {
      this.dataGridProgramMemory.DefaultCellStyle.Font = new Font("Courier New", 9f);
      this.comboBoxProgMemView.SelectedIndex = viewMode;
      this.ReCalcMultiWinMem();
      this.InitDone = true;
    }

    public int GetViewMode()
    {
      return this.comboBoxProgMemView.SelectedIndex;
    }

    public void DisplayDisable()
    {
      this.comboBoxProgMemView.Enabled = false;
      this.dataGridProgramMemory.Enabled = false;
      this.dataGridProgramMemory.ForeColor = SystemColors.GrayText;
    }

    public void DisplayEnable()
    {
      this.comboBoxProgMemView.Enabled = true;
      this.dataGridProgramMemory.Enabled = true;
      this.dataGridProgramMemory.ForeColor = SystemColors.WindowText;
    }

    public void DisplayEETextOn(string displayText)
    {
      this.displayEEProgInfo.Text = displayText;
      this.displayEEProgInfo.Visible = true;
    }

    public void DisplayEETextOff()
    {
      this.displayEEProgInfo.Visible = false;
    }

    public void ReCalcMultiWinMem()
    {
      uint num1 = (uint) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem;
      if ((int) num1 == 0 || this.WindowState == FormWindowState.Minimized)
        return;
      uint num2 = (uint) ((int) num1 * (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemAddressIncrement - 1);
      int num3 = 30;
      this.addrFormat = "{0:X2}";
      if (num2 > 4095U)
      {
        num3 = 40;
        this.addrFormat = "{0:X4}";
      }
      else if (num2 > (uint) byte.MaxValue)
      {
        num3 = 32;
        this.addrFormat = "{0:X3}";
      }
      int num4 = (int) ((double) num3 * (double) FormProgUSB.ScalefactW);
      uint num5 = ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue;
      int num6 = 24;
      int num7 = 16;
      this.asciiBytes = 1;
      this.dataFormat = "{0:X2}";
      if (num5 > (uint) ushort.MaxValue)
      {
        num6 = 36;
        num7 = 28;
        this.asciiBytes = 2;
        this.dataFormat = "{0:X4}";
      }
      else if ((int) num5 == 4095)
      {
        num6 = 28;
        num7 = 28;
        this.asciiBytes = 2;
        this.dataFormat = "{0:X3}";
      }
      float num8 = 1f;
      if (this.comboBoxProgMemView.SelectedIndex > 0)
      {
        num8 = (float) num7 / ((float) num7 + (float) num6);
        num6 += num7;
      }
      int num9 = (int) ((double) num6 * (double) FormProgUSB.ScalefactW);
      int num10 = this.dataGridProgramMemory.Size.Width - num4 - (int) (20.0 * (double) FormProgUSB.ScalefactW);
      int num11 = num10 / num9;
      int num12 = 1;
      while (num12 <= 256)
      {
        if (num12 > num11)
        {
          num11 = num12 / 2;
          break;
        }
        else
          num12 *= 2;
      }
      if (num11 > (int) num1)
        num11 = (int) num1;
      int num13 = num10 / num11;
      if (this.comboBoxProgMemView.SelectedIndex > 0)
      {
        num7 = (int) ((double) num8 * (double) num13);
        num13 -= num7;
      }
      if (this.dataGridProgramMemory.FirstDisplayedCell != null && !this.progMemJustEdited)
      {
        int rowIndex = this.dataGridProgramMemory.FirstDisplayedCell.RowIndex;
        this.dataGridProgramMemory.MultiSelect = false;
        this.dataGridProgramMemory[0, rowIndex].Selected = true;
        this.dataGridProgramMemory[0, rowIndex].Selected = false;
        this.dataGridProgramMemory.MultiSelect = true;
      }
      else if (this.dataGridProgramMemory.FirstDisplayedCell == null && this.dataGridProgramMemory.RowCount > 0)
      {
        this.dataGridProgramMemory.MultiSelect = false;
        this.dataGridProgramMemory[0, 0].Selected = true;
        this.dataGridProgramMemory[0, 0].Selected = false;
        this.dataGridProgramMemory.MultiSelect = true;
      }
      this.progMemJustEdited = false;
      this.dataGridProgramMemory.Rows.Clear();
      this.dataGridProgramMemory.ColumnCount = this.comboBoxProgMemView.SelectedIndex <= 0 ? num11 + 1 : 2 * num11 + 1;
      this.dataGridProgramMemory.Columns[0].Width = num4;
      for (int index = 1; index <= num11; ++index)
        this.dataGridProgramMemory.Columns[index].Width = num13;
      if (this.comboBoxProgMemView.SelectedIndex > 0)
      {
        for (int index = num11 + 1; index <= 2 * num11; ++index)
          this.dataGridProgramMemory.Columns[index].Width = num7;
      }
      int num14 = (int) num1 / num11;
      if ((long) num1 % (long) num11 > 0L)
        ++num14;
      this.dataGridProgramMemory.RowCount = num14;
      int num15 = num11 * (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemAddressIncrement;
      int index1 = 0;
      int num16 = 0;
      for (; index1 < num14; ++index1)
      {
        this.dataGridProgramMemory[0, index1].Value = (object) string.Format(this.addrFormat, (object) num16);
        this.dataGridProgramMemory[0, index1].ReadOnly = true;
        this.dataGridProgramMemory[0, index1].Style.BackColor = SystemColors.ControlLight;
        num16 += num15;
      }
      this.updateDisplay();
    }

    public void UpdateMultiWinMem()
    {
      if (this.lastPart != ProgCommand.ActivePart || this.lastFam != ProgCommand.GetActiveFamily())
        this.ReCalcMultiWinMem();
      else
        this.updateDisplay();
    }

    private void updateDisplay()
    {
      int index1 = this.dataGridProgramMemory.RowCount - 1;
      int num1 = this.dataGridProgramMemory.ColumnCount - 1;
      int num2 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].EEMemAddressIncrement;
      if (this.comboBoxProgMemView.SelectedIndex > 0)
        num1 /= 2;
      int index2 = 0;
      int num3 = 0;
      int num4 = 0;
      for (; index2 < index1; ++index2)
      {
        for (int index3 = 1; index3 <= num1; ++index3)
        {
          this.dataGridProgramMemory[index3, index2].Value = (object) string.Format(this.dataFormat, (object) ProgCommand.DeviceBuffers.EEPromMemory[num3++]);
          this.dataGridProgramMemory[index3, index2].ToolTipText = string.Format(this.addrFormat, (object) num4);
          num4 += num2;
        }
      }
      int num5 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].EEMem % num1;
      if (num5 == 0)
        num5 = num1;
      int num6 = index1 * num1;
      for (int index3 = 1; index3 <= num1; ++index3)
      {
        if (index3 <= num5)
        {
          this.dataGridProgramMemory[index3, index1].Value = (object) string.Format(this.dataFormat, (object) ProgCommand.DeviceBuffers.EEPromMemory[num6++]);
          this.dataGridProgramMemory[index3, index1].ToolTipText = string.Format(this.addrFormat, (object) (num6 * num2));
        }
        else
        {
          this.dataGridProgramMemory[index3, index1].Value = (object) "";
          this.dataGridProgramMemory[index3, index1].ToolTipText = "";
          this.dataGridProgramMemory[index3, index1].ReadOnly = true;
        }
      }
      if (this.comboBoxProgMemView.SelectedIndex > 0)
      {
        for (int index3 = num1 + 1; index3 <= 2 * num1; ++index3)
          this.dataGridProgramMemory.Columns[index3].ReadOnly = true;
        if (this.comboBoxProgMemView.SelectedIndex == 1)
        {
          int index3 = 0;
          int num7 = 0;
          int num8 = 0;
          for (; index3 < index1; ++index3)
          {
            for (int index4 = num1 + 1; index4 <= 2 * num1; ++index4)
            {
              this.dataGridProgramMemory[index4, index3].Value = (object) Utilities.ConvertIntASCII((int) ProgCommand.DeviceBuffers.EEPromMemory[num7++], this.asciiBytes);
              this.dataGridProgramMemory[index4, index3].ToolTipText = string.Format(this.addrFormat, (object) num8);
              num8 += num2;
            }
          }
          int num9 = index1 * num1;
          for (int index4 = num1 + 1; index4 <= 2 * num1; ++index4)
          {
            if (index4 <= num1 + num5)
            {
              this.dataGridProgramMemory[index4, index1].Value = (object) Utilities.ConvertIntASCII((int) ProgCommand.DeviceBuffers.EEPromMemory[num9++], this.asciiBytes);
              this.dataGridProgramMemory[index4, index1].ToolTipText = string.Format(this.addrFormat, (object) (num9 * num2));
            }
            else
            {
              this.dataGridProgramMemory[index4, index1].Value = (object) "";
              this.dataGridProgramMemory[index4, index1].ToolTipText = "";
              this.dataGridProgramMemory[index4, index1].ReadOnly = true;
            }
          }
        }
        else
        {
          int index3 = 0;
          int num7 = 0;
          int num8 = 0;
          for (; index3 < index1; ++index3)
          {
            for (int index4 = num1 + 1; index4 <= 2 * num1; ++index4)
            {
              this.dataGridProgramMemory[index4, index3].Value = (object) Utilities.ConvertIntASCIIReverse((int) ProgCommand.DeviceBuffers.EEPromMemory[num7++], this.asciiBytes);
              this.dataGridProgramMemory[index4, index3].ToolTipText = string.Format(this.addrFormat, (object) num8);
              num8 += num2;
            }
          }
          int num9 = index1 * num1;
          for (int index4 = num1 + 1; index4 <= 2 * num1; ++index4)
          {
            if (index4 <= num1 + num5)
            {
              this.dataGridProgramMemory[index4, index1].Value = (object) Utilities.ConvertIntASCIIReverse((int) ProgCommand.DeviceBuffers.EEPromMemory[num9++], this.asciiBytes);
              this.dataGridProgramMemory[index4, index1].ToolTipText = string.Format(this.addrFormat, (object) (num9 * num2));
            }
            else
            {
              this.dataGridProgramMemory[index4, index1].Value = (object) "";
              this.dataGridProgramMemory[index4, index1].ToolTipText = "";
              this.dataGridProgramMemory[index4, index1].ReadOnly = true;
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
      uint num3 = (uint) byte.MaxValue;
      if (ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue > (uint) ushort.MaxValue)
        num3 = (uint) ushort.MaxValue;
      else if ((int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue == 4095)
        num3 = 4095U;
      ProgCommand.DeviceBuffers.EEPromMemory[rowIndex * num2 + columnIndex - 1] = (uint) ((ulong) num1 & (ulong) num3);
      this.TellMainFormProgMemEdited();
      this.progMemJustEdited = true;
      this.TellMainFormUpdateGUI();
    }

    private void FormMultiWinEEData_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.FormOwnerClosing)
        return;
      e.Cancel = true;
      this.TellMainFormEEMemClosed();
      this.Hide();
    }

    private void comboBoxProgMemView_SelectionChangeCommitted(object sender, EventArgs e)
    {
      this.ReCalcMultiWinMem();
    }

    private void FormMultiWinEEData_ResizeEnd(object sender, EventArgs e)
    {
      this.ReCalcMultiWinMem();
    }

    private void FormMultiWinEEData_Resize(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Maximized)
      {
        this.maxed = true;
        this.ReCalcMultiWinMem();
      }
      else
      {
        if (!this.maxed)
          return;
        this.maxed = false;
        this.ReCalcMultiWinMem();
      }
    }

    private void toolStripMenuItemContextSelectAll_Click(object sender, EventArgs e)
    {
      this.dataGridProgramMemory.SelectAll();
    }

    private void toolStripMenuItemContextCopy_Click(object sender, EventArgs e)
    {
      Clipboard.SetDataObject((object) this.dataGridProgramMemory.GetClipboardContent());
    }

    private void dataGridProgramMemory_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.dataGridProgramMemory.Focus();
    }
  }
}
