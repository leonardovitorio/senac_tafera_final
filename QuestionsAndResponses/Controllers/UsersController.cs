using Microsoft.AspNetCore.Mvc;
using QuestionsAndResponses.Data;
using QuestionsAndResponses.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _db;

        public UsersController(IUsersRepository db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Models.User> Users = _db.GetAll();
            return View(Users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var user = new Models.User();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(Models.User user)
        {
            var users = _db.SearchAll(new Repositories.Filters.UserFilter
            {
                EMail = user.EMail
            });
            user.CreatedIn = DateTime.Now;


            if (users.Count() == 0)
            {
                _db.Save(user);
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                return View(user);
            }

            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _db.GetItem(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Models.User user)
        {
            try
            {
                var current = _db.GetItem(user.Id);
                if(current.Password == user.Password)
                {
                    _db.Save(user);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(user);
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return View(user);
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _db.GetItem(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(Models.User user)
        {
            try
            {
                _db.Delete(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(user);
            }

            
        }
    }
}
