using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyGenomics.Services.Services;

namespace MyGenomics.Controllers
{
    public class LevelsController : ApiController
    {
        private ReportService _reportService = new ReportService();

        public IEnumerable<DomainModel.LevelItemList> Get(int languageId, string filter)
        {
            return _reportService.GetLevels(languageId, filter);
        }

        // GET api/levels/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/levels
        public void Post([FromBody]string value)
        {
        }

        // PUT api/levels/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/levels/5
        public void Delete(int id)
        {
        }
    }
}
