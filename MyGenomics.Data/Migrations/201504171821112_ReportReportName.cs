namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportReportName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportHeaders", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReportHeaders", "Name");
        }
    }
}
