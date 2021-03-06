﻿using Android.App;
using Android.Widget;
using Android.OS;
using System;

/* ToDoList Main Activity by VINIT DIVEKAR- 17960822 STARTS*/
namespace ToDoList
{
    [Activity(Label = "ToDoList", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static string URL_CONSTANT = "http://192.168.1.14:8080";
        private Button mBtnSignUp;
        private Button mBtnSignIn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            mBtnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            
            mBtnSignUp.Click += mBtnSignUp_Click;
            mBtnSignIn.Click += mBtnSignIn_Click;
        }

        private void mBtnSignUp_Click(object sender, EventArgs e)
        {
            // Open the Sign Up Dialog Box
            FragmentTransaction framgmentTransaction = FragmentManager.BeginTransaction();
            SignupDialog signUpDialog = new SignupDialog();
            signUpDialog.Show(framgmentTransaction, "dialog fragment");
        }

        private void mBtnSignIn_Click(object sender, EventArgs e)
        {
            // Open the Sign Up Dialog Box
            FragmentTransaction framgmentTransaction = FragmentManager.BeginTransaction();
            LogInDialog logInDialog = new LogInDialog();
            logInDialog.Show(framgmentTransaction, "login dialog fragment");
        }
    }
}

/* ToDoList Main Activity by VINIT DIVEKAR- 17960822 ENDS*/
