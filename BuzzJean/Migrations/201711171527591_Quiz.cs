namespace BuzzJean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quiz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Quizs");
        }
    }
}
