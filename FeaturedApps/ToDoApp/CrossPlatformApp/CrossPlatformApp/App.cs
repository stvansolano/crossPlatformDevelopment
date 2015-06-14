namespace CrossPlatformApp
{
    using CrossPlatformApp.Pages;
    using Shared.ViewModels;
    using Shared.WebServices;
    using Xamarin.Forms;

	public class App : Application
	{
        private NavigationPage<MasterDetailMainPage> _mainPage;
		
        public App()
		{
            MainPage = _mainPage = new NavigationPage<MasterDetailMainPage>();
		}

		protected override void OnStart()
		{
			_mainPage.CurrentPage.Start();
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

        public void SwitchFloatingTools()
        {
            _mainPage.CurrentPage.SwitchFloatingTools();
        }
    }
}