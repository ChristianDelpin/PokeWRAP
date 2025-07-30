using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeWRAP.Models
{
    public abstract class ResourceBase
    {
        public abstract int Id { get; set; }
        public static string ApiEndpoint { get; } = string.Empty;
    }
    public abstract class NamedAPIResource : ResourceBase
    {
        public string Name { get; set; } = string.Empty;
    }
}
    
    
