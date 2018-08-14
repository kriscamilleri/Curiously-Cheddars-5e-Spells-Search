//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DungeonsAndDragons.Models
//{
//    using System;
//    using System.Collections.Generic;

//    using System.Globalization;
//    using Newtonsoft.Json;
//    using Newtonsoft.Json.Converters;

//    public partial class Spells
//    {
//        [BsonElement("id")]
//        public ObjectId Id { get; set; }

//        [BsonElement("index")]
//        public long Index { get; set; }

//        [BsonElement("name")]
//        public string Name { get; set; }

//        [BsonElement("desc")]
//        public string[] Desc { get; set; }

//        [BsonElement("higher_level")]
//        public string[] HigherLevel { get; set; }

//        [BsonElement("page")]
//        public string Page { get; set; }

//        [BsonElement("range")]
//        public string Range { get; set; }

//        [BsonElement("components")]
//        public string[] Components { get; set; }

//        [BsonElement("material")]
//        public string Material { get; set; }

//        [BsonElement("ritual")]
//        public string Ritual { get; set; }

//        [BsonElement("duration")]
//        public string Duration { get; set; }

//        [BsonElement("concentration")]
//        public string Concentration { get; set; }

//        [BsonElement("casting_time")]
//        public string CastingTime { get; set; }

//        [BsonElement("level")]
//        public long Level { get; set; }

//        [BsonElement("school")]
//        public School School { get; set; }

//        [BsonElement("classes")]
//        public School[] Classes { get; set; }

//        [BsonElement("subclasses")]
//        public School[] Subclasses { get; set; }

//        [BsonElement("url")]
//        public string Url { get; set; }
//    }

//    public partial class School
//    {
//        [BsonElement("url")]
//        public string Url { get; set; }

//        [BsonElement("name")]
//        public string Name { get; set; }
//    }
//}

