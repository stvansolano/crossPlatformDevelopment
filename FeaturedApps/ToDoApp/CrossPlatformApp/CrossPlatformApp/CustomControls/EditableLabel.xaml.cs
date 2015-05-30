namespace CrossPlatformApp
{
    using Xamarin.Forms;

    public partial class EditableLabel
    {
        public EditableLabel()
        {
            InitializeComponent();
        }

        #region BindableContent

        public static readonly BindableProperty BindableContentProperty = BindableProperty.Create<EditableLabel, View>(p => p.BindableContent, default(View), BindingMode.OneWay, null, OnBindableContentChanged);

        private static void OnBindableContentChanged(BindableObject bindable, View oldValue, View newValue)
        {
            var source = bindable as EditableLabel;
            if (source == null)
            {
                return;
            }
            source.OnBindableContentChanged();
        }

        private void OnBindableContentChanged()
        {
            Content = BindableContent;
            OnPropertyChanged("BindableContent");
        }

        public View BindableContent
        {
            get
            {
                return (View)GetValue(BindableContentProperty);
            }
            set
            {
                SetValue(BindableContentProperty, value);
            }
        }

        #endregion BindableContent

        #region Text

        public static readonly BindableProperty TextProperty = BindableProperty.Create<EditableLabel, string>(p => p.Text, default(string), BindingMode.OneWay, null, OnTextChanged);

        private static void OnTextChanged(BindableObject bindable, string oldValue, string newValue)
        {
            var source = bindable as EditableLabel;
            if (source == null)
            {
                return;
            }
            source.OnTextChanged();
        }

        private void OnTextChanged()
        {
            OnPropertyChanged("Text");
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        #endregion Text
    }
}
