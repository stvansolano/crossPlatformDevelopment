namespace Shared.ViewModels
{
    using Infrastructure.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Linq;
    using Core;

	public class TodoListViewModel : BaseViewModel
	{
		public TodoListViewModel(IDataService dataServices)
		{
			_elements = new ObservableCollection<TodoItemViewModel>();
            DataServices = dataServices;
		}

        public IDataService DataServices { get; set; }

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
            return result.Select(data => new TodoItemViewModel(data)).ToArray();
        }

		private TodoItemViewModel[] AddItems(TodoItemViewModel[] result)
		{
			foreach (var item in result)
			{
				Elements.Add(item);
			}

			return result;
		}

        public bool HasItems
        {
            get
            {
                return Elements != null && Elements.Any();
            }
        }

        public object CreateNew()
        {
            throw new System.NotImplementedException();
        }
    }
}