using System;
using DbFirstEg.Model;
using System.Linq;
using System.Collections.Generic;
using DbFirstEg.Repository;

namespace DbFirstEg {
    class Program {

        public static ARONContext db = new ARONContext();
        public static Employee e = new Employee();
        static void Main(string[] args) {
            IEmpRepo obj = new EmpRepo();
            //Accept();
            //obj.AddEmployee(e);
            Console.WriteLine("Enter the Employee ID for which you need the details");
            int id = Convert.ToInt32(Console.ReadLine()); ;
            e = obj.getEmpById(id);
            Console.WriteLine(e.Empid + " " + e.Empname + " " + e.Salary);


            Console.WriteLine("Enter Name, Salary");
            e.Empname = Console.ReadLine();
            e.Salary = float.Parse(Console.ReadLine());
            obj.UpdateEmployee(e);
            Console.WriteLine("Record Got Updated");
             

            /*Console.WriteLine("Are you sure you want to delete this record?");
            string answer = Console.ReadLine();
            if (answer == "Yes") {
                obj.RemoveEmployee(id);
                Console.WriteLine("Record got Deleted!");
            }
            else {
                //
            }*/

            var emps = obj.RetrieveAllEmployees();
            foreach(var item in emps) {
                Console.WriteLine(item.Empid + " " + item.Empname + " " + item.Salary);
            }
        }

        private static void Accept() {
            Console.WriteLine("Enter Empid, Name, Salary, Doj, Emptype, Deptid, Mgrid");
            e.Empid = Convert.ToInt32(Console.ReadLine());
            e.Empname = Console.ReadLine();
            e.Salary = float.Parse(Console.ReadLine());
            e.Doj = Convert.ToDateTime(Console.ReadLine());
            e.EmpType = Convert.ToBoolean(Console.ReadLine());
            e.Deptid = Convert.ToInt32(Console.ReadLine());
            e.Manager = Convert.ToInt32(Console.ReadLine());




        }
    }
}
