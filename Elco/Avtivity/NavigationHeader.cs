using Android.App;
using Android.OS;

namespace Elco
{
    public class NavigationHeader : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.nav_header_main);
        }
    }
}