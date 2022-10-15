using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSSharp.Core.Entities.SmsReception.Order
{
    public class OrderInformation
    {
        [JsonProperty("country")]
        public int Country { get; set; }

        [JsonProperty("sum")]
        public double Sum { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonProperty("tzid")]
        public int Tzid { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("form")]
        public string Form { get; set; }
    }
}
