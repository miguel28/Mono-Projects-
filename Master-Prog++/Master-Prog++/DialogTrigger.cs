// Type: SysProgUSB.DialogTrigger
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogTrigger : Form
  {
    private IContainer components;
    private Label label1;
    private Label label2;
    private PictureBox pictureBox1;
    private Label label3;
    private Label label4;

    public DialogTrigger()
    {
      this.InitializeComponent();
      this.Size = new Size(this.Size.Width, (int) ((double) FormProgUSB.ScalefactH * (double) this.Size.Height));
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
      this.label2 = new Label();
      this.pictureBox1 = new PictureBox();
      this.label3 = new Label();
      this.label4 = new Label();
      this.pictureBox1.BeginInit();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(12, 42);
      this.label1.Name = "label1";
      this.label1.Size = new Size(194, 32);
      this.label1.TabIndex = 0;
      this.label1.Text = "MASTER-PROG Logic Tool is waiting for\r\na valid trigger condition.";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(12, 138);
      this.label2.Name = "label2";
      this.label2.Size = new Size(190, 48);
      this.label2.TabIndex = 1;
      this.label2.Text = "Do not disconnect the MASTER-PROG -\r\ndoing so may cause this\r\napplication to hang.";
      this.pictureBox1.BackColor = Color.Red;
      this.pictureBox1.Location = new Point(15, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(16, 18);
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(37, 14);
      this.label3.Name = "label3";
      this.label3.Size = new Size(137, 16);
      this.label3.TabIndex = 3;
      this.label3.Text = "Waiting for Trigger";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(12, 91);
      this.label4.Name = "label4";
      this.label4.Size = new Size(195, 32);
      this.label4.TabIndex = 4;
      this.label4.Text = "To cancel (abort) press the\r\nPICkit 2 pushbutton.";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(237, 196);
      this.ControlBox = false;
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = "DialogTrigger";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "MASTER-PROG Logic Tool Running";
      this.pictureBox1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
