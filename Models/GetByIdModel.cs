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

    [JsonPropertyName("ean")]
    public string Ean { get; set; } = "";

    [JsonPropertyName("url")]
    public string Url { get; set; } = "";

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = "";

    [JsonPropertyName("ingredients")]
    public string Ingredients { get; set; } = "";


    [JsonPropertyName("current_price")]
    public double CurrentPrice { get; set; }

    [JsonPropertyName("store")]
    public StoreInfo Store { get; set; } = new StoreInfo();

    [JsonPropertyName("price_history")]
    public List<PriceHistory>? PriceHistory { get; set; }

    [JsonPropertyName("allergens")]
    public List<Allergens>? Allergens { get; set; }


}


public class StoreInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("code")]
    public string Code { get; set; } = "";

    [JsonPropertyName("url")]
    public string Url { get; set; } = "";

    [JsonPropertyName("logo")]
    public string Logo { get; set; } = "";

}

public class PriceHistory
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }
}

public class Allergens
{
    [JsonPropertyName("code")]
    public string Code { get; set; } = "";

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = "";

    [JsonPropertyName("contains")]
    public string Contains { get; set; } = "";
}