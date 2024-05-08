using DCEDataObject;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DCEDataObject.Enumeration;

namespace DCEDataAccess
{
    public class OrderDataAccess
    {
        private readonly string _connectionString = null;

        public OrderDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DCEDevDb");
        }

        #region Get Order Details

        public List<OrderDetails> GetActiveOrdersByCustomer(int instance, Guid CustomerId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("USP_Order_GetActiveOrdersByCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Instance", SqlDbType.Int).Value = instance;
                command.Parameters.Add("@CustomerId", SqlDbType.UniqueIdentifier).Value = CustomerId;
                return GetCustomers(command.ExecuteReader());
            }
        }
        private List<OrderDetails> GetCustomers(SqlDataReader sqlDataReader)
        {
            try
            {
                List<OrderDetails> list = null;
                if (sqlDataReader.HasRows)
                {
                    list = new List<OrderDetails>();
                    while (sqlDataReader.Read())
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
        private OrderDetails GetCustomer(SqlDataReader sqlDataReader)
        {
            return new OrderDetails
            {
                OrderId = new Guid(sqlDataReader["OrderId"].ToString()),
                ProductId = new Guid(sqlDataReader["ProductId"].ToString()),
                OrderStatus = (OrderStatusEnum)Convert.ToInt32(sqlDataReader["OrderStatus"].ToString()),
                OrderType = (OrderTypeEnum)Convert.ToInt32(sqlDataReader["OrderType"].ToString()),
                OrderBy = new Guid(sqlDataReader["OrderBy"].ToString()),
                OrderdOn = Convert.ToDateTime(sqlDataReader["OrderDate"].ToString()),
                ShippedOn = Convert.ToDateTime(sqlDataReader["ShippedOn"].ToString()),
                IsActive = Convert.ToBoolean(sqlDataReader["OrderActive"].ToString()),
                ProductName = sqlDataReader["ProductName"].ToString(),
                UnitPrice = Convert.ToDecimal(sqlDataReader["UnitPrice"].ToString()),
                SupplierId = new Guid(sqlDataReader["SupplierId"].ToString()),
                ProductCreatedOn = Convert.ToDateTime(sqlDataReader["ProductCreatedOn"].ToString()),
                ProductActive = Convert.ToBoolean(sqlDataReader["ProductActive"].ToString()),
                SupplierName = sqlDataReader["SupplierName"].ToString(),
                SupplierCreatedOn = Convert.ToDateTime(sqlDataReader["SupplierCreatedOn"].ToString()),
                SupplierActive = Convert.ToBoolean(sqlDataReader["SupplierActive"].ToString())
            };
        }

        #endregion
    }
}
