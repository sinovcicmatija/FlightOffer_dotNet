namespace FlightSearch.Interfaces
{
    public interface IRedisCacheService
    {
        Task SetAsync<T>(string key, T value, TimeSpan expirationTime);
        Task<T?> GetAsync<T>(string key);
    }
}
