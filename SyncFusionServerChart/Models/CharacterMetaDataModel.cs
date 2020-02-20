using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncFusionServerChart.Models
{
    public class CharacterMetaDataModel
    {
        public int script_id { get; set; }
        public string imdb_id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public int gross { get; set; }
        public double lines_data { get; set; }
    }
}
