using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyGenomics.DomainModel;
using MyGenomics.Services.Services;
using MyGenomics.Common.enums;
using MyGenomics.Attributes;

namespace MyGenomics.Controllers
{
    [AuthorizeMultiple(UserType.Administrator)]
    public class ReportHeadersController : ApiController
    {
        private readonly ReportHeaderService _reportHeaderService = new ReportHeaderService();
        public SearchList<ReportHeaderItemList> Get(int languageId, string filter, int page = 1)
        {
            return _reportHeaderService.GetReportHeaders(languageId, filter, page);
        }

        public ReportHeaderDetail Get(int languageId, int id)
        {
            return _reportHeaderService.GetReportHeaderDetail(languageId, id);
        }
            
        public object Post([FromBody]ReportHeaderDetail value)
        {
            var Id = _reportHeaderService.AddOrUpdateReportHeader(value);
            return new { Id };
        }

        public void Delete(int id)
        {
            _reportHeaderService.RemoveReportHeader(id);
        }
        
    }
}
