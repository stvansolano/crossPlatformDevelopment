namespace CrossPlatformApp
{
    using Xamarin.Forms;

    public class TabView : ContentView
    {
        #region Title

        public static readonly BindableProperty TitleProperty = BindableProperty.Create<TabView, string>(p => p.Title, default(string), BindingMode.OneWay, null, OnTitleChanged);

        private static void OnTitleChanged(BindableObject bindable, string oldValue, string newValue)
        {
            var source = bindable as TabView;
            if (source == null)
            {
                return;
            }
            source.OnTitleChanged();
        }

        private void OnTitleChanged()
        {
            OnPropertyChanged("Title");
        }

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        #endregion Title

        #region BindableContent

        public static readonly BindableProperty BindableContentProperty = BindableProperty.Create<TabView, View>(p => p.BindableContent, default(View), BindingMode.OneWay, null, OnBindableContentChanged);

        private static void OnBindableContentChanged(BindableObject bindable, View oldValue, View newValue)
        {
            var source = bindable as TabView;
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
    }
}
