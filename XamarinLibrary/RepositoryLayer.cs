using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinLibrary
{
    // Cooperates with model and service layers.

    public class RepositoryLayer
    {
        //string url = "Add JSON here!";

        //public RepositoryLayer()
        //{
        //    Task.Run(() => this.LoadDataAsync(url)).Wait();
        //}

        //private async Task LoadDataAsync(string uri)
        //{
        //    if (account != null)
        //    {
        //        string responseJsonString = null;

        //        using (var httpClient = new HttpClient())
        //        {
        //            Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
        //            HttpResponseMessage response = await getResponse;

        //            responseJsonString = await response.Content.ReadAsStringAsync();
        //            account = JsonConvert.DeserializeObject<List<Catalog>>(responseJsonString);
        //        }
        //    }
        //}

        // Validate login attempt.
        public Account LoginCredential(string user, string password)
        {
            IEnumerable<Account> query =
                from account in accounts
                where account.UserName == user && account.Password == password
                select account;

            return query.FirstOrDefault();
        }

        // Will return all campaigns associated with accountId.
        public List<Campaign> GetCatalog(int accountId)
        {
            IEnumerable<Campaign> query =
                from account in accounts
                where account.AccountId == accountId
                from campaign in account.Campaigns
                orderby campaign.Name
                select campaign;

            return query.ToList<Campaign>();
        }

        // Returns data from specific campaign by id.
        public Campaign GetCampaign(int accountId, int campaignId)
        {
            IEnumerable<Campaign> query =
                from account in accounts
                where account.AccountId == accountId
                from campaign in account.Campaigns
                where campaign.CampaignId == campaignId
                select campaign;

            return query.FirstOrDefault();
        }

        // Dummy placeholder "database".
        private static List<Account> accounts = new List<Account>()
        {
            new Account()
            {
                AccountId = 1,
                UserName = "Admin",
                Password = "123456",
                FirstName = "Arne",
                LastName = "Weise",
                Campaigns = new List<Campaign>()
                {
                    new Campaign()
                    {
                        CampaignId = 1,
                        Name = "Mining Field",
                        Date = new DateTime(2017, 12, 2),
                        Category = "Tour",
                        Description = "Manchego smelly cheese danish fontina. Hard cheese cow goat red leicester pecorino macaroni cheese cheesecake gouda. Ricotta fromage cheese and biscuits stinking bishop halloumi monterey jack cheese strings goat. Pecorino babybel pecorino jarlsberg cow say cheese cottage cheese.",
                        Subscribers = 1231231,
                        IsActive = true
                    },
                    new Campaign()
                    {
                        CampaignId = 2,
                        Name = "Learn Grammar",
                        Date = new DateTime(2018, 10, 10),
                        Category = "Learn",
                        Description = "Bacon ipsum dolor amet turducken ham t-bone shankle boudin kevin. Hamburger salami pork shoulder pork chop. Flank doner turducken venison rump swine sausage salami sirloin kielbasa pork belly tail cow. Pork chop bacon ground round cupim tongue, venison frankfurter bresaola tri-tip andouille sirloin turducken spare ribs biltong. Drumstick ham hock pork tail, capicola shank frankfurter beef ribs jowl meatball turkey hamburger. Tenderloin swine ham pork belly beef ribeye. ",
                        Subscribers = 231,
                        IsActive = true
                    },
                    new Campaign()
                    {
                        CampaignId = 3,
                        Name = "Why so serious?",
                        Date = new DateTime(2018, 8, 10),
                        Category = "Lifetip",
                        Description = "Capicola short loin shoulder strip steak ribeye pork loin flank cupim doner pastrami. Doner short loin frankfurter ball tip pork belly, shank jowl brisket. Kielbasa prosciutto chuck, turducken brisket short ribs tail pork shankle ball tip. Pancetta jerky andouille chuck salami pastrami bacon pig tri-tip meatball tail bresaola shank short ribs strip steak. Ham hock frankfurter ball tip, biltong cow pastrami swine tenderloin ground round pork loin t-bone. ",
                        Subscribers = 5331,
                        IsActive = true
                    },
                    new Campaign()
                    {
                        CampaignId = 4,
                        Name = "Vandring i vandrarhemmet",
                        Date = new DateTime(2018, 12, 31),
                        Category = "Tour",
                        Description = "That is near—he who would make on these the bare perpendicular rock. From your malignity of my present existing in the lifeless and good fortune in torpor.",
                        Subscribers = 84921,
                        IsActive = false
                    },
                    new Campaign()
                    {
                        CampaignId = 5,
                        Name = "Sting Like A Bee",
                        Date = new DateTime(2019, 2, 19),
                        Category = "Hunting",
                        Description = "September 9th, the evil which I desire of life, added to the last evening the voices of the lowest degradation, a more tranquilly, might have no explanation necessary for admiration of my tranquillity.",
                        Subscribers = 64212,
                        IsActive = false
                    },
                    new Campaign()
                    {
                        CampaignId = 6,
                        Name = "Float Like A Butterfly",
                        Date = new DateTime(2018, 4, 30),
                        Category = "Learning",
                        Description = "Tand do you are not wish to perfectionate our Uncle Thomas' library. My heart I could not despond.",
                        Subscribers = 716231,
                        IsActive = true
                    },
                    new Campaign()
                    {
                        CampaignId = 7,
                        Name = "Cupcake",
                        Date = new DateTime(2025, 4, 20),
                        Category = "Cooking",
                        Description = "Cotton candy tootsie roll dragée. Cotton candy cake apple pie caramels. Carrot cake carrot cake gummi bears muffin cupcake jelly-o ice cream macaroon. Cupcake tootsie roll dragée cake jelly-o.",
                        Subscribers = 958163,
                        IsActive = false
                    },
                    new Campaign()
                    {
                        CampaignId = 8,
                        Name = "Cheeseburger",
                        Date = new DateTime(2199, 4, 14),
                        Category = "Cooking",
                        Description = "The palatable sensation we lovingly refer to as The Cheeseburger has a distinguished and illustrious history. It was born from humble roots, only to rise to well-seasoned greatness.",
                        Subscribers = 26361,
                        IsActive = true
                    },
                    new Campaign()
                    {
                        CampaignId = 9,
                        Name = "Pale Blue Dot",
                        Date = new DateTime(1985, 7, 12),
                        Category = "Documentary",
                        Description = "Sea of Tranquility tingling of the spine paroxysm of global death finite but unbounded hydrogen atoms cosmos, bits of moving fluff the ash of stellar alchemy Vangelis gathered by gravity Drake Equation inconspicuous motes of rock and gas, the ash of stellar alchemy colonies, inconspicuous motes of rock and gas a mote of dust suspended in a sunbeam, muse about consciousness rich in heavy atoms. Tendrils of gossamer clouds Sea of Tranquility and billions upon billions upon billions upon billions upon billions upon billions upon billions.",
                        Subscribers = 67361,
                        IsActive = false
                    }
                }
            },
            new Account()
            {
                AccountId = 2,
                UserName = "Mod",
                Password = "654321",
                FirstName = "Silicon",
                LastName = "Valley",
                Campaigns = new List<Campaign>()
                {
                   new Campaign()
                    {
                        CampaignId = 1,
                        Name = "Coffee",
                        Date = new DateTime(2013, 2, 14),
                        Category = "Lifestyle",
                        Description = "Coffee java frappuccino, skinny brewed flavour, latte in cinnamon steamed iced. So strong arabica decaffeinated doppio wings frappuccino coffee. Chicory et lungo id that, filter caffeine chicory mocha café au lait.",
                        Subscribers = 95828,
                       IsActive = false
                    },
                    new Campaign()
                    {
                        CampaignId = 2,
                        Name = "Bean",
                        Date = new DateTime(2025, 3, 18),
                        Category = "Production",
                        Description = "Sweet, siphon java latte skinny at, acerbic dark id and sugar. Medium organic steamed eu, americano plunger pot macchiato spoon white cinnamon mazagran milk. Aromatic seasonal, cultivar shop extraction trifecta body.",
                        Subscribers = 29,
                        IsActive = true
                    },
                    new Campaign()
                    {
                        CampaignId = 3,
                        Name = "Tutorial",
                        Date = new DateTime(2017, 5, 10),
                        Category = "Coding",
                        Description = "Abhorred monster! Let the most detestable occupation, whilst, still spurned. Was there to the evil, the print of grief had become more deeply imbued with towns and fearfully took a plaything in a great hindrance to bend my beloved dead hare; eat me and rendered mine from all.",
                        Subscribers = 91821,
                        IsActive = false
                    }
                }
            },
            new Account()
            {
                AccountId = 3,
                UserName = "Dummy",
                Password = "Ipsum",
                FirstName = "Lorem",
                LastName = "Ipsum",
                Campaigns = new List<Campaign>()
                {
                    new Campaign()
                    {
                        CampaignId = 1,
                        Name = "Why so serious?",
                        Date = new DateTime(2018, 10, 10),
                        Category = "Lifetip",
                        Description = "Capicola short loin shoulder strip steak ribeye pork loin flank cupim doner pastrami. Doner short loin frankfurter ball tip pork belly, shank jowl brisket. Kielbasa prosciutto chuck, turducken brisket short ribs tail pork shankle ball tip. Pancetta jerky andouille chuck salami pastrami bacon pig tri-tip meatball tail bresaola shank short ribs strip steak. Ham hock frankfurter ball tip, biltong cow pastrami swine tenderloin ground round pork loin t-bone. ",
                        Subscribers = 9172,
                        IsActive = true
                    },
                    new Campaign()
                    {
                        CampaignId = 2,
                        Name = "Frankenstein",
                        Date = new DateTime(1842, 7, 11),
                        Category = "Reading",
                        Description = "Capicola short loin shoulder strip steak ribeye pork loin flank cupim doner pastrami. Doner short loin frankfurter ball tip pork belly, shank jowl brisket. Kielbasa prosciutto chuck, turducken brisket short ribs tail pork shankle ball tip. Pancetta jerky andouille chuck salami pastrami bacon pig tri-tip meatball tail bresaola shank short ribs strip steak. Ham hock frankfurter ball tip, biltong cow pastrami swine tenderloin ground round pork loin t-bone. ",
                        Subscribers = 91823,
                        IsActive = false
                    }
                }
            }
        };
    }
}