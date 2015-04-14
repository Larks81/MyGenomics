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

namespace MyGenomics.Controllers
{
    public class ImagesController : ApiController
    {

        [System.Web.Http.HttpPost]
        public async Task<object> Post()
        {
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {                
                await Request.Content.ReadAsMultipartAsync(provider);

                string encoded = "";
                foreach (MultipartFileData fileData in provider.FileData)
                {
                    var rootPath = System.Web.Hosting.HostingEnvironment.MapPath("~/images/");
                    Image img = Image.FromFile(fileData.LocalFileName);
                    encoded = ImageToBase64(img, System.Drawing.Imaging.ImageFormat.Png);                
                }                
                return new { link = "data:image/png;base64," + encoded };
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        
        public string ImageToBase64(Image image,System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }                
        
    }
}
