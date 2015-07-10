// Type: SysProgUSB.DialogUserIDs
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogUserIDs : Form
  {
    private IContainer components;
    private DataGridView dataGridViewIDMem;
    private Button buttonClose;
    public static bool IDMemOpen;

    public DialogUserIDs()
    {
      this.InitializeComponent();
      DialogUserIDs.IDMemOpen = true;
      this.dataGridViewIDMem.DefaultCellStyle.Font = new Font("Courier New", 9f);
      this.UpdateIDMemoryGrid();
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
      this.dataGridViewIDMem = new DataGridView();
      this.buttonClose = new Button();
      this.dataGridViewIDMem.BeginInit();
      this.SuspendLayout();
      this.dataGridViewIDMem.AllowUserToAddRows = false;
      this.dataGridViewIDMem.AllowUserToDeleteRows = false;
      this.dataGridViewIDMem.AllowUserToResizeColumns = false;
      this.dataGridViewIDMem.AllowUserToResizeRows = false;
      this.dataGridViewIDMem.BackgroundColor = SystemColors.Window;
      this.dataGridViewIDMem.CellBorderStyle = DataGridViewCellBorderStyle.None;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dataGridViewIDMem.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dataGridViewIDMem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGridViewIDMem.ColumnHeadersVisible = false;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dataGridViewIDMem.DefaultCellStyle = gridViewCellStyle2;
      this.dataGridViewIDMem.GridColor = SystemColors.Window;
      this.dataGridViewIDMem.Location = new Point(16, 15);
      this.dataGridViewIDMem.Margin = new Padding(4, 4, 4, 4);
      this.dataGridViewIDMem.MultiSelect = false;
      this.dataGridViewIDMem.Name = "dataGridViewIDMem";
      this.dataGridViewIDMem.ReadOnly = true;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = SystemColors.Control;
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dataGridViewIDMem.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dataGridViewIDMem.RowHeadersVisible = false;
      this.dataGridViewIDMem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewIDMem.RowsDefaultCellStyle = gridViewCellStyle4;
      this.dataGridViewIDMem.RowTemplate.Height = 17;
      this.dataGridViewIDMem.ScrollBars = ScrollBars.Vertical;
      this.dataGridViewIDMem.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dataGridViewIDMem.ShowCellToolTips = false;
      this.dataGridViewIDMem.Size = new Size(308, 170);
      this.dataGridViewIDMem.TabIndex = 0;
      this.buttonClose.Location = new Point(133, 192);
      this.buttonClose.Margin = new Padding(4, 4, 4, 4);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new Size(80, 28);
      this.buttonClose.TabIndex = 1;
      this.buttonClose.Text = "Salir";
      this.buttonClose.UseVisualStyleBackColor = true;
      this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
      this.AutoScaleDimensions = new SizeF(120f, 120f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(339, 233);
      this.Controls.Add((Control) this.buttonClose);
      this.Controls.Add((Control) this.dataGridViewIDMem);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogUserIDs";
      this.Text = "Bits ID del Usuario";
      this.FormClosing += new FormClosingEventHandler(this.DialogUserIDs_FormClosing);
      this.dataGridViewIDMem.EndInit();
      this.ResumeLayout(false);
    }

    public void UpdateIDMemoryGrid()
    {
      int num = (int) (53.0 * (double) FormProgUSB.ScalefactW);
      this.dataGridViewIDMem.ColumnCount = 4;
      for (int index = 0; index < this.dataGridViewIDMem.ColumnCount; ++index)
        this.dataGridViewIDMem.Columns[index].Width = num;
      this.dataGridViewIDMem.RowCount = ProgCommand.DeviceBuffers.UserIDs.Length / 4;
      int index1 = 0;
      int index2 = 0;
      for (int index3 = 0; index3 < ProgCommand.DeviceBuffers.UserIDs.Length; ++index3)
      {
        this.dataGridViewIDMem[index2, index1].Value = (object) string.Format("{0:X6}", (object) ProgCommand.DeviceBuffers.UserIDs[index3]);
        ++index2;
        if (index2 >= 4)
        {
          index2 = 0;
          ++index1;
        }
      }
      this.dataGridViewIDMem[0, 0].Selected = true;
      this.dataGridViewIDMem[0, 0].Selected = false;
    }

    private void DialogUserIDs_FormClosing(object sender, FormClosingEventArgs e)
    {
      DialogUserIDs.IDMemOpen = false;
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
