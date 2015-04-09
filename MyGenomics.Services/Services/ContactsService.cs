using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyGenomics.Data.Context;
using MyGenomics.DataModel;
using MyGenomics.DomainModel;
using Contact = MyGenomics.DataModel.Contact;
using SugarCRM = MyGenomics.Data.SugarCRM;

namespace MyGenomics.Services
{
    public class ContactService
    {
        #region EF Services
        
        public DomainModel.Contact GetContactByLogin(string username, string password)
        {
            Contact dataContact;
            string cryptedPassword = CryptPassword(password);
            using (var context = new MyGenomicsContext())
            {
                dataContact = context.Contacts
                    .FirstOrDefault(p =>
                        p.UserName.ToUpper() == username.ToUpper() &&
                        p.Password == cryptedPassword);
            }

            if (dataContact != null)
            {
                return Mapper.Map<DataModel.Contact, DomainModel.Contact>(dataContact);
            }
            return null;
        }

        public DomainModel.Contact Get(int id)
        {
            Contact dataContact;
            using (var context = new MyGenomicsContext())
            {
                dataContact = context.Contacts
                    .FirstOrDefault(p =>
                        p.Id == id);
            }

            if (dataContact != null)
            {
                return Mapper.Map<DataModel.Contact, DomainModel.Contact>(dataContact);
            }
            return null;
        }

        public List<DomainModel.Contact> GetAll()
        {
            List<DomainModel.Contact> result = new List<DomainModel.Contact>();
            using (var context = new MyGenomicsContext())
            {
                context.Contacts
                    .ToList()
                    .ForEach(p => result.Add(Mapper.Map<DataModel.Contact, DomainModel.Contact>(p)));
            }
            return result;
        }

        public DomainModel.ContactType GetContactTypeByContact(DomainModel.Contact contact)
        {
            var retContactType = new DomainModel.ContactType();
            DataModel.ContactType contactType;
            var today = DateTime.Today;
            int contactAge = today.Year - contact.BirthDate.Year;
            if (contact.BirthDate > today.AddYears(-contactAge))
            {
                contactAge--;
            }

            using (var context = new MyGenomicsContext())
            {
                contactType = context.ContactTypes
                    .FirstOrDefault(t => t.AgeFrom <= contactAge && t.AgeTo >= contactAge && t.Gender == contact.Gender);
            }

            if (contactType != null)
            {
                retContactType.Id = contactType.Id;
                retContactType.AgeFrom = contactType.AgeFrom;
                retContactType.AgeTo = contactType.AgeTo;
                retContactType.Gender = contactType.Gender;
                retContactType.Description = contactType.Description;
            }

            return retContactType;
        }

        public List<DataModel.ContactType> GetContactTypes()
        {           
            using (var context = new MyGenomicsContext())
            {
                return context.ContactTypes.ToList();
            }            
        }

        public void Remove(int id)
        {
            using (var context = new MyGenomicsContext())
            {
                var contactToRemove = context.Contacts.FirstOrDefault(p => p.Id == id);
                if (contactToRemove != null)
                {
                    context.Contacts.Remove(contactToRemove);
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
                context.Contacts.AddRange(crmContacts.Where(p => !context.Contacts.Any(c => c.UserName == p.UserName)));
                context.SaveChanges();
            }

            // TO DO: Allineare eventuali modifiche (es. pwd)?
        }

        public List<DomainModel.Contact> GetAllCrmContacts()
        {
            List<DomainModel.Contact> result = new List<DomainModel.Contact>();

            MyGenomics.Data.SugarCRM.Client sugarClient = new Data.SugarCRM.Client();

            string sugarSession = sugarClient.Authenticate();
            sugarClient.GetContacts(sugarSession)
                .ForEach(p => result.Add(Mapper.Map<DataModel.Contact, DomainModel.Contact>(p)));

            return result;
        }

        public DomainModel.Contact GetContactFromCrm(string username)
        {
            SugarCRM.Client sugarClient = new SugarCRM.Client();
            string sugarSession = sugarClient.Authenticate();

            return Mapper.Map<Contact, DomainModel.Contact>(sugarClient.GetContact(username, sugarSession));
        }

        public DomainModel.Contact AuthenticateInCrm(string username, string password)
        {
            // Prima cerco se la contacta è già presente a DB
            DomainModel.Contact result = GetContactByLogin(username, password);
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
                        if (!context.Contacts.Any(p => p.UserName == username))
                        {
                            // Se aggiungo l'utente lo salvo con la pwd Criptata
                            crmContact.Password = CryptPassword(password);
                            context.Contacts.Add(crmContact);
                            context.SaveChanges();
                        }
                        else
                        {
                            // l'utente è presente ma la pwd è stata modificata, lo leggo e lo allineo 
                            UpdateContact(context.Contacts.FirstOrDefault(p => p.UserName == username), crmContact);
                            context.SaveChanges();
                        }
                    }

                    if (crmContact != null)
                    {
                        return Mapper.Map<DataModel.Contact, DomainModel.Contact>(crmContact);
                    }
                }
            }
            return result;
        }

        public void UpdateCrmContact(DomainModel.Contact contact)
        {
            SugarCRM.Client sugarClient = new SugarCRM.Client();
            string sugarSession = sugarClient.Authenticate();

            sugarClient.UpdateExistingContact(
                    Mapper.Map<DomainModel.Contact, Contact>(contact),
                    sugarSession);


        }

        #endregion


        #region Private Methods

        private void UpdateContact(Contact contextContact, Contact crmContact)
        {
            // Allinea tutto tranne UserName e Id
            contextContact.Address = crmContact.Address;
            contextContact.BirthCity = crmContact.BirthCity;
            contextContact.BirthDate = crmContact.BirthDate;
            contextContact.City = crmContact.City;
            contextContact.Email = crmContact.Email;
            contextContact.FirstName = crmContact.FirstName;
            contextContact.Gender = crmContact.Gender;
            contextContact.LastName = crmContact.LastName;
            contextContact.Password = CryptPassword(crmContact.Password);
            contextContact.PersonalDoctor = crmContact.PersonalDoctor;
            contextContact.ContactType = crmContact.ContactType;
            contextContact.ContactTypeId = crmContact.ContactTypeId;
            contextContact.PhoneNumber = crmContact.PhoneNumber;
            contextContact.UpdateDate = DateTime.Now;                
        }

        private string CryptPassword(string password)
        {
            return password;
        } 

        #endregion
    }
}
