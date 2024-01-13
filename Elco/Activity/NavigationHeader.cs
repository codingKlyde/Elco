using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Auth;

namespace Elco.Activity
{
    [Activity(Label = "Dashboard Activity")]
    public class NavigationHeader : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_dashboard);
        }
    }
}