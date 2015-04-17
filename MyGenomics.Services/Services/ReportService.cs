using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AutoMapper;
using MyGenomics.Data.Context;
using MyGenomics.Data.Migrations;
using MyGenomics.DataModel;
using MyGenomics.DomainModel;

namespace MyGenomics.Services.Services
{
    public class ReportService
    {
        private const int maxItemInPage = 10;

        #region Crud Panels
        public SearchList<DomainModel.PanelItemList> GetPanels(int languageId, string title = null, int page = 1)
        {
            var result = new SearchList<DomainModel.PanelItemList>();

            using (var context = new MyGenomicsContext())
            {
                if (string.IsNullOrWhiteSpace(title))
                {                    
                    result.TotRec = context.Panels.Count();
                    result.CurrentPage = page;
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.Panels
                        .Include(i => i.Translations)
                        .Include(i => i.PanelContents)
                        .OrderBy(p => p.Id)
                        .Skip(maxItemInPage * (page - 1)).Take(maxItemInPage)
                        .Select(p => new DomainModel.PanelItemList()
                                     {
                                         Id = p.Id,
                                         Title = p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title,
                                         ContentsCount = p.PanelContents.Count()
                                     })
                        .ToList();
                }
                else
                {
                    result.TotRec = context.Panels.Count(p => p.Translations.Any(t => t.Title.Contains(title) && t.LanguageId == languageId));
                    result.CurrentPage = page;
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.Panels
                        .Include(i => i.Translations)
                        .Include(i => i.PanelContents)
                        .OrderBy(p => p.Id)
                        .Skip(maxItemInPage * (page - 1)).Take(maxItemInPage)
                        .Where(p => p.Translations.Any(t => t.Title.Contains(title) && t.LanguageId == languageId))
                        .Select(p => new DomainModel.PanelItemList()
                        {
                            Id = p.Id,
                            Title = p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title,
                            ContentsCount = p.PanelContents.Count()
                        })
                        .ToList();
                }                               
            }

            return result;
        }

        public DomainModel.PanelDetail GetPanelDetail(int languageId, int id)
        {
            using (var context = new MyGenomicsContext())
            {
                
                var res = context.Panels
                    .Include(i => i.Translations)
                    .Include(i => i.PanelContents)
                    .Include(i => i.Chapters)
                    .Where(p=>p.Id == id)
                    .Select(p => new DomainModel.PanelDetail()
                        {
                            Id = p.Id,
                            LanguageId = languageId,
                            TranslationId = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Id : (int?)null,
                            Title = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                            PanelContents = p.PanelContents.OrderBy(pc=>pc.OrderPosition)
                                    .Select(c => new DomainModel.PanelContentDetail()
                                    {
                                        Id = c.Id,
                                        TranslationId = c.Translations.Any(t => t.LanguageId == languageId) ? c.Translations.FirstOrDefault(t => t.LanguageId == languageId).Id : (int?)null,
                                        LanguageId = languageId,
                                        LevelId = c.LevelId,
                                        Title = c.Translations.Any(t => t.LanguageId == languageId) ? c.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                                        ShortText = c.Translations.Any(t=>t.LanguageId==languageId) ? c.Translations.FirstOrDefault(t => t.LanguageId == languageId).ShortText : null,
                                        Text = c.Translations.Any(t => t.LanguageId == languageId)  ? c.Translations.FirstOrDefault(t => t.LanguageId == languageId).Text : null,
                                        PanelId = p.Id                                        
                                    } ).ToList(),
                            Chapters = p.Chapters
                                    .Select(c => new DomainModel.ChapterItemList()
                                    {
                                        Id = c.Chapter.Id,
                                        Title = c.Chapter.Translations.Any(t => t.LanguageId == languageId) ? c.Chapter.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                                    }).ToList()                            
                        })
                    .FirstOrDefault();

                if (res != null && res.PanelContents.Any())
                {
                    int count = 1;
                    foreach (var pc in res.PanelContents)
                    {
                        pc.OrderPosition = count++;
                    }
                }

                return res;
            }
            
        }

