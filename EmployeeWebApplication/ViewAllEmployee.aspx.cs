using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WebServices;

namespace EmployeeWebApplication
{

    public partial class ViewAllEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeWebService client = new EmployeeWebService();
            GridView1.DataSource = client.GetAllEmplRecord();
            GridView1.DataBind();
        }




        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idText = Request.QueryString["id"];
            var id = int.Parse(idText);

            var empService = new EmployeeWebService();
             empService.DeleteEmplRecord();

            
            }

       


        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    //var empService = new EmployeeWebService();
        //    //var emps = empService.GetAllEmplRecord();

        //    //foreach (var emp in emps)
        //    //{
        //    //    MessageBox.Show(emp.EmployeeName);

        //    //}
        //}
    }
}