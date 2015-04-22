namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_PractitionerReportKit_Entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PractitionerReportKits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PractitionerId = c.Int(),
                        ReportId = c.Int(),
                        KitId = c.Int(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kits", t => t.KitId)
                .ForeignKey("dbo.Practitioners", t => t.PractitionerId)
                .ForeignKey("dbo.Reports", t => t.ReportId)
                .Index(t => t.PractitionerId)
                .Index(t => t.ReportId)
                .Index(t => t.KitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PractitionerReportKits", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.PractitionerReportKits", "PractitionerId", "dbo.Practitioners");
            DropForeignKey("dbo.PractitionerReportKits", "KitId", "dbo.Kits");
            DropIndex("dbo.PractitionerReportKits", new[] { "KitId" });
            DropIndex("dbo.PractitionerReportKits", new[] { "ReportId" });
            DropIndex("dbo.PractitionerReportKits", new[] { "PractitionerId" });
            DropTable("dbo.PractitionerReportKits");
        }
    }
}
