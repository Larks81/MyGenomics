using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class PanelContentDetail
    {
        public int Id { get; set; }
        public int PanelId { get; set; }
        public int? TranslationId { get; set; }
        public int LanguageId { get; set; }
        public int? LevelId { get; set; }
        public string Title { get; set; }
        public string ShortText { get; set; }
        public string Text { get; set; }
    }
}
