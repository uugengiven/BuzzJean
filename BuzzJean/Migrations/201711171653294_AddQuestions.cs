namespace BuzzJean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        quiz_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Quizs", t => t.quiz_id)
                .Index(t => t.quiz_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "quiz_id", "dbo.Quizs");
            DropIndex("dbo.Questions", new[] { "quiz_id" });
            DropTable("dbo.Questions");
        }
    }
}
