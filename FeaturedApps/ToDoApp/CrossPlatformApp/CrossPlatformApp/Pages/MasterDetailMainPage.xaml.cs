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
                CurrentPageHolder.Content = MainList;
            });

            ViewModel.ClearListCommand = new Command(() =>
            {
                ViewModel.CurrentList.Elements.Clear();
                CurrentPageHolder.Content = MainList;
            });

            BindingContext = ViewModel;

            CurrentPageHolder.Content = MainList;
            ManageListButton.Clicked += delegate { CurrentPageHolder.Content = AllLists; };
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
