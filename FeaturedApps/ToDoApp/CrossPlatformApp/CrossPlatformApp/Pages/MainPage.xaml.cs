namespace CrossPlatformApp
{
    using Shared.Infrastructure.Services;
    using Shared.ViewModels;
    using Shared.WebServices;
    using Xamarin.Forms;
    using Pages;
    using System.Linq;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using CrossPlatformApp.Services;

    public partial class MainPage
		//MasterDetailPage
		//NavigationPage
		//TabbedPage
		//CarouselPage
	{
        public MainPage()
        {
            try
            {
                ViewModel = new ApplicationViewModel(new DataService(), new NavigationService(Navigation));
                InitializeComponent();
                SetupControls();
            }
            catch (System.Exception ex)
            {
            }            
        }

        private void SetupControls() 
        {
            CurrentToDoView = Resources["MainList"] as ToDoList;
            CurrentToDoView.MessageService = new MessageService(this);
            CurrentToDoView.BindingContext = ViewModel.CurrentList;

            AllLists = Resources["AllLists"] as ListManager;

            ViewModel.Sections.Add(CurrentToDoView);
            ViewModel.Sections.Add(AllLists);
            //ViewModel.Sections.Add(new Label { Text = "Coming soon" });

            ViewModel.NewItemCommand = new Command(() =>
            {
                var newItem = CurrentToDoView.CreateNew();

                //CurrentToDoView.ScrollTo(newItem);
            });

            ViewModel.ClearListCommand = new Command(() =>
            {
                ViewModel.CurrentList.Elements.Clear();
            });

            BindingContext = ViewModel;
        }

		internal void Start()
		{
            if (ViewModel.CurrentList.HasItems == false)
            {
                CurrentToDoView.LoadItemsAsync();
            }
		}

        public ApplicationViewModel ViewModel { get; set; }
        public ToDoList CurrentToDoView { get; set; }
        public ListManager AllLists { get; set; }
    }

    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationViewModel (IDataService dataService, INavigationService navigation)
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