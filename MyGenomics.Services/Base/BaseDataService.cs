using System;
using System.Data.Entity;
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
            Mapper.CreateMap<DataModel.Contact, DomainModel.Contact>();
            Mapper.CreateMap<DomainModel.Contact, DataModel.Contact>();
            Mapper.CreateMap<DomainModel.ContactGivenAnswer, DataModel.ContactAnswer>();

            Mapper.CreateMap<DomainModel.SubmitContactQuestionnaire, DataModel.ContactQuestionnaire>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.GivenAnswers)); ;

            Mapper.CreateMap<DataModel.ContactType, DomainModel.ContactType>();
            Mapper.CreateMap<DataModel.QuestionnaireResult, DomainModel.QuestionnaireResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductUrl, opt => opt.MapFrom(src => src.Product.UrlDetail))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.ProductShortDescription, opt => opt.MapFrom(src => src.Product.ShortDescription))
                .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Product.Description));

            Mapper.CreateMap<DataModel.ContactAnswer, DomainModel.ContactGivenAnswer>()
            .ForMember(dest => dest.AnswerText, opt => opt.MapFrom(src => src.Answer.Text))
            .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.Text));

        }
    }
}
