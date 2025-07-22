namespace PokeWRAP
{
    public class PokeWrapClient
    {
        private readonly Uri _baseUrl= new Uri("https://pokeapi.co/api/v2/");

        private readonly HttpClient _httpClient;

        public PokeWrapClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = _baseUrl
            };
        }
        public async Task<T> GetAbilityAsync<T>()
        {
            return await GetAsync<T>("ability");
        }

        public async Task<T> GetBerryAsync<T>()
        {
            return await GetAsync<T>("berry");
        }

        // Add more endpoints as development progresses.


        private async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{endpoint}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<T>(content);
            }
            else
            {
                throw new HttpRequestException($"Request to {endpoint} failed with status code {response.StatusCode}");
            }
        }
    }
}
