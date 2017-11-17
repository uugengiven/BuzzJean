namespace BuzzJean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeQuizs : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Quizs", newName: "Quizzes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Quizzes", newName: "Quizs");
        }
    }
}
