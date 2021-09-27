using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbFirstEg.Model;
namespace DbFirstEg.Repository {
    public interface IEmpRepo {
        public abstract List<Employee> RetrieveAllEmployees();

        public abstract void AddEmployee(Employee e);

        public abstract Employee getEmpById(int id);

        public abstract void RemoveEmployee(int id);

        public abstract void UpdateEmployee(Employee e);
    }

}
