using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class Chapter : ModelBase
    {
        public List<ReportsChapters> Reports { get; set; }
        public string Color { get; set; }
        public List<ChaptersPanels> Panels { get; set; }
        public List<ChapterTranslation> Translations { get; set; }
    }
}
