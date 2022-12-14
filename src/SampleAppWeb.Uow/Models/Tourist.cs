using System.Text.Json.Serialization;

namespace SampleAppWeb.Uow.Models
{
    public class Tourist
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("tourist_name")]
        public string TouristName { get; set; }

        [JsonPropertyName("tourist_email")]
        public string TouristEmail { get; set; }

        [JsonPropertyName("tourist_location")]
        public string TouristLocation { get; set; }

        [JsonPropertyName("createdat")]
        public DateTime Createdat { get; set; }
    }
}
