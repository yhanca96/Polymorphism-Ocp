using System;
using LegacyCode;
using Domain;



namespace Tests.LegacyTest
{
    public class LegacyCalculatorTest
    {
        

        [Fact]
        public void CalculateDiscount_WhenPromoIsBlack50_Returns50Percent()
        {
            // Arrange
            var calculator = new DiscountCalculator();
            var order = new Order
            {
                TotalAmount = 1000m,
                PromoCode = "BLACK50" 
            };

            // Act
            var discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.Equal(500m, discount);
        }

        [Fact]
        public void CalculateDiscount_WhenUserIsVipAndNoPromo_Returns20Percent()
        {
            // Arrange
            var calculator = new DiscountCalculator();
            var order = new Order
            {
                TotalAmount = 1000m,
                Customer = new User { Type = UserType.VIP },
                PromoCode = "" 
            };

            // Act
            var discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.Equal(200m, discount);
        }

        [Fact]
        public void CalculateDiscount_WhenUserIsRegularUnder1000_ReturnsZero()
        {
            // Arrange
            var calculator = new DiscountCalculator();
            var order = new Order
            {
                TotalAmount = 500m, 
                Customer = new User { Type = UserType.Regular },
                PromoCode = null
            };

            // Act
            var discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.Equal(0m, discount);
        }
    }
}