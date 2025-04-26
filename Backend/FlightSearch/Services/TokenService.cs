using FlightSearch.Client;
using FlightSearch.Interfaces;
using FlightSearch.Models.Domain;

namespace FlightSearch.Services
{
    public class TokenService : ITokenService
    {
        private readonly AmadeusClient _client;
        private readonly IRedisCacheService _redisCacheService;
        private readonly ILogger<TokenService> _logger;

        public TokenService(ILogger<TokenService> logger, AmadeusClient client, IRedisCacheService redisCacheService)
        {
            _client = client;
            _redisCacheService = redisCacheService;
            _logger = logger;
        }


        public  async Task<string> GetAccessToken()
        {
            var cachedToken = await _redisCacheService.GetAsync<string>("access_token");

            if (cachedToken != null)
            {
                _logger.LogInformation($"[Redis]Cached token: {cachedToken}");
                return cachedToken;

            }
            _logger.LogInformation("[Redis] Token nije pronađen u cache-u. Dohvaćam novi preko Amadeus API-ja...");

            TokenResponse tokenResponse = await _client.GetToken();
            if (tokenResponse == null)
            {
                throw new InvalidOperationException("Token response was null!");
            }
            
                await _redisCacheService.SetAsync("access_token", tokenResponse.AccessToken, TimeSpan.FromSeconds(tokenResponse.ExpiresIn));
                return tokenResponse.AccessToken;
            
        }
    }
}
