using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4.data;

namespace MVC4.Controllers
{
    public class AirlineController : Controller
    {
        private dbContext db = new dbContext();

        //
        // GET: /Airline/

        public ActionResult Index()
        {
            return View(db.Airlines.ToList());
        }

        //
        // GET: /Airline/Details/5

        public ActionResult Details(long id = 0)
        {
            Airline airline = db.Airlines.Find(id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            return View(airline);
        }

        //
        // GET: /Airline/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Airline/Create

        [HttpPost]
        public ActionResult Create(Airline airline)
        {
            if (ModelState.IsValid)
            {
                db.Airlines.Add(airline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airline);
        }

        //
        // GET: /Airline/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Airline airline = db.Airlines.Find(id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            return View(airline);
        }

        //
        // POST: /Airline/Edit/5

        [HttpPost]
        public ActionResult Edit(Airline airline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airline);
        }

        //
        // GET: /Airline/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Airline airline = db.Airlines.Find(id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            return View(airline);
        }

        //
        // POST: /Airline/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Airline airline = db.Airlines.Find(id);
            db.Airlines.Remove(airline);
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