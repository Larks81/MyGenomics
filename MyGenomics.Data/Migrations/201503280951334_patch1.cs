namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patch1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Languages", "Code", c => c.String());
            DropColumn("dbo.Languages", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Languages", "Name", c => c.String());
            DropColumn("dbo.Languages", "Code");
        }
    }
}
