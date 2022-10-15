using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSSharp.Core.Entities.SmsReception.NumberStatistics
{
    public class Statistics
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("other")]
        public bool Other { get; set; }

        [JsonProperty("new")]
        public bool New { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("services")]
        public Dictionary<string, ServiceModel> Services { get; set; }
    }
}
