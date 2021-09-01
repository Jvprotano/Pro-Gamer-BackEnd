using Newtonsoft.Json;

namespace ProGamer.BackEnd.Models.Response
{
    public class LoginResponse
    {
        public LoginResponse()
        {
            Success = false;
        }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("userData")]
        public UserResponse UserData { get; set; }
    }
}