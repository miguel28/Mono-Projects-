using System;
using System.IO;
using Gtk;

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
	protected void OnReadBtnClicked (object sender, EventArgs e)
	{
		System.IO.StreamReader Reader = new  System.IO.StreamReader("RPG_RT.ldb");
		string Buffer = new string();
		//Buffer = Reader.ReadToEnd();
		//throw new System.NotImplementedException ();
	}

}
