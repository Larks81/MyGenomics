using MyGenomics.Common.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class User
    {
        public string UserName { get; set; }        
        public UserType UserType { get; set; }
    }
}
