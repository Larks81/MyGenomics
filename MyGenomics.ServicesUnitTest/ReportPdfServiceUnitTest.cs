using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGenomics.DomainModel;
using MyGenomics.Services;
using MyGenomics.Services.Services;
using System.Collections.Generic;
using System.Configuration;

namespace MyGenomics.ServicesUnitTest
{
    [TestClass]
    public class ReportPdfServiceUnitTest
    {
        [TestMethod]
        public void TestReportCreate()
        {
            //BaseDataService.InitializeServices();

            //string html = File.ReadAllText("fakeReports/fakeReport.html");
            //string tocPath = "fakeReports/toc.xsl";
            //string pdfFilePath = "testReport.pdf";

            //var _reportService = new ReportPdfService();
            //_reportService.HtmlToPdf(pdfFilePath, tocPath, html);

            //Assert.IsTrue(File.Exists(pdfFilePath));
            //File.Delete(pdfFilePath);
        }

        [TestMethod]
        public void TestReportCreateHtml()
        {
            
            BaseDataService.InitializeServices();
            string templateChapter = File.ReadAllText("fakeReports/fakeReportChapter.html");                        

            var _reportService = new ReportPdfService();
            var model = _reportService.GetReportTemplateModel(1, 1);
            //string html = _reportService.GenerateHtml<ReportTemplate>(template, model);
            string tocPath = "fakeReports/toc.xsl";
            string headerPath = "fakeReports/header.html";
            string footerPath = "fakeReports/footer.html";
            string pdfFilePath = "testReport.pdf";



            var lstHtml = _reportService.GetHtmlMergeByTemplates(model, "", templateChapter);

            _reportService.WritePDF(lstHtml, headerPath,footerPath, pdfFilePath, tocPath);

            //Assert.IsTrue(File.Exists(pdfFilePath));
            //File.Delete(pdfFilePath);
        }
    }
}
