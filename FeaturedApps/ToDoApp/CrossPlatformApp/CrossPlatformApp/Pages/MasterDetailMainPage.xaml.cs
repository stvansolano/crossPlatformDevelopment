namespace CrossPlatformApp.Pages
{
    using CrossPlatformApp.Services;
    using Shared.ViewModels;
    using Shared.WebServices;
    using System;
    using Xamarin.Forms;

    public partial class MasterDetailMainPage
    {
        public MasterDetailMainPage()
        {
            try
            {
                ViewModel = new ApplicationViewModel(new DataService(), new NavigationService(Navigation));
                InitializeComponent();
                SetupControls();
            }
            catch (Exception ex)
            {
            }
        }

        private void SetupControls()
        {
            MainList = Resources["MainList"] as ToDoList;
            MainList.MessageService = new MessageService(this);
            MainList.BindingContext = ViewModel.CurrentList;

            AllLists = Resources["AllLists"] as ListManager;

            ViewModel.Sections.Add(MainList);
            ViewModel.Sections.Add(AllLists);

            ViewModel.NewItemCommand = new Command(() =>
            {
                var newItem = MainList.CreateNew();
                ShowCurrentView(MainList.Title, MainList);
            });

            ViewModel.ClearListCommand = new Command(() =>
            {
                ViewModel.CurrentList.Elements.Clear();
                ShowCurrentView(MainList.Title, MainList);
            });

            BindingContext = ViewModel;

            ShowCurrentView(MainList.Title, MainList);

            ManageTasksButton.Clicked += delegate { ShowCurrentView(MainList.Title, MainList); };
            ManageListButton.Clicked += delegate { ShowCurrentView(AllLists.Title, AllLists); };
        }

        private void ShowCurrentView(string title, View content) 
        {
            ViewModel.Title = title;
            CurrentPageHolder.Content = content;
        }

        internal void Start()
        {
            if (ViewModel.CurrentList.HasItems == false)
            {
                MainList.LoadItemsAsync();
            }
        }

        public ApplicationViewModel ViewModel { get; set; }
        public ToDoList MainList { get; set; }
        public ListManager AllLists { get; set; }

        internal void SwitchFloatingTools()
        {
            var createAction = this.FindByName<ToolbarItem>("CreateAction");
            if (createAction != null)
            {
                ToolbarItems.Remove(createAction);
            }
            MainList.EnableCreateFloatingButton(createAction.Command);
        }
    }
}
