using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class SearchList<T>
    {
        public int TotRec { get; set; }
        public int CurrentPage { get; set; }
        public int TotPag { get; set; }
        public List<T> Results { get; set; }
    }
}
