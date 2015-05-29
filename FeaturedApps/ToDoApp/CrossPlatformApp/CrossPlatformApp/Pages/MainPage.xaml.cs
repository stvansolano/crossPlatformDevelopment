namespace CrossPlatformApp
{
    using Shared.Infrastructure.Services;
    using Shared.ViewModels;
    using Shared.WebServices;
    using Xamarin.Forms;
    using Pages;
    using System.Linq;

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

            ViewModel = new TodoListViewModel(new DataService());

            ViewModel.NewItemCommand = new Command(() =>
            {
                MainList.Navigator.NavigateToAsync(MainList.NewItem());
            });

            BindingContext = ViewModel;

            MainList.MessageService = new MessageService(this);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.Elements.Any() == false)
            {
                MainList.LoadItemsAsync();
            }
        }

		internal void Start()
		{
		}

        public TodoListViewModel ViewModel { get; set; }
    }
}