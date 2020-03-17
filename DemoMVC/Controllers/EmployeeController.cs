using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<EMPDATA> l = DBOperations.getEmps();
            return View(l);
        }

        public ActionResult GetEmp()
       {
            //int empno= int.Parse(Request.Form["rdbemp"].ToString()); for submitbutton
            int eno = int.Parse(Request.QueryString["e"]);
            EMPDATA e = DBOperations.Emp(eno);
            return View(e);
        }
    }
}