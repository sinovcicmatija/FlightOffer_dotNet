namespace FlightSearch.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GetAccessToken();
    }
}
