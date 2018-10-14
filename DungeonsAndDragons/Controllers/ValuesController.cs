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
        public IActionResult AddSpell([FromBody]SpellFormSubmit form)
        {
            try
            {
                var spell = form.GenerateSpellExtended(_dbHelper);
                _dbHelper.InsertSpell(spell);
                return Content($"Success! Added the spell {spell.Name}. Spell index: {spell.Index}.", "application/json");
            }
            catch (Exception e)
            {
                return Content("Error." + e.GetFullMessage(), "application/json");
            }

        }
    }
}
