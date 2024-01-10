using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using System;

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
            // Initialize Xamarin Essentials for platform-specific functionality
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            etUsername = FindViewById<EditText>(Resource.Id.editText_username);
            etPassword = FindViewById<EditText>(Resource.Id.editText_password);
            bLogin = FindViewById<Button>(Resource.Id.button_login);

            // Attach the Click event handler to the login button
            bLogin.Click += LoginClicked;
        }


        /// <summary>
        /// Event handler for the login button click.
        /// </summary>
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
            else if (etUsername.Text == "admin" && password == "admin")
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


        /// <summary>
        /// Called when the result of a permission request is received.
        /// </summary>
        /// <param name="requestCode">The code associated with the permission request.</param>
        /// <param name="permissions">The requested permissions.</param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}