        public int AddOrUpdatePanel(DomainModel.PanelDetail panel)
        {
            var languageId = panel.LanguageId;
            var panelMapped = Mapper.Map<DomainModel.PanelDetail, DataModel.Panel>(panel);
            DataModel.Panel originalPanel;

            using (var context = new MyGenomicsContext())
            {
                originalPanel = context.Panels
                    .Include(i => i.Translations)
                    .Include(i => i.PanelContents)
                    .Include(i => i.PanelContents.Select(pc => pc.Translations))
                    .FirstOrDefault(p => p.Id == panelMapped.Id);
            }


            using (var context = new MyGenomicsContext())
            {

                if (originalPanel != null)
                {
                    //context.Entry(panelMapped).State = EntityState.Modified;

                    //Translations
                    foreach (var translation in panelMapped.Translations)
                    {
                        if (translation.Id > 0)
                        {
                            context.Entry(translation).State = EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(translation).State = EntityState.Added;
                        }
                    }

                    //Contents
                    foreach (var panelContents in panelMapped.PanelContents)
                    {
                        if (panelContents.Id > 0)
                        {
                            context.Entry(panelContents).State = EntityState.Modified;

                            foreach (var panelContentTranslation in panelContents.Translations)
                            {
                                if (panelContentTranslation.Id > 0)
                                {
                                    context.Entry(panelContentTranslation).State = EntityState.Modified;
                                }
                                else
                                {
                                    context.Entry(panelContentTranslation).State = EntityState.Added;
                                }
                            }

                        }
                        else
                        {
                            context.Entry(panelContents).State = EntityState.Added;
                        }
                    }

                    foreach (var panelContent in originalPanel.PanelContents)
                    {
                        if (panelMapped.PanelContents.All(pc => pc.Id != panelContent.Id))
                        {
                            context.PanelContents.Remove(
                                context.PanelContents.FirstOrDefault(pc => pc.Id == panelContent.Id));
                            //context.Entry(panelContent).State = EntityState.Deleted;
                        }
                    }

                }
                else
                {
                    panelMapped.Chapters = null;
                    //context.Entry(panelMapped).State = EntityState.Added;
                    context.Panels.Add(panelMapped);
                }             

                context.SaveChanges();
            }

            return panelMapped.Id;
        }

        public void RemovePanel(int panelId)
        {
            using (var context = new MyGenomicsContext())
            {
                var panel = context.Panels.FirstOrDefault(p => p.Id == panelId);
                if (panel != null)
                {
                    context.Panels.Remove(panel);
                    context.SaveChanges();
                }
            }
        }

        #endregion

        #region Crud Chapters
        public SearchList<DomainModel.ChapterItemList> GetChapters(int languageId, string title = null, int page = 1)
        {
            var result = new SearchList<DomainModel.ChapterItemList>();

            using (var context = new MyGenomicsContext())
            {
                result.CurrentPage = page;

                if (string.IsNullOrWhiteSpace(title))
                {
                    result.TotRec = context.Chapters.Count();                    
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.Chapters
                        .Include(i => i.Translations)
                        .OrderBy(c => c.Id)
                        .Skip(maxItemInPage * (page - 1)).Take(maxItemInPage)
                        .Select(p => new DomainModel.ChapterItemList()
                        {
                            Id = p.Id,
                            Title = p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title,
                            PanelsCount = p.Panels.Count()
                        })
                        .ToList();
                }
                else
                {
                    result.TotRec = context.Chapters.Count(p => p.Translations.Any(t => t.Title.Contains(title) && t.LanguageId == languageId));
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.Chapters
                        .Include(i => i.Translations)                        
                        .Where(p => p.Translations.Any(t => t.Title.Contains(title) && t.LanguageId == languageId))
                        .OrderBy(c=>c.Id)
                        .Skip(maxItemInPage * (page - 1)).Take(maxItemInPage)
                        .Select(p => new DomainModel.ChapterItemList()
                        {
                            Id = p.Id,
                            Title = p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title,
                            PanelsCount = p.Panels.Count()
                        })
                        .ToList();
                }                
            }
            return result;
        }

