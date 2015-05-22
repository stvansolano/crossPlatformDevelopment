namespace Shared.ViewModels
{
    using Shared.Infrastructure.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Linq;
    using Shared.Core;

	public class TodoListViewModel : BaseViewModel
	{
		public TodoListViewModel(IDataService dataServices)
		{
			_elements = new ObservableCollection<TodoItemViewModel>();
            DataServices = dataServices;

            Title = "My To-Do list showcase";
		}

        public IDataService DataServices { get; set; }

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

		public Task<TodoItemViewModel[]> LoadItemsAsync()
		{
            Elements.Clear();
			return FeedItems().ContinueWith(task => AddItems(task.Result));
		}

		private Task<TodoItemViewModel[]> FeedItems()
		{
            if (DataServices == null)
            {
                return Task.Run(() => new TodoItemViewModel[0]);
            }
            var task = DataServices.GetToDosAsync();

            return task.ContinueWith(nextTask => TransformItems(nextTask.Result));
		}

        private TodoItemViewModel[] TransformItems(IEnumerable<ToDoItem> result)
        {
            return result.Select(data => new TodoItemViewModel() { ItemName = data.title, Description = "User:" + data.id + "completed:" + data.completed }).ToArray();
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