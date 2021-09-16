using Newtonsoft.Json;

namespace ProGamer.BackEnd.Models.Response
{
    public class CourseCardResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("instructorName")]
        public string InstructorName { get; set; }
         
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}