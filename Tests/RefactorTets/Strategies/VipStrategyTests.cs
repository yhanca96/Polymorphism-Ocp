using Domain;
using RefactorCode.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.RefactorTets.Strategies
{
    public class VipStrategyTests
    {
        [Fact]
        public void IsApplicable_WhenUserIsVip_ReturnsTrue()
        {
            // Arrange
            var order = new Order
            {
                Customer = new User { Type = UserType.VIP }
            };
            var strategy = new VipStrategy();

            // Act
            var result = strategy.IsApplicable(order);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Calculate_AlwaysReturns20PercentOfTotalAmount()
        {
            // Arrange
            var order = new Order { TotalAmount = 1000m };
            var strategy = new VipStrategy();

            // Act
            var discount = strategy.Calculate(order);

            // Assert
            Assert.Equal(200m, discount);
        }
    }
}
