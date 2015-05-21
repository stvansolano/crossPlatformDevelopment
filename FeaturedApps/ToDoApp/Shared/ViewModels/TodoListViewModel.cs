namespace Shared.ViewModels
{
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Threading.Tasks;
    using System.Windows.Input;

	public class TodoListViewModel : BaseViewModel
	{
		public TodoListViewModel()
		{
			_elements = new ObservableCollection<TodoItemViewModel>();

            Title = "My To-Do list showcase";
		}

		public const string TITLE_PROPERTY = "Title";
		private string _title = string.Empty;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value, TITLE_PROPERTY); }
		}

        public const string NEW_ITEM_COMMAND_PROPERTY = "NewItemCommand";
        private ICommand _newItemCommand;
        public ICommand NewItemCommand
		{
            get { return _newItemCommand; }
            set { SetProperty(ref _newItemCommand, value, NEW_ITEM_COMMAND_PROPERTY); }
		}

		private ObservableCollection<TodoItemViewModel> _elements;
		public ObservableCollection<TodoItemViewModel> Elements
		{
			get { return _elements; }
		}

		public TodoItemViewModel[] LoadItems() 
		{
			return AddItems(FeedItems());
		}

		public Task<TodoItemViewModel[]> LoadItemsAsync()
		{
			return Task.Run(() => FeedItems()).ContinueWith(task => AddItems(task.Result));
		}

		private TodoItemViewModel[] FeedItems()
		{
			return new TodoItemViewModel[] {
				/*new TodoItemViewModel { ItemName = "Item #1", Description = "description", NavigateCommand = null },
				new TodoItemViewModel { ItemName = "Item #2", Description = "description", NavigateCommand = null },
				new TodoItemViewModel { ItemName = "Item #3", Description = "description", NavigateCommand = null }*/
			};
		}

		private TodoItemViewModel[] AddItems(TodoItemViewModel[] result)
		{
			foreach (var item in result)
			{
				Elements.Add(item);
			}

			return result;
		}
	}
}