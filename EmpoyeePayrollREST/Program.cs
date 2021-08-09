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
            EmployeePayrollWebService webService = new EmployeePayrollWebService();
            webService.GetEmployeeList();
            IRestResponse response = webService.GetEmployeeList();
            //Deserialize JSON object
            List<Employee> responsData = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Console.WriteLine("Count of employees : " + responsData.Count);
        }
    }
}
