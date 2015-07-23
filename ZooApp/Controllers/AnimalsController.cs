using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;

namespace ZooApp.Controllers
{
    public class AnimalsController : Controller
    {
        private IAnimalServices _service;

        public AnimalsController(IAnimalServices service)
        {
            _service = service;
        }

        // GET: Animals
        public ActionResult Index()
        {
           
            return View(_service.List());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            if (ModelState.IsValid) 
            {
                _service.Create(animal);
                return RedirectToAction("Index");
            }
             
            return View();
            
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int id)
        {
            var original = _service.Find(id);
            return View(original);
        }

        // POST: Animals/Edit/5
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            if (ModelState.IsValid) {
            _service.Edit(animal);
            return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int id)
        {
            var original = _service.Find(id);
            return View(original);
        }

        // POST: Animals/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
               
        }
    }
}
