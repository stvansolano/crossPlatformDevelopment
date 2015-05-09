namespace CrossPlatformApp
{
	using Shared.ViewModels;
	using Xamarin.Forms;

	public partial class ToDoMainPage : ContentPage
		//MasterDetailPage
		//NavigationPage
		//TabbedPage
		//CarouselPage
	{
		public ToDoMainPage()
		{
			InitializeComponent();
		}

		internal void Start()
		{
			MainList.BindingContext = new TodoListViewModel() { Title = "My To-do list" };
			MainList.LoadItems();
		}
	}
}