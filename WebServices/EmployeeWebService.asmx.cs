using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for EmployeeWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string InsertEmplRecord(Employee obj)
        {
            obj.InsertRecord();

            string status = obj.InsertRecord();

            if (status == "PASS")
            {
                return "Employee New Record Inserted";
            }
            else
            {
                return "Inserte Failed Try Again";
            }

        }

        [WebMethod]
        public List<Employee> GetAllEmplRecord()
        {
            Employee obj = new Employee();
            return obj.GetAll();
        }

        [WebMethod]
        public void DeleteEmplRecord()
        {
            Employee obj = new Employee();
            obj.DeleteRecord(obj.Id);
        }

        [WebMethod]
        public void UpdateEmplRecord()
        {
            Employee obj = new Employee();
             obj.UpdateRecord(obj);
        }
    }
}
