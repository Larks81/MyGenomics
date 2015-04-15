using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class ReportDetail
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int? TranslationId { get; set; }
        public string Version { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string FrontCover { get; set; }
        public string BackCover { get; set; }
        public string ImageUri { get; set; }
        public List<ChapterItemList> Chapters { get; set; }
    }
}
