using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProGamer.BackEnd.Models.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}