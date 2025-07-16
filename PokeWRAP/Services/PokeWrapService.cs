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
    }
}
