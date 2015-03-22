namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "InsertDate", c => c.DateTime());
            AddColumn("dbo.Answers", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.AnswerWeights", "InsertDate", c => c.DateTime());
            AddColumn("dbo.AnswerWeights", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.PersonTypes", "InsertDate", c => c.DateTime());
            AddColumn("dbo.PersonTypes", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Products", "InsertDate", c => c.DateTime());
            AddColumn("dbo.Products", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Packages", "InsertDate", c => c.DateTime());
            AddColumn("dbo.Packages", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Questions", "InsertDate", c => c.DateTime());
            AddColumn("dbo.Questions", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.QuestionCategories", "InsertDate", c => c.DateTime());
            AddColumn("dbo.QuestionCategories", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Questionnaires", "InsertDate", c => c.DateTime());
            AddColumn("dbo.Questionnaires", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Languages", "InsertDate", c => c.DateTime());
            AddColumn("dbo.Languages", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.People", "InsertDate", c => c.DateTime());
            AddColumn("dbo.People", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.PersonAnswers", "InsertDate", c => c.DateTime());
            AddColumn("dbo.PersonAnswers", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.PersonQuestionnaires", "InsertDate", c => c.DateTime());
            AddColumn("dbo.PersonQuestionnaires", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.QuestionnaireResults", "InsertDate", c => c.DateTime());
            AddColumn("dbo.QuestionnaireResults", "UpdateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionnaireResults", "UpdateDate");
            DropColumn("dbo.QuestionnaireResults", "InsertDate");
            DropColumn("dbo.PersonQuestionnaires", "UpdateDate");
            DropColumn("dbo.PersonQuestionnaires", "InsertDate");
            DropColumn("dbo.PersonAnswers", "UpdateDate");
            DropColumn("dbo.PersonAnswers", "InsertDate");
            DropColumn("dbo.People", "UpdateDate");
            DropColumn("dbo.People", "InsertDate");
            DropColumn("dbo.Languages", "UpdateDate");
            DropColumn("dbo.Languages", "InsertDate");
            DropColumn("dbo.Questionnaires", "UpdateDate");
            DropColumn("dbo.Questionnaires", "InsertDate");
            DropColumn("dbo.QuestionCategories", "UpdateDate");
            DropColumn("dbo.QuestionCategories", "InsertDate");
            DropColumn("dbo.Questions", "UpdateDate");
            DropColumn("dbo.Questions", "InsertDate");
            DropColumn("dbo.Packages", "UpdateDate");
            DropColumn("dbo.Packages", "InsertDate");
            DropColumn("dbo.Products", "UpdateDate");
            DropColumn("dbo.Products", "InsertDate");
            DropColumn("dbo.PersonTypes", "UpdateDate");
            DropColumn("dbo.PersonTypes", "InsertDate");
            DropColumn("dbo.AnswerWeights", "UpdateDate");
            DropColumn("dbo.AnswerWeights", "InsertDate");
            DropColumn("dbo.Answers", "UpdateDate");
            DropColumn("dbo.Answers", "InsertDate");
        }
    }
}
