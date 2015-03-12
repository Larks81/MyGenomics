using System;
using System.Collections.Generic;
using System.Linq;
using MyGenomics.Data.Context;
using MyGenomics.DataModel;
using MyGenomics.DomainModel;

namespace MyGenomics.Services
{
    public class PersonsService
    {                
        public DomainModel.PersonType GetPersonTypeByPerson(DomainModel.Person person)
        {
            var retPersonType = new DomainModel.PersonType();
            DataModel.PersonType personType;
            DateTime today = DateTime.Today;
            int personAge = today.Year - person.BirthDate.Year;
            if (person.BirthDate > today.AddYears(-personAge))
            {
                personAge--;
            }

            using (var context = new MyGenomicsContext())
            {
                personType = context.PersonTypes
                    .FirstOrDefault(t => t.AgeFrom <= personAge && t.AgeTo >= personAge && t.Gender == person.Gender);
            }

            if (personType != null)
            {
                retPersonType.Id = personType.Id;
                retPersonType.AgeFrom = personType.AgeFrom;
                retPersonType.AgeTo = personType.AgeTo;
                retPersonType.Gender = personType.Gender;
                retPersonType.Description = personType.Description;
            }

            return retPersonType;
        }
    }
}
