using AmarisTest.Models;

namespace AmarisTest.BusinessLogicLayer
{
    public class EmployeeBLL
    {
        public decimal CalculateAnnualSalary(Employee employee)
        {
            return employee.employee_salary * 12;
        }
    }
}
