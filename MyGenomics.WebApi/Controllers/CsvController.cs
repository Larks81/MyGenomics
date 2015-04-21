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
        public async Task<object> Post(int panelId)
        {
            var _snpService = new SnpService();
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {                
                await Request.Content.ReadAsMultipartAsync(provider);

                string encoded = "";
                foreach (MultipartFileData fileData in provider.FileData)
                {
                    var csv = File.ReadAllText(fileData.LocalFileName);
                    _snpService.ImportSnpsFromCsv(csv, panelId);
                }                
                return new { link = "data:image/png;base64," + encoded };
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

        }                   
        
    }
}
