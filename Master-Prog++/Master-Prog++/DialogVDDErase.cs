// Type: SysProgUSB.DialogVDDErase
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SysProgUSB
{
  public class DialogVDDErase : Form
  {
    private IContainer components;
    private Label label1;
    private Label label2;
    private Label label3;
    private CheckBox checkBoxDoNotShow;
    private Button buttonContinue;
    private Button buttonCancel;

    public DialogVDDErase()
    {
      this.InitializeComponent();
    }

    public void UpdateText()
    {
      this.label2.Text = "Este Dispositivo necesita un VDD de " + ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].VddErase.ToString() + "V\npara Borrarse. Checar Nivel.";
    }

    private void continueClick(object sender, EventArgs e)
    {
      if (this.checkBoxDoNotShow.Checked)
        FormProgUSB.ShowWriteEraseVDDDialog = false;
      FormProgUSB.ContinueWriteErase = true;
      this.Close();
    }

    private void cancelClick(object sender, EventArgs e)
    {
      FormProgUSB.ContinueWriteErase = false;
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
      this.label2 = new Label();
      this.label3 = new Label();
      this.checkBoxDoNotShow = new CheckBox();
      this.buttonContinue = new Button();
      this.buttonCancel = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Red;
      this.label1.Location = new Point(13, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(133, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "AVISO IMPORTANTE:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(13, 29);
      this.label2.Name = "label2";
      this.label2.Size = new Size(213, 26);
      this.label2.TabIndex = 1;
      this.label2.Text = "Este Dispositivo Requiere un VDD de ?.?V\r\nPara Borrarse Correctamente. Checar Nivel.";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(13, 62);
      this.label3.Name = "label3";
      this.label3.Size = new Size(187, 26);
      this.label3.TabIndex = 2;
      this.label3.Text = "Un Voltaje Incorrecto Puede Provocar\r\nErrores de Escritura/Borrado";
      this.checkBoxDoNotShow.AutoSize = true;
      this.checkBoxDoNotShow.Location = new Point(13, 102);
      this.checkBoxDoNotShow.Name = "checkBoxDoNotShow";
      this.checkBoxDoNotShow.Size = new Size(204, 17);
      this.checkBoxDoNotShow.TabIndex = 3;
      this.checkBoxDoNotShow.Text = "No Volver a Mostrar Esta Advertencia";
      this.checkBoxDoNotShow.UseVisualStyleBackColor = true;
      this.buttonContinue.Location = new Point(26, 126);
      this.buttonContinue.Name = "buttonContinue";
      this.buttonContinue.Size = new Size(80, 22);
      this.buttonContinue.TabIndex = 4;
      this.buttonContinue.Text = "Aceptar";
      this.buttonContinue.UseVisualStyleBackColor = true;
      this.buttonContinue.Click += new EventHandler(this.continueClick);
      this.buttonCancel.Location = new Point(148, 126);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(80, 22);
      this.buttonCancel.TabIndex = 5;
      this.buttonCancel.Text = "Cancelar";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.cancelClick);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(254, 161);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonContinue);
      this.Controls.Add((Control) this.checkBoxDoNotShow);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogVDDErase";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "                  ¡  A  V  I  S  O  !";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
