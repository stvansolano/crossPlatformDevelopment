namespace CrossPlatformApp
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public partial class ToDoItemCell
    {
        public ToDoItemCell()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
            }
        }

        private void OnTapped(object sender, EventArgs e)
        {
            if (Command == null)
            {
                return;
            }
            if (Command.CanExecute(this))
            {
                Command.Execute(this);
            }
        }

        #region Command

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<ToDoItemCell, ICommand>(p => p.Command, default(ICommand), BindingMode.OneWay, null, OnCommandPropertyChanged);

        private static void OnCommandPropertyChanged(BindableObject bindable, ICommand oldValue, ICommand newValue)
        {
            var source = bindable as ToDoItemCell;
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