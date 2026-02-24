using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorCode.Interfaces;
using Domain;

namespace RefactorCode
{
    public class OcpDiscountCalculator
    {
       
        private readonly IEnumerable<IDiscountStrategy> _strategies;

        public OcpDiscountCalculator(IEnumerable<IDiscountStrategy> strategies)
        {
            _strategies = strategies;
        }

        public decimal CalculateDiscount(Order order)
        {
            var applicableStrategies = _strategies.Where(s => s.IsApplicable(order)).ToList();   
            
            if (!applicableStrategies.Any())
                return 0;

            return applicableStrategies.Max(s => s.Calculate(order));
        }
    }
}
