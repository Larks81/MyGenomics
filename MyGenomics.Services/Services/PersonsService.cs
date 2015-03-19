using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyGenomics.Data.Context;
using MyGenomics.DataModel;
using MyGenomics.DomainModel;
using Person = MyGenomics.DataModel.Person;
using SugarCRM = MyGenomics.Data.SugarCRM;

namespace MyGenomics.Services
{
    public class PersonsService
    {
        #region EF Services
        
        public DomainModel.Person GetPersonByLogin(string username, string password)
        {
            Person dataPerson;
            string cryptedPassword = CryptPassword(password);
            using (var context = new MyGenomicsContext())
            {
                dataPerson = context.People
                    .FirstOrDefault(p =>
                        p.UserName.ToUpper() == username.ToUpper() &&
                        p.Password == cryptedPassword);
            }

            if (dataPerson != null)
            {
                return Mapper.Map<DataModel.Person, DomainModel.Person>(dataPerson);
            }
            return null;
        }

        public DomainModel.Person Get(int id)
        {
            Person dataPerson;
            using (var context = new MyGenomicsContext())
            {
                dataPerson = context.People
                    .FirstOrDefault(p =>
                        p.Id == id);
            }

            if (dataPerson != null)
            {
                return Mapper.Map<DataModel.Person, DomainModel.Person>(dataPerson);
            }
            return null;
        }

        public List<DomainModel.Person> GetAll()
        {
            List<DomainModel.Person> result = new List<DomainModel.Person>();
            using (var context = new MyGenomicsContext())
            {
                context.People
                    .ToList()
                    .ForEach(p => result.Add(Mapper.Map<DataModel.Person, DomainModel.Person>(p)));
            }
            return result;
        }

        public DomainModel.PersonType GetPersonTypeByPerson(DomainModel.Person person)
        {
            var retPersonType = new DomainModel.PersonType();
            DataModel.PersonType personType;
            var today = DateTime.Today;
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

        public void Remove(int id)
        {
            using (var context = new MyGenomicsContext())
            {
                var personToRemove = context.People.First(p => p.Id == id);
                if (personToRemove != null)
                {
                    context.People.Remove(personToRemove);
                    context.SaveChanges();
                }
            }
        } 
        
        #endregion
        

        #region CRM Services

        public void MigrateCrmContacts()
        {
            MyGenomics.Data.SugarCRM.Client sugarClient = new Data.SugarCRM.Client();
            string sugarSession = sugarClient.Authenticate();

            var crmContacts = sugarClient.GetContacts(sugarSession);

            using (var context = new MyGenomicsContext())
            {
                // Faccio la migrazione degli utenti non presenti
                context.People.AddRange(crmContacts.Where(p => !context.People.Any(c => c.UserName == p.UserName)));
                context.SaveChanges();
            }

            // TO DO: Allineare eventuali modifiche (es. pwd)?
        }

        public List<DomainModel.Person> GetAllCrmContacts()
        {
            List<DomainModel.Person> result = new List<DomainModel.Person>();

            MyGenomics.Data.SugarCRM.Client sugarClient = new Data.SugarCRM.Client();

            string sugarSession = sugarClient.Authenticate();
            sugarClient.GetContacts(sugarSession)
                .ForEach(p => result.Add(Mapper.Map<DataModel.Person, DomainModel.Person>(p)));

            return result;
        }

        public DomainModel.Person GetContactFromCrm(string username)
        {
            SugarCRM.Client sugarClient = new SugarCRM.Client();
            string sugarSession = sugarClient.Authenticate();

            return Mapper.Map<Person, DomainModel.Person>(sugarClient.GetContact(username, sugarSession));
        }

        public DomainModel.Person AuthenticateInCrm(string username, string password)
        {
            // Prima cerco se la persona è già presente a DB
            DomainModel.Person result = GetPersonByLogin(username, password);
            if (result == null)
            {
                MyGenomics.Data.SugarCRM.Client sugarClient = new Data.SugarCRM.Client();

                string sugarSession = sugarClient.Authenticate();
                var crmContact = sugarClient.GetContact(username, sugarSession);


                if (crmContact.UserName == username && crmContact.Password == password)
                {
                    using (var context = new MyGenomicsContext())
                    {
                        // Se l'utente non è presente, lo aggiungo prima di tornare l'anagrafica
                        if (!context.People.Any(p => p.UserName == username))
                        {
                            // Se aggiungo l'utente lo salvo con la pwd Criptata
                            crmContact.Password = CryptPassword(password);
                            context.People.Add(crmContact);
                            context.SaveChanges();
                        }
                        else
                        {
                            // l'utente è presente ma la pwd è stata modificata, lo leggo e lo allineo 
                            UpdatePerson(context.People.First(p => p.UserName == username), crmContact);
                            context.SaveChanges();
                        }
                    }

                    if (crmContact != null)
                    {
                        return Mapper.Map<DataModel.Person, DomainModel.Person>(crmContact);
                    }
                }
            }
            return result;
        }

        public void UpdateCrmContact(DomainModel.Person person)
        {
            SugarCRM.Client sugarClient = new SugarCRM.Client();
            string sugarSession = sugarClient.Authenticate();

            sugarClient.UpdateExistingContact(
                    Mapper.Map<DomainModel.Person, Person>(person),
                    sugarSession);


        }

        #endregion


        #region Private Methods

        private void UpdatePerson(Person contextPerson, Person crmContact)
        {
            // Allinea tutto tranne UserName e Id
            contextPerson.Address = crmContact.Address;
            contextPerson.BirthCity = crmContact.BirthCity;
            contextPerson.BirthDate = crmContact.BirthDate;
            contextPerson.City = crmContact.City;
            contextPerson.Email = crmContact.Email;
            contextPerson.FirstName = crmContact.FirstName;
            contextPerson.Gender = crmContact.Gender;
            contextPerson.LastName = crmContact.LastName;
            contextPerson.Password = CryptPassword(crmContact.Password);
            contextPerson.PersonalDoctor = crmContact.PersonalDoctor;
            contextPerson.PersonType = crmContact.PersonType;
            contextPerson.PersonTypeId = crmContact.PersonTypeId;
            contextPerson.PhoneNumber = crmContact.PhoneNumber;
        }

        private string CryptPassword(string password)
        {
            return password;
        } 

        #endregion
    }
}
