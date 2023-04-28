using AmarisTest.BusinessLogicLayer;
using AmarisTest.Models;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;

namespace AmarisTest.UnitTests
{
    [TestFixture]
    public class BusinessLayerTests
    {
        private EmployeeBLL _businessLayer;

        [SetUp]
        public void Setup()
        {
            _businessLayer = new EmployeeBLL();
        }

        [Test]
        public void CalculateAnnualSalary_ReturnsCorrectValue()
        {
            // Arrange
            var employee = new Employee
            {
                id = 1,
                employee_name = "John Doe",
                employee_salary = 50000,
                employee_age = 30,
                profile_image = ""
            };
            decimal expectedAnnualSalary = employee.employee_salary * 12;

            // Act
            decimal actualAnnualSalary = _businessLayer.CalculateAnnualSalary(employee);

            // Assert
            Assert.AreEqual(expectedAnnualSalary, actualAnnualSalary);
        }
    }
}
