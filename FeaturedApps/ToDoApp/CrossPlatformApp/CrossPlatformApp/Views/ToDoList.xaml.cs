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
                SetupCommands(item);
			}
		}

        private void SetupCommands(TodoItemViewModel item)
        {
            item.NavigateCommand = new Command(() => OnNavigate(item));
            item.SaveCommand = new Command(() => OnSave(item));
        }

        private void OnSave(TodoItemViewModel editItem)
        {
            if (ViewModel.Elements.Contains(editItem) == false)
            {
                ViewModel.Elements.Add(editItem);
            }
            Navigator.ReturnToMain();
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

        internal TodoItemViewModel NewItem()
        {
            var newItem = new TodoItemViewModel { ItemName = "New item:" };
            SetupCommands(newItem);

            return newItem;
        }
    }
}