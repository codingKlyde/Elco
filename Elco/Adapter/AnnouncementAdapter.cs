using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace Elco.Adapter
{
    class AnnouncementAdapter : BaseAdapter<string>
    {

        private List<string> listItems;
        private Context listContext;

        public AnnouncementAdapter(Context context, List<string> items )
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

        public override string this[int position]
        {
            get { return listItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if ( row == null )
            {
                row = LayoutInflater.From(listContext).Inflate(Resource.Layout.announcement_item, null, false);
            }

            TextView tvList = row.FindViewById<TextView>(Resource.Id.textView_item);
            tvList.Text = listItems[position];

            return row;
        }
    }
}