using System;
using Android.App;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Navigation;
using Google.Android.Material.Snackbar;

namespace Elco
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
                drawer.CloseDrawer(GravityCompat.Start);
            else
                base.OnBackPressed();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
                return true;

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_dashboard)
            {
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, new FragmentDashboard()).Commit();
                return true;
            }
            else if (id == Resource.Id.nav_announcement)
            {
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, new FragmentAnnouncement()).Commit();
                return true;
            }
            else if (id == Resource.Id.nav_event)
            {
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, new FragementEvent()).Commit();
                return true;
            }
            else if (id == Resource.Id.nav_account)
            {
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, new FragementAccount()).Commit();
                return true;
            }
            else if (id == Resource.Id.nav_setting)
            {
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, new FragmentSetting()).Commit();
                return true;
            }

            else if (id == Resource.Id.nav_community_forum)
            {

            }
            else if (id == Resource.Id.nav_help_center)
            {

            }
            else if (id == Resource.Id.nav_report_bug)
            {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}

