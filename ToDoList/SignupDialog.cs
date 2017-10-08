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

/* SIGN UP DIALOG by Vinit Divekar- 17960822 STARTS*/
namespace ToDoList
{
    class SignupDialog : DialogFragment
    {
        private EditText mTxtFirstName;
        private EditText mTxtLastName;
        private EditText mTxtUserName;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private EditText mTxtConfirmPassword;
        private Button mBtnSignUp;
        private ProgressBar mProgressBar;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);
            try
            {


                mTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
                mTxtLastName = view.FindViewById<EditText>(Resource.Id.txtLastName);
                mTxtUserName = view.FindViewById<EditText>(Resource.Id.txtUserName);
                mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
                mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
                mBtnSignUp = view.FindViewById<Button>(Resource.Id.btnSignUp);
                mProgressBar = view.FindViewById<ProgressBar>(Resource.Id.progressBarInSignUpDialog);
                mTxtConfirmPassword = view.FindViewById<EditText>(Resource.Id.txtConfirmPassword);

                mBtnSignUp.Click += async (sender, e) =>
                {
                    var validation = false;
                    if (mTxtFirstName.Text == null || mTxtFirstName.Text == "" ||
                        mTxtLastName.Text == null || mTxtLastName.Text == "" ||
                        mTxtUserName.Text == null || mTxtUserName.Text == "" ||
                        mTxtEmail.Text == null || mTxtEmail.Text == "" ||
                        mTxtPassword.Text == null || mTxtPassword.Text == "" ||
                        mTxtConfirmPassword.Text == null || mTxtConfirmPassword.Text == "")
                    {
                        Toast.MakeText(Activity, "Please enter all the fields", ToastLength.Long).Show();
                    }
                    else if (mTxtPassword.Text != mTxtConfirmPassword.Text)
                    {
                        mTxtConfirmPassword.Error = "Passwords Do Not Match";
                    }
                    else
                    {
                        validation = true;
                    }
                    // Get the latitude and longitude entered by the user and create a query.
                    string url = MainActivity.URL_CONSTANT + "/registerUser";
                    dynamic formData = new JObject();
                    formData.firstName = mTxtFirstName.Text;
                    formData.lastName = mTxtLastName.Text;
                    formData.userName = mTxtUserName.Text;
                    formData.emailId = mTxtEmail.Text;
                    formData.password = mTxtPassword.Text;

                    // parse the results, then update the screen:
                    if (validation)
                    {
                        mProgressBar.Visibility = ViewStates.Visible;
                        JsonValue json = await RegisterUser(url, formData.ToString());
                        mProgressBar.Visibility = ViewStates.Invisible;
                        // ParseAndDisplay (json);
                    }

                };
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            return view;
        }

        private void mBtnSignUp_Click(object sender, EventArgs e) {

        }

        private async Task<JsonValue> RegisterUser(string url, string data)
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
                    if (jsonDoc["fieldName"] == "userName")
                    {
                        mTxtUserName.Error = jsonDoc["message"];
                    }
                    else if (jsonDoc["fieldName"] == "emailId")
                    {
                        mTxtEmail.Error = jsonDoc["message"];
                    }
                }

                else if (jsonDoc["success"] == "Y") {
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

/* SIGN UP DIALOG by Vinit Divekar- 17960822 ENDS*/
