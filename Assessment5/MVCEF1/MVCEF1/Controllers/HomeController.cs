using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MVCEF1.Models;
using MVCEF1.ViewModels;
using WebGrease.Css.Extensions;

namespace MVCEF1.Controllers
{
    public class HomeController : Controller
    {
        SnadDBEntities context =new SnadDBEntities();
        public ActionResult Index()
        {
            
            

            List<employee> employees = context.employees.ToList();

            employee emp = ( from a in context.employees where a.EmpId==1 select a).SingleOrDefault();
          emp = context.employees.Where(x=>x.EmpId==1).SingleOrDefault();

            string EmpName= (from a in context.employees where a.EmpId==1 select a.EmpName).SingleOrDefault();
            EmpName = context.employees.Where(x => x.EmpId == 1).Select(x => x.EmpName).SingleOrDefault();

            List<employee> list =( from a in context.employees where a.DeptId==1 select a).ToList();
           list=context.employees.Where(x=>x.DeptId==1).ToList();
         
            decimal maxsalary=context.employees.Max(x=>x.EmpSalary);
            decimal minsalary=context.employees.Min(x=>x.EmpSalary);
            decimal totalSalary = context.employees.Sum(x => x.EmpSalary);


            employees=context.employees.OrderBy(x=>x.EmpSalary).ToList();
            employees=context.employees.OrderByDescending(x=>x.EmpSalary).ToList();

            var empList = (from a in context.employees
                           join b in context.Departments on a.DeptId equals b.DeptId
                           select new DeptEmp 
                           { 
                           DeptId=a.DeptId,
                           DeptName=b.DeptName,
                           DeptLocation=b.DeptLocation,
                           EmpId=a.EmpId,
                           EmpName=a.EmpName,
                           EmpSalary=a.EmpSalary
                           }).ToList();
            
            return View(employees);
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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(employee emp)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            emp.EmpId = 0;
            context.employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Details (int id)
        {
            var emp=context.employees.Where(x=>x.EmpId== id).SingleOrDefault();
            return View(emp);
        }
        [HttpGet]
        public ActionResult Edit (int id)
        {
            var emp= context.employees.Where(x=>x.EmpId== id).SingleOrDefault();
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(employee emp)
        {
            context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        
        
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            var emp=context.employees.Where(x=>x.EmpId==id).SingleOrDefault();
            context.employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}