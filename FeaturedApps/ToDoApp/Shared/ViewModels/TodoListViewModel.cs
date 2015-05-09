namespace Shared.ViewModels
{
	public class TodoListViewModel : BaseViewModel
	{
		public const string TITLE_PROPERTY = "Title";

		private string title = string.Empty;
		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value, TITLE_PROPERTY); }
		}
	}
}