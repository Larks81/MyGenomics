using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public DateTime? InsertDate {get; set;}
        public DateTime? UpdateDate { get; set; }
    }
}
