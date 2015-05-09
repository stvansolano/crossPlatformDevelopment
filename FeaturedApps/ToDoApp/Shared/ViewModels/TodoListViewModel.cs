namespace Shared.ViewModels
{
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Threading.Tasks;

	public class TodoListViewModel : BaseViewModel
	{
		public TodoListViewModel()
		{
			_elements = new ObservableCollection<TodoItemViewModel>();
		}

		public const string TITLE_PROPERTY = "Title";
		private string _title = string.Empty;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value, TITLE_PROPERTY); }
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
				new TodoItemViewModel { ItemName = "Item #1", Description = "description", NavigateCommand = null },
				new TodoItemViewModel { ItemName = "Item #2", Description = "description", NavigateCommand = null },
				new TodoItemViewModel { ItemName = "Item #3", Description = "description", NavigateCommand = null }
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