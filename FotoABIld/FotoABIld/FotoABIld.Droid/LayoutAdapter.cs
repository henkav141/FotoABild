using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FotoABIld.Droid
{
    public class LayoutAdapter : BaseAdapter<TextView>
    {
        private List<TextView> items;
        private Activity context;

        public LayoutAdapter(Activity context, List<TextView> items) : base()
        {
            this.items = items;
            this.context = context;
        }


        public override long GetItemId(int position)
        {
            return position;
        }
        public override TextView this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            var text = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            text.Text = items[position].Text;
            text.SetTextColor(Color.ParseColor("#1F2F40"));

            return view;    
        }
    }
}