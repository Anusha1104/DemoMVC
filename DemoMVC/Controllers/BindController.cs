using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class BindController : Controller
    {
        // GET: Bind
       // [ActionName("Example")]
        public ActionResult Index()
        {
            return View();
        }
        //primitive Type Databinding
        public ActionResult Update(int id)
        {
            return View("Index",DBOperations.Emp(id));
        }

        //binding to complex type
        //[HttpPost]
        //public ActionResult Update(EMPDATA E)
        //{
        //    ViewBag.msg=DBOperations.UpdateEmp(E);
        //    return View("Index");
        //}

        //Basic type(not suggested)
        //[HttpPost]
        //public ActionResult Update(int EMPNO, string ENAME, string JOB, int MGR, DateTime HIREDATE, int SAL, int COMM, int DEPTNO)
        //{
        //    return View();
        //}


        // Form Collection
        //[HttpPost]
        //public ActionResult Update(FormCollection F)
        //{
        //    int eno = int.Parse(F["EMPNO"]);
        //    string ename = F["ENAME"];
        //    return View();
        //}

        [HttpPost]
        public ActionResult UPdate([Bind(Exclude ="ENAME,JOB,DEPTNO")] EMPDATA E)
        {
            return View();
        }
    }
}