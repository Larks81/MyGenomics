using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGenomics.DomainModel;
using System.Collections.Generic;
using System.Linq;
using MyGenomics.Services;

namespace MyGenomics.ServicesUnitTest
{
    [TestClass]
    public class PersonServicesUnitTest
    {
        [TestMethod]
        public void MigrateContractFromCRM()
        {
            List<Person> dbContacts = null;
            List<Person> afterMigrationDbContacts = null;
            List<Person> crmContacts = null;

            BaseDataService.InitializeServices();
            PersonsService service = new PersonsService();

            try
            {
                // Leggo tutte le persone da CRM
                crmContacts = service.GetAllCrmContacts();

                // Leggo le persone presenti nel DB
                dbContacts = service.GetAll();

                // Faccio la migrazione degli utenti non presenti
                service.MigrateCrmContacts();

                // Rileggo le persone presenti a DB
                afterMigrationDbContacts = service.GetAll();

                // Verifico il numero di contatti aggiunti
                Assert.IsTrue(dbContacts.Count + crmContacts.Where(c => !dbContacts.Any(p => p.UserName == c.UserName)).Count() == afterMigrationDbContacts.Count,
                    "Verifica del numero di contatti aggiunti");
            }
            catch (Exception e)
            {
                Assert.Fail("Test fallito a causa di una eccezione:" + Environment.NewLine + e.Message + Environment.NewLine + e.InnerException);
            }
            finally
            {
                // Perform the test clean up
                if (dbContacts != null && afterMigrationDbContacts != null && crmContacts != null)
                {
                    afterMigrationDbContacts.Where(c => !dbContacts.Any(p => p.UserName == c.UserName))
                        .ToList()
                        .ForEach(c => service.Remove(c.Id));
                }
            }
        }

        [TestMethod]
        public void AuthenticateInCrm()
        {
            Person dbContact = null;
            Person crmContact = null;

            BaseDataService.InitializeServices();
            PersonsService service = new PersonsService();

            try
            {
                string userName = "demo";
                string pwd = "demo";
                // Verifico se il contatto è stato trovato
                crmContact = service.AuthenticateInCrm(userName, pwd);
                Assert.IsTrue(crmContact != null, "Caricamento contatto dal CRM");

                // Verifico che il contatto sia stato aggiunto a DB
                dbContact = service.GetPersonByLogin(userName, pwd);
                Assert.IsTrue(dbContact != null, "Aggiunta contatto nel DB");
            }
            catch (Exception e)
            {
                Assert.Fail("Test fallito a causa di una eccezione:" + Environment.NewLine + e.Message + Environment.NewLine + e.InnerException);
            }
            finally
            {
                // Perform the test clean up
                if (dbContact != null && crmContact != null)
                {
                    service.Remove(dbContact.Id);
                }
            }

        }


        [TestMethod]
        public void UpdateCrmContact()
        {
            Person crmContact = null;
            Person updContact = null;
            string oldEmail = null;
            string newEmail = "demo.demo@demo.com";
            string userName = "demo";

            BaseDataService.InitializeServices();
            PersonsService service = new PersonsService();

            try
            {
                // Leggo un contatto che so esistere nel CRM
                crmContact = service.GetContactFromCrm(userName);
                Assert.IsTrue(crmContact != null, "Caricamento contatto dal CRM");

                // Modifico una voce del contatto
                oldEmail = crmContact.Email;
                crmContact.Email = newEmail;
                
                // Faccio l'update sul CRM del nuovo contatto
                service.UpdateCrmContact(crmContact);

                // Rileggo il contatto e verifico che sia stata cambiata l'email
                updContact = service.GetContactFromCrm(userName);
                Assert.IsTrue(updContact.Email == newEmail, "Verifica email");

            }
            catch (Exception e)
            {
                Assert.Fail("Test fallito a causa di una eccezione:" + Environment.NewLine + e.Message + Environment.NewLine + e.InnerException);
            }
            finally
            {
                if (updContact != null)
                {
                    // Resetto l'email a crm al valore precedente
                    updContact.Email = oldEmail;
                    service.UpdateCrmContact(updContact);
                }
                else if (crmContact != null && oldEmail != null)
                {
                    // Resetto l'email a crm al valore precedente
                    crmContact.Email = oldEmail;
                    service.UpdateCrmContact(crmContact);
                }
            }
        }
    }
}
