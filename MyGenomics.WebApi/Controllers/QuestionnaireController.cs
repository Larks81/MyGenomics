using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyGenomics.DomainModel;
using MyGenomics.Services;


namespace MyGenomics.Controllers
{
    public class QuestionnaireController : ApiController
    {
        private readonly QuestionnairesService _questionnairesService = new QuestionnairesService();

        // GET api/questionnaire
        public IEnumerable<Questionnaire> Get()
        {
            return _questionnairesService.GetAll();
        }

        // GET api/questionnaire/5
        public Questionnaire Get(string code)
        {            
            return _questionnairesService.Get(code);
        }

        public ImportQuestionnaire ImportQuestionnaire(ImportQuestionnaire importQuestionnaire, string password)
        {
            if (password == "asdfkljhasdf7asd897fasdhjfojuiasdf798a98d7sf89a7sdfkjasdfasdffff")

                try
                {
                    return _questionnairesService.ImportQuestionnaire(importQuestionnaire);
                }
                catch (Exception ex)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(ex.Message),
                        ReasonPhrase = ex.Message
                    };
                    throw new HttpResponseException(resp);
                }

            else
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Wrong password - Access Denied"),
                    ReasonPhrase = "Wrong password - Access Denied"
                };
                throw new HttpResponseException(resp);
            }                
        }
        
    }
}
