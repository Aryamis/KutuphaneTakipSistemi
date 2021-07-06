using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneTakipSistemi.Models.Entity;

namespace KutuphaneTakipSistemi.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL prs)
        {
           if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBLPERSONEL.Add(prs);
            db.SaveChanges();
            return View();
        }

        public ActionResult PersonelSil(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(prs);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", prs);

        }
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prs= db.TBLPERSONEL.Find(p.ID);
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}