using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class Product : ModelBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Package> ProductPackages { get; set; }
        public string UrlDetail { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}
