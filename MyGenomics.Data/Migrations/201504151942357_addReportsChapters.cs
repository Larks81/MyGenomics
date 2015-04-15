namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReportsChapters : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReportChapters", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.ReportChapters", "Chapter_Id", "dbo.Chapters");
            DropIndex("dbo.ReportChapters", new[] { "Report_Id" });
            DropIndex("dbo.ReportChapters", new[] { "Chapter_Id" });
            CreateTable(
                "dbo.ReportsChapters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportId = c.Int(nullable: false),
                        ChapterId = c.Int(nullable: false),
                        OrderPosition = c.Int(nullable: false),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chapters", t => t.ChapterId, cascadeDelete: true)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.ReportId)
                .Index(t => t.ChapterId);
            
            DropTable("dbo.ReportChapters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReportChapters",
                c => new
                    {
                        Report_Id = c.Int(nullable: false),
                        Chapter_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Report_Id, t.Chapter_Id });
            
            DropForeignKey("dbo.ReportsChapters", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.ReportsChapters", "ChapterId", "dbo.Chapters");
            DropIndex("dbo.ReportsChapters", new[] { "ChapterId" });
            DropIndex("dbo.ReportsChapters", new[] { "ReportId" });
            DropTable("dbo.ReportsChapters");
            CreateIndex("dbo.ReportChapters", "Chapter_Id");
            CreateIndex("dbo.ReportChapters", "Report_Id");
            AddForeignKey("dbo.ReportChapters", "Chapter_Id", "dbo.Chapters", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReportChapters", "Report_Id", "dbo.Reports", "Id", cascadeDelete: true);
        }
    }
}
