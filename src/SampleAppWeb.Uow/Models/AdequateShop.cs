using System.Text.Json.Serialization;

namespace SampleAppWeb.Uow.Models
{
    public class AdequateShop
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("totalrecord")]
        public int Totalrecord { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("data")]
        public List<Tourist> Data { get; set; }
    }
}
