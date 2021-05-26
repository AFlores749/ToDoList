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
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return RedirectToAction("Login", "Login");
        }

        public IActionResult ValidateUser([Bind("Email, Password")]User user)
        {
            if(ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Login", "Login");
        }
    }
}
