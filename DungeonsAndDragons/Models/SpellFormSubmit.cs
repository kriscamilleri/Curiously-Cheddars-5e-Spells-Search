using DungeonsAndDragons.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DungeonsAndDragons.Models
{
    public class SpellFormSubmit
    {
        public string classInput { set; private get; }
        public string nameInput { set; private get; }
        public int levelsInput { set; private get; }
        public string descInput { set; private get; }
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
        public bool concentrationInput { set; private get; }

        private SpellsExtendedDatabaseHelper _dbHelper { get; set; }

        private string CleanString(string value)
        {
            value = Regex.Replace(value, "[^0-9A-Za-z ,]", ",");
            return value;
        }

        //private string CleanHTMLString(string value)
        //{
        //    value = Regex.Replace(value, "[^0-9A-Za-z ,]", ",");
        //    return value;
        //}

        private string[] GetClass()
        {
            return classInput.Split(",");
        }

        private string GetCastingTime()
        {
            return CleanString(castingTimeInput);
        }

        private string GetClassDescription()
        {
            return CleanString(descInput);
        }

        private class ComponentContainer
        {
            public string Name;
            public bool Value;
        }

        private string GetComponentDescription()
        {
            var materialBool = String.IsNullOrWhiteSpace(materialInput) ? false : true;
            var containers = new List<ComponentContainer>() {
                new ComponentContainer(){ Name = "V", Value = verbalInput },
                new ComponentContainer() { Name = "S", Value = somaticInput },
                new ComponentContainer() { Name = "M", Value =  materialBool}
            };
            var filteredContainers = containers.Where(c => c.Value).Select(c => c.Name);
            var result = string.Join(", ", filteredContainers);
            return result;
        }

        private bool GetConcentration()
        {
            return concentrationInput;
        }

        private string GetDescription()
        {
            return descInput;
        }
        private string GetDuration()
        {
            return CleanString(durationInput);
        }

        private string GetHigherLevels()
        {
            return higherLevelsInput;
        }

        private long GetIndex()
        {
            return _dbHelper.GetNextSpellIndex();
        }

        private int GetLevel()
        {
            return levelsInput;
        }

        private class LevelContainer
        {
            public 
        }

        private string GetLevelDesc()
        {
            var classFilters = new string[]{ "bard", "cleric", "druid", "paladin", "ranger", "sorcerer", "warlock","wizard"};

            return levelsInput;
        }

        public SpellsExtended GenerateSpellExtended()
        {
            var spell = new SpellsExtended()
            {
                Class = GetClass(),
                CastingTime = GetCastingTime(),
                ClassDesc = GetClassDescription(),
                ComponentDesc = GetComponentDescription(),
                Concentration = GetConcentration(),
                Desc = GetDescription(),
                Duration = GetDuration(),
                HigherLevel = GetHigherLevels(),
                Index = GetIndex(),
                Level = GetLevel(),
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
            return spell;
        }
    }
}
