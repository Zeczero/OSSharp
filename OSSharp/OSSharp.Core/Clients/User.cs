using OSSharp.Core.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using OSSharp.Core.Entities.User;

namespace OSSharp.Core.Clients
{
    public class User : Base, IOnlineSimUser
    {
        public User(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<CashBalance> GetBalance()
        {
            return await GetAsync<CashBalance>(AddStringToQuery(ApiEndPoints.UserApiEndPoint.Balance)).ConfigureAwait(false);        
        }
    }
}
