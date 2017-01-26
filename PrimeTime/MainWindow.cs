using System;
using Gtk;

using PrimeTime;


public partial class MainWindow : Gtk.Window
{
	private int number;
	private PrimeNumberUtils pnu;
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		pnu = new PrimeNumberUtils();

		number = 0;
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void OnSpinbutton1ValueChanged(object sender, EventArgs e)
	{
		number = spinbutton1.ValueAsInt;
	}

	protected void OnButton1Clicked(object sender, EventArgs e)
	{
		textview1.Buffer.Text = pnu.testPrimality(number) == true ? "Prime Number " + number : "Composite Number (see factorization) " + number;
		if (number > 2)
		{
			pnu.primeFactorization(number);
		}
		textview4.Buffer.Text = pnu.message;
	}
}
