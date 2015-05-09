namespace CrossPlatformApp
{
	using Shared.ViewModels;
	using Xamarin.Forms;

	public class App : Application
	{
		public App()
		{
			// The root page of your application
			MainPage = new ToDoMainPage { BindingContext = new TodoListViewModel() { Title = "My To-do list" } };
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}