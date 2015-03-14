using System.Collections.Generic;
using System.Web.Http;
using MyGenomics.DomainModel;
using MyGenomics.Services;

namespace MyGenomics.Controllers
{
    public class PersonController : ApiController
    {
        private readonly PersonsService _personService = new PersonsService();
        // GET api/pesrons
        public IEnumerable<Person> Get()
        {
            return null;
        }

        // GET api/pesrons/5
        public Person Get(string username, string password)
        {
            return _personService.GetPersonByLogin(username, password);
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
