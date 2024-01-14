using Android.OS;
using Android.Views;

namespace Elco
{
    public class FragmentDashboard : AndroidX.Fragment.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.activity_dashboard, container, false);

            return view;
        }
    }
}
