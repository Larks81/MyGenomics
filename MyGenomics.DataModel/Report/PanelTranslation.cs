using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class PanelTranslation : ModelBase
    {
        public Panel Panel { get; set; }
        public int PanelId { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }

    }
}
