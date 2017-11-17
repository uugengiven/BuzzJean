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
        DbConnection newConnection = new DbConnection();

        // GET: Make
        public ActionResult Index()
        {
            List<Quiz> quizzes = newConnection.Quizzes.ToList();
            return View(quizzes);
        }

        // GET: Make/Quiz/:id
        public ActionResult Quiz(int id)
        {
            //find which quiz
            Quiz currentQuiz = newConnection.Quizzes.Find(id);
            //pass quiz to view
            return View(currentQuiz);
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

            //save the quiz in the db
            newConnection.Quizzes.Add(newQuiz);
            newConnection.SaveChanges();

            //redirect to Index
            return RedirectToAction("Index");
        }
    }
}