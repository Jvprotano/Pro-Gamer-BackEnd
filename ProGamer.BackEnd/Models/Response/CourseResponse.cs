using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGamer.BackEnd.Models.Response
{
    public class CourseResponse
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("duration")]
        public int duration { get; set; }

        [JsonProperty("value")]
        public decimal value { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("active")]
        public bool active { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("user")]
        public UserResponse user { get; set; }

        public string errorMessage { get; set; }
    }
}