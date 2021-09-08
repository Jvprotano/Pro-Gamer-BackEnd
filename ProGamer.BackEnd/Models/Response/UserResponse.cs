using Newtonsoft.Json;
using System;

namespace ProGamer.BackEnd.Models.Response
{
    public class UserResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("dateBirth")]
        public DateTime DateBirth { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        
        [JsonProperty("issued")]
        public DateTime Issued { get; set; }
       
        [JsonProperty("tokenType")]
        public string TokenType { get; set; }
        
        [JsonProperty("expiresIn")]
        public long ExpiresIn { get; set; }
     
        [JsonProperty("expires")]
        public DateTime Expires { get; set; }
    }
}