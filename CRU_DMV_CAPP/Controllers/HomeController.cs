using CRU_DMV_CAPP.DUMMY;
using CRU_DMV_CAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRU_DMV_CAPP.Controllers
{
    public class HomeController : Controller
    {
        companyEntities db = new companyEntities();

        loginEntities obj = new loginEntities();
        public ActionResult Index()
        {
            var res = db.Employees.ToList();
            List<empmodelcs> obj = new List<empmodelcs>();
            foreach (var item in res)
            {
                obj.Add(new empmodelcs
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    City = item.City,
                    Gender = item.Gender,
                    Salary = item.Salary,
                    Company = item.Company
                });
            }
            return View(obj);
        }
       public ActionResult Delete(int? id)
        {
            var Dt = db.Employees.Where(m => m.Id == id).FirstOrDefault();
            db.Employees.Remove(Dt);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(empmodelcs obj)
        {
            Employee b = new Employee();
            b.Id = obj.Id;
            b.Name = obj.Name;
            b.Email = obj.Email;
            b.City = obj.City;
            b.Company = obj.Company;
            b.Gender = obj.Gender;
            b.Salary = obj.Salary;
            if (b.Id == 0)
            {
                db.Employees.Add(b);
                db.SaveChanges();
            }
            else
            {
                db.Entry(b).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult Edit(int? id)
        {
            var c = db.Employees.Where(m => m.Id == id).FirstOrDefault();
            empmodelcs d = new empmodelcs();
            d.Id = c.Id;
            d.Name = c.Name;
            d.Email = c.Email;
            d.City = c.City;
            d.Gender = c.Gender;
            d.Company = c.Company;
            d.Salary = c.Salary;
            ViewBag.Edit = "Edit";
            return View("Create", d);

        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(usermodel a)
        {
            var l = obj.userinfoes.Where(m => m.Email == a.Email).FirstOrDefault();
            if(l==null)
            {
                ViewBag.a = "email not found";
            }
            else
            {
                if(l.Email==a.Email && l.password==a.password)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.e = "password is wrong";
                }
            }
            return View();
        }


    }
}