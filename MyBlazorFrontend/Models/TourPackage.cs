using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyBlazorFrontend.Models;

public class TourPackage
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("destination_id")]
    public int DestinationId { get; set; }

    [JsonPropertyName("destination_name")]
    public string DestinationName { get; set; } = "";

    [JsonPropertyName("description")]
    public string Description { get; set; } = "";

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; } = "";

    [JsonPropertyName("duration_days")]
    public int DurationDays { get; set; }

    [JsonPropertyName("price_per_person")]
    public decimal PricePerPerson { get; set; }

    [JsonPropertyName("included_services")]
    public List<string> IncludedServices { get; set; } = new();

    [JsonPropertyName("excluded_services")]
    public List<string> ExcludedServices { get; set; } = new();

    [JsonPropertyName("itinerary_highlights")]
    public List<string> ItineraryHighlights { get; set; } = new();

    [JsonPropertyName("category")]
    public string Category { get; set; } = "";
}