using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class SnpDetail 
    {
        public int Id { get; set; }
        public int PanelId { get; set; }
        public string SNPCode { get; set; }
        public string Gene { get; set; }
        public string Allelerisk { get; set; }
        public double OR_Beta { get; set; }
        public double P_value { get; set; }        
        public double CC { get; set; }
        public double CT { get; set; }
        public double TC { get; set; }
        public double TT { get; set; }
        public double AA { get; set; }
        public double AG { get; set; }
        public double GA { get; set; }
        public double GG { get; set; }
        public double CG { get; set; }
        public double GC { get; set; }
        public double AC { get; set; }
        public double CA { get; set; }
        public double GT { get; set; }
        public double TG { get; set; }
        public double AT { get; set; }
        public double TA { get; set; }

    }
}
