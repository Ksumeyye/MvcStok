using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entities;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities(); //Modelin içerisindeki tablolara ulaşmak için db nesnesine ihtiyacımız vardır.
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }
        [HttpGet] //Sayfa yüklenince bunu yap
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost] //İçerisinde ben bir şey yapınca bunu yap
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}