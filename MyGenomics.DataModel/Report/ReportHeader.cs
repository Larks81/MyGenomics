using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class ReportHeader : ModelBase
    {
        public string TextColor { get; set; }
        public string BaseColor { get; set; }
        public List<ReportHeaderTranslation> Translations { get; set; }
    }
}
