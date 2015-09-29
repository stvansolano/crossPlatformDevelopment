namespace Tests
{
    using NUnit.Framework;
    using Xamarin.UITest;

    public abstract class CrossPlatformTests
    {
        protected IApp App { get; set; }

        /// <summary>
        /// We do 'Ignore' in the base class so that these set of tests aren't actually *run*
        /// outside the context of one of the platform-specific bootstrapper sub-classes.
        /// </summary>

        [SetUp]
        public virtual void SetUp()
        {
            Assert.Ignore("This class requires a platform-specific bootstrapper to override the `SetUp` method");
        }

        [Test]
        public void AppLaunches()
        {
            //App.ScrollDown();
            App.Screenshot("First screen.");

            //App.Tap(x => x.Marked("ItemsList").Index(0));

            //App.Screenshot("Tapped list item");
        }

        //[Test]
        public void ItemsNavigation()
        {
            App.Screenshot("First screen.");

            App.ScrollDown();
            App.Screenshot("First screen.");

            App.Tap(x => x.Marked("ItemsList").Index(0));

            App.Screenshot("Tapped list item");
        }

        //[Test]
        public void DeleItemTest()
        {
            App.Repl();
        }
    }
}