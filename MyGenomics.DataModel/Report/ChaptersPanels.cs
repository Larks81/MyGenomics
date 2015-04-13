using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class ChaptersPanels : ModelBase
    {
        public Panel Panel { get; set; }
        public int PanelId { get; set; }
        public Chapter Chapter { get; set; }
        public int ChapterId { get; set; }
        public int OrderPosition { get; set; }
    }
}
