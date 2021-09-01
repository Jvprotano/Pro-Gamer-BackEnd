using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProGamer.BackEnd.Helpers
{
    public class TokenHelper
    {
        public static async Task<TokenResponse> GenerateAuthUserTokenAsync(string email, string password, string url)
        {
            using (var client = new HttpClient())
            {
                var content = $"username={email}&password={password}&grant_type=password";
                var strContent = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");

                using (var response = await client.PostAsync(url, strContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
                        return result;
                    }

                    throw new Exception("Usuário não encontrado");
                }
            }
        }
    }

    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty(".issued")]
        public DateTime Issued { get; set; }

        [JsonProperty(".expires")]
        public DateTime Expires { get; set; }
    }
}