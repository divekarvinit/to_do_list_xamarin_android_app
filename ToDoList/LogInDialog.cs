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
using System.Net;
using System.IO;
using System.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

/* LOG IN DIALOG by Vinit Divekar- 17960822 STARTS*/
namespace ToDoList
{
    public class LogInDialog : DialogFragment
    {

        private EditText mTxtUserName;
        private EditText mTxtPassword;
        private Button mBtnLogIn;
        private ProgressBar mProgressBar;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_login, container, false);
            
            mBtnLogIn = view.FindViewById<Button>(Resource.Id.btnLogIn);
            mTxtUserName = view.FindViewById<EditText>(Resource.Id.txtSignInUserName);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtSignInPassword);
            mProgressBar = view.FindViewById<ProgressBar>(Resource.Id.progressBarInSignInDialog);

            try
            {
                mBtnLogIn.Click += async (sender, e) =>
                {
                    if (mTxtUserName.Text == null || mTxtUserName.Text == "" ||
                        mTxtPassword.Text == null || mTxtPassword.Text == "")
                    {
                        Toast.MakeText(Activity, "Please enter all the fields", ToastLength.Long).Show();
                    }
                    else {
                        string url = MainActivity.URL_CONSTANT + "/loginUser";
                        dynamic formData = new JObject();
                        formData.userName = mTxtUserName.Text;
                        formData.password = mTxtPassword.Text;

                        mProgressBar.Visibility = ViewStates.Visible;
                        JsonValue json = await LoginUser(url, formData.ToString());
                        mProgressBar.Visibility = ViewStates.Invisible;
                    }
                };
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            return view;
        }

        private async Task<JsonValue> LoginUser(string url, string data)
        {
            JsonValue jsonDoc = null;

            try
            {
                HttpClient client = new HttpClient();
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                var responseStream = await response.Content.ReadAsStreamAsync();
                jsonDoc = await Task.Run(() => JsonObject.Load(responseStream));

                if (jsonDoc["success"] == "N")
                {
                    Toast.MakeText(Activity, "Invalid User Name or Password", ToastLength.Long).Show();
                }

                else if (jsonDoc["success"] == "Y")
                {
                    Intent intentOfNextActivity = new Intent(this.Activity, typeof(CreateList));
                    StartActivity(intentOfNextActivity);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return jsonDoc;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}

/* LOG IN DIALOG by Vinit Divekar- 17960822 ENDS*/