        public DomainModel.ChapterDetail GetChapterDetail(int languageId, int id)
        {
            using (var context = new MyGenomicsContext())
            {
                var res = context.Chapters
                    .Include(i => i.Translations)
                    .Include(i => i.Panels.Select(p=>p.Panel))
                    .Include(i => i.Reports)
                    .Where(c=>c.Id == id)
                    .Select(p => new DomainModel.ChapterDetail()
                    {
                        Id = p.Id,
                        LanguageId = languageId,
                        TranslationId = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Id : (int?)null,
                        Title = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,                        
                        Panels = p.Panels.OrderBy(pc=>pc.OrderPosition)
                                .Select(c => c!=null ? new DomainModel.PanelItemList()
                                {
                                    Id = c.Panel.Id,
                                    Title = c.Panel.Translations.Any(t => t.LanguageId == languageId) ? c.Panel.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                                } : null).ToList(),
                        Color = p.Color,
                        ImageUri = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).ImageUri : null,
                        Reports = p.Reports
                                .Select(c => c!=null ? new DomainModel.ReportItemList()
                                {
                                    Id = c.Id,
                                    Title = c.Report.Translations.Any(t => t.LanguageId == languageId) ? c.Report.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                                } : null).ToList(),
                        Text = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Text : null,                        
                    })
                    .FirstOrDefault();

                if (res != null && res.Panels.Any())
                {
                    int count = 1;
                    foreach (var pc in res.Panels)
                    {
                        pc.OrderPosition = count++;
                    }
                }

                return res;
            }

        }

        public int AddOrUpdateChapter(DomainModel.ChapterDetail chapter)
        {
            var languageId = chapter.LanguageId;
            var chapterMapped = Mapper.Map<DomainModel.ChapterDetail, DataModel.Chapter>(chapter);
            DataModel.Chapter originalChapter;

            using (var context = new MyGenomicsContext())
            {
                originalChapter = context.Chapters
                    .Include(i => i.Translations)
                    .Include(i=> i.Panels)
                    .FirstOrDefault(p => p.Id == chapterMapped.Id);
            }


            using (var context = new MyGenomicsContext())
            {
                
                if (originalChapter != null)
                {
                    chapterMapped.Panels = null;
                    chapterMapped.Reports = null;                    

                    context.Entry(chapterMapped).State = EntityState.Modified;

                    //Translations
                    foreach (var translation in chapterMapped.Translations)
                    {
                        if (translation.Id > 0)
                        {
                            context.Entry(translation).State = EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(translation).State = EntityState.Added;
                        }
                    }                                       
                }
                else
                {
                    //context.Chapters.Add(chapterMapped);
                    context.Entry(chapterMapped).State = EntityState.Added;
                }                

                context.SaveChanges();
            }

            
            //Update panels associations
            using (var context = new MyGenomicsContext())
            {
                    
                context.ChaptersPanels.RemoveRange(
                    context.ChaptersPanels.Where(cp => cp.ChapterId == chapterMapped.Id));

                context.SaveChanges();

                if (chapter.Panels != null && chapter.Panels.Any())
                {
                    var original = context.Chapters
                        .Include(i => i.Panels.Select(p => p.Panel))
                        .FirstOrDefault(c => c.Id == chapterMapped.Id);

                    //Pannelli associati
                    foreach (var panel in chapter.Panels)
                    {

                        var pan = context.Panels.FirstOrDefault(p => p.Id == panel.Id);
                        if (pan != null)
                        {
                            original.Panels.Add(new ChaptersPanels()
                                                {
                                                    PanelId = pan.Id,
                                                    ChapterId = chapterMapped.Id
                                                });
                        }
                    }

                    context.SaveChanges();
                }
            }            

            return chapterMapped.Id;
        }

        public void RemoveChapter(int chapterId)
        {
            using (var context = new MyGenomicsContext())
            {
                context.Chapters.Remove(context.Chapters.FirstOrDefault(p => p.Id == chapterId));
                context.SaveChanges();
            }
        }

        #endregion

        #region Crud Reports

        public SearchList<DomainModel.ReportItemList> GetReports(int languageId, string title = null, int page = 1)
        {
            var result = new SearchList<DomainModel.ReportItemList>();
            result.CurrentPage = page;

            using (var context = new MyGenomicsContext())
            {
                
                if (string.IsNullOrWhiteSpace(title))
                {
                    result.TotRec = context.Chapters.Count();
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.Reports
                        .Include(i => i.Translations)
                        .Include(i => i.Product)
                        .Include(i => i.Chapters)
                        .Select(p => new DomainModel.ReportItemList()
                        {
                            Id = p.Id,
                            Title = p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title,
                            ProductName = p.Product.Name,
                            Version = p.Version,
                            ChaptersCount = p.Chapters.Count()
                        })
                        .ToList();
                }
                else
                {
                    result.TotRec = context.Chapters.Count(p => p.Translations.Any(t => t.Title.Contains(title) && t.LanguageId == languageId));
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.Reports
                        .Include(i => i.Translations)
                        .Include(i => i.Product)
                        .Include(i => i.Chapters)
                        .Where(p => p.Translations.Any(t => t.Title.Contains(title) && t.LanguageId == languageId))
                        .Select(p => new DomainModel.ReportItemList()
                        {
                            Id = p.Id,
                            Title = p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title,
                            ProductName = p.Product.Name,
                            Version = p.Version,
                            ChaptersCount = p.Chapters.Count()
                        })
                        .ToList();
                }
            }
            return result;
        }

