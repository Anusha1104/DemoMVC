using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class XYZController : Controller
    {
        // GET: XYZ
        public ActionResult Index()
        {
            ViewBag.str = "My first MVC Project";
            ViewData["str1"] = "My First Project";
            TempData["str2"] = "My Project";
            
            return View();
        }

        public ActionResult SendObject()
        {
            Emp E = new Emp();
            E.Empno = 10;
            E.Ename = "Anu";
            E.Salary = 20000;
            return View(E);
        }
    
        public ActionResult SendObjects()
        {
            List<Emp> l = new List<Emp>();
            Emp e = new Emp();
            e.Empno = 1;
            e.Ename = "AAA";
            e.Salary = 1000;
            l.Add(e);

            e = new Emp();
            e.Empno = 2;
            e.Ename = "BBB";
            e.Salary = 2000;
            l.Add(e);
            return View(l);
        }

        public ActionResult SendObjectVB()
        {
            Emp E = new Emp();
            E.Empno = 10;
            E.Ename = "Anu";
            E.Salary = 20000;
            ViewBag.emp = E;
            ViewData["str"] = E;
            TempData["str1"] = E;
            return View();
        }

        public ActionResult SendObjectsVB()
        {
            List<Emp> l = new List<Emp>();
            Emp e = new Emp();
            e.Empno = 1;
            e.Ename = "AAA";
            e.Salary = 1000;
            l.Add(e);

            e = new Emp();
            e.Empno = 2;
            e.Ename = "BBB";
            e.Salary = 2000;
            l.Add(e);
            ViewBag.xyz = l;
            ViewData["xyz"] = l;
            return View();
        }
    }
}