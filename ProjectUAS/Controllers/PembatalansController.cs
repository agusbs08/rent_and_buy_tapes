using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectUAS.DAL;
using ProjectUAS.Models;

namespace ProjectUAS.Controllers
{
    public class PembatalansController : Controller
    {
        private kasetContext db = new kasetContext();

        // GET: Pembatalans
        public ActionResult Index()
        {
            return View(db.Pembatalans.ToList());
        }

        // GET: Pembatalans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pembatalan pembatalan = db.Pembatalans.Find(id);
            if (pembatalan == null)
            {
                return HttpNotFound();
            }
            return View(pembatalan);
        }

        // GET: Pembatalans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pembatalans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_pemesanan,denda,refund")] Pembatalan pembatalan)
        {
            if (ModelState.IsValid)
            {
                db.Pembatalans.Add(pembatalan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pembatalan);
        }

        // GET: Pembatalans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pembatalan pembatalan = db.Pembatalans.Find(id);
            if (pembatalan == null)
            {
                return HttpNotFound();
            }
            return View(pembatalan);
        }

        // POST: Pembatalans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_pemesanan,denda,refund")] Pembatalan pembatalan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pembatalan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pembatalan);
        }

        // GET: Pembatalans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pembatalan pembatalan = db.Pembatalans.Find(id);
            if (pembatalan == null)
            {
                return HttpNotFound();
            }
            return View(pembatalan);
        }

        // POST: Pembatalans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pembatalan pembatalan = db.Pembatalans.Find(id);
            db.Pembatalans.Remove(pembatalan);
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
