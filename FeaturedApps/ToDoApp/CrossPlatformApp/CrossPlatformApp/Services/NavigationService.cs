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

        async void INavigationService.NavigateToAsync(object context)
        {
            try
            {
                if (context is TodoItemViewModel)
                {
                    await NavigateTo<EditPage>(context);
                }
            }
            catch (System.Exception)
            {
            }
        }

		private Task NavigateTo<TPage>(object context)
            where TPage : Page, new()
		{
            var newPage = new TPage() { BindingContext = context};
            var navigable = newPage as NavigationPage;
            if (navigable == null)
            {
                navigable = new NavigationPage(newPage);
            }
            return Navigation.PushAsync(navigable);
		}

        public Task ReturnToMain()
        {
            return Navigation.PopToRootAsync();
        }
    }
}