namespace CrossPlatformApp.Droid
{
    using System;
    using Android.App;
    using Android.Content.PM;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Android.OS;
    using Android.Graphics.Drawables;
    using Xamarin.Forms.Platform.Android;

    [Activity(
        Label = "My To-Do list showcase",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/Theme.MyTheme"
        //@android:style/Theme.Holo.Light
        //@style/MyTheme
    )]
    public class MainActivity : FormsApplicationActivity //XFormsApplicationDroid
                                //FormsApplicationActivity
                                // AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            try
            {
                LoadApplication(new App());
            }
            catch (Exception ex)
            {
            }

            /*if ((int)Android.OS.Build.VERSION.SdkInt >= 21)
            {
                ActionBar.SetIcon(new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));
            }*/
        }
    }
}