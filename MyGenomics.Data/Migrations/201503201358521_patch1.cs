namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patch1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnswerWeights", "PersonTypeId", "dbo.PersonTypes");
            DropIndex("dbo.AnswerWeights", new[] { "PersonTypeId" });
            AlterColumn("dbo.AnswerWeights", "PersonTypeId", c => c.Int());
            CreateIndex("dbo.AnswerWeights", "PersonTypeId");
            AddForeignKey("dbo.AnswerWeights", "PersonTypeId", "dbo.PersonTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnswerWeights", "PersonTypeId", "dbo.PersonTypes");
            DropIndex("dbo.AnswerWeights", new[] { "PersonTypeId" });
            AlterColumn("dbo.AnswerWeights", "PersonTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.AnswerWeights", "PersonTypeId");
            AddForeignKey("dbo.AnswerWeights", "PersonTypeId", "dbo.PersonTypes", "Id", cascadeDelete: true);
        }
    }
}
