using Android.App;
using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase;
using Firebase.Auth;
using System;

namespace Elco.Activity
{
    [Activity(MainLauncher = true, NoHistory = true)]
    public class ActivityLogin : AppCompatActivity, IOnSuccessListener, IOnFailureListener
    {
        GoogleSignInOptions gso;
        GoogleApiClient gac;

        FirebaseAuth firebaseAuth;

        EditText etUsername;
        EditText etPassword;
        Button bLogin;

        Button bGoogleSignIn;

        private DashboardViewModel viewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            // Initialize Xamarin Essentials for platform-specific functionality
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                .RequestIdToken("339367572283-g14v6ne3oo56ljettjdrffhb6ttdeaie.apps.googleusercontent.com")
                .RequestEmail()
                .Build();

            gac = new GoogleApiClient.Builder(this).AddApi(Auth.GOOGLE_SIGN_IN_API, gso).Build();
            gac.Connect();

            firebaseAuth = GetFirebaseAuth();


            etUsername = FindViewById<EditText>(Resource.Id.editText_username);
            etPassword = FindViewById<EditText>(Resource.Id.editText_password);
            bLogin = FindViewById<Button>(Resource.Id.button_login);
            bLogin.Click += LoginClicked;

            bGoogleSignIn = FindViewById<Button>(Resource.Id.button_google_signin);
            bGoogleSignIn.Click += GoogleSignInClicked;

            UpdateUI();
        }


        private FirebaseAuth GetFirebaseAuth()
        {
            FirebaseAuth mAuth;

            var app = FirebaseApp.InitializeApp(this);

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetProjectId("elco-cfdf3")
                    .SetApplicationId("elco-cfdf3")
                    .SetApiKey("AIzaSyBQXDHtQOBRSveERo9un9xl1Xnx2lM9P_M")
                    .SetDatabaseUrl("https://elco-cfdf3-default-rtdb.asia-southeast1.firebasedatabase.app")
                    .SetStorageBucket("elco-cfdf3.appspot.com")
                    .Build();

                FirebaseApp.InitializeApp(this, options);
                mAuth = FirebaseAuth.Instance;
            }
            else
            {
                mAuth = FirebaseAuth.Instance;
            }

            return mAuth;
        }


        private void GoogleSignInClicked(object sender, EventArgs e)
        {
            UpdateUI();
            if (firebaseAuth.CurrentUser == null)
            {
                var intent = Auth.GoogleSignInApi.GetSignInIntent(gac);
                StartActivityForResult(intent, 1);
            }
            else
            {
                firebaseAuth.SignOut();
                UpdateUI();
            }
           
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 1)
            {
                GoogleSignInResult result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);

                if (result.IsSuccess)
                {
                    GoogleSignInAccount account = result.SignInAccount;
                    LoginWithFirebase(account);
                }
            }
        }

        private void LoginWithFirebase(GoogleSignInAccount account)
        {
            var credentials = GoogleAuthProvider.GetCredential(account.IdToken, null);
            firebaseAuth.SignInWithCredential(credentials)
                .AddOnSuccessListener(this)
                .AddOnFailureListener(this);
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

        public void OnSuccess(Java.Lang.Object result)
        {
            string storeName = firebaseAuth.CurrentUser.DisplayName;
            string storeEmail = firebaseAuth.CurrentUser.Email;
            string storePhotoURL = firebaseAuth.CurrentUser.PhotoUrl?.ToString(); // Handle null
           
            DashboardViewModel.Instance.SetName = storeName;
            DashboardViewModel.Instance.SetEmail = storeEmail;
            DashboardViewModel.Instance.SetPhotoURL = storePhotoURL;

            Intent intent = new Intent(this, typeof(MainActivity));      
            StartActivity(intent);

            Toast.MakeText(this, "Login successfully", ToastLength.Short).Show();
            UpdateUI();
        }

        public void OnFailure(Java.Lang.Exception e)
        {
            Toast.MakeText(this, "Try again", ToastLength.Short).Show();
            UpdateUI();
        }

        void UpdateUI()
        {
            if (firebaseAuth.CurrentUser != null)
            {
                bGoogleSignIn.Text = "Sign Out";
            }
            else
            {
                bGoogleSignIn.Text = "Sign in with Google";
            }
        }
    }
}