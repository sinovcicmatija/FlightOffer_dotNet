using FlightSearch.Models.Domain;
using FlightSearch.Models.External;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlightSearch.Client
{
    public class AmadeusClient
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiSecret;
        private readonly string? _tokenUrl;
        private readonly string _locationUrl;
        private readonly string? _flightOfferUrl;

        public AmadeusClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["AMADEUS_API_KEY"]
                ?? throw new InvalidOperationException("API ključ nije postavljen");
            _apiSecret = configuration["AMADEUS_API_SECRET"]
                ?? throw new InvalidOperationException("API tajni ključ nije postavljen");

            _tokenUrl = configuration.GetValue<string>("AmadeusApi:AmadeusApiTokenUrl");
            _locationUrl = configuration.GetValue<string>("AmadeusApi:AmadeusApiLocationUrl")
                ?? throw new InvalidOperationException("Location URL nije postavljen");
            _flightOfferUrl = configuration.GetValue<string>("AmadeusApi:AmadeusApiFlightOffersUrl");
        }

        public async Task<TokenResponse?> GetToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _tokenUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var formData = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", _apiKey },
                { "client_secret", _apiSecret }
            };
            request.Content = new FormUrlEncodedContent(formData);
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TokenResponse>(content);
        }

        public async Task<LocationResponse?> GetLocationAirport(string token, string keyword)
        {
            var queryParams = new Dictionary<string, string?>
            {
                { "subType", "CITY,AIRPORT" },
                { "keyword", keyword }
            };

            var fullUrl = QueryHelpers.AddQueryString(_locationUrl, queryParams);

            var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.amadeus+json");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LocationResponse>(content);
        }

        public async Task<FlightOfferResponse?> GetFlightOffer(string token, FlightOfferCallModel flightOfferCallModel)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _flightOfferUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.amadeus+json");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = JsonContent.Create(flightOfferCallModel);

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<FlightOfferResponse>(content);
        }
    }
}
