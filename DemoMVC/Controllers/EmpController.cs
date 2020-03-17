using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        //static List<EMPDATA> l = null;
        public ActionResult Index()
        {
            List<EMPDATA> l = DBOperations.getEmps();
            return View(l);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Insert(EMPDATA e)
        {
            ViewBag.msg = DBOperations.InsertEmp(e);
            return View("Create");
        }

        //public ActionResult Edit([Bind(Include = "ENAME,JOB,MGR,HIREDATE,SAL,COMM,DEPTNO")]EMPDATA emp)
        //{
        //    return View();
        //}

        public ActionResult Edit(int id)
        {
            EMPDATA e=DBOperations.getEmp(id);
            return View(e);
        }

        public ActionResult Update(EMPDATA e)
        {
            ViewBag.msg=DBOperations.UpdateEmp(e);
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            ViewBag.msg=DBOperations.DelEmp(id);
            return View("Index", DBOperations.getEmps());
        }
    }
}