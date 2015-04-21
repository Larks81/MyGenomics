using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class Distributor : ModelBase
    {
        public string Name { get; set; }
        public string LogoImageUri { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
