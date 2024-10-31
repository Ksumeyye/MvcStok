using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entities;
using PagedList;
using PagedList.Mvc;
namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities(); //Modelin içerisindeki tablolara ulaşmak için db nesnesine ihtiyacımız vardır.
        //public ActionResult Index(string k)
        //{
        //    var degerler = from d in db.TBLKATEGORILER select d;
        //    if (!string.IsNullOrEmpty(k))
        //    {
        //        degerler = degerler.Where(m => m.KATEGORIAD.Contains(k));
        //    }
        //    return View(degerler.ToList());
        //    //var musteriler=db.TBLMUSTERILER.ToList();
        //    //return View(musteriler);
        //}
        public ActionResult Index(int sayfa = 1)
            {
                //var degerler = db.TBLKATEGORILER.ToList();
                var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 4); //PagedList, istenilen sayıda veriyi listeler.
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
                if (!ModelState.IsValid) //Doğrulama işlemi Doğru Yapılmadıysa
                {
                    return View("YeniKategori"); //Beni YeniKategoriye döndür
                }
                db.TBLKATEGORILER.Add(p1);
                db.SaveChanges();
                return View();
            }
            public ActionResult Sil(int id)
            {
                var kategori = db.TBLKATEGORILER.Find(id);
                db.TBLKATEGORILER.Remove(kategori);
                db.SaveChanges();
                return RedirectToAction("Index"); //Beni index safasına yönlendirir.
            }
            public ActionResult KategoriGetir(int id)
            {
                var ktgr = db.TBLKATEGORILER.Find(id);
                return View("KategoriGetir", ktgr);
            }
            public ActionResult Guncelle(TBLKATEGORILER p1)
            {
                var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
                ktg.KATEGORIAD = p1.KATEGORIAD;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
