using Newtonsoft.Json;

namespace ProGamer.BackEnd.Models.Response
{
    public class GameCardResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }
}