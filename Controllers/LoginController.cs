using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                ViewData["User"] = user.Email.Split("@")[0];
                return View("../Home/Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            return View(nameof(Login));
        }
    }
}
