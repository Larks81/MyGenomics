using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyGenomics.Attributes;
using MyGenomics.Common.enums;
using MyGenomics.DomainModel;
using MyGenomics.Services.Services;

namespace MyGenomics.Controllers
{
    [AuthorizeRoles(UserType.Administrator)]
    public class SnpsController : ApiController
    {
        private SnpService _snpService = new SnpService();
        
        public SearchList<DomainModel.SnpItemList> Get(int panelId, int? page)
        {
            return _snpService.GetSnps(panelId, page);
        }

        // GET api/snps/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/snps
        public void Post([FromBody]string value)
        {
        }

        // PUT api/snps/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/snps/5
        public void Delete(int id)
        {
        }
    }
}
