using DCEBusinessLogic.Interfaces;
using DCEDataObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCEWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusinessLogic _orderBusinessLogic;
        public OrderController(IOrderBusinessLogic orderBusinessLogic)
        {
            _orderBusinessLogic = orderBusinessLogic;
        }

        [HttpGet]
        [Route("ActiveOrdersByCustomer/{customerId}")]
        public List<OrderDetails> GetActiveOrdersByCustomer(Guid CustomerId)
        {
            return _orderBusinessLogic.GetActiveOrdersByCustomer(CustomerId);
        }
    }
}
