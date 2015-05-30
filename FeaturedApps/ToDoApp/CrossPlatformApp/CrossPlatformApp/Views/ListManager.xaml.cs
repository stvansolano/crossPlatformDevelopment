namespace CrossPlatformApp
{
    using Services;
    using Xamarin.Forms;

    public partial class ListManager
    {
        public ListManager()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {
            }

            Navigator = new NavigationService(Navigation);
            Title = "My Lists";
        }

        public string Title { get; set; }
        public NavigationService Navigator { get; set; }
    }
}