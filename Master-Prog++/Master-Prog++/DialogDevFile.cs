// Type: SysProgUSB.DialogDevFile
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogDevFile : Form
  {
    private IContainer components;
    private Label label1;
    private Button buttonLoadDevFile;
    private ListBox listBoxDevFiles;

    public DialogDevFile()
    {
      this.InitializeComponent();
      foreach (FileSystemInfo fileSystemInfo in new DirectoryInfo(Directory.GetCurrentDirectory()).GetFiles("*.bin"))
        this.listBoxDevFiles.Items.Add((object) fileSystemInfo.Name);
    }

    private void buttonLoadDevFile_Click(object sender, EventArgs e)
    {
      FormProgUSB.DeviceFileName = this.listBoxDevFiles.SelectedItem.ToString();
      this.Close();
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
      this.buttonLoadDevFile = new Button();
      this.listBoxDevFiles = new ListBox();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(16, 11);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(183, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Select a Device File to load:";
      this.buttonLoadDevFile.Location = new Point(144, 284);
      this.buttonLoadDevFile.Margin = new Padding(4, 4, 4, 4);
      this.buttonLoadDevFile.Name = "buttonLoadDevFile";
      this.buttonLoadDevFile.Size = new Size(100, 28);
      this.buttonLoadDevFile.TabIndex = 2;
      this.buttonLoadDevFile.Text = "Load";
      this.buttonLoadDevFile.UseVisualStyleBackColor = true;
      this.buttonLoadDevFile.Click += new EventHandler(this.buttonLoadDevFile_Click);
      this.listBoxDevFiles.FormattingEnabled = true;
      this.listBoxDevFiles.ItemHeight = 16;
      this.listBoxDevFiles.Location = new Point(20, 31);
      this.listBoxDevFiles.Margin = new Padding(4, 4, 4, 4);
      this.listBoxDevFiles.Name = "listBoxDevFiles";
      this.listBoxDevFiles.Size = new Size(352, 244);
      this.listBoxDevFiles.TabIndex = 3;
      this.AutoScaleDimensions = new SizeF(120f, 120f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(389, 327);
      this.Controls.Add((Control) this.listBoxDevFiles);
      this.Controls.Add((Control) this.buttonLoadDevFile);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogDevFile";
      this.Text = "DialogDevFile";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
