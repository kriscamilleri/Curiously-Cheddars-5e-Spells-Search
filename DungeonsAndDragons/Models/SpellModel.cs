
namespace Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using System.Runtime.Serialization;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public enum CastingTime { The10Minutes, The12Hours, The1Action, The1BonusAction, The1Hour, The1Minute, The1Reaction, The24Hours, The8Hours };

    public enum Component { M, S, V };

    public enum Concentration { No, Yes };

    public enum Name { Abjuration, Bard, Cleric, Conjuration, Devotion, Divination, Druid, Enchantment, Evocation, Fiend, Illusion, Land, Life, Lore, Necromancy, Paladin, Ranger, Sorcerer, Transmutation, Warlock, Wizard };

    public enum Range { Self, Sight, Special, The100Feet, The10Feet, The120Feet, The150Feet, The1Mile, The300Feet, The30Feet, The500Feet, The500Miles, The5Feet, The60Feet, The90Feet, Touch, Unlimited };

    public enum Url { HttpWwwDnd5EapiCoApiClasses10, HttpWwwDnd5EapiCoApiClasses11, HttpWwwDnd5EapiCoApiClasses12, HttpWwwDnd5EapiCoApiClasses2, HttpWwwDnd5EapiCoApiClasses3, HttpWwwDnd5EapiCoApiClasses4, HttpWwwDnd5EapiCoApiClasses7, HttpWwwDnd5EapiCoApiClasses8, HttpWwwDnd5EapiCoApiMagicSchools1, HttpWwwDnd5EapiCoApiMagicSchools2, HttpWwwDnd5EapiCoApiMagicSchools3, HttpWwwDnd5EapiCoApiMagicSchools4, HttpWwwDnd5EapiCoApiMagicSchools5, HttpWwwDnd5EapiCoApiMagicSchools6, HttpWwwDnd5EapiCoApiMagicSchools7, HttpWwwDnd5EapiCoApiMagicSchools8, HttpWwwDnd5EapiCoApiSubclasses11, HttpWwwDnd5EapiCoApiSubclasses2, HttpWwwDnd5EapiCoApiSubclasses3, HttpWwwDnd5EapiCoApiSubclasses4, HttpWwwDnd5EapiCoApiSubclasses7 };

    public partial class School
    {
        [DataMember][JsonProperty("name")]
        public Name Name { get; set; }

        [DataMember][JsonProperty("url")]
        public Url Url { get; set; }
    }

    public partial class Spells
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [DataMember][JsonProperty("casting_time")]
        public CastingTime CastingTime { get; set; }

        [DataMember][JsonProperty("classes")]
        public School[] Classes { get; set; }

        [DataMember][JsonProperty("components")]
        public Component[] Components { get; set; }

        [DataMember][JsonProperty("concentration")]
        public Concentration Concentration { get; set; }

        [DataMember][JsonProperty("desc")]
        public string[] Desc { get; set; }

        [DataMember][JsonProperty("duration")]
        public string Duration { get; set; }

        [DataMember][JsonProperty("higher_level", NullValueHandling = NullValueHandling.Ignore)]
        public string[] HigherLevel { get; set; }

        [DataMember][JsonProperty("index")]
        public long Index { get; set; }

        [DataMember][JsonProperty("level")]
        public long Level { get; set; }

        [DataMember][JsonProperty("material", NullValueHandling = NullValueHandling.Ignore)]
        public string Material { get; set; }

        [DataMember][JsonProperty("name")]
        public string Name { get; set; }
        [DataMember][JsonProperty("page")]
        public string Page { get; set; }

        [DataMember][JsonProperty("range")]
        public Range Range { get; set; }
        [DataMember][JsonProperty("ritual")]
        public Concentration Ritual { get; set; }
        [DataMember][JsonProperty("school")]
        public School School { get; set; }
        [DataMember][JsonProperty("subclasses")]
        public School[] Subclasses { get; set; }

        [DataMember][JsonProperty("url")]
        public string Url { get; set; }
    }
}
