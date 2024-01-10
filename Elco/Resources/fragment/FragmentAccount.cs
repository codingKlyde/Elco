using Android.OS;
using Android.Views;

namespace Elco
{
    public class FragementAccount : AndroidX.Fragment.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.activity_account, container, false);
        }
    }
}