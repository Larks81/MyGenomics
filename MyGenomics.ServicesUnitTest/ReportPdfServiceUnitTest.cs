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
            string WkHtmlToPdfPath = "C:/Users/Developer29/Documents/GitHub/MyGenomics/MyGenomics.ServicesUnitTest";//AppDomain.CurrentDomain.BaseDirectory;
            WkHtmlToPdfPath += ConfigurationManager.AppSettings.Get("WkHtmlToPdfPath");            

            BaseDataService.InitializeServices();
            string template = File.ReadAllText("fakeReports/fakeReportRazor.html");                        

            var _reportService = new ReportPdfService(WkHtmlToPdfPath);
            var model = _reportService.GetReportTemplateModel(1, 1);
            //string html = _reportService.GenerateHtml<ReportTemplate>(template, model);
            string tocPath = "fakeReports/toc.xsl";
            string headerPath = "fakeReports/header.html";
            string pdfFilePath = "testReport.pdf";

            var lstHtml = new List<string>(){
                "<h1>Hello World</h1><p>Sta minchia</p>",
                "<h1>Hello World 2</h1><p>Sta minchia 2</p>",
            };

            _reportService.WritePDF(lstHtml, headerPath, pdfFilePath, tocPath);

            //Assert.IsTrue(File.Exists(pdfFilePath));
            //File.Delete(pdfFilePath);
        }
    }
}
