using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class PractitionerReportKit : ModelBase
    {
        public Practitioner Practitioner { get; set; }
        public int? PractitionerId { get; set; }
        public Report Report { get; set; }
        public int? ReportId { get; set; }
        public Kit Kit { get; set; }
        public int? KitId { get; set; }
    }
}
