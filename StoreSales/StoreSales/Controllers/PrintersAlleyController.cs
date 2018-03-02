using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreSales.Models;

namespace StoreSales.Controllers
{
    public class PrintersAlleyController : Controller
    {
        private PADbContext db = new PADbContext();
        // GET: PrintersAlley
        public ActionResult Index()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}