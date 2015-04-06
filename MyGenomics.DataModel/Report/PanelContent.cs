using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class PanelContent : ModelBase
    {
        public Panel Panel { get; set; }
        public int PanelId { get; set; }
        public Level Level { get; set; }
        public int? LevelId { get; set; }
        public List<PanelContentTranslation> Translations { get; set; }    
    }
}
