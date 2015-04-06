using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class Panel : ModelBase
    {        
        public List<Chapter> Chapters { get; set; }
        public List<PanelContent> PanelContents { get; set; }
        public List<Snp> Snps { get; set; }
        public List<PanelTranslation> Translations { get; set; }
    }
}
