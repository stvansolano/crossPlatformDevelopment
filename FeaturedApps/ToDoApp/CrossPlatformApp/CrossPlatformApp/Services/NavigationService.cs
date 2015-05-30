namespace CrossPlatformApp.Services
{
	using System.Threading.Tasks;
	using Shared.Infrastructure.Services;
	using Xamarin.Forms;
	using Shared.ViewModels;
    using System.Linq;

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

            try
            {
                return Navigation.PushModalAsync(navigable);
            }
            catch (System.Exception ex) 
            {
                return Task.Factory.StartNew(() => { });
            }
		}

        public Task ReturnToMain()
        {
            if (Navigation.ModalStack.Any())
            {
                return Navigation.PopModalAsync().ContinueWith(task => Navigation.PopToRootAsync());
            }
            return Navigation.PopToRootAsync();
        }
    }
}