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
using System.IO;

namespace ProjectUAS.Controllers
{
    public class KasetsController : Controller
    {
        private kasetContext db = new kasetContext();

        // GET: Kasets
        public ActionResult Index()
        {
            return View(db.Kasets.ToList());
        }

        // GET: Kasets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaset kaset = db.Kasets.Find(id);
            if (kaset == null)
            {
                return HttpNotFound();
            }
            return View(kaset);
        }

        // GET: Kasets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kasets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nama,harga_sewa,harga_beli,stok,diskon,imageFile")] Kaset kaset)
        {
            kaset.jumlah_pencarian = 0;
            string filename = Path.GetFileNameWithoutExtension(kaset.imageFile.FileName);
            string extension = Path.GetExtension(kaset.imageFile.FileName);
            filename = DateTime.Now.Ticks + extension;
            kaset.imagepath = "~/Content/images/" + filename;
            filename = Path.Combine(Server.MapPath("~/Content/images/"), filename);
            kaset.imageFile.SaveAs(filename);

            if (ModelState.IsValid)
            {
                db.Kasets.Add(kaset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kaset);
        }

        // GET: Kasets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaset kaset = db.Kasets.Find(id);
            if (kaset == null)
            {
                return HttpNotFound();
            }
            return View(kaset);
        }

        // POST: Kasets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nama,harga_sewa,harga_beli,stok,jumlah_pencarian,diskon")] Kaset kaset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kaset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kaset);
        }

        // GET: Kasets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaset kaset = db.Kasets.Find(id);
            if (kaset == null)
            {
                return HttpNotFound();
            }
            return View(kaset);
        }

        // POST: Kasets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kaset kaset = db.Kasets.Find(id);
            db.Kasets.Remove(kaset);
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
