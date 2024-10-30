using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entities;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities db=new MvcDbStokEntities();
        // GET: Musteri
        public ActionResult Index()
        {
            var musteriler=db.TBLMUSTERILER.ToList();
            return View(musteriler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER m1)
        {
            if (!ModelState.IsValid) //Doğrulama işlemi Doğru Yapılmadıysa
            {
                return View("YeniMusteri"); //Beni YeniMusteriye döndür
            }
            db.TBLMUSTERILER.Add(m1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var musteri=db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mus); //Musteri Getir sayfasında döndür mus'u getir.
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteri = db.TBLMUSTERILER.Find(p1.MUSTERIID); //Buradaki p1 diğer tarafta viewdeki müşterilerle eşleşecek.
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}