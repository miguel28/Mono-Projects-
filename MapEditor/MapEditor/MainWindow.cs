using System;
using Gtk;
using Cairo;

public partial class MainWindow: Gtk.Window
{	
	Gtk.Image MiImage = new Gtk.Image ("basic.png");
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnExposeEvent (object sender, ExposeEventArgs a)
	{
		//Tiles.GdkWindow.DrawPixbuf(Tiles.Style.TextGC (StateType.Normal),MiImage.Pixbuf,0,0,0,96,480,256,Gdk.RgbDither.Normal,0,0);
		//Map.GdkWindow.DrawPixbuf(Map.Style.TextGC (StateType.Normal),MiImage.Pixbuf,0,0,0,96,480,256,Gdk.RgbDither.Normal,0,0);
		Tiles.FromPixbuf =MiImage.Pixbuf;
		Map.FromPixbuf =MiImage.Pixbuf;
		//Tiles.
	}

	protected void OnNewActionActivated (object sender, EventArgs e)
	{
		//Tiles.GdkWindow.DrawPixbuf(Tiles.Style.TextGC (StateType.Normal),MiImage.Pixbuf,0,0,0,96,96,96,Gdk.RgbDither.Normal,0,0);
		//throw new System.NotImplementedException ();
	}	protected void OnDrawingAreaExposeEvent (object o, ExposeEventArgs args)
	{
		/*DrawingArea area = (DrawingArea) o;
    Cairo.Graphics g = Graphics.CreateDrawable (area.GdkWindow);
 
    PointD p1,p2,p3,p4;
    p1 = new PointD (10,10);
    p2 = new PointD (100,10);
    p3 = new PointD (100,100);
    p4 = new PointD (10,100);
 
    g.MoveTo (p1);
    g.LineTo (p2);
    g.LineTo (p3);
    g.LineTo (p4);
    g.LineTo (p1);
    g.ClosePath ();
 
    g.Color = new Color (0,0,0);
    g.FillPreserve ();
    g.Color = new Color (1,0,0);
    g.Stroke ();
 
    ((IDisposable) g.Target).Dispose ();                                      
    ((IDisposable) g).Dispose ();*/
		//throw new System.NotImplementedException ();
	}



}
