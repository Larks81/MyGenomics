using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class ReportsChapters : ModelBase
    {
        public Report Report { get; set; }
        public int ReportId { get; set; }
        public Chapter Chapter { get; set; }
        public int ChapterId { get; set; }
        public int OrderPosition { get; set; }
    }
}
