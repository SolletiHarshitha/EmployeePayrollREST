using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoyeePayrollREST
{
    public class EmployeePayrollWebService
    {
        RestClient client;
        public EmployeePayrollWebService()
        {
            client = new RestClient("http://localhost:3000");
        }
        //Retrieve EmployeeList
        public IRestResponse GetEmployeeList()
        {
            RestRequest request = new RestRequest("/employees",Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
        //Add Employee to JSON
        public IRestResponse AddEmployee(Employee employee)
        {
            RestRequest request = new RestRequest("/employees", Method.POST);
            //Creating JSON object
            JsonObject json = new JsonObject();
            json.Add("name", employee.Name);
            json.Add("salary", employee.Salary);
            //Adding into JSON file
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
