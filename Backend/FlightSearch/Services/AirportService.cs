using FlightSearch.Client;
using FlightSearch.Helpers;
using FlightSearch.Interfaces;
using FlightSearch.Models.Domain;
using FlightSearch.Models.DTOs;

namespace FlightSearch.Services
{
    public class AirportService : IAirportService
    {
        private readonly AmadeusClient _client;

        public AirportService(AmadeusClient client)
        {
            _client = client;
        }
        public async Task<List<AirportDTO>> GetAirport(string keyword)
        {
            TokenResponse tokenResponse = await _client.GetToken();
            string token = tokenResponse.AccessToken;

            LocationResponse response = await _client.GetLocationAirport(token, keyword);

            return AirportMapper.toDTO(response);
        }
    }
}
