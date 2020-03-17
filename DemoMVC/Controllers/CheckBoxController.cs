using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class CheckBoxController : Controller
    {
        List<EMPDATA> l = null;
        // GET: CheckBox
        public ActionResult Index()
        {
            List<EMPDATA> l = DBOperations.getEmps();
            return View(l);
        }

        public ActionResult Display()
        {
             var eno = Request.Form.Get("cbemp");
            l = DBOperations.getEmps();
            List<EMPDATA> emp = new List<EMPDATA>();
            foreach (var i in l)
            {
                if (eno.Contains(i.EMPNO.ToString()))
                {
                    emp.Add(i);
                }
            }
              

            return View(emp);
        }
    }
}