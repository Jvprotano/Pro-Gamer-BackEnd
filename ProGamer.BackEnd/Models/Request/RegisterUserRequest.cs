using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGamer.BackEnd.Models.Request
{
    public class RegisterUserRequest
    {
        [JsonProperty("name")]
        public String name { get; set; }
        [JsonProperty("lastName")]
        public String lastName { get; set; }
        [JsonProperty("email")]
        public String email { get; set; }
        [JsonProperty("bithDate")]
        public DateTime bithDate { get; set; }
        [JsonProperty("password")]
        public String password { get; set; }


    }
}