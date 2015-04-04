using System;
using Gtk;
using System.Web;
using Mono.WebBrowser;

namespace CalculadoraMono
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			//IWebBrowser browser = Mono.WebBrowser.Manager.GetNewInstance();
    		//browser.Navigation.Go("www.google.com");
			win.Show ();
			Application.Run ();
		}
	}
}
