using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenomics.Model;

namespace MyGenomics.Data.Context
{
    public class MyGenomicsContext : DbContext
    {
        public MyGenomicsContext()            
        { }

        public DbSet<Answer> Answers { get; set; }        
        public DbSet<Person> People { get; set; }
        public DbSet<PersonAnswer> PersonAnswers { get; set; }
        public DbSet<PersonQuestionnaire> PersonQuestionnaires { get; set; }        
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AnswerWeight> AnswerWeights { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<QuestionnaireResult> QuestionnaireResults { get; set; }
    }
}
