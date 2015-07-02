namespace AccordionSample
{
    using Xamarin.Forms;

    public class App : Application
    {
        public App()
        {
            string yourText = "[evaluating content]";
            const string REGEX = "(?<=\n)|(?=\n)";
            
            var results = new System.Text.RegularExpressions.Regex(REGEX).Matches(yourText);

            foreach (System.Text.RegularExpressions.Match match in results)
            {
                string value = match.Value;
            }
            
            MainPage = new NavigationPage(new AccordionViewExample());
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