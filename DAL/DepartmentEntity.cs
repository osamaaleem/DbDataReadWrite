using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DbDataReadWrite.Models;

namespace DbDataReadWrite.DAL
{
    public class DepartmentEntity
    {
        private string connection = @"data source = DESKTOP-7GUB027\SQLEXPRESS; initial catalog = SqlProjectdb; integrated security = True";
        private SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        public List<Department> GetList()
        {
        
                List<Department> list = new List<Department>();
                string query = "SELECT * FROM Department";
                sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    list.Add(new Department() { DempartmentID = Convert.ToInt32(sqlDataReader["depID"].ToString()), Name = sqlDataReader["depName"].ToString()});
                }
                sqlConnection.Close();
            return list;
        }
    }
}