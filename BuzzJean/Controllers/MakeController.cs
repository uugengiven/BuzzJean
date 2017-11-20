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

        // GET: Make/NewQuestion/:id
        [HttpGet]
        public ActionResult NewQuestion(int id)
        {
            ViewBag.quiz_id = id;
            return View();
        }

        // POST: Make/CreateQuestion
        [HttpPost]
        public ActionResult CreateQuestion(string question, int quiz_id)
        {
            //create a new question
            Question newQuestion = new Question();
            newQuestion.question = question;
            newQuestion.quiz = newConnection.Quizzes.Find(quiz_id);

            //save the question in the db
            newConnection.Questions.Add(newQuestion);
            newConnection.SaveChanges();

            //redirect to quiz page
            return RedirectToAction("Quiz", new { id = quiz_id });
        }

        public ActionResult newAnswer(int id)
        {
            Question question = newConnection.Questions.Find(id);
            return View(question);
        }

        public ActionResult ConfirmAnswer(string answer, int value, int question_id)
        {
            Answer temp = new Answer();
            temp.answer = answer;
            temp.value = value;
            temp.question = newConnection.Questions.Find(question_id);
            newConnection.Answers.Add(temp);
            newConnection.SaveChanges();
            return RedirectToAction("newAnswer", new { id = question_id});
        }
    }
}