namespace CrossPlatformApp
{
	using Shared.ViewModels;
	using Xamarin.Forms;

	public partial class ToDoList
	{
		public ToDoList()
		{
			InitializeComponent();
		}

		public TodoListViewModel ViewModel { get { return BindingContext as TodoListViewModel; } }

		public async void LoadItemsAsync()
		{
			if (ViewModel == null)
			{
				return;
			}
			await ViewModel.LoadItemsAsync();
		}

		public void LoadItems()
		{
			if (ViewModel == null)
			{
				return;
			}
			ViewModel.LoadItems();
		}
	}
}