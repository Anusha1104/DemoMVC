using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class EventsController : Controller
    {
        
       
        public ActionResult Index()
        {
            //step 1
            //Retrieve all Emp names
             ViewBag.EL= DBOperations.getEmps();
             return View();
        }

        public ActionResult GetData()
        {
            int eno=int.Parse(Request.QueryString["Eno"]);
            ViewBag.msg=DBOperations.DelEmp(eno);
            ViewBag.EL = DBOperations.getEmps();
            return View("Index");
        }

        public ActionResult Emp()
        {
            return View();
        }

        public ActionResult GetEmp()
        {
            int empno = int.Parse(Request.QueryString["e"]);
            EMPDATA emp = DBOperations.Emp(empno);
            return View("Emp",emp);
        }

        public ActionResult Update(EMPDATA E)
        {
            ViewBag.msg=DBOperations.UpdateEmp(E);
            return View("Emp");
        }
    }
}