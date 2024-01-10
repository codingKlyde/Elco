using Android.OS;
using AndroidX.AppCompat.App;

namespace Elco
{
    // [Activity(Label = "ActivityDashboard")]
    public class ActivityDashboard : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_dashboard);
        }
    }
}