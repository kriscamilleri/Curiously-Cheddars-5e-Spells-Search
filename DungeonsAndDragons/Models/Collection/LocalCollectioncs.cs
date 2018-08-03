using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragons.Models.Collection
{
    public class SpellsCollection
    {
        public string Id { get; set; }
        public int LocalCollectioncsID { get; set; }
        public int LoanRocketID { get; set; }
        public DateTime RequestDate { get; set; }
        public int CreatedByID { get; set; }
        public string RequestXML { get; set; }
    }
}
