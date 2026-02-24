using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorCode.Interfaces;

namespace RefactorCode.Strategies
{
    public class LargeOrderStrategy : IDiscountStrategy
    {
        public bool IsApplicable(Order order)
        {
            return order.Customer != null &&
                   order.Customer.Type == UserType.Regular &&
                   order.TotalAmount > 1000;
        }

        public decimal Calculate(Order order)
        {
            return order.TotalAmount * 0.05m;
        }
    }
}
