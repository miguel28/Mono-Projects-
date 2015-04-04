using System;
using Gtk;
using Mono.WebBrowser;

public partial class MainWindow: Gtk.Window
{	
	public int operacion = 0;     //que se quiere hacer (+ = 1, - = 2, * = 3, / = 4) 
	public bool pendiente = false;    // si se aprieta un operando pasa a true.
	public bool separador_decimal = false;   //si se aprieta el punto pasa a true
	public double primer_numero, segundo_numero, resultado; 

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnBN1Clicked (object sender, EventArgs e)
	{
		cajatexto.Text = cajatexto.Text + "1";

	}	protected void OnBN2Clicked (object sender, EventArgs e)
	{
		cajatexto.Text = cajatexto.Text + "2";

	}	protected void OnBN3Clicked (object sender, EventArgs e)
	{
		cajatexto.Text = cajatexto.Text + "3";

	}	protected void OnBMasClicked (object sender, EventArgs e)
	{
		operacion_Click (sender, e);

	}	protected void OnBN4Clicked (object sender, EventArgs e)
	{
		cajatexto.Text = cajatexto.Text + "4";

	}	protected void OnBN5Clicked (object sender, EventArgs e)
	{
		cajatexto.Text = cajatexto.Text + "5";

	}	protected void OnBN6Clicked (object sender, EventArgs e)
	{
		cajatexto.Text = cajatexto.Text + "6";

	}	protected void OnBMenosClicked (object sender, EventArgs e)
	{

	}	protected void OnBN7Clicked (object sender, EventArgs e)
	{
		cajatexto.Text = cajatexto.Text + "7";

	}	protected void OnBN8Clicked (object sender, EventArgs e)
	{
		cajatexto.Text = cajatexto.Text + "8";
	}	protected void OnBN9Clicked (object sender, EventArgs e)
	{
		cajatexto.Text = cajatexto.Text + "9";

	}	protected void OnBPorClicked (object sender, EventArgs e)
	{


	}	protected void OnBNClicked (object sender, EventArgs e)
	{
		cajatexto.Text = cajatexto.Text + "0";

	}	protected void OnBPuntoClicked (object sender, EventArgs e)
	{

	}	protected void OnBIgualClicked (object sender, EventArgs e)
	{

	}	protected void OnBEntreClicked (object sender, EventArgs e)
	{

	}
	protected virtual void operacion_Click (object sender, System.EventArgs e)
	{
		if (cajatexto.Text != "")
		{
		pendiente = true;
		if ((sender as Button).Name == "BMas") operacion = 1;
		if ((sender as Button).Name == "BMenos") operacion = 2;
		if ((sender as Button).Name == "BPor") operacion = 3;
		if ((sender as Button).Name == "BDivision") operacion = 4;
		separador_decimal = false;
			cajatexto.Text = "Hola" +Convert.ToString(operacion);
		}
	}


}
