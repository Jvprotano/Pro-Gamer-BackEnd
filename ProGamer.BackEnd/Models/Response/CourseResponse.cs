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
        public int Id { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("instrutorId")]
        public int InstrutorId { get; set; }

        [JsonIgnore]
        public string InstrutorName { get; set; }

        [JsonIgnore]
        public string InstrutorLastName { get; set; }

        [JsonProperty("instrutorFullName")]
        public string InstrutorFullName => InstrutorName + " " + InstrutorLastName;

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonProperty("strCreationDate")]
        public string StrCreationDate => CreationDate.ToString("dd/MM/yyyy");
    }
}