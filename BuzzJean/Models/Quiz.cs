using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuzzJean.Models
{
    [Table("Quizzes")]
    public class Quiz
    {
        public int id { get; set; }
        public string title { get; set; }
        public virtual List<Question> questions { get; set; }
    }

    public class Question
    {
        public int id { get; set; }
        public string question { get; set; }
        public virtual Quiz quiz { get; set; }
        public virtual List<Answer> answers { get; set; }
    }

    public class Answer
    {
        public int id { get; set; }
        public string answer { get; set; }
        public int value { get; set; }
        public virtual Question question { get; set; }
    }

    public class DbConnection:DbContext
    {
        public DbSet<Quiz>     Quizzes   { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer>   Answers   { get; set; }
    }
}