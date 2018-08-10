using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonsAndDragons.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DungeonsAndDragons.Controllers
{
    //[Route("/")]
    public class HomeController : Controller
    {
        private string _connectionString = "mongodb://localhost:27017/local";

        public IActionResult Index()
        {
            return File("/index.html", "text/html");
        }

        public IActionResult GetSpells()
        {
            var db = GetDatabase();
            var collection = db.GetCollection<Spells>("spells");
            var spells = collection.Find(_ => true).ToList();

            return Ok(spells);
        }

        public IActionResult GetSpell(long index)
        {
            var db = GetDatabase();
            var collection = db.GetCollection<Spells>("spells");
            var spells = collection.Find(c => c.Index == index).ToList();

            return Ok(spells);
        }

        public  IMongoDatabase GetDatabase()
        {
            var _databaseName = MongoUrl.Create(_connectionString).DatabaseName;
            return new MongoClient(_connectionString).GetDatabase(_databaseName);
        }

    }
}