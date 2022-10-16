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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmployeeWebService empService = new EmployeeWebService();

            Employee obj = new Employee()
            {
                EmployeeName = EmpName.Text
            };

            MessageBox.Show(empService.InsertEmplRecord(obj));
        }
    }
}