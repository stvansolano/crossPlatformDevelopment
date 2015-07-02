namespace CrossPlatformApp.ViewModels
{
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ItemViewModel : ViewModel
    {
        public ItemViewModel()
        {
            LikeCommand = new Command(() => {
                Likes++;
            });
        }
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        private int _likes;
        public int Likes
        {
            get { return _likes; }
            set
            {
                _likes = value;
                OnPropertyChanged("Likes");
            }
        }

        public ICommand LikeCommand { get; set; }
    }
}