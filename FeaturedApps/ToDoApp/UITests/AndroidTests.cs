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
        [SetUp]
        public override void SetUp()
        {
            App = ConfigureApp.Android.StartApp();

            App.Screenshot("Given the app is loaded");
        }

        [Test]
        public void AppLaunches()
        {
            App.Screenshot("First screen.");
        }
    }
}