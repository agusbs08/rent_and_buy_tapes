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
    public class PemesanansController : Controller
    {
        private kasetContext db = new kasetContext();

        // GET: Pemesanans
        public ActionResult Index()
        {
            return View(db.Pemesanans.ToList());
        }

        // GET: Pemesanans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pemesanan pemesanan = db.Pemesanans.Find(id);
            if (pemesanan == null)
            {
                return HttpNotFound();
            }
            return View(pemesanan);
        }

        // GET: Pemesanans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pemesanans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_user,id_kaset,jumlah,tanggal_pemesanan,harga,status")] Pemesanan pemesanan)
        {
            if (ModelState.IsValid)
            {
                db.Pemesanans.Add(pemesanan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pemesanan);
        }

        // GET: Pemesanans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pemesanan pemesanan = db.Pemesanans.Find(id);
            if (pemesanan == null)
            {
                return HttpNotFound();
            }
            return View(pemesanan);
        }

        // POST: Pemesanans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_user,id_kaset,jumlah,tanggal_pemesanan,harga,status")] Pemesanan pemesanan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pemesanan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pemesanan);
        }

        // GET: Pemesanans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pemesanan pemesanan = db.Pemesanans.Find(id);
            if (pemesanan == null)
            {
                return HttpNotFound();
            }
            return View(pemesanan);
        }

        // POST: Pemesanans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pemesanan pemesanan = db.Pemesanans.Find(id);
            db.Pemesanans.Remove(pemesanan);
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
