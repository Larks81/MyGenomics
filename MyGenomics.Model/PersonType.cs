using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.Model
{
    public enum Gender { Male = 1, Female=2 }
    public class PersonType : ModelBase
    {        
        public Gender Gender { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public string Description { get; set; }
    }
}
