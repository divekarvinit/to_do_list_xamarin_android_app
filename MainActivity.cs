using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Collections;
using System.Reflection.Emit;

namespace SearchName
{
    [Activity(Label = "SearchName", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public object HorizontalOptions { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ArrayList names = SearchName.Search("name");

            var buttons = FindViewById<LinearLayout>(Resource.Id.Buttons);

            foreach (var i in names)
            {
                Label person = new Label
                {
                    Text = i.ToString()

                };
                var button = new Button(this);
                button.Text = "ADD ";
                button.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                                                                     ViewGroup.LayoutParams.WrapContent);

            }
        }
    }
}

