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
        public string castingTimeInput { set; private get; }
        public string classInput { set; private get; }
        public bool concentrationInput { set; private get; }
        public string descInput { set; private get; }
        public string durationInput { set; private get; }
        public string higherLevelsInput { set; private get; }
        public int levelsInput { set; private get; }
        public bool materialCostInput { set; private get; }
        public string materialInput { set; private get; }
        public string nameInput { set; private get; }
        public int pageInput { set; private get; }
        public string rangeInput { set; private get; }
        public bool ritualInput { set; private get; }
        public string schoolInput { set; private get; }
        public bool somaticInput { set; private get; }
        public bool verbalInput { set; private get; }
        
        private SpellsExtendedDatabaseHelper _dbHelper { get; set; }

        public SpellsExtended GenerateSpellExtended(SpellsExtendedDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
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
                LevelDesc = GetLevelDesc(),
                Material = GetMaterial(),
                MaterialCost = GetMaterialCost(),
                MaterialDesc = GetMaterialDesc(),
                Name = GetName(),
                Page = GetPage(),
                Range = GetRange(),
                RangeDesc = GetRange(),
                Ritual = GetRitual(),
                School = GetSchool(),
                Somatic = GetSomatic(),
                Verbal = GetVerbal(),
                Source = "XGE"
            };
            return spell;
        }

        public bool GetMaterialCost()
        {
            return materialCostInput;
        }

        public bool GetMaterial()
        {
            var materialBool = String.IsNullOrWhiteSpace(materialInput) ? false : true;

            return materialBool;
        }

        public string GetName()
        {
            return CleanString(nameInput);
        }

        public int GetPage()
        {
            return pageInput;
        }

        public string GetRange()
        {
            return CleanString(rangeInput);
        }

        public bool GetRitual()
        {
            return ritualInput;
        }

        public string GetSchool()
        {
            return schoolInput.ToTitleCase();
        }

        private string CleanString(string value)
        {
            value = Regex.Replace(value, "[^0-9A-Za-z ,]", ",");
            return value;
        }

        private string GetCastingTime()
        {
            return CleanString(castingTimeInput);
        }

        private string[] GetClass()
        {
            var array = classInput.ToTitleCase().Split(",");
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = CleanString(array[i].Trim());
            }
            return array;
        }

        private string GetClassDescription()
        {
            return classInput;
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

        private string GetLevelDesc()
        {
            var levelDict = new Dictionary<int, string>()
            {
                { 1, "1st-level" },
                { 2, "2nd-level" },
                { 3, "3rd-level" },
                { 4, "4th-level" },
                { 5, "5th-level" },
                { 6, "6th-level" },
                { 7, "7th-level" },
                { 8, "8th-level" },
                { 9, "9th-level" },
            };

            var result = levelDict[levelsInput];

            return result;
        }

        private string GetMaterialDesc()
        {
            var result = materialInput;
            return result;
        }

        private bool GetSomatic()
        {
            return somaticInput;
        }

        private bool GetVerbal()
        {
            return verbalInput;
        }
        private class ComponentContainer
        {
            public string Name;
            public bool Value;
        }
    }
}
