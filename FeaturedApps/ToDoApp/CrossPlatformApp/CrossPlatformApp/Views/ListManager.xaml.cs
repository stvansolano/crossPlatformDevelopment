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

            Title = "My Lists";
        }

        public string Title { get; set; }
    }
}