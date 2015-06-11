namespace CrossPlatformApp
{
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public partial class AccordionView
    {
        private ObservableCollection<AccordionItem> _items;

        public AccordionView()
        {
            _items = new ObservableCollection<AccordionItem>();
            InitializeComponent();
            
            _items.Add(new AccordionItem { Title = "Item #1", Content = "Body content #1", IsSelected = true });
            _items.Add(new AccordionItem { Title = "Item #2", Content = "Body content #2" });
            _items.Add(new AccordionItem { Title = "Item #3", Content = "Body content #3" });

            ItemsSource = _items;
        }

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
        }

        internal void Toggle(AccordionCell selectedItem)
        {
            foreach (var item in _items)
            {
                if (item.Cell != null && item.Cell != selectedItem)
                {
                    item.IsSelected = false;
                }
            }
            selectedItem.IsSelected = true;
        }
    }

    public class AccordionItem : BindableObject
	{
        public string Title { get; set; }
        public string Content { get; set; }
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public AccordionCell Cell { get; set; }
    }
}
