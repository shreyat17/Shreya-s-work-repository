﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MVCEF1.Models;
using MVCEF1.ViewModels;

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
    }
}