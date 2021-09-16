using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProGamer.BackEnd.Models.Response
{
    public class HomeResponse
    {
        public HomeResponse() 
        {
            ListGame = new List<GameCardResponse>();
            ListCourseRecent = new List<CourseCardResponse>();
            listCourseRecommended = new List<CourseCardResponse>();
        }

        [JsonProperty("listGame")]
        public List<GameCardResponse> ListGame { get; set; }

        [JsonProperty("listCourseRecommended")]
        public List<CourseCardResponse> listCourseRecommended { get; set; }


        [JsonProperty("listCourseRecent")]
        public List<CourseCardResponse> ListCourseRecent { get; set; }
    }
}