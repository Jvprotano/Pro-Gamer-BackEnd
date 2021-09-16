using Newtonsoft.Json;
using System;

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

        [JsonProperty("instructorId")]
        public int InstructorId { get; set; }

        [JsonIgnore]
        public string InstructorName { get; set; }

        [JsonIgnore]
        public string InstructorLastName { get; set; }

        [JsonProperty("instructorFullName")]
        public string InstructorFullName => InstructorName + " " + InstructorLastName;

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonProperty("strCreationDate")]
        public string StrCreationDate => CreationDate.ToString("dd/MM/yyyy");
    }
}