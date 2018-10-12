using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragons.Models
{
    public class SpellFormSubmit
    {
        public string classInput { set; private get; }
        public string nameInput { set; private get; }
        public int levelInput { set; private get; }
        public string descriptionInput { set; private get; }
        public string higherLevelsInput { set; private get; }
        public string rangeInput { set; private get; }
        public string durationInput { set; private get; }
        public string castingTimeInput { set; private get; }
        public string schoolInput { set; private get; }
        public bool somaticInput { set; private get; }
        public bool verbalInput { set; private get; }
        public bool ritualInput { set; private get; }
        public bool materialCostInput { set; private get; }
        public string materialInput { set; private get; }
        public int pageInput { set; private get; }

        public SpellFormSubmit()
        {
            var spell = new SpellsExtended()
            {
                Class = new string[] { "Wizard", "Sorcerer" },
                CastingTime = "1 min",
                ClassDesc = "Wizard",
                ComponentDesc = "V",
                Concentration = false,
                Desc = "<p>Test description.</p>",
                Duration = "30 mins",
                HigherLevel = "<p>Test higher level.</p>",
                Index = 415,
                Level = 9,
                LevelDesc = "Test Level desc",
                Material = false,
                Name = "Test Spell",
                Page = 999,
                Range = "50 feet",
                RangeDesc = "Test range",
                Ritual = false,
                School = "Necromancy",
                Somatic = false,
                Source = "KKK",
                Verbal = false
            };
        }
    }
}
