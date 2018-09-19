using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        TaskContext db = new TaskContext();

        public ActionResult Index()
        {
            IEnumerable<Task> tasks = db.Task;
            return View(tasks);
        }

        [HttpGet]
        public ActionResult Add(string TaskName)
        {
            return View(TaskName);
        }
        [HttpPost]
        public ActionResult Add(Task task)
        {
            db.Task.Add(task);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Task b = db.Task.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Task b = db.Task.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Task.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Task task = db.Task.Find(id);
            if (task != null)
            {
                return View(task);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Task task)
        {
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}