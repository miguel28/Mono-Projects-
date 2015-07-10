// Type: SysProgUSB.SetOSCCAL
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SysProgUSB
{
	public class SetOSCCAL : Form
	{
		private IContainer components;
		private Label label1;
		private TextBox textBoxOSCCAL;
		private Label label2;
		private Button buttonSet;
		private Button buttonCancel;
		private Label label3;
		private Label label4;

		public SetOSCCAL()
		{
			this.InitializeComponent();
			this.textBoxOSCCAL.Text = string.Format("{0:X4}", (object) ProgCommand.DeviceBuffers.OSCCAL);
			this.textBoxOSCCAL.SelectAll();
		}

		private void clickSet(object sender, EventArgs e)
		{
			try
			{
				int num = Utilities.Convert_Value_To_Int(!(this.textBoxOSCCAL.Text.Substring(0, 2) == "0x") ? (!(this.textBoxOSCCAL.Text.Substring(0, 1) == "x") ? "0x" + this.textBoxOSCCAL.Text : "0" + this.textBoxOSCCAL.Text) : this.textBoxOSCCAL.Text);
				ProgCommand.DeviceBuffers.OSCCAL = (uint) num;
				FormProgUSB.setOSCCALValue = true;
				this.Close();
			}
			catch
			{
				this.textBoxOSCCAL.Text = string.Format("{0:X4}", (object) ProgCommand.DeviceBuffers.OSCCAL);
			}
		}

		private void clickCancel(object sender, EventArgs e)
		{
			FormProgUSB.setOSCCALValue = false;
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
			this.textBoxOSCCAL = new TextBox();
			this.label2 = new Label();
			this.buttonSet = new Button();
			this.buttonCancel = new Button();
			this.label3 = new Label();
			this.label4 = new Label();
			this.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(10, 15);
			this.label1.Name = "label1";
			this.label1.Size = new Size(81, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Valor OSCCAL:";
			this.textBoxOSCCAL.Location = new Point(93, 12);
			this.textBoxOSCCAL.Name = "textBoxOSCCAL";
			this.textBoxOSCCAL.Size = new Size(54, 20);
			this.textBoxOSCCAL.TabIndex = 1;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(153, 15);
			this.label2.Name = "label2";
			this.label2.Size = new Size(30, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "(hex)";
			this.buttonSet.Location = new Point(12, 88);
			this.buttonSet.Name = "buttonSet";
			this.buttonSet.Size = new Size(75, 23);
			this.buttonSet.TabIndex = 3;
			this.buttonSet.Text = "Ajustar";
			this.buttonSet.UseVisualStyleBackColor = true;
			this.buttonSet.Click += new EventHandler(this.clickSet);
			this.buttonCancel.Location = new Point(105, 88);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancelar";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new EventHandler(this.clickCancel);
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
			this.label3.ForeColor = Color.Red;
			this.label3.Location = new Point(10, 37);
			this.label3.Name = "label3";
			this.label3.Size = new Size(71, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "     ¡¡ A L E R T A !!";
			this.label4.AutoSize = true;
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(10, 53);
			this.label4.Name = "label4";
			this.label4.Size = new Size(153, 26);
			this.label4.TabIndex = 6;
			this.label4.Text = "El ajuste de OSCCAL Borrará Toda\r\nla Memoria Interna del PIC!\n";
			this.AutoScaleDimensions = new SizeF(6f, 13f);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(192, 123);
			this.Controls.Add((Control) this.label4);
			this.Controls.Add((Control) this.label3);
			this.Controls.Add((Control) this.buttonCancel);
			this.Controls.Add((Control) this.buttonSet);
			this.Controls.Add((Control) this.label2);
			this.Controls.Add((Control) this.textBoxOSCCAL);
			this.Controls.Add((Control) this.label1);
			this.Name = "SetOSCCAL";
			this.ShowIcon = false;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Ajuste OSCCAL";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
