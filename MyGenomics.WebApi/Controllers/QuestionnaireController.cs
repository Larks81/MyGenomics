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
        public Questionnaire Get(int id)
        {            
            return _questionnairesService.Get(id);
        }

        
    }
}
