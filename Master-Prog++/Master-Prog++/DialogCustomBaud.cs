// Type: SysProgUSB.DialogCustomBaud
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogCustomBaud : Form
  {
    private IContainer components;
    private Label label1;
    private TextBox textBox1;
    private Button buttonOK;
    private Button buttonCancel;

    public DialogCustomBaud()
    {
      this.InitializeComponent();
      this.textBox1.Focus();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (this.textBox1.Text.Length <= 0 || char.IsDigit(this.textBox1.Text[this.textBox1.Text.Length - 1]))
        return;
      this.textBox1.Text = this.textBox1.Text.Substring(0, this.textBox1.Text.Length - 1);
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      try
      {
        int num1 = int.Parse(this.textBox1.Text);
        if (num1 < 150 || num1 > 38400)
        {
          int num2 = (int) MessageBox.Show("Baud value is outside\nthe Min / Max range.");
        }
        else
        {
          DialogUART.CustomBaud = this.textBox1.Text;
          this.Close();
        }
      }
      catch
      {
        int num = (int) MessageBox.Show("Illegal Value.");
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
      this.textBox1 = new TextBox();
      this.buttonOK = new Button();
      this.buttonCancel = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(13, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(142, 65);
      this.label1.TabIndex = 0;
      this.label1.Text = "Enter baud rate in box below\r\nand click \"OK\".\r\n\r\nMinimum = 150 baud\r\nMaximum = 38400 baud";
      this.textBox1.Location = new Point(16, 82);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(106, 20);
      this.textBox1.TabIndex = 1;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.buttonOK.Location = new Point(13, 114);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(80, 22);
      this.buttonOK.TabIndex = 2;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      this.buttonCancel.Location = new Point(99, 114);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(80, 22);
      this.buttonCancel.TabIndex = 3;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(188, 148);
      this.ControlBox = false;
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogCustomBaud";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Custom Baud Rate";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
