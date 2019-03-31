using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using XamarinLibrary;

namespace XamarinAndroid
{
    [Activity(Label = "Unmaze", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class LoginActivity : Activity
    {
        public Button btnForgotPassword, btnLoginUser;
        public EditText edittextLoginName, edittextLoginPassword;

        public int loginAttempt = 2;

        // When activity is created
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            FindElement();
            EventHandle();
        }


        // Finds all elements on layout page
        private void FindElement()
        {
            btnForgotPassword = FindViewById<Button>(Resource.Id.btnLoginForgotPassword);
            btnLoginUser = FindViewById<Button>(Resource.Id.btnLoginUser);
            edittextLoginName = FindViewById<EditText>(Resource.Id.edittextLoginName);
            edittextLoginPassword = FindViewById<EditText>(Resource.Id.edittextLoginPassword);
        }

        // Adds event handles to element
        private void EventHandle()
        {
            btnLoginUser.Click += LoginUser_TouchEvent;
            btnForgotPassword.Click += ForgotPassword_TouchEvent;
        }

        // Touch event for login
        private void LoginUser_TouchEvent(object sender, EventArgs args)
        {
            ServiceLayer serviceLayer = new ServiceLayer();
            Account IsValid = serviceLayer.LoginCredential(edittextLoginName.Text, edittextLoginPassword.Text);

            if (IsValid != null)
            {
                int accountId = IsValid.AccountId;
                Intent catalog = new Intent(this, typeof(CatalogActivity));
                catalog.PutExtra("Account", accountId);
                StartActivity(catalog);
            }
            else
            {
                if (loginAttempt == 0)
                {
                    edittextLoginName.Text = "";
                    edittextLoginPassword.Text = "";
                    btnForgotPassword.Enabled = false;
                    btnLoginUser.Enabled = false;
                    edittextLoginName.Enabled = false;
                    edittextLoginPassword.Enabled = false;
                }
                else
                {
                    loginAttempt--;
                }
            }
        }

        // Touch event for forgot password
        private void ForgotPassword_TouchEvent(object sender, EventArgs args)
        {
            string dlgTitle, dlgContent;

            dlgTitle = Resources.GetString(Resource.String.dlgForgotTitle);
            dlgContent = Resources.GetString(Resource.String.dlgForgotContent);

            AlertDialog(dlgTitle, dlgContent, true);
        }

        // Dialog message structure
        private void AlertDialog(string title, string content, bool confirmable)
        {
            string negativeButton;

            negativeButton = Resources.GetString(Resource.String.dlgNegativeButton);

            var dialog = new AlertDialog.Builder(this);
            dialog.SetMessage(content);

            if (confirmable == true)
            {
                string outgoingLink, positiveButton;

                outgoingLink = Resources.GetString(Resource.String.dlgOutgoingLink);
                positiveButton = Resources.GetString(Resource.String.dlgPositiveButton);

                var url = Android.Net.Uri.Parse(outgoingLink);
                var intent = new Intent(Intent.ActionView, url);

                dialog.SetPositiveButton(positiveButton, delegate { StartActivity(intent); });
            }

            dialog.SetNegativeButton(negativeButton, delegate { });
            dialog.SetTitle(title);
            dialog.Show();
        }
    }
}