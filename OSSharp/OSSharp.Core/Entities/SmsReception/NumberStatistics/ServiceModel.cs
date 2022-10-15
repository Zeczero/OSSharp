using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSSharp.Core.Entities.SmsReception.NumberStatistics
{
    public class ServiceModel
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("popular")]
        public bool Popular { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}
