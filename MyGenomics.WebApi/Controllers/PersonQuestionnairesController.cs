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
    public class PersonQuestionnairesController : ApiController
    {
        private readonly PersonQuestionnairesService _personQuestionnairesService = new PersonQuestionnairesService();

        // GET api/personquestionnaires
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/personquestionnaires/5
        public PersonQuestionnaire Get(int id)
        {           
            return _personQuestionnairesService.Get(id);
        }

        // POST api/personquestionnaires
        public PersonQuestionnaire Post([FromBody]PersonQuestionnaire value)
        {
            value.CreatedDate = DateTime.Now;            
            _personQuestionnairesService.Insert(value);
            return value;
        }

        // PUT api/personquestionnaires/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/personquestionnaires/5
        public void Delete(int id)
        {
        }
    }
}
