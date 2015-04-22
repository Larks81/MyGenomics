using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class SnpItemList
    {
        public int Id { get; set; }        
        public string SNPCode { get; set; }
        public string Gene { get; set; }
        public string Allelerisk { get; set; }
        public double OR_Beta { get; set; }
        public double P_value { get; set; }     
    }
}
