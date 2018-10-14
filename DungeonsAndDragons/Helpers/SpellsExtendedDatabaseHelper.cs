using DungeonsAndDragons.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragons.Helpers
{
    public class SpellsExtendedDatabaseHelper
    {
        private string _connectionString;

        public SpellsExtendedDatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public long GetNextSpellIndex()
        {
            var db = GetDatabase();
            var collection = db.GetCollection<SpellsExtended>("spells_extended");
            return collection.CountDocuments(new BsonDocument());
        }

        public IEnumerable<SpellsExtended> GetSpells()
        {
            var db = GetDatabase();
            var collection = db.GetCollection<SpellsExtended>("spells_extended");
            var spells = collection.Find(_ => true).ToList();
            return spells;
        }
        public IEnumerable<SpellsExtended> GetSpell(long index)
        {
            var db = GetDatabase();
            var collection = db.GetCollection<SpellsExtended>("spells_extended");
            var spell = collection.Find(c => c.Index == index).ToList();
            return spell;
        }

        private IMongoDatabase GetDatabase()
        {
            var _databaseName = MongoUrl.Create(_connectionString).DatabaseName;
            return new MongoClient(_connectionString).GetDatabase(_databaseName);
        }
    }
}
