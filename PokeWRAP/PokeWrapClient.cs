using PokeWRAP.Models;
using System.Reflection;
using System.Text.Json;

namespace PokeWRAP
{
    public class PokeWrapClient
    {
        private readonly Uri _baseUrl= new Uri("https://pokeapi.co/api/v2/");
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public PokeWrapClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = _baseUrl
            };
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }


        //TODO: Add tooltip summary.
        // Generic method to allow getting resources by type. Allows for easy scalability.
        internal async Task<T?> GetResourceAsync<T>(string? nameOrId)where T : class
        {
            var endpoint = GetApiEndpoint<T>();
            var requestUri = $"{endpoint}/{nameOrId}";

            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync(); // Read the response content as a string so the next line can deserialize it neatly.
            return JsonSerializer.Deserialize<T>(jsonResponse, _jsonOptions);
        }

        //TODO: Add tooltip summary.
        // Generic method to allow getting resources by type. Since one model can have multiple endpoints, this allows for easy scalability.
        private static string GetApiEndpoint<T>()
        {
            // This allows me to use reflection to easily get the API endpoint from the model class.
            PropertyInfo? endpoint = typeof(T).GetProperty("ApiEndpoint", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (endpoint == null)
            {
                throw new InvalidOperationException($"Type {typeof(T).Name} does not have a static property 'ApiEndpoint'.");
            }
            var value = endpoint.GetValue(null)?.ToString();
            if (value == null)
            {
                throw new InvalidOperationException($"Type {typeof(T).Name} has a null 'ApiEndpoint'.");
            }
            return value;
        }
    }
}
