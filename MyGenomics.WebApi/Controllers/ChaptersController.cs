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
    public class ChaptersController : ApiController
    {
        private readonly ReportService _reportService = new ReportService();
        public SearchList<ChapterItemList> Get(int languageId, string filter, int page = 1)
        {
            return _reportService.GetChapters(languageId, filter, page);
        }

        public ChapterDetail Get(int languageId, int id)
        {
            return _reportService.GetChapterDetail(languageId, id);
        }

        // POST api/panels
        public object Post([FromBody]ChapterDetail value)
        {
            var Id = _reportService.AddOrUpdateChapter(value);
            return new { Id };
        }

        // DELETE api/panels/5
        public void Delete(int id)
        {
            _reportService.RemoveChapter(id);
        }
    }
}
