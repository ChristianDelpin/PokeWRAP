using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeWRAP.Models
{
    public class Location : NamedAPIResource
    {
        internal static string ApiResource { get; } = "location";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public NamedAPIResource<Region> Region { get; set; } = new NamedAPIResource<Region>();
        public List<Name> Names { get; set; } = [];
        [JsonPropertyName("game_indices")]
        public List<GenerationGameIndex> GameIndices { get; set; } = [];
        public List<NamedAPIResource<LocationArea>> Areas { get; set; } = [];
    }
    public class LocationArea : NamedAPIResource
    { 
        internal static string ApiResource { get; } = "location-area";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        [JsonPropertyName("game_index")]
        public int GameIndex { get; set; }
        [JsonPropertyName("encounter_method_rates")]
        public List<EncounterMethodRate> EncounterMethodRates { get; set; } = [];
        public NamedAPIResource<Location> Location { get; set; } = new NamedAPIResource<Location>();
        public List<Name> Names { get; set; } = [];
        [JsonPropertyName("pokemon_encounters")]
        public List<PokemonEncounter> PokemonEncounters { get; set; } = [];
    }

    public class EncounterMethodRate
    {
        // TODO: Continue from here: https://pokeapi.co/docs/v2#location-areas
    }
}
