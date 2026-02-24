using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RefactorCode.Interfaces;
using Domain;

namespace RefactorCode.Strategies
{
    public class VipStrategy : IDiscountStrategy
    {
        public bool IsApplicable(Order order)
        {
            return order.Customer != null && order.Customer.Type == UserType.VIP;
        }

        public decimal Calculate(Order order)
        {
            return order.TotalAmount * 0.20m;
        }
    }
}
