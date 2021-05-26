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

        [HttpGet]
        public IActionResult LogOut()
        {
            return View(nameof(Login));
        }

        [HttpPost]
        public IActionResult ValidateUser(User user)
        {
            if (ModelState.IsValid)
                return View("../Home/Index");

            return View(nameof(Login), user);
        }
    }
}
