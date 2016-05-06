using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using FotoABIld.Droid.Resources.layout;
using FotoABIld.Droid.UITools;
using Java.Lang;
using Newtonsoft.Json;

namespace FotoABIld.Droid
{
    [Activity(Label = "HistoryActivity",Theme ="@style/AppBaseTheme",ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class HistoryActivity : AppCompatActivity
    {
        private ListView listView;
        private List<Order> orders;
        private Button homeButton;
        private Button deleteHistoryButton;
        private ViewSwitcher buttonViewSwitcher;
        private ViewSwitcher listViewSwitcher;
        private ListView deleteListView ;
        private LayoutAdapter adapter;
        private TrashListViewAdapter deleteAdapter;
        private Android.Support.V7.Widget.Toolbar toolbar;  

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OrderHistory);
            
            Init();
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarMenuOrderHistory,menu);
            return base.OnCreateOptionsMenu(menu);
        }

        private void Init()
        {
             homeButton = FindViewById<Button>(Resource.Id.HomeButton);
            deleteHistoryButton = FindViewById<Button>(Resource.Id.RemoveHistoryButton);
            buttonViewSwitcher = FindViewById<ViewSwitcher>(Resource.Id.buttonViewSwitcher);
            listViewSwitcher = FindViewById<ViewSwitcher>(Resource.Id.itemListViewSwitcher);
            listView = FindViewById<ListView>(Resource.Id.orderListView);
            deleteListView = FindViewById<ListView>(Resource.Id.deleteListView);
            //var trashCan = FindViewById<ImageView>(Resource.Id.trashCanIcon);
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
        

            orders = GetOrders();
            homeButton.Click += homeButton_Click;
            deleteHistoryButton.Click += deleteHistoryButton_Click;
            adapter = new LayoutAdapter(this, orders);
            deleteAdapter = new TrashListViewAdapter(this,orders);
            listView.Adapter = adapter;

            listView.ItemClick += listView_ItemClick;
            deleteListView.Adapter = deleteAdapter;
            deleteListView.ChoiceMode = ChoiceMode.Multiple;
            deleteListView.ItemClick +=deleteListView_ItemClick;
            //trashCan.Click += trashCan_Click;

        }

        private void deleteListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listItem = (RelativeLayout)deleteListView.GetChildAt(e.Position - deleteListView.FirstVisiblePosition);
            var checkbox = (CheckBox)listItem.GetChildAt(listItem.ChildCount -1);
           checkbox.Toggle();
        }

        private void deleteHistoryButton_Click(object sender, EventArgs e)
        {
            var checkedList = deleteListView.CheckedItemPositions;
            var positions = new List<int>();
            if (checkedList != null)
            {
                for (var i = 0; i < checkedList.Size(); i++)
                {
                    if(checkedList.ValueAt(i))
                    {
                        positions.Add(checkedList.KeyAt(i));
                        
                    }
                }
            }

            foreach (var position in positions.OrderByDescending(v=>v))
            {
                orders.Remove(orders[position]);
            }
            adapter.NotifyDataSetChanged();
            deleteAdapter.NotifyDataSetChanged();
            listViewSwitcher.ShowNext();
            buttonViewSwitcher.ShowNext();
            RemoveChecked();

            
                Serializer <List<Order>>.Serialize(orders, FilesDir + "/FotoABildKvitton");
            

        }

        private void RemoveChecked()
        {
            for (var i = 0; i < deleteListView.ChildCount-1; i++)
            {
                var listItem = (RelativeLayout)deleteListView.GetChildAt(i - deleteListView.FirstVisiblePosition);
                var checkbox = (CheckBox) listItem.GetChildAt(listItem.ChildCount - 1);
                checkbox.Checked = false;
            }
        }



        void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof (OrderHistoryItemActivity));
            var objectString = JsonConvert.SerializeObject(orders[e.Position]);
            intent.PutExtra("order", objectString);
            StartActivity(intent);

        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            Finish();
        }


        private List<Order> GetOrders()
        {

            var filepath = FilesDir + "/FotoABildKvitton";

            orders = Serializer<List<Order>>.DeSerialize(filepath);
            return orders;
        }
       
public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_delete:
                    listViewSwitcher.ShowNext();
                    buttonViewSwitcher.ShowNext();
                    return true;

                case Resource.Id.action_help:
                    var intent = new Intent(this,typeof(HelpActivity));
                    StartActivity(intent);
                    return true;

                default:

                    return OnOptionsItemSelected(item);
            }
        }



    }
}