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
    public class PengembaliansController : Controller
    {
        private kasetContext db = new kasetContext();

        // GET: Pengembalians
        public ActionResult Index()
        {
            return View(db.Pengembalians.ToList());
        }

        // GET: Pengembalians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pengembalian pengembalian = db.Pengembalians.Find(id);
            if (pengembalian == null)
            {
                return HttpNotFound();
            }
            return View(pengembalian);
        }

        // GET: Pengembalians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pengembalians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_peminjaman,denda")] Pengembalian pengembalian)
        {
            if (ModelState.IsValid)
            {
                db.Pengembalians.Add(pengembalian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pengembalian);
        }

        // GET: Pengembalians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pengembalian pengembalian = db.Pengembalians.Find(id);
            if (pengembalian == null)
            {
                return HttpNotFound();
            }
            return View(pengembalian);
        }

        // POST: Pengembalians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_peminjaman,denda")] Pengembalian pengembalian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pengembalian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pengembalian);
        }

        // GET: Pengembalians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pengembalian pengembalian = db.Pengembalians.Find(id);
            if (pengembalian == null)
            {
                return HttpNotFound();
            }
            return View(pengembalian);
        }

        // POST: Pengembalians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pengembalian pengembalian = db.Pengembalians.Find(id);
            db.Pengembalians.Remove(pengembalian);
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
