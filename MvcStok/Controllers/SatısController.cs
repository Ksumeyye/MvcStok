using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entities;
namespace MvcStok.Controllers
{
    public class SatısController : Controller
    {
        // GET: Satıs
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
        public ActionResult Sil(int id)
        {
            var satıs = db.TBLSATISLAR.Find(id);
            db.TBLSATISLAR.Remove(satıs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}