using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGenomics.Services;
using MyGenomics.Services.Services;

namespace MyGenomics.ServicesUnitTest
{
    [TestClass]
    public class ReportServiceUnitTest
    {
        [TestMethod]
        public void TestGetPanelsList()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetPanels(1,"");

            Assert.IsTrue(res.Any());
        }

        [TestMethod]
        public void TestGetPanelsDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetPanelDetail(1, 1);

            Assert.IsTrue(res!=null);
        }

        [TestMethod]
        public void AddOrUpdatePanelsDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetPanelDetail(1, 1);            
            
            res.Title = "Titolo hjklhjkl 234";
            res.PanelContents.Add(new DomainModel.PanelContentDetail()
                                  {
                                      LanguageId = 1,
                                      PanelId = 1,
                                      ShortText = "Vacca troglia233",
                                      Text = "mmmminchia",
                                      Title = "pannello sostitutivo"
                                  });
            reportService.AddOrUpdatePanel(res);

            Assert.IsTrue(res != null);
        }

        [TestMethod]
        public void RemovePanelsDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            reportService.RemovePanel(3);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetChapterDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetChapterDetail(1, 1);

            Assert.IsTrue(res != null);
        }

        [TestMethod]
        public void TestGetChaptersList()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetChapters(1, "");

            Assert.IsTrue(res.Any());
        }

        [TestMethod]
        public void AddOrUpdateChapterDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetChapterDetail(1, 1);
            res.Panels.RemoveAt(0);
            res.Title = "Titolo nuovo capitolo 234";
           
            reportService.AddOrUpdateChapter(res);

            Assert.IsTrue(res != null);
        }

        [TestMethod]
        public void RemoveChapterDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            reportService.RemoveChapter(2);
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void TestGetReportDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetReportDetail(1, 1);

            Assert.IsTrue(res != null);
        }

        [TestMethod]
        public void TestGetReportsList()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetReports(1, "");

            Assert.IsTrue(res.Any());
        }

        [TestMethod]
        public void AddOrUpdateReportDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetReportDetail(1, 1);
            
            res.Title = "Titolo nuovo report 234";

            reportService.AddOrUpdateReport(res);

            Assert.IsTrue(res != null);
        }

        [TestMethod]
        public void RemoveReportDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            reportService.RemoveReport(1);
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void TestGetLevelDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetLevelDetail(1, 1);

            Assert.IsTrue(res != null);
        }

        [TestMethod]
        public void TestGetLevelsList()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetLevels(1, "");

            Assert.IsTrue(res.Any());
        }

        [TestMethod]
        public void AddOrUpdateLevelDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            var res = reportService.GetLevelDetail(1, 1);

            res.Name = "Titolo nuovo livello 234";

            reportService.AddOrUpdateLevel(res);

            Assert.IsTrue(res != null);
        }

        [TestMethod]
        public void RemoveLevelDetail()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            reportService.RemoveLevel(1);
            Assert.IsTrue(true);
        }
    }
}
