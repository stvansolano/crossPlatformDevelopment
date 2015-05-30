namespace CrossPlatformApp
{
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class TappedImage : Image
    {
        public TappedImage()
        {
            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => ExecuteTapCommand())
            });
        }

        private void ExecuteTapCommand()
        {
            if (Command == null)
            {
                return;
            }
            Command.Execute(this);
        }

        #region Command

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<TappedImage, ICommand>(p => p.Command, default(ICommand), BindingMode.OneWay, null, OnPropertyChanged);

        private static void OnPropertyChanged(BindableObject bindable, ICommand oldValue, ICommand newValue)
        {
            var source = bindable as TappedImage;
            if (source == null)
            {
                return;
            }
            source.OnCommandChanged();
        }

        private void OnCommandChanged()
        {
            OnPropertyChanged("Command");
        }

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        #endregion Command
    }
}
