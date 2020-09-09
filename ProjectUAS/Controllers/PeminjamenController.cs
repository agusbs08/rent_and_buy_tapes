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
    public class PeminjamenController : Controller
    {
        private kasetContext db = new kasetContext();

        // GET: Peminjamen
        public ActionResult Index()
        {
            return View(db.Peminjamen.ToList());
        }

        // GET: Peminjamen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peminjaman peminjaman = db.Peminjamen.Find(id);
            if (peminjaman == null)
            {
                return HttpNotFound();
            }
            return View(peminjaman);
        }

        // GET: Peminjamen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peminjamen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_user,id_kaset,harga,tanggal_peminjaman,tanggal_pengembalian,status_kembali")] Peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                db.Peminjamen.Add(peminjaman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peminjaman);
        }

        // GET: Peminjamen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peminjaman peminjaman = db.Peminjamen.Find(id);
            if (peminjaman == null)
            {
                return HttpNotFound();
            }
            return View(peminjaman);
        }

        // POST: Peminjamen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_user,id_kaset,harga,tanggal_peminjaman,tanggal_pengembalian,status_kembali")] Peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peminjaman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peminjaman);
        }

        // GET: Peminjamen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peminjaman peminjaman = db.Peminjamen.Find(id);
            if (peminjaman == null)
            {
                return HttpNotFound();
            }
            return View(peminjaman);
        }

        // POST: Peminjamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Peminjaman peminjaman = db.Peminjamen.Find(id);
            db.Peminjamen.Remove(peminjaman);
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
