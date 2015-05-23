namespace CrossPlatformApp.Pages
{
    using System.Collections.Generic;
    using Xamarin.Forms;

    public partial class TabsPage
    {
        public TabsPage()
        {
            InitializeComponent();
            ItemsSource = new object[] {
               "One",
               "Two"
            };
        }
    }
}