using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IOT_PMS.Models;

namespace IOT_PMS.Controllers
{
    public class E_BillController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: E_Bill
        public ActionResult Index()
        {
            return View(db.E_Bill.ToList());
        }

        // GET: E_Bill/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Bill e_Bill = db.E_Bill.Find(id);
            if (e_Bill == null)
            {
                return HttpNotFound();
            }
            return View(e_Bill);
        }

        // GET: E_Bill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: E_Bill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,DateofAnnounce,Price,Notes,UserId,user,CounterId")] E_Bill e_Bill)
        {
            if (ModelState.IsValid)
            {
                db.E_Bill.Add(e_Bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(e_Bill);
        }

        // GET: E_Bill/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Bill e_Bill = db.E_Bill.Find(id);
            if (e_Bill == null)
            {
                return HttpNotFound();
            }
            return View(e_Bill);
        }

        // POST: E_Bill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,DateofAnnounce,Price,Notes,UserId,user,CounterId")] E_Bill e_Bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e_Bill);
        }

        // GET: E_Bill/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Bill e_Bill = db.E_Bill.Find(id);
            if (e_Bill == null)
            {
                return HttpNotFound();
            }
            return View(e_Bill);
        }

        // POST: E_Bill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Bill e_Bill = db.E_Bill.Find(id);
            db.E_Bill.Remove(e_Bill);
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
