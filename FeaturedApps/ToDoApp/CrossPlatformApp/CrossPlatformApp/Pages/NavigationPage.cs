namespace CrossPlatformApp.Pages
{
    using Xamarin.Forms;

    public class NavigationPage<TPage> : NavigationPage
        where TPage : Page, new()
    {
        public NavigationPage() : base(new TPage())
        {
        }

        public new TPage CurrentPage { get { return (TPage)base.CurrentPage; } }
    }
}