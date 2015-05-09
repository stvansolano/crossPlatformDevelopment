namespace CrossPlatformApp
{
	using Services;
	using Shared.Infrastructure.Services;
	using Shared.ViewModels;
	using Xamarin.Forms;

	public partial class ToDoList
	{
		public ToDoList()
		{
			InitializeComponent();

			Navigator = new NavigatorService(Navigation);
		}

		public INavigationService Navigator { get; set; }
		public TodoListViewModel ViewModel { get { return BindingContext as TodoListViewModel; } }

		public async void LoadItemsAsync()
		{
			if (ViewModel == null)
			{
				return;
			}
			await ViewModel.LoadItemsAsync().ContinueWith(task => SetupCommands(task.Result));
		}

		public void LoadItems()
		{
			if (ViewModel == null)
			{
				return;
			}
			var items = ViewModel.LoadItems();

			SetupCommands(items);
		}

		private void SetupCommands(TodoItemViewModel[] elements)
		{
			foreach (var item in elements)
			{
				var editItem = item;
				item.NavigateCommand = new Command(() => OnNavigate(editItem));
			}
		}

		private async void OnNavigate(TodoItemViewModel editItem)
		{
			try
			{
				await Navigator.NavigateToEditAsync(editItem);
			}
			catch (System.Exception ex)
			{
			}
		}
	}
}