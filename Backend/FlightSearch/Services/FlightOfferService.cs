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

        public FlightOfferService(AmadeusClient client)
        {
            _client = client;
        }
        public async Task<List<FlightOfferDTO>> GetFlightOffer(FlightOfferCallModel callModel)
        {
            TokenResponse tokenResponse = await _client.GetToken();
            string token = tokenResponse.AccessToken;

            FlightOfferResponse response = await _client.GetFlightOffer(token, callModel);

            return FlightOfferMapper.toDTO(response);
        }
    }
}
