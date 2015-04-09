namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reportheader : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextColor = c.String(),
                        BaseColor = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportHeaderTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportHeaderId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        FirstPage = c.String(),
                        SecondPage = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.ReportHeaders", t => t.ReportHeaderId, cascadeDelete: true)
                .Index(t => t.ReportHeaderId)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportHeaderTranslations", "ReportHeaderId", "dbo.ReportHeaders");
            DropForeignKey("dbo.ReportHeaderTranslations", "LanguageId", "dbo.Languages");
            DropIndex("dbo.ReportHeaderTranslations", new[] { "LanguageId" });
            DropIndex("dbo.ReportHeaderTranslations", new[] { "ReportHeaderId" });
            DropTable("dbo.ReportHeaderTranslations");
            DropTable("dbo.ReportHeaders");
        }
    }
}
