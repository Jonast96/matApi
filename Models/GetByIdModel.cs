using System.Text.Json.Serialization;
namespace foodApp.Models;

public class ProductData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("brand")]
    public string Brand { get; set; } = "";

    [JsonPropertyName("vendor")]
    public string Vendor { get; set; } = "";
}


