using MvcStok.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcStok.Controllers
{
    public class YardimController : Controller
    {
        // GET: Yardim
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var yrdm = db.TBLYARDIM.ToList();
            return View(yrdm);
        }
    }
}