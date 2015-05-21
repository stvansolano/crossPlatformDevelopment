namespace CrossPlatformApp
{
	using Shared.ViewModels;
	using Xamarin.Forms;

	public class App : Application
	{
		private MainPage _mainPage;
		public App()
		{
            _mainPage = new MainPage();
			// The root page of your application
            MainPage = new NavigationPage(_mainPage);
		}

		protected override void OnStart()
		{
			_mainPage.Start();
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}