using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StorePayments.Models;

namespace StorePayments.Controllers
{
    public class StoresController : Controller
    {
        private DbDataContext db = new DbDataContext();
        // GET: Stores
        public ActionResult Index()
        {
            return View();
        }
    }
}