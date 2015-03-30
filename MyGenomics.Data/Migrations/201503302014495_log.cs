namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WebApiLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        HttpVerb = c.String(),
                        Date = c.DateTime(nullable: false),
                        RequestUri = c.String(),
                        RequestBody = c.String(),
                        ResponseBody = c.String(),
                        Exception = c.String(),
                        ClientIp = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WebApiLogs");
        }
    }
}
