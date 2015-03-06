namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patch1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Gender");
        }
    }
}
