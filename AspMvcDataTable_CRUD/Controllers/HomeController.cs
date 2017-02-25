using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspMvcDataTable_CRUD.Models;
using System.Data.Entity;

namespace AspMvcDataTable_CRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            using (Article_CRUD_DataTableEntities db = new Article_CRUD_DataTableEntities())
            {
                var employees = db.Employees.OrderBy(m => m.FirstName).ToList();
                return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}