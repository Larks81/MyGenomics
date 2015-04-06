using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class LevelTranslation : ModelBase
    {
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public string Text { get; set; }
        public string ImageUri { get; set; }
    }
}
