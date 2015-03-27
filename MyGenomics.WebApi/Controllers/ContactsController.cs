using System.Collections.Generic;
using System.Web.Http;
using MyGenomics.DomainModel;
using MyGenomics.Services;

namespace MyGenomics.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly ContactService _contactService = new ContactService();
        // GET api/pesrons
        public IEnumerable<Contact> Get()
        {
            return null;
        }

        // GET api/pesrons/5
        public Contact Get(string username, string password)
        {
            return _contactService.GetContactByLogin(username, password);
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
