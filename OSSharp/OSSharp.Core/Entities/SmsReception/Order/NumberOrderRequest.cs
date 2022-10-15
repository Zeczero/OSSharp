using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSSharp.Core.Entities.SmsReception.Order
{
    public class NumberOrderRequest
    {
        [JsonProperty("response")]
        public int Response { get; set; }

        [JsonProperty("tzid")]
        public int Tzid { get; set; }
    }
}
