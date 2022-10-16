using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServices
{
    public class Employee
    {
        private int _id;
        private string _employeeName;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }
        public Employee()
        {
        }

        readonly string conStr = @"Data Source=DESKTOP-IU72N5R;Initial Catalog=WebServiceEmpCrud;Integrated Security=True";

        public string InsertRecord()
        {
            //  string conStr = ConfigurationManager.ConnectionStrings["employeeDatabase"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand("SP_InsertEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", EmployeeName);

                connection.Open();
                int count = command.ExecuteNonQuery();

                if (count > 0)
                {
                    return "PASS";
                }
                else
                {
                    return "FAIL";
                }

            }
        }

        public List<Employee> GetAll()
        {
            var emp = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand("SP_GetAllEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new Employee
                        {
                            Id = (int)reader["ID"],
                            EmployeeName = (string)reader["EmpName"]

                        };

                        emp.Add(employee);
                    }
                }
            }
            return emp;
        }



        public void DeleteRecord(int id)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand("SP_DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                var rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected != 1)
                    throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");
            }
        }

        public Employee GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand("SP_GetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var employees = new Employee();
                        employees.Id = (int)reader["Id"];
                        employees.EmployeeName = (string)reader["EmpName"];
                        return employees;
                    }
                }
                return null;
            }
        }

        public void UpdateRecord(Employee emp)
        {
            string conStr = @"Data Source=DESKTOP-IU72N5R;Initial Catalog=WebServiceEmpCrud;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand("SP_UpdateRecord", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", emp.Id);
                command.Parameters.AddWithValue("@EmpName", emp.EmployeeName);
                connection.Open();

                var rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected != 1)
                    throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");
            }
        }
    }
}


