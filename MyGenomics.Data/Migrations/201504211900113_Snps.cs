namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Snps : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Snps", "Panel_Id", "dbo.Panels");
            DropIndex("dbo.Snps", new[] { "Panel_Id" });
            RenameColumn(table: "dbo.Snps", name: "Panel_Id", newName: "PanelId");
            CreateTable(
                "dbo.KitResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KitId = c.Int(nullable: false),
                        PanelId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kits", t => t.KitId, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .ForeignKey("dbo.Panels", t => t.PanelId, cascadeDelete: true)
                .Index(t => t.KitId)
                .Index(t => t.PanelId)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Kits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Code = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.SnpGenotypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KitId = c.Int(nullable: false),
                        PanelId = c.Int(),
                        SnpId = c.Int(),
                        Genotype = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kits", t => t.KitId, cascadeDelete: true)
                .ForeignKey("dbo.Panels", t => t.PanelId)
                .ForeignKey("dbo.Snps", t => t.SnpId)
                .Index(t => t.KitId)
                .Index(t => t.PanelId)
                .Index(t => t.SnpId);
            
            AddColumn("dbo.Snps", "SNPCode", c => c.String());
            AddColumn("dbo.Snps", "Gene", c => c.String());
            AddColumn("dbo.Snps", "Allelerisk", c => c.String());
            AddColumn("dbo.Snps", "OR_Beta", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "P_value", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "CC", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "CT", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "TC", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "TT", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "AA", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "AG", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "GA", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "GG", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "CG", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "GC", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "AC", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "CA", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "GT", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "TG", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "AT", c => c.Double(nullable: false));
            AddColumn("dbo.Snps", "TA", c => c.Double(nullable: false));
            AlterColumn("dbo.Snps", "PanelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Snps", "PanelId");
            AddForeignKey("dbo.Snps", "PanelId", "dbo.Panels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Snps", "PanelId", "dbo.Panels");
            DropForeignKey("dbo.SnpGenotypes", "SnpId", "dbo.Snps");
            DropForeignKey("dbo.SnpGenotypes", "PanelId", "dbo.Panels");
            DropForeignKey("dbo.SnpGenotypes", "KitId", "dbo.Kits");
            DropForeignKey("dbo.KitResults", "PanelId", "dbo.Panels");
            DropForeignKey("dbo.KitResults", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.KitResults", "KitId", "dbo.Kits");
            DropForeignKey("dbo.Kits", "ContactId", "dbo.Contacts");
            DropIndex("dbo.SnpGenotypes", new[] { "SnpId" });
            DropIndex("dbo.SnpGenotypes", new[] { "PanelId" });
            DropIndex("dbo.SnpGenotypes", new[] { "KitId" });
            DropIndex("dbo.Kits", new[] { "ContactId" });
            DropIndex("dbo.KitResults", new[] { "LevelId" });
            DropIndex("dbo.KitResults", new[] { "PanelId" });
            DropIndex("dbo.KitResults", new[] { "KitId" });
            DropIndex("dbo.Snps", new[] { "PanelId" });
            AlterColumn("dbo.Snps", "PanelId", c => c.Int());
            DropColumn("dbo.Snps", "TA");
            DropColumn("dbo.Snps", "AT");
            DropColumn("dbo.Snps", "TG");
            DropColumn("dbo.Snps", "GT");
            DropColumn("dbo.Snps", "CA");
            DropColumn("dbo.Snps", "AC");
            DropColumn("dbo.Snps", "GC");
            DropColumn("dbo.Snps", "CG");
            DropColumn("dbo.Snps", "GG");
            DropColumn("dbo.Snps", "GA");
            DropColumn("dbo.Snps", "AG");
            DropColumn("dbo.Snps", "AA");
            DropColumn("dbo.Snps", "TT");
            DropColumn("dbo.Snps", "TC");
            DropColumn("dbo.Snps", "CT");
            DropColumn("dbo.Snps", "CC");
            DropColumn("dbo.Snps", "P_value");
            DropColumn("dbo.Snps", "OR_Beta");
            DropColumn("dbo.Snps", "Allelerisk");
            DropColumn("dbo.Snps", "Gene");
            DropColumn("dbo.Snps", "SNPCode");
            DropTable("dbo.SnpGenotypes");
            DropTable("dbo.Kits");
            DropTable("dbo.KitResults");
            RenameColumn(table: "dbo.Snps", name: "PanelId", newName: "Panel_Id");
            CreateIndex("dbo.Snps", "Panel_Id");
            AddForeignKey("dbo.Snps", "Panel_Id", "dbo.Panels", "Id");
        }
    }
}
