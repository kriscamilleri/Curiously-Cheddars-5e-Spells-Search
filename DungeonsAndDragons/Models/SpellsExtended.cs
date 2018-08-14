using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragons.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    //https://colinmarc.com/dndspells/ Database retrieved from here
    public partial class SpellsExtended
    {
        [BsonElement("id")]
        public ObjectId Id { get; set; }

        [BsonElement("index")]
        public long Index { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("desc")]
        public string Desc { get; set; }

        [BsonElement("range")]
        public string Range { get; set; }

        [BsonElement("ritual")]
        public bool Ritual { get; set; }

        [BsonElement("duration")]
        public string Duration { get; set; }

        [BsonElement("concentration")]
        public bool Concentration { get; set; }

        [BsonElement("casting_time")]
        public string CastingTime { get; set; }

        [BsonElement("level")]
        public long Level { get; set; }

        [BsonElement("school")]
        public string School { get; set; }

        [BsonElement("class")]
        public string[] Class { get; set; }

        [BsonElement("level_desc")]
        public string LevelDesc { get; set; }

        [BsonElement("class_desc")]
        public string ClassDesc { get; set; }

        [BsonElement("range_desc")]
        public string RangeDesc { get; set; }

        [BsonElement("component_desc")]
        public string ComponentDesc { get; set; }

        [BsonElement("verbal")]
        public bool Verbal { get; set; }

        [BsonElement("material")]
        public bool Material { get; set; }

        [BsonElement("somatic")]
        public bool Somatic { get; set; }

        [BsonElement("material_desc")]
        public string MaterialDesc { get; set; }

        [BsonElement("material_cost")]
        public bool? MaterialCost { get; set; }

        [BsonElement("source")]
        public string Source { get; set; }

        [BsonElement("page")]
        public long Page { get; set; }

        [BsonElement("higher_level")]
        public string HigherLevel { get; set; }

    }

}

