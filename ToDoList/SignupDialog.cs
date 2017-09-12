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
using System.Threading.Tasks;

namespace ToDoList
{
    class SignupDialog : DialogFragment
    {
        private EditText mTxtFirstName;
        private EditText mTxtLastName;
        private EditText mTxtUserName;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private Button mBtnSignUp;
        private ProgressBar mProgressBar;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            mTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mTxtLastName = view.FindViewById<EditText>(Resource.Id.txtLastName);
            mTxtUserName = view.FindViewById<EditText>(Resource.Id.txtUserName);
            mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mBtnSignUp = view.FindViewById<Button>(Resource.Id.btnSignUp);
            mProgressBar = view.FindViewById<ProgressBar>(Resource.Id.progressBar1);

            mBtnSignUp.Click += async (sender, e) => {

                // Get the latitude and longitude entered by the user and create a query.
                string url = MainActivity.URL_CONSTANT + "/getLogin";

                // Fetch the weather information asynchronously, 
                // parse the results, then update the screen:
                mProgressBar.Visibility = ViewStates.Visible;
                JsonValue json = await RegisterUser(url);
                mProgressBar.Visibility = ViewStates.Invisible;
                // ParseAndDisplay (json);
            };

            return view;
        }

        private void mBtnSignUp_Click(object sender, EventArgs e) {

        }

        private async Task<JsonValue> RegisterUser(string url) {
            JsonValue jsonDoc = null;
            try
            {

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
                request.ContentType = "application/json";
                request.Method = "GET";

                using (WebResponse response = await request.GetResponseAsync())
                {
                    // Get a stream representation of the HTTP web response:
                    using (Stream stream = response.GetResponseStream())
                    {
                        // Use this stream to build a JSON document object:
                        jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                        Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());
                    }
                }
            }
            catch (Exception e) {
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