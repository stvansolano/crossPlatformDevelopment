namespace Shared.ViewModels
{
    using Infrastructure.Services;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationViewModel(IDataService dataService, INavigationService navigation)
        {
            Title = "ToDoApp";
            CurrentList = new TodoListViewModel(dataService, navigation);
            Sections = new ObservableCollection<object>();
        }

        public TodoListViewModel CurrentList { get; set; }
        public ObservableCollection<object> Sections { get; set; }

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

        public const string CLEAR_LIST_COMMAND_PROPERTY = "ClearListCommand";
        private ICommand _clearListCommand;
        public ICommand ClearListCommand
        {
            get { return _clearListCommand; }
            set { SetProperty(ref _clearListCommand, value, CLEAR_LIST_COMMAND_PROPERTY); }
        }
    }
}