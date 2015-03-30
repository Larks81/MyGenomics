namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log_duration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WebApiLogs", "Duration", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WebApiLogs", "Duration");
        }
    }
}
