using Android.OS;
using Android.Views;
using Android.Widget;

namespace Elco
{
    public class FragmentDashboard : AndroidX.Fragment.App.Fragment
    {
        TextView tvName, tvEmail, tvPhotoURL;
        private DashboardViewModel dashboardViewModel;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.activity_dashboard, container, false);

            tvName = view.FindViewById<TextView>(Resource.Id.textView_Name);
            tvEmail = view.FindViewById<TextView>(Resource.Id.textView_Email);
            tvPhotoURL = view.FindViewById<TextView>(Resource.Id.textView_PhotoURL);

            dashboardViewModel = DashboardViewModel.Instance;
            string retrieveName = dashboardViewModel.SetName;
            string retrieveEmail = dashboardViewModel.SetEmail;
            string retrievPhotoURL = dashboardViewModel.SetPhotoURL;

            tvName.Text = "Name: " + retrieveName;
            tvEmail.Text = "Email: " + retrieveEmail;
            tvPhotoURL.Text = retrievPhotoURL;

            return view;
        }
    }
}
