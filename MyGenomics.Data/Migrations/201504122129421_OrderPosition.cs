namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderPosition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PanelContents", "OrderPosition", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PanelContents", "OrderPosition");
        }
    }
}
