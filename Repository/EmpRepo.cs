using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirstEg.Model;

namespace DbFirstEg.Repository {
    class EmpRepo : IEmpRepo {
        public static ARONContext db = new ARONContext();
        public static Employee e = new Employee();
        public List<Employee> RetrieveAllEmployees() {
            return db.Employees.ToList();
        }

        public void AddEmployee(Employee e) {
            db.Employees.Add(e);
            db.SaveChanges();
        }

        public Employee getEmpById(int id) {
            return e = db.Employees.Find(id);
        }

        public void RemoveEmployee(int id) {
            e = getEmpById(id);
            db.Employees.Remove(e);
            db.SaveChanges();
        }

        public void UpdateEmployee(Employee e) {
            db.Employees.Update(e);
            db.SaveChanges();
        }
    }
}
