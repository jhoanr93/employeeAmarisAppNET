using AmarisTest.BusinessLogicLayer;
using AmarisTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AmarisTest.DataAccessLayer
{
    public class EmployeeDAL
    {
        private readonly string baseUrl = "http://dummy.restapiexample.com/api/v1/";

        EmployeeBLL employeeB = new EmployeeBLL();

        public async Task<List<Employee>> GetEmployees()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage response = await client.GetAsync("employees");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(jsonString);
                    List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(result.data.ToString());
                    

                    // calculate the annual salary for each employee
                    foreach (var employee in employees)
                    {
                        employee.annual_salary = employeeB.CalculateAnnualSalary(employee);
                    }
                    return employees;
                }
                else
                {
                    throw new Exception($"Error getting employees from API. Status code: {response.StatusCode}");
                }

                
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage response = await client.GetAsync($"employee/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<EmployeeResponse>(json);
                    return result.data;
                }

                return null;
            }
        }

    }
}
