namespace CrossPlatformApp.Services
{
	using System.Threading.Tasks;
	using Shared.Infrastructure.Services;
	using Xamarin.Forms;
	using Shared.ViewModels;

	public class NavigatorService : INavigationService
	{
		public NavigatorService(INavigation navigation)
		{
			Navigation = navigation;
		}

		protected INavigation Navigation { get; set; }

		Task INavigationService.NavigateToEditAsync(object item)
		{
			if (item is TodoItemViewModel)
			{
				return NavigateToEdit<EditToDoView, TodoItemViewModel>(item);
			}
			return null;
		}

		private Task NavigateToEdit<T, TContext>(object context)
			where T : ContentView, new()
			where TContext : class
		{
			var content = new T();

			return Navigation.PushModalAsync(new NavigationPage(new ContentPage { Content = content, BindingContext = context }));
		}
	}
}