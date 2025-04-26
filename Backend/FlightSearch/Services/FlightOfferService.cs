using FlightSearch.Client;
using FlightSearch.Helpers;
using FlightSearch.Interfaces;
using FlightSearch.Models.Domain;
using FlightSearch.Models.DTOs;
using FlightSearch.Models.External;

namespace FlightSearch.Services
{
    public class FlightOfferService : IFlightOfferService
    {
        private readonly AmadeusClient _client;
        private readonly ITokenService _tokenService;
        private readonly IRedisCacheService _redisCacheService;
        private readonly ILogger<FlightOfferService> _logger;

        public FlightOfferService(ILogger<FlightOfferService> logger, AmadeusClient client, ITokenService tokenService, IRedisCacheService redisCacheService)
        {
            _client = client;
            _tokenService = tokenService;
            _redisCacheService = redisCacheService;
            _logger = logger;
        }
        public async Task<List<FlightOfferDTO>> GetFlightOffer(FlightOfferCallDTO callModelDTO)
        {
            string token = await _tokenService.GetAccessToken();
            string hashKey = CacheKeyGenerator.GenerateHashKey(callModelDTO);
            var cachedOffers = await _redisCacheService.GetAsync<List<FlightOfferDTO>>(hashKey);
            if(cachedOffers != null)
            {
                _logger.LogInformation($"Vraćam {cachedOffers.Count} keširanih ponuda za hash ključ: {hashKey}");
                return cachedOffers;
            }

            _logger.LogInformation($"traze se novi podaci, saljem zahtjev");

            FlightOfferCallModel model = FlightOfferCallMapper.MapToFlightOfferCallModel(callModelDTO);
            FlightOfferResponse? response = await _client.GetFlightOffer(token, model);
            if(response == null || response.Data == null || response.Data.Length == 0)
            {
                return new List<FlightOfferDTO>();
            }
            List<FlightOfferDTO> offerDTOs = FlightOfferMapper.ToDTO(response);
            await _redisCacheService.SetAsync(hashKey, offerDTOs, TimeSpan.FromMinutes(10));

            return offerDTOs;
        }
    }
}
