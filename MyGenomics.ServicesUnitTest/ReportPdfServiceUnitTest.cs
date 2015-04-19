using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGenomics.DomainModel;
using MyGenomics.Services;
using MyGenomics.Services.Services;

namespace MyGenomics.ServicesUnitTest
{
    [TestClass]
    public class ReportPdfServiceUnitTest
    {
        [TestMethod]
        public void TestReportCreate()
        {
            BaseDataService.InitializeServices();

            string html = File.ReadAllText("fakeReports/fakeReport.html");
            string tocPath = "fakeReports/toc.xsl";
            string pdfFilePath = "testReport.pdf";

            var _reportService = new ReportPdfService();
            _reportService.HtmlToPdf(pdfFilePath, tocPath, html);

            Assert.IsTrue(File.Exists(pdfFilePath));
            //File.Delete(pdfFilePath);
        }

        [TestMethod]
        public void TestReportCreateHtml()
        {
            BaseDataService.InitializeServices();
            var _reportPdfService = new ReportPdfService();

            string template = File.ReadAllText("fakeReports/fakeReportRazor.html");            

            var model = _reportPdfService.GetReportTemplateModel(1, 1);

            var _reportService = new ReportPdfService();
            string html = _reportService.GenerateHtml<ReportTemplate>(template, model);
            string tocPath = "fakeReports/toc.xsl";
            string headerPath = "C:/Users/Larks/Documents/GitHub/MyGenomics/MyGenomics.ServicesUnitTest/fakeReports/header.html";
            string pdfFilePath = "testReport.pdf";

            _reportService.WritePDF(html,headerPath, pdfFilePath, tocPath);

            //Assert.IsTrue(File.Exists(pdfFilePath));
            //File.Delete(pdfFilePath);
        }
    }
}
