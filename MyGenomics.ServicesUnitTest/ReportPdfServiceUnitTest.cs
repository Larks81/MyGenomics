using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
