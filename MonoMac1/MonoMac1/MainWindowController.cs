using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.WebKit;

namespace MonoMac1
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
			//_Label1.StringValue = "www.google.com";
		}
		
		#endregion
		
		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}
		partial void _ButtonClick(NSObject sender)
		{
         	_Label1.StringValue = "www.google.com";
			//MonoMac.WebKit.WebView.
			webView.MainFrameUrl = "http://187.141.133.51/ley/default.aspx";
			//webView.EstimatedProgress;
		}
		partial void _ExecClick(NSObject sender)
		{
			webView.StringByEvaluatingJavaScriptFromString("var myTextField = document.getElementById('TxtUsuario'); myTextField.value = 'miguelsilva'; myTextField = document.getElementById('TxtPassword'); myTextField.value = 'sireco'; myTextField = document.getElementById('BtnAceptar').click();");
			if(webView.IsLoading)
			{
				NSAlert msg = new NSAlert();
				msg.MessageText = "Cargando...";
				msg.BeginSheet(Window);
			}
		}

	}
}

