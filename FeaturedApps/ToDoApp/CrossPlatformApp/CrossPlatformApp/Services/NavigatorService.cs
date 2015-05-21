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
				return NavigateToEdit<EditPage>(item);
			}
			return null;
		}

		private Task NavigateToEdit<TPage>(object context)
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