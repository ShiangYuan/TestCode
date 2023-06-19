using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.DAO
{
    public class TestCodeDao
    {

        public List<Customer> GetAllCustomers()
        {
            List<Customer> rc = new List<Customer>();
            try
            {
                string strSQL = "select * from [Northwind].[dbo].[Customers]";
                string connStr = GetConnectString();
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    rc = SqlMapper.Query<Customer>(sqlConnection, strSQL).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rc;
        }
        
        public Customer GetCustomerById(string CustomerID)
        {
            Customer rc = new Customer();
            DynamicParameters p = new DynamicParameters();
            try
            {
                string strSQL = "select * from [Northwind].[dbo].[Customers] where CustomerID=@CustomerID";
                string connStr = GetConnectString();
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    p.Add("CustomerID", CustomerID);
                    rc = SqlMapper.QueryFirstOrDefault<Customer>(sqlConnection, strSQL, p);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rc;
        }
        
        public string InsertCustomer(Customer customer)
        {
            string rc = "";
            DynamicParameters p = new DynamicParameters();
            try
            {
                string strSQL = @"INSERT INTO [Northwind].[dbo].[Customers]
                (CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax) 
                VALUES (@CustomerID,@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax)";
                string connStr = GetConnectString();
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    p.Add("CustomerID", customer.CustomerID);
                    p.Add("CompanyName", customer.CompanyName);
                    p.Add("ContactName", customer.ContactName);
                    p.Add("ContactTitle", customer.ContactTitle);
                    p.Add("Address", customer.Address);
                    p.Add("City", customer.City);
                    p.Add("Region", customer.Region);
                    p.Add("PostalCode", customer.PostalCode);
                    p.Add("Country", customer.Country);
                    p.Add("Phone", customer.Phone);
                    p.Add("Fax", customer.Fax);
                    SqlMapper.Execute(sqlConnection, strSQL, p);
                }
                rc = "SUCCESS";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rc;
        }
        
        public string UpdateCustomer(Customer customer)
        {
            string rc = "";
            DynamicParameters p = new DynamicParameters();
            try
            {
                string strSQL = @"UPDATE [Northwind].[dbo].[Customers] SET
                CompanyName=@CompanyName,ContactName=@ContactName,ContactTitle=@ContactTitle,Address=@ContactTitle,
                City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country,Phone=@Phone,Fax=@Fax 
                WHERE CustomerID=@CustomerID";
                string connStr = GetConnectString();
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    p.Add("CustomerID", customer.CustomerID);
                    p.Add("CompanyName", customer.CompanyName);
                    p.Add("ContactName", customer.ContactName);
                    p.Add("ContactTitle", customer.ContactTitle);
                    p.Add("Address", customer.Address);
                    p.Add("City", customer.City);
                    p.Add("Region", customer.Region);
                    p.Add("PostalCode", customer.PostalCode);
                    p.Add("Country", customer.Country);
                    p.Add("Phone", customer.Phone);
                    p.Add("Fax", customer.Fax);
                    SqlMapper.Execute(sqlConnection, strSQL, p);
                }
                rc = "SUCCESS";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rc;
        }
        
        public string DeleteCustomer(string CustomerID)
        {
            string rc = "";
            DynamicParameters p = new DynamicParameters();
            try
            {
                string strSQL = @"DELETE FROM [Northwind].[dbo].[Customers] WHERE CustomerID=@CustomerID";
                string connStr = GetConnectString();
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    p.Add("CustomerID", CustomerID);
                    SqlMapper.Execute(sqlConnection, strSQL, p);
                }
                rc = "SUCCESS";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rc;
        }

        private string GetConnectString()
        {
            return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
        }

    }
}
