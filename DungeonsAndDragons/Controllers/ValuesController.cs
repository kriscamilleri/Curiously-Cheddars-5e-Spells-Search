using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonsAndDragons.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DungeonsAndDragons.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        private string _connectionString = "mongodb://localhost:27017/local";

        [HttpGet]
        public IEnumerable<SpellsExtended> GetSpells()
        {
            var db = GetDatabase();
            var collection = db.GetCollection<SpellsExtended>("spells_extended");
            var spells = collection.Find(_ => true).ToList();
            var spellsOrdered = spells.OrderBy(c => c.Level);
            return spellsOrdered;
        }

        [HttpGet]
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
