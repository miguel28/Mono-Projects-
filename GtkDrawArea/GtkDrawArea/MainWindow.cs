using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	//[DllImport ("LibSDL")]
	Pango.Layout layout, layout2;
	//Gdk.GC color = new Gdk.GC(
	public double x,y;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		layout = new Pango.Layout(this.PangoContext);
		layout.Width = Pango.Units.FromPixels(500);
		layout.Wrap = Pango.WrapMode.Word;
		layout.Alignment = Pango.Alignment.Left;
		layout.FontDescription = Pango.FontDescription.FromString("Arial CLM Bold 10");
		layout.SetMarkup("<span color=" + (char)34 + "black" + (char)34 + ">" + "Hello" + "</span>");

		layout2 = new Pango.Layout(this.PangoContext);
		layout2.Width = Pango.Units.FromPixels(500);
		layout2.Wrap = Pango.WrapMode.Word;
		layout2.Alignment = Pango.Alignment.Left;
		layout2.FontDescription = Pango.FontDescription.FromString("Arial CLM Bold 10");
		layout2.SetMarkup("<span color=" + (char)34 + "green" + (char)34 + ">" + "Hello" + "</span>");
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnButtonClicked (object sender, EventArgs e)
	{

		Area1.GdkWindow.DrawLine( Area1.Style.TextGC (StateType.Normal), 10,10 ,50,50);
		Area1.GdkWindow.DrawLayout (Area1.Style.BaseGC (StateType.Normal), 5, 5, layout);

		layout2.SetMarkup("<span color=" + (char)34 + "green" + (char)34 + ">" + Convert.ToString(x) + "</span>");
		Area1.GdkWindow.DrawLayout (Area1.Style.BaseGC (StateType.Normal), 5, 5, layout2);

		//Area1.GdkWindow.DrawImage(Area1.Style.BaseGC (StateType.Normal),
		//textview3.Text="JAJA";
	}
	protected void OnMotionNotifyEvent (object o, MotionNotifyEventArgs args)
	{
	}
	protected void OnArea1MotionNotifyEvent (object o, MotionNotifyEventArgs args)
	{
		x = args.Event.X;
		y = args.Event.Y;

	}

}
