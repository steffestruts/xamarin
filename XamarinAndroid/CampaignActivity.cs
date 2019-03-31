using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using XamarinLibrary;

namespace XamarinAndroid
{
    [Activity(Label = "Campaign Activity")]
    public class CampaignActivity : Activity
    {
        public TextView txtCampaignName, txtCampaignDateDay, txtCampaignDateMonth, txtCampaignCategory, txtCampaignIsActive, txtCampaignDescription, txtCampaignSubscribers;
        public string resourceIsActiveTrue, resourceIsActiveFalse;

        // When activity is created
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Campaign);

            FindElement();
            FetchTranslation();
            DataBinding();
        }

        // Finds all elements on layout page
        private void FindElement()
        {
            txtCampaignCategory = FindViewById<TextView>(Resource.Id.txtCampaignCategory);
            txtCampaignDateDay = FindViewById<TextView>(Resource.Id.txtCampaignDateDay);
            txtCampaignDateMonth = FindViewById<TextView>(Resource.Id.txtCampaignDateMonth);
            txtCampaignDescription = FindViewById<TextView>(Resource.Id.txtCampaignDescription);
            txtCampaignSubscribers = FindViewById<TextView>(Resource.Id.txtCampaignSubscribers);
            //txtCampaignIsActive = FindViewById<TextView>(Resource.Id.txtCampaignIsActive);
            txtCampaignName = FindViewById<TextView>(Resource.Id.txtCampaignName);
        }

        // Gets text/translation from ../resource/values/..
        private void FetchTranslation()
        {
            resourceIsActiveTrue = Resources.GetString(Resource.String.isActiveTrue);
            resourceIsActiveFalse = Resources.GetString(Resource.String.isActiveFalse);
        }


        // Binds data from campaign service layer
        private void DataBinding()
        {
            //string campaignCategory = Intent.GetStringExtra("CampaignCategory");
            //string campaignDate = Intent.GetStringExtra("CampaignDate");
            //string campaignDescription = Intent.GetStringExtra("CampaignDescription");
            //bool campaignIsActive = Intent.GetBooleanExtra("CampaignIsActive", false);
            //string campaignName = Intent.GetStringExtra("CampaignName");

            int aId = Intent.GetIntExtra("AccountId", 0);
            int cId = Intent.GetIntExtra("CampaignId", 0);

            ServiceLayer serviceLayer = new ServiceLayer();
            Campaign campaign = serviceLayer.GetCampaign(aId, cId);

            var date = campaign.Date;
            var day = date.ToString("dd");

            var month = date.ToString("MMMM");

            txtCampaignName.Text = campaign.Name /*campaignName*/;
            txtCampaignDateDay.Text = day /*campaignDate*/;
            txtCampaignDateMonth.Text = month /*campaignDate*/;
            txtCampaignCategory.Text = campaign.Category /*campaignCategory*/;
            txtCampaignDescription.Text = campaign.Description /*campaignDescription*/;
            txtCampaignSubscribers.Text = campaign.Subscribers.ToString();

            //if (campaign.IsActive /*campaignIsActive*/ == false)
            //{
            //    txtCampaignIsActive.Text = resourceIsActiveTrue;
            //}
            //else
            //{
            //    txtCampaignIsActive.Text = resourceIsActiveFalse;
            //}
        }
    }
}