using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class DBOperations
    {
       static DemoEntities d = new DemoEntities();

        public static string InsertEmp(EMPDATA A)
        {
            try
            {
                d.EMPDATAs.Add(A);
                d.SaveChanges();
            }
            catch(DbUpdateException E)
            {
               SqlException ex=E.GetBaseException() as SqlException;
                if (ex.Message.Contains("FK__EMPDept"))
                    return "No Proper Deptno";
                else if (ex.Message.Contains("EMP_PK"))
                    return "No duplicate Empno";
                else
                    return "Error occured";
            }
            return "1 Row Inserted";
        }

        public static List<EMPDATA> GetDept(int Deptno)
        {
            var LE = from i in d.EMPDATAs
                     where i.DEPTNO==Deptno
                     select i;
            return LE.ToList();
        }

        public static List<EMPDATA> GetEmp(int empno)
        {
            var LE = from i in d.EMPDATAs
                     where i.EMPNO == empno
                     select i;
            return LE.ToList();
        }

        public static EMPDATA getEmp(int empno)
        {
            var LE = from i in d.EMPDATAs
                     where i.EMPNO == empno
                     select i;
            return LE.First();
        }

        public static List<DEPTDATA> getDepts()
        {
            var dept = from i in d.DEPTDATAs
                       select i;
            return dept.ToList();
        }
        public static List<EMPDATA> getEmps()
        {
            var emps = from i in d.EMPDATAs
                       select i;
            return emps.ToList();
        }

        public static string DelEmp(int empno)
        {
            var emp = from i in d.EMPDATAs
                      where i.EMPNO == empno
                      select i;
            EMPDATA E = emp.First();  // var(emp) is an object so cant delete
                                     // directly use First();
            d.EMPDATAs.Remove(E);
            d.SaveChanges();
            return "Employee with number "+empno+" is Deleted";
        }

        public static EMPDATA Emp(int empno)
        {
            var Emp = from i in d.EMPDATAs
                    where i.EMPNO == empno
                    select i;
            EMPDATA E = Emp.First();
            return E;
        }

        public static string UpdateEmp(EMPDATA E)
        {
            try
            {
                var E1 = from i in d.EMPDATAs
                         where i.EMPNO == E.EMPNO
                         select i;

                // int a = 0;
                // bool c = int.TryParse(E.COMM, out a);
                EMPDATA emp = E1.First();
                emp.ENAME = E.ENAME;
                emp.JOB = E.JOB;
                emp.MGR = E.MGR;
                emp.HIREDATE = E.HIREDATE;
                emp.SAL = E.SAL;
                //if (a != 0)
                emp.COMM = E.COMM;
                emp.DEPTNO = E.DEPTNO;
                // d.Entry(E).State = System.Data.Entity.EntityState.Modified;
                d.SaveChanges();
                
            }
            catch(DbEntityValidationException M)
            {
                //SqlException ex = E.GetBaseException() as SqlException;
                return M.Message;
            }
            return "Updated";
        }


    }
}