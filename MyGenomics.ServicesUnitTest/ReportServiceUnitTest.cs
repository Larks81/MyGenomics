using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGenomics.DomainModel;
using MyGenomics.Services;
using MyGenomics.Services.Services;

namespace MyGenomics.ServicesUnitTest
{
    [TestClass]
    public class ReportServiceUnitTest
    {
        

        [TestMethod]
        public void TestPanelCrud()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();
            
            //Test insert new panel ITA
            var fakePanel = new PanelDetail()
            {
                LanguageId = 1,
                Title = "Inserimento nuovo pannello fake",
                PanelContents = new List<PanelContentDetail>()
                {
                    new PanelContentDetail()
                    {
                        LanguageId = 1,
                        LevelId = 4,
                        ShortText = "Inserimento nuovo ShortText contenuto pannello",
                        Text = "contenuto nuovo testo pannello",
                        Title = "titolo nuovo pannello"                                                        
                    }
                }
            };

            int idInserted = reportService.AddOrUpdatePanel(fakePanel);

            Assert.IsTrue(idInserted > 0);
 
            //Test Get panelJustInserted update and save
            var panelJustInserted = reportService.GetPanelDetail(1, idInserted);
            panelJustInserted.Title = "Nuovo titolo in italiano";
            int idUpdated = reportService.AddOrUpdatePanel(panelJustInserted);
            
            //Test add translation ENG (2)
            var panelToTranslate = reportService.GetPanelDetail(2, idInserted);
            panelToTranslate.Title = "New title in english";
            panelToTranslate.PanelContents[0].ShortText = "New text in english";
            int idTraslated = reportService.AddOrUpdatePanel(panelToTranslate);

            Assert.IsTrue(idTraslated > 0 && idTraslated == idUpdated);

            //Test if exists in list
            var listIta = reportService.GetPanels(1, "Nuovo titolo in italiano");
            Assert.IsTrue(listIta.Results.Any(p => p.Id == idUpdated && p.Title == "Nuovo titolo in italiano"));
            var listEng = reportService.GetPanels(2, "New title in english");
            Assert.IsTrue(listEng.Results.Any(p => p.Id == idUpdated && p.Title == "New title in english"));
            
            //Test delete
            reportService.RemovePanel(idUpdated);

            var panelCancelled = reportService.GetPanelDetail(1, idUpdated);
            Assert.IsTrue(panelCancelled==null);

        }

        
        [TestMethod]
        public void TestChapterCrud()
        {
            BaseDataService.InitializeServices();
            var reportService = new ReportService();

            //Test Add new Chapter
            var fakeChapter = new DomainModel.ChapterDetail()
            {
                Color = "#FFFFFF",
                ImageUri = "Test ImageUri",
                LanguageId = 1,
                Text = "Nuovo capitolo testo ITA",
                Title = "Nuovo capitolo titolo ITA",                                   
            };

            int idInserted = reportService.AddOrUpdateChapter(fakeChapter);
            Assert.IsTrue(idInserted>0);

            //Test Update ITA
            var chapterJustInserted = reportService.GetChapterDetail(1, idInserted);
            chapterJustInserted.Text = "Modifica testo";
            chapterJustInserted.Panels.Add(new PanelItemList()
                                           {
                                               Id = 1
                                           });
            int idUpdated = reportService.AddOrUpdateChapter(chapterJustInserted);

            var chapterToTranslate = reportService.GetChapterDetail(2, idUpdated);
            Assert.IsTrue(chapterToTranslate.Panels.Count==1);

            //Test Translate in english and remove a panel
            chapterToTranslate.Title = "Title in english";
            chapterToTranslate.Text = "Text in english";
            //chapterToTranslate.Panels.RemoveAt(1);
            int idTranlated = reportService.AddOrUpdateChapter(chapterToTranslate);
            
            //Test if exists in list
            var listIta = reportService.GetChapters(1, "Nuovo capitolo titolo ITA");
            Assert.IsTrue(listIta.Results.Any(p => p.Id == idUpdated && p.Title == "Nuovo capitolo titolo ITA"));
            var listEng = reportService.GetChapters(2, "Title in english");
            Assert.IsTrue(listEng.Results.Any(p => p.Id == idUpdated && p.Title == "Title in english"));

            //Test delete
            reportService.RemoveChapter(idUpdated);

            var chapterCancelled = reportService.GetChapterDetail(1, idUpdated);
            Assert.IsTrue(chapterCancelled == null);        
            
        }                

