namespace AccordionSample
{
    using Xamarin.Forms;

    public partial class AccordionCell
    {
        public AccordionCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var item = BindingContext as AccordionItem;
            if (item != null)
            {
                item.Cell = this;
            }
        }

        protected override void OnTapped()
        {
            base.OnTapped();

            var accordion = Parent as AccordionView;
            if (accordion != null)
            {
                accordion.Toggle(this);
            }
        }

        #region IsSelected

        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create<AccordionCell, bool>(p => p.IsSelected, default(bool), BindingMode.TwoWay, null, OnIsSelectedChanged);

        private static void OnIsSelectedChanged(BindableObject bindable, bool oldValue, bool newValue)
        {
            var source = bindable as AccordionCell;
            if (source == null)
            {
                return;
            }
            source.OnIsSelectedChanged();
        }

        private void OnIsSelectedChanged()
        {
            OnPropertyChanged("IsSelected");
        }

        public bool IsSelected
        {
            get
            {
                return (bool)GetValue(IsSelectedProperty);
            }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }

        #endregion IsSelected
    }
}