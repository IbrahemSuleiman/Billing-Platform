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
    public class E_CounterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: E_Counter
        public ActionResult Index()
        {
            return View(db.E_Counter.ToList());
        }

        public ActionResult ViewCounter()
        {
            var UserId = User.Identity.GetUserId();
            var e_counter = db.E_Counter.Where(c => c.UserId == UserId).SingleOrDefault();
            if (e_counter != null)
            {
                return View(e_counter);
            }
            else
            {
                ViewBag.Result = "يرجى الاشتراك بعداد كهرباء  قبل المحاولة.";
                return View();
            }
        }

        // GET: E_Counter/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Counter e_Counter = db.E_Counter.Find(id);
            if (e_Counter == null)
            {
                return HttpNotFound();
            }
            return View(e_Counter);
        }

        // GET: E_Counter/Create
        public ActionResult Create()
        {
            ViewBag.RegistrationType = new SelectList(new[] { "أحادي الطور 40 أمبير", "أحادي الطور 60 أمبير", "ثلاثي الطور" });

            return View();
        }

        // POST: E_Counter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SerialNumber,RegistrationType,CounterValue,RegistrationDate,UserId")] E_Counter e_Counter)
        {
            if (ModelState.IsValid)
            {
                var UserId = User.Identity.GetUserId();
                e_Counter.UserId = UserId;
                db.E_Counter.Add(e_Counter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(e_Counter);
        }

        // GET: E_Counter/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Counter e_Counter = db.E_Counter.Find(id);
            if (e_Counter == null)
            {
                return HttpNotFound();
            }
            return View(e_Counter);
        }

        // POST: E_Counter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SerialNumber,RegistrationType,CounterValue,RegistrationDate,UserId")] E_Counter e_Counter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Counter).State = EntityState.Modified;
                db.SaveChanges();
                E_Bill new_bill = new E_Bill();
                new_bill.UserId = e_Counter.UserId;

                var e_bil = db.E_Bill.Where(c => c.UserId == e_Counter.UserId).ToList();
                new_bill.Number = (e_bil.Count + 1).ToString();

                new_bill.DateofAnnounce = System.DateTime.Now.ToShortDateString();

                double s1 = 0, s2 = 0, s3 = 0, s4 = 0, s5=0;
                if (e_Counter.RegistrationType == "أحادي الطور 40 أمبير") { s1 = 1; s2 = 3; s3 = 4; s4 = 10; s5 = 29; }
                if (e_Counter.RegistrationType == "أحادي الطور 60 أمبير") { s1 = 1; s2 = 3; s3 = 4; s4 = 10; s5 = 29; }
                if (e_Counter.RegistrationType == "ثلاثي الطور") { s1 = 1; s2 = 3; s3 = 4; s4 = 10; s5 = 29; }

                var slice = (int.Parse(e_Counter.CounterValue));
                if (slice < 600)
                { new_bill.Price = (slice * s1).ToString(); new_bill.Notes = "فاتورة من الشريحة الأولى" + "-" + e_Counter.RegistrationType; }
                else if (slice < 1000)
                { new_bill.Price = ((600) * s1 + (slice - 600)*s2).ToString(); new_bill.Notes = "فاتورة من الشريحة الثانية" + "-" + e_Counter.RegistrationType; }
                else if (slice < 1500)
                { new_bill.Price = ((600) * s1 + (400) * s2 + (slice - 500) * s3).ToString(); new_bill.Notes = "فاتورة من الشريحة الثالثة" + "-" + e_Counter.RegistrationType; }
                else if (slice < 2500)
                { new_bill.Price = ((600) * s1 + (400) * s2 + (500) * s3 + (slice - 2500) * s4).ToString(); new_bill.Notes = "فاتورة من الشريحة الرابعة" + "-" + e_Counter.RegistrationType; }
                else 
                { new_bill.Price = ((600) * s1 + (400) * s2 + (500) * s3 + (1000) * s4 + (slice - 2500) * s5).ToString(); new_bill.Notes = "فاتورة من الشريحة الرابعة" + "-" + e_Counter.RegistrationType; }

                new_bill.Price = new_bill.Price + " ل.س " ;
                db.E_Bill.Add(new_bill);
                db.SaveChanges();
                return RedirectToAction("ViewCounter", "E_Counter");
            }
            return View(e_Counter);
        }

        // GET: E_Counter/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Counter e_Counter = db.E_Counter.Find(id);
            if (e_Counter == null)
            {
                return HttpNotFound();
            }
            return View(e_Counter);
        }

        // POST: E_Counter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Counter e_Counter = db.E_Counter.Find(id);
            db.E_Counter.Remove(e_Counter);
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
