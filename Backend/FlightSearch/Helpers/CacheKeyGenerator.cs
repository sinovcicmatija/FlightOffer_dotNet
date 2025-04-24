using FlightSearch.Models.DTOs;
using System.Text.Json;
using System.Text;
using System.Security.Cryptography;

namespace FlightSearch.Helpers
{
    public static class CacheKeyGenerator
    {

        public static string GenerateHashKey(FlightOfferCallDTO dto)
        {
            try
            {
                var json = JsonSerializer.Serialize(dto);
                using var sha256 = SHA256.Create();
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(json));
                return Convert.ToBase64String(hashBytes)
                              .Replace("+", "-")
                              .Replace("/", "_")
                              .Replace("=", "");
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to generate hash key from DTO", ex);
            }
        }
    }
}
