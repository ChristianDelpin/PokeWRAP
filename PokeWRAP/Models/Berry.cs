using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PokeWRAP.Models
{
    public class Berry
    {
        //                                 vvvvvvvv is necessary for reflection to work properly.
        internal static string ApiEndpoint { get; } = "berry";

        /// <summary>
        /// The unique identifier for the berry.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Name of the berry.  
        /// </summary> 
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Time it takes the tree to grow one stage, 
        /// in hours. Berry trees go through four of 
        /// these growth stages before they can be picked.
        /// </summary> 
        [JsonPropertyName("growth_time")]
        public int GrowthTime { get; set; }


        /// <summary>
        /// The maximum number of these berries that 
        /// can grow on one tree in Generation IV.
        /// </summary>
        [JsonPropertyName("max_harvest")]

        /// <summary>
        /// The power of the move "Natural Gift" when used with this Berry.
        /// </summary>
        public int MaxHarvest { get; set; }

        /// <summary>
        /// The power of the move "Natural Gift" when used with this Berry.
        /// </summary>

        [JsonPropertyName("natural_gift_power")]
        public int NaturalGiftPower { get; set; }


        /// <summary>
        /// The size of this Berry, in millimeters.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The smoothness of this Berry, used in making Pokéblocks or Poffins.
        /// </summary>
        public int Smoothness { get; set; }

        /// <summary>
        /// The speed at which this Berry dries out the soil as 
        /// it grows. A higher rate means the soil dries more quickly.
        /// </summary>
        [JsonPropertyName("soil_dryness")]
        public int SoilDryness { get; set; }

        /// <summary>
        /// The firmness of this berry, used in making Pokéblocks or Poffins.
        /// </summary>
        /// TODO: Need to implement BerryFirmness endpoint.
        public NamedAPIResource<BerryFirmness> Firmness { get; set; } = new NamedAPIResource<BerryFirmness>();

        /// <summary>
        /// A list of references to each flavor a berry can have and the potency of each of those flavors in regard to this berry.
        /// </summary>
        public List<BerryFlavorMap> Flavors { get; set; } = [];

        /// <summary>
        /// Berries are actually items. This is a reference to the item specific data for this berry.
        /// </summary>
        public NamedAPIResource<Item> Item { get; set; } = new NamedAPIResource<Item>();

        /// <summary>
        /// The type inherited by "Natural Gift" when used with this Berry.
        /// </summary>
        [JsonPropertyName("natural_gift_type")]
        public NamedAPIResource<Type> NaturalGiftType { get; set; } = new NamedAPIResource<Type>();
        public override string? ToString()
        {
            return $"ID: {Id}\n" +
                $"Name: {Name}\n" +
                $"Growth Time: {GrowthTime}\n" +
                $"Max Harvest: {MaxHarvest}\n" +
                $"Natural Gift Power: {NaturalGiftPower}\n" +
                $"Size: {Size}\n" +
                $"Smoothness: {Smoothness}\n" +
                $"Soil Dryness: {SoilDryness}\n" +
                $"Firmness: {Firmness}\n" + // TODO: Verify this works as intended. Maybe an override ToString() method in BerryFirmness?
                $"Flavors: {Flavors}\n" + // TODO: Verify this works as intended. Maybe an override ToString() method in BerryFlavorMap?
                $"Item: {Item}\n" + // TODO: Verify this works as intended. Maybe an override ToString() method in Item?
                $"Natural Gift Type: {NaturalGiftType}"; // TODO: Verify this works as intended. Maybe an override ToString() method in Type?
        }

    }
    /// <summary>
    /// Represents the flavor profile of a specific berry.
    /// Returned as part of a berry's data (e.g., from `/berry/{id}`).
    /// Direction: Berry → Flavors
    /// </summary>
    public class BerryFlavorMap
    {
        public int Potency { get; set; }
        public NamedAPIResource<BerryFlavor> Flavor { get; set; } = new NamedAPIResource<BerryFlavor>();
    }
    public class BerryFirmness : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "berry-firmness";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public List<NamedAPIResource<Berry>> Berries { get; set; } = [];
        public List<Name> Names { get; set; } = [];

    }
    public class BerryFlavor : NamedAPIResource
    {
        internal new static string ApiEndpoint { get; } = "berry-flavor";
        public override int Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public List<FlavorBerryMap> Berries { get; set; } = [];
        [JsonPropertyName("contest_type")]
        public NamedAPIResource<ContestType> ContestType { get; set; } = new NamedAPIResource<ContestType>();
        public List<Name> Names { get; set; } = [];
    }
    /// <summary>
    /// Represents how a specific berry contributes to a given flavor.
    /// Returned as part of a berry flavor's data (e.g., from `/berry-flavor/{id}`).
    /// Direction: Flavor → Berries
    /// </summary>
    public class FlavorBerryMap
    {
        public int Potency { get; set; }
        public NamedAPIResource<Berry> Berry { get; set; } = new NamedAPIResource<Berry>();
    }
}
