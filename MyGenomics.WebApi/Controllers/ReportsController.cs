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
    [AuthorizeRoles(UserType.Administrator)]
    public class ReportsController : ApiController
    {
        private readonly ReportService _reportService = new ReportService();
        public SearchList<ReportItemList> Get(int languageId, string filter, int page = 1)
        {
            return _reportService.GetReports(languageId, filter, page);
        }

        public ReportDetail Get(int languageId, int id)
        {
            return _reportService.GetReportDetail(languageId, id);
        }
        
        public object Post([FromBody]ReportDetail value)
        {
            var Id = _reportService.AddOrUpdateReport(value);
            return new { Id };
        }

        public void Delete(int id)
        {
            _reportService.RemoveReport(id);
        }
    }
}
