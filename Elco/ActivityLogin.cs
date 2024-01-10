using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elco
{
    [Activity(Label = "@string/app_name", MainLauncher = true, NoHistory = true)]
    public class ActivityLogin : Activity
    {
        EditText etUsername;
        EditText etPassword;
        Button bLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);


            etUsername = FindViewById<EditText>(Resource.Id.editText_username);
            etPassword = FindViewById<EditText>(Resource.Id.editText_password);
            bLogin = FindViewById<Button>(Resource.Id.button_login);

            bLogin.Click += LoginClicked;
        }

        private void LoginClicked(object sender, EventArgs e)
        {
            string username = etUsername.Text;
            string password = etPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Toast.MakeText(this, "Username and password cannot be empty", ToastLength.Long).Show();

                etUsername.Text = "";
                etPassword.Text = "";
            }
            else if (username == "admin" && password == "admin")
            {
                Toast.MakeText(this, "Login Successful", ToastLength.Long).Show();

                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "Incorrect username or password", ToastLength.Long).Show();

                etUsername.Text = "";
                etPassword.Text = "";
            }
        }
    }
}