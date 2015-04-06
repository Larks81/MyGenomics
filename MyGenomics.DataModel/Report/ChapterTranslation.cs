using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class ChapterTranslation : ModelBase
    {
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public Chapter Chapter { get; set; }
        public int ChapterId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUri { get; set; }
    }
}
