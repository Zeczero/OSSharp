using Newtonsoft.Json;

namespace OSSharp.Core.Entities.User
{
    public class CashBalance
    {
        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("zbalance")]
        public long Zbalance { get; set; }
    }
}
