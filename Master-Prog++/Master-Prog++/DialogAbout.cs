// Type: SysProgUSB.DialogAbout
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogAbout : Form
  {
    private IContainer components;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label displayAppVer;
    private Label displayDevFileVer;
    private Label displayPUSBFWVer;
    private TextBox textBox1;
    private LinkLabel linkLabel1;
    private Button buttonOK;
    private PictureBox pictureBox1;

    public DialogAbout()
    {
      this.InitializeComponent();
      this.displayAppVer.Text = "3.0";
      this.displayDevFileVer.Text = ProgCommand.DeviceFileVersion;
      this.displayPUSBFWVer.Text = ProgCommand.FirmwareVersion;
      this.textBox1.Select(0, 0);
    }

    private void clickOK(object sender, EventArgs e)
    {
      this.Close();
    }

    private void microchipLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      try
      {
        this.visitMicrochipSite();
      }
      catch
      {
        int num = (int) MessageBox.Show("Error al abrir el link!");
      }
    }

    private void visitMicrochipSite()
    {
      this.linkLabel1.LinkVisited = true;
      Process.Start("mailto:edutronika@hotmail.com");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DialogAbout));
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.displayAppVer = new Label();
      this.displayDevFileVer = new Label();
      this.displayPUSBFWVer = new Label();
      this.textBox1 = new TextBox();
      this.linkLabel1 = new LinkLabel();
      this.buttonOK = new Button();
      this.pictureBox1 = new PictureBox();
      this.pictureBox1.BeginInit();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(52, 80);
      this.label1.Name = "label1";
      this.label1.Size = new Size(0, 22);
      this.label1.TabIndex = 0;
      this.label1.Visible = false;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Lucida Handwriting", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Red;
      this.label2.Location = new Point(46, 102);
      this.label2.Name = "label2";
      this.label2.Size = new Size(0, 31);
      this.label2.TabIndex = 1;
      this.label2.Visible = false;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(121, 100);
      this.label3.Name = "label3";
      this.label3.Size = new Size(97, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Application Version";
      this.label3.Visible = false;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(121, 113);
      this.label4.Name = "label4";
      this.label4.Size = new Size(98, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "Device File Version";
      this.label4.Visible = false;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(121, 125);
      this.label5.Name = "label5";
      this.label5.Size = new Size(105, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "OS Firmware Version";
      this.label5.Visible = false;
      this.displayAppVer.AutoSize = true;
      this.displayAppVer.Location = new Point(259, 100);
      this.displayAppVer.Name = "displayAppVer";
      this.displayAppVer.Size = new Size(43, 13);
      this.displayAppVer.TabIndex = 5;
      this.displayAppVer.Text = "2.00.00";
      this.displayAppVer.TextAlign = ContentAlignment.TopRight;
      this.displayAppVer.Visible = false;
      this.displayDevFileVer.AutoSize = true;
      this.displayDevFileVer.Location = new Point(259, 113);
      this.displayDevFileVer.Name = "displayDevFileVer";
      this.displayDevFileVer.Size = new Size(49, 13);
      this.displayDevFileVer.TabIndex = 6;
      this.displayDevFileVer.Text = "00.00.00";
      this.displayDevFileVer.TextAlign = ContentAlignment.TopRight;
      this.displayDevFileVer.Visible = false;
      this.displayPUSBFWVer.AutoSize = true;
      this.displayPUSBFWVer.Location = new Point(259, 125);
      this.displayPUSBFWVer.Name = "displayPUSBFWVer";
      this.displayPUSBFWVer.Size = new Size(49, 13);
      this.displayPUSBFWVer.TabIndex = 7;
      this.displayPUSBFWVer.Text = "00.00.00";
      this.displayPUSBFWVer.TextAlign = ContentAlignment.TopRight;
      this.displayPUSBFWVer.Visible = false;
      this.textBox1.BackColor = Color.White;
      this.textBox1.BorderStyle = BorderStyle.None;
      this.textBox1.Font = new Font("Comic Sans MS", 12f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.textBox1.ForeColor = Color.Navy;
      this.textBox1.Location = new Point(7, 247);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(340, 95);
      this.textBox1.TabIndex = 8;
      this.textBox1.Text = "VENTAS Y SOPORTE TÉCNICO:\r\n\r\nTEL: 01 771 7912231\r\nCEL: 7711841824";
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Font = new Font("Comic Sans MS", 15.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.Location = new Point(48, 338);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(259, 30);
      this.linkLabel1.TabIndex = 9;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "edutronika@hotmail.com";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.microchipLinkClicked);
      this.buttonOK.Font = new Font("Comic Sans MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.buttonOK.Location = new Point(138, 391);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(79, 27);
      this.buttonOK.TabIndex = 10;
      this.buttonOK.Text = "Salir";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.clickOK);
      this.pictureBox1.Image = (Image) Resources._3_COLORES_2;
      this.pictureBox1.Location = new Point(19, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(317, 239);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 11;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.White;
      this.ClientSize = new Size(355, 430);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.displayPUSBFWVer);
      this.Controls.Add((Control) this.displayDevFileVer);
      this.Controls.Add((Control) this.displayAppVer);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogAbout";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "           *** VENTAS Y SOPORTE TECNICO ***";
      this.pictureBox1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
