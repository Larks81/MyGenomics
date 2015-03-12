using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenomics.Common.enums;

namespace MyGenomics.DomainModel
{    
    public class PersonType
    {
        public int Id { get; set; }
        public Enums Gender { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public string Description { get; set; }
    }
}
