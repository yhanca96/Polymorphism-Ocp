using System;
using Domain;
using System.Collections.Generic;

namespace LegacyCode
{
    public class DiscountCalculator
    {
        
        public decimal CalculateDiscount(Order order)
        {
            decimal discount = 0;

            // Condicional 1: Reglas de Marketing por cupón
            if (!string.IsNullOrEmpty(order.PromoCode) && order.PromoCode.ToUpper() == "BLACK50")
            {
                discount = order.TotalAmount * 0.50m;
            
            }
            else if (!string.IsNullOrEmpty(order.PromoCode) && order.PromoCode.ToUpper() == "SUMMER20")
            {
                discount = order.TotalAmount * 0.20m;
            }
           
            else if (order.Customer != null)
            {
                // Condicional 2: Reglas de Dominio por tipo de cliente
                switch (order.Customer.Type)
                {
                    case UserType.VIP:
                        discount = order.TotalAmount * 0.20m;
                        break;
                    case UserType.Premium:
                        discount = order.TotalAmount * 0.10m;
                        break;
                    case UserType.Regular:
                        if (order.TotalAmount > 1000)
                        {
                            discount = order.TotalAmount * 0.05m;
                        }
                        break;
                }
            }

            return discount;
        }
    }
}
