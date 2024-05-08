using DCEDataObject;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DCEDataAccess
{
    public class CustomerDataAccess
    {
        private readonly string _connectionString = null;
        public CustomerDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DCEDevDb");
        }

        #region Create Update Delete Customer

        public void CreateCustomer(int instance, Customer customer)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("USP_Customer_CreateCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Instance", SqlDbType.Int).Value = instance;
                command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = customer.UserId == null ? DBNull.Value : customer.UserId;
                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = customer.UserName;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = customer.Email;
                command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = customer.FirstName;
                command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = customer.LastName;
                command.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = customer.CreatedOn;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = customer.IsActive;
                command.ExecuteScalar();
            }
        }

        public void DeleteCustomer(int instance, Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("USP_Customer_DeleteCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Instance", SqlDbType.Int).Value = instance;
                command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = id; ;
                command.ExecuteScalar();
            }
        }

        #endregion

        #region Get Customer Details

        public List<Customer> GetCustomers(int instance)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("USP_Customer_GetCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Instance", SqlDbType.Int).Value = instance;
                return GetCustomers(command.ExecuteReader());
            }
        }
        private List<Customer> GetCustomers(SqlDataReader sqlDataReader)
        {
            try
            {
                List<Customer> list = null;
                if(sqlDataReader.HasRows)
                {
                    list = new List<Customer>();
                    while(sqlDataReader.Read())
                    {
                        list.Add(GetCustomer(sqlDataReader));
                    }
                }
                return list;
            }
            finally
            {
                sqlDataReader.Close();
            }
        }
        private Customer GetCustomer(SqlDataReader sqlDataReader)
        {
            return new Customer
            {
                UserId = new Guid(sqlDataReader["UserId"].ToString()),
                UserName = sqlDataReader["UserName"].ToString(),
                Email = sqlDataReader["Email"].ToString(),
                FirstName = sqlDataReader["FirstName"].ToString(),
                LastName = sqlDataReader["LastName"].ToString(),
                CreatedOn = Convert.ToDateTime(sqlDataReader["CreatedOn"].ToString()),
                IsActive = Convert.ToBoolean(sqlDataReader["IsActive"].ToString())
            };
        }

        #endregion
    }
}
