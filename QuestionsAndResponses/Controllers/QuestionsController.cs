using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionsAndResponses.Data;
using QuestionsAndResponses.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IUsersRepository usersRep;
        private readonly IQuestionRepository questionRep;
        private readonly IResponseRepository responseRep;

        public QuestionsController(IUsersRepository usersRep, IQuestionRepository questionRep, IResponseRepository responseRep)
        {
            this.usersRep = usersRep;
            this.questionRep = questionRep;
            this.responseRep = responseRep;
        }
        public IActionResult Index(string text)
        {
            var questions = questionRep.SearchAll(new Repositories.Filters.QuestionFilter { 
                Description = text
            });
            foreach(var question in questions)
            {
                question.User = usersRep.GetItem(question.UserId);
            }
            return View(questions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var question = new Models.Question();

            var list = new List<SelectListItem>();
            foreach(var user in usersRep.GetAll())
            {
                list.Add(new SelectListItem
                {
                    Text = user.Name + " (" + user.EMail + ")",
                    Value = user.Id.ToString()
                });
            }

            ViewBag.users = list;
            return View(question);
        }

        [HttpPost]
        public IActionResult Create(Models.Question question)
        {
            questionRep.Save(question);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var question = questionRep.GetItem(id);
            question.User = usersRep.GetItem(question.UserId);
            question.Responses = responseRep.SearchAll(new Repositories.Filters.ResponseFilter() { 
                QuestionId = question.Id
            }).ToList();
            return View(question);
        }

        [HttpPost]
        public IActionResult Edit(Models.Question question)
        {
            try
            {
                questionRep.Save(question);
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
            var question = questionRep.GetItem(id);
            return View(question);
        }

        [HttpPost]
        public IActionResult Delete(Models.Question question)
        {
            try
            {
                questionRep.Delete(question);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(question);
            }

            
        }
    }
}
