using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyGenomics.Data.Context;
using MyGenomics.DomainModel;

namespace MyGenomics.Services.Services
{
    public class ReportHeaderService
    {
        private const int maxItemInPage = 10;

        public SearchList<DomainModel.ReportHeaderItemList> GetReportHeaders(int languageId, string name = null, int page = 1)
        {
            var result = new SearchList<DomainModel.ReportHeaderItemList>();
            result.CurrentPage = page;

            using (var context = new MyGenomicsContext())
            {

                if (string.IsNullOrWhiteSpace(name))
                {
                    result.TotRec = context.ReportHeaders.Count();
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.ReportHeaders
                        .Include(i => i.Translations)
                        .Select(p => new DomainModel.ReportHeaderItemList()
                        {
                            Id = p.Id,
                            Name = p.Name                            
                        })
                        .ToList();
                }
                else
                {
                    result.TotRec = context.Chapters.Count(p => p.Translations.Any(t => t.Title.Contains(name) && t.LanguageId == languageId));
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.ReportHeaders
                        .Include(i => i.Translations)                        
                        .Where(p => p.Name.Contains(name))
                        .Select(p => new DomainModel.ReportHeaderItemList()
                        {
                            Id = p.Id,
                            Name = p.Name     
                        })
                        .ToList();
                }
            }
            return result;
        }

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
                        Name = p.Name,
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
