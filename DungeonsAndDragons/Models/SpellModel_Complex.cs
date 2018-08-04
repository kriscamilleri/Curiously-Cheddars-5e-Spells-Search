
//namespace Models
//{
//    using System;
//    using System.Collections.Generic;

//    using System.Globalization;
//    using System.Runtime.Serialization;
//    using MongoDB.Bson;
//    using MongoDB.Bson.Serialization.Attributes;
//    using Newtonsoft.Json;
//    using Newtonsoft.Json.Converters;

//    public enum CastingTime { The10Minutes, The12Hours, The1Action, The1BonusAction, The1Hour, The1Minute, The1Reaction, The24Hours, The8Hours };

//    public enum Component { M, S, V };

//    public enum Concentration { No, Yes };

//    public enum Name { Abjuration, Bard, Cleric, Conjuration, Devotion, Divination, Druid, Enchantment, Evocation, Fiend, Illusion, Land, Life, Lore, Necromancy, Paladin, Ranger, Sorcerer, Transmutation, Warlock, Wizard };

//    public enum Range { Self, Sight, Special, The100Feet, The10Feet, The120Feet, The150Feet, The1Mile, The300Feet, The30Feet, The500Feet, The500Miles, The5Feet, The60Feet, The90Feet, Touch, Unlimited };

//    public enum Url { HttpWwwDnd5EapiCoApiClasses10, HttpWwwDnd5EapiCoApiClasses11, HttpWwwDnd5EapiCoApiClasses12, HttpWwwDnd5EapiCoApiClasses2, HttpWwwDnd5EapiCoApiClasses3, HttpWwwDnd5EapiCoApiClasses4, HttpWwwDnd5EapiCoApiClasses7, HttpWwwDnd5EapiCoApiClasses8, HttpWwwDnd5EapiCoApiMagicSchools1, HttpWwwDnd5EapiCoApiMagicSchools2, HttpWwwDnd5EapiCoApiMagicSchools3, HttpWwwDnd5EapiCoApiMagicSchools4, HttpWwwDnd5EapiCoApiMagicSchools5, HttpWwwDnd5EapiCoApiMagicSchools6, HttpWwwDnd5EapiCoApiMagicSchools7, HttpWwwDnd5EapiCoApiMagicSchools8, HttpWwwDnd5EapiCoApiSubclasses11, HttpWwwDnd5EapiCoApiSubclasses2, HttpWwwDnd5EapiCoApiSubclasses3, HttpWwwDnd5EapiCoApiSubclasses4, HttpWwwDnd5EapiCoApiSubclasses7 };

//    public partial class School
//    {
//        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
//        [BsonRepresentation(BsonType.String)]         // Mongo
//        [DataMember][JsonProperty("name")]
//        public Name name { get; set; }

//        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
//        [BsonRepresentation(BsonType.String)]         // Mongo
//        [DataMember][JsonProperty("url")]
//        public Url url { get; set; }
//    }

//    public partial class Spells
//    {
//        [BsonId]
//        public ObjectId id { get; set; }

//        [DataMember][JsonProperty("casting_time")]
//        [BsonRepresentation(BsonType.String)]         // Mongo
//        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
//        public CastingTime castingTime { get; set; }

//        [DataMember][JsonProperty("classes")]
//        public School[] classes { get; set; }

//        [DataMember][JsonProperty("components")]
//        [BsonRepresentation(BsonType.String)]         // Mongo
//        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
//        public Component[] components { get; set; }

//        [DataMember][JsonProperty("concentration")]
//        [BsonRepresentation(BsonType.String)]         // Mongo
//        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
//        public Concentration concentration { get; set; }

//        [DataMember][JsonProperty("desc")]
//        public string[] desc { get; set; }

//        [DataMember][JsonProperty("duration")]
//        public string duration { get; set; }

//        [DataMember][JsonProperty("higher_level", NullValueHandling = NullValueHandling.Ignore)]
//        public string[] higherLevel { get; set; }

//        [DataMember][JsonProperty("index")]
//        public long index { get; set; }

//        [DataMember][JsonProperty("level")]
//        public long level { get; set; }

//        [DataMember][JsonProperty("material", NullValueHandling = NullValueHandling.Ignore)]
//        public string material { get; set; }

//        [DataMember][JsonProperty("name")]
//        public string name { get; set; }
//        [DataMember][JsonProperty("page")]
//        public string page { get; set; }

//        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
//        [BsonRepresentation(BsonType.String)]         // Mongo
//        [DataMember][JsonProperty("range")]
//        public Range range { get; set; }

//        [DataMember][JsonProperty("ritual")]
//        [BsonRepresentation(BsonType.String)]         // Mongo
//        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
//        public Concentration ritual { get; set; }
//        [DataMember][JsonProperty("school")]
//        public School school { get; set; }
//        [DataMember][JsonProperty("subclasses")]
//        public School[] subclasses { get; set; }

//        [DataMember][JsonProperty("url")]
//        public string url { get; set; }
//    }
//}
