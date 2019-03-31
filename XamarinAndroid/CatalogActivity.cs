using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using XamarinLibrary;

namespace XamarinAndroid
{
    [Activity(Label = "Catalog Activity")]
    public class CatalogActivity : Activity
    {
        public ListView campaignList;
        public List<Campaign> campaignItems;

        public int accountId;

        // When activity is created
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Catalog);

            campaignList = FindViewById<ListView>(Resource.Id.lsCatalogCustom);

            ServiceLayer serviceLayer = new ServiceLayer();
            accountId = Intent.GetIntExtra("Account", 0);

            campaignItems = serviceLayer.GetCatalog(accountId);
            campaignList.Adapter = new CustomListAdapter(this, campaignItems);
            campaignList.ItemClick += CampaignItem_TouchEvent;
        }

        
        // Event handle for single campaign item
        void CampaignItem_TouchEvent(object sender, AdapterView.ItemClickEventArgs e)
        {
            //string itemCategory = oItems[e.Position].Category;
            //string itemDate = oItems[e.Position].Date;
            //string itemDescription = oItems[e.Position].Description;
            //bool itemIsActive = oItems[e.Position].IsActive;
            //string itemName = oItems[e.Position].Name;

            //campaign.PutExtra("CampaignCategory", itemCategory);
            //campaign.PutExtra("CampaignDate", itemDate);
            //campaign.PutExtra("CampaignDescription", itemDescription);
            //campaign.PutExtra("CampaignName", itemName);
            //campaign.PutExtra("CampaignIsActive", itemIsActive);

            int campaignId = campaignItems[e.Position].CampaignId;

            Intent campaign = new Intent(this, typeof(CampaignActivity));

            campaign.PutExtra("AccountId", accountId);
            campaign.PutExtra("CampaignId", campaignId);

            StartActivity(campaign);
        }
    }
}