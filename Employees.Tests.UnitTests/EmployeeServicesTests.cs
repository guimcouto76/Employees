using Microsoft.VisualStudio.TestTools.UnitTesting;
using Employees.Services;

namespace Employees.Tests.UnitTests
{
    [TestClass]
    public class EmployeeServicesTests
    {
       
        [TestMethod]
        public void DeleteEmployee_WhenEployeeExists_ReturnTrue()
        {
            // Arrange
            var _employeeServices = new EmployeeServices();

            // Act
            int employeeId = 1;
            var result = _employeeServices.DeleteEmployee(employeeId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteEmployee_WhenEployeeDoesNotExists_ReturnFalse()
        {
            // Arrange
            var _employeeServices = new EmployeeServices();

            // Act
            int employeeId = 99;
            var result = _employeeServices.DeleteEmployee(employeeId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
