using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonsAndDragons.Models.Collection;
using Microsoft.AspNetCore.Mvc;
using Models;
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

        public int GetSpells()
        {
            //var connectionString = "mongodb://localhost:27017/";
            //var client = new MongoClient(connectionString);
            //IMongoDatabase db = client.GetDatabase("local");
            //db = _db;
            var db = GetDatabase();
            var collection = db.GetCollection<Spells>("spells");
            var spells = collection.Find(_ => true).ToList();
            return spells.Count;
        }

        public  IMongoDatabase GetDatabase()
        {
            var _databaseName = MongoUrl.Create(_connectionString).DatabaseName;
            return new MongoClient(_connectionString).GetDatabase(_databaseName);
        }

    }
}