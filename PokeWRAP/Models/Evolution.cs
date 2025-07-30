using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeWRAP.Models
{
    public class EvolutionChain : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "evolution-chain";
        public override int Id { get; set; }
        [JsonPropertyName("baby_trigger_item")]
        public NamedAPIResource<Item> BabyTriggerItem { get; set; } = new NamedAPIResource<Item>();
        public ChainLink chain { get; set; }
    }
    public class ChainLink
    {
        [JsonPropertyName("is_baby")]
        public bool IsBaby { get; set; }
        public NamedAPIResource<PokemonSpecies> Species { get; set; } = new NamedAPIResource<PokemonSpecies>();
        
        public List<EvolutionDetail> EvolutionDetails { get; set; } = new List<EvolutionDetail>();
        public List<ChainLink> EvolvesTo { get; set; }
    }
    public class EvolutionDetail
    {
        public NamedAPIResource<Item> Item { get; set; } = new NamedAPIResource<Item>();
        public NamedAPIResource<EvolutionTrigger> Trigger { get; set; } = new NamedAPIResource<EvolutionTrigger>();
        public int Gender { get; set; }
        [JsonPropertyName("held_item")]
        public NamedAPIResource<Item> HeldItem { get; set; } = new NamedAPIResource<Item>();
        [JsonPropertyName("known_move")]
        public NamedAPIResource<Moves> KnownMove { get; set; } = new NamedAPIResource<Moves>();
        [JsonPropertyName("known_move_type")]
        public NamedAPIResource<Type> KnownMoveType { get; set; } = new NamedAPIResource<Type>();
        public NamedAPIResource<Location> Location { get; set; }
        [JsonPropertyName("min_level")]
        public int MinLevel { get; set; }
        [JsonPropertyName("min_happiness")]
        public int MinHappiness { get; set; }
        [JsonPropertyName("min_beauty")]
        public int MinBeauty { get; set; }
        [JsonPropertyName("min_affection")]
        public int MinAffection { get; set; }
        [JsonPropertyName("needs_overworld_rain")]
        public bool NeedsOverWorldRain { get; set; }
        [JsonPropertyName("party_species")]
        public NamedAPIResource<PokemonSpecies> PartySpecies { get; set; } = new NamedAPIResource<PokemonSpecies>();
        [JsonPropertyName("party_type")]
        public NamedAPIResource<Type> PartyType { get; set; } = new NamedAPIResource<Type>();
        [JsonPropertyName("relative_physical_stats")]
        public int RelativePhysicalStats { get; set; }
        [JsonPropertyName("time_of_day")]
        public string TimeOfDay { get; set; } = string.Empty;
        [JsonPropertyName("trade_species")]
        public NamedAPIResource<PokemonSpecies> TradeSpecies { get; set; } = new NamedAPIResource<PokemonSpecies>();
        [JsonPropertyName("turn_upside_down")]
        public bool TurnUpsideDown { get; set; }
    }
    public class EvolutionTrigger : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "evolution-trigger";
        public override int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Name> Names { get; set; }
        [JsonPropertyName("pokemon_species")]
        public NamedAPIResource<PokemonSpecies> PokemonSpecies { get; set; } = new NamedAPIResource<PokemonSpecies>();
    }

}
