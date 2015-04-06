namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_kreo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Panels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PanelContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PanelId = c.Int(nullable: false),
                        LevelId = c.Int(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Levels", t => t.LevelId)
                .ForeignKey("dbo.Panels", t => t.PanelId, cascadeDelete: true)
                .Index(t => t.PanelId)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PanelContentTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        PanelContentId = c.Int(nullable: false),
                        Title = c.String(),
                        ShortText = c.String(),
                        Text = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.PanelContents", t => t.PanelContentId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.PanelContentId);
            
            CreateTable(
                "dbo.Snps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        Panel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Panels", t => t.Panel_Id)
                .Index(t => t.Panel_Id);
            
            CreateTable(
                "dbo.PanelTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PanelId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Title = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Panels", t => t.PanelId, cascadeDelete: true)
                .Index(t => t.PanelId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ReportTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                        Cover = c.String(),
                        ImageUri = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.ReportId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.ChapterTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        ChapterId = c.Int(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                        ImageUri = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chapters", t => t.ChapterId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.ChapterId);
            
            CreateTable(
                "dbo.LevelTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Text = c.String(),
                        ImageUri = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.PanelChapters",
                c => new
                    {
                        Panel_Id = c.Int(nullable: false),
                        Chapter_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Panel_Id, t.Chapter_Id })
                .ForeignKey("dbo.Panels", t => t.Panel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Chapters", t => t.Chapter_Id, cascadeDelete: true)
                .Index(t => t.Panel_Id)
                .Index(t => t.Chapter_Id);
            
            CreateTable(
                "dbo.ReportChapters",
                c => new
                    {
                        Report_Id = c.Int(nullable: false),
                        Chapter_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Report_Id, t.Chapter_Id })
                .ForeignKey("dbo.Reports", t => t.Report_Id, cascadeDelete: true)
                .ForeignKey("dbo.Chapters", t => t.Chapter_Id, cascadeDelete: true)
                .Index(t => t.Report_Id)
                .Index(t => t.Chapter_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LevelTranslations", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.LevelTranslations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ChapterTranslations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ChapterTranslations", "ChapterId", "dbo.Chapters");
            DropForeignKey("dbo.ReportTranslations", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.ReportTranslations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Reports", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ReportChapters", "Chapter_Id", "dbo.Chapters");
            DropForeignKey("dbo.ReportChapters", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.PanelTranslations", "PanelId", "dbo.Panels");
            DropForeignKey("dbo.PanelTranslations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Snps", "Panel_Id", "dbo.Panels");
            DropForeignKey("dbo.PanelContentTranslations", "PanelContentId", "dbo.PanelContents");
            DropForeignKey("dbo.PanelContentTranslations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.PanelContents", "PanelId", "dbo.Panels");
            DropForeignKey("dbo.PanelContents", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.PanelChapters", "Chapter_Id", "dbo.Chapters");
            DropForeignKey("dbo.PanelChapters", "Panel_Id", "dbo.Panels");
            DropIndex("dbo.ReportChapters", new[] { "Chapter_Id" });
            DropIndex("dbo.ReportChapters", new[] { "Report_Id" });
            DropIndex("dbo.PanelChapters", new[] { "Chapter_Id" });
            DropIndex("dbo.PanelChapters", new[] { "Panel_Id" });
            DropIndex("dbo.LevelTranslations", new[] { "LanguageId" });
            DropIndex("dbo.LevelTranslations", new[] { "LevelId" });
            DropIndex("dbo.ChapterTranslations", new[] { "ChapterId" });
            DropIndex("dbo.ChapterTranslations", new[] { "LanguageId" });
            DropIndex("dbo.ReportTranslations", new[] { "LanguageId" });
            DropIndex("dbo.ReportTranslations", new[] { "ReportId" });
            DropIndex("dbo.Reports", new[] { "ProductId" });
            DropIndex("dbo.PanelTranslations", new[] { "LanguageId" });
            DropIndex("dbo.PanelTranslations", new[] { "PanelId" });
            DropIndex("dbo.Snps", new[] { "Panel_Id" });
            DropIndex("dbo.PanelContentTranslations", new[] { "PanelContentId" });
            DropIndex("dbo.PanelContentTranslations", new[] { "LanguageId" });
            DropIndex("dbo.PanelContents", new[] { "LevelId" });
            DropIndex("dbo.PanelContents", new[] { "PanelId" });
            DropTable("dbo.ReportChapters");
            DropTable("dbo.PanelChapters");
            DropTable("dbo.LevelTranslations");
            DropTable("dbo.ChapterTranslations");
            DropTable("dbo.ReportTranslations");
            DropTable("dbo.Reports");
            DropTable("dbo.PanelTranslations");
            DropTable("dbo.Snps");
            DropTable("dbo.PanelContentTranslations");
            DropTable("dbo.Levels");
            DropTable("dbo.PanelContents");
            DropTable("dbo.Panels");
            DropTable("dbo.Chapters");
        }
    }
}
