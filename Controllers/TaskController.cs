using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private static List<Models.Task> _Tasks;

        // GET: TaskController
        [HttpGet]
        public ActionResult Tasks()
        {
            InitializeList();
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _Tasks.Add(new Models.Task()
                {
                    Id = (_Tasks.Count == 0) ? 1 : _Tasks.Last().Id+1,
                    Title = collection["Title"],
                    Description = collection["Description"],
                    Attendant = collection["Attendant"]
                });
                return RedirectToAction(nameof(Tasks));
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
            return View(_Tasks[id-1]);
        }


        // GET: TaskController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_Tasks[id-1]);
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            int index = 0;
            try
            {
                index = int.Parse(collection["Id"]) - 1;
                _Tasks[index].Title = collection["Title"];
                _Tasks[index].Description = collection["Description"];
                _Tasks[index].Attendant = collection["Attendant"];
                return RedirectToAction(nameof(Tasks));
            }
            catch
            {
                return RedirectToAction(nameof(Tasks));
            }
        }

        // GET: TaskController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_Tasks[id-1]);
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(IFormCollection collection)
        {
            try
            {
                int id = int.Parse(collection["Id"]);
                _Tasks.Remove(_Tasks.Find(x => x.Id == id));

                return RedirectToAction(nameof(Tasks));
            }
            catch
            {
                return RedirectToAction(nameof(Tasks));
            }
        }

        private void InitializeList()
        {
            if (_Tasks == null)
            {
                _Tasks = new List<Models.Task>();
            }
        }
    }
}
