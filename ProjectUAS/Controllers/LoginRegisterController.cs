using ProjectUAS.Models;
using ProjectUAS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectUAS.Controllers
{
    public class LoginRegisterController : Controller
    {
        private kasetContext context = new kasetContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginMetadata userMetadata)
        {
            try
            {
                var user = (from a in context.Users where a.username == userMetadata.username select a).Single();
                if (user.password == userMetadata.password)
                {
                    Session["id_user"] = user.id;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Password anda salah";
                    ViewBag.Status = false;
                    return View(userMetadata);
                }
                
            } catch(Exception e)
            {
                ViewBag.Message = "Username " + userMetadata.username + " tidak ditemukan";
                ViewBag.Status = false;
                return View(userMetadata);
            }  
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterMetadata registerMetadata)
        {
            try
            {
                var userTmp = (from a in context.Users where a.username == registerMetadata.username select a).Single();
                if (userTmp != null)
                {
                    ViewBag.Message = "Username sudah ada";
                    ViewBag.Status = false;
                    return View(registerMetadata);
                } else
                {
                    addUser(context, registerMetadata);
                    return RedirectToAction("Index", "Home");
                }
            } catch(Exception e)
            {
                addUser(context, registerMetadata);
                return RedirectToAction("Index", "Home");
            }
        }

        [NonAction]
        private void addUser(kasetContext context, RegisterMetadata registerMetadata)
        {
            var user = new User();
            user.username = registerMetadata.username;
            user.nama = registerMetadata.nama;
            user.no_identitas = registerMetadata.noIdentitas;
            user.password = registerMetadata.Password;
            user.alamat = registerMetadata.alamat;
            user.saldo = registerMetadata.saldo;
            context.Users.Add(user);
            context.SaveChanges();

            var userTmp = (from a in context.Users where a.username == user.username select a).Single();
            Session["id_user"] = userTmp.id;
        }
    }
}