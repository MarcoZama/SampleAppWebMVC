using System.Text.Json.Serialization;

namespace SampleAppWeb.Uow.Models
{
    public class TouristAddRequest
    {
    

        [JsonPropertyName("tourist_name")]
        public string TouristName { get; set; }

        [JsonPropertyName("tourist_email")]
        public string TouristEmail { get; set; }

        [JsonPropertyName("tourist_location")]
        public string TouristLocation { get; set; }

       
    }
}
