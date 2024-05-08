using DCEDataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCEBusinessLogic.Interfaces
{
    public interface ICustomerBusinessLogic
    {
        Customer CreateCustomer(Customer customer);
        List<Customer> GetCustomers();
        void DeleteCustomer(Guid id);
    }
}
