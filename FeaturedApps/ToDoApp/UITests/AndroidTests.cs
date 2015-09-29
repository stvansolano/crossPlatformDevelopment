namespace Tests
{
    using NUnit.Framework;
    using Xamarin.UITest;

    public class AndroidTest : CrossPlatformTests
    {
        [SetUp]
        public override void SetUp()
        {
			#if DEBUG
			App = ConfigureApp.Android.ApkFile("../../../CrossPlatformApp/CrossPlatformApp.Droid/bin/Debug/com.stvansolano.todoapp.apk").StartApp();
			#else
			App = ConfigureApp.Android.StartApp();
			#endif

            App.Screenshot("Given the app is loaded");
        }
    }
}