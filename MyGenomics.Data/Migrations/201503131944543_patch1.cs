namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patch1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "UserName", c => c.String());
            AddColumn("dbo.People", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Password");
            DropColumn("dbo.People", "UserName");
        }
    }
}
