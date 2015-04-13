using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class PanelItemList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ContentsCount { get; set; }
        public int OrderPosition { get; set; }
    }
}
