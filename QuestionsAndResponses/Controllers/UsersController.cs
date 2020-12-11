using Microsoft.AspNetCore.Mvc;
using QuestionsAndResponses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Models.User> Users = _db.Users;
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
            user.CreatedIn = DateTime.Now;
            if (_db.Users.Where(u => u.EMail == user.EMail).Count() == 0)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
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
            var user = _db.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Models.User user)
        {
            try
            {
                var current = _db.Users.Find(user.Id);
                if(current.Password == user.Password)
                {
                    current.Name = user.Name;
                    current.EMail = user.EMail;
                    _db.SaveChanges();
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
            var user = _db.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(Models.User user)
        {
            try
            {
                _db.Remove(user);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(user);
            }

            
        }
    }
}
