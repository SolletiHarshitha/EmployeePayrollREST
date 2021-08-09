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
    }
}
