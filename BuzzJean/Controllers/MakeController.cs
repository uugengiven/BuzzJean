using BuzzJean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuzzJean.Controllers
{
    public class MakeController : Controller
    {
        // GET: Make
        public ActionResult Index()
        {
            return View();
        }

        // GET: Make/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

       // POST: Make/Create
       [HttpPost]
        public ActionResult Create(string title)
        {
            //create a new quiz
            Quiz newQuiz = new Quiz();
            newQuiz.title = title;

            //create an instance of the DBConnection
            DbConnection newConnection = new DbConnection();

            //save the quiz in the db
            newConnection.Quizzes.Add(newQuiz);
            newConnection.SaveChanges();

            //redirect to Index
            return RedirectToAction("Index");
        }
    }
}