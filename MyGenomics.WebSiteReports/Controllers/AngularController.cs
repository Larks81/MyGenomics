using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGenomics.WebSiteReports.Controllers
{
    public class AngularController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FroalaUploadImage(HttpPostedFileBase file, int? postId) // نام پارامتر فايل را تغيير ندهيد
        {
            var fileName = Path.GetFileName(file.FileName);
            var rootPath = Server.MapPath("~/images/");
            file.SaveAs(Path.Combine(rootPath, fileName));
            return Json(new { link = "images/" + fileName }, JsonRequestBehavior.AllowGet);
        }

    }
}
