namespace CrossPlatformApp
{
    using Xamarin.Forms;

    public partial class ToggleImage
    {
        public ToggleImage()
        {
            InitializeComponent();

            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => ExecuteTap())
            });
        }

        public bool IsToggled { get; private set; }
        protected double PreviousHeight { get; set; }

        protected virtual void ExecuteTap()
        {
            IsToggled = !IsToggled;
            if (IsToggled)
            {
                PreviousHeight = HeightRequest;
                HeightRequest = ToggleHeight;
            }
            else
            {
                HeightRequest = PreviousHeight;
            }
        }

        #region Command

        public static readonly BindableProperty ToggleHeightProperty = BindableProperty.Create<ToggleImage, double>(p => p.ToggleHeight, default(double), BindingMode.OneWay, null, OnPropertyChanged);

        private static void OnPropertyChanged(BindableObject bindable, double oldValue, double newValue)
        {
            var source = bindable as ToggleImage;
            if (source == null)
            {
                return;
            }
            source.OnToggleHeightChanged();
        }

        private void OnToggleHeightChanged()
        {
            OnPropertyChanged("ToggleHeight");
        }

        public double ToggleHeight
        {
            get
            {
                return (double)GetValue(ToggleHeightProperty);
            }
            set
            {
                SetValue(ToggleHeightProperty, value);
            }
        }

        #endregion
    }
}
