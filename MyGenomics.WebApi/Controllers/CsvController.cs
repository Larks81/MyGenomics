using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MyGenomics.Services.Services;

namespace MyGenomics.Controllers
{    
    public class CsvController : ApiController
    {

        [System.Web.Http.HttpPost]
        public async Task<object> ImportSnpCsv(int panelId)
        {
            var _snpService = new SnpService();
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {                
                await Request.Content.ReadAsMultipartAsync(provider);

                var imported = 0;
                foreach (MultipartFileData fileData in provider.FileData)
                {
                    var csv = File.ReadAllText(fileData.LocalFileName);
                    imported = _snpService.ImportSnpsFromCsv(csv, panelId);
                }
                return new { imported = imported };
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

        }                   
        
    }
}
