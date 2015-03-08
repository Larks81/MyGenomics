using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenomics.Data.Context;
using MyGenomics.Model;

namespace MyGenomics.Data.Services
{
    public class PersonsService
    {
        public List<Person> GetAll()
        {
            using (var context = new MyGenomicsContext())
            {
                return context.People.ToList();
            }
        }

        public int InsertPersonQuestionnaire(PersonQuestionnaire personQuestionnaire)
        {
            using (var context = new MyGenomicsContext())
            {
                context.PersonQuestionnaires.Add(personQuestionnaire);
                context.SaveChanges();
                return personQuestionnaire.Id;
            }
        }

        public PersonType GetPersonTypeByPerson(Person person)
        {
            var personTypeId = 0;
            List<PersonType> personTypes = null;

            DateTime today = DateTime.Today;
            int personAge = today.Year - person.BirthDate.Year;
            if (person.BirthDate > today.AddYears(-personAge))
            {
                personAge--;
            }

            using (var context = new MyGenomicsContext())
            {
               return context.PersonTypes
                    .FirstOrDefault(t => t.AgeFrom <= personAge && t.AgeTo >= personAge && t.Gender == person.Gender);
            }            
        }
    }
}
