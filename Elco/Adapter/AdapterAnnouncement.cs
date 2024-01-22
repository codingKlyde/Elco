using Android.Content;
using Android.Views;
using Android.Widget;
using Elco.Model;
using System.Collections.Generic;

namespace Elco.Adapter
{
    class AdapterAnnouncement : BaseAdapter<ModelAnnouncement>
    {

        private List<ModelAnnouncement> listItems;
        private Context listContext;

        public AdapterAnnouncement(Context context, List<ModelAnnouncement> items )
        {
            listItems = items;
            listContext = context;
        }

        public override int Count 
        { 
            get { return listItems.Count; } 
        }

        public override long GetItemId(int position) 
        { 
            return position; 
        }

        public override ModelAnnouncement this[int position]
        {
            get { return listItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if ( row == null )
                row = LayoutInflater.From(listContext).Inflate(Resource.Layout.announcement_item, null, false);

            TextView tvAnnouncementDate = row.FindViewById<TextView>(Resource.Id.textView_announcement_date);
            tvAnnouncementDate.Text = listItems[position].announcementDate;

            TextView tvAnnouncementDescription = row.FindViewById<TextView>(Resource.Id.textView_announcement_description);
            tvAnnouncementDescription.Text = listItems[position].announcementDescription;

            TextView tvAnnouncementTime = row.FindViewById<TextView>(Resource.Id.textView_announcement_time);
            tvAnnouncementTime.Text = listItems[position].announcementTime;

            TextView tvAnnouncementTitle = row.FindViewById<TextView>(Resource.Id.textView_announcement_title);
            tvAnnouncementTitle.Text = listItems[position].announcementTitle;

            return row;
        }
    }
}