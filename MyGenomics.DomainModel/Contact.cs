using MyGenomics.Common.enums;
using System;

namespace MyGenomics.DomainModel
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Enums Gender { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthCity { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PersonalDoctor { get; set; }
        public ContactType ContactType { get; set; }
        public int ContactTypeId { get; set; }

    }
}
