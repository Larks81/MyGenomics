using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenomics.DataModel;

namespace MyGenomics.Data.Context
{
    public class MyGenomicsContext : DbContext
    {
        public MyGenomicsContext()            
        { }

        public DbSet<Answer> Answers { get; set; }        
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactAnswer> ContactAnswers { get; set; }
        public DbSet<ContactQuestionnaire> ContactQuestionnaires { get; set; }        
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AnswerWeight> AnswerWeights { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<QuestionnaireResult> QuestionnaireResults { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<WebApiLog> WebApiLogs { get; set; }

        //Kreo
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ChaptersPanels> ChaptersPanels { get; set; }
        public DbSet<ChapterTranslation> ChapterTranslations { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<LevelTranslation> LevelTranslations { get; set; }
        public DbSet<Panel> Panels { get; set; }
        public DbSet<PanelTranslation> PanelTranslations { get; set; }
        public DbSet<PanelContent> PanelContents { get; set; }
        public DbSet<PanelContentTranslation> PanelContentTranslations { get; set; }        
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportTranslation> ReportTranslations { get; set; }
        public DbSet<ReportHeader> ReportHeaders { get; set; }
        public DbSet<ReportHeaderTranslation> ReportHeaderTranslations { get; set; }
        public DbSet<Snp> Snps { get; set; }
       
    }
}
