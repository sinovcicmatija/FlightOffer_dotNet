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

        public FlightOfferService(AmadeusClient client, ITokenService tokenService)
        {
            _client = client;
            _tokenService = tokenService;
        }
        public async Task<List<FlightOfferDTO>> GetFlightOffer(FlightOfferCallDTO callModelDTO)
        {
            string token = await _tokenService.GetAccessToken();

            FlightOfferCallModel model = FlightOfferCallMapper.MapToFlightOfferCallModel(callModelDTO);

            FlightOfferResponse response = await _client.GetFlightOffer(token, model);

            return FlightOfferMapper.toDTO(response);
        }
    }
}
