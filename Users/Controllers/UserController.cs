// Controllers/UserController.cs
using Microsoft.AspNetCore.Mvc;
using MVCUsers.Models;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    public class UserController : Controller
    {
        private static List<User> Users = new List<User>();

        public IActionResult Index()
        {   
            
            return View(Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Users.Count; // Przykładowe przypisanie Id
                Users.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = Users.Find(u => u.Id == user.Id);
                if (existingUser == null)
                {
                    return NotFound();
                }
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Age = user.Age;
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = Users.ElementAtOrDefault(id);
            if (user != null)
            {
                Users.RemoveAt(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
