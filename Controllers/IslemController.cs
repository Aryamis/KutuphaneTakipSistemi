using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneTakipSistemi.Models.Entity;

namespace KutuphaneTakipSistemi.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUMU == true).ToList();
            return View(degerler);
        }
    }
}