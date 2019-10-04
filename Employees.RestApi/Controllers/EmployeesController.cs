using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Employees.Models;
using Employees.Services;
using Employees.Services.Interfaces;



namespace Employees.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmployeeServices _employeeServices;
        public EmployeesController(ILogger<EmployeesController> logger, IHostingEnvironment hostingEnvironment, IEmployeeServices employeeServices)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _employeeServices = employeeServices;
            _employeeServices.SetDataPath(_hostingEnvironment.ContentRootPath);
        }

        // GET: api/Employees
        [HttpGet]
        public IActionResult Get(DateTime startDate)
        {
            try
            {
                var employees = _employeeServices.ListEmployees(startDate);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GET action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _employeeServices.DeleteEmployee(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
