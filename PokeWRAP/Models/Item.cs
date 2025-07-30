using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeWRAP.Models
{
    public class Item : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "item";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public int Cost { get; set; }
        [JsonPropertyName("fling_power")]
        public int FlingPower { get; set; }
        [JsonPropertyName("fling_effect")]
        public NamedAPIResource<FlingEffect> FlingEffect { get; set; } = new NamedAPIResource<FlingEffect>();
        public List<NamedAPIResource<ItemAttribute>> Attributes { get; set; } = [];
        public NamedAPIResource<ItemCategory> Category { get; set; } = new NamedAPIResource<ItemCategory>();
        [JsonPropertyName("effect_entries")]
        public List<VerboseEffect> EffectEntries { get; set; } = [];
        [JsonPropertyName("flavor_text_entries")]
        public List<VersionGroupFlavorText> FlavorTextEntries { get; set; } = [];
        [JsonPropertyName("game_indices")]
        public List<GenerationGameIndex> GameIndices { get; set; } = [];
        public List<Name> Names { get; set; } = [];
        public ItemSprites Sprites { get; set; }
        [JsonPropertyName("held_by_pokemon")]
        public List<ItemHolderPokemon> HeldByPokemon { get; set; } = [];
        [JsonPropertyName("baby_trigger_for")]
        public APIResource<EvolutionChain> BabyTriggerFor { get; set; } = new APIResource<EvolutionChain>();
        public List<MachineVersionDetail> Machines { get; set; } = [];
    }
    public class ItemSprites
    {
        public string Default { get; set; } = string.Empty;
    }
    public class ItemHolderPokemon
    {
        public NamedAPIResource<Pokemon> Pokemon { get; set; } = new NamedAPIResource<Pokemon>();
        public List<ItemHolderPokemonVersionDetail> VersionDetails { get; set; } = [];
    }
    public class ItemHolderPokemonVersionDetail
    {
        public int Rarity { get; set; }
        public NamedAPIResource<Version> Version { get; set; } = new NamedAPIResource<Version>();
    }
    public class ItemAttribute : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "item-attribute";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public List<NamedAPIResource<Item>> Items { get; set; } = [];
        public List<Name> Names = [];
        public List<Description> Descriptions { get; set; } = [];
    }
    public class ItemCategory : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "item-category";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public List<NamedAPIResource<Item>> Items { get; set; } = [];
        public List<Name> Names { get; set; } = [];
        public NamedAPIResource<ItemPocket> Pocket { get; set; } = new NamedAPIResource<ItemPocket>();
    }
    public class ItemFlingEffect : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "item-fling-effect";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public List<Effect> Effects { get; set; } = [];
        public List<NamedAPIResource<Item>> Items { get; set; } = [];
    }
    public class ItemPocket : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "item-pocket";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public List<NamedAPIResource<ItemCategory>> Categories { get; set; } = [];
        public List<Name> Names { get; set; } = [];

    }
}
