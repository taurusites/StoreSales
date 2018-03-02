using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StorePayments.Models;

namespace StorePayments.Controllers
{
    public class StateNamesController : Controller
    {
        private DbDataContext db = new DbDataContext();

        // GET: StateNames
        public ActionResult Index()
        {
            return View(db.StateNames.ToList());
        }

        // GET: StateNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateNames stateNames = db.StateNames.Find(id);
            if (stateNames == null)
            {
                return HttpNotFound();
            }
            return View(stateNames);
        }

        // GET: StateNames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,StateName")] StateNames stateNames)
        {
            if (ModelState.IsValid)
            {
                db.StateNames.Add(stateNames);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stateNames);
        }

        // GET: StateNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateNames stateNames = db.StateNames.Find(id);
            if (stateNames == null)
            {
                return HttpNotFound();
            }
            return View(stateNames);
        }

        // POST: StateNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateId,StateName")] StateNames stateNames)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stateNames).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stateNames);
        }

        // GET: StateNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateNames stateNames = db.StateNames.Find(id);
            if (stateNames == null)
            {
                return HttpNotFound();
            }
            return View(stateNames);
        }

        // POST: StateNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StateNames stateNames = db.StateNames.Find(id);
            db.StateNames.Remove(stateNames);
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
