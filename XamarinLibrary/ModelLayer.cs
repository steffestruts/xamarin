using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinLibrary
{
    // Acts as end station for the class library. It will feed data to platform specific code.

    public class Account
    {
        public int AccountId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Campaign> Campaigns { get; set; }
    }

    public class Campaign
    {
        public int CampaignId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; }

        public int Subscribers { get; set; }

        public string ImagePath { get; set; }

        public bool IsActive { get; set; }
    }
}