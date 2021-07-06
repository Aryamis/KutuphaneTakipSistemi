using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneTakipSistemi.Models.Entity;

namespace KutuphaneTakipSistemi.Controllers
{
    
    public class OduncController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUMU == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

   
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            p.ISLEMDURUMU = false;
            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult OduncIade(int id)
        {
            var ktp = db.TBLHAREKET.Find(id);
            return View("OduncIade", ktp);
        }

        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrk = db.TBLHAREKET.Find(p.ID);
            hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrk.ISLEMDURUMU = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}
