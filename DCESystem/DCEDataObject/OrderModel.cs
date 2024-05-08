using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DCEDataObject.Enumeration;

namespace DCEDataObject
{
    public class Order : Product
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public Guid OrderBy { get; set; }
        public DateTime OrderdOn { get; set; }
        public DateTime ShippedOn { get; set; }
        public bool IsActive { get; set; }
    }

    public class OrderDetails : Order
    {
        public DateTime ProductCreatedOn { get; set; }
        public bool ProductActive { get; set; }
        public DateTime SupplierCreatedOn { get; set; }
        public bool SupplierActive { get; set; }
    }
}
