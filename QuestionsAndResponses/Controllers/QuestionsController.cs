using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionsAndResponses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public QuestionsController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Models.Question> questions = _db.Questions;
            foreach(var question in questions)
            {
                question.User = _db.Users.Find(question.UserId);
            }
            return View(questions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var question = new Models.Question();

            var list = new List<SelectListItem>();
            foreach(var user in _db.Users)
            {
                list.Add(new SelectListItem
                {
                    Text = user.Name + "(" + user.EMail + ")",
                    Value = user.Id.ToString()
                });
            }

            ViewBag.users = list;
            return View(question);
        }

        [HttpPost]
        public IActionResult Create(Models.Question question)
        {
            question.CreatedIn = DateTime.Now;
            _db.Questions.Add(question);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var question = _db.Questions.Find(id);
            question.User = _db.Users.Find(question.UserId);
            question.Responses = _db.Responses.Where(resp => resp.QuestionId == question.Id).ToList();
            return View(question);
        }

        [HttpPost]
        public IActionResult Edit(Models.Question question)
        {
            try
            {
                _db.Update(question);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(question);
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var question = _db.Questions.Find(id);
            return View(question);
        }

        [HttpPost]
        public IActionResult Delete(Models.Question question)
        {
            try
            {
                _db.Remove(question);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(question);
            }

            
        }
    }
}
