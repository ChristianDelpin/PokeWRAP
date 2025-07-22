using System;
using System.Collections.Generic;
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
        public string Name { get; set; }

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
        public string Firmness { get; set; }

        /// <summary>
        /// A list of references to each flavor a berry can have and the potency of each of those flavors in regard to this berry.
        /// </summary>
        public List<string> Flavors { get; set; } = new List<string>();

        /// <summary>
        /// Berries are actually items. This is a reference to the item specific data for this berry.
        /// </summary>
        public int Item { get; set; }

        /// <summary>
        /// The type inherited by "Natural Gift" when used with this Berry.
        /// </summary>
        [JsonPropertyName("natural_gift_type")]
        public List<string> NaturalGiftType { get; set; } = new List<string>();

        public override string? ToString()
        {
            return $"ID: {Id}\n" +
                $"Name: {Name}\n" +
                $"Growth Time: {GrowthTime}" +
                $"Max Harvest: {MaxHarvest}\n" +
                $"Natural Gift Power: {NaturalGiftPower}\n" +
                $"Size: {Size}\n" +
                $"Smoothness: {Smoothness}\n" +
                $"Soil Dryness: {SoilDryness}\n" +
                $"Firmness: {Firmness}\n" +
                $"Flavors: {string.Join(", ", Flavors)}\n" +
                $"Item: {Item}\n" +
                $"Natural Gift Type: {string.Join(", ", NaturalGiftType)}";
        }
    }
}
