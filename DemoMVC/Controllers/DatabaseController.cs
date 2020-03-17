using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class DatabaseController : Controller
    {
        static List<DEPTDATA> list = null;
        static List<EMPDATA> list1 = null;
        // GET: Database
        public ActionResult Index()
        {
            EMPDATA E = new EMPDATA();
            return View(E);
        }

        [HttpPost]
        public ActionResult Index(EMPDATA E)
        {
            ViewBag.msg=DBOperations.InsertEmp(E);
            return View();
        }
      
        public ActionResult getDeptData()
        {
           
                return View();                                            
        }
       

        
        public ActionResult GetDept()
        {

            int deptno = int.Parse(Request.Form["txtDeptno"]);
            List<EMPDATA> L=DBOperations.GetDept(deptno);
            return View("getDeptData",L);
        }

        public ActionResult GetEmp()
        {
            EMPDATA E = new EMPDATA();
            return View(E);
        }
        public ActionResult GetEmpDetails()
        {
            int empno = int.Parse(Request.Form["txtempno"]);
            ViewBag.L = DBOperations.GetEmp(empno);
            return View("getDeptData");
        }

        public ActionResult getDepts()
        {
            list = DBOperations.getDepts();
            ViewBag.L = list;
            return View();
        }

        public ActionResult SendDept()
        {
            int deptno = int.Parse(Request.QueryString["d"]);
            ViewBag.v = deptno;
            ViewBag.L = list;
            List<EMPDATA> l=DBOperations.GetDept(deptno);
            return View("getDepts", l);
        }

        public ActionResult getEmps()
        {
            list1 = DBOperations.getEmps();
            ViewBag.L = list1;
            return View();
        }

        public ActionResult SendEmp()
        {
            int empno = int.Parse(Request.Form["ddlEmpno"]);
            //ViewBag.v = empno;
            
            ViewBag.str= DBOperations.DelEmp(empno);
            ViewBag.L = DBOperations.getEmps();
            return View("getEmps");
        }
    }
}