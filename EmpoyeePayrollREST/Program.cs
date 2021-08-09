using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace EmpoyeePayrollREST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Payroll using REST");
            List<Employee> employeeList = new List<Employee>();
            //Create object
            EmployeePayrollWebService webService = new EmployeePayrollWebService();
            Employee employee = new Employee();
            Employee emp1 = new Employee();

            //Add employee
            employee.Name = "Richard";
            employee.Salary = 75000;
            employeeList.Add(employee);
            emp1.Name = "Kevin";
            emp1.Salary = 84000;
            employeeList.Add(emp1);
            //Add multiple employees
            webService.AddMultipleEmployees(employeeList);

            //Get employee
            webService.GetEmployeeList();
            IRestResponse response = webService.GetEmployeeList();
            //Deserialize JSON object
            List<Employee> responsData = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Console.WriteLine("Count of employees : " + responsData.Count);
        }
    }
}
