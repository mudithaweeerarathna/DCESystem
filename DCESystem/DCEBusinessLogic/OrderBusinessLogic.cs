using DCEBusinessLogic.Interfaces;
using DCEDataAccess;
using DCEDataObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCEBusinessLogic
{
    public class OrderBusinessLogic : IOrderBusinessLogic
    {
        private readonly OrderDataAccess _dataAccess;
        public OrderBusinessLogic(IConfiguration configuration)
        {
            _dataAccess = new OrderDataAccess(configuration);
        }

        #region Get Order Details

        public List<OrderDetails> GetActiveOrdersByCustomer(Guid CustomerId)
        {
            try
            {
                return GetActiveOrdersByCustomer(0, CustomerId);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<OrderDetails> GetActiveOrdersByCustomer(int instance, Guid CustomerId)
        {
            return _dataAccess.GetActiveOrdersByCustomer(instance, CustomerId);
        }

        #endregion
    }
}
