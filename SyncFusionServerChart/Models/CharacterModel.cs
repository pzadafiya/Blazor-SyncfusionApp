using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncFusionServerChart.Models
{
    public class CharacterModel
    {
        public int script_id { get; set; }
        public string imdb_character_name { get; set; }
        public int words { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
    }
}
