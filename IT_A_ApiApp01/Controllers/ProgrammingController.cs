using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_A_ApiApp01.Data;
using IT_A_ApiApp01.Models;

namespace IT_A_ApiApp01.Controllers
{
    public class ProgrammingController : Controller
    {
        private ProgrammingContext db = new ProgrammingContext();

        // GET: Programming
        public ActionResult Index()
        {
            return View(db.Programming.ToList());
        }

        // GET: Programming/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programming programming = db.Programming.Find(id);
            if (programming == null)
            {
                return HttpNotFound();
            }
            return View(programming);
        }

        // GET: Programming/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programming/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Image")] Programming programming)
        {
            if (ModelState.IsValid)
            {
                db.Programming.Add(programming);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programming);
        }

        // GET: Programming/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programming programming = db.Programming.Find(id);
            if (programming == null)
            {
                return HttpNotFound();
            }
            return View(programming);
        }

        // POST: Programming/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Image")] Programming programming)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programming).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programming);
        }

        // GET: Programming/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programming programming = db.Programming.Find(id);
            if (programming == null)
            {
                return HttpNotFound();
            }
            return View(programming);
        }

        // POST: Programming/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Programming programming = db.Programming.Find(id);
            db.Programming.Remove(programming);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
