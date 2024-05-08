using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCEDataObject
{
    public class Enumeration
    {
        public enum OrderStatusEnum : int
        {
            Pending = 0,
            Approved = 1,
            Shipped = 2,
            PaymentPending = 3,
            PaymentComplete = 4
        }

        public enum OrderTypeEnum : int
        {
            StanderdOrder = 1,
            CustomOrder = 2,
            BulkOrder = 3,
            SubscriptionOrder = 4,
        }
    }
}
