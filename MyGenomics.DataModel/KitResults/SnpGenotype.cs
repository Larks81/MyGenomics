using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class SnpGenotype : ModelBase 
    {
        public Kit Kit { get; set; }
        public int KitId { get; set; }
        public Panel Panel { get; set; }
        public int PanelId { get; set; }
        public Snp Snp { get; set; }
        public int SnpId { get; set; }
        public string Genotype { get; set; }
    }
}
