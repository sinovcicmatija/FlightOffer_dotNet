using System.Text.Json;
using FlightSearch.Interfaces;
using StackExchange.Redis;

namespace FlightSearch.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase _cache;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
        }
        public async Task<T?> GetAsync<T>(string key)
        {
            var jsonData = await _cache.StringGetAsync(key);
            return jsonData.HasValue ? JsonSerializer.Deserialize<T>(jsonData!) : default;
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expirationTime)
        {
            var jsonData = JsonSerializer.Serialize(value);
            await _cache.StringSetAsync(key, jsonData, expirationTime);
        }
    }
}
