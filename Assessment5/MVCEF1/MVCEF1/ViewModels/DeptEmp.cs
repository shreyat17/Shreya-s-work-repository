using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEF1.ViewModels
{
    public class DeptEmp
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptLocation { get; set; }
       
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }
    }
}