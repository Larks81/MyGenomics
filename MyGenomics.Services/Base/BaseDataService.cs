using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using MyGenomics.Data.Context;

namespace MyGenomics.Services
{
    public static class BaseDataService
    {
        public static void InitializeServices()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyGenomicsContext, MyGenomics.Data.Migrations.Configuration>());
            InitAutomapper();
        }

        public static void InitAutomapper()
        {
            Mapper.CreateMap<DataModel.ContactQuestionnaire, DomainModel.ContactQuestionnaire>();
            Mapper.CreateMap<DomainModel.ContactQuestionnaire, DataModel.ContactQuestionnaire>();
            Mapper.CreateMap<DataModel.Contact, DomainModel.Contact>();
            Mapper.CreateMap<DomainModel.Contact, DataModel.Contact>();
            Mapper.CreateMap<DomainModel.ContactGivenAnswer, DataModel.ContactAnswer>();
            Mapper.CreateMap<DataModel.Product, DomainModel.Product>();
            Mapper.CreateMap<DataModel.Questionnaire, DomainModel.Questionnaire>();

            Mapper.CreateMap<DomainModel.WebApiLog, DataModel.WebApiLog>();

            Mapper.CreateMap<DomainModel.SubmitContactQuestionnaire, DataModel.ContactQuestionnaire>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.GivenAnswers)); ;

            Mapper.CreateMap<DataModel.ContactType, DomainModel.ContactType>();
            Mapper.CreateMap<DataModel.QuestionnaireResult, DomainModel.QuestionnaireResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductUrl, opt => opt.MapFrom(src => src.Product.UrlDetail))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.ProductShortDescription, opt => opt.MapFrom(src => src.Product.ShortDescription))
                .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Product.Description));

            Mapper.CreateMap<DataModel.Panel, DomainModel.PanelItemList>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Translations.Any() ? src.Translations.FirstOrDefault().Title : null))
                .ForMember(dest => dest.ContentsCount, opt => opt.MapFrom(src => src.PanelContents.Count()));

            Mapper.CreateMap<DomainModel.PanelDetail, DataModel.Panel>()
                .ForMember(dest => dest.Chapters, opt => opt.MapFrom(src => new List<DataModel.ChaptersPanels>()))
                .ForMember(dest => dest.Translations,
                    opt => opt.MapFrom(src => new List<DataModel.PanelTranslation>(){
                        new DataModel.PanelTranslation()
                        {
                            Id = src.TranslationId.GetValueOrDefault(0),
                            LanguageId = src.LanguageId,                        
                            Title = src.Title,
                            PanelId = src.Id
                        }
                    }));

            Mapper.CreateMap<DomainModel.ChapterDetail, DataModel.Chapter>()
                .ForMember(dest => dest.Reports,
                    opt => opt.MapFrom(src => src.Reports != null ? src.Reports.Select(c =>
                        new DataModel.ReportsChapters()
                        {
                            ReportId = c.Id,
                            ChapterId = src.Id
                        }) : null))
                .ForMember(dest => dest.Panels,
                    opt => opt.MapFrom(src => src.Panels!=null ? src.Panels.Select(c =>                        
                        new DataModel.ChaptersPanels()
                        {
                            PanelId = c.Id,
                            ChapterId = src.Id
                        }) : null))                
                .ForMember(dest => dest.Translations,
                    opt => opt.MapFrom(src => new List<DataModel.ChapterTranslation>(){
                        new DataModel.ChapterTranslation()
                        {
                            Id = src.TranslationId.GetValueOrDefault(0),
                            LanguageId = src.LanguageId,                        
                            Title = src.Title,
                            ChapterId = src.Id,
                            ImageUri = src.ImageUri,
                            Text = src.Text                            
                        }
                    }));

            Mapper.CreateMap<DomainModel.PanelContentDetail, DataModel.PanelContent>()
                .ForMember(dest => dest.Translations,
                    opt => opt.MapFrom(src => 
                        new List<DataModel.PanelContentTranslation>(){
                                new DataModel.PanelContentTranslation()
                                {
                                    Id = src.TranslationId.GetValueOrDefault(0),
                                    LanguageId = src.LanguageId,
                                    ShortText = src.ShortText,
                                    Text = src.Text,
                                    Title = src.Title,
                                    PanelContentId = src.Id
                                } 
                            }));

            Mapper.CreateMap<DomainModel.ReportDetail, DataModel.Report>()
                .ForMember(dest => dest.Chapters,
                    opt => opt.MapFrom(src => src.Chapters != null ? src.Chapters.Select(c =>
                        new DataModel.ReportsChapters()
                        {                            
                            ReportId = src.Id,
                            ChapterId = c.Id
                        }) : null))               
               .ForMember(dest => dest.Translations,
                   opt => opt.MapFrom(src => new List<DataModel.ReportTranslation>(){
                        new DataModel.ReportTranslation()
                        {
                            Id = src.TranslationId.GetValueOrDefault(0),
                            LanguageId = src.LanguageId,                        
                            Title = src.Title,
                            FrontCover = src.FrontCover,
                            BackCover = src.BackCover,
                            ImageUri = src.ImageUri,
                            ReportId = src.Id,
                            Text = src.Text                            
                        }
                    }));

            Mapper.CreateMap<DataModel.Product, DomainModel.ProductItemList>();

            Mapper.CreateMap<DomainModel.LevelDetail, DataModel.Level>()               
               .ForMember(dest => dest.Translations,
                   opt => opt.MapFrom(src => new List<DataModel.LevelTranslation>(){
                        new DataModel.LevelTranslation()
                        {
                            Id = src.TranslationId.GetValueOrDefault(0),
                            LanguageId = src.LanguageId,                                                                                
                            ImageUri = src.ImageUri,                            
                            Text = src.Text,      
                            LevelId = src.Id                            
                        }
                    }));

            Mapper.CreateMap<DomainModel.ReportHeaderDetail, DataModel.ReportHeader>()
               .ForMember(dest => dest.Translations,
                   opt => opt.MapFrom(src => new List<DataModel.ReportHeaderTranslation>(){
                        new DataModel.ReportHeaderTranslation()
                        {
                            Id = src.TranslationId.GetValueOrDefault(0),
                            LanguageId = src.LanguageId,                                                                                
                            FirstPage = src.FirstPage,
                            SecondPage = src.SecondPage,
                            ReportHeaderId = src.Id
                        }
                    }));

            Mapper.CreateMap<DataModel.ContactAnswer, DomainModel.ContactGivenAnswer>()
            .ForMember(dest => dest.AnswerText, opt => opt.MapFrom(src => src.Answer.Text))
            .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.Text));

        }
    }
}
