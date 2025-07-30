using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeWRAP.Models
{
    public class ContestType : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "contest-type";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public NamedAPIResource<BerryFlavor> BerryFlavor { get; set; } = new NamedAPIResource<BerryFlavor>();
        public List<ContestName> Names { get; set; } = [];
    }
    public class ContestName
    {
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public NamedAPIResource<Language> Language { get; set; } = new NamedAPIResource<Language>();

    }
    public class ContestEffect : APIResource
    {
        internal static string ApiEndpoint { get; } = "contest-effect";
        public int Id { get; set; }
        public int Appeal { get; set; }
        public int Jam { get; set; }
        [JsonPropertyName("effect_entries")]
        public List<Effect> EffectEntries { get; set; } = [];
        [JsonPropertyName("flavor_text_entries")]
        public List<FlavorText> FlavorTextEntries { get; set; } = [];
    }
    public class SuperContestEffect : APIResource
    {
        internal static string ApiEndpoint { get; } = "super-contest-effect";
        public int Id { get; set; }
        public int Appeal { get; set; }
        [JsonPropertyName("flavor_text_entries")]
        public List<FlavorText> FlavorTextEntries { get; set; } = [];
        public List<NamedAPIResource<Move>> Moves { get; set; } = [];
    }
}
