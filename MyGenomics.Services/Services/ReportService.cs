using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AutoMapper;
using MyGenomics.Data.Context;
using MyGenomics.Data.Migrations;
using MyGenomics.DataModel;

namespace MyGenomics.Services.Services
{
    public class ReportService
    {
        #region Crud Panels
        public List<DomainModel.PanelItemList> GetPanels(int languageId, string title = null)
        {
            using (var context = new MyGenomicsContext())
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    return context.Panels
                        .Include(i => i.Translations)
                        .Include(i => i.PanelContents)                        
                        .Select(p => new DomainModel.PanelItemList()
                                     {
                                         Id = p.Id,
                                         Title = p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title
                                     })
                        .ToList();
                }
                else
                {
                    return context.Panels
                        .Include(i => i.Translations)
                        .Include(i => i.PanelContents)
                        .Where(p => p.Translations.Any(t => t.Title.Contains(title) && t.LanguageId == languageId))
                        .Select(p => new DomainModel.PanelItemList()
                        {
                            Id = p.Id,
                            Title = p.Translations.FirstOrDefault().Title
                        })
                        .ToList();
                }
                
                
            }
        }

        public DomainModel.PanelDetail GetPanelDetail(int languageId, int id)
        {
            using (var context = new MyGenomicsContext())
            {                
                return context.Panels
                    .Include(i => i.Translations)
                    .Include(i => i.PanelContents)
                    .Include(i => i.Chapters)
                    .Select(p => new DomainModel.PanelDetail()
                        {
                            Id = p.Id,
                            LanguageId = languageId,
                            TranslationId = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Id : (int?)null,
                            Title = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                            PanelContents = p.PanelContents
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
                                        Id = c.Id,                                        
                                        Title = c.Translations.Any(t => t.LanguageId == languageId) ? c.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                                    }).ToList()                            
                        })
                    .First();
                
            }
            
        }

        public void AddOrUpdatePanel(DomainModel.PanelDetail panel)
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
                    context.Entry(panelMapped).State = EntityState.Added;
                }             

                context.SaveChanges();
            }            
        }

        public void RemovePanel(int panelId)
        {
            using (var context = new MyGenomicsContext())
            {
                context.Panels.Remove(context.Panels.FirstOrDefault(p => p.Id == panelId));
                context.SaveChanges();
            }
        }

        #endregion

        #region Crud Chapters
        public List<DomainModel.ChapterItemList> GetChapters(int languageId, string title = null)
        {
            using (var context = new MyGenomicsContext())
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    return context.Chapters
                        .Include(i => i.Translations)
                        .Select(p => new DomainModel.ChapterItemList()
                        {
                            Id = p.Id,
                            Title = p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title
                        })
                        .ToList();
                }
                else
                {
                    return context.Chapters
                        .Include(i => i.Translations)                        
                        .Where(p => p.Translations.Any(t => t.Title.Contains(title) && t.LanguageId == languageId))
                        .Select(p => new DomainModel.ChapterItemList()
                        {
                            Id = p.Id,
                            Title = p.Translations.FirstOrDefault().Title
                        })
                        .ToList();
                }
            }
        }

        public DomainModel.ChapterDetail GetChapterDetail(int languageId, int id)
        {
            using (var context = new MyGenomicsContext())
            {
                return context.Chapters
                    .Include(i => i.Translations)
                    .Include(i => i.Panels)
                    .Include(i => i.Reports)
                    .Select(p => new DomainModel.ChapterDetail()
                    {
                        Id = p.Id,
                        LanguageId = languageId,
                        TranslationId = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Id : (int?)null,
                        Title = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,                        
                        Panels = p.Panels
                                .Select(c => new DomainModel.PanelItemList()
                                {
                                    Id = c.Id,
                                    Title = c.Translations.Any(t => t.LanguageId == languageId) ? c.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                                }).ToList(),
                        Color = p.Color,
                        ImageUri = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).ImageUri : null,
                        Reports = p.Reports
                                .Select(c => new DomainModel.ReportItemList()
                                {
                                    Id = c.Id,
                                    Title = c.Translations.Any(t => t.LanguageId == languageId) ? c.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                                }).ToList(),
                    })
                    .First();
            }

        }

        public void AddOrUpdateChapter(DomainModel.ChapterDetail chapter)
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
                context.Entry(chapterMapped).State = EntityState.Modified;

                if (originalChapter != null)
                {
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
                    context.Entry(chapterMapped).State = EntityState.Added;
                }                

                context.SaveChanges();
            }

            //Update panels associations
            using (var context = new MyGenomicsContext())
            {
                var original = context.Chapters
                    .Include(i=>i.Panels)
                    .FirstOrDefault(c => c.Id == chapterMapped.Id);

                if (original.Panels.Any())
                {
                    original.Panels.Clear();
                }
                else
                {
                    original.Panels = new List<Panel>();
                }
                    
                //Pannelli associati
                foreach (var panel in chapter.Panels)
                {                                                             
                    var pan = context.Panels.FirstOrDefault(p => p.Id == panel.Id);
                    if (pan != null)
                    {
                        original.Panels.Add(pan);
                    }                                                              
                }

                context.SaveChanges();
            }
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

        public List<DomainModel.ReportItemList> GetReports(int languageId, string title = null)
        {
            using (var context = new MyGenomicsContext())
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    return context.Reports
                        .Include(i => i.Translations)
                        .Select(p => new DomainModel.ReportItemList()
                        {
                            Id = p.Id,
                            Title = p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title,
                            ProductId = p.ProductId
                        })
                        .ToList();
                }
                else
                {
                    return context.Reports
                        .Include(i => i.Translations)
                        .Where(p => p.Translations.Any(t => t.Title.Contains(title) && t.LanguageId == languageId))
                        .Select(p => new DomainModel.ReportItemList()
                        {
                            Id = p.Id,
                            Title = p.Translations.FirstOrDefault().Title,
                            ProductId = p.ProductId
                        })
                        .ToList();
                }
            }
        }

        public DomainModel.ReportDetail GetReportDetail(int languageId, int id)
        {
            using (var context = new MyGenomicsContext())
            {
                return context.Reports
                    .Include(i => i.Translations)
                    .Include(i => i.Chapters)                    
                    .Select(p => new DomainModel.ReportDetail()
                    {
                        Id = p.Id,
                        LanguageId = languageId,
                        TranslationId = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Id : (int?)null,
                        Title = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                        Chapters = p.Chapters
                                .Select(c => new DomainModel.ChapterItemList()
                                {
                                    Id = c.Id,
                                    Title = c.Translations.Any(t => t.LanguageId == languageId) ? c.Translations.FirstOrDefault(t => t.LanguageId == languageId).Title : null,
                                }).ToList(),
                        Cover = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Cover : null,
                        ImageUri = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).ImageUri : null,
                        ProductId = p.ProductId,
                        Text = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Text : null                        
                    })
                    .First();
            }
        }

        public void AddOrUpdateReport(DomainModel.ReportDetail report)
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
                context.Entry(reportMapped).State = EntityState.Modified;

                if (originalReport != null)
                {
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
                var original = context.Reports
                    .Include(i => i.Chapters)
                    .FirstOrDefault(c => c.Id == reportMapped.Id);

                if (original.Chapters.Any())
                {
                    original.Chapters.Clear();
                }
                else
                {
                    original.Chapters = new List<Chapter>();
                }

                //Pannelli associati
                foreach (var chapter in report.Chapters)
                {
                    var chap = context.Chapters.FirstOrDefault(p => p.Id == chapter.Id);
                    if (chap != null)
                    {
                        original.Chapters.Add(chap);
                    }
                }

                context.SaveChanges();
            }
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


        public List<DomainModel.LevelItemList> GetLevels(int languageId, string name = null)
        {
            using (var context = new MyGenomicsContext())
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return context.Levels
                        .Include(i => i.Translations)                        
                        .Select(p => new DomainModel.LevelItemList()
                        {
                            Id = p.Id,
                            Name = p.Name
                        })
                        .ToList();
                }
                else
                {
                    return context.Levels
                        .Include(i => i.Translations)
                        .Where(p => p.Name.Contains(name))
                        .Select(p => new DomainModel.LevelItemList()
                        {
                            Id = p.Id,
                            Name = p.Name
                        })
                        .ToList();
                }
            }
        }

        public DomainModel.LevelDetail GetLevelDetail(int languageId, int id)
        {
            using (var context = new MyGenomicsContext())
            {
                return context.Levels
                    .Include(i => i.Translations)                    
                    .Select(p => new DomainModel.LevelDetail()
                    {
                        Id = p.Id,
                        LanguageId = languageId,
                        TranslationId = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Id : (int?)null,
                        ImageUri = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).ImageUri : null,
                        Text = p.Translations.Any(t => t.LanguageId == languageId) ? p.Translations.FirstOrDefault(t => t.LanguageId == languageId).Text : null,
                        Name = p.Name                        
                    })
                    .First();
            }

        }

        public void AddOrUpdateLevel(DomainModel.LevelDetail level)
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
        }

        public void RemoveLevel(int levelId)
        {
            using (var context = new MyGenomicsContext())
            {
                context.Levels.Remove(context.Levels.FirstOrDefault(p => p.Id == levelId));
                context.SaveChanges();
            }
        }

    }
}
