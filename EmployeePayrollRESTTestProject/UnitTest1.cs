using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmpoyeePayrollREST;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmployeePayrollRESTTestProject
{
    [TestClass]
    public class UnitTest1
    {
        EmployeePayrollWebService webService;
        Employee employee;
        [TestInitialize]
        public void SetUp()
        {
            webService = new EmployeePayrollWebService();
            employee = new Employee();
        }
        /// <summary>
        /// UC 1 - Retrieve Employees
        /// </summary>
        [TestMethod]
        public void GetCountOfContacts()
        {
            IRestResponse response = webService.GetEmployeeList();
            //Checking the status code
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Employee> responseData = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(6, responseData.Count);
        }
        /// <summary>
        /// UC 2 - Add Employee
        /// </summary>
        [TestMethod]
        public void AddEmployeeByCallingPOSTApi()
        {
            employee.Name = "Michael";
            employee.Salary = 84000;
            IRestResponse response = webService.AddEmployee(employee);
            var result = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
            Assert.AreEqual("Michael", result.Name);
        }
        /// <summary>
        /// UC 3 - Add Multiple Employees
        /// </summary>
        [TestMethod]
        public void AddMultipleEmployeesByCallingPOSTApi()
        {
            List<Employee> employeeList = new List<Employee>();
            Employee emp1 = new Employee();
            employee.Name = "Richard";
            employee.Salary = 75000;
            employeeList.Add(employee);
            emp1.Name = "Kevin";
            emp1.Salary = 84000;
            employeeList.Add(emp1);
            webService.AddMultipleEmployees(employeeList);
            IRestResponse response = webService.GetEmployeeList();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Employee> responseData = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(9,responseData.Count);
        }
        /// <summary>
        /// UC 4 - Update Salary
        /// </summary>
        [TestMethod]
        public void UpdateSalaryByCallingPUTApi()
        {
            employee.Name = "Kevin";
            employee.Salary = 74000;
            IRestResponse response = webService.UpdateSalary(employee);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            var result = JsonConvert.DeserializeObject<Employee>(response.Content);
        }
    }
}
