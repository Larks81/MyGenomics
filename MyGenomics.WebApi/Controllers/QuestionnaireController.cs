using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyGenomics.Data.Services;
using MyGenomics.Model;

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
            var a = _questionnairesService.Get(id);
            return _questionnairesService.Get(id);
        }

        
    }
}
