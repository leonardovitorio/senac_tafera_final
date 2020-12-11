using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionsAndResponses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Controllers
{
    public class ResponsesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ResponsesController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Models.Response> responses = _db.Responses;
            return View(responses);
        }

        [HttpGet]
        public IActionResult Create(int questionId)
        {
            var response = new Models.Response();
            response.QuestionId = questionId;

            var list = new List<SelectListItem>();
            foreach (var user in _db.Users)
            {
                list.Add(new SelectListItem
                {
                    Text = user.Name + "(" + user.EMail + ")",
                    Value = user.Id.ToString()
                });
            }

            ViewBag.users = list;
            return View(response);
        }

        [HttpPost]
        public IActionResult Create(Models.Response response)
        {
            response.CreatedIn = DateTime.Now;
            _db.Responses.Add(response);
            _db.SaveChanges();
            return Redirect("/Questions/Edit/"+response.QuestionId);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var response = _db.Questions.Find(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Edit(Models.Response response)
        {
            try
            {
                _db.Update(response);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(response);
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var response = _db.Questions.Find(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Delete(Models.Response response)
        {
            try
            {
                _db.Remove(response);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(response);
            }

            
        }
    }
}
