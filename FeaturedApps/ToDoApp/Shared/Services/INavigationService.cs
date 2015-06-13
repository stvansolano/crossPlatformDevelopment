namespace Shared.Infrastructure.Services
{
	using System.Threading.Tasks;

	public interface INavigationService
	{
		Task NavigateToAsync(object context);

        Task ReturnToMain();
    }
}