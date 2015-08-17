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
    using Android.Support.V4.View;

    [Activity(
        Label = "My Tasks",
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
            Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.View.StyleId))
                {
                    e.NativeView.ContentDescription = e.View.StyleId;
                }
            };

            try
            {
                var application = new App();
                LoadApplication(application);

                //application.SwitchFloatingTools();
            }
            catch (Exception ex)
            {
            }

            //ActionBar.CustomView = LayoutInflater.Inflate(Resource.Layout.MyCard, null);
            //ActionBar.DisplayOptions = ActionBarDisplayOptions.ShowCustom;

            /*
            ActionBar.CustomView = Inflate(context, Resource.Layout.PersonControl, this);
            ActionBar.DisplayOptions = ActionBarDisplayOptions.ShowCustom;
            ActionBar.SetHomeButtonEnabled(true);
            */
            
            /*if ((int)Android.OS.Build.VERSION.SdkInt >= 21)
            {*/
            ActionBar.SetIcon(new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));
            //}
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {/*
            MenuInflater inflater = base.MenuInflater;
            inflater.Inflate(Resource.Menu.main_activity_actions, menu);

            var searchItem = menu.FindItem(Resource.Id.action_search);
            SearchView searchView = (SearchView)MenuItemCompat.GetActionView(searchItem);
            */

            //menu.FindItem(Resource.Id.action_search).GetActionView();

            return base.OnCreateOptionsMenu(menu);

            //MenuInflater.Inflate(Resource.Menu.customMenu, menu);
        }
    }
}