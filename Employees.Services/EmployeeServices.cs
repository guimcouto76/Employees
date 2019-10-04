using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using Employees.Models;
using Employees.Services.Interfaces;

namespace Employees.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private string _dataPath;
        public void SetDataPath(string dataPath) {
            _dataPath = $"{dataPath}\\Data\\employee data.csv";
        }

        public bool DeleteEmployee(int idEmployee)
        {
            var employees = ListEmployees();
            var employee = employees.Where(e => e.EmployeId == idEmployee).FirstOrDefault();

            if (employee == null) return false;
            else
            {
                employee.IsDeleted = true;

                using (var writer = new StreamWriter(_dataPath))
                {
                    using (var csv = new CsvWriter(writer, new CsvHelper.Configuration.Configuration { Delimiter = ",", HasHeaderRecord = true }))
                    {
                        csv.WriteRecords<Employee>(employees);
                    }
                }

                return true;
            }
        }

        public IEnumerable<Employee> ListEmployees()
        {
            using (var reader = new StreamReader(_dataPath)) {
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.Configuration { Delimiter = "," , HasHeaderRecord = true } ))
                {
                    var employees = csv.GetRecords<Employee>().ToList(); 
                    return employees;
                }
            }
        }

        public IEnumerable<Employee> ListEmployeesCompleted5YearsOrMore()
        {
            return ListEmployees().Where(e => Convert.ToDateTime(e.StartDate, new System.Globalization.CultureInfo("en-US")) < DateTime.Now.AddYears(-5) && !e.IsDeleted).ToList();
        }
    }
}
