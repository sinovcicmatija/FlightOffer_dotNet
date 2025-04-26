using System;
using System.Reflection.Metadata;
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
        private readonly IRedisCacheService _redisCacheService;
        private readonly ILogger<AirportService> _logger;

        public AirportService(ILogger<AirportService> logger, AmadeusClient client, ITokenService tokenService, IRedisCacheService redisCacheService)
        {
            _client = client;
            _tokenService = tokenService;
            _redisCacheService = redisCacheService;
            _logger = logger;
        }
        public async Task<List<AirportDTO>> GetAirport(string keyword)
        {
            string token = await _tokenService.GetAccessToken();
            string normalizedKey = $"airports:{keyword.Trim().ToLower()}";
            var cachedAirports = await _redisCacheService.GetAsync<List<AirportDTO>>(normalizedKey);

            if(cachedAirports != null)
            {
                _logger.LogInformation($"Vraćam keshirane aerodrome za: {keyword}");
                return cachedAirports;
            }

            _logger.LogInformation($"traze se novi podaci, saljem zahtjev");

            LocationResponse? response = await _client.GetLocationAirport(token, keyword);
            if (response == null || response.Data == null)
            {
                return new List<AirportDTO>();
            }
            List<AirportDTO> airportDTOs = AirportMapper.ToDTO(response);
            await _redisCacheService.SetAsync(normalizedKey, airportDTOs, TimeSpan.FromMinutes(10));

            return airportDTOs;
        }
    }
}
