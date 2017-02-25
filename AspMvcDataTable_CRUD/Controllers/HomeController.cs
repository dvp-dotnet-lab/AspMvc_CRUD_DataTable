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

        [HttpPost]
        public ActionResult Save(int id)
        {
            using (Article_CRUD_DataTableEntities db = new Article_CRUD_DataTableEntities())
            {
                var v = db.Employees.Where(a => a.EmployeeID == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (Article_CRUD_DataTableEntities db = new Article_CRUD_DataTableEntities())
                {
                    if (emp.uEmployeeID > 0)
                    {
                        //edit
                        var v = db.Employees.Where(a => a.EmployeeID == emp.EmployeeID).FirstOrDefault();
                        if (v != null)
                        {
                            v.FirstName = emp.FirstName;
                            v.LastName = emp.LastName;
                            v.EmailID = emp.EmailID;
                            v.City = emp.City;
                            v.Country = emp.Country;
                        }
                    }
                    else
                    {
                        //save
                        db.Employees.Add(emp);
                    }
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (Article_CRUD_DataTableEntities db = new Article_CRUD_DataTableEntities())
            {
                var v = db.Employees.Where(a => a.EmployeeID == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }

        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;
            using (Article_CRUD_DataTableEntities db = new Article_CRUD_DataTableEntities())
            {
                var v =db.Employees.Where(a => a.EmployeeID == id ).FirstOrDefault();
                if (v != null)
                {
                    db.Employees.Remove(v);
                    db.SaveChanges();
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


    }
}