namespace Tests
{
    using NUnit.Framework;
    using System;
    using System.IO;
    using System.Reflection;
    using Xamarin.UITest;
    using Xamarin.UITest.Configuration;

    [TestFixture()]
    public class AndroidTest : CrossPlatformTests
    {
        public string PathToAPK { get; set; }


        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            FileInfo fi = new FileInfo(currentFile);
            string dir = fi.Directory.Parent.Parent.Parent.FullName;

#if DEBUG
            PathToAPK = Path.Combine(dir, "CrossPlatformApp", "CrossPlatformApp.Droid", "bin", "Debug", "com.stvansolano.todoapp.apk");
#endif
        }

        [SetUp]
        public override void SetUp()
        {
            // an API key is required to publish on Xamarin Test Cloud for remote, multi-device testing
            // this works fine for local simulator testing though
            //App = ConfigureApp.Android.ApkFile(PathToAPK).ApiKey("36d0f463f0931d440289115b13087f27").StartApp();

            //App = AppInitializer.StartApp(Platform.Android);

            App = ConfigureApp.Android.ApiKey("2ad3fdc4d9dac33c02c44bb72858bd90").EnableLocalScreenshots().StartApp();

            App.Screenshot("Given the app is loaded");
        }

        [Test]
        public void AppLaunches()
        {
            App.Screenshot("First screen.");
        }
    }
}