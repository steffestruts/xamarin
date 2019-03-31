using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

using XamarinLibrary;

namespace XamarinAndroid
{
    class CustomListAdapter : BaseAdapter<Campaign>
    {
        private List<Campaign> mItems;
        private Context mContext;

        public CustomListAdapter(Context context, List<Campaign> Items) : base()
        {
            this.mItems = Items;
            this.mContext = context;
        }

        public override Campaign this[int position]
        {
            get { return mItems[position]; }
        }

        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            TextView lsItemTitle, lsItemSubtitle;
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.CustomListRow, null, false);
            }

            lsItemTitle = row.FindViewById<TextView>(Resource.Id.txtItemTitle);
            lsItemSubtitle = row.FindViewById<TextView>(Resource.Id.txtItemSubtitle);

            lsItemTitle.Text = mItems[position].Name;
            lsItemSubtitle.Text = mItems[position].Category;

            return row;
        }
    }
}