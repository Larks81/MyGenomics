using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class ReportHeaderTranslation : ModelBase
    {
        public ReportHeader ReportHeader { get; set; }
        public int ReportHeaderId { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public string FirstPage { get; set; }
        public string SecondPage { get; set; }
    }
}