        public DomainModel.ReportDetail GetReportDetail(int languageId, int id)
        {
            using (var context = new MyGenomicsContext())
            {
                var a = context.Reports
                    .Include(i => i.Translations)
                    .Include(i => i.Chapters.Select(c=>c.Chapter))          
                    .Where(r=> r.Id == id)
                    .Select(p => new DomainModel.ReportDetail()
                    {
                        Id = p.Id,
                        LanguageId = languageId,
                        TranslationId = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Id : (int?)null,
                        Title = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                        Chapters = p.Chapters
                                .Select(c => new DomainModel.ChapterItemList()
                                {
                                    Id = c.Chapter.Id,
                                    Title = c.Chapter.Translations.Any(t => t.LanguageId == languageId) ? c.Chapter.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                                    OrderPosition = c.OrderPosition
                                }).ToList(),
                        FrontCover = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).FrontCover : null,
                        BackCover = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).BackCover : null,
                        ImageUri = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).ImageUri : null,
                        ProductId = p.ProductId,
                        Text = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Text : null,
                        Version = p.Version
                    })
                    .FirstOrDefault();
                return a;
            }
        }

        public int AddOrUpdateReport(DomainModel.ReportDetail report)
        {
            var languageId = report.LanguageId;
            var reportMapped = Mapper.Map<DomainModel.ReportDetail, DataModel.Report>(report);
            DataModel.Report originalReport;

            using (var context = new MyGenomicsContext())
            {
                originalReport = context.Reports
                    .Include(i => i.Translations)
                    .Include(i => i.Chapters)
                    .FirstOrDefault(p => p.Id == reportMapped.Id);
            }


            using (var context = new MyGenomicsContext())
            {
                
                if (originalReport != null)
                {
                    reportMapped.Chapters = null;
                    reportMapped.Product = null;                    
                    context.Entry(reportMapped).State = EntityState.Modified;

                    //Translations
                    foreach (var translation in reportMapped.Translations)
                    {
                        if (translation.Id > 0)
                        {
                            context.Entry(translation).State = EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(translation).State = EntityState.Added;
                        }
                    }
                }
                else
                {
                    context.Entry(reportMapped).State = EntityState.Added;
                }

                context.SaveChanges();
            }

            //Update panels associations
            using (var context = new MyGenomicsContext())
            {

                context.ReportsChapters.RemoveRange(context.ReportsChapters.Where(cp => cp.ReportId == reportMapped.Id));
                context.SaveChanges();

                var original = context.Reports
                        .Include(i => i.Chapters.Select(p => p.Chapter))
                        .FirstOrDefault(c => c.Id == reportMapped.Id);

                //Pannelli associati
                foreach (var chapter in report.Chapters)
                {

                    var chap = context.Chapters.FirstOrDefault(p => p.Id == chapter.Id);
                    if (chap != null)
                    {
                        original.Chapters.Add(new ReportsChapters()
                                            {
                                                ChapterId = chap.Id,
                                                ReportId = reportMapped.Id,
                                                OrderPosition = chapter.OrderPosition
                                            });
                    }
                }

                context.SaveChanges();
                
            }

            return reportMapped.Id;
        }       

        public void RemoveReport(int reportId)
        {
            using (var context = new MyGenomicsContext())
            {
                context.Reports.Remove(context.Reports.FirstOrDefault(p => p.Id == reportId));
                context.SaveChanges();
            }
        }

        #endregion


       

        #region Crud Levels

        public SearchList<DomainModel.LevelItemList> GetLevels(int languageId, string name = null, int page = 1)
        {
            var result = new SearchList<DomainModel.LevelItemList>();
            result.CurrentPage = page;

            using (var context = new MyGenomicsContext())
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    result.TotRec = context.Levels.Count();
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.Levels
                        .Include(i => i.Translations)                        
                        .Select(p => new DomainModel.LevelItemList()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Value = p.Value
                        })
                        .ToList();
                }
                else
                {
                    result.TotRec = context.Levels.Count(p => p.Name.Contains(name));
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.Levels
                        .Include(i => i.Translations)
                        .Where(p => p.Name.Contains(name))
                        .Select(p => new DomainModel.LevelItemList()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Value = p.Value
                        })
                        .ToList();
                }
            }
            return result;
        }

        public DomainModel.LevelDetail GetLevelDetail(int languageId, int id)
        {
            using (var context = new MyGenomicsContext())
            {
                return context.Levels
                    .Include(i => i.Translations)  
                    .Where(l => l.Id == id)
                    .Select(p => new DomainModel.LevelDetail()
                    {
                        Id = p.Id,
                        LanguageId = languageId,
                        TranslationId = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Id : (int?)null,
                        ImageUri = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).ImageUri : null,
                        Text = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Text : null,
                        Name = p.Name,
                        Value = p.Value
                    })
                    .FirstOrDefault();
            }

        }

        public int AddOrUpdateLevel(DomainModel.LevelDetail level)
        {
            var languageId = level.LanguageId;
            var levelMapped = Mapper.Map<DomainModel.LevelDetail, DataModel.Level>(level);
            DataModel.Level originalLevel;

            using (var context = new MyGenomicsContext())
            {
                originalLevel = context.Levels
                    .Include(i => i.Translations)
                    .FirstOrDefault(p => p.Id == levelMapped.Id);
            }


            using (var context = new MyGenomicsContext())
            {

                if (originalLevel != null)
                {
                    context.Entry(levelMapped).State = EntityState.Modified;

                    //Translations
                    foreach (var translation in levelMapped.Translations)
                    {
                        if (translation.Id > 0)
                        {
                            context.Entry(translation).State = EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(translation).State = EntityState.Added;
                        }
                    }                    
                }
                else
                {
                    context.Entry(levelMapped).State = EntityState.Added;
                }

                context.SaveChanges();
            }

            return levelMapped.Id;
        }

        public void RemoveLevel(int levelId)
        {
            using (var context = new MyGenomicsContext())
            {
                context.Levels.Remove(context.Levels.FirstOrDefault(p => p.Id == levelId));
                context.SaveChanges();
            }
        }
        #endregion

        public DomainModel.ReportHeaderDetail GetReportHeaderDetail(int languageId, int id)
        {
            using (var context = new MyGenomicsContext())
            {
                return context.ReportHeaders
                    .Include(i => i.Translations)
                    .Where(rh => rh.Id == id)
                    .Select(p => new DomainModel.ReportHeaderDetail()
                    {
                        Id = p.Id,
                        LanguageId = languageId,
                        TranslationId = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Id : (int?)null,
                        FirstPage = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).FirstPage : null,
                        SecondPage = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).SecondPage : null,
                    })
                    .FirstOrDefault();
            }

        }

        public int AddOrUpdateReportHeader(DomainModel.ReportHeaderDetail reportHeader)
        {
            var languageId = reportHeader.LanguageId;
            var reportHeaderMapped = Mapper.Map<DomainModel.ReportHeaderDetail, DataModel.ReportHeader>(reportHeader);
            DataModel.ReportHeader originalReportHeader;

            using (var context = new MyGenomicsContext())
            {
                originalReportHeader = context.ReportHeaders
                    .Include(i => i.Translations)
                    .FirstOrDefault(p => p.Id == reportHeaderMapped.Id);
            }


            using (var context = new MyGenomicsContext())
            {

                if (originalReportHeader != null)
                {
                    context.Entry(reportHeaderMapped).State = EntityState.Modified;

                    //Translations
                    foreach (var translation in reportHeaderMapped.Translations)
                    {
                        if (translation.Id > 0)
                        {
                            context.Entry(translation).State = EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(translation).State = EntityState.Added;
                        }
                    }
                }
                else
                {
                    context.Entry(reportHeaderMapped).State = EntityState.Added;
                }

                context.SaveChanges();
            }

            return reportHeaderMapped.Id;
        }

        public void RemoveReportHeader(int reportHeaderId)
        {
            using (var context = new MyGenomicsContext())
            {
                context.ReportHeaders.Remove(context.ReportHeaders.FirstOrDefault(p => p.Id == reportHeaderId));
                context.SaveChanges();
            }
        }
    }
}
