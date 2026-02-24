using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace RefactorCode.Interfaces
{
    public interface IDiscountStrategy
    {
        bool IsApplicable(Order order);
        decimal Calculate(Order order);
    }
}
