using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class Kit : ModelBase 
    {
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        public string Code { get; set; }
    }
}
