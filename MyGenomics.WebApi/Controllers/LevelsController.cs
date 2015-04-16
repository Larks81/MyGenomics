using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyGenomics.DomainModel;
using MyGenomics.Services.Services;

namespace MyGenomics.Controllers
{
    public class LevelsController : ApiController
    {
        private ReportService _reportService = new ReportService();

        public SearchList<DomainModel.LevelItemList> Get(int languageId, string filter)
        {
            return _reportService.GetLevels(languageId, filter);
        }

        // GET api/levels/5
        public LevelDetail Get(int languageId, int id)
        {
            return _reportService.GetLevelDetail(languageId,id);
        }

        // POST api/levels
        public object Post([FromBody]LevelDetail value)
        {
            var Id = _reportService.AddOrUpdateLevel(value);
            return new { Id };
        }        

        // DELETE api/levels/5
        public void Delete(int id)
        {
            _reportService.RemoveLevel(id);
        }
    }
}
