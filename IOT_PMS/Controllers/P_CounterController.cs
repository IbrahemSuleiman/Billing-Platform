using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IOT_PMS.Models;
using Microsoft.AspNet.Identity;

namespace IOT_PMS.Controllers
{
    [Authorize]
    public class P_CounterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: P_Counter
        public ActionResult Index()
        {
            return View(db.P_Counter.ToList());
        }

        // GET: P_Counter/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Counter p_Counter = db.P_Counter.Find(id);
            if (p_Counter == null)
            {
                return HttpNotFound();
            }
            return View(p_Counter);
        }

        // GET: P_Counter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: P_Counter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PhoneNumber,Duration")] P_Counter p_Counter)
        {
            if (ModelState.IsValid)
            {
                db.P_Counter.Add(p_Counter);
                var Userid = User.Identity.GetUserId();
                p_Counter.UserId = Userid;

                db.SaveChanges();

                P_Bill new_bill = new P_Bill();
                new_bill.UserId = p_Counter.UserId;

                var p_bill = db.E_Bill.Where(c => c.UserId == p_Counter.UserId).ToList();
                new_bill.Number = (p_bill.Count + 1).ToString();

                new_bill.DateofAnnounce = System.DateTime.Now.ToShortDateString();

                double w = 0;

                if (p_Counter.PhoneNumber.Substring(0,3) == "011") { w = 0.33; new_bill.Notes = "كلفة اتصال محلي - دمشق"; }
                if (p_Counter.PhoneNumber.Substring(0, 2) == "09") { w = 13; new_bill.Notes = "كلفة اتصال خليوي"; }
                else{ w = 3; new_bill.Notes = "كلفة اتصال بين المحافظات"; }

                new_bill.Price = (w * double.Parse(p_Counter.Duration)).ToString();
                   

                new_bill.Price = new_bill.Price + " ل.س ";

                db.P_Bill.Add(new_bill);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(p_Counter);
        }

        // GET: P_Counter/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Counter p_Counter = db.P_Counter.Find(id);
            if (p_Counter == null)
            {
                return HttpNotFound();
            }
            return View(p_Counter);
        }

        // POST: P_Counter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PhoneNumber,Duration,UserId")] P_Counter p_Counter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_Counter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_Counter);
        }

        // GET: P_Counter/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            P_Counter p_Counter = db.P_Counter.Find(id);
            if (p_Counter == null)
            {
                return HttpNotFound();
            }
            return View(p_Counter);
        }

        // POST: P_Counter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            P_Counter p_Counter = db.P_Counter.Find(id);
            db.P_Counter.Remove(p_Counter);
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

        public ActionResult PhoneCounter()
        {
            var UserId = User.Identity.GetUserId();
            var p_counter = db.P_Counter.Where(c => c.UserId == UserId).SingleOrDefault();
            if (p_counter != null)
            {
                return View(p_counter);
            }
            else
            {
                return View();
            }
        }
    }
}
