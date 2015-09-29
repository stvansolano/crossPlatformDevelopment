namespace Tests
{
    using NUnit.Framework;
    using Xamarin.UITest;

    public class IosTests : CrossPlatformTests
    {
        [SetUp]
        public override void SetUp()
        {
#if DEBUG
            App = ConfigureApp.iOS.EnableLocalScreenshots().StartApp();
#else
			App = ConfigureApp.iOS.StartApp();
#endif

            App.Screenshot("Given the app is loaded in iOS");
        }
    }
}