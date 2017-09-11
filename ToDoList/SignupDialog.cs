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
    class SignupDialog : DialogFragment
    {
        private EditText mTxtFirstName;
        private EditText mTxtLastName;
        private EditText mTxtUserName;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private Button mBtnSignUp;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mTxtFirstName = FindViewById<EditText>(Resource.Id.txtFirstName);
            mTxtLastName = FindViewById<EditText>(Resource.Id.txtLastName);
            mTxtUserName = FindViewById<EditText>(Resource.Id.txtUserName);
            mTxtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);

            mBtnSignUp.Click += mBtnSignUp_Click;

            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            return view;
        }

        private void mBtnSignUp_Click(object sender, EventArgs e) {

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}