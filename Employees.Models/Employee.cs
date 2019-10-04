using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Models
{
    public class Employee
    {
        public int EmployeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string StartDate { get; set; }
        public bool IsDeleted { get; set; }
      
    }
}
