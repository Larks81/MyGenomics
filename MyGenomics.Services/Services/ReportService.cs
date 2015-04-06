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

    }
}
