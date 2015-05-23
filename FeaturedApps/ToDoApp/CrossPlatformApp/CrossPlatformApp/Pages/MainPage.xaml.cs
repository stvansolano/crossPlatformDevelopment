namespace CrossPlatformApp
{
    using Shared.Infrastructure.Services;
    using Shared.ViewModels;
    using Shared.WebServices;
    using Xamarin.Forms;

	public partial class MainPage
		//MasterDetailPage
		//NavigationPage
		//TabbedPage
		//CarouselPage
	{
        public MainPage()
		{
            Title = "Master";
            //SetBinding (Page.TitleProperty, new Binding(BaseViewModel.TitlePropertyName));

            InitializeComponent();

            //IsPresented = false;
            var context = new TodoListViewModel(new DataService());

            context.NewItemCommand = new Command(() =>
            {
                MainList.Navigator.NavigateToAsync(MainList.NewItem());
            });

            BindingContext = context;
		}

		internal void Start()
		{
			MainList.LoadItemsAsync();
		}
    }
}