        [TestMethod]
        public void TestReportCrud()
        {
            BaseDataService.InitializeServices();
            var reportService = new ReportService();
            
            //Test insert new report in ITA
            var fakeReport = new ReportDetail()
                                {
                                    FrontCover = "cover.jpg",
                                    BackCover = "backcover",
                                    ImageUri = "new ImageUri",
                                    LanguageId = 1,
                                    ProductId = 1,
                                    Text = "Nuovo report di test testo",
                                    Title = "Titolo Nuovo report di test",
                                    Version = "1.0",
                                    Chapters = new List<ChapterItemList>()
                                            {
                                                new ChapterItemList()
                                                {
                                                    Id = 1
                                                }
                                            }
                                };
            int idInserted = reportService.AddOrUpdateReport(fakeReport);

            //Test get reportJustInserted
            var reportJustInserted = reportService.GetReportDetail(1, idInserted);
            Assert.IsTrue(reportJustInserted.Chapters.Count == 1);
            reportJustInserted.Title = "Titolo nuovo report";
            int idUpdated = reportService.AddOrUpdateReport(reportJustInserted);

            //Test translate
            var reportToTranslate = reportService.GetReportDetail(2, idUpdated);
            reportToTranslate.Title = "Title in english";
            reportToTranslate.Chapters.Clear();
            int idTranslated = reportService.AddOrUpdateReport(reportToTranslate);

            var reportJustUpdated = reportService.GetReportDetail(2, idTranslated);
            Assert.IsTrue(idTranslated == idUpdated && !reportJustUpdated.Chapters.Any());

            //Test if exists in list
            var listIta = reportService.GetReports(1, "Titolo nuovo report");
            Assert.IsTrue(listIta.Results.Any(p => p.Id == idUpdated && p.Title == "Titolo nuovo report"));
            var listEng = reportService.GetReports(2, "Title in english");
            Assert.IsTrue(listEng.Results.Any(p => p.Id == idUpdated && p.Title == "Title in english"));

            //Test delete
            reportService.RemoveReport(idUpdated);

            var reportCancelled = reportService.GetReportDetail(1, idUpdated);
            Assert.IsTrue(reportCancelled == null);
            
        }       

        [TestMethod]
        public void TestLevelCrud()
        {
            BaseDataService.InitializeServices();
            var reportService = new ReportService();

            //Test insert new level
            var fakeLevel = new LevelDetail()
                            {
                                ImageUri = "new ImageUri",
                                LanguageId = 1,
                                Name = "Livello Nuovo",
                                Text = "nuovo livello testo",
                                Value = 99
                            };

            int idInserted = reportService.AddOrUpdateLevel(fakeLevel);
            Assert.IsTrue(idInserted>0);

            //Test update
            var levelJustInserted = reportService.GetLevelDetail(1, idInserted);
            levelJustInserted.Text = "nuovo testo";
            levelJustInserted.Name = "nuovo nome";

            int idUpdated = reportService.AddOrUpdateLevel(levelJustInserted);
            Assert.IsTrue(idInserted == idUpdated);

            //Test Translate
            var levelToTranslate = reportService.GetLevelDetail(2, idInserted);
            levelToTranslate.Text = "text in english";
            int idtranslated = reportService.AddOrUpdateLevel(levelToTranslate);

            //Test if exists in list
            var listIta = reportService.GetLevels(1, "nuovo nome");
            Assert.IsTrue(listIta.Results.Any(p => p.Id == idUpdated && p.Name == "nuovo nome"));
            var listEng = reportService.GetLevels(2, "nuovo nome");
            Assert.IsTrue(listEng.Results.Any(p => p.Id == idUpdated && p.Name == "nuovo nome"));

            //Test delete
            reportService.RemoveLevel(idUpdated);

            var reportCancelled = reportService.GetLevelDetail(1, idUpdated);
            Assert.IsTrue(reportCancelled == null);
           
        }        


        [TestMethod]
        public void TestReportHeaderCrud()
        {
            BaseDataService.InitializeServices();

            var reportService = new ReportService();

            //Test Insert new ITA
            var fakeReportHeader = new ReportHeaderDetail()
                               {
                                   FirstPage = "text of firstPage",
                                   LanguageId = 1,
                                   SecondPage = "text of second page"                                                                       
                               };

            int idInserted = reportService.AddOrUpdateReportHeader(fakeReportHeader);

            //Test Update
            var reportHeaderJustInserted = reportService.GetReportHeaderDetail(1, idInserted);
            reportHeaderJustInserted.FirstPage = "First page new";

            int idUpdated = reportService.AddOrUpdateReportHeader(reportHeaderJustInserted);
            Assert.IsTrue(idInserted == idUpdated);

            //Test Translate
            var reportHeaderToTranslate = reportService.GetReportHeaderDetail(2, idUpdated);
            reportHeaderToTranslate.FirstPage = "First page in english";
            int idtranslated = reportService.AddOrUpdateReportHeader(reportHeaderToTranslate);

            //Test Remove
            reportService.RemoveReportHeader(idtranslated);
            var reportHeaderCancelled = reportService.GetReportHeaderDetail(1, idtranslated);
            Assert.IsTrue(reportHeaderCancelled == null);

        }
        
    }
}
