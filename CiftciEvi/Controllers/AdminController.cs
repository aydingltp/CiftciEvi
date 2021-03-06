﻿using CiftciEvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace CiftciEvi.Controllers
{
    public class AdminController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            var adminlist = db.Kullanicilar.Where(i => i.Adminmi == true).ToList();
            return View(adminlist);
        }
        public PartialViewResult KullaniciList()
        {
            var kullanicilist = db.Kullanicilar.Where(i => i.Adminmi == false).ToList();
            return PartialView("_KullaniciList",kullanicilist);
        }

        // GET: Kullanici/AdminKayit
        public ActionResult Kayit()
        {
            return View();
        }

        // POST: Kullanici/AdminKayit   Kurumsal Üyelik
        [HttpPost]
        public ActionResult Kayit(Kullanici kullanici)
        {
            if (db.Kullanicilar.FirstOrDefault(p => p.Cep == kullanici.Cep) != null)
            {
                ModelState.AddModelError("Cep", "Bu numara başka bir kullanıcı tarafından kullanılmaktadır.");
            }
            else
            {
                kullanici.Adminmi = true;
                db.Kullanicilar.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("Login", "Giris");
            }
            return View(kullanici);
        }

        // GET: Kullanici/Edit/5
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanicilar.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanici/Edit/5
        [HttpPost]
        public ActionResult Guncelle(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Kullanicilar.Find(kullanici.Id);
                if (entity != null)
                {
                    entity.Adi = kullanici.Adi;
                    entity.Soyadi = kullanici.Soyadi;
                    entity.Cep = kullanici.Cep;
                    entity.Email = kullanici.Email;
                    entity.Sifre = kullanici.Sifre;
                    entity.SifreConfirm = kullanici.SifreConfirm;
                    db.SaveChanges();
                    TempData["Duzenlendi"] = entity;
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }


        // GET: Admin/Detay/5
        public ActionResult Detay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kullanici = db.Kullanicilar.FirstOrDefault(i => i.Id == id);

            if (kullanici == null)
            {
                return HttpNotFound();
            }

            return View(kullanici);
        }


    }
}