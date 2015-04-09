namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class versionInReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Version", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Version");
        }
    }
}
