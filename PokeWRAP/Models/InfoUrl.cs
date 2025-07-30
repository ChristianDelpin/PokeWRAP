using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeWRAP.Models
{
    public abstract class InfoUrl<T> where T : ResourceBase
    {
        public string Url { get; set; } = string.Empty;
    }
}
