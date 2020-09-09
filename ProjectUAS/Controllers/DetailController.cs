using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectUAS.DAL;
using ProjectUAS.Models;

namespace ProjectUAS.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        private kasetContext context = new kasetContext();
        public ActionResult Index(int? id)
        {
            var kaset = context.Kasets.Find(id);
            if (kaset == null)
            {
                return HttpNotFound();
            }
            return View(kaset);
        }

        [HttpPost]
        public ActionResult Peminjaman(Peminjaman peminjaman)
        {
            var kaset = context.Kasets.Find(peminjaman.id_kaset);
            var user = context.Users.Find((int)Session["id_user"]);

            peminjaman.Kaset = kaset;
            peminjaman.User = user;
            peminjaman.id_user = user.id;
            peminjaman.status_kembali = "Masih Dipinjam";

            string message = "Gagal melakukan Peminjaman";
            if (ModelState.IsValid && checkSaldo(user, kaset.harga_sewa) && checkStok(kaset, 1))
            {
                context.Peminjamen.Add(peminjaman);
                kaset.stok -= 1;
                user.saldo -= kaset.harga_sewa;
                context.SaveChanges();

                message = "Peminjaman " + kaset.nama + " Sukses";
            }
            return RedirectToAction("Index", "Home", new { message = message });
        }

        [HttpPost]
        public ActionResult Pembelian(Pembelian pembelian)
        {
            var kaset = context.Kasets.Find(pembelian.id_kaset);
            var user = context.Users.Find((int)Session["id_user"]);

            pembelian.Kaset = kaset;
            pembelian.User = user;

            pembelian.id_kaset = kaset.id;
            pembelian.id_user = user.id;
            pembelian.harga = (kaset.harga_beli - kaset.diskon) * pembelian.jumlah;

            string message = "Gagal melakukan pembelian";
            if (ModelState.IsValid && checkSaldo(user, pembelian.harga) && checkStok(kaset, pembelian.jumlah))
            {
                context.Pembelians.Add(pembelian);
                kaset.stok -= pembelian.jumlah;
                user.saldo -= pembelian.harga;
                context.SaveChanges();
                message = "Pembelian " + kaset.nama + " Sukses";
            }
            return RedirectToAction("Index", "Home", new { message = message });
        }

        [HttpPost]
        public ActionResult Pemesanan(Pemesanan pemesanan)
        {
            var kaset = context.Kasets.Find(pemesanan.id_kaset);
            var user = context.Users.Find((int)Session["id_user"]);

            pemesanan.Kaset = kaset;
            pemesanan.User = user;

            pemesanan.id_kaset = kaset.id;
            pemesanan.id_user = user.id;
            pemesanan.status = "Masih Proses";
            pemesanan.harga = (pemesanan.jumlah - kaset.diskon) * kaset.harga_beli;

            string message = "Gagal melakukan pemesanan";
            if (ModelState.IsValid && checkSaldo(user, pemesanan.harga) && checkStok(kaset, pemesanan.jumlah))
            {
                context.Pemesanans.Add(pemesanan);
                kaset.stok -= pemesanan.jumlah;
                user.saldo -= pemesanan.harga;
                context.SaveChanges();
                message = "Pembelian " + kaset.nama + " Sukses";
            }
            return RedirectToAction("Index", "Home", new { message = message });
        }

        [NonAction]
        private bool checkSaldo(User user, double? harga)
        {
            if(user.saldo >= harga)
            {
                return true;
            }
            return false;
        }

        [NonAction]
        private bool checkStok(Kaset kaset, double? jumlah)
        {
            if(kaset.stok >= jumlah)
            {
                return true;
            }
            return false;
        }
    }
}