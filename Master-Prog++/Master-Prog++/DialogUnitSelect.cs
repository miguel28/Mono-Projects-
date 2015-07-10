// Type: SysProgUSB.DialogUnitSelect
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogUnitSelect : Form
  {
    private IContainer components;
    private Label label1;
    private Button buttonSelectUnit;
    private ListBox listBoxUnits;
    private Label label2;

    public DialogUnitSelect()
    {
      this.InitializeComponent();
      this.Size = new Size(this.Size.Width, (int) ((double) FormProgUSB.ScalefactH * (double) this.Size.Height));
      for (ushort pk2ID = (ushort) 0; (int) pk2ID < 8 && ProgCommand.DetectPICkit2Device(pk2ID, false) != Constants.PICkit2USB.notFound; ++pk2ID)
      {
        string str = ProgCommand.GetSerialUnitID();
        if (str == "PIC18F2550")
          str = "MASTER-PROG";
        this.listBoxUnits.Items.Add((object) ("  " + pk2ID.ToString() + "                " + str));
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.buttonSelectUnit = new Button();
      this.listBoxUnits = new ListBox();
      this.label2 = new Label();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(13, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(190, 48);
      this.label1.TabIndex = 0;
      this.label1.Text = "More than one MASTER-PROG unit has\r\nbeen detected. \r\nPlease select a MASTER-PROG to use:";
      this.buttonSelectUnit.Enabled = false;
      this.buttonSelectUnit.Location = new Point(76, 166);
      this.buttonSelectUnit.Name = "buttonSelectUnit";
      this.buttonSelectUnit.Size = new Size(80, 26);
      this.buttonSelectUnit.TabIndex = 2;
      this.buttonSelectUnit.Text = "Select";
      this.buttonSelectUnit.UseVisualStyleBackColor = true;
      this.buttonSelectUnit.Click += new EventHandler(this.buttonSelectUnit_Click);
      this.listBoxUnits.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.listBoxUnits.FormattingEnabled = true;
      this.listBoxUnits.ItemHeight = 15;
      this.listBoxUnits.Location = new Point(16, 86);
      this.listBoxUnits.Name = "listBoxUnits";
      this.listBoxUnits.Size = new Size(199, 64);
      this.listBoxUnits.TabIndex = 4;
      this.listBoxUnits.MouseDoubleClick += new MouseEventHandler(this.listBoxUnits_MouseDoubleClick);
      this.listBoxUnits.SelectedIndexChanged += new EventHandler(this.listBoxUnits_SelectedIndexChanged);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(13, 70);
      this.label2.Name = "label2";
      this.label2.Size = new Size(122, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Unit#            UnitID";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(231, 211);
      this.ControlBox = false;
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.listBoxUnits);
      this.Controls.Add((Control) this.buttonSelectUnit);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogUnitSelect";
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Select MASTER-PROG Unit";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void listBoxUnits_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      FormProgUSB.pk2number = (ushort) this.listBoxUnits.SelectedIndex;
      this.Close();
    }

    private void listBoxUnits_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.buttonSelectUnit.Enabled = true;
    }

    private void buttonSelectUnit_Click(object sender, EventArgs e)
    {
      FormProgUSB.pk2number = (ushort) this.listBoxUnits.SelectedIndex;
      this.Close();
    }
  }
}
