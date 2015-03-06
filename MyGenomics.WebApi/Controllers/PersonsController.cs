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
    public class PersonsController : ApiController
    {
        private readonly PersonsService _personService = new PersonsService();
        // GET api/pesrons
        public IEnumerable<Person> Get()
        {            
            return _personService.GetAll();
        }

        // GET api/pesrons/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/pesrons
        public void Post([FromBody]string value)
        {
        }

        // PUT api/pesrons/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/pesrons/5
        public void Delete(int id)
        {
        }
    }
}
