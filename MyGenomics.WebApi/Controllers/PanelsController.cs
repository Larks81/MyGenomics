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
    [Authorize(Roles = "Admin")]
    public class PanelsController : ApiController
    {
        private readonly ReportService _reportService = new ReportService();

        public SearchList<PanelItemList> Get(int languageId, string filter, int page = 1)
        {
            return _reportService.GetPanels(languageId, filter, page);
        }
        
        public PanelDetail Get(int languageId, int id)
        {
            return _reportService.GetPanelDetail(languageId, id);
        }

        // POST api/panels
        public object Post([FromBody]PanelDetail value)
        {
            var Id = _reportService.AddOrUpdatePanel(value);
            return new { Id };
        }        

        // DELETE api/panels/5
        public void Delete(int id)
        {
            _reportService.RemovePanel(id);
        }
    }
}
