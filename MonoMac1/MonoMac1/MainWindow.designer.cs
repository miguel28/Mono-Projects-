// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using MonoMac.WebKit;

namespace MonoMac1
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSTextField _Label1 { get; set; }

		[Outlet]
		MonoMac.WebKit.WebView webView { get; set; }

		[Action ("_ButtonClick:")]
		partial void _ButtonClick (MonoMac.Foundation.NSObject sender);

		[Action ("_ExecClick:")]
		partial void _ExecClick (MonoMac.Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (_Label1 != null) {
				_Label1.Dispose ();
				_Label1 = null;
			}

			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
