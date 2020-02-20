using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncFusionServerChart.Models
{
    public class CharacterDetailsViewModel
    {
        public int ScriptID { get; set; }
        public string MovieName { get; set; }
        public int TotalWords { get; set; }
        public int MenWords { get; set; }
        public int WomenWords { get; set; }
        public int Gross { get; set; }
        public decimal MenPecentage
        {
            get { return 100 * MenWords / TotalWords; }
        }
        public decimal WomenPecentage
        {
            get { return 100 - MenPecentage; }
        }
        public string Color { get { return MenPecentage < 50 ? "#FF0000" : "#00BDAE"; } }
    }
}
