using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonsAndDragons.Helpers;
using DungeonsAndDragons.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DungeonsAndDragons.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        SpellsExtendedDatabaseHelper _dbHelper = new SpellsExtendedDatabaseHelper("mongodb://localhost:27017/local");

        [HttpGet]
        public IEnumerable<SpellsExtended> GetSpells()
        {
            var spells = _dbHelper.GetSpells();
            var spellsOrdered = spells.OrderBy(c => c.Level);
            return spellsOrdered;
        }

        [HttpGet]
        public IEnumerable<SpellsExtended> GetSpell(long index)
        {
            var spell = _dbHelper.GetSpell(index);
            return spell;
        }

        [HttpPost]
        public IActionResult AddSpell([FromBody]SpellFormSubmit data)
        //public IActionResult AddSpell(string classInput, string nameInput, int levelsInput, string descInput, string higherLevelsInput, string rangeInput, string durationInput, string castingTimeInput, string schoolInput, bool somaticInput, bool verbalInput, bool ritualInput, string materialCostInput, string materialInput, int pageInput, bool concentrationInput)
        {
            var x = HttpContext.Request.Body;
            var collection = db.GetCollection<SpellsExtended>("spells_extended");
            
            //collection.InsertOne(spell);

            return RedirectToAction("Home", "Index");
        }

    }
}
