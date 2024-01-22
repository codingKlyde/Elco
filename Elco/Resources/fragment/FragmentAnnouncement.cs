using Android.OS;
using Android.Views;
using Android.Widget;
using Elco.Adapter;
using Elco.Model;
using System;
using System.Collections.Generic;
using static Android.Content.ClipData;

namespace Elco
{
    public class FragmentAnnouncement : AndroidX.Fragment.App.Fragment
    {
        private List<ModelAnnouncement> nItems;
        private ListView mListView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.activity_announcement, container, false);

            mListView = view.FindViewById<ListView>(Resource.Id.listView_announcement);

            nItems = new List<ModelAnnouncement>();

            nItems.Add(new ModelAnnouncement() { 
                announcementDate = "Feb. 5, 2024", 
                announcementDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent odio nibh, mollis vitae luctus ac, fermentum quis eros. Fusce pharetra aliquet felis id vestibulum. Integer diam urna, dapibus nec pellentesque at, iaculis sit amet arcu. Mauris et magna a enim posuere imperdiet. In bibendum orci at feugiat finibus. Sed a.",
                announcementTime = "1 pm - 5 pm", 
                announcementTitle = "Power Interruption" 
            });
            nItems.Add(new ModelAnnouncement()
            {
                announcementDate = "Sept. 21, 2024",
                announcementDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent odio nibh, mollis vitae luctus ac, fermentum quis eros. Fusce pharetra aliquet felis id vestibulum. Integer diam urna, dapibus nec pellentesque at, iaculis sit amet arcu. Mauris et magna a enim posuere imperdiet. In bibendum orci at feugiat finibus. Sed a.",
                announcementTime = "7 am - 11 am",
                announcementTitle = "Power Interruption"
            });

            AdapterAnnouncement adapter = new AdapterAnnouncement(Activity, nItems);
            mListView.Adapter = adapter;
            mListView.ItemClick += itemClick;

            return view;
        }

        private void itemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}