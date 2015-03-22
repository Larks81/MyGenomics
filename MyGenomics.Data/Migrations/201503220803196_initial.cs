namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        HasAdditionalInfo = c.Boolean(nullable: false),
                        AdditionalInfoType = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.AnswerWeights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerId = c.Int(nullable: false),
                        PersonTypeId = c.Int(),
                        ProductId = c.Int(nullable: false),
                        FromNumericAdditionalInfo = c.Int(nullable: false),
                        ToNumericAdditionalInfo = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonTypes", t => t.PersonTypeId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .Index(t => t.AnswerId)
                .Index(t => t.PersonTypeId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PersonTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Gender = c.Int(nullable: false),
                        AgeFrom = c.Int(nullable: false),
                        AgeTo = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        UrlDetail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShortDescription = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        StepNumber = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        QuestionType = c.Int(nullable: false),
                        QuestionnaireId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Questionnaires", t => t.QuestionnaireId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.QuestionnaireId);
            
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questionnaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        City = c.String(),
                        Address = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        BirthCity = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        PersonalDoctor = c.String(),
                        PersonTypeId = c.Int(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonTypes", t => t.PersonTypeId)
                .Index(t => t.PersonTypeId);
            
            CreateTable(
                "dbo.PersonAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                        AdditionalInfo = c.String(),
                        PersonQuestionnaire_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: false)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: false)
                .ForeignKey("dbo.PersonQuestionnaires", t => t.PersonQuestionnaire_Id, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.AnswerId)
                .Index(t => t.PersonQuestionnaire_Id);
            
            CreateTable(
                "dbo.PersonQuestionnaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        QuestionnaireId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Questionnaires", t => t.QuestionnaireId, cascadeDelete: true)
                .Index(t => t.QuestionnaireId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.QuestionnaireResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonQuestionnaireId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Result = c.Double(nullable: false),
                        NumberOfAnswer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.PersonQuestionnaires", t => t.PersonQuestionnaireId, cascadeDelete: true)
                .Index(t => t.PersonQuestionnaireId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PackageProducts",
                c => new
                    {
                        Package_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Package_Id, t.Product_Id })
                .ForeignKey("dbo.Packages", t => t.Package_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Package_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionnaireResults", "PersonQuestionnaireId", "dbo.PersonQuestionnaires");
            DropForeignKey("dbo.QuestionnaireResults", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PersonQuestionnaires", "QuestionnaireId", "dbo.Questionnaires");
            DropForeignKey("dbo.PersonQuestionnaires", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonAnswers", "PersonQuestionnaire_Id", "dbo.PersonQuestionnaires");
            DropForeignKey("dbo.PersonAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.PersonAnswers", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.People", "PersonTypeId", "dbo.PersonTypes");
            DropForeignKey("dbo.Questions", "QuestionnaireId", "dbo.Questionnaires");
            DropForeignKey("dbo.Questionnaires", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Questions", "CategoryId", "dbo.QuestionCategories");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.AnswerWeights", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.AnswerWeights", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PackageProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.PackageProducts", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.AnswerWeights", "PersonTypeId", "dbo.PersonTypes");
            DropIndex("dbo.PackageProducts", new[] { "Product_Id" });
            DropIndex("dbo.PackageProducts", new[] { "Package_Id" });
            DropIndex("dbo.QuestionnaireResults", new[] { "ProductId" });
            DropIndex("dbo.QuestionnaireResults", new[] { "PersonQuestionnaireId" });
            DropIndex("dbo.PersonQuestionnaires", new[] { "PersonId" });
            DropIndex("dbo.PersonQuestionnaires", new[] { "QuestionnaireId" });
            DropIndex("dbo.PersonAnswers", new[] { "PersonQuestionnaire_Id" });
            DropIndex("dbo.PersonAnswers", new[] { "AnswerId" });
            DropIndex("dbo.PersonAnswers", new[] { "QuestionId" });
            DropIndex("dbo.People", new[] { "PersonTypeId" });
            DropIndex("dbo.Questionnaires", new[] { "LanguageId" });
            DropIndex("dbo.Questions", new[] { "QuestionnaireId" });
            DropIndex("dbo.Questions", new[] { "CategoryId" });
            DropIndex("dbo.AnswerWeights", new[] { "ProductId" });
            DropIndex("dbo.AnswerWeights", new[] { "PersonTypeId" });
            DropIndex("dbo.AnswerWeights", new[] { "AnswerId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.PackageProducts");
            DropTable("dbo.QuestionnaireResults");
            DropTable("dbo.PersonQuestionnaires");
            DropTable("dbo.PersonAnswers");
            DropTable("dbo.People");
            DropTable("dbo.Languages");
            DropTable("dbo.Questionnaires");
            DropTable("dbo.QuestionCategories");
            DropTable("dbo.Questions");
            DropTable("dbo.Packages");
            DropTable("dbo.Products");
            DropTable("dbo.PersonTypes");
            DropTable("dbo.AnswerWeights");
            DropTable("dbo.Answers");
        }
    }
}
