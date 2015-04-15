using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class ReportItemList
    {
        public int Id { get; set; }
        public string ProductName { get; set; }        
        public string Title { get; set; }
        public string Version { get; set; }
        public int ChaptersCount { get; set; }     
    }
}
