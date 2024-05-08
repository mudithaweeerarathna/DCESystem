using DCEDataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCEBusinessLogic.Interfaces
{
    public interface IOrderBusinessLogic
    {
        List<OrderDetails> GetActiveOrdersByCustomer(Guid CustomerId);
    }
}
