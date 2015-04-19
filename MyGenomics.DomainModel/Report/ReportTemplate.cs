using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class ReportTemplate 
    {
        public ReportPrintable ReportDetail { get; set; }
    }

    public class ReportPrintable : ReportDetail
    {
        public List<ChapterPrintable> ChaptersDetail { get; set; }
        public ReportHeaderPrintable ReportHeaderDetail { get; set; }
    }

    public class ReportHeaderPrintable : ReportHeaderDetail
    {

    }

    public class ChapterPrintable : ChapterDetail
    {
        public List<PanelPrintable> PanelsDetail { get; set; }
    }

    public class PanelPrintable : PanelDetail
    {
        public List<PanelContentPrintable> PanelContentsDetail { get; set; }
    }

    public class PanelContentPrintable : PanelContentDetail
    {

    }
}
