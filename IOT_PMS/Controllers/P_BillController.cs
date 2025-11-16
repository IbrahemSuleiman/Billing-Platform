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
    public class P_BillController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: P_Bill
        public ActionResult Index()
        {
            return View(db.P_Bill.ToList());
        }

        // GET: P_Bill/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Bill p_Bill = db.P_Bill.Find(id);
            if (p_Bill == null)
            {
                return HttpNotFound();
            }
            return View(p_Bill);
        }

        // GET: P_Bill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Bill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,DateofAnnounce,Price,Notes,UserId")] P_Bill p_Bill)
        {
            if (ModelState.IsValid)
            {
                db.P_Bill.Add(p_Bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_Bill);
        }

        // GET: P_Bill/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Bill p_Bill = db.P_Bill.Find(id);
            if (p_Bill == null)
            {
                return HttpNotFound();
            }
            return View(p_Bill);
        }

        // POST: P_Bill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,DateofAnnounce,Price,Notes,UserId")] P_Bill p_Bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Bill);
        }

        // GET: P_Bill/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Bill p_Bill = db.P_Bill.Find(id);
            if (p_Bill == null)
            {
                return HttpNotFound();
            }
            return View(p_Bill);
        }

        // POST: P_Bill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            P_Bill p_Bill = db.P_Bill.Find(id);
            db.P_Bill.Remove(p_Bill);
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
