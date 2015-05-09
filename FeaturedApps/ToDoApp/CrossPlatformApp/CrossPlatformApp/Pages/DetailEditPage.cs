namespace CrossPlatformApp
{
	using Xamarin.Forms;

	public class DetailEditPage<TContext>
		where TContext : class
	{
		public DetailEditPage(ContentView content, TContext context)
		{
			
		}

		public NavigationPage Content { get; set; }
	}
}