using Android.OS;
using Android.Views;
using Android.Widget;
using Elco.Adapter;
using System.Collections.Generic;

namespace Elco
{
    public class FragmentAnnouncement : AndroidX.Fragment.App.Fragment
    {
        private List<string> nItems;
        private ListView mListView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.activity_announcement, container, false);

            mListView = view.FindViewById<ListView>(Resource.Id.listView_announcement);

            nItems = new List<string>();
            nItems.Add("Announcement 1");
            nItems.Add("Announcement 2");
            nItems.Add("Announcement 3");


            AnnouncementAdapter adapter = new AnnouncementAdapter(Activity, nItems);
            mListView.Adapter = adapter;


            return view;
        }
    }
}