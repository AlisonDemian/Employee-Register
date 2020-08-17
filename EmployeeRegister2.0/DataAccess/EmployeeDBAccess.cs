using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using EmployeeRegister2._0.Models;
using System.Data;

namespace EmployeeRegister2._0.DataAccess
{
    public class EmployeeDBAccess
    {
        //CONNECTION STRING
        public string connectionString(string connectionStr = "EmployeeRegister")
        {
            return ConfigurationManager.ConnectionStrings[connectionStr].ConnectionString;
        }

        //GET EMPLOYEES (List)
        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeeGetAll", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader dtReader = cmd.ExecuteReader();
                while (dtReader.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(dtReader["Employee_Id"].ToString());
                    emp.EmployeeFirstName = dtReader["Employee_FirstName"].ToString();
                    emp.EmployeeLastName = dtReader["Employee_LastName"].ToString();
                    emp.EmployeeEmail = dtReader["Employee_Email"].ToString();

                    employeeList.Add(emp);
                }
                connection.Close();
            }
            return employeeList;
        }

        //CREAT (INSERT EMPLOYEE)
        public void CreateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeeAdd", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeFirstName", employee.EmployeeFirstName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", employee.EmployeeLastName);
                cmd.Parameters.AddWithValue("@EmployeeEmail", employee.EmployeeEmail);
                cmd.Parameters.AddWithValue("@EmployeePassword", employee.EmployeePassword);

                connection.Open();  //OPEN
                cmd.ExecuteNonQuery(); //EXECUTE
                connection.Close();  //CLOSE
            }
        }

        //UPDATE EMPLOYEE
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeeUpdate", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeFirstName", employee.EmployeeFirstName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", employee.EmployeeLastName);
                cmd.Parameters.AddWithValue("@EmployeeEmail", employee.EmployeeEmail);
                    

                connection.Open();  //OPEN
                cmd.ExecuteNonQuery(); //EXECUTE
                connection.Close();  //CLOSE
            }

        }

        //DELETE EMPLOYEE
        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("EmployeeDeleteById", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", id);   // ID to delete


                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //GET BY ID 
        public Employee GetEmployeeById(int empId)
        {
            Employee emp = new Employee();

            using (SqlConnection connection = new SqlConnection(connectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("EmployeeReadById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", empId);
                
                SqlDataReader dtReader = cmd.ExecuteReader();
                while (dtReader.Read())
                {
                    emp.EmployeeId = Convert.ToInt32(dtReader["Employee_Id"].ToString());
                    emp.EmployeeFirstName = dtReader["Employee_FirstName"].ToString();
                    emp.EmployeeLastName = dtReader["Employee_LastName"].ToString();
                    emp.EmployeeEmail = dtReader["Employee_Email"].ToString();
                }

                dtReader.Close();
            }
            return emp;
        }

    }    
}