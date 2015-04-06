using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class ReportTranslation : ModelBase
    {
        public Report Report { get; set; }
        public int ReportId { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Cover { get; set; }
        public string ImageUri { get; set; }
    }
}
