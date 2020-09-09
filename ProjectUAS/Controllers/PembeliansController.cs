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
    public class PembeliansController : Controller
    {
        private kasetContext db = new kasetContext();

        // GET: Pembelians
        public ActionResult Index()
        {
            return View(db.Pembelians.ToList());
        }

        // GET: Pembelians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pembelian pembelian = db.Pembelians.Find(id);
            if (pembelian == null)
            {
                return HttpNotFound();
            }
            return View(pembelian);
        }

        // GET: Pembelians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pembelians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_user,id_kaset,jumlah,tanggal_pembelian,harga")] Pembelian pembelian)
        {
            if (ModelState.IsValid)
            {
                db.Pembelians.Add(pembelian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pembelian);
        }

        // GET: Pembelians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pembelian pembelian = db.Pembelians.Find(id);
            if (pembelian == null)
            {
                return HttpNotFound();
            }
            return View(pembelian);
        }

        // POST: Pembelians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_user,id_kaset,jumlah,tanggal_pembelian,harga")] Pembelian pembelian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pembelian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pembelian);
        }

        // GET: Pembelians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pembelian pembelian = db.Pembelians.Find(id);
            if (pembelian == null)
            {
                return HttpNotFound();
            }
            return View(pembelian);
        }

        // POST: Pembelians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pembelian pembelian = db.Pembelians.Find(id);
            db.Pembelians.Remove(pembelian);
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
