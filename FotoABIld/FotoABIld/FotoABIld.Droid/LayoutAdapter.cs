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

namespace FotoABIld.Droid
{
    public class LayoutAdapter : BaseAdapter<Order>
    {
        private List<Order> items;
        private Activity context;

        public LayoutAdapter(Activity context, List<Order> items)

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
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null) 
                view = context.LayoutInflater.Inflate(Resource.Layout.OrderHistoryListItem, null);
            var textView = view.FindViewById<TextView>(Resource.Id.listItemText);
            var amountHandler = new AmountHandler(items[position].Pictures);
            var text = (items[position].Date.ToString("yyyy-M-d") + "   " 
                    + amountHandler.GetTotalAmount() + " bilder" + "   "
                    + PriceCalculator.CalculateTotalPrice(items[position].Pictures) + " kr");
            textView.Text = text;
            textView.SetTextSize(ComplexUnitType.Dip,20);
            textView.SetTextColor(Color.ParseColor("#1F2F40"));

            return view;    
        }
    }
}