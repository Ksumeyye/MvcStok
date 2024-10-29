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
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index()
        {
            var satislar=db.TBLSATISLAR.ToList();
            return View(satislar);
        }
    }
}