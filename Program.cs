using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NUV_PublicAPIClient
{
    class Program
    {
        public const string SchemeId = "<Request from NUV administrator>";
        public const string BaseAddress = "<Request from NUV administrator>";
        public const string SecurityToken = "<Request from NUV administrator>";
        public const string BranchId = "<Request from NUV administrator>";

        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SecurityToken);

                //string token = "";
                //  client.b.SetBearerToken(token);
                // HTTP GET
                HttpResponseMessage response = await client.GetAsync($"api/LoyaltyUserAPI/8071001090514618?schemeId={SchemeId}&type=0");
                Guid userid = Guid.Empty;
                if (response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadAsAsync<User>();
                    Console.WriteLine("{0}\t${1}\t{2}", user.Name, user.CardNo, user.Status);
                    userid = user.Id;
                }
                else
                {
                    return;
                }

                // HTTP POST
                var transaction = new Transaction();

                transaction.SchemeId = Guid.Parse(SchemeId);
                transaction.UserIdType = UserIdType.UniqueId;
                transaction.Id = userid.ToString();
                transaction.Amount = 10233.45;
                transaction.Discount = 456.89;
                transaction.Location = BranchId;
                transaction.Reason = "Purchase";

                //Put here Offer id or Reward Id. To get offer list and reward list please reffer the api help page.
                //transaction.OfferId = <offerid/rewardid>;

                response = await client.PostAsJsonAsync("api/LoyaltyTransactionAPI", transaction);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<bool>();
                    if (result)
                    {
                        Console.WriteLine("Transaction Complete");
                        return;
                    }
                }

                Console.WriteLine("Error: Transaction did not Complete");

            }
        }
    }
}
