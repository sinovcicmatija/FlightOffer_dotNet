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
        private readonly ITokenService _tokenService;

        public AirportService(AmadeusClient client, ITokenService tokenService)
        {
            _client = client;
            _tokenService = tokenService;
        }
        public async Task<List<AirportDTO>> GetAirport(string keyword)
        {
            string token = await _tokenService.GetAccessToken();

            LocationResponse response = await _client.GetLocationAirport(token, keyword);

            return AirportMapper.toDTO(response);
        }
    }
}
