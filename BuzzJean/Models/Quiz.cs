using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuzzJean.Models
{
    public class Quiz
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class DbConnection:DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
    }
}