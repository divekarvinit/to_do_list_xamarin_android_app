using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ToDoList
{
    [Activity(Label = "UserToDoListActivity")]
    public class UserToDoListActivity : Activity
    {
        private TextView testView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UserToDoList);
            testView = FindViewById<TextView>(Resource.Id.testTextView1);
            testView.Text = "This is a test String for my purpose";
        }
    }
}