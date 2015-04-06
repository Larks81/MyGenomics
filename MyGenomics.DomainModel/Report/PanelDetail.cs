using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class PanelDetail
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int? TranslationId { get; set; }
        public string Title { get; set; }
        public List<ChapterItemList> Chapters { get; set; }
        public List<PanelContentDetail> PanelContents { get; set; }
        
    }
}
