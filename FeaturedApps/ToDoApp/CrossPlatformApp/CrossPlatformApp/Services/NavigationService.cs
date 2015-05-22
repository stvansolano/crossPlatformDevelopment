namespace CrossPlatformApp.Services
{
	using System.Threading.Tasks;
	using Shared.Infrastructure.Services;
	using Xamarin.Forms;
	using Shared.ViewModels;

	public class NavigationService : INavigationService
	{
		public NavigationService(INavigation navigation)
		{
			Navigation = navigation;
		}

		protected INavigation Navigation { get; set; }

		Task INavigationService.NavigateToAsync(object context)
		{
			if (context is TodoItemViewModel)
			{
				return NavigateTo<EditPage>(context);
			}
			return null;
		}

		private Task NavigateTo<TPage>(object context)
            where TPage : Page, new()
		{
            return Navigation.PushAsync(new TPage() { BindingContext = context});
		}


        public Task ReturnToMain()
        {
            return Navigation.PopToRootAsync();
        }
    }
}