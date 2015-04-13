namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mmChaptersPanels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PanelChapters", "Panel_Id", "dbo.Panels");
            DropForeignKey("dbo.PanelChapters", "Chapter_Id", "dbo.Chapters");
            DropIndex("dbo.PanelChapters", new[] { "Panel_Id" });
            DropIndex("dbo.PanelChapters", new[] { "Chapter_Id" });
            CreateTable(
                "dbo.ChaptersPanels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PanelId = c.Int(nullable: false),
                        ChapterId = c.Int(nullable: false),
                        OrderPosition = c.Int(nullable: false),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chapters", t => t.ChapterId, cascadeDelete: true)
                .ForeignKey("dbo.Panels", t => t.PanelId, cascadeDelete: true)
                .Index(t => t.PanelId)
                .Index(t => t.ChapterId);
            
            DropTable("dbo.PanelChapters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PanelChapters",
                c => new
                    {
                        Panel_Id = c.Int(nullable: false),
                        Chapter_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Panel_Id, t.Chapter_Id });
            
            DropForeignKey("dbo.ChaptersPanels", "PanelId", "dbo.Panels");
            DropForeignKey("dbo.ChaptersPanels", "ChapterId", "dbo.Chapters");
            DropIndex("dbo.ChaptersPanels", new[] { "ChapterId" });
            DropIndex("dbo.ChaptersPanels", new[] { "PanelId" });
            DropTable("dbo.ChaptersPanels");
            CreateIndex("dbo.PanelChapters", "Chapter_Id");
            CreateIndex("dbo.PanelChapters", "Panel_Id");
            AddForeignKey("dbo.PanelChapters", "Chapter_Id", "dbo.Chapters", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PanelChapters", "Panel_Id", "dbo.Panels", "Id", cascadeDelete: true);
        }
    }
}
