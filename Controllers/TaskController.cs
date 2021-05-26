using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private static List<Models.Task> _Tasks;

        // GET: TaskController
        [HttpGet]
        public ActionResult Tasks()
        {
            InitializeObjects();
            // Obtener el usuario y desplegar botones conforme a permisos entre otras validaciones
            return View(_Tasks);
        }

        // GET: TaskController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Task TaskObj)
        {
            try
            {
                _Tasks.Add(new Models.Task()
                {
                    Id = (_Tasks.Count == 0) ? 1 : _Tasks.Last().Id+1,
                    Title = TaskObj.Title,
                    Description = TaskObj.Description,
                    Attendant = TaskObj.Attendant
                });
                return RedirectToAction("Tasks");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_Tasks.Find(x => x.Id == id));
        }


        // GET: TaskController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_Tasks.Find(x => x.Id == id));
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Task TaskObj)
        {
            //int index = 0;
            try
            {
                Models.Task ViewModel = _Tasks.FirstOrDefault(x => x.Id == TaskObj.Id);
                ViewModel.Title = TaskObj.Title;
                ViewModel.Description = TaskObj.Description;
                ViewModel.Attendant = TaskObj.Attendant;
                return View(nameof(Tasks), _Tasks);
            }
            catch
            {
                return View(nameof(Tasks), _Tasks);
            }
        }

        // GET: TaskController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_Tasks.Find(x => x.Id == id));
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.Task TaskObj)
        {
            _Tasks.Remove(_Tasks.Find(x => x.Id == TaskObj.Id));
            return View(nameof(Tasks), _Tasks);
        }

        private void InitializeObjects()
        {
            if (_Tasks == null)
            {
                _Tasks = new List<Models.Task>();
            }
        }
    }
}
