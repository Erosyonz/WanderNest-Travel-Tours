
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazorFrontend;
using MyBlazorFrontend.Components;
using MyBlazorFrontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Supabase configuration
var supabaseUrl = builder.Configuration["Supabase:Url"]
    ?? throw new InvalidOperationException("Supabase URL is missing.");

var supabaseKey = builder.Configuration["Supabase:PublishableKey"]
    ?? throw new InvalidOperationException("Supabase Publishable Key is missing.");

// HTTP client for Supabase
builder.Services.AddScoped(sp =>
{
    var client = new HttpClient
    {
        BaseAddress = new Uri(
            $"{supabaseUrl.TrimEnd('/')}/rest/v1/"
        )
    };

    client.DefaultRequestHeaders.Add("apikey", supabaseKey);

    return client;
});

// Register services used by the pages
builder.Services.AddScoped<SupabaseDataService>();
builder.Services.AddScoped<TourService>();

await builder.Build().RunAsync();
