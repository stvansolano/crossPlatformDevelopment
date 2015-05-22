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

			Navigator = new NavigationService(Navigation);

            ItemsList.RefreshCommand = new Command(DoRefresh);
		}

		public INavigationService Navigator { get; set; }
		public TodoListViewModel ViewModel { get { return BindingContext as TodoListViewModel; } }

		public void LoadItemsAsync()
		{
            DoRefresh();
		}

        private async void DoRefresh()
        {
            if (ViewModel == null)
            {
                return;
            }
            await ViewModel.LoadItemsAsync().ContinueWith(task => HandleResult(task.Result));

            ItemsList.EndRefresh();
        }

        private TodoItemViewModel[] HandleResult(TodoItemViewModel[] result)
        {
            SetupCommands(result);

            return result;
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
				await Navigator.NavigateToAsync(editItem);
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