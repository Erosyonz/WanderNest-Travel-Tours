using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyBlazorFrontend.Models;

public class Destination
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("country")]
    public string Country { get; set; } = "Philippines";

    [JsonPropertyName("region")]
    public string Region { get; set; } = "Cordova, Cebu";

    [JsonPropertyName("description")]
    public string Description { get; set; } = "";

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; } = "";

    [JsonPropertyName("starting_price")]
    public decimal StartingPrice { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("duration")]
    public string Duration { get; set; } = "";

    [JsonPropertyName("category")]
    public string Category { get; set; } = "";

    [JsonPropertyName("highlights")]
    public List<string> Highlights { get; set; } = new();

    [JsonPropertyName("travel_tips")]
    public string TravelTips { get; set; } = "";
}