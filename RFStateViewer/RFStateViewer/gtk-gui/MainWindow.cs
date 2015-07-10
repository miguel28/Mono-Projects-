
// This file has been generated by the GUI designer. Do not modify.
public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.VBox vbox1;
	private global::Gtk.MenuBar menubar2;
	private global::Gtk.Notebook TabView;
	private global::Gtk.Fixed fixed1;
	private global::Gtk.Label lblSender;
	private global::Gtk.Entry txtSender;
	private global::Gtk.Button btnSend;
	private global::Gtk.Label lblRecibed;
	private global::Gtk.Entry txtRecibed;
	private global::Gtk.Label label1;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-about", global::Gtk.IconSize.Menu);
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar2'/></ui>");
		this.menubar2 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar2")));
		this.menubar2.Name = "menubar2";
		this.vbox1.Add (this.menubar2);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar2]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.TabView = new global::Gtk.Notebook ();
		this.TabView.CanFocus = true;
		this.TabView.Name = "TabView";
		this.TabView.CurrentPage = 0;
		// Container child TabView.Gtk.Notebook+NotebookChild
		this.fixed1 = new global::Gtk.Fixed ();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.lblSender = new global::Gtk.Label ();
		this.lblSender.Name = "lblSender";
		this.lblSender.LabelProp = global::Mono.Unix.Catalog.GetString ("Text To Send");
		this.fixed1.Add (this.lblSender);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.lblSender]));
		w3.X = 24;
		w3.Y = 27;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.txtSender = new global::Gtk.Entry ();
		this.txtSender.CanFocus = true;
		this.txtSender.Name = "txtSender";
		this.txtSender.IsEditable = true;
		this.txtSender.MaxLength = 8;
		this.txtSender.InvisibleChar = '●';
		this.fixed1.Add (this.txtSender);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.txtSender]));
		w4.X = 123;
		w4.Y = 20;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.btnSend = new global::Gtk.Button ();
		this.btnSend.CanFocus = true;
		this.btnSend.Name = "btnSend";
		this.btnSend.UseUnderline = true;
		this.btnSend.Label = global::Mono.Unix.Catalog.GetString ("Update");
		this.fixed1.Add (this.btnSend);
		global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.btnSend]));
		w5.X = 298;
		w5.Y = 18;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.lblRecibed = new global::Gtk.Label ();
		this.lblRecibed.Name = "lblRecibed";
		this.lblRecibed.LabelProp = global::Mono.Unix.Catalog.GetString ("Text Recived");
		this.fixed1.Add (this.lblRecibed);
		global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.lblRecibed]));
		w6.X = 26;
		w6.Y = 67;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.txtRecibed = new global::Gtk.Entry ();
		this.txtRecibed.CanFocus = true;
		this.txtRecibed.Name = "txtRecibed";
		this.txtRecibed.IsEditable = true;
		this.txtRecibed.MaxLength = 8;
		this.txtRecibed.InvisibleChar = '●';
		this.fixed1.Add (this.txtRecibed);
		global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.txtRecibed]));
		w7.X = 124;
		w7.Y = 64;
		this.TabView.Add (this.fixed1);
		// Notebook tab
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Eco Test");
		this.TabView.SetTabLabel (this.fixed1, this.label1);
		this.label1.ShowAll ();
		this.vbox1.Add (this.TabView);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.TabView]));
		w9.Position = 1;
		w9.Expand = false;
		w9.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 372;
		this.DefaultHeight = 164;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.btnSend.Clicked += new global::System.EventHandler (this.OnBtnSendClicked);
	}
}
