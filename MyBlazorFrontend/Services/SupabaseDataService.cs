
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using MyBlazorFrontend.Models;

namespace MyBlazorFrontend.Services;

public class SupabaseDataService
{
    private readonly HttpClient _http;

    // JSON settings for Supabase snake_case columns
    private static readonly JsonSerializerOptions JsonOptions =
        new(JsonSerializerDefaults.Web)
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

    public SupabaseDataService(HttpClient http)
    {
        _http = http;
    }

    // =====================================
    // GET DESTINATIONS
    // =====================================

    public async Task<List<Destination>> GetDestinationsAsync()
    {
        var result = await _http.GetFromJsonAsync<List<Destination>>(
            "destinations?select=*&order=id.asc",
            JsonOptions
        );

        return result ?? new List<Destination>();
    }

    // =====================================
    // GET TOUR PACKAGES
    // =====================================

    public async Task<List<TourPackage>> GetTourPackagesAsync()
    {
        var result = await _http.GetFromJsonAsync<List<TourPackage>>(
            "tour_packages?select=*&order=id.asc",
            JsonOptions
        );

        return result ?? new List<TourPackage>();
    }

    // =====================================
    // INSERT BOOKING
    // =====================================

    public async Task SubmitBookingAsync(BookingRequest booking)
    {
        var payload = new
        {
            full_name = booking.FullName,
            email = booking.Email,
            travel_date = booking.TravelDate?.ToString("yyyy-MM-dd"),
            travelers = booking.Travelers,
            requests = booking.Requests
        };

        var response = await _http.PostAsJsonAsync(
            "booking_requests",
            payload
        );

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();

            throw new HttpRequestException(
                $"Booking submission failed: {error}"
            );
        }
    }

    // =====================================
    // INSERT CONTACT MESSAGE
    // =====================================

    public async Task SubmitContactMessageAsync(ContactMessage message)
    {
        var payload = new
        {
            name = message.Name,
            email = message.Email,
            phone = message.Phone,
            destination = message.Destination,
            preferred_date = message.PreferredDate?.ToString("yyyy-MM-dd"),
            travelers = message.Travelers,
            budget = message.Budget,
            inquiry_type = message.InquiryType,
            message = message.Message
        };

        var response = await _http.PostAsJsonAsync(
            "contact_messages",
            payload
        );

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();

            throw new HttpRequestException(
                $"Contact submission failed: {error}"
            );
        }
    }
}
