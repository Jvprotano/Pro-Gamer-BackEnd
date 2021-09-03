using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProGamer.BackEnd.Models.Request
{
    public class RegisterUserRequest
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [JsonProperty("name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "O campo sobrenome é obrigatório")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo data de nascimento é obrigatório")]
        [JsonProperty("dateBirth")]
        public DateTime DateBirth { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "A senha e a confirmação não conferem.")]
        [Required(ErrorMessage = "O campo confirmação de senha é obrigatório")]
        [JsonProperty("ConfirmPassword")]
        public string ConfirmPassword { get; set; }


    }
}