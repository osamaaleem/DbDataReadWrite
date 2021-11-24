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
        public EmployeeEntity()
        {
            sqlConnection = new SqlConnection(connection);
        }
        private string connection = @"data source = DESKTOP-7GUB027\SQLEXPRESS; initial catalog = SqlProjectdb; integrated security = True";
        private SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        private string query;
        SqlDataReader sqlDataReader = null;
        public List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            query = "SELECT * FROM Employee emp INNER JOIN Department dep ON emp.departmentID = dep.depID";
            sqlConnection.Open();
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
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
                query = "INSERT INTO Employee(emp_fname, emp_lname, City, salary, age, hire_date, departmentID) " +
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
        public Employee GetEmployeeById(int id)
        {
            query = $"SELECT * FROM Employee emp INNER JOIN Department dep ON emp.departmentID=dep.depID WHERE emp_id = {id}";
            sqlConnection.Open();
            sqlCommand = new SqlCommand (query, sqlConnection);
            Employee employee = new Employee();
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                employee.EmployeeID = Convert.ToInt32(sqlDataReader["emp_id"].ToString());
                employee.FirstName = sqlDataReader["emp_fname"].ToString();
                employee.LastName = sqlDataReader["emp_Lname"].ToString();
                employee.Salary = Convert.ToDouble(sqlDataReader["salary"].ToString());
                employee.Age = Convert.ToInt32(sqlDataReader["age"].ToString());
                employee.HireDate = Convert.ToDateTime(sqlDataReader["hire_date"].ToString());
                employee.City = sqlDataReader["city"].ToString();
                employee.Department.DempartmentID = Convert.ToInt32(sqlDataReader["departmentID"]);
                employee.Department.Name = sqlDataReader["depName"].ToString();
            }
            return employee;
        }
        public bool UpdateEmployee(int id)
        {
            query = $"";
            return false;
        }
    }
}