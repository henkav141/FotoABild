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

namespace FotoABIld.Droid.UITools
{
    public static class ViewCreator
    {

        public static TextView CreateTextView(GravityFlags gravity, ViewGroup.LayoutParams lP,
            string text, Context context, int textSize, Color textColor)
        {
            var textView = new TextView(context)
            {
                LayoutParameters = lP,
                Text = text,
                Gravity = gravity,
                TextSize = textSize

            };
            textView.SetTextColor(textColor);
            return textView;
        }
        public static View CreateDivider(Context context, Color color)
        {
            var view = new View(context);
            view.SetBackgroundColor(color);
            view.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 1);

            return view;
        }
        public static LinearLayout CreateLinearLayout(Context context, ViewGroup.LayoutParams lP, Orientation orientation)
        {
            var layout = new LinearLayout(context)
            {
                LayoutParameters = lP,
                Orientation = orientation
            };
            return layout;
        }
    }
}