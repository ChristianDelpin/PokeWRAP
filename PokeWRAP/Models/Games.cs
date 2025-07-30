using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeWRAP.Models
{
    public class Gerneration : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "generation";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public List<NamedAPIResource<Ability>> Abilities { get; set; } = [];
        public List<Name> Names { get; set; } = [];
        [JsonPropertyName("main_region")]
        public NamedAPIResource<Region> MainRegion { get; set; } = new NamedAPIResource<Region>();
        public List<NamedAPIResource<Move>> Moves { get; set; }
        [JsonPropertyName("pokemon_species")]
        public List<NamedAPIResource<PokemonSpecies>> PokemonSpecies { get; set; } = [];
        public List<NamedAPIResource<Type>> Types { get; set; } = [];
        [JsonPropertyName("version_groups")]
        public List<NamedAPIResource<VersionGroup>> VersionGroups { get; set; } = [];

    }
    public class Pokedex : NamedAPIResource
    {
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        [JsonPropertyName("is_main_series")]
        public bool IsMainSeries { get; set; }
        public List<Description> Descriptions { get; set; } = [];
        public List<Name> Names { get; set; } = [];
        [JsonPropertyName("pokemon_entries")]
        public List<PokemonEntry> PokemonEntries { get; set; } = [];
        public NamedAPIResource<Region> Region { get; set; } = new NamedAPIResource<Region>();
        [JsonPropertyName("version_groups")]
        public List<NamedAPIResource<VersionGroup>> VersionGroups { get; set; } = [];
    }
    public class PokemonEntry
    {
        [JsonPropertyName("entry_number")]
        public int EntryNumber { get; set; }
        public NamedAPIResource<PokemonSpecies> PokemonSpecies { get; set; } = new NamedAPIResource<PokemonSpecies>();
    }
    public class Version : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "version";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public List<Name> Names { get; set; } = [];
        [JsonPropertyName("version_group")]
        public NamedAPIResource<VersionGroup> VersionGroup { get; set; } = new NamedAPIResource<VersionGroup>();
    }
    public class VersionGroup : NamedAPIResource
    {
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public NamedAPIResource<Generation> Generation { get; set; } = new NamedAPIResource<GenerationGameIndex>();
        [JsonPropertyName("move_learn_methods")]
        public List<NamedAPIResource<MoveLearnMethod>> MoveLearnMethods { get; set; } = [];
        public List<NamedAPIResource<Pokedex>> Pokedexes { get; set; } = [];
        public List<NamedAPIResource<Region>> Regions { get; set; } = [];
        public List<NamedAPIResource<Version>> Versions { get; set; } = [];
    }

}