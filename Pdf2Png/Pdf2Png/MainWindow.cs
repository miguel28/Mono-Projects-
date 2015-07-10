using System;
using Gtk;
using libpdf;
using System.IO;
using MyLib;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnBtnOpenClicked (object sender, EventArgs e)
	{
		Gtk.FileChooserDialog fc=
			new Gtk.FileChooserDialog("Choose the file to open",
			                          this,
			                          FileChooserAction.Open,
			                          "Cancel",ResponseType.Cancel,
			                          "Open",ResponseType.Accept);

		fc.Run ();
		txtPSource.Text = fc.Filename;
		txtPDest.Text = fc.Filename;

		fc.Destroy();
	}

	protected void OnBtnConvertClicked (object sender, EventArgs e)
	{

		Console.WriteLine ("Create...");
		MyClass class1 = new MyClass(txtPSource.Text);
		Console.WriteLine ("Create...");
		using (FileStream file = File.OpenRead(txtPSource.Text)) // in file
		{
			var bytes = new byte[file.Length];
			file.Read(bytes, 0, bytes.Length);

			using (var pdf = new LibPdf(bytes))
			{
				byte[] pngBytes = pdf.GetImage(0,ImageType.PNG); // image type
				using (var outFile = File.Create(txtPDest.Text)) // out file
				{
					outFile.Write(pngBytes, 0, pngBytes.Length);
				}
			}
		}
	}
}
