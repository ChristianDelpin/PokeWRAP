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

        /// <summary>
        /// Used to fetch data.
        /// </summary>
        /// <typeparam name="T">Specify which model to use</typeparam>
        /// <param name="idOrName">Optional. Used to specify what you want to look up. Null will return a full list of the specified model</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Thrown if either `T` or `idOrName` are invalid.</exception>
        public async Task<T> GetResourceAsync<T>(string? idOrName) where T : class
        {
            var result = await _client.GetResourceAsync<T>(idOrName);
            if (result is null)
                throw new InvalidOperationException($"Resource of type {typeof(T).Name} with identifier '{idOrName}' was not found.");
            return result;
        }
    }
}
