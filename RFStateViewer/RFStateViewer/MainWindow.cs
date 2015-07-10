using System;
using System.Timers;
using USBInterface;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	USBClass usb = new USBClass(); 
	private static System.Timers.Timer aTimer;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		usb.HIDOpen(0x3995,0x0001);
		usb.HIDDescription();
		aTimer = new System.Timers.Timer(10000);

		// Hook up the Elapsed event for the timer.
		aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

		// Set the Interval to 2 seconds (2000 milliseconds).
		aTimer.Interval = 200;
		aTimer.Enabled = true;

	}
	private void OnTimedEvent(object source, ElapsedEventArgs e)
	{
		UpdateInfo ();
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnBtnSendClicked (object sender, EventArgs e)
	{
		UpdateInfo ();
	}

	private void UpdateInfo()
	{
		int i = 0;
		foreach (byte b in GetBytes (txtSender.Text) )
		{
			usb.BufferOUT[i] = b;
			i++;
		}
		usb.BufferOUT [0] = 0xff;
		usb.SendBuffer();
		usb.GetInputBuffer();

		byte[] temp = new byte[10];
		for (i=0; i<8; i++)
			temp [i] = usb.BufferIN [i];
		txtRecibed.Text = GetString(temp);

		usb.Print();
	}

	static byte[] GetBytes(string str)
	{
		System.Text.ASCIIEncoding  encoding=new System.Text.ASCIIEncoding();
		return encoding.GetBytes(str);
	}

	static string GetString(byte[] bytes)
	{
		return System.Text.ASCIIEncoding.ASCII.GetString(bytes);
	}
}