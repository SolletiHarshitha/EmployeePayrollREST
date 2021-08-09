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
        [TestInitialize]
        public void SetUp()
        {
            webService = new EmployeePayrollWebService();
        }
        [TestMethod]
        public void GetCountOfContacts()
        {
            IRestResponse response = webService.GetEmployeeList();
            //Checking the status code
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Employee> responseData = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(6, responseData.Count);
        }
    }
}
