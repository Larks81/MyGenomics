namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pathPTNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "PersonTypeId", "dbo.PersonTypes");
            DropIndex("dbo.People", new[] { "PersonTypeId" });
            AlterColumn("dbo.People", "PersonTypeId", c => c.Int());
            CreateIndex("dbo.People", "PersonTypeId");
            AddForeignKey("dbo.People", "PersonTypeId", "dbo.PersonTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "PersonTypeId", "dbo.PersonTypes");
            DropIndex("dbo.People", new[] { "PersonTypeId" });
            AlterColumn("dbo.People", "PersonTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "PersonTypeId");
            AddForeignKey("dbo.People", "PersonTypeId", "dbo.PersonTypes", "Id", cascadeDelete: true);
        }
    }
}
