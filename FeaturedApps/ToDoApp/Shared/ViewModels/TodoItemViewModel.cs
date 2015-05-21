namespace Shared.ViewModels
{
	using System.Windows.Input;

	public class TodoItemViewModel : BaseViewModel
	{
		public const string ITEM_NAME_PROPERTY = "ItemName";
		private string _name = string.Empty;
		public string ItemName
		{
			get { return _name; }
			set { SetProperty(ref _name, value, ITEM_NAME_PROPERTY); }
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
    }
}