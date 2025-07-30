using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeWRAP.Models
{
    
    public class APIResource<T> : InfoUrl<T> where T : ResourceBase { }
    public class Description
    { 
        public string description { get; set; }
        public NamedAPIResource Language { get; set; } 
    }
    public class Effect
    { 
        public string effect { get; set; }
        public NamedAPIResource<Language> Language { get; set; }
    }
    public class Encounter
    { 
        public int minLevel { get; set; }
        public int maxLevel { get; set; }
        public NamedAPIResource<EncounterConditionValue> ConditionValues { get; set; }
        public int chance { get; set; }
        public NamedAPIResource<EncounterMethod> Method { get; set; }
    }
    public class FlavorText
    { 
        public string flavorText { get; set; }
        public NamedAPIResource<Language> Language { get; set; }
        public NamedAPIResource<Version> Version { get; set; }
    }
    public class GenerationGameIndex
    { 
        public int gameIndex { get; set; }
        public NamedAPIResource<Generation> Generation { get; set; }
    }
    public class MachineVersionDetail
    { 
        public APIResource<Machine> Machine { get; set; }
        public NamedAPIResource<VersionGroup> VersionGroup { get; set; }
    }
    public class Name
    {
        public string name { get; set; }
        public NamedAPIResource<Language> Language { get; set; }
    }
    public class NamedAPIResource<T> : InfoUrl<T> where T : class
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
    public class VerboseEffect
    { 
        public string Effect { get; set; }
        public string ShortEffect { get; set; }
        public NamedAPIResource<Language> Language { get; set; }
    }
    public class VersionEncounterDetail
    {
        public NamedAPIResource<Version> Version { get; set; }
        public int MaxChance { get; set; }
        public List<Encounter> EncounterDetails { get; set; }
    }

    public class VersionGameIndex
    {
       public int GameIndex { get; set; }
       public NamedAPIResource<Version> Version { get; set; }
    }
    public class VersionGroupFlavorText
    { 
        public string Text { get; set; }
        public NamedAPIResource<Language> Language { get; set; }
        public NamedAPIResource<VersionGroup> VersionGroup { get; set; }
    }

    public class Language
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Official { get; set; }
        public string Iso639 { get; set; }
        public string Iso3166 { get; set; }
        public List<Name> Names { get; set; }
    }
    public class APIResource { }
}
