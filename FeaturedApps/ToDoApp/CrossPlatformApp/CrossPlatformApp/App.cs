namespace CrossPlatformApp
{
    using CrossPlatformApp.Pages;
    using Shared.ViewModels;
    using Shared.WebServices;
    using Xamarin.Forms;

	public class App : Application
	{
		private MainPage _mainPage;
		
        public App()
		{
			// The root page of your application
            _mainPage = new MainPage();

            var navigationPage = new NavigationPage(_mainPage);

            MainPage = navigationPage;
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