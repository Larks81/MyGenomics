namespace MyGenomics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patch2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "QuestionType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "QuestionType");
        }
    }
}
