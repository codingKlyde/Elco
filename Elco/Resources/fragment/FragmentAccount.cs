using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace Elco
{
    public class FragementAccount : AndroidX.Fragment.App.Fragment
    {

        TextView tvUserID, tvName, tvEmail, tvPhoneNumber, tvPhotoURL, tvCreationTimestamp;
        private AccountViewModel accountViewModel;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)

        {
            View view = inflater.Inflate(Resource.Layout.activity_account, container, false);

            tvUserID = view.FindViewById<TextView>(Resource.Id.textView_UserID);
            tvName = view.FindViewById<TextView>(Resource.Id.textView_Name);
            tvEmail = view.FindViewById<TextView>(Resource.Id.textView_Email);
            tvPhoneNumber = view.FindViewById<TextView>(Resource.Id.textView_PhoneNumber);
            tvPhotoURL = view.FindViewById<TextView>(Resource.Id.textView_PhotoURL);
            tvCreationTimestamp = view.FindViewById<TextView>(Resource.Id.textView_CreationTimestamp);

            accountViewModel = AccountViewModel.Instance;
            string retrieveUserID = accountViewModel.SetUID;
            string retrieveName = accountViewModel.SetName;
            string retrieveEmail = accountViewModel.SetEmail;
            string retrievePhoneNumber = accountViewModel.SetPhoneNumber;
            string retrievPhotoURL = accountViewModel.SetPhotoURL;
            long retrieveCreationTimeStamp = accountViewModel.SetCreationTimestamp;

            tvUserID.Text += retrieveUserID;
            tvName.Text += retrieveName;
            tvEmail.Text += retrieveEmail;
            tvPhoneNumber.Text += retrievePhoneNumber;
            tvPhotoURL.Text += retrievPhotoURL;
            tvCreationTimestamp.Text += retrieveCreationTimeStamp;

            return view;
        }
    }
}