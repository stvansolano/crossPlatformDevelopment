namespace CrossPlatformApp
{
	using System;
	using Xamarin.Forms;

	public partial class MyFirstPage
	{
		public MyFirstPage ()
		{
			InitializeComponent ();
		}

		private void OnSalute(object sender, EventArgs e){
			var text = string.Empty;

			if (string.IsNullOrEmpty(EntryName.Text)) {
				text = "Hello World!";
			} else {
				text = "Hello " + EntryName.Text + "!!";
			}

			DisplayAlert ("We salute", text, "Close");
		}
	}
}