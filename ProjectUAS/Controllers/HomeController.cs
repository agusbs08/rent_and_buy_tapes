using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectUAS.DAL;
using System.Net;
using ProjectUAS.Models;

namespace ProjectUAS.Controllers
{
    public class HomeController : Controller
    {
        private kasetContext context = new kasetContext();
        public ActionResult Index()
        {
            if(Session["id_user"] == null)
            {
                return HttpNotFound();
            }
            var allKaset = context.Kasets.ToList();
            var topTenKaset = (from a in context.Kasets orderby a.jumlah_pencarian descending select a).ToList();
            HomeModel homeModel = new HomeModel(allKaset, topTenKaset);
            return View(homeModel);
        }

        [HttpGet]
        public ActionResult Index(String message)
        {
            if (Session["id_user"] == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = message;
            var allKaset = context.Kasets.ToList();
            var topTenKaset = (from a in context.Kasets orderby a.jumlah_pencarian descending select a).ToList();
            HomeModel homeModel = new HomeModel(allKaset, topTenKaset);
            return View(homeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpGet]
        public ActionResult Pengembalian()
        {
            if(Session["id_user"] == null)
            {
                return HttpNotFound();
            }
            int id_user = (int)Session["id_user"];
            return View((from a in context.Peminjamen where a.id_user == id_user select a));
        }

        [HttpPost]
        public ActionResult Pengembalian(Pengembalian pengembalian)
        {
            var peminjaman = context.Peminjamen.Find(pengembalian.id_peminjaman);
            var user = context.Users.Find(peminjaman.id_user);
            var kaset = context.Kasets.Find(peminjaman.id_kaset);

            pengembalian.Peminjaman = peminjaman;

            if (ModelState.IsValid)
            {
                peminjaman.status_kembali = "Sudah Kembali";
                context.Pengembalians.Add(pengembalian);
                kaset.stok += 1;
                user.saldo -= pengembalian.denda;
                context.SaveChanges();
            }
            return RedirectToAction("Index", new { message = "Pengembalian Sukses" });
        }

        [HttpGet]
        public ActionResult StrukPengembalian(int? id)
        {
            return View(context.Peminjamen.Find(id));
        }

        [HttpGet]
        public ActionResult Pembatalan()
        {

            if (Session["id_user"] == null)
            {
                return HttpNotFound();
            }
            int id_user = (int)Session["id_user"];
            return View((from a in context.Pemesanans where a.id_user == id_user select a));
        }

        [HttpPost]
        public ActionResult Pembatalan(Pembatalan pembatalan)
        {
            var pemesanan = context.Pemesanans.Find(pembatalan.id_pemesanan);
            var user = pemesanan.User;
            var kaset = pemesanan.Kaset;

            pembatalan.Pemesanan = pemesanan;
            
            if(ModelState.IsValid)
            {
                pemesanan.status = "Dibatalkan";
                context.Pembatalans.Add(pembatalan);
                user.saldo += pembatalan.refund;
                kaset.stok += pembatalan.Pemesanan.jumlah;
                context.SaveChanges();
            }
            return RedirectToAction("Index", new { message = "Pembatalan Sukses" });
        }

        [HttpGet]
        public ActionResult StrukPembatalan(int? id)
        {
            return View(context.Pemesanans.Find(id));
        }

        [HttpGet]
        public ActionResult Penerimaan(int? id)
        {
            var pemesanan = context.Pemesanans.Find(id);
            pemesanan.status = "Sudah Diterima";
            context.SaveChanges();

            string message = "Konfirmasi Pesanan Sukses";
            return RedirectToAction("Index", new { message = message });
        }
        
        [HttpGet]
        public ActionResult toDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kaset = context.Kasets.Find(id);
            kaset.jumlah_pencarian += 1;
            context.SaveChanges();
            return RedirectToAction("Index", "Detail", new { id = id });
        }
    }
}