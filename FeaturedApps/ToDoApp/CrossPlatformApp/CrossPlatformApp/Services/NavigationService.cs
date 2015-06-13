namespace CrossPlatformApp.Services
{
    using Shared.Infrastructure.Services;
    using Shared.ViewModels;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms;

	public class NavigationService : INavigationService
	{
		public NavigationService(INavigation formsNavigation)
		{
            Navigation = formsNavigation;
		}

		protected INavigation Navigation { get; set; }

        Task INavigationService.NavigateToAsync(object context)
        {
            try
            {
                if (context is TodoItemViewModel)
                {
                    return NavigateTo<EditPage>(context);
                }
            }
            catch (System.Exception ex)
            {
            }
            return Task.Factory.StartNew(() => { });
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
            navigable.SetValue(NavigationPage.HasBackButtonProperty, true);

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