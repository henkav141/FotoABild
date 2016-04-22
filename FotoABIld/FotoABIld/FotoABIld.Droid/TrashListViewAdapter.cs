using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FotoABIld.Droid.UITools;

namespace FotoABIld.Droid
{
    public class TrashListViewAdapter : BaseAdapter<Order>
    {
        private List<Order> items;
        private Activity context;

        public TrashListViewAdapter(Activity context, List<Order> items)
        {
            this.items = items;
            this.context = context;
        }


        public override long GetItemId(int position)
        {
            return position;
        }
        public override Order this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        private  class CheckBoxHolder
        {
            public TextView info;
            public CheckBox checkbox;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            var holder = new CheckBoxHolder();
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.TrashCheckBox, null);


            holder.info = view.FindViewById<TextView>(Resource.Id.listItemText);
            holder.checkbox = view.FindViewById<CheckBox>(Resource.Id.listItemCheckBox);
            var amountHandler = new AmountHandler(items[position].Pictures);
            var text = (items[position].Date.ToString("yyyy-M-d") + "   "
            + amountHandler.GetTotalAmount() + " bilder" + "   "
            + PriceCalculator.CalculateTotalPrice(items[position].Pictures) + " kr");
            holder.info.Text = text;
            holder.info.TextSize = 20;
            holder.info.SetTextColor(Color.ParseColor("#1F2F40"));
            var pixels = (int)context.Resources.DisplayMetrics.Density*15;
            holder.info.SetPadding(0, 0, 0,pixels);


            

            
            return view;
        }
    }
}