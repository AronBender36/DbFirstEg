using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstEg.Model
{
    public partial class Employee
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public double? Salary { get; set; }
        public DateTime? Doj { get; set; }
        public bool? EmpType { get; set; }
        public int? Deptid { get; set; }
        public int? Manager { get; set; }

        public virtual Department Dept { get; set; }
    }
}
