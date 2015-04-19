namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportReportHeader : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "ReportHeaderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reports", "ReportHeaderId");
            AddForeignKey("dbo.Reports", "ReportHeaderId", "dbo.ReportHeaders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "ReportHeaderId", "dbo.ReportHeaders");
            DropIndex("dbo.Reports", new[] { "ReportHeaderId" });
            DropColumn("dbo.Reports", "ReportHeaderId");
        }
    }
}
