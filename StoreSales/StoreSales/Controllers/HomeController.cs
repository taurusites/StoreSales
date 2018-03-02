using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using StoreSales.Models;
using System.Text;

namespace StoreSales.Controllers
{
    public class HomeController : Controller
    {
        private FusionDbContext db = new FusionDbContext();

        // GET: Default
        public ActionResult Index(string beginDate, string endDate, string currentFilter, string searchString)
        {

            if (String.IsNullOrEmpty(beginDate) || String.IsNullOrEmpty(endDate))
            {
                beginDate = DateTime.Today.Date.AddDays(-1).ToString("yyyy-MM-dd");
                endDate = DateTime.Today.Date.ToString("yyyy-MM-dd");
            }

            ViewBag.BeginDate = beginDate;
            ViewBag.EndDate = endDate;


            if (String.IsNullOrEmpty(searchString))
            {
                searchString = currentFilter;
                ViewBag.CurrentFilter = searchString;
                var sales = GetSales(beginDate, endDate).ToList();
                return View(sales);
            }
            else
            {
                var sales = GetSales(beginDate, endDate).Where(m => m.registerid.Equals(searchString)).ToList();
                return View(sales);
            }
        }


        [HttpPost]
        public FileResult ExportSales()
        {
            string[] columnNames = { "RecModDate", "tranno", "registerid", "TenderAmount", "ID1" };
            string beginDate = Request.Form["BegDate"];
            string endDate = Request.Form["EggDate"];
            string searchString = Request.Form["SegStr"];
            var sales = GetSales(beginDate, endDate);
            string csv = string.Empty;
            foreach (string columnName in columnNames)
            {
                csv += columnName + ',';
            }
            csv += "\r\n";
            if (!string.IsNullOrEmpty(searchString))
            {
                sales = sales.Where(s => s.registerid.Equals(searchString));
            }
            foreach (var sale in sales)
            {
                csv += sale.RecModDate.Date.ToString("d") + ',';
                csv += sale.tranno.ToString() + ',';
                csv += sale.registerid + ',';
                csv += sale.TenderAmount.ToString() + ',';
                csv += sale.ID1 + ',';

                csv += "\r\n";
            }

            byte[] bytes = Encoding.ASCII.GetBytes(csv);
            ViewBag.BeginDate = beginDate;
            ViewBag.EndDate = endDate;
            ViewBag.CurrentFilter = searchString;
            return File(bytes, "application/text", "Sales.csv");
        }

        [HttpPost]
        public FileResult ExportMonthlySales()
        {
            string[] columnNames = { "Location", "TotalAsOnDate", "TotalSalesThisMonth", "TotalSalesThisYear", "SalesThisMonthLastYear", "TotalSalesLastYearTillDate", "SalesLastYearNextMonth" };
            string asonDate = Request.Form["Adate"];
            var sales = GetMonthlySales(asonDate);
            string csv = string.Empty;
            foreach (string columnName in columnNames)
            {
                csv += columnName + ',';
            }
            csv += "\r\n";
            foreach (var sale in sales)
            {
                csv += sale.Location + ',';
                csv += sale.TotalAsOnDate.ToString() + ',';
                csv += sale.TotalSalesThisMonth.ToString() + ',';
                csv += sale.TotalSalesThisYear.ToString() + ',';
                csv += sale.SalesThisMonthLastYear.ToString() + ',';
                csv += sale.TotalSalesLastYearTillDate.ToString() + ',';
                csv += sale.SalesLastYearNextMonth.ToString() + ',';

                csv += "\r\n";
            }

            byte[] bytes = Encoding.ASCII.GetBytes(csv);
            ViewBag.AsonDate = asonDate;
            return File(bytes, "application/text", "MonthlySales.csv");
        }

        public ActionResult MonthlySales(string asonDate)
        {
            if (String.IsNullOrEmpty(asonDate))
            {
                asonDate = DateTime.Today.ToString("yyyy-MM-dd");
            }

            ViewBag.AsOnDate = asonDate;
            var sdata = GetMonthlySales(asonDate);
            return View(sdata.ToList());
        }


        private IEnumerable<Sales> GetSales(string beginDate, string endDate)
        {
            SqlParameter pbdate = new SqlParameter("@startdate", Convert.ToDateTime(beginDate));
            SqlParameter pedate = new SqlParameter("@enddate", Convert.ToDateTime(endDate));
            IEnumerable<Sales> salesData = db.Database.SqlQuery<Sales>("sp_aci_ccsales @startdate,@enddate", pbdate, pedate);
            return (salesData);
        }

        private IEnumerable<MonthlySales> GetMonthlySales(string sdate)
        {
            SqlParameter pasonDate = new SqlParameter("@asondate", Convert.ToDateTime(sdate));
            IEnumerable<MonthlySales> sales = db.Database.SqlQuery<MonthlySales>("sp_aci_GetSalesTotals @asondate", pasonDate);
            return (sales);
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