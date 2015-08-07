namespace CrossPlatformApp
{
    using Xamarin.Forms;

    public partial class App
    {
        public App()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {
            }

            // The root page of your application
            MainPage = new DictionaryBindingExample();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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