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
            Mapper.CreateMap<DataModel.PersonQuestionnaire, DomainModel.PersonQuestionnaire>();
            Mapper.CreateMap<DataModel.Person, DomainModel.Person>();
            Mapper.CreateMap<DomainModel.Person, DataModel.Person>();
            Mapper.CreateMap<DomainModel.PersonGivenAnswer, DataModel.PersonAnswer>();

            Mapper.CreateMap<DomainModel.SubmitPersonQuestionnaire, DataModel.PersonQuestionnaire>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.GivenAnswers)); ;

            Mapper.CreateMap<DataModel.PersonType, DomainModel.PersonType>();
            Mapper.CreateMap<DataModel.QuestionnaireResult, DomainModel.QuestionnaireResult>()
                .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));

            Mapper.CreateMap<DataModel.PersonAnswer, DomainModel.PersonGivenAnswer>()
            .ForMember(dest => dest.AnswerText, opt => opt.MapFrom(src => src.Answer.Text))
            .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.Text));

        }
    }
}
