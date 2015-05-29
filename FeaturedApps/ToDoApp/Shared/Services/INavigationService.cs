namespace Shared.Infrastructure.Services
{
	using System.Threading.Tasks;

	public interface INavigationService
	{
		void NavigateToAsync(object context);

        Task ReturnToMain();
    }
}