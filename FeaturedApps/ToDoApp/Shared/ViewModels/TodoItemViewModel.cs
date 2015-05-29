namespace Shared.ViewModels
{
    using Shared.Core;
    using Shared.Infrastructure.Services;
    using System.Windows.Input;

	public class TodoItemViewModel : BaseViewModel
	{
        public TodoItemViewModel(ToDoItem model)
        {
            Model = model;

            Description = "User:" + model.id + "completed:" + model.completed;
        }

        public TodoItemViewModel()
        {
            Model = new ToDoItem();
        }

        protected ToDoItem Model { get; set; }
        
		public string ItemName
		{
			get { return Model.title; }
            set
            {
                Model.title = value;
                OnPropertyChanged("ItemName");
            }
		}

		public const string DESCRIPTION_PROPERTY = "Description";
		private string _description;
		public string Description
		{
			get { return _description; }
			set { SetProperty(ref _description, value, DESCRIPTION_PROPERTY); }
		}

		public const string NAVIGATE_COMMAND_PROPERTY = "NavigateCommand";
		private ICommand _navigateCommand;
		public ICommand NavigateCommand
		{
			get { return _navigateCommand; }
			set { SetProperty(ref _navigateCommand, value, NAVIGATE_COMMAND_PROPERTY); }
		}

        public const string SAVE_COMMAND_PROPERTY = "SaveCommand";
        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get { return _saveCommand; }
            set { SetProperty(ref _saveCommand, value, SAVE_COMMAND_PROPERTY); }
        }

        public const string TOGGLE_COMMAND_PROPERTY = "ToggleCommand";
        private ICommand _toggleCommand;
        public ICommand ToggleCommand
        {
            get { return _toggleCommand; }
            set { SetProperty(ref _toggleCommand, value, TOGGLE_COMMAND_PROPERTY); }
        }

        private ICommand _showOptionsCommand;
        public ICommand ShowOptionsCommand
        {
            get { return _showOptionsCommand; }
            set
            {
                _showOptionsCommand = value;
                OnPropertyChanged("ShowOptionsCommand");
            }
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DuplicateCommand { get; set; }

        public bool IsChecked
        {
            get { return Model.completed; }
            set
            {
                Model.completed = value;
                OnPropertyChanged("IsChecked");
            }
        }

        public void Toggle()
        {
            Model.Toggle();
            OnPropertyChanged("IsChecked");
        }

        protected Menu LastMenu { get; set; }
        public Menu AsMenuOptions()
        {
            return LastMenu = new Menu
            {
                Title = "Options",
                Options = new MenuOption[] { 
                    new MenuOption { Text = "Edit", Command = EditCommand },
                    new MenuOption { Text = "Copy & edit", Command = DuplicateCommand}
                }
            };
        }
    }
}