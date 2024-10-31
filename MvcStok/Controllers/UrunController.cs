using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entities;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        //public ActionResult Index(string p)
        //{
        //    var degerler = from d in db.TBLURUNLER select d;
        //    if (!string.IsNullOrEmpty(p))
        //    {
        //        degerler = degerler.Where(m => m.URUNAD.Contains(p));
        //    }
        //    return View(degerler.ToList());
        //}
        public ActionResult Index()
        {
            var urunler = db.TBLURUNLER.ToList();
            return View(urunler);
        }
        [HttpGet]
            public ActionResult YeniUrun()
            {
                if (!ModelState.IsValid) //Doğrulama işlemi doğru yapılmadıysa
                {
                    return View("YeniUrun"); //Beni YeniUrune döndür.
                }
                List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList() //i değişkeni, tblkategoriler listesindeki kategori ad ve kategori ıd leri eşler. degerler, sorgudan gelen değerleri tutar.
                                                 select new SelectListItem
                                                 {
                                                     Text = i.KATEGORIAD,
                                                     Value = i.KATEGORIID.ToString()
                                                 }).ToList();
                ViewBag.dgr = degerler; //Viewbag; controllerdakini başka sayfada kullanmaya yarar. 
                return View();
            }
            [HttpPost]
            public ActionResult YeniUrun(TBLURUNLER u1)
            {
                var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == u1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
                u1.TBLKATEGORILER = ktg;
                db.TBLURUNLER.Add(u1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            public ActionResult Sil(int id)
            {
                var urun = db.TBLURUNLER.Find(id);
                db.TBLURUNLER.Remove(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            public ActionResult UrunGetir(int id)
            {
                var urunler = db.TBLURUNLER.Find(id);
                List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.KATEGORIAD,
                                                     Value = i.KATEGORIID.ToString()
                                                 }).ToList();
                ViewBag.dgr = degerler;
                return View("UrunGetir", urunler);
            }
            public ActionResult Guncelle(TBLURUNLER c1)
            {
                var urun = db.TBLURUNLER.Find(c1.URUNID);
                urun.URUNAD = c1.URUNAD;
                urun.MARKA = c1.MARKA;
                var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == c1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
                urun.URUNKATEGORI = ktg.KATEGORIID;
                //urun.URUNKATEGORI = c1.URUNKATEGORI;
                urun.FIYAT = c1.FIYAT;
                urun.STOK = c1.STOK;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
