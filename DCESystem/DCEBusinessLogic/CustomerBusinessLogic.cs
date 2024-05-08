using DCEBusinessLogic.Interfaces;
using DCEDataAccess;
using DCEDataObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCEBusinessLogic
{
    public class CustomerBusinessLogic : ICustomerBusinessLogic
    {
        private readonly CustomerDataAccess _dataAccess;

        public CustomerBusinessLogic(IConfiguration configuration)
        {
            _dataAccess = new CustomerDataAccess(configuration);
        }

        #region Create Update Delete Customer

        public Customer CreateCustomer(Customer customer)
        {
            try
            {
                if (customer.UserId == null)
                {
                    customer.UserId = Guid.NewGuid();
                    return CreateCustomer(0, customer);
                }
                else
                {
                    return CreateCustomer(1, customer);
                }
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
        private Customer CreateCustomer(int instance, Customer customer)
        {
            _dataAccess.CreateCustomer(instance, customer);
            return customer;
        }

        public void DeleteCustomer(Guid id)
        {
            try
            {
                DeleteCustomer(0, id);
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
        private void DeleteCustomer(int instance, Guid guid)
        {
            _dataAccess.DeleteCustomer(instance, guid);
        }

        #endregion Create Customer

        #region Get Customers

        public List<Customer> GetCustomers()
        {
            try
            {
                return GetCustomers(0);
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
        private List<Customer> GetCustomers(int instance)
        {
            return _dataAccess.GetCustomers(instance);
        }

        #endregion
    }
}
