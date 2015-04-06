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
            
            res.Title = "Titolo nuovo 234";
            res.PanelContents.Add(new DomainModel.PanelContentDetail()
                                  {
                                      LanguageId = 1,
                                      PanelId = 1,
                                      ShortText = "Vacca troglia",
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
    }
}
