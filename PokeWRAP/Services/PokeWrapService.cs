using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeWRAP.Services
{
    public class PokeWrapService
    {

        private readonly PokeWrapClient _client;
        public PokeWrapService() 
        {
            _client = new PokeWrapClient();
        }
        public async Task<T> GetAbilityAsync<T>()
        {
            return await _client.GetAbilityAsync<T>();
        }
        public async Task<T> GetBerryAsync<T>()
        {
            return await _client.GetBerryAsync<T>();
        }


        // Copy of what I attempted to do in Finbot.
        /*
          public async Task<Result<T>> TryGetAsync<T>(string endpoint) where T : NamedApiResource, new()
        {
            try
            {
                var resource = await _pokeClient.GetResourceAsync<T>(endpoint);
                return new Result<T>()
                {
                   IsSuccessful = true,
                   Data = resource
                };
            }
            catch (HttpRequestException e)
            {
                return new Result<T>()
                {
                    IsSuccessful = false,
                    ErrorMessage = $"HTTP Request failed: {e.Message}"
                };
            }
            catch (Exception e)
            {
                return new Result<T>()
                {
                    IsSuccessful = false,
                    ErrorMessage = $"An error occurred: {e.Message}"
                };
            }
        }
        */
    }
}
