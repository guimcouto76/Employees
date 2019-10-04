using System;
using System.Collections.Generic;
using Employees.Models;

namespace Employees.Services.Interfaces
{
    public interface IEmployeeServices
    {
        void SetDataPath(string dataPath);
        IEnumerable<Employee> ListEmployees();
        IEnumerable<Employee> ListEmployees(DateTime startDate);
        bool DeleteEmployee(int idEmployee);

    }
}
