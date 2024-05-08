using DCEBusinessLogic;
using DCEBusinessLogic.Interfaces;
using DCEDataObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DCEWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusinessLogic _customerBl;
        public CustomerController(ICustomerBusinessLogic customerBusinessLogic)
        {
            _customerBl = customerBusinessLogic;
        }


        [HttpPost]
        [Route("Customers")]
        public Customer Customers(Customer customer)
        {
            _customerBl.CreateCustomer(customer);
            return customer;
        }

        [HttpGet]
        [Route("Customers")]
        public List<Customer> Customers()
        {
            return _customerBl.GetCustomers();
        }

        [HttpDelete]
        [Route("Customers/{id}")]
        public void Delete(Guid id)
        {
            _customerBl.DeleteCustomer(id);
        }
    }
}
