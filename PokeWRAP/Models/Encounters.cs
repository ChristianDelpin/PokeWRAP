using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeWRAP.Models
{
    public class EncounterMethod : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "encounter-method";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public List<Name> Names { get; set; } = new List<Name>();
    }
    public class EncounterCondition : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "encounter-condition";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public List<Name> Names { get; set; } = [];
        public List<NamedAPIResource<EncounterConditionValue>> Values { get; set; } = [];
    }
    public class EncounterConditionValue : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "encounter-condition-value";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public NamedAPIResource<EncounterCondition> Condition { get; set; } = new NamedAPIResource<EncounterCondition>();
        public List<Name> Names { get; set; } = new List<Name>();
    }
}
