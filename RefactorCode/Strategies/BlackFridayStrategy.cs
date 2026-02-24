using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using RefactorCode.Interfaces;

namespace RefactorCode.Strategies
{
    public class BlackFridayStrategy : IDiscountStrategy
    {
        public bool IsApplicable(Order order)
        {
            return !string.IsNullOrEmpty(order.PromoCode) &&
                   order.PromoCode.ToUpper() == "BLACK50";
        }

        public decimal Calculate(Order order)
        {
            return order.TotalAmount * 0.50m;
        }
    }
}
