namespace CrossPlatformApp
{
    using System.ComponentModel;
    using Xamarin.Forms;

    public class CustomViewCell : ViewCell
    {
        public static readonly BindableProperty ClientProperty = BindableProperty.Create<CustomViewCell, Client>(
            p => p.Client, new Client());

        public Client Client
        {
            get { return (Client)GetValue(ClientProperty); }
            set { SetValue(ClientProperty, value); }
        }

        public CustomViewCell()
        {
            var name = new Label { };
            var phone = new Label { };

            name.SetBinding(Label.TextProperty, new Binding(path: "FirstName", source: Client));
            phone.SetBinding(Label.TextProperty, new Binding(path: "Mobile", source: Client));

            var layout = new StackLayout { Orientation = StackOrientation.Horizontal };
            layout.Children.Add(name);
            layout.Children.Add(phone);

            this.View = layout;
        }

        protected override void OnTapped()
        {
            base.OnTapped();

            Client.FirstName = "Esteban";
            Client.Mobile = "555-5555";
        }
    }

    public class Client : INotifyPropertyChanged
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _mobile;
        public string Mobile
        {
            get { return _mobile; }
            set
            {
                _mobile = value;
                OnPropertyChanged("Mobile");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}