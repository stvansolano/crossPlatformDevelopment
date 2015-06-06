namespace CrossPlatformApp
{
    using Shared.Infrastructure.Services;
    using Shared.ViewModels;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public partial class ToDoList
	{
		public ToDoList()
		{
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {
            }

            ItemsList.RefreshCommand = new Command(DoRefresh);
            Title = "My TODO list";
		}

        public IMessageService MessageService { get; set; }
		public TodoListViewModel ViewModel { get { return BindingContext as TodoListViewModel; } }
        public string Title { get; set; }

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
            await ViewModel.LoadItemsAsync().ContinueWith<TodoItemViewModel[]>(HandleResult);
        }

        private TodoItemViewModel[] HandleResult(Task<TodoItemViewModel[]> task)
        {
            if (task.Exception != null)
            {
                return new TodoItemViewModel[0];
            }
            var result = task.Result;
            SetupCommands(result);

            if (ItemsList.IsRefreshing)
            {
                ItemsList.EndRefresh();
            }

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
            item.NavigateCommand = new Command(() => ViewModel.NavigateTo(item));
            item.SaveCommand = new Command(() => ViewModel.Save(item) );
            item.CancelEditCommand = new Command(() => ViewModel.CancelEdit(item));
            item.ToggleCommand = new Command(() => OnToggle(item));
            item.ShowOptionsCommand = new Command(() => OnShowOptionsCommand(item));
            item.DeleteCommand = new Command(() => OnDeletePrompt(item));
            item.DuplicateCommand = new Command(() => ViewModel.Duplicate(item));
            item.EditCommand = new Command(() => ViewModel.Edit(item));
        }

        private async void OnShowOptionsCommand(TodoItemViewModel item)
        {
            if (MessageService == null)
            {
                return;
            }

            var selected = await MessageService.PickChoiceFrom(item.AsMenuOptions());
            if (selected != null)
            {
                selected.Command.Execute(item);
            }
        }

        private async void OnDeletePrompt(TodoItemViewModel item)
        {
            var result = await MessageService.ShowYesNo("Confirm delete", "Do you really want to delete it?", "Yes", "No");

            if (result)
            {
                ViewModel.Elements.Remove(item);
            }
        }

        private void OnToggle(TodoItemViewModel item)
        {
            item.Toggle();
        }

        internal void ScrollTo(TodoItemViewModel newItem)
        {
            ItemsList.ScrollTo(newItem, ScrollToPosition.End, true);
            ItemsList.SelectedItem = newItem;
        }

        internal TodoItemViewModel CreateNew()
        {
            var newItem = ViewModel.CreateNew();
            SetupCommands(newItem);

            return newItem;
        }
    }
}