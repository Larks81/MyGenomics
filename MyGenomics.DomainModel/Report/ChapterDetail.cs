using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class ChapterDetail
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int? TranslationId { get; set; }
        public string Color { get; set; }
        public string Title { get; set; }        
        public string Text { get; set; }
        public string ImageUri { get; set; }
        public List<PanelItemList> Panels { get; set; }
        public List<ReportItemList> Reports { get; set; }
    }
}
