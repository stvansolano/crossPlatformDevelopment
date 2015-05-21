namespace Shared.Infrastructure.Services
{
	using System.Threading.Tasks;

	public interface INavigationService
	{
		/*
		Task NavigateToEditAsync<T, TContext>(TContext item)
			where T : class, new()
			where TContext : class;*/
		Task NavigateToEditAsync(object item);

        Task ReturnToMain();
    }
}