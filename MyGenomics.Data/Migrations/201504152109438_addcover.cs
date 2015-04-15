namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcover : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportTranslations", "FrontCover", c => c.String());
            AddColumn("dbo.ReportTranslations", "BackCover", c => c.String());
            DropColumn("dbo.ReportTranslations", "Cover");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportTranslations", "Cover", c => c.String());
            DropColumn("dbo.ReportTranslations", "BackCover");
            DropColumn("dbo.ReportTranslations", "FrontCover");
        }
    }
}
