namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateResult : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionnaireResults", "WorseCaseTotal", c => c.Int(nullable: false));
            AddColumn("dbo.QuestionnaireResults", "PersonTotal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionnaireResults", "PersonTotal");
            DropColumn("dbo.QuestionnaireResults", "WorseCaseTotal");
        }
    }
}
