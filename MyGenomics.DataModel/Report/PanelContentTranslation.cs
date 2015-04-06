using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class PanelContentTranslation : ModelBase
    {
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public PanelContent PanelContent { get; set; }
        public int PanelContentId { get; set; }
        public string Title { get; set; }
        public string ShortText { get; set; }
        public string Text { get; set; }
    }
}
