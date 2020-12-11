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
    public class ResponsesController : Controller
    {
        private readonly IUsersRepository usersRep;
        private readonly IQuestionRepository questionRep;
        private readonly IResponseRepository responseRep;


        public ResponsesController(IUsersRepository usersRep, IQuestionRepository questionRep, IResponseRepository responseRep)
        {
            this.usersRep = usersRep;
            this.questionRep = questionRep;
            this.responseRep = responseRep;
        }

        [HttpGet]
        public IActionResult Create(int questionId)
        {
            var response = new Models.Response();
            response.QuestionId = questionId;

            var list = new List<SelectListItem>();
            foreach (var user in usersRep.GetAll())
            {
                list.Add(new SelectListItem
                {
                    Text = user.Name + " (" + user.EMail + ")",
                    Value = user.Id.ToString()
                });
            }

            ViewBag.users = list;
            return View(response);
        }

        [HttpPost]
        public IActionResult Create(Models.Response response)
        {
            responseRep.Save(response);
            return Redirect("/Questions/Edit/"+response.QuestionId);
        }
    }
}
