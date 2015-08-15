namespace CrossPlatformApp
{
    using Shared.Infrastructure.Services;
    using Shared.ViewModels;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
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
            Title = "My Tasks";
		}

        public IMessageService MessageService { get; set; }
		public TodoListViewModel ViewModel { get { return BindingContext as TodoListViewModel; } }
        public string Title { get; set; }

		public void LoadItemsAsync()
		{
            DoRefresh();
		}

        private void DoRefresh()
        {
            if (IsFaulted)
            {
                StartTrying(1);
            }
            if (ViewModel == null)
            {
                return;
            }
            ViewModel.LoadItemsAsync().ContinueWith<TodoItemViewModel[]>(HandleResult);
        }

        public bool IsFaulted { get; set; }
        public bool IsTrying { get; set; }

        private TodoItemViewModel[] HandleResult(Task<TodoItemViewModel[]> task)
        {
            if (task.Exception != null)
            {
                IsFaulted = true;
                if (IsTrying == false)
                {
                    StartTrying(5);
                    return new TodoItemViewModel[0];
                }
                return new TodoItemViewModel[0];
            }

            IsFaulted = false;
            IsTrying = false;
            var result = task.Result;
            SetupCommands(result);

            if (ItemsList.IsRefreshing)
            {
                try
                {
                    ItemsList.IsRefreshing = false;
                    ItemsList.EndRefresh();
                }
                catch (Exception ex)
                {
                }
            }

            return result;
        }

        private void StartTrying(int tries)
        {
            IsTrying = true;

            Task.Factory.StartNew(new Action(async delegate
            {
                int _retryCount = 0;
                while (_retryCount < tries && IsFaulted)
                {
                    _retryCount++;
                    await Task.Delay(3000).ContinueWith(task =>
                    {
                        ViewModel.LoadItemsAsync().ContinueWith<TodoItemViewModel[]>(HandleResult);
                    });
                }
                IsTrying = false;
            }));
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

        internal void EnableCreateFloatingButton(ICommand command)
        {
            CreateAction.IsVisible = true;
            CreateAction.Command = command;
        }
    }
}