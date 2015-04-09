using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class ReportHeaderDetail
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int? TranslationId { get; set; }
        public string FirstPage { get; set; }
        public string SecondPage { get; set; }
    }
}
