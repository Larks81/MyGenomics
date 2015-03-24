using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGenomics.DomainModel;
using MyGenomics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.ServicesUnitTest
{
    [TestClass]
    public class PersonQuestionnaireServicesUnitTest
    {
        [TestMethod]
        public void SetResultInCrm()
        {
            BaseDataService.InitializeServices();
            PersonQuestionnairesService questService = new PersonQuestionnairesService();
            PersonsService persService = new PersonsService();

            try
            {
                string userName = "demo";
                string pwd = "demo";
                // Verifico se il contatto è stato trovato
                Person crmContact = persService.AuthenticateInCrm(userName, pwd);
                QuestionnaireResult result = new QuestionnaireResult()
                {
                    NumberOfAnswer = 9,
                    ProductId = 1,
                    Result = 5
                };

                questService.SetResultInCrm(crmContact, new List<QuestionnaireResult> {result});
                Assert.IsTrue(crmContact.UserName == userName);
            }
            catch (Exception e)
            {
                Assert.Fail("Test fallito a causa di una eccezione:" + Environment.NewLine + e.Message + Environment.NewLine + e.InnerException);
            }
            finally
            {
            }
        }
    }
}
