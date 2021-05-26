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
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public IActionResult ValidateUser(User user)
        {
            if(ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            return View("Login", user);
        }
    }
}
