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
		public TodoListViewModel(IDataService dataServices, INavigationService navigation)
		{
			_elements = new ObservableCollection<TodoItemViewModel>();
            DataServices = dataServices;
            Navigation = navigation;
		}

        public IDataService DataServices { get; set; }
        protected INavigationService Navigation { get; set; }

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

        public TodoItemViewModel CreateNew()
        {
            var newItem = new TodoItemViewModel() { ItemName = "New item:" };
            
            NavigateTo(newItem);

            return newItem;
        }

        public async void Save(TodoItemViewModel editItem)
        {
            if (Elements.Contains(editItem) == false)
            {
                Elements.Add(editItem);
            }
            await Navigation.ReturnToMain();
        }

        public async void CancelEdit(TodoItemViewModel item)
        {
            await Navigation.ReturnToMain();
        }

        public void NavigateTo(TodoItemViewModel item)
        {
            Navigation.NavigateToAsync(item);
        }

        public void Duplicate(TodoItemViewModel item)
        {
            var duplicate = CreateNew();
            duplicate.ItemName = item.ItemName + " copy";
            duplicate.IsChecked = item.IsChecked;
            duplicate.Description = item.Description;

            NavigateTo(duplicate);
        }

        public void Edit(TodoItemViewModel item)
        {
            NavigateTo(item);
        }
    }
}