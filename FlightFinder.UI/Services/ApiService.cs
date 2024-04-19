using Microsoft.AspNetCore.WebUtilities;

namespace FlightFinder.UI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCount(string input)
        {
            return await _httpClient.GetStringAsync(QueryHelpers.AddQueryString("", "input", input));
        }
    }
}
