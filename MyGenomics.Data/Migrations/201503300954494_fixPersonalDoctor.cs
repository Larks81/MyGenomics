namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixPersonalDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "PersonalDoctor", c => c.String());
            DropColumn("dbo.Contacts", "ContactalDoctor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "ContactalDoctor", c => c.String());
            DropColumn("dbo.Contacts", "PersonalDoctor");
        }
    }
}
