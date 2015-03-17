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
    }
}
