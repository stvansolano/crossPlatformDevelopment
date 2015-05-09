namespace CrossPlatformApp
{
	using Shared.ViewModels;

	public partial class EditToDoView
	{
		public EditToDoView()
		{
			InitializeComponent();
		}

		public TodoItemViewModel ViewModel { get { return BindingContext as TodoItemViewModel; } }
	}
}