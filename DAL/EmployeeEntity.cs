using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DbDataReadWrite.Models;

namespace DbDataReadWrite.DAL
{
    public class EmployeeEntity
    {
        private string connection = @"data source = DESKTOP-7GUB027\SQLEXPRESS; initial catalog = SqlProjectdb; integrated security = True";
        private SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        public List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            string query = "SELECT * FROM Employee emp INNER JOIN Department dep ON emp.departmentID = dep.depID";
            sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                list.Add(new Employee {EmployeeID = Convert.ToInt32(sqlDataReader["emp_id"].ToString()),FirstName = sqlDataReader["emp_fname"].ToString(),
                    LastName = sqlDataReader["emp_Lname"].ToString(),
                    City = sqlDataReader["City"].ToString(), Salary = Convert.ToDouble(sqlDataReader["salary"].ToString()),
                    Age = Convert.ToInt32(sqlDataReader["age"].ToString()),
                    HireDate = Convert.ToDateTime(sqlDataReader["hire_date"]),
                    Department = new Department() { DempartmentID = Convert.ToInt32(sqlDataReader["departmentID"].ToString()),
                    Name = sqlDataReader["depName"].ToString()}
                });
            }
            return list;
        }
        public int AddEmployee(Employee employee)
        {
            int rowsAffected = 0;
            try
            {
                sqlConnection = new SqlConnection(connection);
                string query = "INSERT INTO Employee(emp_fname, emp_lname, City, salary, age, hire_date, departmentID) " +
                    "Values('"+employee.FirstName+ "', '"+employee.LastName+ "', '"+employee.City+ "', '"+employee.Salary+"'," +
                    "'"+employee.Age+ "','"+employee.HireDate+ "','"+employee.Department.DempartmentID+"')";
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                rowsAffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                return rowsAffected;
            }
            return rowsAffected;
        }
    }
}