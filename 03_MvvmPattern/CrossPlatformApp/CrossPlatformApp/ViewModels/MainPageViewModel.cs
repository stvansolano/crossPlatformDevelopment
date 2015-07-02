namespace CrossPlatformApp.ViewModels
{
    using System.Collections.ObjectModel;

    public class MainPageViewModel : ViewModel
    {
        public MainPageViewModel()
        {
            MainText = "Hello Xamarin Forms!";
            Items = new ObservableCollection<ItemViewModel>();
        }

        private string _mainText;
        public string MainText
        {
            get { return _mainText; }
            set 
            {
                _mainText = value;
                OnPropertyChanged("MainText");
            }
        }

        public ObservableCollection<ItemViewModel> Items { get; set; }
    }
}
