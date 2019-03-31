using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinLibrary
{
    // This "connects" with a service, SQL-server etcetra.

    public class ServiceLayer
    {
        // Call offline "database".
        private static RepositoryLayer repositoryLayer = new RepositoryLayer();

        // Validates userinput for login.
        public Account LoginCredential(string user, string password)
        {
            return repositoryLayer.LoginCredential(user, password);
        }

        // Fetch all campaigns from the account.
        public List<Campaign> GetCatalog(int accountId)
        {
            return repositoryLayer.GetCatalog(accountId);
        }

        // Gets all the data for specific campaign.
        public Campaign GetCampaign(int accountId, int campaignId)
        {
            return repositoryLayer.GetCampaign(accountId, campaignId);
        }
    }
}
