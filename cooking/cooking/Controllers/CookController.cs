using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cooking.Models;

namespace cooking.Controllers
{
    public class CookController : Controller
    {
        private Cookingdb db = new Cookingdb();

        //
        // GET: /Cook/

        public ActionResult Index()
        {
            return View(db.Cooks.ToList());
        }

        //
        // GET: /Cook/Details/5

        public ActionResult Details(int id = 0)
        {
            Cook cook = db.Cooks.Find(id);
            if (cook == null)
            {
                return HttpNotFound();
            }
            return View(cook);
        }

        //
        // GET: /Cook/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cook/Create

        [HttpPost]
        public ActionResult Create(Cook cook)
        {
            if (ModelState.IsValid)
            {
                db.Cooks.Add(cook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cook);
        }

        //
        // GET: /Cook/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cook cook = db.Cooks.Find(id);
            if (cook == null)
            {
                return HttpNotFound();
            }
            return View(cook);
        }

        //
        // POST: /Cook/Edit/5

        [HttpPost]
        public ActionResult Edit(Cook cook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cook);
        }

        //
        // GET: /Cook/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cook cook = db.Cooks.Find(id);
            if (cook == null)
            {
                return HttpNotFound();
            }
            return View(cook);
        }

        //
        // POST: /Cook/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cook cook = db.Cooks.Find(id);
            db.Cooks.Remove(cook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}