namespace BuzzJean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnswersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        answer = c.String(),
                        value = c.Int(nullable: false),
                        question_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Questions", t => t.question_id)
                .Index(t => t.question_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "question_id", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "question_id" });
            DropTable("dbo.Answers");
        }
    }
}
