namespace CrossPlatformApp.Pages
{
    using ViewModels;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {
            }

            var viewModel = new MainPageViewModel();

            for (int i = 0; i < 3; i++)
			{
                viewModel.Items.Add(new ItemViewModel { Text = "Item" + i++ });
			}

            BindingContext = viewModel;
        }
    }
}