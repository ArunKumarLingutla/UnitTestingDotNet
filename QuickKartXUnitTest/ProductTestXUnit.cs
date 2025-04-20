using AutoFixture;
using QuickKartBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartXUnitTest
{
    public class ProductTestXUnit
    {
        private Product product;

        


        //[Fact]
        //public void Check_InvalidQuantityException()
        //{
        //    // Arrange
        //    product = new Product("P001", "Shirt", 1, 1000, 20, 4);
        //    // Act and Assert
        //    Assert.Throws<InvalidQuantityException>(() => product.CalculateDiscountedPrice(0));
        //}

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Check_InvalidQuantityException(int quantity)
        {
            // Arrange
            product = new Product("P001", "Shirt", 1, 1000, 20, 4);
            // Act and Assert
            Assert.Throws<InvalidQuantityException>(() => product.CalculateDiscountedPrice(quantity));
        }

        //[Fact]
        //public void Check_QuantityGreaterThan10()
        //{
        //    //Arrange
        //    var fixture = new Fixture();
        //    product = new Product("P001", "Shirt", 1, 1000, 20, 4);
        //    //Act
        //    double totalPrice = product.CalculateDiscountedPrice(11);
        //    //Assert
        //    Assert.Equal(9350, totalPrice);
        //}

        [Theory]
        [InlineData(19, 16150)]
        [InlineData(11, 9350)]
        [InlineData(20, 17000)]
        public void Check_QuantityGreaterThan10(int quantity, double expected)
        {
            //Arrange
            var fixture = new Fixture();
            product = fixture.Build<Product>()
                .With(x => x.QuantityAvailable, 20)
                .With(y => y.Price, 1000)
                .Create();
            //Act
            double totalPrice = product.CalculateDiscountedPrice(quantity);
            //Assert
            Assert.Equal(expected, totalPrice);
        }

        [Theory]
        [InlineData(9, 8100)]
        [InlineData(6, 5400)]
        [InlineData(10, 9000)]
        public void Check_QuantityBetween5And10(int quantity, double expected)
        {
            //Arrange
            product = new Product("P001", "Shirt", 1, 1000, 20, 4);
            // Act
            double totalPrice = product.CalculateDiscountedPrice(quantity);
            // Assert
            Assert.Equal(expected, totalPrice);
        }

        //[Fact]
        //public void Check_QuantityBetween1And5()
        //{
        //    //Arrange
        //    product = new Product("P001", "Shirt", 1, 1000, 20, 4);
        //    //Act
        //    double totalPrice = product.CalculateDiscountedPrice(5);
        //    //Assert
        //    Assert.Equal(5000, totalPrice);
        //}

        [Theory]
        [InlineData(1, 1000)]
        [InlineData(2, 2000)]
        [InlineData(4, 4000)]
        [InlineData(5, 5000)]
        public void Check_QuantityBetween1And5(int quantity, double expected)
        {
            //Arrange
            product = new Product("P001", "Shirt", 1, 1000, 20, 4);
            // Act
            double totalPrice = product.CalculateDiscountedPrice(quantity);
            // Assert
            Assert.Equal(expected, totalPrice);
        }
    }
}
