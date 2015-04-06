using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenomics.Common.enums;

namespace MyGenomics.DataModel
{
    public class Contact : ModelBase
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Enums Gender { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthCity { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PersonalDoctor { get; set; }
        public ContactType ContactType { get; set; }
        public int? ContactTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
